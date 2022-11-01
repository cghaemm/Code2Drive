using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Array2DEditor {
    public class PlayerCar : MonoBehaviour
    {
        private Animator animator;
        private bool turnLeftWithSignal;
        private bool turnRightWithSignal;

        private GameObject road;

        private float forwardDistance;
        private float sideToSideDistance;

        private float speed = 0.05f;
        private Rigidbody rb;
        private Vector3 destination;

        [SerializeField]
        private AnimationCurve _curve;
        private float _target;
        private float current;

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

            rb = gameObject.GetComponent<Rigidbody>();

            destination = new Vector3(transform.position.x,transform.position.y,transform.position.z);
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
            
            if(transform.position == destination)
            {
                _target = 0;
                //Debug.Log("Target Changed to 0");
            }
            else
            {
                _target = 1;
            }

            //Debug.Log(_target);
            current = Mathf.MoveTowards(current, _target, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, destination, _curve.Evaluate(current));
            //Debug.Log(destination);

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

            Debug.Log("Move Forward");
            destination = new Vector3(transform.position.x-forwardDistance, transform.position.y, transform.position.z);
            //Debug.Log(50);
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

        public void assignRoad(GameObject road)
        {
            this.road = road;
            int numColumns = road.GetComponent<GridController>().getNumColumns();
            int numRows = road.GetComponent<GridController>().getNumRows();

            float width = road.gameObject.transform.localScale.z;
            float length = road.gameObject.transform.localScale.x;

            forwardDistance = width/numRows;
            sideToSideDistance = length/numColumns;
        }







    }
}
