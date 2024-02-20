using System;
using UnityEngine;

public class Statistic_Logic : MonoBehaviour
{
	[Serializable]
	public class characterBaseAttribute
	{
		[Serializable]
		public class characterBaseSpellAttribute
		{
			[Serializable]
			public class characterSpell
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

			public characterSpell[] CharacterSpell = new characterSpell[5];
		}

		public string characterID;

		public int characterNumber;

		public int characterNumberOfGuards;

		public int characterGuardRatingValue;

		public int characterGuardHealth;

		public int characterGuardHealthRegeneration;

		public int characterMaximumObjectInput;

		public int characterObjectControlManaCost;

		public int characterObjectDamagePlus;

		public float characterObjectSpeedPlus;

		public float characterObjectKnockPlus;

		public int characterMaxManaPoint;

		public int characterStartingManaPoint;

		public int characterManaRegenerate;

		public int characterManaWaveRegenerate;

		public characterBaseSpellAttribute[] CharacterBaseSpellAttribute = new characterBaseSpellAttribute[4];
	}

	[Serializable]
	public class inGameAttribute
	{
		[Serializable]
		public class playerSpellAttribute
		{
			public int playerSpellState = 1;

			public int playerSpellNumber;

			public GameObject spellEffectObject;

			public int spellType;

			public float arrowDirection;

			public float centreSpellTypeHeight;

			public int indicatorType;

			public AudioClip activateSound;

			public int playerSpellEffectClass;

			public int playerSpellManaCost;

			public int playerSpellCoolDown;

			public int playerSpellCastingPenalty;

			public int hpAttributeToggle;

			public int hpAttributeAmount;

			public int hpOverTimeAttributeToggle;

			public int hpOverTimeAttributeAmount;

			public int hpOverTimeAttributeNumber;

			public float hpOverTimeAttributeDelay;

			public int mpAttributeToggle;

			public int mpAttributeAmount;

			public int colorEffectToggle;

			public Color colorEffectColor;

			public float colorEffectDuration;

			public int disableEffectToggle;

			public float disableEffectDuration;

			public int riseEffectToggle;

			public float riseEffectDistance;

			public float riseEffectDuration;

			public float riseEffectDamping;

			public int knockEffectToggle;

			public float knockEffectDistance;

			public float knockEffectDuration;

			public float knockEffectDamping;

			public int dmgAttributeToggle;

			public int dmgAttributeAmount;

			public float dmgAttributeDuration;

			public int msAttributeToggle;

			public int msAttributeAmount;

			public float msAttributeDuration;

			public int asAttributeToggle;

			public int asAttributeAmount;

			public float asAttributeDuration;

			public int apAttributeToggle;

			public int apAttributeAmount;

			public float apAttributeDuration;

			public int anpAttributeToggle;

			public int anpAttributeAmount;

			public float anpAttributeDuration;

			public int mrpAttributeToggle;

			public int mrpAttributeAmount;

			public float mrpAttributeDuration;

			public int crpAttributeToggle;

			public int crpAttributeAmount;

			public float crpAttributeDuration;

			public int acpAttributeToggle;

			public int acpAttributeAmount;

			public float acpAttributeDuration;

			public int evpAttributeToggle;

			public int evpAttributeAmount;

			public float evpAttributeDuration;
		}

		public string characterID;

		public int characterNumber;

		public int playerGuardHealth;

		public int playerGuardHealthRegeneration;

		public int playerMaximumObjectInput;

		public int playerObjectControlManaCost;

		public int playerMaxManaPoint;

		public int playerStartingManaPoint;

		public int playerManaRegenerate;

		public int playerManaWaveRegenerate;

		public playerSpellAttribute[] PlayerSpellAttribute = new playerSpellAttribute[4];

		public int objectPlusDMG;

		public float objectPlusMS;

		public float objectPlusKNK;

		public int difficultyObjectPlusDMG;

		public int difficultyGuardPlusHP;

		public int difficultyIntruderPlusHP;

		public int difficultyIntruderPlusDMG;

		public float difficultyIntruderPlusMS;
	}

	[Serializable]
	public class effectClassAttribute
	{
		public int coolDownAmount;

		public int manaCostAmount;

		public int hpAttributeAmount;

		public int hpOverTimeAttributeAmount;

		public int mpAttributeAmount;

		public float disableEffectDuration;

		public float knockEffectDistance;

		public int dmgAttributeAmount;

		public int msAttributeAmount;

		public int asAttributeAmount;

		public int apAttributeAmount;

		public int anpAttributeAmount;

		public int mrpAttributeAmount;

		public int crpAttributeAmount;

		public int acpAttributeAmount;

		public int evpAttributeAmount;
	}

	[Serializable]
	public class unitClassAttribute
	{
		public string unitClassID;

		public int unitPlusHP;

		public int unitPlusHRP;

		public int unitPlusMP;

		public int unitPlusMRP;

		public int unitPlusDMG;

		public int unitPlusAS;

		public float unitPlusMS;

		public int unitPlusAP;

		public int unitPlusANP;

		public int unitPlusCRP;

		public int unitPlusACP;

		public int unitPlusEVP;
	}

	[Serializable]
	public class summonControl
	{
		public string summonID;

		public int summonNumber;

		public int summonStatus;

		public Unit_Control scriptUnitControl;
	}

	public string characterID;

	public int dataState = -1;

	private Game_Data data;

	private PlayerCharacterInfo scriptPlayerInfo;

	public PlayerCharacterData scriptPlayerData;

	public characterBaseAttribute[] CharacterBaseAttribute = new characterBaseAttribute[1];

	public inGameAttribute[] InGameAttribute = new inGameAttribute[2];

	public effectClassAttribute[] EffectClassAttribute = new effectClassAttribute[30];

	public unitClassAttribute[] UnitClassAttribute = new unitClassAttribute[12];

	public summonControl[] SummonControl = new summonControl[10];

	public int currentSummonNumber;

	public int inGameAttributeUpdate;

	private int TOGGLE_inGameAttributeUpdate;

	private void Awake()
	{
		base.useGUILayout = false;
		data = ScriptsManager.dataScript;
		if (data != null)
		{
			characterID = data.selectedCharacterID;
		}
		dataState = -1;
		for (int i = 0; i < UnitClassAttribute.Length; i++)
		{
			UnitClassAttribute[i].unitClassID = "empty";
		}
		for (int j = 0; j < SummonControl.Length; j++)
		{
			SummonControl[j].summonID = "null";
		}
	}

	private void CharacterAttributeSetupFunction()
	{
		if (data != null)
		{
			for (int i = 0; i < data.CharacterData.Length; i++)
			{
				if (data.CharacterData[i].characterID == data.selectedCharacterID)
				{
					scriptPlayerData = data.CharacterData[i].characterObject.GetComponent<PlayerCharacterData>();
					i = data.CharacterData.Length;
				}
			}
		}
		if (!(scriptPlayerData != null))
		{
			return;
		}
		CharacterBaseAttribute[0].characterID = scriptPlayerData.characterID;
		CharacterBaseAttribute[0].characterNumber = scriptPlayerData.saveID;
		CharacterBaseAttribute[0].characterNumberOfGuards = scriptPlayerData.characterNumberOfGuards;
		CharacterBaseAttribute[0].characterGuardRatingValue = scriptPlayerData.characterGuardRatingValue;
		CharacterBaseAttribute[0].characterGuardHealth = scriptPlayerData.characterGuardHealth;
		CharacterBaseAttribute[0].characterGuardHealthRegeneration = scriptPlayerData.characterGuardHealthRegeneration;
		CharacterBaseAttribute[0].characterMaximumObjectInput = scriptPlayerData.characterMaximumObjectInput;
		CharacterBaseAttribute[0].characterObjectControlManaCost = scriptPlayerData.characterObjectControlManaCost;
		CharacterBaseAttribute[0].characterObjectDamagePlus = scriptPlayerData.characterObjectDamagePlus;
		CharacterBaseAttribute[0].characterObjectSpeedPlus = scriptPlayerData.characterObjectSpeedPlus;
		CharacterBaseAttribute[0].characterObjectKnockPlus = scriptPlayerData.characterObjectKnockPlus;
		CharacterBaseAttribute[0].characterMaxManaPoint = scriptPlayerData.characterMaxManaPoint;
		CharacterBaseAttribute[0].characterStartingManaPoint = scriptPlayerData.characterStartingManaPoint;
		CharacterBaseAttribute[0].characterManaRegenerate = scriptPlayerData.characterManaRegenerate;
		CharacterBaseAttribute[0].characterManaWaveRegenerate = scriptPlayerData.characterManaWaveRegenerate;
		for (int j = 0; j < CharacterBaseAttribute[0].CharacterBaseSpellAttribute.Length; j++)
		{
			for (int k = 0; k < CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell.Length; k++)
			{
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].spellAttributeEffectClass = scriptPlayerData.CharacterSpell[j].Spell[k].spellAttributeEffectClass;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].spellAttributeManaCost = scriptPlayerData.CharacterSpell[j].Spell[k].spellAttributeManaCost;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].spellAttributeCoolDown = scriptPlayerData.CharacterSpell[j].Spell[k].spellAttributeCoolDown;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].spellAttributeCastingPenalty = scriptPlayerData.CharacterSpell[j].Spell[k].spellAttributeCastingPenalty;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].spellEffectObject = scriptPlayerData.CharacterSpell[j].Spell[k].spellEffectObject;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].spellType = scriptPlayerData.CharacterSpell[j].Spell[k].spellType;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].arrowDirection = scriptPlayerData.CharacterSpell[j].Spell[k].arrowDirection;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].centreSpellTypeHeight = scriptPlayerData.CharacterSpell[j].Spell[k].centreSpellTypeHeight;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].indicatorType = scriptPlayerData.CharacterSpell[j].Spell[k].indicatorType;
				CharacterBaseAttribute[0].CharacterBaseSpellAttribute[j].CharacterSpell[k].activateSound = scriptPlayerData.CharacterSpell[j].Spell[k].activateSound;
			}
		}
	}

	private void LateUpdate()
	{
		switch (dataState)
		{
		case -1:
			CharacterAttributeSetupFunction();
			dataState = 0;
			break;
		case 0:
			ResetAttributePlus();
			dataState = 1;
			break;
		case 1:
			AttributeSetupFunction();
			dataState = 2;
			break;
		case 2:
			if (TOGGLE_inGameAttributeUpdate != inGameAttributeUpdate)
			{
				AttributeUpdate();
				TOGGLE_inGameAttributeUpdate = inGameAttributeUpdate;
			}
			break;
		}
	}

	private void AttributeSetupFunction()
	{
		InGameAttribute[0].characterID = CharacterBaseAttribute[0].characterID;
		InGameAttribute[0].characterNumber = CharacterBaseAttribute[0].characterNumber;
		InGameAttribute[0].playerGuardHealth = CharacterBaseAttribute[0].characterGuardHealth;
		InGameAttribute[0].playerGuardHealthRegeneration = CharacterBaseAttribute[0].characterGuardHealthRegeneration;
		InGameAttribute[0].playerMaximumObjectInput = CharacterBaseAttribute[0].characterMaximumObjectInput;
		InGameAttribute[0].playerObjectControlManaCost = CharacterBaseAttribute[0].characterObjectControlManaCost;
		InGameAttribute[0].playerMaxManaPoint = CharacterBaseAttribute[0].characterMaxManaPoint;
		InGameAttribute[0].playerStartingManaPoint = CharacterBaseAttribute[0].characterStartingManaPoint;
		InGameAttribute[0].playerManaRegenerate = CharacterBaseAttribute[0].characterManaRegenerate;
		InGameAttribute[0].playerManaWaveRegenerate = CharacterBaseAttribute[0].characterManaWaveRegenerate;
		InGameAttribute[0].objectPlusDMG = CharacterBaseAttribute[0].characterObjectDamagePlus;
		InGameAttribute[0].objectPlusMS = CharacterBaseAttribute[0].characterObjectSpeedPlus;
		InGameAttribute[0].objectPlusKNK = CharacterBaseAttribute[0].characterObjectKnockPlus;
		for (int i = 0; i < InGameAttribute[0].PlayerSpellAttribute.Length; i++)
		{
			InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber = 0;
			InGameAttribute[0].PlayerSpellAttribute[i].playerSpellEffectClass = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].spellAttributeEffectClass;
			InGameAttribute[0].PlayerSpellAttribute[i].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].spellAttributeManaCost;
			InGameAttribute[0].PlayerSpellAttribute[i].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].spellAttributeCoolDown;
			InGameAttribute[0].PlayerSpellAttribute[i].playerSpellCastingPenalty = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].spellAttributeCastingPenalty;
			InGameAttribute[0].PlayerSpellAttribute[i].spellEffectObject = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].spellEffectObject;
			InGameAttribute[0].PlayerSpellAttribute[i].spellType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].spellType;
			InGameAttribute[0].PlayerSpellAttribute[i].arrowDirection = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].arrowDirection;
			InGameAttribute[0].PlayerSpellAttribute[i].centreSpellTypeHeight = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].centreSpellTypeHeight;
			InGameAttribute[0].PlayerSpellAttribute[i].indicatorType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].indicatorType;
			InGameAttribute[0].PlayerSpellAttribute[i].activateSound = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[i].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[i].playerSpellNumber].activateSound;
			InGameAttribute[0].PlayerSpellAttribute[i].hpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].hpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].hpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].hpAttributeAmount;
			InGameAttribute[0].PlayerSpellAttribute[i].hpOverTimeAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].hpOverTimeAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeAmount;
			InGameAttribute[0].PlayerSpellAttribute[i].hpOverTimeAttributeNumber = InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeNumber;
			InGameAttribute[0].PlayerSpellAttribute[i].hpOverTimeAttributeDelay = InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeDelay;
			InGameAttribute[0].PlayerSpellAttribute[i].mpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].mpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].mpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].mpAttributeAmount;
			InGameAttribute[0].PlayerSpellAttribute[i].colorEffectToggle = InGameAttribute[1].PlayerSpellAttribute[i].colorEffectToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].colorEffectColor = InGameAttribute[1].PlayerSpellAttribute[i].colorEffectColor;
			InGameAttribute[0].PlayerSpellAttribute[i].colorEffectDuration = InGameAttribute[1].PlayerSpellAttribute[i].colorEffectDuration;
			InGameAttribute[0].PlayerSpellAttribute[i].disableEffectToggle = InGameAttribute[1].PlayerSpellAttribute[i].disableEffectToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].disableEffectDuration = InGameAttribute[1].PlayerSpellAttribute[i].disableEffectDuration;
			InGameAttribute[0].PlayerSpellAttribute[i].riseEffectToggle = InGameAttribute[1].PlayerSpellAttribute[i].riseEffectToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].riseEffectDistance = InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDistance;
			InGameAttribute[0].PlayerSpellAttribute[i].riseEffectDuration = InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDuration;
			InGameAttribute[0].PlayerSpellAttribute[i].riseEffectDamping = InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDamping;
			InGameAttribute[0].PlayerSpellAttribute[i].knockEffectToggle = InGameAttribute[1].PlayerSpellAttribute[i].knockEffectToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].knockEffectDistance = InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDistance;
			InGameAttribute[0].PlayerSpellAttribute[i].knockEffectDuration = InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDuration;
			InGameAttribute[0].PlayerSpellAttribute[i].knockEffectDamping = InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDamping;
			InGameAttribute[0].PlayerSpellAttribute[i].dmgAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].dmgAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeAmount;
			InGameAttribute[0].PlayerSpellAttribute[i].dmgAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeDuration;
			InGameAttribute[0].PlayerSpellAttribute[i].msAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].msAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].msAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].msAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].msAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].msAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].asAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].asAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].asAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].asAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].asAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].asAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].apAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].apAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].apAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].apAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].apAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].apAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].anpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].anpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].anpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].mrpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].mrpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].mrpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].crpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].crpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].crpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].acpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].acpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].acpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].evpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].evpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeToggle;
			InGameAttribute[0].PlayerSpellAttribute[i].evpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeToggle;
		}
	}

	private void AttributeUpdate()
	{
		InGameAttribute[1].characterID = "Plus Value";
		InGameAttribute[0].characterID = CharacterBaseAttribute[0].characterID;
		InGameAttribute[0].characterNumber = CharacterBaseAttribute[0].characterNumber;
		InGameAttribute[0].playerGuardHealth = CharacterBaseAttribute[0].characterGuardHealth + InGameAttribute[1].playerGuardHealth;
		InGameAttribute[0].playerGuardHealthRegeneration = CharacterBaseAttribute[0].characterGuardHealthRegeneration + InGameAttribute[1].playerGuardHealthRegeneration;
		InGameAttribute[0].playerMaximumObjectInput = CharacterBaseAttribute[0].characterMaximumObjectInput + InGameAttribute[1].playerMaximumObjectInput;
		InGameAttribute[0].playerObjectControlManaCost = CharacterBaseAttribute[0].characterObjectControlManaCost + InGameAttribute[1].playerObjectControlManaCost;
		InGameAttribute[0].playerMaxManaPoint = CharacterBaseAttribute[0].characterMaxManaPoint + InGameAttribute[1].playerMaxManaPoint;
		InGameAttribute[0].playerStartingManaPoint = CharacterBaseAttribute[0].characterStartingManaPoint + InGameAttribute[1].playerStartingManaPoint;
		InGameAttribute[0].playerManaRegenerate = CharacterBaseAttribute[0].characterManaRegenerate + InGameAttribute[1].playerManaRegenerate;
		InGameAttribute[0].playerManaWaveRegenerate = CharacterBaseAttribute[0].characterManaWaveRegenerate + InGameAttribute[1].playerManaWaveRegenerate;
		InGameAttribute[0].objectPlusDMG = CharacterBaseAttribute[0].characterObjectDamagePlus + InGameAttribute[1].objectPlusDMG;
		InGameAttribute[0].objectPlusMS = CharacterBaseAttribute[0].characterObjectSpeedPlus + InGameAttribute[1].objectPlusMS;
		InGameAttribute[0].objectPlusKNK = CharacterBaseAttribute[0].characterObjectKnockPlus + InGameAttribute[1].objectPlusKNK;
		if (InGameAttribute[0].PlayerSpellAttribute[0].playerSpellEffectClass >= 0)
		{
			InGameAttribute[0].PlayerSpellAttribute[0].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].spellAttributeManaCost + InGameAttribute[1].PlayerSpellAttribute[0].playerSpellManaCost + EffectClassAttribute[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellEffectClass].manaCostAmount;
			InGameAttribute[0].PlayerSpellAttribute[0].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].spellAttributeCoolDown + InGameAttribute[1].PlayerSpellAttribute[0].playerSpellCoolDown + EffectClassAttribute[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellEffectClass].coolDownAmount;
		}
		else
		{
			InGameAttribute[0].PlayerSpellAttribute[0].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].spellAttributeManaCost + InGameAttribute[1].PlayerSpellAttribute[0].playerSpellManaCost;
			InGameAttribute[0].PlayerSpellAttribute[0].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].spellAttributeCoolDown + InGameAttribute[1].PlayerSpellAttribute[0].playerSpellCoolDown;
		}
		InGameAttribute[0].PlayerSpellAttribute[0].playerSpellCastingPenalty = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].spellAttributeCastingPenalty;
		InGameAttribute[0].PlayerSpellAttribute[0].spellEffectObject = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].spellEffectObject;
		InGameAttribute[0].PlayerSpellAttribute[0].spellType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].spellType;
		InGameAttribute[0].PlayerSpellAttribute[0].arrowDirection = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].arrowDirection;
		InGameAttribute[0].PlayerSpellAttribute[0].centreSpellTypeHeight = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].centreSpellTypeHeight;
		InGameAttribute[0].PlayerSpellAttribute[0].indicatorType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].indicatorType;
		InGameAttribute[0].PlayerSpellAttribute[0].activateSound = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[0].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[0].playerSpellNumber].activateSound;
		InGameAttribute[0].PlayerSpellAttribute[0].hpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].hpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].hpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].hpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].hpOverTimeAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].hpOverTimeAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].hpOverTimeAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].hpOverTimeAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].hpOverTimeAttributeNumber = InGameAttribute[1].PlayerSpellAttribute[0].hpOverTimeAttributeNumber;
		InGameAttribute[0].PlayerSpellAttribute[0].hpOverTimeAttributeDelay = InGameAttribute[1].PlayerSpellAttribute[0].hpOverTimeAttributeDelay;
		InGameAttribute[0].PlayerSpellAttribute[0].mpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].mpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].mpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].mpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].colorEffectToggle = InGameAttribute[1].PlayerSpellAttribute[0].colorEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].colorEffectColor = InGameAttribute[1].PlayerSpellAttribute[0].colorEffectColor;
		InGameAttribute[0].PlayerSpellAttribute[0].colorEffectDuration = InGameAttribute[1].PlayerSpellAttribute[0].colorEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].disableEffectToggle = InGameAttribute[1].PlayerSpellAttribute[0].disableEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].disableEffectDuration = InGameAttribute[1].PlayerSpellAttribute[0].disableEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].riseEffectToggle = InGameAttribute[1].PlayerSpellAttribute[0].riseEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].riseEffectDistance = InGameAttribute[1].PlayerSpellAttribute[0].riseEffectDistance;
		InGameAttribute[0].PlayerSpellAttribute[0].riseEffectDuration = InGameAttribute[1].PlayerSpellAttribute[0].riseEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].riseEffectDamping = InGameAttribute[1].PlayerSpellAttribute[0].riseEffectDamping;
		InGameAttribute[0].PlayerSpellAttribute[0].knockEffectToggle = InGameAttribute[1].PlayerSpellAttribute[0].knockEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].knockEffectDistance = InGameAttribute[1].PlayerSpellAttribute[0].knockEffectDistance;
		InGameAttribute[0].PlayerSpellAttribute[0].knockEffectDuration = InGameAttribute[1].PlayerSpellAttribute[0].knockEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].knockEffectDamping = InGameAttribute[1].PlayerSpellAttribute[0].knockEffectDamping;
		InGameAttribute[0].PlayerSpellAttribute[0].dmgAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].dmgAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].dmgAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].dmgAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].dmgAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].dmgAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].msAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].msAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].msAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].msAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].msAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].msAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].asAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].asAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].asAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].asAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].asAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].asAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].apAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].apAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].apAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].apAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].apAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].apAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].anpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].anpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].anpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].anpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].anpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].anpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].mrpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].mrpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].mrpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].mrpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].mrpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].mrpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].crpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].crpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].crpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].crpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].crpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].crpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].acpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].acpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].acpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].acpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].acpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].acpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[0].evpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[0].evpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[0].evpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[0].evpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[0].evpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[0].evpAttributeDuration;
		if (InGameAttribute[0].PlayerSpellAttribute[1].playerSpellEffectClass >= 0)
		{
			InGameAttribute[0].PlayerSpellAttribute[1].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].spellAttributeManaCost + InGameAttribute[1].PlayerSpellAttribute[1].playerSpellManaCost + EffectClassAttribute[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellEffectClass].manaCostAmount;
			InGameAttribute[0].PlayerSpellAttribute[1].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].spellAttributeCoolDown + InGameAttribute[1].PlayerSpellAttribute[1].playerSpellCoolDown + EffectClassAttribute[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellEffectClass].coolDownAmount;
		}
		else
		{
			InGameAttribute[0].PlayerSpellAttribute[1].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].spellAttributeManaCost + InGameAttribute[1].PlayerSpellAttribute[1].playerSpellManaCost;
			InGameAttribute[0].PlayerSpellAttribute[1].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].spellAttributeCoolDown + InGameAttribute[1].PlayerSpellAttribute[1].playerSpellCoolDown;
		}
		InGameAttribute[0].PlayerSpellAttribute[1].playerSpellCastingPenalty = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].spellAttributeCastingPenalty;
		InGameAttribute[0].PlayerSpellAttribute[1].spellEffectObject = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].spellEffectObject;
		InGameAttribute[0].PlayerSpellAttribute[1].spellType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].spellType;
		InGameAttribute[0].PlayerSpellAttribute[1].arrowDirection = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].arrowDirection;
		InGameAttribute[0].PlayerSpellAttribute[1].centreSpellTypeHeight = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].centreSpellTypeHeight;
		InGameAttribute[0].PlayerSpellAttribute[1].indicatorType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].indicatorType;
		InGameAttribute[0].PlayerSpellAttribute[1].activateSound = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[1].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[1].playerSpellNumber].activateSound;
		InGameAttribute[0].PlayerSpellAttribute[1].hpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].hpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].hpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].hpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].hpOverTimeAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].hpOverTimeAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].hpOverTimeAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].hpOverTimeAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].hpOverTimeAttributeNumber = InGameAttribute[1].PlayerSpellAttribute[1].hpOverTimeAttributeNumber;
		InGameAttribute[0].PlayerSpellAttribute[1].hpOverTimeAttributeDelay = InGameAttribute[1].PlayerSpellAttribute[1].hpOverTimeAttributeDelay;
		InGameAttribute[0].PlayerSpellAttribute[1].mpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].mpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].mpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].mpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].colorEffectToggle = InGameAttribute[1].PlayerSpellAttribute[1].colorEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].colorEffectColor = InGameAttribute[1].PlayerSpellAttribute[1].colorEffectColor;
		InGameAttribute[0].PlayerSpellAttribute[1].colorEffectDuration = InGameAttribute[1].PlayerSpellAttribute[1].colorEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].disableEffectToggle = InGameAttribute[1].PlayerSpellAttribute[1].disableEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].disableEffectDuration = InGameAttribute[1].PlayerSpellAttribute[1].disableEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].knockEffectToggle = InGameAttribute[1].PlayerSpellAttribute[1].knockEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].knockEffectDistance = InGameAttribute[1].PlayerSpellAttribute[1].knockEffectDistance;
		InGameAttribute[0].PlayerSpellAttribute[1].knockEffectDuration = InGameAttribute[1].PlayerSpellAttribute[1].knockEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].knockEffectDamping = InGameAttribute[1].PlayerSpellAttribute[1].knockEffectDamping;
		InGameAttribute[0].PlayerSpellAttribute[1].riseEffectToggle = InGameAttribute[1].PlayerSpellAttribute[1].riseEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].riseEffectDistance = InGameAttribute[1].PlayerSpellAttribute[1].riseEffectDistance;
		InGameAttribute[0].PlayerSpellAttribute[1].riseEffectDuration = InGameAttribute[1].PlayerSpellAttribute[1].riseEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].riseEffectDamping = InGameAttribute[1].PlayerSpellAttribute[1].riseEffectDamping;
		InGameAttribute[0].PlayerSpellAttribute[1].dmgAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].dmgAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].dmgAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].dmgAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].dmgAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[1].dmgAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].msAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].msAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].msAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].msAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].msAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[1].msAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].asAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].asAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].asAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].asAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].asAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[1].asAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].apAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].apAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].apAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].apAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].apAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[1].apAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].mrpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].mrpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].mrpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].mrpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].mrpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[1].mrpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].crpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].crpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].crpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].crpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].crpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[1].crpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].acpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].acpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].acpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].acpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].acpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[1].acpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[1].evpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[1].evpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[1].evpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[1].evpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[1].evpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[1].evpAttributeDuration;
		if (InGameAttribute[0].PlayerSpellAttribute[2].playerSpellEffectClass >= 0)
		{
			InGameAttribute[0].PlayerSpellAttribute[2].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].spellAttributeManaCost + InGameAttribute[1].PlayerSpellAttribute[2].playerSpellManaCost + EffectClassAttribute[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellEffectClass].manaCostAmount;
			InGameAttribute[0].PlayerSpellAttribute[2].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].spellAttributeCoolDown + InGameAttribute[1].PlayerSpellAttribute[2].playerSpellCoolDown + EffectClassAttribute[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellEffectClass].coolDownAmount;
		}
		else
		{
			InGameAttribute[0].PlayerSpellAttribute[2].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].spellAttributeManaCost + InGameAttribute[1].PlayerSpellAttribute[2].playerSpellManaCost;
			InGameAttribute[0].PlayerSpellAttribute[2].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].spellAttributeCoolDown + InGameAttribute[1].PlayerSpellAttribute[2].playerSpellCoolDown;
		}
		InGameAttribute[0].PlayerSpellAttribute[2].playerSpellCastingPenalty = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].spellAttributeCastingPenalty;
		InGameAttribute[0].PlayerSpellAttribute[2].spellEffectObject = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].spellEffectObject;
		InGameAttribute[0].PlayerSpellAttribute[2].spellType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].spellType;
		InGameAttribute[0].PlayerSpellAttribute[2].arrowDirection = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].arrowDirection;
		InGameAttribute[0].PlayerSpellAttribute[2].centreSpellTypeHeight = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].centreSpellTypeHeight;
		InGameAttribute[0].PlayerSpellAttribute[2].indicatorType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].indicatorType;
		InGameAttribute[0].PlayerSpellAttribute[2].activateSound = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[2].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[2].playerSpellNumber].activateSound;
		InGameAttribute[0].PlayerSpellAttribute[2].hpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].hpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].hpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].hpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].hpOverTimeAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].hpOverTimeAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].hpOverTimeAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].hpOverTimeAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].hpOverTimeAttributeNumber = InGameAttribute[1].PlayerSpellAttribute[2].hpOverTimeAttributeNumber;
		InGameAttribute[0].PlayerSpellAttribute[2].hpOverTimeAttributeDelay = InGameAttribute[1].PlayerSpellAttribute[2].hpOverTimeAttributeDelay;
		InGameAttribute[0].PlayerSpellAttribute[2].mpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].mpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].mpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].mpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].colorEffectToggle = InGameAttribute[1].PlayerSpellAttribute[2].colorEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].colorEffectColor = InGameAttribute[1].PlayerSpellAttribute[2].colorEffectColor;
		InGameAttribute[0].PlayerSpellAttribute[2].colorEffectDuration = InGameAttribute[1].PlayerSpellAttribute[2].colorEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].disableEffectToggle = InGameAttribute[1].PlayerSpellAttribute[2].disableEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].disableEffectDuration = InGameAttribute[1].PlayerSpellAttribute[2].disableEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].knockEffectToggle = InGameAttribute[1].PlayerSpellAttribute[2].knockEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].knockEffectDistance = InGameAttribute[1].PlayerSpellAttribute[2].knockEffectDistance;
		InGameAttribute[0].PlayerSpellAttribute[2].knockEffectDuration = InGameAttribute[1].PlayerSpellAttribute[2].knockEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].knockEffectDamping = InGameAttribute[1].PlayerSpellAttribute[2].knockEffectDamping;
		InGameAttribute[0].PlayerSpellAttribute[2].riseEffectToggle = InGameAttribute[1].PlayerSpellAttribute[2].riseEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].riseEffectDistance = InGameAttribute[1].PlayerSpellAttribute[2].riseEffectDistance;
		InGameAttribute[0].PlayerSpellAttribute[2].riseEffectDuration = InGameAttribute[1].PlayerSpellAttribute[2].riseEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].riseEffectDamping = InGameAttribute[1].PlayerSpellAttribute[2].riseEffectDamping;
		InGameAttribute[0].PlayerSpellAttribute[2].dmgAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].dmgAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].dmgAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].dmgAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].dmgAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].dmgAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].msAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].msAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].msAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].msAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].msAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].msAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].asAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].asAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].asAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].asAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].asAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].asAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].apAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].apAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].apAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].apAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].apAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].apAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].anpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].anpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].anpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].anpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].anpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].anpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].mrpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].mrpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].mrpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].mrpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].mrpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].mrpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].crpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].crpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].crpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].crpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].crpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].crpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].acpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].acpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].acpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].acpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].acpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].acpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[2].evpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[2].evpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[2].evpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[2].evpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[2].evpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[2].evpAttributeDuration;
		if (InGameAttribute[0].PlayerSpellAttribute[3].playerSpellEffectClass >= 0)
		{
			InGameAttribute[0].PlayerSpellAttribute[3].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].spellAttributeManaCost + InGameAttribute[1].PlayerSpellAttribute[3].playerSpellManaCost + EffectClassAttribute[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellEffectClass].manaCostAmount;
			InGameAttribute[0].PlayerSpellAttribute[3].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].spellAttributeCoolDown + InGameAttribute[1].PlayerSpellAttribute[3].playerSpellCoolDown + EffectClassAttribute[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellEffectClass].coolDownAmount;
		}
		else
		{
			InGameAttribute[0].PlayerSpellAttribute[3].playerSpellManaCost = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].spellAttributeManaCost + InGameAttribute[1].PlayerSpellAttribute[3].playerSpellManaCost;
			InGameAttribute[0].PlayerSpellAttribute[3].playerSpellCoolDown = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].spellAttributeCoolDown + InGameAttribute[1].PlayerSpellAttribute[3].playerSpellCoolDown;
		}
		InGameAttribute[0].PlayerSpellAttribute[3].playerSpellCastingPenalty = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].spellAttributeCastingPenalty;
		InGameAttribute[0].PlayerSpellAttribute[3].spellEffectObject = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].spellEffectObject;
		InGameAttribute[0].PlayerSpellAttribute[3].spellType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].spellType;
		InGameAttribute[0].PlayerSpellAttribute[3].arrowDirection = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].arrowDirection;
		InGameAttribute[0].PlayerSpellAttribute[3].centreSpellTypeHeight = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].centreSpellTypeHeight;
		InGameAttribute[0].PlayerSpellAttribute[3].indicatorType = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].indicatorType;
		InGameAttribute[0].PlayerSpellAttribute[3].activateSound = CharacterBaseAttribute[0].CharacterBaseSpellAttribute[3].CharacterSpell[InGameAttribute[0].PlayerSpellAttribute[3].playerSpellNumber].activateSound;
		InGameAttribute[0].PlayerSpellAttribute[3].hpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].hpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].hpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].hpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].hpOverTimeAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].hpOverTimeAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].hpOverTimeAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].hpOverTimeAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].hpOverTimeAttributeNumber = InGameAttribute[1].PlayerSpellAttribute[3].hpOverTimeAttributeNumber;
		InGameAttribute[0].PlayerSpellAttribute[3].hpOverTimeAttributeDelay = InGameAttribute[1].PlayerSpellAttribute[3].hpOverTimeAttributeDelay;
		InGameAttribute[0].PlayerSpellAttribute[3].mpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].mpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].mpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].mpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].colorEffectToggle = InGameAttribute[1].PlayerSpellAttribute[3].colorEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].colorEffectColor = InGameAttribute[1].PlayerSpellAttribute[3].colorEffectColor;
		InGameAttribute[0].PlayerSpellAttribute[3].colorEffectDuration = InGameAttribute[1].PlayerSpellAttribute[3].colorEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].disableEffectToggle = InGameAttribute[1].PlayerSpellAttribute[3].disableEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].disableEffectDuration = InGameAttribute[1].PlayerSpellAttribute[3].disableEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].knockEffectToggle = InGameAttribute[1].PlayerSpellAttribute[3].knockEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].knockEffectDistance = InGameAttribute[1].PlayerSpellAttribute[3].knockEffectDistance;
		InGameAttribute[0].PlayerSpellAttribute[3].knockEffectDuration = InGameAttribute[1].PlayerSpellAttribute[3].knockEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].knockEffectDamping = InGameAttribute[1].PlayerSpellAttribute[3].knockEffectDamping;
		InGameAttribute[0].PlayerSpellAttribute[3].riseEffectToggle = InGameAttribute[1].PlayerSpellAttribute[3].riseEffectToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].riseEffectDistance = InGameAttribute[1].PlayerSpellAttribute[3].riseEffectDistance;
		InGameAttribute[0].PlayerSpellAttribute[3].riseEffectDuration = InGameAttribute[1].PlayerSpellAttribute[3].riseEffectDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].riseEffectDamping = InGameAttribute[1].PlayerSpellAttribute[3].riseEffectDamping;
		InGameAttribute[0].PlayerSpellAttribute[3].dmgAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].dmgAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].dmgAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].dmgAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].dmgAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].dmgAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].msAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].msAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].msAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].msAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].msAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].msAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].asAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].asAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].asAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].asAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].asAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].asAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].apAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].apAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].apAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].apAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].apAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].apAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].anpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].anpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].anpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].anpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].anpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].anpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].mrpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].mrpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].mrpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].mrpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].mrpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].mrpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].crpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].crpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].crpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].crpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].crpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].crpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].acpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].acpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].acpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].acpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].acpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].acpAttributeDuration;
		InGameAttribute[0].PlayerSpellAttribute[3].evpAttributeToggle = InGameAttribute[1].PlayerSpellAttribute[3].evpAttributeToggle;
		InGameAttribute[0].PlayerSpellAttribute[3].evpAttributeAmount = InGameAttribute[1].PlayerSpellAttribute[3].evpAttributeAmount;
		InGameAttribute[0].PlayerSpellAttribute[3].evpAttributeDuration = InGameAttribute[1].PlayerSpellAttribute[3].evpAttributeDuration;
		if (InGameAttribute[0].PlayerSpellAttribute[0].playerSpellManaCost > 500)
		{
			InGameAttribute[0].PlayerSpellAttribute[0].playerSpellManaCost = 500;
		}
		if (InGameAttribute[0].PlayerSpellAttribute[1].playerSpellManaCost > 500)
		{
			InGameAttribute[0].PlayerSpellAttribute[1].playerSpellManaCost = 500;
		}
		if (InGameAttribute[0].PlayerSpellAttribute[2].playerSpellManaCost > 500)
		{
			InGameAttribute[0].PlayerSpellAttribute[2].playerSpellManaCost = 500;
		}
		if (InGameAttribute[0].PlayerSpellAttribute[3].playerSpellManaCost > 500)
		{
			InGameAttribute[0].PlayerSpellAttribute[3].playerSpellManaCost = 500;
		}
	}

	public void ResetAttributePlus()
	{
		InGameAttribute[1].playerGuardHealth = 0;
		InGameAttribute[1].playerGuardHealthRegeneration = 0;
		InGameAttribute[1].playerMaximumObjectInput = 0;
		InGameAttribute[1].playerObjectControlManaCost = 0;
		InGameAttribute[1].playerMaxManaPoint = 0;
		InGameAttribute[1].playerStartingManaPoint = 0;
		InGameAttribute[1].playerManaRegenerate = 0;
		InGameAttribute[0].objectPlusDMG = 0;
		InGameAttribute[0].objectPlusMS = 0f;
		InGameAttribute[0].objectPlusKNK = 0f;
		for (int i = 0; i < InGameAttribute[1].PlayerSpellAttribute.Length; i++)
		{
			InGameAttribute[1].PlayerSpellAttribute[i].playerSpellNumber = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].playerSpellManaCost = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].playerSpellCoolDown = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].playerSpellCastingPenalty = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].hpAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].hpAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeNumber = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeDelay = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].mpAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].mpAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].colorEffectToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].colorEffectColor = Color.white;
			InGameAttribute[1].PlayerSpellAttribute[i].colorEffectDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].disableEffectToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].disableEffectDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].riseEffectToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDistance = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDamping = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].knockEffectToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDistance = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDamping = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].msAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].msAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].msAttributeDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].asAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].asAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].asAttributeDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].apAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].apAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].apAttributeDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeDuration = 0f;
			InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeToggle = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeAmount = 0;
			InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeDuration = 0f;
		}
	}
}
