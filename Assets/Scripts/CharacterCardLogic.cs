using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardLogic : MonoBehaviour
{
    public CharacterCardData cardData;
    public int paranoia;
    public int goodwill;
    [SerializeField]
    private bool dead;
    [SerializeField]
    private bool dirty;
    private Image characterPicture;
    private Text characterName;
    private Text characterStats;



    private void Awake()
    {
        var temp = GetComponentsInChildren<Text>();
        characterName = temp[0];
        characterStats = temp[1];
        characterPicture = GetComponentsInChildren<Image>()[1];
        dirty = true;
    }


    private void Update()
    {
        if (dirty)
        {
            // handle rotation for card death
            if (dead)
            {
                Vector3 temp = new Vector3(0, 0, -90);
                transform.eulerAngles = temp;
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
            }

            // update 
            characterName.text = cardData.characterName;
            characterPicture.sprite = cardData.characterPicture;
            characterStats.text = FormatStatsText(cardData);
            dirty = false;
        }
    }

    private string FormatStatsText(CharacterCardData cardData)
    {
        StringBuilder newText = new StringBuilder("Paranoia: ", 50);
        newText.Append(paranoia);
        newText.Append("\n/");
        newText.Append(cardData.paranoiaLimit);
        newText.Append("\nGoodwill: ");
        newText.Append(goodwill);
        newText.Append("\n");
        bool firstGW = true;
        foreach (int gwTrigger in cardData.goodWillAbilityLevels)
        {
            if (firstGW) firstGW = false;
            else newText.Append("   ");
            newText.Append("/");
            newText.Append(gwTrigger);
        }

        return newText.ToString();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right click on card!");
        }
    }

    public void ChangeParanoia(int deltaValue)
    {
        SetParanoia(paranoia + deltaValue);
    }

    public void ChangeGoodwill(int deltaValue)
    {
        SetGoodwill(goodwill + deltaValue);
    }

    public void SetParanoia(int value)
    {
        paranoia = (value < 0) ? 0 : value;
        dirty = true;
    }

    public void SetGoodwill(int value)
    {
        goodwill = (value < 0) ? 0 : value;
        dirty = true;
    }

    public void ToggleDead()
    {
        dead = !dead;
        dirty = true;
    }

    // TODO: card pooling is probably a good best practice.  But for now, they won't be created/destroyed often
    public void RemoveCard()
    {
        GameObject.Destroy(gameObject);
    }


}
