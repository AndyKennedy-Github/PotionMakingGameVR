using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float timeInRound = 120;
    public bool startTime;
    private GameManager gm;

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
        gm = FindObjectOfType<GameManager>();
        startTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime)
        {
            timeInRound -= Time.deltaTime;
            if (timeInRound < 0)
            {
                gm.levelEnded = true;
                startTime = false;
            }
        }
    }
}
