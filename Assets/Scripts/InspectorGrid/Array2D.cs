using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Array2DEditor
{
    [System.Serializable]
    public class Array2D
    {
       public Vector2Int Gridsize => gridSize;

       [SerializeField]
       private Vector2Int gridSize = Vector2Int.one * Consts.numRows; 

       [SerializeField]
       CellRow[] cells = new CellRow[Consts.numRows];

       #pragma warning disable 414
       [SerializeField]
       private Vector2Int cellSize;
       #pragma warning restore 414

       public int[,] GetCells()
       {
            var ret = new int[gridSize.y, gridSize.x];

            for (int y = 0; y < gridSize.y; y++)
            {
                for(int x = 0; x < gridSize.x; x++)
                {
                    ret[y,x] = GetCells(x,y);
                }
            }
            return ret; 
       }

       public int GetCells(int x, int y)
       {
        return GetCellRow(y)[x];
       }

       public void SetCell(int x, int y, int value)
       {
        GetCellRow(y)[x] = value;
       }

       protected CellRow GetCellRow(int idx)
       {
            return cells[idx];
       }

    }
}
