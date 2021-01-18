using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler,IEndDragHandler, IDragHandler
{
    private Vector2 offset;
    Camera mainCam;

    void Awake()
    {
        mainCam = Camera.main;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - mainCam.ScreenToWorldPoint(eventData.position);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging!");
        transform.position = offset + (Vector2)mainCam.ScreenToWorldPoint(eventData.position);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End drag!");
    }

    
}
