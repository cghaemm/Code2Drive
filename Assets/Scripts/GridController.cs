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

        private GameObject[,] carGrid;
        private int[] playerCarPosition = new int[2];

        [SerializeField]
        private GameObject modal_window;

        // Start is called before the first frame update

        void Start()
        {
            numRows = grid.GridSize.y;
            numColumns = grid.GridSize.x;

            carGrid = new GameObject[numRows, numColumns];
            testGrid<GameObject>(carGrid);

            int[,] x = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            testGrid<int>(x);

            string[,] y = {{"Hello", "World", "!"}, {"Coding", "Minds", "Academy"},
            {"How", "are", "you?"}};
            testGrid<string>(y);

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
                        carGrid[rowNum,colNum] = new_player_car;
                        playerCarPosition[0] = rowNum;
                        playerCarPosition[1] = colNum;
                        Debug.Log("Player Car Position: " + playerCarPosition[0] + ", " + playerCarPosition[1]);

                    }
                    else if(newGrid[rowNum,colNum] == 2)
                    {
                        //Vector3 position = new Vector3(gameObject.transform.position.x - (width/2) + (width/(2*numRows)) + ((width/numRows)*rowNum), 
                        //gameObject.transform.position.y + yBuffer, gameObject.transform.position.z - (length/2) + (length/(2*numColumns)) + ((length/numColumns)*colNum));
                        GameObject new_npc_car = Instantiate(npc_car, position, transform.rotation);
                        new_npc_car.GetComponent<NPC_CAR>().assignRoad(gameObject);
                        carGrid[rowNum, colNum] = new_npc_car;
                    }
                    else if(newGrid[rowNum, colNum] == 3)
                    {
                        Quaternion goal_rotation = Quaternion.Euler(0, 180, 0);
                        Vector3 goal_position = position + new Vector3(0, yBufferGoal, 0);
                        GameObject new_goal = Instantiate(goal, goal_position, goal_rotation);
                        carGrid[rowNum, colNum] = new_goal;
                    }
                    else if(newGrid[rowNum, colNum] == 4)
                    {
                        GameObject new_sports_car = Instantiate(sports_car, position, transform.rotation);
                        carGrid[rowNum, colNum] = new_sports_car;
                    }

                }
            }
            testGrid<GameObject>(carGrid);

            modal_window = Instantiate(modal_window);
            modal_window.SetActive(false);
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

        // Y and X positions of grid are inverted
        public void playerCarForward()
        {
            int curYPosition = playerCarPosition[0];
            if((curYPosition - 1) >= 0)
            {
                GameObject playerCar = carGrid[curYPosition, playerCarPosition[1]];
                carGrid[curYPosition-1, playerCarPosition[1]] = playerCar;
                carGrid[curYPosition, playerCarPosition[1]] = null;
                playerCarPosition[0] = curYPosition-1;
            }
            else
            {
                Debug.Log("CAR MOVED TOO FAR FORWARD");
                // Add modal window here later
                modal_window.SetActive(true);
            }

            Debug.Log("Player Car Position: " + playerCarPosition[0] + ", " + playerCarPosition[1]);

        }

        public void playerCarBackward()
        {
            int curYPosition = playerCarPosition[0];
            if((curYPosition + 1) < carGrid.GetLength(0))
            {
                GameObject playerCar = carGrid[curYPosition, playerCarPosition[1]];
                carGrid[curYPosition+1, playerCarPosition[1]] = playerCar;
                carGrid[curYPosition, playerCarPosition[1]] = null;
                playerCarPosition[0] = curYPosition + 1;
            }
            else
            {
                Debug.Log("CAR WENT TOO FAR BACKWARD");
                // Add modal window here later
                modal_window.SetActive(true);
            }

            Debug.Log("Player Car Position: " + playerCarPosition[0] + ", " + playerCarPosition[1]);
        }

        public void playerCarLeft()
        {
            int curXPosition = playerCarPosition[1];
            if((curXPosition - 1) >= 0)
            {
                GameObject playerCar = carGrid[playerCarPosition[0], curXPosition];
                carGrid[playerCarPosition[0], curXPosition-1] = playerCar;
                carGrid[playerCarPosition[0], curXPosition] = null;
                playerCarPosition[1] = curXPosition-1;
            }
            else
            {
                Debug.Log("CAR MOVED TOO FAR TO THE LEFT");
                modal_window.SetActive(true);
            }
        }

        public void playerCarRight()
        {
            int curXPosition = playerCarPosition[1];
            if((curXPosition + 1) < carGrid.GetLength(1))
            {
                GameObject playerCar = carGrid[playerCarPosition[0], curXPosition];
                carGrid[playerCarPosition[0], curXPosition+1] = playerCar;
                carGrid[playerCarPosition[0], curXPosition] = null;
                playerCarPosition[1] = curXPosition + 1;
            }
            else
            {
                Debug.Log("CAR MOVED TOO FAR TO THE RIGHT");
                modal_window.SetActive(true);
            }

        }

        // Assume testGrid only tests carGrid/grid of GameObjects
        public void testGrid<T>(T[,] testGrid)
        {
            //Debug.Log(testGrid.GetLength());
            for(int i = 0; i < testGrid.GetLength(0); i++)
            {
                string str = "[";
                for(int j = 0; j < testGrid.GetLength(1); j++)
                {
                    // [0,0] [0, 1], [0,2]
                    str += testGrid[i,j] + ", ";
                }
                str += "]";
                Debug.Log(str);
            }
        }

        // function assumes that player did not have their turn signal on
        // positions are [y, x]
        //              0      1      2
        // animals = ["dog", "cow", "pig"]   // length of list is 3
        // System.out.println(animals[0]); // dog
        //              0      1      2      3       4
        // animals = ["dog", "cow", "pig", "cat", "horse"] // length of list is 5
        // animals.length

        // public String getAnimal(int index)
        // {    
        //      if(index <= animals.length-1 && index >= 0)
        //      {
        //          return animals[index];
        //      }
        // }
        public void checkBehindPC()
        {
            if((carGrid.GetLength(0)-1) >= (playerCarPosition[0]+1) &&
                carGrid[playerCarPosition[0]+1, playerCarPosition[1]] != null &&
                carGrid[playerCarPosition[0]+1, playerCarPosition[1]].gameObject.tag == "car")
            {
                // There is a car behind the player
                carGrid[playerCarPosition[0]+1, playerCarPosition[1]].
                gameObject.GetComponent<NPC_CAR>().moveForward();
            }
        }

        public void checkLeftPC()
        {
            // Checks if car is to left of player
            if((playerCarPosition[1]-1) >= 0 &&
            carGrid[playerCarPosition[0], playerCarPosition[1]-1] != null
            && carGrid[playerCarPosition[0], playerCarPosition[1]-1].gameObject.tag == "car")
            {
                // CAR to left of player; now check to make sure no car is behind that car
                if((carGrid.GetLength(0)-1) >= (playerCarPosition[0]+1) &&
                    carGrid[playerCarPosition[0]+1, playerCarPosition[1]-1] == null)
                {
                    
                    GameObject npcCar = carGrid[playerCarPosition[0], playerCarPosition[1]-1];    
                    carGrid[playerCarPosition[0]+1, playerCarPosition[1]-1] = npcCar;
                    carGrid[playerCarPosition[0], playerCarPosition[1]-1] = null;
                    npcCar.GetComponent<NPC_CAR>().moveBackward();
                }
            }
        }

        public void checkRightPC()
        {
            if((carGrid.GetLength(1)-1) >= (playerCarPosition[1]+1) &&
            carGrid[playerCarPosition[0], playerCarPosition[1]+1] != null &&
            carGrid[playerCarPosition[0], playerCarPosition[1]+1].gameObject.tag == "car")
            {
                if((carGrid.GetLength(0)-1) >= (playerCarPosition[0]+1) &&
                    carGrid[playerCarPosition[0]+1, playerCarPosition[1]+1] == null)
                {
                    GameObject npcCar = carGrid[playerCarPosition[0], playerCarPosition[1]+1];    
                    carGrid[playerCarPosition[0]+1, playerCarPosition[1]+1] = npcCar;
                    carGrid[playerCarPosition[0], playerCarPosition[1]+1] = null;
                    npcCar.GetComponent<NPC_CAR>().moveBackward();
                }
            }
        }

        public void crashOccured()
        {
            modal_window.SetActive(true);
        }
    }
}
