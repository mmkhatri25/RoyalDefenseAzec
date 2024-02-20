using System;
using UnityEngine;

public class Statistic_Effect : MonoBehaviour
{
	[Serializable]
	public class guardEffect
	{
		public int guardEffectToggle;

		public float guardEffectDuration;

		public int guardEffectHP;

		public int guardEffectMP;

		public int guardEffectMRP;

		public int guardEffectAP;

		public int guardEffectANP;

		public int guardEffectMS;

		public int guardEffectAS;

		public int guardEffectCRP;

		public int guardEffectACP;

		public int guardEffectEVP;

		public int guardEffectToggleHPOT;

		public int guardEffectAmountHPOT;

		public int guardEffectNumberHPOT;

		public float guardEffectDelayHPOT;

		public int guardEffectIdHPOT;

		public int guardEffectSubIdHPOT;
	}

	[Serializable]
	public class playerSpellAttribute
	{
		public int playerSpellState = 1;

		public int playerSpellNumber;

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

		public int attributeSetNumber;

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

	public float statisticEffectDuration;

	public string despawnPoolName;

	private float TIMER_statisticEffectDuration;

	private Statistic_Logic scriptStatisticLogic;

	private Guard_Logic scriptGuardLogic;

	private Object_Logic scriptObjectLogic;

	private Game_Statistics scriptGameStatistic;

	private Spell_Logic scriptSpellLogic;

	public int gameEffectEnable;

	public int spellState;

	public int spellStateDuration;

	public int manaEffectAmount;

	public int manaEffectOverTime;

	public float manaEffectOverTimeDelay;

	public int manaEffectOverTimeDespawnActivate;

	private float TIMER_manaEffectOverTimeDelay;

	public int objectEffectEnable;

	public int objectState;

	public int guardEffectEnable;

	public guardEffect[] GuardEffect = new guardEffect[5];

	public int statisticEffectEnable;

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

	public effectClassAttribute[] EffectClassAttribute = new effectClassAttribute[30];

	public unitClassAttribute[] UnitClassAttribute;

	private void Start()
	{
		base.useGUILayout = false;
		scriptGuardLogic = GameScriptsManager.guardLogicScript;
		scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		scriptObjectLogic = ScriptsManager.objectLogicScript;
		scriptGameStatistic = GameScriptsManager.gameStatisticScript;
		scriptSpellLogic = GameScriptsManager.spellLogicScript;
	}

	private void OnSpawned()
	{
		if (statisticEffectDuration > 0f)
		{
			TIMER_statisticEffectDuration = Time.time + statisticEffectDuration;
		}
		if (gameEffectEnable > 0)
		{
			if (scriptGameStatistic == null || scriptSpellLogic == null)
			{
				scriptGameStatistic = GameScriptsManager.gameStatisticScript;
				scriptSpellLogic = GameScriptsManager.spellLogicScript;
			}
			scriptGameStatistic.manaRecoverAmount += manaEffectAmount;
			if (manaEffectOverTime != 0)
			{
				TIMER_manaEffectOverTimeDelay = Time.time + manaEffectOverTimeDelay;
			}
			scriptSpellLogic.spellState = spellState;
			scriptSpellLogic.spellStateDuration = spellStateDuration;
		}
		if (objectEffectEnable > 0)
		{
			if (scriptObjectLogic == null)
			{
				scriptObjectLogic = ScriptsManager.objectLogicScript;
			}
			scriptObjectLogic.objectState = objectState;
		}
		if (guardEffectEnable > 0)
		{
			if (scriptGuardLogic == null)
			{
				scriptGuardLogic = GameScriptsManager.guardLogicScript;
			}
			for (int i = 0; i < GuardEffect.Length; i++)
			{
				if (GuardEffect[i].guardEffectToggle > 0)
				{
					scriptGuardLogic.effectDuration = GuardEffect[i].guardEffectDuration;
					scriptGuardLogic.effectHP = GuardEffect[i].guardEffectHP;
					scriptGuardLogic.effectMP = GuardEffect[i].guardEffectMP;
					scriptGuardLogic.effectMRP = GuardEffect[i].guardEffectMRP;
					scriptGuardLogic.effectAP = GuardEffect[i].guardEffectAP;
					scriptGuardLogic.effectANP = GuardEffect[i].guardEffectANP;
					scriptGuardLogic.effectMS = GuardEffect[i].guardEffectMS;
					scriptGuardLogic.effectAS = GuardEffect[i].guardEffectAS;
					scriptGuardLogic.effectCRP = GuardEffect[i].guardEffectCRP;
					scriptGuardLogic.effectACP = GuardEffect[i].guardEffectACP;
					scriptGuardLogic.effectEVP = GuardEffect[i].guardEffectEVP;
					if (GuardEffect[i].guardEffectToggleHPOT > 0)
					{
						scriptGuardLogic.effectToggleHPOT = GuardEffect[i].guardEffectToggleHPOT;
						scriptGuardLogic.effectAmountHPOT = GuardEffect[i].guardEffectAmountHPOT;
						scriptGuardLogic.effectNumberHPOT = GuardEffect[i].guardEffectNumberHPOT;
						scriptGuardLogic.effectDelayHPOT = GuardEffect[i].guardEffectDelayHPOT;
						scriptGuardLogic.effectIdHPOT = GuardEffect[i].guardEffectIdHPOT;
						scriptGuardLogic.effectSubIdHPOT = GuardEffect[i].guardEffectSubIdHPOT;
					}
					scriptGuardLogic.effectToggle = GuardEffect[i].guardEffectToggle;
				}
			}
		}
		if (statisticEffectEnable <= 0)
		{
			return;
		}
		if (scriptStatisticLogic == null)
		{
			scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		}
		scriptStatisticLogic.InGameAttribute[1].playerGuardHealth += playerGuardHealth;
		scriptStatisticLogic.InGameAttribute[1].playerGuardHealthRegeneration += playerGuardHealthRegeneration;
		scriptStatisticLogic.InGameAttribute[1].playerMaximumObjectInput += playerMaximumObjectInput;
		scriptStatisticLogic.InGameAttribute[1].playerObjectControlManaCost += playerObjectControlManaCost;
		scriptStatisticLogic.InGameAttribute[1].playerMaxManaPoint += playerMaxManaPoint;
		scriptStatisticLogic.InGameAttribute[1].playerStartingManaPoint += playerStartingManaPoint;
		scriptStatisticLogic.InGameAttribute[1].playerManaRegenerate += playerManaRegenerate;
		scriptStatisticLogic.InGameAttribute[1].objectPlusDMG += objectPlusDMG;
		scriptStatisticLogic.InGameAttribute[1].objectPlusMS += objectPlusMS;
		scriptStatisticLogic.InGameAttribute[1].objectPlusKNK += objectPlusKNK;
		for (int j = 0; j < scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute.Length; j++)
		{
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].playerSpellNumber += PlayerSpellAttribute[j].playerSpellNumber;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].playerSpellManaCost += PlayerSpellAttribute[j].playerSpellManaCost;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].playerSpellCoolDown += PlayerSpellAttribute[j].playerSpellCoolDown;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].playerSpellCastingPenalty += PlayerSpellAttribute[j].playerSpellCastingPenalty;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].hpAttributeToggle += PlayerSpellAttribute[j].hpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].hpAttributeAmount += PlayerSpellAttribute[j].hpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].hpOverTimeAttributeToggle += PlayerSpellAttribute[j].hpOverTimeAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].hpOverTimeAttributeAmount += PlayerSpellAttribute[j].hpOverTimeAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].hpOverTimeAttributeNumber += PlayerSpellAttribute[j].hpOverTimeAttributeNumber;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].hpOverTimeAttributeDelay += PlayerSpellAttribute[j].hpOverTimeAttributeDelay;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].mpAttributeToggle += PlayerSpellAttribute[j].mpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].mpAttributeAmount += PlayerSpellAttribute[j].mpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].disableEffectToggle += PlayerSpellAttribute[j].disableEffectToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].disableEffectDuration += PlayerSpellAttribute[j].disableEffectDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].riseEffectToggle += PlayerSpellAttribute[j].riseEffectToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].riseEffectDistance += PlayerSpellAttribute[j].riseEffectDistance;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].riseEffectDuration += PlayerSpellAttribute[j].riseEffectDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].riseEffectDamping += PlayerSpellAttribute[j].riseEffectDamping;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].knockEffectToggle += PlayerSpellAttribute[j].knockEffectToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].knockEffectDistance += PlayerSpellAttribute[j].knockEffectDistance;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].knockEffectDuration += PlayerSpellAttribute[j].knockEffectDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].knockEffectDamping += PlayerSpellAttribute[j].knockEffectDamping;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].dmgAttributeToggle += PlayerSpellAttribute[j].dmgAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].dmgAttributeAmount += PlayerSpellAttribute[j].dmgAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].dmgAttributeDuration += PlayerSpellAttribute[j].dmgAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].msAttributeToggle += PlayerSpellAttribute[j].msAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].msAttributeAmount += PlayerSpellAttribute[j].msAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].msAttributeDuration += PlayerSpellAttribute[j].msAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].asAttributeToggle += PlayerSpellAttribute[j].asAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].asAttributeAmount += PlayerSpellAttribute[j].asAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].asAttributeDuration += PlayerSpellAttribute[j].asAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].apAttributeToggle += PlayerSpellAttribute[j].apAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].apAttributeAmount += PlayerSpellAttribute[j].apAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].apAttributeDuration += PlayerSpellAttribute[j].apAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].anpAttributeToggle += PlayerSpellAttribute[j].anpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].anpAttributeAmount += PlayerSpellAttribute[j].anpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].anpAttributeDuration += PlayerSpellAttribute[j].anpAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].mrpAttributeToggle += PlayerSpellAttribute[j].mrpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].mrpAttributeAmount += PlayerSpellAttribute[j].mrpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].mrpAttributeDuration += PlayerSpellAttribute[j].mrpAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].crpAttributeToggle += PlayerSpellAttribute[j].crpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].crpAttributeAmount += PlayerSpellAttribute[j].crpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].crpAttributeDuration += PlayerSpellAttribute[j].crpAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].acpAttributeToggle += PlayerSpellAttribute[j].acpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].acpAttributeAmount += PlayerSpellAttribute[j].acpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].acpAttributeDuration += PlayerSpellAttribute[j].acpAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].evpAttributeToggle += PlayerSpellAttribute[j].evpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].evpAttributeAmount += PlayerSpellAttribute[j].evpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[j].evpAttributeDuration += PlayerSpellAttribute[j].evpAttributeDuration;
		}
		for (int k = 0; k < EffectClassAttribute.Length; k++)
		{
			scriptStatisticLogic.EffectClassAttribute[k].manaCostAmount += EffectClassAttribute[k].manaCostAmount;
			scriptStatisticLogic.EffectClassAttribute[k].coolDownAmount += EffectClassAttribute[k].coolDownAmount;
			scriptStatisticLogic.EffectClassAttribute[k].hpAttributeAmount += EffectClassAttribute[k].hpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].hpOverTimeAttributeAmount += EffectClassAttribute[k].hpOverTimeAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].knockEffectDistance += EffectClassAttribute[k].knockEffectDistance;
			scriptStatisticLogic.EffectClassAttribute[k].disableEffectDuration += EffectClassAttribute[k].disableEffectDuration;
			scriptStatisticLogic.EffectClassAttribute[k].mpAttributeAmount += EffectClassAttribute[k].mpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].dmgAttributeAmount += EffectClassAttribute[k].dmgAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].msAttributeAmount += EffectClassAttribute[k].msAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].asAttributeAmount += EffectClassAttribute[k].asAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].anpAttributeAmount += EffectClassAttribute[k].anpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].crpAttributeAmount += EffectClassAttribute[k].crpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].acpAttributeAmount += EffectClassAttribute[k].acpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[k].evpAttributeAmount += EffectClassAttribute[k].evpAttributeAmount;
		}
		if (UnitClassAttribute.Length > 0)
		{
			for (int l = 0; l < UnitClassAttribute.Length; l++)
			{
				if (!(UnitClassAttribute[l].unitClassID != string.Empty))
				{
					continue;
				}
				for (int m = 0; m < scriptStatisticLogic.UnitClassAttribute.Length; m++)
				{
					if (scriptStatisticLogic.UnitClassAttribute[m].unitClassID == "empty")
					{
						scriptStatisticLogic.UnitClassAttribute[m].unitClassID = UnitClassAttribute[l].unitClassID;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusHP = UnitClassAttribute[l].unitPlusHP;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusHRP = UnitClassAttribute[l].unitPlusHRP;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusMP = UnitClassAttribute[l].unitPlusMP;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusMRP = UnitClassAttribute[l].unitPlusMRP;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusDMG = UnitClassAttribute[l].unitPlusDMG;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusAS = UnitClassAttribute[l].unitPlusAS;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusMS = UnitClassAttribute[l].unitPlusMS;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusAP = UnitClassAttribute[l].unitPlusAP;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusANP = UnitClassAttribute[l].unitPlusANP;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusCRP = UnitClassAttribute[l].unitPlusCRP;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusACP = UnitClassAttribute[l].unitPlusACP;
						scriptStatisticLogic.UnitClassAttribute[m].unitPlusEVP = UnitClassAttribute[l].unitPlusEVP;
						UnitClassAttribute[l].attributeSetNumber = m;
						m = scriptStatisticLogic.UnitClassAttribute.Length;
					}
				}
			}
		}
		scriptStatisticLogic.inGameAttributeUpdate++;
	}

	private void OnDespawned()
	{
		if (statisticEffectEnable <= 0 || !(scriptStatisticLogic != null))
		{
			return;
		}
		scriptStatisticLogic.InGameAttribute[1].playerGuardHealth -= playerGuardHealth;
		scriptStatisticLogic.InGameAttribute[1].playerGuardHealthRegeneration -= playerGuardHealthRegeneration;
		scriptStatisticLogic.InGameAttribute[1].playerMaximumObjectInput -= playerMaximumObjectInput;
		scriptStatisticLogic.InGameAttribute[1].playerObjectControlManaCost -= playerObjectControlManaCost;
		scriptStatisticLogic.InGameAttribute[1].playerMaxManaPoint -= playerMaxManaPoint;
		scriptStatisticLogic.InGameAttribute[1].playerStartingManaPoint -= playerStartingManaPoint;
		scriptStatisticLogic.InGameAttribute[1].playerManaRegenerate -= playerManaRegenerate;
		scriptStatisticLogic.InGameAttribute[1].objectPlusDMG -= objectPlusDMG;
		scriptStatisticLogic.InGameAttribute[1].objectPlusMS -= objectPlusMS;
		scriptStatisticLogic.InGameAttribute[1].objectPlusKNK -= objectPlusKNK;
		for (int i = 0; i < scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute.Length; i++)
		{
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].playerSpellNumber -= PlayerSpellAttribute[i].playerSpellNumber;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].playerSpellManaCost -= PlayerSpellAttribute[i].playerSpellManaCost;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].playerSpellCoolDown -= PlayerSpellAttribute[i].playerSpellCoolDown;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].playerSpellCastingPenalty -= PlayerSpellAttribute[i].playerSpellCastingPenalty;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].hpAttributeToggle -= PlayerSpellAttribute[i].hpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].hpAttributeAmount -= PlayerSpellAttribute[i].hpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeToggle -= PlayerSpellAttribute[i].hpOverTimeAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeAmount -= PlayerSpellAttribute[i].hpOverTimeAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeNumber -= PlayerSpellAttribute[i].hpOverTimeAttributeNumber;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].hpOverTimeAttributeDelay -= PlayerSpellAttribute[i].hpOverTimeAttributeDelay;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].mpAttributeToggle -= PlayerSpellAttribute[i].mpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].mpAttributeAmount -= PlayerSpellAttribute[i].mpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].disableEffectToggle -= PlayerSpellAttribute[i].disableEffectToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].disableEffectDuration -= PlayerSpellAttribute[i].disableEffectDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].riseEffectToggle -= PlayerSpellAttribute[i].riseEffectToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDistance -= PlayerSpellAttribute[i].riseEffectDistance;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDuration -= PlayerSpellAttribute[i].riseEffectDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].riseEffectDamping -= PlayerSpellAttribute[i].riseEffectDamping;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].knockEffectToggle -= PlayerSpellAttribute[i].knockEffectToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDistance -= PlayerSpellAttribute[i].knockEffectDistance;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDuration -= PlayerSpellAttribute[i].knockEffectDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].knockEffectDamping -= PlayerSpellAttribute[i].knockEffectDamping;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeToggle -= PlayerSpellAttribute[i].dmgAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeAmount -= PlayerSpellAttribute[i].dmgAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].dmgAttributeDuration -= PlayerSpellAttribute[i].dmgAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].msAttributeToggle -= PlayerSpellAttribute[i].msAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].msAttributeAmount -= PlayerSpellAttribute[i].msAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].msAttributeDuration -= PlayerSpellAttribute[i].msAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].asAttributeToggle -= PlayerSpellAttribute[i].asAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].asAttributeAmount -= PlayerSpellAttribute[i].asAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].asAttributeDuration -= PlayerSpellAttribute[i].asAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].apAttributeToggle -= PlayerSpellAttribute[i].apAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].apAttributeAmount -= PlayerSpellAttribute[i].apAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].apAttributeDuration -= PlayerSpellAttribute[i].apAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeToggle -= PlayerSpellAttribute[i].anpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeAmount -= PlayerSpellAttribute[i].anpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].anpAttributeDuration -= PlayerSpellAttribute[i].anpAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeToggle -= PlayerSpellAttribute[i].mrpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeAmount -= PlayerSpellAttribute[i].mrpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].mrpAttributeDuration -= PlayerSpellAttribute[i].mrpAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeToggle -= PlayerSpellAttribute[i].crpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeAmount -= PlayerSpellAttribute[i].crpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].crpAttributeDuration -= PlayerSpellAttribute[i].crpAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeToggle -= PlayerSpellAttribute[i].acpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeAmount -= PlayerSpellAttribute[i].acpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].acpAttributeDuration -= PlayerSpellAttribute[i].acpAttributeDuration;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeToggle -= PlayerSpellAttribute[i].evpAttributeToggle;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeAmount -= PlayerSpellAttribute[i].evpAttributeAmount;
			scriptStatisticLogic.InGameAttribute[1].PlayerSpellAttribute[i].evpAttributeDuration -= PlayerSpellAttribute[i].evpAttributeDuration;
		}
		for (int j = 0; j < EffectClassAttribute.Length; j++)
		{
			scriptStatisticLogic.EffectClassAttribute[j].manaCostAmount -= EffectClassAttribute[j].manaCostAmount;
			scriptStatisticLogic.EffectClassAttribute[j].coolDownAmount -= EffectClassAttribute[j].coolDownAmount;
			scriptStatisticLogic.EffectClassAttribute[j].hpAttributeAmount -= EffectClassAttribute[j].hpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].hpOverTimeAttributeAmount -= EffectClassAttribute[j].hpOverTimeAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].knockEffectDistance -= EffectClassAttribute[j].knockEffectDistance;
			scriptStatisticLogic.EffectClassAttribute[j].disableEffectDuration -= EffectClassAttribute[j].disableEffectDuration;
			scriptStatisticLogic.EffectClassAttribute[j].mpAttributeAmount -= EffectClassAttribute[j].mpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].dmgAttributeAmount -= EffectClassAttribute[j].dmgAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].msAttributeAmount -= EffectClassAttribute[j].msAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].asAttributeAmount -= EffectClassAttribute[j].asAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].anpAttributeAmount -= EffectClassAttribute[j].anpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].crpAttributeAmount -= EffectClassAttribute[j].crpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].acpAttributeAmount -= EffectClassAttribute[j].acpAttributeAmount;
			scriptStatisticLogic.EffectClassAttribute[j].evpAttributeAmount -= EffectClassAttribute[j].evpAttributeAmount;
		}
		if (UnitClassAttribute.Length > 0)
		{
			for (int k = 0; k < UnitClassAttribute.Length; k++)
			{
				if (UnitClassAttribute[k].unitClassID != string.Empty)
				{
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitClassID = "empty";
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusHP = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusHRP = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusMP = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusMRP = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusDMG = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusAS = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusMS = 0f;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusAP = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusANP = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusCRP = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusACP = 0;
					scriptStatisticLogic.UnitClassAttribute[UnitClassAttribute[k].attributeSetNumber].unitPlusEVP = 0;
				}
			}
		}
		scriptStatisticLogic.inGameAttributeUpdate++;
	}

	private void Update()
	{
		if (manaEffectOverTime != 0 && gameEffectEnable > 0 && Time.time >= TIMER_manaEffectOverTimeDelay)
		{
			if (manaEffectOverTimeDespawnActivate > 0)
			{
				if (manaEffectOverTime < 0)
				{
					if (scriptGameStatistic.manaNumber <= 0)
					{
						PoolManager.Pools[despawnPoolName].Despawn(base.transform);
					}
					else
					{
						scriptGameStatistic.manaRecoverAmount += manaEffectOverTime;
						TIMER_manaEffectOverTimeDelay = Time.time + manaEffectOverTimeDelay;
					}
				}
				else if (manaEffectOverTime > 0)
				{
					if (scriptGameStatistic.manaNumber >= scriptGameStatistic.manaMaximumLimit)
					{
						PoolManager.Pools[despawnPoolName].Despawn(base.transform);
					}
					else
					{
						scriptGameStatistic.manaRecoverAmount += manaEffectOverTime;
						TIMER_manaEffectOverTimeDelay = Time.time + manaEffectOverTimeDelay;
					}
				}
			}
			else
			{
				scriptGameStatistic.manaRecoverAmount += manaEffectOverTime;
				TIMER_manaEffectOverTimeDelay = Time.time + manaEffectOverTimeDelay;
			}
		}
		if (statisticEffectDuration > 0f && despawnPoolName != string.Empty)
		{
			if (Time.time >= TIMER_statisticEffectDuration)
			{
				PoolManager.Pools[despawnPoolName].Despawn(base.transform);
			}
		}
		else if (statisticEffectDuration == -1f && despawnPoolName != string.Empty)
		{
			PoolManager.Pools[despawnPoolName].Despawn(base.transform);
		}
	}
}
