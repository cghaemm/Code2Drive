using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForwardBlock : MonoBehaviour, IBlockInterface
{

    private bool finished;
    private CanvasGroup canvasGroup;
    private bool activate;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        finished = false;
        canvasGroup = GetComponent<CanvasGroup>();
        activate = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*
List Explanation:

// This is an array
String[] animals = {"pig", "cat", "dog"};
Debug.Log(animals.length); // Get the length of an array in Java

// This is a list
ArrayList<String> animals = new ArrayList<String>();
animals.add("pig");
animals.add("cat");
animals.add("dog");

Debug.Log(animals[0]);

for(int i = 0; i < animals.size(); i++)
{
    System.out.println(animals[i]);
}

*/

    public void BlockRun()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        activate = true;
    }

    public bool getStatus()
    {
        return finished;
    }

    public void blockRaycast()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void resetBlock()
    {
        finished = false;
        canvasGroup.blocksRaycasts = true;
        activate = false;
    }
}
