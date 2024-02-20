using System;
using UnityEngine;

public class PlayerCharacterData : MonoBehaviour
{
	[Serializable]
	public class characterSpell
	{
		[Serializable]
		public class spell
		{
			public int spellAttributeEffectClass;

			public int spellAttributeManaCost;

			public int spellAttributeCoolDown;

			public int spellAttributeCastingPenalty;

			public GameObject spellEffectObject;

			public int spellType;

			public float arrowDirection;

			public float centreSpellTypeHeight;

			public int indicatorType;

			public AudioClip activateSound;
		}

		public spell[] Spell = new spell[5];
	}

	[Serializable]
	public class stageIDs
	{
		public string stageID;

		public string[] levelContentIDs = new string[7];
	}

	[Serializable]
	public class itemUnlockID
	{
		public string itemID;

		public int itemState;
	}

	public string characterID;

	public int saveID;

	public characterSpell[] CharacterSpell = new characterSpell[4];

	public GameObject characterGuardLogic;

	public int characterNumberOfGuards;

	public int characterGuardRatingValue;

	public int characterGuardHealth;

	public int characterGuardHealthRegeneration;

	public int characterMaximumObjectInput;

	public int characterObjectControlManaCost;

	public int characterObjectDamagePlus;

	public int characterObjectSpeedPlus;

	public int characterObjectKnockPlus;

	public int characterMaxManaPoint;

	public int characterStartingManaPoint;

	public int characterManaRegenerate;

	public int characterManaWaveRegenerate;

	public string[] levelIDs = new string[21];

	public stageIDs[] StageIDs = new stageIDs[3];

	public itemUnlockID[] ItemUnlockID = new itemUnlockID[4];

	public GameObject characterTutorial;

	public string storyBeginning;

	public string storyEnd;

	public string cutsceneStage1;

	public string cutsceneStage2;

	public string cutsceneStage3;

	private int TOGGLE_levelNumber;

	private Game_Data data;

	private Content_Data contentData;

	private void Awake()
	{
	}

	private void Start()
	{
		base.gameObject.name = "Player Character";
		ScriptsManager.playerCharacter = base.gameObject;
	}

	private void OnSpawned()
	{
	}

	private void OnDespawned()
	{
		base.gameObject.name = characterID + "_OFF";
	}

	private void Update()
	{
		if (base.gameObject.name != "Player Character")
		{
			base.gameObject.name = "Player Character";
		}
	}
}
