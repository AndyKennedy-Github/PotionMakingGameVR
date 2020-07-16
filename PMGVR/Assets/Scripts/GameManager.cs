using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Timer t;

    int totalGameGold, levelGold, levelGoldGoal, totalGameStars, levelStars;
    int firstStarGoal, secondStarGoal, thirdStarGoal;
    public int breathingTime = 5;

    public bool inLevel, inMap, levelEnded;

    void Awake()
    {
        if(instance == null)
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
        t = FindObjectOfType<Timer>();
        StartCoroutine(LevelStart(breathingTime));
    }

    // Update is called once per frame
    void Update()
    {
        if(inLevel)
        {
            StarCount();
        }

        if(levelEnded == true)
        {
            EndOfLevel();
            levelEnded = false;
        }
    }

    public void ResetLevelGoldandStars()
    {
        levelGold = 0;
        levelStars = 0;
    }

    public void SetLevelGoal(int i)
    {
        levelGoldGoal = i;
    }

    void StarCount()
    {
        if(levelGold > firstStarGoal)
        {
            //display first star achieved!
            levelStars = 1;
        }
        else if(levelGold > secondStarGoal)
        {
            //display second star achieved!
            levelStars = 2;
        }
        else if(levelGold > thirdStarGoal)
        {
            //display third star achieved!
            levelStars = 3;
        }
    }

    IEnumerator LevelStart(int i)
    {
        yield return new WaitForSecondsRealtime(i);
        t.startTime = true;
    }

    IEnumerator EndOfLevel()
    {
        totalGameGold += levelGold;
        totalGameStars += levelStars;
        yield return null;
    }
}
