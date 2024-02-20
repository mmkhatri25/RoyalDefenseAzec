using System;
using UnityEngine;

public class Spell_Logic : MonoBehaviour
{
	[Serializable]
	public class spellControl
	{
		public string colorID;

		public int spellState;

		public int spellNumber;

		public int manaCost;

		public int coolDown;

		public int castPenalty;

		public GameObject spellButton;

		public tk2dAnimatedSprite spellIcon;

		public tk2dAnimatedSprite costIcon;

		public tk2dAnimatedSprite iconBackground;

		public pop_effect popEffect;

		public BarMetre_Script coolDownShade;

		public GameObject highlight;

		public int casterControlType;

		public int casterIndicatorType;

		public float casterArrowDirection;

		public float casterCentreSpellTypeHeight;

		public AudioClip casterActivateSound;

		public GameObject casterSpawnEffect;

		public float coolDownAmount;

		public int spellStateToggle;
	}

	public string characterID;

	public int manaNumber;

	public GameObject spellCaster;

	public int spellState;

	public float spellStateDuration;

	public spellControl[] SpellControl;

	private Game_Logic scriptGameLogic;

	private Game_Statistics scriptGameStatistic;

	private Statistic_Logic scriptStatisticLogic;

	public int spellUpdate;

	private float TIMER_spellState;

	private int TOGGLE_spellState;

	private void Start()
	{
		base.useGUILayout = false;
		scriptGameLogic = GameScriptsManager.gameLogicScript;
		scriptGameStatistic = GameScriptsManager.gameStatisticScript;
		scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		for (int i = 0; i < SpellControl.Length; i++)
		{
			SpellControl[i].coolDownAmount = SpellControl[i].coolDown;
			SpellControl[i].spellState = -2;
			SpellControl[i].spellStateToggle = -2;
		}
	}

	private void Update()
	{
		if (characterID != scriptStatisticLogic.characterID)
		{
			characterID = scriptStatisticLogic.characterID;
		}
		if (Time.timeScale != 0f)
		{
			SpellStateFunction();
			SpellFunction(0);
			SpellFunction(1);
			SpellFunction(2);
			SpellFunction(3);
		}
	}

	public void SpellState(int state, float duration)
	{
		spellState = state;
		spellStateDuration = duration;
	}

	private void SpellStateFunction()
	{
		switch (spellState)
		{
		case -1:
			if (TOGGLE_spellState != spellState)
			{
				TIMER_spellState = Time.time + 0.1f;
				TOGGLE_spellState = spellState;
			}
			if (Time.time >= TIMER_spellState)
			{
				spellState = 0;
			}
			break;
		case 0:
			if (TOGGLE_spellState != spellState)
			{
				TOGGLE_spellState = spellState;
			}
			break;
		case 1:
			if (TOGGLE_spellState != spellState)
			{
				TIMER_spellState = Time.time + 0.1f;
				TOGGLE_spellState = spellState;
			}
			if (Time.time >= TIMER_spellState)
			{
				spellState = 0;
			}
			break;
		case 2:
			if (TOGGLE_spellState != spellState)
			{
				TIMER_spellState = Time.time + spellStateDuration;
				TOGGLE_spellState = spellState;
			}
			if (spellStateDuration != 0f && Time.time >= TIMER_spellState)
			{
				spellState = 0;
			}
			break;
		case 3:
			if (TOGGLE_spellState != spellState)
			{
				TIMER_spellState = Time.time + spellStateDuration;
				TOGGLE_spellState = spellState;
			}
			if (spellStateDuration != 0f && Time.time >= TIMER_spellState)
			{
				spellState = 0;
			}
			break;
		case 4:
			if (TOGGLE_spellState != spellState)
			{
				TIMER_spellState = Time.time + spellStateDuration;
				TOGGLE_spellState = spellState;
			}
			if (spellStateDuration != 0f && Time.time >= TIMER_spellState)
			{
				spellState = 0;
			}
			break;
		case 5:
			if (TOGGLE_spellState != spellState)
			{
				TIMER_spellState = Time.time + spellStateDuration;
				TOGGLE_spellState = spellState;
			}
			if (spellStateDuration != 0f && Time.time >= TIMER_spellState)
			{
				spellState = 0;
			}
			break;
		}
	}

	private void SpellUpdate(int x)
	{
		if (spellUpdate != 0)
		{
			return;
		}
		if (SpellControl[x].spellNumber != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellNumber)
		{
			SpellControl[x].spellNumber = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellNumber;
			SpellControl[x].spellStateToggle = -100;
		}
		if (spellState == 4 || spellState == 5)
		{
			if (SpellControl[x].manaCost != 0)
			{
				SpellControl[x].manaCost = 0;
				SpellControl[x].spellStateToggle = -100;
			}
		}
		else if (SpellControl[x].manaCost != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellManaCost)
		{
			SpellControl[x].manaCost = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellManaCost;
			SpellControl[x].spellStateToggle = -100;
		}
		if (SpellControl[x].coolDown != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellCoolDown)
		{
			SpellControl[x].coolDownAmount = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellCoolDown;
			SpellControl[x].coolDown = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellCoolDown;
		}
		if (SpellControl[x].castPenalty != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellCastingPenalty)
		{
			SpellControl[x].castPenalty = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellCastingPenalty;
		}
		if (SpellControl[x].casterControlType != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].spellType)
		{
			SpellControl[x].casterControlType = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].spellType;
		}
		if (SpellControl[x].casterIndicatorType != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].indicatorType)
		{
			SpellControl[x].casterIndicatorType = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].indicatorType;
		}
		if (SpellControl[x].casterArrowDirection != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].arrowDirection)
		{
			SpellControl[x].casterArrowDirection = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].arrowDirection;
		}
		if (SpellControl[x].casterCentreSpellTypeHeight != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].centreSpellTypeHeight)
		{
			SpellControl[x].casterCentreSpellTypeHeight = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].centreSpellTypeHeight;
		}
		if (SpellControl[x].casterActivateSound != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].activateSound)
		{
			SpellControl[x].casterActivateSound = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].activateSound;
		}
		if (SpellControl[x].casterSpawnEffect != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].spellEffectObject)
		{
			SpellControl[x].casterSpawnEffect = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].spellEffectObject;
		}
	}

	private void SpellButton(int x)
	{
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		Vector3 vector = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float x2 = vector.x;
		Vector3 position = SpellControl[x].spellButton.transform.position;
		if (!(x2 < position.x + 0.4f))
		{
			return;
		}
		Vector3 vector2 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float x3 = vector2.x;
		Vector3 position2 = SpellControl[x].spellButton.transform.position;
		if (!(x3 > position2.x - 0.4f))
		{
			return;
		}
		Vector3 vector3 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float y = vector3.y;
		Vector3 position3 = SpellControl[x].spellButton.transform.position;
		if (!(y < position3.y + 0.4f))
		{
			return;
		}
		Vector3 vector4 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float y2 = vector4.y;
		Vector3 position4 = SpellControl[x].spellButton.transform.position;
		if (y2 > position4.y - 0.4f)
		{
			PlayerPrefs.SetInt(characterID + "statSpellCasted" + x, PlayerPrefs.GetInt(characterID + "statSpellCasted" + x) + 1);
			switch (x)
			{
			case 0:
				ScriptsManager.dataScript.GameAnalytics("spell:red", 0f);
				break;
			case 1:
				ScriptsManager.dataScript.GameAnalytics("spell:blue", 0f);
				break;
			case 2:
				ScriptsManager.dataScript.GameAnalytics("spell:yellow", 0f);
				break;
			case 3:
				ScriptsManager.dataScript.GameAnalytics("spell:green", 0f);
				break;
			}
			scriptGameStatistic.scoreSpellPoints -= SpellControl[x].castPenalty;
			scriptGameStatistic.characterAnimationNumber = x + (x * 1 + 7);
			scriptGameStatistic.objectLevitating = 0;
			scriptGameStatistic.manaNumber -= SpellControl[x].manaCost;
			Transform transform = PoolManager.Pools["Spell Pool"].Spawn(spellCaster.transform, new Vector3(-3.4f, 1.25f, 0f), spellCaster.transform.rotation);
			transform.GetComponent<Spell_Caster_Control>().SpellActivate(1, x, SpellControl[x].casterControlType, SpellControl[x].casterIndicatorType, SpellControl[x].casterArrowDirection, SpellControl[x].casterCentreSpellTypeHeight, SpellControl[x].casterActivateSound, SpellControl[x].casterSpawnEffect);
			SpellControl[x].spellState = 2;
		}
	}

	private void SpellFunction(int x)
	{
		switch (spellState)
		{
		case -2:
			SpellControl[x].coolDownAmount = 0f;
			SpellControl[x].coolDownShade.CurrentAmount = 0f;
			SpellControl[x].spellStateToggle = -1;
			SpellControl[x].spellState = -1;
			break;
		case -1:
			SpellControl[x].coolDownAmount = 0f;
			SpellControl[x].coolDownShade.CurrentAmount = 0f;
			SpellControl[x].spellStateToggle = -1;
			SpellControl[x].spellState = 2;
			break;
		case 2:
			SpellControl[x].spellState = 3;
			break;
		}
		if (SpellControl[x].spellState < 2 && SpellControl[x].spellState > -10)
		{
			if (SpellControl[x].coolDownAmount >= (float)SpellControl[x].coolDown)
			{
				SpellUpdate(x);
				if (scriptGameStatistic.manaNumber >= SpellControl[x].manaCost)
				{
					SpellControl[x].spellState = 1;
				}
				else
				{
					SpellControl[x].spellState = 0;
				}
			}
			else
			{
				SpellControl[x].spellState = 2;
			}
		}
		switch (SpellControl[x].spellState)
		{
		case -10:
			if (SpellControl[x].spellStateToggle != SpellControl[x].spellState)
			{
				SpellControl[x].spellIcon.Play("blank");
				SpellControl[x].iconBackground.Play("spell_" + SpellControl[x].colorID + "_0");
				SpellControl[x].costIcon.Play("blank");
				SpellControl[x].spellStateToggle = SpellControl[x].spellState;
			}
			break;
		case 0:
			if (SpellControl[x].spellStateToggle != SpellControl[x].spellState)
			{
				SpellControl[x].spellIcon.Play("blank");
				SpellControl[x].iconBackground.Play("spell_" + SpellControl[x].colorID + "_0");
				if (SpellControl[x].manaCost > 0)
				{
					SpellControl[x].costIcon.Play("cost " + SpellControl[x].manaCost);
				}
				else
				{
					SpellControl[x].costIcon.Play("blank");
				}
				SpellControl[x].spellStateToggle = SpellControl[x].spellState;
			}
			if (SpellControl[x].highlight.active)
			{
				SpellControl[x].highlight.active = false;
			}
			break;
		case 1:
			if (SpellControl[x].spellStateToggle != SpellControl[x].spellState)
			{
				SpellControl[x].popEffect.activate = true;
				SpellControl[x].spellIcon.Play(string.Empty + characterID + "_" + SpellControl[x].colorID + "_" + SpellControl[x].spellNumber);
				SpellControl[x].iconBackground.Play("spell_" + SpellControl[x].colorID + "_1");
				if (SpellControl[x].manaCost > 0)
				{
					SpellControl[x].costIcon.Play("cost " + SpellControl[x].manaCost);
				}
				else
				{
					SpellControl[x].costIcon.Play("blank");
				}
				SpellControl[x].spellStateToggle = SpellControl[x].spellState;
			}
			if (!SpellControl[x].highlight.active)
			{
				SpellControl[x].highlight.active = true;
			}
			SpellButton(x);
			break;
		case 2:
			if (SpellControl[x].spellStateToggle != SpellControl[x].spellState)
			{
				SpellControl[x].coolDownAmount = 0f;
				SpellControl[x].coolDownShade.CurrentAmount = 0f;
				SpellControl[x].coolDownShade.FullAmount = SpellControl[x].coolDown;
				SpellControl[x].spellIcon.Play("blank");
				SpellControl[x].iconBackground.Play("spell_cd");
				if (SpellControl[x].manaCost > 0)
				{
					SpellControl[x].costIcon.Play("cost " + SpellControl[x].manaCost);
				}
				else
				{
					SpellControl[x].costIcon.Play("blank");
				}
				SpellControl[x].spellStateToggle = SpellControl[x].spellState;
			}
			if (SpellControl[x].manaCost != scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellManaCost)
			{
				if (scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellManaCost > 0)
				{
					SpellControl[x].costIcon.Play("cost " + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellManaCost);
				}
				else
				{
					SpellControl[x].costIcon.Play("blank");
				}
				SpellControl[x].manaCost = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[x].playerSpellManaCost;
			}
			if (SpellControl[x].highlight.active)
			{
				SpellControl[x].highlight.active = false;
			}
			if (spellState == 1 || spellState == 3 || spellState == 5 || scriptGameLogic.gameState == 4)
			{
				SpellControl[x].iconBackground.Play("spell_" + SpellControl[x].colorID + "_0");
				SpellControl[x].coolDownShade.CurrentAmount = 0f;
				SpellControl[x].coolDownAmount = SpellControl[x].coolDown;
				SpellControl[x].spellState = -1;
			}
			else if (SpellControl[x].coolDownAmount < (float)SpellControl[x].coolDown)
			{
				SpellControl[x].coolDownAmount += Time.fixedDeltaTime;
				SpellControl[x].coolDownShade.CurrentAmount = SpellControl[x].coolDownAmount;
			}
			else if (SpellControl[x].coolDownAmount >= (float)SpellControl[x].coolDown)
			{
				SpellControl[x].iconBackground.Play("spell_" + SpellControl[x].colorID + "_0");
				SpellControl[x].coolDownShade.CurrentAmount = 0f;
				SpellControl[x].coolDownAmount = SpellControl[x].coolDown;
				SpellControl[x].spellState = -1;
			}
			break;
		case 3:
			if (SpellControl[x].spellStateToggle != SpellControl[x].spellState)
			{
				if (SpellControl[x].coolDownAmount < (float)SpellControl[x].coolDown)
				{
					SpellControl[x].coolDownAmount = 0f;
					SpellControl[x].coolDownShade.CurrentAmount = 0f;
				}
				SpellControl[x].spellIcon.Play("blank");
				SpellControl[x].iconBackground.Play("spell_ds");
				if (SpellControl[x].manaCost > 0)
				{
					SpellControl[x].costIcon.Play("cost " + SpellControl[x].manaCost);
				}
				else
				{
					SpellControl[x].costIcon.Play("blank");
				}
				SpellControl[x].spellStateToggle = SpellControl[x].spellState;
			}
			if (SpellControl[x].highlight.active)
			{
				SpellControl[x].highlight.active = false;
			}
			if (spellState != -1)
			{
				SpellControl[x].spellState = -10;
			}
			break;
		case 4:
			if (SpellControl[x].spellStateToggle != SpellControl[x].spellState)
			{
				if (SpellControl[x].coolDownAmount < (float)SpellControl[x].coolDown)
				{
					SpellControl[x].coolDownAmount = 0f;
					SpellControl[x].coolDownShade.CurrentAmount = 0f;
				}
				SpellControl[x].spellIcon.Play("blank");
				SpellControl[x].iconBackground.Play("spell_oc");
				if (SpellControl[x].manaCost > 0)
				{
					SpellControl[x].costIcon.Play("cost " + SpellControl[x].manaCost);
				}
				else
				{
					SpellControl[x].costIcon.Play("blank");
				}
				SpellControl[x].spellStateToggle = SpellControl[x].spellState;
			}
			if (SpellControl[x].highlight.active)
			{
				SpellControl[x].highlight.active = false;
			}
			break;
		}
	}
}
