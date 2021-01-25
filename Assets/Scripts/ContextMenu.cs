using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// from https://gamedev.stackexchange.com/questions/108508/how-to-design-context-menus-based-on-whatever-the-object-is


public class ContextMenuItem
{
    public string text;
    public Button button;
    public Action<Image> action;

    public ContextMenuItem(string text, Button button, Action<Image> action)
    {
        this.text = text;
        this.button = button;
        this.action = action;
    }
}

public class ContextMenu : MonoBehaviour
{

    public Image contentPanel;
    public Canvas canvas;

    private static ContextMenu instance;
    public static ContextMenu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(ContextMenu)) as ContextMenu;
                if (instance == null)
                {
                    instance = new ContextMenu();
                }
            }
            return instance;
        }
    }

    public void CreateContextMenu(List<ContextMenuItem> items, Vector2 position)
    {
        Image panel = Instantiate(contentPanel, new Vector3(position.x, position.y, 0), Quaternion.identity) as Image;
        panel.transform.SetParent(canvas.transform);
        panel.transform.SetAsLastSibling();
        panel.rectTransform.anchoredPosition = position;

        foreach (var item in items)
        {
            ContextMenuItem tempItem = item;
            Button button = Instantiate(item.button) as Button;
            Text buttonText = button.GetComponentInChildren(typeof(Text)) as Text;
            buttonText.text = item.text;
            button.onClick.AddListener(delegate { tempItem.action(panel); });
            button.transform.SetParent(panel.transform);
        }
    }
}
