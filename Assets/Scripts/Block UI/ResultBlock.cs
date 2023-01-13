using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Array2DEditor {

    public class ResultBlock : MonoBehaviour, IDropHandler
    {
        public Button runButton;

        private int numBlocks = 0;
        private RectTransform rectTransform;
        private List<GameObject> blocks = new List<GameObject>();

        private GameObject player;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop in Slot");
            if(eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<DragDrop>().slotted();
                blocks.Add(eventData.pointerDrag.gameObject);

                eventData.pointerDrag.gameObject.GetComponent<RectTransform>().anchoredPosition = 
                rectTransform.anchoredPosition 
                + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2)
                - new Vector2(0,eventData.pointerDrag.GetComponent<RectTransform>().rect.height*numBlocks);
                
                numBlocks += 1;
            }
        }

        private int getIndexOfBlock(GameObject block)
        {
            for(int i = 0; i < blocks.Count; i++)
            {
                if(blocks[i] == block)
                {
                    return i;
                }
            }
            return -1;
        }

        public void removeBlock(GameObject block)
        {
            int num = getIndexOfBlock(block);
            blocks.Remove(block);
            numBlocks = numBlocks - 1;
            
            // Loop through the remaining blocks and update the position of every other block
            for(int i = num; i < blocks.Count; i++)
            {
                blocks[i].GetComponent<RectTransform>().anchoredPosition = 
                rectTransform.anchoredPosition                                                // Position of Result Block
                + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2)    // Height of our block divided 2
                - new Vector2(0, blocks[i].GetComponent<RectTransform>().rect.height*i);      // The heights of the blocks above our current block
            }

        }

        public async void Run()
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            runButton.interactable = false;
            // Loop through every block and make them non-interactable
            for(int i = 0; i < blocks.Count; i++)
            {
                blocks[i].GetComponent<IBlockInterface>().blockRaycast();
            }

            // Runs every block in our ResultBlock
            for(int i = 0; i < blocks.Count; i++)
            {
                if (!player.GetComponent<PlayerCar>().getCrashed() && 
                    !player.GetComponent<PlayerCar>().getFinished()) 
                {
                    try
                    {
                        blocks[i].GetComponent<IBlockInterface>().BlockRun();
                        while(!blocks[i].GetComponent<IBlockInterface>().getStatus())
                        {
                            await Task.Yield();
                        }
                        Debug.Log("GameObject: " + blocks[i]);
                    }
                    catch (MissingReferenceException e)
                    {
                        Debug.Log(e);
                        Debug.Log("ERROR OCCURED IN RESULT BLOCK Run()");
                    }
                }
            }

            // All player actions have been performed
            if (!player.GetComponent<PlayerCar>().getCrashed() && 
                    !player.GetComponent<PlayerCar>().getFinished()) {
                // Player ran out of gas
                player.GetComponent<PlayerCar>().noFinish();
            }

            // Loops through every block in our ResultBlock and resets them
            // Null Reference Exception sometimes occurs here
            for(int i = 0; i < blocks.Count; i++)
            {
                blocks[i].GetComponent<IBlockInterface>().resetBlock();
            }
            //runButton.interactable = true;
        }
        
    }
}
