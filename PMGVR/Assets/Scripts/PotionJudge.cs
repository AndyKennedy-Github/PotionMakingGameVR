using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionJudge : MonoBehaviour
{
    NPCManager npcgm;
    PotionManager pm;
    // Start is called before the first frame update
    void Start()
    {
        npcgm = FindObjectOfType<NPCManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bottle"))
        {
            if(npcgm.GetWaitingNPC().GetNPCPotion().ToString() == other.GetComponent<Bottle>().GetPotionInBottleName().ToString())
            {
                Debug.Log("That was the right potion!");
                Debug.Log(npcgm.GetWaitingNPC().GetNPCPotion().ToString());
                Debug.Log(other.GetComponent<Bottle>().GetPotionInBottleName().ToString());
                npcgm.GetWaitingNPC().NPCServed(true);
            }
            else if (npcgm.GetWaitingNPC().GetNPCPotion().ToString() != other.GetComponent<Bottle>().GetPotionInBottleName().ToString())
            {
                Debug.Log("That was the wrong potion!");
                Debug.Log(npcgm.GetWaitingNPC().GetNPCPotion().ToString());
                Debug.Log(other.GetComponent<Bottle>().GetPotionInBottleName().ToString());
                npcgm.GetWaitingNPC().NPCServed(false);
            }
            //Destroy(other.gameObject);
        }
    }
}
