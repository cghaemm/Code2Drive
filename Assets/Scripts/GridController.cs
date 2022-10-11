using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Array2DEditor
{
    public class GridController : MonoBehaviour
    {
        public GameObject player;
        public GameObject npc_car;

        [SerializeField]
        private Array2D<int> test = null;

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
}
