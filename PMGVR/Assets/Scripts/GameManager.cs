using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int totalGameGold, levelGold, levelGoldGoal, totalGameStars, levelStars;
    int firstStarGoal, secondStarGoal, thirdStarGoal;

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

    }

    // Update is called once per frame
    void Update()
    {
        if(inLevel)
        {
            StarCount();
        }

        /*if(levelEnded == false)
         {
            EndOfLevel();
            levelEnded = true;
         }
         */
        
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

    IEnumerator EndOfLevel()
    {
        totalGameGold += levelGold;
        totalGameStars += levelStars;
        yield return null;
    }
}
