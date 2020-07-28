using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int levelDif, firstStarGoal, secondStarGoal, thirdStarGoal, unlockStars, totalLevelStars, level, goldHighScore, timeInLevel, starsAcquired;

    public bool isUnlocked = false, firstStarGot, secondStarGot, thirdStarGot;

    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.totalGameStars >= unlockStars)
        {
            isUnlocked = true;
        }
    }
}
