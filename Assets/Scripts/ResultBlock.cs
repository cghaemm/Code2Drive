using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResultBlock : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop  in Slot");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DragDrop>().slotted();
        }

    }
}
