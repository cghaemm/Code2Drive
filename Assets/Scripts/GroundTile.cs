using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    private float speed = 100f;
    private float deltaBuffer = 150f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
    }

    public void moveToStart() 
    {
        gameObject.transform.Translate(new Vector3(-deltaBuffer, 0, 0), Space.World);
    }
}
