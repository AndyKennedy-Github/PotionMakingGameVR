using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Potion
{
    int myColorIntensity, myPropertyIntensity, randomLevelNumber, randomPotionNumber;
    bool beingServed, potionObtained;
    GameManager gm;

    Color myColor = Color.Null;

    Property myProperty = Property.Null;

    // Start is called before the first frame update
    void Start()
    {
        beingServed = false;
        potionObtained = false;
        gm = FindObjectOfType<GameManager>();
        randomLevelNumber = Random.Range(0, 99);
        randomPotionNumber = Random.Range(0, 99);
        SetDesiredPotion(gm.GetLevelDifficulty());
    }

    // Update is called once per frame
    void Update()
    {
        if (!beingServed && !potionObtained)
        {
            //Have the character stand in a spot and stay there.
        }
        else if (beingServed && !potionObtained)
        {
            //Move to new spot and stay there. Probs passing through a trigger
            //that shows what thing they want on the screen
        }
        else if(potionObtained)
        {
            //Moves off screen (probs around carriage) and then despawning
            //Also transfers beingserved to next character in line
        }
    }
    
    void SetDesiredPotion(int i)
    {
        if(i == 0)
        {
            if (randomLevelNumber < 75)
            {
                MakeEasyPotion();
            }
            else if (randomLevelNumber < 97 && randomLevelNumber >= 75)
            {
                MakeMediumPotion();
            }
            else if (randomLevelNumber < 100 && randomLevelNumber >= 97)
            {
                MakeHardPotion();
            }
        }
        else if(i == 1)
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
        else if(i == 3)
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
        if(randomPotionNumber <= 49)
        {
            myProperty = Property.Null;
            myColor = (Color)Random.Range(0, 2);
            if(myColor.ToString() != "Null")
            {
                myColorIntensity = 1;
            }
        }
        else if(randomPotionNumber > 50)
        {
            myColor = Color.Null;
            myProperty = (Property)Random.Range(0, 4);
            if(myProperty.ToString() != "Null")
            {
                myPropertyIntensity = 1;
            }
        }
    }

    void MakeMediumPotion()
    {
        myColor = (Color)Random.Range(0, 5);
        myProperty = (Property)Random.Range(0, 4);
        if (myColor.ToString() == "Null")
        {
            myColorIntensity = 0;
        }
        else if(myColor.ToString() == "Yellow" || myColor.ToString() == "Red" || myColor.ToString() == "Blue")
        {
            myColorIntensity = Random.Range(1, 2);
        }
        else if(myColor.ToString() == "Purple" || myColor.ToString() == "Orange" || myColor.ToString() == "Green")
        {
            myColorIntensity = 2;
        }

        if (myProperty.ToString() != "Null")
        {
            myPropertyIntensity = Random.Range(1,2);
        }
    }

    void MakeHardPotion()
    {
        myColor = (Color)Random.Range(0, 6);
        myProperty = (Property)Random.Range(0, 3);
        if (myColor.ToString() == "Yellow" || myColor.ToString() == "Red" || myColor.ToString() == "Blue")
        {
            myColorIntensity = Random.Range(2, 3);
        }
        else if (myColor.ToString() == "Purple" || myColor.ToString() == "Orange" || myColor.ToString() == "Green")
        {
            myColorIntensity = 2;
        }
        else if(myColor.ToString() == "Brown")
        {
            myColorIntensity = 3;
        }
        myPropertyIntensity = Random.Range(1, 3);
    }

    void MakeExpertPotion()
    {
        myColor = Color.Brown;
        myProperty = (Property)Random.Range(0, 3);
        myPropertyIntensity = 3;
    }
}
