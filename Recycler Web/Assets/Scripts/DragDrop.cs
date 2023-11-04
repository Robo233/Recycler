using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour,  IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        GetComponent<GarbageMovement>().enabled = false;
    }

    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.localPosition =  new Vector3(0,transform.localPosition.y,transform.localPosition.z);
        GetComponent<GarbageMovement>().enabled = true;
    }

}
