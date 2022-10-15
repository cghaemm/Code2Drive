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

        // Start is called before the first frame update
        void Start()
        {
            int numRows = grid.GridSize.y;
            int numColumns = grid.GridSize.x;
            Debug.Log("Number of Rows: " + numRows);
            Debug.Log("Number of Columns: " + numColumns);

            float width = gameObject.transform.localScale.z;
            float length = gameObject.transform.localScale.x;
            Debug.Log("Width of Road: " + width);
            Debug.Log("Length of Road: " + length);

            int[,] newGrid = grid.GetCells();
            // newGrid[y, x]

            for(int y = 0; y < numRows; y++)
            {
                for(int x = 0; x < numColumns; x++)
                {
                    Debug.Log("[" + y + ", " + x + "]: " + newGrid[y, x]);
                    if(newGrid[y,x] == 2)
                    {
                        Vector3 position = new Vector3(gameObject.transform.position.x + ((width/numColumns)*x), 
                        gameObject.transform.position.y, gameObject.transform.position.z + ((length/numRows)*y));
                        
                        GameObject car = Instantiate(npc_car, position, transform.rotation); 

                    }

                }
            }

            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
