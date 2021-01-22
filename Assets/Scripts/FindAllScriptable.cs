using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAllScriptable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterCardData[] allCards = Resources.FindObjectsOfTypeAll<CharacterCardData>();


        //CharacterCardData[] allCards = FindObjectsOfType(typeof(CharacterCardData)) as CharacterCardData[];

        Debug.Log("All " + allCards.Length + " cards found:");
        foreach (var c in allCards)
        {
            Debug.Log(c.characterName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
