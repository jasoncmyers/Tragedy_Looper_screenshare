using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCardLogic : MonoBehaviour
{
    public CharacterCardData cardData;
    public int paranoia;
    public int goodwill;
    public bool dead;


    private void OnMouseOver()
    {
        Debug.Log("MouseOver on card " + cardData?.characterName);
    }


    private void Update()
    {
        if (dead && transform.eulerAngles == Vector3.zero)
        {
            Vector3 temp = new Vector3(0, 0, -90);
            transform.eulerAngles = temp;
        }
        else if (!dead)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
