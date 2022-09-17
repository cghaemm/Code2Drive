using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,
IDragHandler
{
    public Canvas canvas;
    public GameObject resultStack;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject clone;

    private bool inSlot = false;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        clone = gameObject;
    }

    public void slotted()
    {
        inSlot = true;
    }

    public void OnPointerDown(PointerEventData evenData) {
        Debug.Log("OnPointerDown");
    }
  
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if(!inSlot)
        {
            // Remove the block from the ResultBlock List
            Destroy(gameObject);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        if(!inSlot)
        {
            GameObject newClone = Instantiate(clone, transform.position, transform.rotation,canvas.transform);
        }
        else
        {
            resultStack.GetComponent<ResultBlock>().removeBlock(gameObject);
        }
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        inSlot = false;
    }
    
    // While the object is dragged
    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }


}

