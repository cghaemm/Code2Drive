using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Array2DEditor
{   
    [System.Serializable]
    public class CellRow 
    {
        [SerializeField]
        private int[] row = new int [Consts.numColumns];

        public int this[int i]
        {
            get => row[i];
            set => row[i] = value; 
        }
    }
}
