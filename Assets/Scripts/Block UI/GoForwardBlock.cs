using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Array2DEditor {
    public class GoForwardBlock : IBlockInterface
    {
        public override async void BlockRun()
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.GetComponent<PlayerCar>().goStraight();
            
            try{
                while(player.GetComponent<PlayerCar>().isMoving())
                {
                    await Task.Yield();
                }
                finished = true;
            }
            catch (MissingReferenceException e)
            {
                Debug.Log(e);
                Debug.Log("ERROR OCCURED IN BlockRun()");
            }
        }
    }
}
