using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        t = FindObjectOfType<Timer>();
        StartCoroutine(LevelStart(breathingTime));
    }

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
        levelStars = 0;
    }

    void StarCount()
    {
        if(levelGold > firstStarGoal)
        {
            //display first star achieved!
            //Set up an animation to play here
            levelStars = 1;
            Debug.Log("You reached the first star goal!");
        }
        else if(levelGold > secondStarGoal)
        {
            //display second star achieved!
            //Set up an animation to play here
            levelStars = 2;
        }
        else if(levelGold > thirdStarGoal)
        {
            //display third star achieved!
            //Set up an animation to play here
            levelStars = 3;
        }
    }

    public void AddGold(int i)
    {
        levelGold += i;
    }

    public void SetGoldGoal(int i)
    {
        levelGoldGoal = i;
    }

    public void SetStarGoals(int a, int b, int c)
    {
        firstStarGoal = a;
        secondStarGoal = b;
        thirdStarGoal = c;
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
