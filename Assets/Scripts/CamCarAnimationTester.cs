using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCarAnimationTester : MonoBehaviour
{
    Animator animator;
    private bool turnLeftWithSignal;
    private bool turnRightWithSignal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        animator.SetBool("TurnRight", false);
        animator.SetBool("TurnLeft", false);

        turnLeftWithSignal = false;
        turnRightWithSignal = false;
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

        if(Input.GetKeyDown(KeyCode.Q))
        {
            leftTurnSignal();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            rightTurnSignal();
        }
    }

    public void goStraight()
    {
        animator.SetBool("TurnRight", false);
        animator.SetBool("TurnLeft", false);

        if(turnLeftWithSignal)
        {
            leftTurnSignal();
        }

        if(turnRightWithSignal)
        {
            rightTurnSignal();
        }
    }

    public void turnLeft()
    {
        if(animator.GetBool("TurnLeft"))
        {
            goStraight();
        }
        else
        {
            animator.SetBool("TurnLeft", true);
            animator.SetBool("TurnRight", false);
            // Player is turning left while turn signal is on
            if(animator.GetBool("LeftTurnSignal"))
            {
                turnLeftWithSignal = true;
            }

            if(turnRightWithSignal)
            {
                rightTurnSignal();
            }
        }
    }

    public void turnRight()
    {
        if(animator.GetBool("TurnRight"))
        {
            goStraight();
        }
        else
        {
            animator.SetBool("TurnRight", true);
            animator.SetBool("TurnLeft", false);
            // Player is turning right while turn signal is on
            if(animator.GetBool("RightTurnSignal"))
            {
                turnRightWithSignal = true;
            }

            if(turnLeftWithSignal)
            {
                leftTurnSignal();
            }
        }
    }

    public void leftTurnSignal()
    {
        // If the right turn signal is not on change left turn signal
        if(!animator.GetBool("RightTurnSignal"))
        {
            // Turn off turn signal if already on 
            if(animator.GetBool("LeftTurnSignal"))
            {
                animator.SetBool("LeftTurnSignal", false);
                turnLeftWithSignal = false;
            }
            // Turn on turn signal
            else
            {
                animator.SetBool("LeftTurnSignal", true);
                // Player is turning left while the turn signal is on
                if(animator.GetBool("TurnLeft"))
                {
                    turnLeftWithSignal = true;
                }
            }
        }
        
    }

    public void rightTurnSignal()
    {
        // If the left turn signal is not on change the right turn signal
        if(!animator.GetBool("LeftTurnSignal"))
        {
            // Turn off turn signal if already on
            if(animator.GetBool("RightTurnSignal"))
            {
                animator.SetBool("RightTurnSignal", false);
                turnRightWithSignal = false;
            }
            // Turn on turn signal
            else
            {
                animator.SetBool("RightTurnSignal", true);
                // Player is turning right while the turn signal is on
                if(animator.GetBool("TurnRight"))
                {
                    turnRightWithSignal = true;
                }
            }
        }
        
    }
}
