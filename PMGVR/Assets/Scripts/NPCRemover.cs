using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRemover : MonoBehaviour
{
    public NPCManager npcgm;

    private void Start()
    {
        npcgm = FindObjectOfType<NPCManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        npcgm.RemoveNPC(other.gameObject);
        if (other.CompareTag("Knight"))
        {
            npcgm.RemoveNPC(other.gameObject);
        }
    }
}
