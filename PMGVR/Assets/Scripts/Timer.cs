using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeInRound = 120;
    public bool startTime;
    // Start is called before the first frame update
    void Start()
    {
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
                return;
            }
        }
    }
}
