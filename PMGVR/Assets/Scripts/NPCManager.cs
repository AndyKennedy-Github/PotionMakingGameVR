using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject npc;
    public Transform startpos;
    public List<NPC> npcs = new List<NPC>();
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveNPC(GameObject g)
    {
        Debug.Log("I removed the knight!");
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

    IEnumerator Wait()
    {
        while(true)
        {
            while (npcs.Count < 5)
            {
                SpawnNPC();
                yield return new WaitForSecondsRealtime(2);
            }
            yield return null;
        } 
    }
}
