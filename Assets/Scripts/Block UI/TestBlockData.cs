using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestBlockData : MonoBehaviour, IBlockInterface
{
    public float data = 5f;

    public float maxTimeLeft = 1.5f;
    private float timeLeft;

    private bool finished = false;
    private bool updateTime = false;
    private CanvasGroup canvasGroup;

    public void Awake()
    {
        timeLeft = maxTimeLeft;
        canvasGroup = GetComponent<CanvasGroup>();
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

    public void blockRaycast()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void resetBlock()
    {
        updateTime = false;
        timeLeft = maxTimeLeft;
        finished = false;
        canvasGroup.blocksRaycasts = true;
    }

    public bool getStatus()
    {
        return finished;
    }

}
