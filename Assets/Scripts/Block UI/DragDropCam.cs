using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropCam : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,
IDragHandler
{
    public Canvas canvas;
    public GameObject resultStack;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject clone;

    private bool inSlot = false;
    private bool wasSlotted = false;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        clone = gameObject;
    }

    public void slotted()
    {
        inSlot = true;
        wasSlotted = true;
    }

    public void OnPointerDown(PointerEventData evenData) {
        Debug.Log("OnPointerDown");
    }
  
    public void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        // If the block is dropped outside of the resultStack
        if(!inSlot)
        {
            if(wasSlotted)
            {
                // Remove this block from the resultStack
                resultStack.GetComponent<ResultBlockCam>().removeBlock(gameObject);
            }
            Destroy(gameObject);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        // Only create a clone if not in the slot
        if(!inSlot)
        {
            GameObject newClone = Instantiate(clone, transform.position, transform.rotation,canvas.transform);
            newClone.GetComponent<BlockData>().test += 1;
        }
        //else
        //{
        //    resultStack.GetComponent<ResultBlockCam>().removeBlock(gameObject);
        //}
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        inSlot = false;
    }
    
    // While the object is dragged
    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public bool checkSlotted()
    {
        return wasSlotted;
    }


}

