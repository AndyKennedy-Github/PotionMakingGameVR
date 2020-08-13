using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public OutfitManager om;
    public GameManager gm;
    public List<GameObject> items = new List<GameObject>();
    // Start is called before the first frame update
    public void ActivateItem(int i)
    {
        items[i].SetActive(true);
    }
}
