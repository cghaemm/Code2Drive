using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BlockData : MonoBehaviour, BlockInterface
{
    public float test = 5f;
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

    public async void BlockRun()
    {
        updateTime = true;
        while(timeLeft > 0)
        {
            await Task.Yield();
        }
        finished = true;
        //Debug.Log("FINISHED");
    }

    public void Update()
    {
        if(updateTime)
        {
            timeLeft -= Time.deltaTime;
        }
    }

    public bool getStatus()
    {
        return finished;
    }

    public void blockRaycast()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void resetBlock()
    {
        finished = false;
        updateTime = false;
        timeLeft = maxTimeLeft;
        canvasGroup.blocksRaycasts = true;
    }
}
