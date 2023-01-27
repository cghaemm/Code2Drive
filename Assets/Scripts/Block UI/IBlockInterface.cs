using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBlockInterface : MonoBehaviour
{
    protected bool finished;
    protected CanvasGroup canvasGroup;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        finished = false;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public abstract void BlockRun();

    public virtual bool getStatus()
    {
        return finished;
    }

    public virtual void blockRaycast()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public virtual void unBlockRaycast() {
        canvasGroup.blocksRaycasts = true;
    }

    public void resetBlock()
    {
        finished = false;
        canvasGroup.blocksRaycasts = true;
    }
}
