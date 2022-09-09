using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BlockData : MonoBehaviour, BlockInterface
{
    public float test = 5f;
    public float timeLeft = 1.5f;
    private bool finished = false;
    private bool updateTime = false;

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
}
