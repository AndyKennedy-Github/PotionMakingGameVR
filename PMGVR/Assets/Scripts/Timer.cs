using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PuppetJump.Objs
{
    public class Timer : MonoBehaviour
    {
        public static Timer instance;
        public float timeInRound = 120;
        public bool startTime;
        private GameManager gm;
        public Text timeText;

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
            if (startTime)
            {
                timeInRound -= Time.deltaTime;
                DisplayTime(timeInRound);
                if (timeInRound <= 0)
                {
                    Debug.Log("Time's up!");
                    gm.levelEnded = true;
                    startTime = false;
                }
            }
        }

        void DisplayTime(float timeToDisplay)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
