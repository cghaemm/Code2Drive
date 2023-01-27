using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : IMoveable
{    
    private float deltaBuffer = 150f;

    public override void moveToStart() 
    {
        gameObject.transform.Translate(new Vector3(-deltaBuffer, 0, 0), Space.World);
    }
}
