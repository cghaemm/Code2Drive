using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBoundary : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tree")
        {
            Debug.Log("Found Tree!");
        }
    }
}
