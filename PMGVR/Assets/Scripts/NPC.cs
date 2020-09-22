using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PuppetJump.Objs
{
    public class NPC : Potion
    {
        int myColorIntensity, myPropertyIntensity, randomLevelNumber, randomPotionNumber, prevNPC, spotInList, goldAmount;
        public bool beingServed, potionObtained;
        GameManager gm;
        NPCManager npcgm;
        Potion myPotion;
        public Transform windowSpot, endSpot;
        NavMeshAgent agent;

        Color wantedColor = Color.Null;

        Property wantedProperty = Property.Null;

        // Start is called before the first frame update
        void Start()
        {
            myPotion = GetComponent<Potion>();
            beingServed = false;
            potionObtained = false;
            npcgm = FindObjectOfType<NPCManager>();
            gm = FindObjectOfType<GameManager>();
            agent = GetComponent<NavMeshAgent>();
            randomLevelNumber = Random.Range(0, 99);
            randomPotionNumber = Random.Range(0, 99);
            SetDesiredPotion(gm.GetLevelDifficulty());
            Debug.Log(GetNPCPotion());
        }

        // Update is called once per frame
        void Update()
        {
            if (npcgm.npcs[0] == this || npcgm.npcs[FindPreviousNPC()].potionObtained)
            {
                beingServed = true;
            }
            if (!beingServed && !potionObtained)
            {
                agent.destination = new Vector3(npcgm.npcs[FindPreviousNPC()].transform.position.x, npcgm.npcs[FindPreviousNPC()].transform.position.y, npcgm.npcs[FindPreviousNPC()].transform.position.z - 2.0f);
                Debug.Log(FindPreviousNPC());
                //Have the character stand in a spot and stay there.
            }
            else if (beingServed && !potionObtained)
            {
                agent.destination = new Vector3(.0f, transform.position.y, -3.0f);//windowSpot.position;
                Debug.Log("I'm moving to the window!");
                //Move to new spot and stay there. Probs passing through a trigger
                //that shows what thing they want on the screen
            }
            else if (potionObtained)
            {
                agent.destination = endSpot.position;
                beingServed = false;
                //Moves off screen (probs around carriage) and then despawning
                //Also transfers beingserved to next character in line
            }

            DestroyNPC();
        }

        int FindPreviousNPC()
        {
            prevNPC = npcgm.GetSpotInList(this) - 1;
            return prevNPC;
        }

        void SetDesiredPotion(int i)
        {
            if (i == 0)
            {
                if (randomLevelNumber < 75)
                {
                    MakeEasyPotion();
                    SetGoldAmount(100);
                }
                else if (randomLevelNumber < 97 && randomLevelNumber >= 75)
                {
                    MakeMediumPotion();
                    SetGoldAmount(200);
                }
                else if (randomLevelNumber < 100 && randomLevelNumber >= 97)
                {
                    MakeHardPotion();
                    SetGoldAmount(300);
                }
            }
            else if (i == 1)
            {
                if (randomLevelNumber < 20)
                {
                    MakeEasyPotion();
                }
                else if (randomLevelNumber < 71 && randomLevelNumber >= 20)
                {
                    MakeMediumPotion();
                }
                else if (randomLevelNumber < 98 && randomLevelNumber >= 71)
                {
                    MakeHardPotion();
                }
                else if (randomLevelNumber >= 98)
                {
                    MakeExpertPotion();
                }
            }
            else if (i == 2)
            {
                if (randomLevelNumber < 6)
                {
                    MakeEasyPotion();
                }
                else if (randomLevelNumber < 20 && randomLevelNumber >= 6)
                {
                    MakeMediumPotion();
                }
                else if (randomLevelNumber < 80 && randomLevelNumber >= 20)
                {
                    MakeHardPotion();
                }
                else if (randomLevelNumber >= 80)
                {
                    MakeExpertPotion();
                }
            }
            else if (i == 3)
            {
                if (randomLevelNumber < 6)
                {
                    MakeEasyPotion();
                }
                else if (randomLevelNumber < 20 && randomLevelNumber >= 6)
                {
                    MakeMediumPotion();
                }
                else if (randomLevelNumber < 40 && randomLevelNumber >= 20)
                {
                    MakeHardPotion();
                }
                else if (randomLevelNumber >= 40)
                {
                    MakeExpertPotion();
                }
            }
        }

        void MakeEasyPotion()
        {
            if (randomPotionNumber <= 49)
            {
                wantedProperty = Property.Null;
                wantedColor = (Color)Random.Range(0, 2);
                if (wantedColor.ToString() != "Null")
                {
                    myColorIntensity = 1;
                }
            }
            else if (randomPotionNumber > 50)
            {
                wantedColor = Color.Null;
                wantedProperty = (Property)Random.Range(0, 4);
                if (wantedProperty.ToString() != "Null")
                {
                    myPropertyIntensity = 1;
                }
            }
            myPotion.SetPotionColor(wantedColor);
            myPotion.SetPotionColorIntensity(myColorIntensity);
            myPotion.SetPotionProperty(wantedProperty);
            myPotion.SetPotionProperyIntensity(myPropertyIntensity);
            goldAmount = 100;
        }

        void MakeMediumPotion()
        {
            wantedColor = (Color)Random.Range(0, 5);
            wantedProperty = (Property)Random.Range(0, 4);
            if (wantedColor.ToString() == "Null")
            {
                myColorIntensity = 0;
            }
            else if (wantedColor.ToString() == "Yellow" || wantedColor.ToString() == "Red" || wantedColor.ToString() == "Blue")
            {
                myColorIntensity = Random.Range(1, 2);
            }
            else if (wantedColor.ToString() == "Purple" || wantedColor.ToString() == "Orange" || wantedColor.ToString() == "Green")
            {
                myColorIntensity = 2;
            }

            if (wantedProperty.ToString() != "Null")
            {
                myPropertyIntensity = Random.Range(1, 2);
            }
            myPotion.SetPotionColor(wantedColor);
            myPotion.SetPotionColorIntensity(myColorIntensity);
            myPotion.SetPotionProperty(wantedProperty);
            myPotion.SetPotionProperyIntensity(myPropertyIntensity);
            goldAmount = 200;
        }

        void MakeHardPotion()
        {
            wantedColor = (Color)Random.Range(0, 6);
            wantedProperty = (Property)Random.Range(0, 4);
            if (wantedColor.ToString() == "Yellow" || wantedColor.ToString() == "Red" || wantedColor.ToString() == "Blue")
            {
                myColorIntensity = Random.Range(2, 3);
            }
            else if (wantedColor.ToString() == "Purple" || wantedColor.ToString() == "Orange" || wantedColor.ToString() == "Green")
            {
                myColorIntensity = 2;
            }
            else if (wantedColor.ToString() == "Brown")
            {
                myColorIntensity = 3;
            }
            myPropertyIntensity = Random.Range(1, 3);
            myPotion.SetPotionColor(wantedColor);
            myPotion.SetPotionColorIntensity(myColorIntensity);
            myPotion.SetPotionProperty(wantedProperty);
            myPotion.SetPotionProperyIntensity(myPropertyIntensity);
            goldAmount = 300;
        }

        void MakeExpertPotion()
        {
            wantedColor = Color.Brown;
            wantedProperty = (Property)Random.Range(0, 4);
            myPropertyIntensity = 3;
            myPotion.SetPotionColor(wantedColor);
            myPotion.SetPotionColorIntensity(myColorIntensity);
            myPotion.SetPotionProperty(wantedProperty);
            myPotion.SetPotionProperyIntensity(myPropertyIntensity);
            goldAmount = 400;
        }

        void SetGoldAmount(int i)
        {
            goldAmount = i;
        }

        public string GetNPCPotion()
        {
            return myPotion.GetPotionName();
        }

        public void NPCServed(bool b)
        {
            if (b)
            {
                Debug.Log("I've added the money to the bank!");
                gm.AddGold(goldAmount);
                potionObtained = true;
            }
            else if (!b)
            {
                potionObtained = true;
            }
        }

        void DestroyNPC()
        {
            if (gm.inLevel == false)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
