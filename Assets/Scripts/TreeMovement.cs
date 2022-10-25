using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 100f;

    private float deltaBuffer = 125f;

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
        float randomBuffer = Random.Range(-10f, 10f);
        rb.transform.Translate(new Vector3(-deltaBuffer + randomBuffer, 0, 0), Space.World);
    }
}
