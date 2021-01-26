using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenuLogic : MonoBehaviour, IAssociableMenu
{

    private CharacterCardLogic associatedCard = null;

    public void AssociateWithGameobject(GameObject go)
    {
        AssociateWithCard(go.GetComponent<CharacterCardLogic>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssociateWithCard(CharacterCardLogic newCard)
    {
        associatedCard = newCard;
    }

    private void OnDisable()
    {
        associatedCard = null;
    }

    public void IncParanoia()
    {
        associatedCard?.ChangeParanoia(1);
        gameObject.SetActive(false);
    }
    public void IncGoodwill()
    {
        associatedCard?.ChangeGoodwill(1);
        gameObject.SetActive(false);
    }
    public void DecParanoia()
    {
        associatedCard?.ChangeParanoia(-1);
        gameObject.SetActive(false);
    }
    public void DecGoodwill()
    {
        associatedCard?.ChangeGoodwill(-1);
        gameObject.SetActive(false);
    }

    public void ToggleDead()
    {
        associatedCard?.ToggleDead();
        gameObject.SetActive(false);
    }

    public void RemoveCard()
    {
        associatedCard?.RemoveCard();
        gameObject.SetActive(false);
    }
}
