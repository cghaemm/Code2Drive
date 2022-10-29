using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLine : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 100f;

    private float deltaBuffer = 120f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
    }

    public void moveToStart()
    {
        rb.transform.Translate(new Vector3(-deltaBuffer, 0, 0), Space.World);
    }
}
