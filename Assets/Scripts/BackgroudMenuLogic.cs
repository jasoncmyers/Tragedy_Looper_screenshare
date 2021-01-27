using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BackgroudMenuLogic : MonoBehaviour, IAssociableMenu
{

    public List<CharacterCardData> characterCards;
    [SerializeField]
    private GameObject buttonTemplate, contentList;
    


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            GenerateButton("testButton" + i);
        }
    }

    // only one background menu, so no need to actually associate anything
    public void AssociateWithGameobject(GameObject go)
    {
        return;
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateButton(string text)
    {
        GameObject newButtonGO = Instantiate(buttonTemplate) as GameObject;
        Button newButton = newButtonGO.GetComponent<Button>();
        newButton.GetComponentInChildren<Text>().text = text;

        newButtonGO.transform.SetParent(contentList.transform, false);
        newButtonGO.SetActive(true);
    }

}
