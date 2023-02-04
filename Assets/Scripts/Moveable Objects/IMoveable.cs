using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMoveable : MonoBehaviour
{
    protected float speed = 100f;
    protected bool move = true;

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            gameObject.transform.Translate(new Vector3(speed,0,0) * Time.deltaTime, Space.World);
        }
    }

    public void stopMoving()
    {
        move = false;
    }

    public abstract void moveToStart();
}
