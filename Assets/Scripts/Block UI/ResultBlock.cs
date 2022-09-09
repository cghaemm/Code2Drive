using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResultBlock : MonoBehaviour, IDropHandler
{
    private int numBlocks = 0;
    private RectTransform rectTransform;
    private List<GameObject> blocks = new List<GameObject>();

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

    public void Run()
    {
        List<string> test = new List<string>{"dog", "cat", "cow"};
        for(int i = 0; i < test.Count; i++) // i = i - 1
        {
            Debug.Log("i is equal to " + i);
            Debug.Log(test[i]);
        }
    }
    
}
