using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    public static OutfitManager instance;
    public GameObject currentOutfit;
    public List<GameObject> outfits = new List<GameObject>();
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if(ES3.KeyExists("Current Outfit"))
        {
            currentOutfit = ES3.Load<GameObject>("Current Outfit");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (currentOutfit != null)
        {
            currentOutfit.SetActive(true);
        }
        foreach(GameObject obj in outfits)
        {
            if(obj != currentOutfit)
            {
                obj.SetActive(false);
            }
        }
    }
}
