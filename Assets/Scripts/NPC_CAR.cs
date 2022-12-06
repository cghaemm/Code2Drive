using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Array2DEditor 
{
    public class NPC_CAR : MonoBehaviour
    {
        private GameObject road;

        private float forwardDistance;
        private float speed = 0.05f;
        private Rigidbody rb;
        private Vector3 destination;

        [SerializeField]
        private AnimationCurve _curve;
        private float _target;
        private float current;

        private bool moving;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();

            destination = new Vector3(transform.position.x, transform.position.y, 
            transform.position.z);

            moving = false;
        }

        // Update is called once per frame
        void Update()
        {
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
            current = Mathf.MoveTowards(current, _target, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, destination, _curve.Evaluate(current));
            //Debug.Log(destination);
            
        }

        public void moveForward()
        {
            moving = true;
            destination = new Vector3(transform.position.x-forwardDistance,
            transform.position.y,
            transform.position.z);
        }

        public void moveBackward()
        {
            moving = true;
            destination = new Vector3(transform.position.x+forwardDistance,
            transform.position.y,
            transform.position.z);
        }

        public void assignRoad(GameObject road)
        {
            this.road = road;
            int numRows = road.GetComponent<GridController>().getNumRows();
            float width = road.gameObject.transform.localScale.z;
            forwardDistance = width/numRows;
        }

        private bool isMoving()
        {
            return moving;
        }

        private void finishedMoving()
        {
            moving = false;
        }
    }
}
