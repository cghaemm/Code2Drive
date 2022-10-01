using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    private Animator animator;
    private bool turnLeftWithSignal;
    private bool turnRightWithSignal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("TurnRight", false);
        animator.SetBool("TurnLeft", false);

        animator.SetBool("LeftTurnSignal", false);
        animator.SetBool("RightTurnSignal", false);

        turnLeftWithSignal = false;
        turnRightWithSignal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            turnLeft();
            //Debug.Log(true);        // print true
            //Debug.Log(!true);       // print false
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            turnRight();
/*
            bool var1 = false;

            if(var1 == true)
            {
                Debug.Log("The variable is true");
            }
            if(var1)
            {
                Debug.Log("if(var1): The variable is true");
            }

            if(var1 != true)
            {
                Debug.Log("The variable is false");
            }
            if(!var1)
            {
                Debug.Log("if(!var1): The variable is false");
            }*/
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            goStraight();
        }

        // Left Turn Signal
        if(Input.GetKeyDown(KeyCode.Q))
        {
            leftTurnSignal();
        }

        // Right Turn Signal
        if(Input.GetKeyDown(KeyCode.E))
        {
           rightTurnSignal();
        }
    }

    public void turnLeft()
    {
        animator.SetBool("TurnLeft", true);
        animator.SetBool("TurnRight", false);

        // Playe is turning left while turn signal is on
        if(animator.GetBool("LeftTurnSignal") == true)
        {
            turnLeftWithSignal = true;
        }

        if(turnRightWithSignal == true)
        {
            rightTurnSignal();
        }
    }

    public void turnRight()
    {
        animator.SetBool("TurnRight", true);
        animator.SetBool("TurnLeft", false);

        // Player is turning right while turn signal is on
        if(animator.GetBool("RightTurnSignal") == true)
        {
            turnRightWithSignal = true;
        }

        if(turnLeftWithSignal)
        {
            leftTurnSignal();
        }
    }

    public void goStraight()
    {
        animator.SetBool("TurnRight", false);
        animator.SetBool("TurnLeft", false);

        if(turnLeftWithSignal == true)
        {
            leftTurnSignal();
        }

        if(turnRightWithSignal == true)
        {
            rightTurnSignal();
        }
    }

    public void leftTurnSignal()
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
                // Player is turning left while the turn signal is on
                if(animator.GetBool("TurnLeft") == true)
                {
                    turnLeftWithSignal = true;
                }
            }
        }
    }

    public void rightTurnSignal()
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
                // Player is turning right while the turn signal is on
                if(animator.GetBool("TurnRight") == true)
                {
                    turnRightWithSignal = true;
                }
            }
        }
    }







}
