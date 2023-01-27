using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBoundary : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tree")
        {
            //Debug.Log("Found Tree!");
            other.gameObject.GetComponent<TreeMovement>().moveToStart();
        }

        if(other.gameObject.tag == "Road Line")
        {
            other.gameObject.GetComponent<RoadLine>().moveToStart();
        }

        if(other.gameObject.tag == "Grass") {
            Debug.Log("GRASS ENCOUNTERED");
            other.gameObject.GetComponent<GroundTile>().moveToStart();
        }
    }
}
