using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BackgroudMenuLogic : MonoBehaviour, IAssociableMenu
{

    public List<CharacterCardData> characterCards;
    [SerializeField]
    private GameObject buttonTemplate, contentList, cardTemplate, cardCanvas, cardRightClickMenu, MMCardTemplate, MMCardCanvas, intrigueTokenTemplate, intrigueTokenCanvas;
    


    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < 15; i++)
        {
            GenerateButton("testButton" + i);
        } */
        foreach (var c in characterCards)
        {
            //CreateCharacterCard(c);
            GenerateCharacterButton(c);
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

    private void GenerateCharacterButton(CharacterCardData cardData)
    {
        GameObject newButtonGO = Instantiate(buttonTemplate) as GameObject;
        Button newButton = newButtonGO.GetComponent<Button>();
        newButton.GetComponentInChildren<Text>().text = cardData.characterName;

        // newButton.onClick.AddListener(() => Debug.Log("Clicked " + cardData.characterName));
        newButton.onClick.AddListener(() =>
        {
            CreateCharacterCard(cardData);
            gameObject.SetActive(false);
        });

        newButtonGO.transform.SetParent(contentList.transform, false);
        newButtonGO.SetActive(true);
    }

    // TODO: pooling here too.  In practice, creation should be rare so it's probably ok with Instantiate()
    private void CreateCharacterCard(CharacterCardData cardData)
    {
        GameObject newCardGO = GameObject.Instantiate(cardTemplate, cardCanvas.transform);
        var newCard = newCardGO.GetComponent<CharacterCardLogic>();
        newCard.cardData = cardData;
        newCardGO.GetComponent<UIRightClickMenu>().MenuToLoad = cardRightClickMenu;
        newCardGO.SetActive(true);
    }

    public void CreateMMCard()
    {
        GameObject newCardGO = GameObject.Instantiate(MMCardTemplate, MMCardCanvas.transform);
        newCardGO.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CreateIntrigueToken()
    {
        GameObject newIntrigueToken = GameObject.Instantiate(intrigueTokenTemplate, intrigueTokenCanvas.transform);
        newIntrigueToken.SetActive(true);
        gameObject.SetActive(false);
    }

}
