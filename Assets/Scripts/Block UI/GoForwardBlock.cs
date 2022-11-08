using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Array2DEditor {
    public class GoForwardBlock : MonoBehaviour, IBlockInterface
    {

        private bool finished;
        private CanvasGroup canvasGroup;
        private GameObject player;

        // Start is called before the first frame update
        void Awake()
        {
            finished = false;
            canvasGroup = GetComponent<CanvasGroup>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        // Activate player.goStraight()
        // Add function to ForwardBlock script that updates finished status
        //    - Use that function in PlayerCar Script when finished moving
        //    
        public async void BlockRun()
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.GetComponent<PlayerCar>().goStraight();
            while(player.GetComponent<PlayerCar>().isMoving())
            {
                await Task.Yield();
            }
            finished = true;
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
        }
    }
}
