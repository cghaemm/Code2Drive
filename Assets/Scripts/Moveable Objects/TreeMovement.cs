using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : IMoveable
{
    private float deltaBuffer = 125f;

    public override void moveToStart()
    {
        float randomBuffer = Random.Range(-10f, 10f);
        gameObject.transform.Translate(new Vector3(-deltaBuffer + randomBuffer, 0, 0), Space.World);
    }
}
