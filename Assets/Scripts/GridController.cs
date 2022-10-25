using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Array2DEditor
{
    public class GridController : MonoBehaviour
    {

        // 0 is an empty space
        // 1 is player car
        // 2 is npc_car
        // 3 is goal
        // 4 is sports_car;

        public GameObject player;
        public GameObject npc_car;
        public GameObject goal;
        public GameObject sports_car;

        [SerializeField]
        private Array2DInt grid = null;

        public float yBuffer = 0.23f;
        public float yBufferGoal = 10f;

        private int numRows;
        private int numColumns;

        // Start is called before the first frame update
        void Start()
        {
            numRows = grid.GridSize.y;
            numColumns = grid.GridSize.x;
            Debug.Log("Number of Rows: " + numRows);
            Debug.Log("Number of Columns: " + numColumns);

            float width = gameObject.transform.localScale.z;
            float length = gameObject.transform.localScale.x;
            Debug.Log("Width of Road: " + width);
            Debug.Log("Length of Road: " + length);

            int[,] newGrid = grid.GetCells();
            // newGrid[y, x]
            Debug.Log(newGrid);

            for(int rowNum = 0; rowNum < numRows; rowNum++)
            {
                for(int colNum = 0; colNum < numColumns; colNum++)
                {
                    Debug.Log("[" + rowNum + ", " + colNum + "]: " + newGrid[rowNum, colNum]);
                    
                    Vector3 position = new Vector3(gameObject.transform.position.x - (width/2) + (width/(2*numRows)) + ((width/numRows)*rowNum), 
                    gameObject.transform.position.y + yBuffer, gameObject.transform.position.z - (length/2) + (length/(2*numColumns)) + ((length/numColumns)*colNum));
                    if(newGrid[rowNum, colNum] == 1)
                    {
                        GameObject new_player_car = Instantiate(player, position, transform.rotation);
                        new_player_car.GetComponent<PlayerCar>().assignRoad(gameObject);
                    }
                    else if(newGrid[rowNum,colNum] == 2)
                    {
                        //Vector3 position = new Vector3(gameObject.transform.position.x - (width/2) + (width/(2*numRows)) + ((width/numRows)*rowNum), 
                        //gameObject.transform.position.y + yBuffer, gameObject.transform.position.z - (length/2) + (length/(2*numColumns)) + ((length/numColumns)*colNum));
                        GameObject new_npc_car = Instantiate(npc_car, position, transform.rotation); 
                    }
                    else if(newGrid[rowNum, colNum] == 3)
                    {
                        Quaternion goal_rotation = Quaternion.Euler(0, 180, 0);
                        Vector3 goal_position = position + new Vector3(0, yBufferGoal, 0);
                        GameObject new_goal = Instantiate(goal, goal_position, goal_rotation);
                    }
                    else if(newGrid[rowNum, colNum] == 4)
                    {
                        GameObject new_sports_car = Instantiate(sports_car, position, transform.rotation);
                    }

                }
            }

            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public int getNumRows()
        {
            return numRows;
        }

        public int getNumColumns()
        {
            return numColumns;
        }
    }
}
