using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public List<Level> levels = new List<Level>();
    public GameManager gm;

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
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        for(int i = 0; i < levels.Count; i++)
        {
            levels[i].level = i;
        }
    }

    public void LoadLevel(Level l)
    {
        if(l.isUnlocked == true)
        {
            gm.level = l.level;
            gm.levelDif = l.levelDif;
            gm.firstStarGoal = l.firstStarGoal;
            gm.secondStarGoal = l.secondStarGoal;
            gm.thirdStarGoal = l.thirdStarGoal;
            gm.StartLevel(gm.breathingTime, l.timeInLevel);
            Debug.Log("The Level is loaded!");
        }
    }

    public void LoadTutorial()
    {
        gm.level = 0;
        gm.levelDif = 0;
        gm.StartLevel(gm.breathingTime, 60000);
    }
}
