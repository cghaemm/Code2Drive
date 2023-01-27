using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLine : IMoveable
{
    private float deltaBuffer = 120f;

    public override void moveToStart()
    {
        gameObject.transform.Translate(new Vector3(-deltaBuffer, 0, 0), Space.World);
    }
}
