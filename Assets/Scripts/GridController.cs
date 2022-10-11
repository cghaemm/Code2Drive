using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Array2DEditor
{
<<<<<<< Updated upstream
    public GameObject player; 
   
    void Start()
    {
=======
    public class GridController : MonoBehaviour
    {
        public GameObject player;
        public GameObject npc_car;


        [SerializeField]
        private Array2D test = null; 

>>>>>>> Stashed changes
        

<<<<<<< Updated upstream
   
    void Update()
    {
        
=======
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
>>>>>>> Stashed changes
    }
}
