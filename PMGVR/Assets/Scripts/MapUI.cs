using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public static MapUI instance;
    public Map map;
    public List<GameObject> gameStartButtons = new List<GameObject>();
    public List<GameObject> mapMarkers = new List<GameObject>();
    public List<GameObject> optionButtons = new List<GameObject>();
    public List<GameObject> storeCatalog = new List<GameObject>();

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
    // Update is called once per frame
    void Update()
    {
        MapCheck();
    }

    void MapCheck()
    {
        if (gameObject.activeInHierarchy)
        {
            switch (map.mapType)
            {
                case 0:
                    foreach (GameObject buttons in gameStartButtons)
                    {
                        buttons.SetActive(true);
                    }
                    foreach (GameObject buttons in mapMarkers)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in optionButtons)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in storeCatalog)
                    {
                        buttons.SetActive(false);
                    }
                    break;
                case 1:
                    foreach (GameObject buttons in gameStartButtons)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in mapMarkers)
                    {
                        buttons.SetActive(true);
                    }
                    foreach (GameObject buttons in optionButtons)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in storeCatalog)
                    {
                        buttons.SetActive(false);
                    }
                    break;
                case 2:
                    foreach (GameObject buttons in gameStartButtons)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in mapMarkers)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in optionButtons)
                    {
                        buttons.SetActive(true);
                    }
                    foreach (GameObject buttons in storeCatalog)
                    {
                        buttons.SetActive(false);
                    }
                    break;
                case 3:
                    foreach (GameObject buttons in gameStartButtons)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in mapMarkers)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in optionButtons)
                    {
                        buttons.SetActive(false);
                    }
                    foreach (GameObject buttons in storeCatalog)
                    {
                        buttons.SetActive(true);
                    }
                    break;
            }

        }
    }
}
