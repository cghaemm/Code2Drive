using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResultBlockHW : MonoBehaviour, IDropHandler
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
        //                                        0      1      2       3        4
        List<string> animals = new List<string>{"dog", "cat", "cow", "horse","chicken"};

        int i = 0;
        while (i < 5)
        {
            Debug.Log("Value of i: " + i);
            i += 1;
        }







        /*
        for(int i=0 ; i < animals.Count-1 ; i += 1) 
        {
            Debug.Log(animals[i]);
        }*/



    }
    
}
