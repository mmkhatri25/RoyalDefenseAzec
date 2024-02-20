using UnityEngine;

public class PlayerCharacterInfo : MonoBehaviour
{
	private PlayerCharacterData characterData;

	public string characterID;

	public string characterName;

	public string characterClass;

	public int characterDifficulty;

	public Color characterBackgroundColor;

	public string redSpellName;

	public int redSpellManaCost;

	public string redSpellDescription;

	public string blueSpellName;

	public int blueSpellManaCost;

	public string blueSpellDescription;

	public string yellowSpellName;

	public int yellowSpellManaCost;

	public string yellowSpellDescription;

	public string greenSpellName;

	public int greenSpellManaCost;

	public string greenSpellDescription;

	public string guardName;

	public int numberOfGuards;

	public Unit_Attributes guardAttribute;

	public string[] itemDescription = new string[4];

	private void Start()
	{
		characterData = GetComponent<PlayerCharacterData>();
		characterID = characterData.characterID;
		redSpellManaCost = characterData.CharacterSpell[0].Spell[0].spellAttributeManaCost;
		blueSpellManaCost = characterData.CharacterSpell[1].Spell[0].spellAttributeManaCost;
		yellowSpellManaCost = characterData.CharacterSpell[2].Spell[0].spellAttributeManaCost;
		greenSpellManaCost = characterData.CharacterSpell[3].Spell[0].spellAttributeManaCost;
		characterName = PlayerPrefs.GetString(characterID + "characterName");
		characterClass = PlayerPrefs.GetString(characterID + "characterClass");
	}

	private void OnDespawned()
	{
	}

	private void LateUpdate()
	{
	}
}
