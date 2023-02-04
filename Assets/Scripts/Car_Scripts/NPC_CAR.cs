using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Array2DEditor 
{
    public class NPC_CAR : ICar
    {
        private GameObject road;

        private float forwardDistance;

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
    }
}
