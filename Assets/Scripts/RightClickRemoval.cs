using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickRemoval : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        GameObject.Destroy(gameObject);
    }
}
