using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject npc;
    public int npcRecharge = 3, npcMax = 5;
    public Transform startpos;
    public List<NPC> npcs = new List<NPC>();
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(Wait());
    }

    public void StopNPCs()
    {
        StopCoroutine(Wait());
    }

    public void StartNPCs()
    {
        StartCoroutine(Wait());
    }

    public void RemoveNPC(GameObject g)
    {
        npcs.Remove(g.GetComponent<NPC>());
        Destroy(g);
    }

    void SpawnNPC()
    {
        GameObject currentNPC = Instantiate(npc, startpos.position, Quaternion.identity);
        npcs.Add(currentNPC.GetComponent<NPC>());
        currentNPC = null;
    }

    public int GetSpotInList(NPC c)
    {
        return npcs.IndexOf(c);
    }

    public NPC GetWaitingNPC()
    {
        foreach(NPC npc in npcs)
        {
            if(npc.beingServed == true)
            {
                return npc;
            }
            else if(npc.beingServed == false)
            {
                return null;
            }
        }
        return null;
    }

    IEnumerator Wait()
    {
        while(true)
        {
            while (npcs.Count < npcMax && gm.inLevel)
            {
                SpawnNPC();
                yield return new WaitForSecondsRealtime(npcRecharge);
            }
            yield return null;
        } 
    }
}
