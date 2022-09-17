using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ResultBlockCam : MonoBehaviour, IDropHandler
{
    //public float startOffset = 100f;
    public int numBlocks = 0;
    public Button runButton; 

    private RectTransform rectTransform;
    private List<GameObject> blocks = new List<GameObject>();


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop in Slot");
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<DragDropCam>().checkSlotted())
            {
                Debug.Log("BLOCK DROPPED BACK IN SLOT");
                eventData.pointerDrag.GetComponent<DragDropCam>().slotted();
                int num = getIndexOfBlock(eventData.pointerDrag.gameObject);

                Debug.Log("Y Position of Opening: " + ((rectTransform.anchoredPosition 
                + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2) 
                - new Vector2(0,eventData.pointerDrag.GetComponent<RectTransform>().rect.height*num)).y
                - eventData.pointerDrag.GetComponent<RectTransform>().rect.height*0.45));
                Debug.Log("Y Position of Block: " + (eventData.pointerDrag.GetComponent<RectTransform>().position.y/2));

                // Check if the block is at or above the original position
                if((rectTransform.anchoredPosition 
                + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2) 
                - new Vector2(0,eventData.pointerDrag.GetComponent<RectTransform>().rect.height*num)).y
                - eventData.pointerDrag.GetComponent<RectTransform>().rect.height*0.45 < 
                eventData.pointerDrag.GetComponent<RectTransform>().position.y/2)
                {
                    Debug.Log("ABOVE OPEN SLOT");
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
                    rectTransform.anchoredPosition 
                    + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2) 
                    - new Vector2(0,eventData.pointerDrag.GetComponent<RectTransform>().rect.height*num);
                }
                else
                {
                    Debug.Log("BELOW OPEN SLOT");
                    blocks.Remove(eventData.pointerDrag.gameObject);
                    for (int i = num; i < blocks.Count; i++)
                    {
                        blocks[i].GetComponent<RectTransform>().anchoredPosition = 
                        rectTransform.anchoredPosition 
                        + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2) 
                        - new Vector2(0,blocks[i].GetComponent<RectTransform>().rect.height*i);
                    }
                    blocks.Add(eventData.pointerDrag.gameObject);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
                    rectTransform.anchoredPosition 
                    + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2) 
                    - new Vector2(0,eventData.pointerDrag.GetComponent<RectTransform>().rect.height*(blocks.Count-1));
                }
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragDropCam>().slotted();
                // HERE Possibly add a check that checks if the block was previously slotted
                blocks.Add(eventData.pointerDrag.gameObject);
                //Debug.Log(blocks);
                //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
                //Debug.Log(GetComponent<RectTransform>().anchoredPosition.GetType());
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
                rectTransform.anchoredPosition 
                + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2) 
                - new Vector2(0,eventData.pointerDrag.GetComponent<RectTransform>().rect.height*numBlocks);
                
                numBlocks += 1;
            }
        }
    }

    public void removeBlock(GameObject block)
    {
        int num = getIndexOfBlock(block);
        blocks.Remove(block);
        numBlocks = numBlocks - 1;
        // update the position of every other block
        for (int i = num; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<RectTransform>().anchoredPosition = 
            rectTransform.anchoredPosition 
            + new Vector2(0, (rectTransform.rect.height*rectTransform.localScale.y)/2) 
            - new Vector2(0,blocks[i].GetComponent<RectTransform>().rect.height*i);
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

    public async void Run()
    {
        runButton.interactable = false;
        for(int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<BlockInterface>().blockRaycast();
        }

        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<BlockInterface>().BlockRun();
            while(!blocks[i].GetComponent<BlockInterface>().getStatus())
            {
                await Task.Yield();
            }
            Debug.Log("Data: " + blocks[i].GetComponent<BlockData>().test);
            Debug.Log("Cur Index: " + i);
        }

        for(int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<BlockInterface>().resetBlock();
        }
        runButton.interactable = true;
    }
    
}
