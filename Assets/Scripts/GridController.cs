using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject player;
    public GameObject npc_car;

    public int[,] grid = new int[6, 4];

    private int numColumns;
    private int numRows;

    // Start is called before the first frame update
    void Start()
    {
        // numColumns = grid[0].GetLength();
        // numRows = grid.GetLength();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
