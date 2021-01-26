using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector2 offset;
    Camera mainCam;

    void Awake()
    {
        mainCam = Camera.main;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        offset = transform.position - mainCam.ScreenToWorldPoint(eventData.position);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        transform.position = offset + (Vector2)mainCam.ScreenToWorldPoint(eventData.position);
    }   
}
