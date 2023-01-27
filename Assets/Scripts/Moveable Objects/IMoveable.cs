using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMoveable : MonoBehaviour
{
    protected float speed = 100f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed,0,0) * Time.deltaTime, Space.World);
    }

    public abstract void moveToStart();
}
