using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlockData : MonoBehaviour
{
    public float data = 5f;

    public float maxTimeLeft = 1.5f;
    private float timeLeft;

    private bool finished = false;
    private bool updateTime = false;


    public void Awake()
    {
        timeLeft = maxTimeLeft;
    }

    public void BlockRun()
    {
        updateTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(updateTime)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0 && !finished)
            {
                finished = true;
                Debug.Log("FINISHED");
            }
        }
    }

    public bool getStatus()
    {
        return finished;
    }
}
