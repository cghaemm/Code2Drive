using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public class ResultBlockCam : MonoBehaviour, IDropHandler
{
    //public float startOffset = 100f;
    public int numBlocks = 0;
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
            eventData.pointerDrag.GetComponent<DragDropCam>().slotted();
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
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<BlockData>().BlockRun();
            while(!blocks[i].GetComponent<BlockData>().getStatus())
            {
                await Task.Yield();
            }
            Debug.Log("Data: " + blocks[i].GetComponent<BlockData>().test);
            Debug.Log("Cur Index: " + i);
        }
    }
    
}
