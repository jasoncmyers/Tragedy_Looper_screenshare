using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPopulate : MonoBehaviour
{

    GameObject MainPanel;
    public CharacterCardData[] availableCharacterCards;

    
    // Start is called before the first frame update
    void Start()
    {
        MainPanel = this.gameObject;
        foreach (var card in availableCharacterCards)
        {
            Button temp = MainPanel.AddComponent<Button>();
            //temp.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
