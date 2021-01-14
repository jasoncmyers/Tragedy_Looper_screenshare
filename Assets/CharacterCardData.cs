using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCardData", menuName = "Character Card Data", order = 51)]
public class CharacterCardData : ScriptableObject
{
    public string characterName;
    public Sprite characterPicture;
    public int paranoiaLimit;
    public List<int> goodWillAbilityLevels;

    public List<int> forbiddenLocations;
}
