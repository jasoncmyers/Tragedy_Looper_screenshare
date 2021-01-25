using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemController : MonoBehaviour
{

    public Button sampleButton;
    private List<ContextMenuItem> contextMenuItems;

    private void Awake()
    {
        contextMenuItems = new List<ContextMenuItem>();
        Action<Image> equip = new Action<Image>(EquipAction);
        Action<Image> use = new Action<Image>(UseAction);
        Action<Image> drop = new Action<Image>(DropAction);

        contextMenuItems.Add(new ContextMenuItem("Equip", sampleButton, equip));
        contextMenuItems.Add(new ContextMenuItem("Use", sampleButton, use));
        contextMenuItems.Add(new ContextMenuItem("Drop", sampleButton, drop));
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Activating menu!");

            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            ContextMenu.Instance.CreateContextMenu(contextMenuItems, new Vector2(pos.x, pos.y));
        }
    }

    void EquipAction(Image contextPanel)
    {
        Debug.Log("Equipped");
        Destroy(contextPanel.gameObject);
    }

    void UseAction(Image contextPanel)
    {
        Debug.Log("Used");
        Destroy(contextPanel.gameObject);
    }

    void DropAction(Image contextPanel)
    {
        Debug.Log("Dropped");
        Destroy(contextPanel.gameObject);
    }
}
