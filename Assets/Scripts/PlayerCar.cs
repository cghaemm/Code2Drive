using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
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

        if(animator.GetBool("RightTurnsSignal") == true)
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
        if(!animator.GetBool("RightTurnSignal"))
        {
           
            if(animator.GetBool("LeftTurnSignal"))
            {
                animator.SetBool("LeftTurnSignal", false);
            }
                
            else
            {
                animator.SetBool("LeftTurnSignal", true);

                if(animator.GetBool("TurnLeft") == true)
                {
                    turnLeftWithSignal = true; 
                }
            }
        }
    }

    public void rightTurnSignal()
    {
        
        if(!animator.GetBool("LeftTurnSignal"))
        {
               
            if(animator.GetBool("RightTurnSignal"))
            {
                animator.SetBool("RightTurnSignal", false);
            }
               
            else
            {
                animator.SetBool("RightTurnSignal", true);
            }
        }
    }







}
