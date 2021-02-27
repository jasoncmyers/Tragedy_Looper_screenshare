using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickRemoval : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right
            && Input.touchCount < 2) return;
        GameObject.Destroy(gameObject);
    }
}
