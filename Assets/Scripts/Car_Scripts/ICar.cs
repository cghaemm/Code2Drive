using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICar : MonoBehaviour
{
    protected bool moving;
    private float crashForwardDistance = 100f;
    protected Rigidbody rb;
    protected Vector3 destination;

    [SerializeField]
    protected float speed = 0.2f;

    [SerializeField]
    private AnimationCurve _curve;
    private float _target;
    private float current;

    private bool crashed;

    public void Start()
    {
        crashed = false;
        rb = GetComponent<Rigidbody>();
        moving = false;
        destination = new Vector3(transform.position.x, transform.position.y, 
            transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!crashed) {
            if(transform.position == destination)
            {
                //_target = 0;
                current = 0;
                if(isMoving() == true)
                {
                    finishedMoving();
                    Debug.Log("Finished Moving");
                }
            }
            else
            {
                _target = 1;
            }

            //Debug.Log(_target);
            current = Mathf.MoveTowards(current, _target, speed * Time.fixedDeltaTime);
            transform.position = Vector3.Lerp(transform.position, destination, _curve.Evaluate(current));
            //Debug.Log(destination);
        }
    }

    protected bool isMoving()
    {
        return moving;
    }

    protected void finishedMoving()
    {
        moving = false;
    }

    public void crash_move_forward()
    {
        speed = speed/2;
        destination = new Vector3(gameObject.transform.position.x - crashForwardDistance, gameObject.transform.position.y,
        gameObject.transform.position.z);
    }

    public void hitByPlayer(Vector3 dv) {
        float upwardForce = 220f;
        float directionalForce = 250f;
        crashed = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        rb.AddForce(transform.up * upwardForce);
        rb.AddForce(dv * directionalForce);

        // torque for spins
        Vector3 torqueRotation = new Vector3(dv.z/2, dv.y, dv.x*-1);
        Debug.Log(dv);
        rb.AddTorque(torqueRotation * directionalForce/2);
    }
}
