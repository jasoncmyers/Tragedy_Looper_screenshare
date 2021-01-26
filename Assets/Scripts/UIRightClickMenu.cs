using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIRightClickMenu : MonoBehaviour, IPointerClickHandler
{

    public GameObject MenuToLoad;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        
        var menuLogic = MenuToLoad.GetComponent<IAssociableMenu>();
        if (menuLogic == null) return;

        menuLogic.AssociateWithGameobject(this.gameObject);
        MenuToLoad.transform.position = eventData.position;
        MenuToLoad.SetActive(true);
    }
}

public interface IAssociableMenu
{
    void AssociateWithGameobject(GameObject go);
}
