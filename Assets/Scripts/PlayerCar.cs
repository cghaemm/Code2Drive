using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("TurnRight", false);
        animator.SetBool("TurnLeft", false);

        animator.SetBool("LeftTurnSignal", false);
        animator.SetBool("RightTurnSignal", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            turnLeft();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            turnRight();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            goStraight();
        }

        // Left Turn Signal
        if(Input.GetKeyDown(KeyCode.Q))
        {
            // Only turn left turn signal on if right turn signal is off
            if(!animator.GetBool("RightTurnSignal"))
            {
                // Turn off turn signal if already on
                if(animator.GetBool("LeftTurnSignal"))
                {
                    animator.SetBool("LeftTurnSignal", false);
                }
                // Turn on turn signal
                else
                {
                    animator.SetBool("LeftTurnSignal", true);
                }
            }
        }

        // Right Turn Signal
        if(Input.GetKeyDown(KeyCode.E))
        {
            // Only turn the right turn signal on if the left turn signal is off
            if(!animator.GetBool("LeftTurnSignal"))
            {
                // Turn off turn signal if already on
                if(animator.GetBool("RightTurnSignal"))
                {
                    animator.SetBool("RightTurnSignal", false);
                }
                // Turn on turn signal
                else
                {
                    animator.SetBool("RightTurnSignal", true);
                }
            }
           
        }
        
    }

    public void turnLeft()
    {
        animator.SetBool("TurnLeft", true);
        animator.SetBool("TurnRight", false);
    }

    public void turnRight()
    {
        animator.SetBool("TurnRight", true);
        animator.SetBool("TurnLeft", false);
    }

    public void goStraight()
    {
        animator.SetBool("TurnRight", false);
        animator.SetBool("TurnLeft", false);
    }







}
