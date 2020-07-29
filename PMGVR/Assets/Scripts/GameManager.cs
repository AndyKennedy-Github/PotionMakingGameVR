using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Timer t;
    public LevelManager lm;
    public Map map;

    public int totalGameGold, levelGold, levelGoldGoal, totalGameStars, levelStars, levelDif, level;
    public int firstStarGoal, secondStarGoal, thirdStarGoal;
    public int breathingTime = 5;

    public bool inLevel, inMap, levelEnded, goldAdded, starsAdded, isMapActive = true;

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

    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        t = FindObjectOfType<Timer>();
        map = FindObjectOfType<Map>();
        inLevel = false;
        isMapActive = true;
    }

    void Update()
    {
        if(inLevel)
        {
            StarCount();
            //t.startTime = true;
        }

        if(t.timeInRound <= 0)
        {
            StartCoroutine(EndOfLevel());           
        }

        if(isMapActive)
        {
            map.gameObject.SetActive(true);
        }
        else if(!isMapActive)
        {
            map.gameObject.SetActive(false);
        }
        Debug.Log(levelGold);
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetGoldGoal(1000);
            SceneManager.LoadScene(1);
            Debug.Log(levelGoldGoal);
        }
        */
    }

    public void ResetLevelGoldandStars()
    {
        levelGold = 0;
    }

    void StarCount()
    {
        if(levelGold > firstStarGoal && lm.levels[level].firstStarGot == false)
        {
            //display first star achieved!
            //Set up an animation to play here
            levelStars++; 
            lm.levels[level].firstStarGot = true;
        }
        else if(levelGold > secondStarGoal && lm.levels[level].secondStarGot == false)
        {
            //display second star achieved!
            //Set up an animation to play here
            levelStars++;
            lm.levels[level].secondStarGot = true;
        }
        else if(levelGold > thirdStarGoal && lm.levels[level].thirdStarGot == false)
        {
            //display third star achieved!
            //Set up an animation to play here
            levelStars++;
            lm.levels[level].thirdStarGot = true;
        }
    }

    public void AddGold(int i)
    {
        levelGold += i;
    }

   /* public void SetGoldGoal(int i)
    {
        levelGoldGoal = i;
    }
    */
    public void SetStarGoals(int a, int b, int c)
    {
        firstStarGoal = a;
        secondStarGoal = b;
        thirdStarGoal = c;
    }

    public int GetLevelDifficulty()
    {
        return levelDif;
    }

    public void SetLevelDifficulty(int i)
    {
        levelDif = i;
    }

    public void StartLevel(int i, int s)
    {
        StartCoroutine(LevelStart(i, s));
    }

    public void OnLoadData()
    {
        if (ES3.KeyExists("TotalGold"))
        {
            totalGameGold = ES3.Load<int>("TotalGold");
        }
        if (ES3.KeyExists("TotalStars"))
        {
            totalGameStars = ES3.Load<int>("TotalStars");
        }

        for (int i = 0; i < lm.levels.Count; i++)
        {
            if (ES3.KeyExists("Level " + i + " StarsAcquired"))
            {
                lm.levels[i].starsAcquired = ES3.Load<int>("Level " + i + " StarsAcquired");
            }
            if (ES3.KeyExists("Level " + i + " HighScore"))
            {
                lm.levels[i].goldHighScore = ES3.Load<int>("Level " + i + " HighScore");
            }
            lm.levels[i].firstStarGot = ES3.Load<bool>("Level " + i + " FirstStarGot");
            lm.levels[i].secondStarGot = ES3.Load<bool>("Level " + i + " SecondStarGot");
            lm.levels[i].thirdStarGot = ES3.Load<bool>("Level " + i + " ThirdStarGot"); 
        }
        map.mapType = 1;
    }

    IEnumerator LevelStart(int i, int s)
    {
        StopCoroutine("EndofLevel");
        isMapActive = false;
        yield return new WaitForSecondsRealtime(i);
        inLevel = true;
        t.timeInRound = s;
        t.startTime = true;
        goldAdded = false;
        starsAdded = false;
    }

    IEnumerator EndOfLevel()
    {
        StopCoroutine("LevelStart");
        isMapActive = true;
        Debug.Log("Running the End of Level checks!");
        inLevel = false;
        if(goldAdded == false)
        {
            totalGameGold += levelGold;
            goldAdded = true;
        }
        if (starsAdded == false)
        {
            totalGameStars += levelStars;
            lm.levels[level].starsAcquired += levelStars;
            starsAdded = true;
        }
        if(lm.levels[level].goldHighScore < levelGold)
        {
            lm.levels[level].goldHighScore = levelGold;
        }
        ResetLevelGoldandStars();
        ES3.Save("TotalGold", totalGameGold);
        ES3.Save("TotalStars", totalGameStars);
        //ES3.Save("Levels", lm.levels);
        for(int i = 0; i < lm.levels.Count; i++)
        {
            if(lm.levels[i].starsAcquired > 0)
            {
                ES3.Save("Level " + i + " StarsAcquired", lm.levels[i].starsAcquired);
            }
            if(lm.levels[i].goldHighScore > 0)
            {
                ES3.Save("Level " + i + " HighScore", lm.levels[i].goldHighScore);
            }
            ES3.Save("Level " + i + " FirstStarGot", lm.levels[level].firstStarGot);
            ES3.Save("Level " + i + " SecondStarGot", lm.levels[level].secondStarGot);
            ES3.Save("Level " + i + " ThirdStarGot", lm.levels[level].thirdStarGot);
        }
        levelEnded = true;
        yield return null;
    }
}
