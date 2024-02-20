using System;
using UnityEngine;

public class Unit_Attributes : MonoBehaviour
{
	[Serializable]
	public class offense
	{
		public int unitOffenseAction;

		public int defendPlusArmorPoint;

		public int defendPlusAnchorPoint;

		public int attackAccuracyPrecision;

		public int attackCriticalPrecision;

		public int attackManaCost;

		public int attackHealthCost;

		public GameObject attackSpawnObject;

		public Transform attackPosition;

		public float baseAttackRange = 1f;

		public float baseAttackRangeRatio = 0.1f;

		public float attackRange = 1f;

		public float rangeDistance;

		public float attackStartDelay;

		public float attackDelay;

		public float attackEndDelay;

		public int alignment;

		public int projectileType;

		public int pureEffect;

		public int effectType;

		public int effectClass;

		public int effectSubID;

		public int hpAttributeToggle;

		public int hpAttributeAmount;

		public int hpOverTimeAttributeToggle;

		public int hpOverTimeAttributeAmount;

		public int hpOverTimeAttributeNumber;

		public float hpOverTimeAttributeDelay;

		public int hpOverTimeAttributeEffectClass;

		public int hpOverTimeAttributeEffectNumber;

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

	public GameObject healthIndicatorHUD;

	public Effect_Property_Display effectTextDisplay;

	private Transform INST_effectTextDisplay;

	public GameObject retreatDrop;

	public int retreatDropTier = 1;

	public string unitGroupID;

	public string unitClassID;

	public string unitNumberID;

	public int state;

	public int unitAlignment;

	public int unitMagicClass;

	public int unitTier;

	public int unitState;

	public int unitOffenseNumber;

	public int unitOffenseAction;

	public int unitMovementType;

	public int unitStatisticWeightClass = 1;

	public float unitDestinationPosition;

	public float unitDefaultHeight;

	public float unitDuration;

	public int unitAltitudeType;

	public float unitAltitudeAirMotionSpeed;

	public float unitAltitudeAirHeightThreshold;

	public float unitAltitudeAirDisableDropSpeed;

	public float unitAltitudeAirDisableDropThreshold;

	public int healthPoint = 1;

	public int healthRegenPoint = 1;

	public int damagePoint = 1;

	public float movementSpeedPoint = 1f;

	public float maxMovementSpeedPoint = 8f;

	public int attackSpeedPoint = 1;

	public int maxAttackSpeedPoint = 20;

	public int armorPoint;

	public int manaPoint = 1;

	public int manaRegenPoint = 1;

	public int anchorPoint = 1;

	public int criticalPoint = 1;

	public int accuracyPoint = 10;

	public int evasionPoint = 1;

	public float movementSpeedVelocity;

	public int effectHexable = 1;

	public float GrowthWaveHP;

	public float GrowthLevelHP;

	public float GrowthStageHP;

	public float GrowthWaveMP;

	public float GrowthLevelMP;

	public float GrowthStageMP;

	public float GrowthWaveDMG;

	public float GrowthLevelDMG;

	public float GrowthStageDMG;

	public float GrowthWaveAS;

	public float GrowthLevelAS;

	public float GrowthStageAS;

	public float GrowthWaveMS;

	public float GrowthLevelMS;

	public float GrowthStageMS;

	public float GrowthWaveAP;

	public float GrowthLevelAP;

	public float GrowthStageAP;

	public float GrowthWaveANP;

	public float GrowthLevelANP;

	public float GrowthStageANP;

	public float GrowthWaveCRP;

	public float GrowthLevelCRP;

	public float GrowthStageCRP;

	public float GrowthWaveACP;

	public float GrowthLevelACP;

	public float GrowthStageACP;

	public float GrowthWaveEVP;

	public float GrowthLevelEVP;

	public float GrowthStageEVP;

	public int[] effectTypeDefense = new int[10];

	public int[] effectClassDefense = new int[30];

	public offense[] Offense;

	public GameObject[] retreatEffect = new GameObject[6];

	public int currentDamagePoint;

	public float currentMovementSpeedPoint;

	public int currentAttackSpeedPoint;

	public int currentArmorPoint;

	public int currentManaRegenPoint;

	public int currentAnchorPoint;

	public int currentCriticalPoint;

	public int currentAccuracyPoint;

	public int currentEvasionPoint;

	public int plusDamagePoint;

	public int plusMovementSpeedPoint;

	public int plusAttackSpeedPoint;

	public int plusArmorPoint;

	public int plusManaRegenPoint;

	public int plusAnchorPoint;

	public int plusCriticalPoint;

	public int plusAccuracyPoint;

	public int plusEvasionPoint;

	public int plusUnitStateArmorPoint;

	public int plusUnitStateAnchorPoint;

	public int plusStaticDamagePoint;

	public int plusStaticMovementSpeedPoint;

	public int plusStaticAttackSpeedPoint;

	public int plusStaticArmorPoint;

	public int plusStaticManaRegenPoint;

	public int plusStaticAnchorPoint;

	public int plusStaticCriticalPoint;

	public int plusStaticAccuracyPoint;

	public int plusStaticEvasionPoint;

	public int healthValue;

	public int healthRegenValue;

	public int damageValue;

	public float movementSpeedValue;

	public float attackSpeedDelay;

	public float damageMultiplier;

	public int manaValue;

	public int manaRegenValue;

	public float knockResistanceValue;

	public float criticalValue;

	public float accuracyValue;

	public float evasionValue;

	public float movementSpeedVelocityValue;

	public float unitStatisticWeightValue;

	public float statisticAltered;

	public int statisticAlteredMRP;

	public int statisticAlteredDMG;

	public int statisticAlteredAS;

	public float statisticAlteredMS;

	public int statisticAlteredAP;

	public int statisticAlteredANP;

	public int statisticAlteredCRP;

	public int statisticAlteredACP;

	public int statisticAlteredEVP;

	private int RANDOM_healthValue;

	private float RANDOM_movementSpeedValue;

	private float PERCENT_plusMovementSpeedValue;

	private int MODIFIED_accuracyPoint;

	private Unit_Control scriptUnitControl;

	private Game_Logic scriptGameLogic;

	private Statistic_Logic scriptStatisticLogic;

	private int GROWTH_stageNumber;

	private int GROWTH_levelNumber;

	private Transform myTransform;

	private Transform INST_healthIndicatorHUD;

	private float TIMER_unitDuration;

	private int GROWTH_hp;

	private int GROWTH_mp;

	private int GROWTH_dmg;

	private float GROWTH_ms;

	private int GROWTH_as;

	private int GROWTH_ap;

	private int GROWTH_anp;

	private int GROWTH_crp;

	private int GROWTH_acp;

	private int GROWTH_evp;

	private int SLPLUS_HP;

	private int SLPLUS_HRP;

	private int SLPLUS_MP;

	private int SLPLUS_MRP;

	private int SLPLUS_DMG;

	private int SLPLUS_AS;

	private float SLPLUS_MS;

	private int SLPLUS_AP;

	private int SLPLUS_ANP;

	private int SLPLUS_CRP;

	private int SLPLUS_ACP;

	private int SLPLUS_EVP;

	private int TOGGLE_plusStaticMRP;

	private int TOGGLE_plusStaticDMG;

	private int TOGGLE_plusStaticAS;

	private int TOGGLE_plusStaticMS;

	private int TOGGLE_plusStaticAP;

	private int TOGGLE_plusStaticANP;

	private int TOGGLE_plusStaticCRP;

	private int TOGGLE_plusStaticACP;

	private int TOGGLE_plusStaticEVP;

	private int SLPLUS_HPEFFECT;

	private int TOGGLE_statisticAttributeUpdate;

	private float SLPLUSD_MS;

	private int SLUAPLUS_HP;

	private int SLUAPLUS_HRP;

	private int SLUAPLUS_MP;

	private int SLUAPLUS_MRP;

	private int SLUAPLUS_DMG;

	private int SLUAPLUS_AS;

	private float SLUAPLUS_MS;

	private int SLUAPLUS_AP;

	private int SLUAPLUS_ANP;

	private int SLUAPLUS_CRP;

	private int SLUAPLUS_ACP;

	private int SLUAPLUS_EVP;

	private string UNITCONTROL_ID;

	private int waveNumber;

	public int enableRetreatDrop;

	public int enableRetreatEffect;

	private int TOGGLE_retreatDrop;

	private Transform INST_retreatDrop;

	private float AMOUNT_retreatDrop;

	private int TOGGLE_retreatEffect;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		scriptGameLogic = GameScriptsManager.gameLogicScript;
		scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		if (unitTier == 0 && unitAlignment == 1)
		{
			if (healthPoint > 20)
			{
				healthPoint = 20;
			}
			healthRegenPoint = 0;
		}
		scriptUnitControl = GetComponent<Unit_Control>();
		AttributeSetup();
		StatisticSetup();
	}

	private void HUDSetup()
	{
		if (healthIndicatorHUD != null && INST_healthIndicatorHUD == null)
		{
			INST_healthIndicatorHUD = PoolManager.Pools["HUD Pool"].Spawn(healthIndicatorHUD.transform, myTransform.position, healthIndicatorHUD.transform.rotation);
			INST_healthIndicatorHUD.GetComponent<Unit_Health_Display>().scriptUnitControl = scriptUnitControl;
		}
	}

	private void OnDespawned()
	{
		if (INST_healthIndicatorHUD != null && INST_healthIndicatorHUD.gameObject.active)
		{
			PoolManager.Pools["HUD Pool"].Despawn(INST_healthIndicatorHUD);
			INST_healthIndicatorHUD = null;
		}
	}

	private void OnSpawned()
	{
		if (unitDuration > 0f)
		{
			TIMER_unitDuration = Time.time + unitDuration;
		}
		INST_healthIndicatorHUD = null;
		AttributePlusReset();
		AttributeSetup();
		StatisticSetup();
	}

	private void AttributePlusReset()
	{
		currentDamagePoint = 0;
		currentMovementSpeedPoint = 0f;
		currentAttackSpeedPoint = 0;
		currentArmorPoint = 0;
		currentManaRegenPoint = 0;
		currentAnchorPoint = 0;
		currentCriticalPoint = 0;
		currentAccuracyPoint = 0;
		currentEvasionPoint = 0;
		plusDamagePoint = 0;
		plusMovementSpeedPoint = 0;
		plusAttackSpeedPoint = 0;
		plusArmorPoint = 0;
		plusManaRegenPoint = 0;
		plusAnchorPoint = 0;
		plusCriticalPoint = 0;
		plusAccuracyPoint = 0;
		plusEvasionPoint = 0;
		plusUnitStateArmorPoint = 0;
		plusUnitStateAnchorPoint = 0;
		plusStaticDamagePoint = 0;
		plusStaticMovementSpeedPoint = 0;
		plusStaticAttackSpeedPoint = 0;
		plusStaticArmorPoint = 0;
		plusStaticManaRegenPoint = 0;
		plusStaticAnchorPoint = 0;
		plusStaticCriticalPoint = 0;
		plusStaticAccuracyPoint = 0;
		plusStaticEvasionPoint = 0;
	}

	private void StatisticSetup()
	{
		if (unitStatisticWeightClass > 3)
		{
			unitStatisticWeightClass = 3;
		}
		else if (unitStatisticWeightClass < -3)
		{
			unitStatisticWeightClass = -3;
		}
		switch (unitStatisticWeightClass)
		{
		case -3:
			unitStatisticWeightValue = 0.001f;
			break;
		case -2:
			unitStatisticWeightValue = 0.005f;
			break;
		case -1:
			unitStatisticWeightValue = 0.01f;
			break;
		case 0:
			unitStatisticWeightValue = 0.05f;
			break;
		case 1:
			unitStatisticWeightValue = 0.1f;
			break;
		case 2:
			unitStatisticWeightValue = 0.2f;
			break;
		case 3:
			unitStatisticWeightValue = 0.4f;
			break;
		}
	}

	private void AttributeSetup()
	{
		if (retreatDrop != null)
		{
			enableRetreatDrop = 1;
		}
		if (retreatEffect.Length > 0)
		{
			enableRetreatEffect = 1;
		}
		RANDOM_healthValue = UnityEngine.Random.Range(-2, 2);
		RANDOM_movementSpeedValue = UnityEngine.Random.Range(-0.025f, 0.075f);
		currentDamagePoint = damagePoint;
		currentMovementSpeedPoint = movementSpeedPoint;
		currentAttackSpeedPoint = attackSpeedPoint;
		currentArmorPoint = armorPoint;
		currentManaRegenPoint = manaRegenPoint;
		currentAnchorPoint = anchorPoint;
		currentCriticalPoint = criticalPoint;
		currentAccuracyPoint = accuracyPoint;
		currentEvasionPoint = evasionPoint;
		if (scriptGameLogic != null)
		{
			GROWTH_hp = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveHP + (float)scriptGameLogic.gameLevel * GrowthLevelHP + (float)scriptGameLogic.gameStage * GrowthStageHP);
			GROWTH_mp = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveMP + (float)scriptGameLogic.gameLevel * GrowthLevelMP + (float)scriptGameLogic.gameStage * GrowthStageMP);
			GROWTH_dmg = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveDMG + (float)scriptGameLogic.gameLevel * GrowthLevelDMG + (float)scriptGameLogic.gameStage * GrowthStageDMG);
			GROWTH_ms = (float)scriptGameLogic.gameWavesComplete * GrowthWaveMS + (float)scriptGameLogic.gameLevel * GrowthLevelMS + (float)scriptGameLogic.gameStage * GrowthStageMS;
			GROWTH_as = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveAS + (float)scriptGameLogic.gameLevel * GrowthLevelAS + (float)scriptGameLogic.gameStage * GrowthStageAS);
			GROWTH_ap = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveAP + (float)scriptGameLogic.gameLevel * GrowthLevelAP + (float)scriptGameLogic.gameStage * GrowthStageAP);
			GROWTH_anp = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveANP + (float)scriptGameLogic.gameLevel * GrowthLevelANP + (float)scriptGameLogic.gameStage * GrowthStageANP);
			GROWTH_crp = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveCRP + (float)scriptGameLogic.gameLevel * GrowthLevelCRP + (float)scriptGameLogic.gameStage * GrowthStageCRP);
			GROWTH_acp = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveACP + (float)scriptGameLogic.gameLevel * GrowthLevelACP + (float)scriptGameLogic.gameStage * GrowthStageACP);
			GROWTH_evp = Mathf.RoundToInt((float)scriptGameLogic.gameWavesComplete * GrowthWaveEVP + (float)scriptGameLogic.gameLevel * GrowthLevelEVP + (float)scriptGameLogic.gameStage * GrowthStageEVP);
		}
		SLUAPLUS_HP = 0;
		SLUAPLUS_HRP = 0;
		SLUAPLUS_MP = 0;
		SLUAPLUS_MRP = 0;
		SLUAPLUS_DMG = 0;
		SLUAPLUS_AS = 0;
		SLUAPLUS_MS = 0f;
		SLUAPLUS_AP = 0;
		SLUAPLUS_ANP = 0;
		SLUAPLUS_CRP = 0;
		SLUAPLUS_ACP = 0;
		SLUAPLUS_EVP = 0;
		SLPLUS_HP = 0;
		SLPLUS_HRP = 0;
		SLPLUS_MP = 0;
		SLPLUS_MRP = 0;
		SLPLUS_DMG = 0;
		SLPLUS_AS = 0;
		SLPLUS_MS = 0f;
		SLPLUS_AP = 0;
		SLPLUS_ANP = 0;
		SLPLUS_CRP = 0;
		SLPLUS_ACP = 0;
		SLPLUS_EVP = 0;
		TOGGLE_statisticAttributeUpdate = -1;
		for (int i = 0; i < Offense.Length; i++)
		{
			Offense[i].attackRange = UnityEngine.Random.Range(Offense[i].baseAttackRange - Offense[i].baseAttackRangeRatio, Offense[i].baseAttackRange + Offense[i].baseAttackRangeRatio);
		}
	}

	private void AttributeUpdate()
	{
		statisticAltered = (float)SLPLUS_HP * 0.1f + (float)SLPLUS_HRP * 0.1f + (float)SLPLUS_MP * 0.1f + ((float)(plusManaRegenPoint + plusStaticManaRegenPoint) + (float)SLPLUS_MRP * 0.1f) + (float)plusDamagePoint + (float)plusStaticDamagePoint + (float)SLPLUS_DMG + (float)plusAttackSpeedPoint + (float)plusStaticAttackSpeedPoint + (float)SLPLUS_AS + (float)plusMovementSpeedPoint + (float)plusStaticMovementSpeedPoint + SLPLUS_MS + (float)plusAnchorPoint + (float)plusStaticAnchorPoint + (float)SLPLUS_ANP + (float)plusCriticalPoint + (float)plusStaticCriticalPoint + (float)SLPLUS_CRP + (float)plusAccuracyPoint + (float)plusStaticAccuracyPoint + (float)SLPLUS_ACP + (float)plusEvasionPoint + (float)plusStaticEvasionPoint + (float)SLPLUS_EVP;
		statisticAlteredMRP = plusManaRegenPoint + plusStaticManaRegenPoint;
		statisticAlteredDMG = plusDamagePoint + plusStaticDamagePoint;
		statisticAlteredAS = plusAttackSpeedPoint + plusStaticAttackSpeedPoint;
		statisticAlteredMS = plusMovementSpeedPoint + plusStaticMovementSpeedPoint;
		statisticAlteredAP = plusArmorPoint + plusStaticArmorPoint + SLPLUS_AP;
		statisticAlteredANP = plusAnchorPoint + plusStaticAnchorPoint;
		statisticAlteredCRP = plusCriticalPoint + plusStaticCriticalPoint;
		statisticAlteredACP = plusAccuracyPoint + plusStaticAccuracyPoint;
		statisticAlteredEVP = plusEvasionPoint + plusStaticEvasionPoint;
		healthRegenValue = healthRegenPoint + SLPLUS_HRP;
		currentDamagePoint = damagePoint + plusDamagePoint + plusStaticDamagePoint + GROWTH_dmg + SLPLUS_DMG;
		currentMovementSpeedPoint = movementSpeedPoint * 1.5f + GROWTH_ms + SLPLUS_MS + SLPLUSD_MS;
		if (attackSpeedPoint + plusAttackSpeedPoint + plusStaticAttackSpeedPoint + GROWTH_as + SLPLUS_AS <= maxAttackSpeedPoint)
		{
			currentAttackSpeedPoint = attackSpeedPoint + plusAttackSpeedPoint + plusStaticAttackSpeedPoint + GROWTH_as + SLPLUS_AS;
		}
		else if (attackSpeedPoint + plusAttackSpeedPoint + plusStaticAttackSpeedPoint + GROWTH_as + SLPLUS_AS > maxAttackSpeedPoint)
		{
			currentAttackSpeedPoint = maxAttackSpeedPoint;
		}
		currentArmorPoint = armorPoint + plusArmorPoint + plusStaticArmorPoint + plusUnitStateArmorPoint + GROWTH_ap + SLPLUS_AP;
		currentAnchorPoint = anchorPoint + plusAnchorPoint + plusStaticAnchorPoint + plusUnitStateAnchorPoint + GROWTH_anp + SLPLUS_ANP;
		currentManaRegenPoint = manaRegenPoint + plusManaRegenPoint + plusStaticManaRegenPoint + SLPLUS_MRP;
		currentCriticalPoint = criticalPoint + plusCriticalPoint + plusStaticCriticalPoint + GROWTH_crp + SLPLUS_CRP;
		currentAccuracyPoint = accuracyPoint + plusAccuracyPoint + plusStaticAccuracyPoint + GROWTH_acp + SLPLUS_ACP;
		currentEvasionPoint = evasionPoint + plusEvasionPoint + plusStaticEvasionPoint + GROWTH_evp + SLPLUS_EVP;
	}

	private void StatisticAttributeUpdate()
	{
		SLUAPLUS_HP = 0;
		SLUAPLUS_HRP = 0;
		SLUAPLUS_MP = 0;
		SLUAPLUS_MRP = 0;
		SLUAPLUS_DMG = 0;
		SLUAPLUS_AS = 0;
		SLUAPLUS_MS = 0f;
		SLUAPLUS_AP = 0;
		SLUAPLUS_ANP = 0;
		SLUAPLUS_CRP = 0;
		SLUAPLUS_ACP = 0;
		SLUAPLUS_EVP = 0;
		switch (unitAlignment)
		{
		case 0:
			switch (unitTier)
			{
			case -1:
				UNITCONTROL_ID = "GUARD";
				break;
			case 0:
				UNITCONTROL_ID = "SUMMON";
				break;
			}
			break;
		case 1:
			UNITCONTROL_ID = "INTRUDER";
			break;
		}
		for (int i = 0; i < scriptStatisticLogic.UnitClassAttribute.Length; i++)
		{
			if (scriptStatisticLogic.UnitClassAttribute[i].unitClassID == UNITCONTROL_ID || scriptStatisticLogic.UnitClassAttribute[i].unitClassID == unitGroupID || scriptStatisticLogic.UnitClassAttribute[i].unitClassID == unitClassID)
			{
				SLUAPLUS_HP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusHP;
				SLUAPLUS_HRP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusHRP;
				SLUAPLUS_MP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusMP;
				SLUAPLUS_MRP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusMRP;
				SLUAPLUS_DMG += scriptStatisticLogic.UnitClassAttribute[i].unitPlusDMG;
				SLUAPLUS_AS += scriptStatisticLogic.UnitClassAttribute[i].unitPlusAS;
				SLUAPLUS_MS += scriptStatisticLogic.UnitClassAttribute[i].unitPlusMS;
				SLUAPLUS_AP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusAP;
				SLUAPLUS_ANP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusANP;
				SLUAPLUS_CRP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusCRP;
				SLUAPLUS_ACP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusACP;
				SLUAPLUS_EVP += scriptStatisticLogic.UnitClassAttribute[i].unitPlusEVP;
			}
		}
		if (SLPLUS_HP != SLUAPLUS_HP)
		{
			SLPLUS_HPEFFECT = SLUAPLUS_HP - SLPLUS_HP;
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_HP - SLPLUS_HP > 0)
				{
					InGameStatisticDisplay(0, "health");
					scriptUnitControl.AttributeEffectHP(2, SLPLUS_HPEFFECT, 0);
				}
				else if (SLUAPLUS_HP - SLPLUS_HP < 0)
				{
					InGameStatisticDisplay(1, "health");
				}
			}
			SLPLUS_HP = SLUAPLUS_HP;
		}
		if (SLPLUS_HRP != SLUAPLUS_HRP)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_HRP - SLPLUS_HRP > 0)
				{
					InGameStatisticDisplay(0, "regen");
				}
				else if (SLUAPLUS_HRP - SLPLUS_HRP < 0)
				{
					InGameStatisticDisplay(1, "regen");
				}
			}
			SLPLUS_HRP = SLUAPLUS_HRP;
		}
		if (SLPLUS_MP != SLUAPLUS_MP)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_MP - SLPLUS_MP > 0)
				{
					InGameStatisticDisplay(0, "mana");
				}
				else if (SLUAPLUS_MP - SLPLUS_MP < 0)
				{
					InGameStatisticDisplay(1, "mana");
				}
			}
			SLPLUS_MP = SLUAPLUS_MP;
		}
		if (SLPLUS_MRP != SLUAPLUS_MRP)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_MRP - SLPLUS_MRP > 0)
				{
					InGameStatisticDisplay(0, "regen");
				}
				else if (SLUAPLUS_MRP - SLPLUS_MRP < 0)
				{
					InGameStatisticDisplay(1, "regen");
				}
			}
			SLPLUS_MRP = SLUAPLUS_MRP;
		}
		if (SLPLUS_DMG != SLUAPLUS_DMG)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_DMG - SLPLUS_DMG > 0)
				{
					InGameStatisticDisplay(0, "damage");
				}
				else if (SLUAPLUS_DMG - SLPLUS_DMG < 0)
				{
					InGameStatisticDisplay(1, "damage");
				}
			}
			SLPLUS_DMG = SLUAPLUS_DMG;
		}
		if (SLPLUS_AS != SLUAPLUS_AS)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_AS - SLPLUS_AS > 0)
				{
					InGameStatisticDisplay(0, "attack");
				}
				else if (SLUAPLUS_AS - SLPLUS_AS < 0)
				{
					InGameStatisticDisplay(1, "attack");
				}
			}
			SLPLUS_AS = SLUAPLUS_AS;
		}
		if (SLPLUS_MS != SLUAPLUS_MS)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_MS - SLPLUS_MS > 0f)
				{
					InGameStatisticDisplay(0, "speed");
				}
				else if (SLUAPLUS_MS - SLPLUS_MS < 0f)
				{
					InGameStatisticDisplay(3, "slowed");
				}
			}
			SLPLUS_MS = SLUAPLUS_MS;
		}
		if (SLPLUS_AP != SLUAPLUS_AP)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_AP - SLPLUS_AP > 0)
				{
					InGameStatisticDisplay(0, "armor");
				}
				else if (SLUAPLUS_AP - SLPLUS_AP < 0)
				{
					InGameStatisticDisplay(1, "armor");
				}
			}
			SLPLUS_AP = SLUAPLUS_AP;
		}
		if (SLPLUS_ANP != SLUAPLUS_ANP)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_ANP - SLPLUS_ANP > 0)
				{
					InGameStatisticDisplay(0, "anchor");
				}
				else if (SLUAPLUS_ANP - SLPLUS_ANP < 0)
				{
					InGameStatisticDisplay(1, "anchor");
				}
			}
			SLPLUS_ANP = SLUAPLUS_ANP;
		}
		if (SLPLUS_CRP != SLUAPLUS_CRP)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_CRP - SLPLUS_CRP > 0)
				{
					InGameStatisticDisplay(0, "critical");
				}
				else if (SLUAPLUS_CRP - SLPLUS_CRP < 0)
				{
					InGameStatisticDisplay(1, "critical");
				}
			}
			SLPLUS_CRP = SLUAPLUS_CRP;
		}
		if (SLPLUS_ACP != SLUAPLUS_ACP)
		{
			if (effectTextDisplay != null)
			{
				if (SLUAPLUS_ACP - SLPLUS_ACP > 0)
				{
					InGameStatisticDisplay(0, "accuracy");
				}
				else if (SLUAPLUS_ACP - SLPLUS_ACP < 0)
				{
					InGameStatisticDisplay(1, "accuracy");
				}
			}
			SLPLUS_ACP = SLUAPLUS_ACP;
		}
		if (SLPLUS_EVP == SLUAPLUS_EVP)
		{
			return;
		}
		if (effectTextDisplay != null)
		{
			if (SLUAPLUS_EVP - SLPLUS_EVP > 0)
			{
				InGameStatisticDisplay(0, "evasion");
			}
			else if (SLUAPLUS_EVP - SLPLUS_EVP < 0)
			{
				InGameStatisticDisplay(1, "evasion");
			}
		}
		SLPLUS_EVP = SLUAPLUS_EVP;
	}

	private void InGameStatisticDisplay(int AttributeStatus, string AttributeName)
	{
		INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectTextDisplay.transform, myTransform.position, effectTextDisplay.transform.rotation);
		switch (AttributeStatus)
		{
		case 0:
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.5f, 1f, 1f, 1f), AttributeName + "+", 2.5f, 0.1f, 0.01f, 0.3f, 0f);
			break;
		case 1:
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.8f, 1f, 1f, 1f), AttributeName + "-", 2.5f, 0.1f, 0.01f, -0.2f, 0f);
			break;
		case 2:
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.5f, 1f, 1f, 1f), AttributeName, 2.5f, 0.1f, 0.01f, 0.3f, 0f);
			break;
		case 3:
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.8f, 1f, 1f, 1f), AttributeName, 2.5f, 0.1f, 0.01f, -0.2f, 0f);
			break;
		}
	}

	private void HealthAttribute()
	{
		if (healthPoint < 0)
		{
			healthValue = 0;
		}
		else
		{
			switch (unitAlignment)
			{
			case 0:
				if (unitTier == -1)
				{
					healthValue = healthPoint + GROWTH_hp + SLPLUS_HP;
				}
				else
				{
					healthValue = healthPoint + GROWTH_hp + SLPLUS_HP + RANDOM_healthValue;
				}
				break;
			case 1:
				if (scriptGameLogic.gameMode == 2)
				{
					if (unitTier == 1)
					{
						healthValue = 30 + scriptGameLogic.gameLevel + healthPoint;
					}
					else if (unitTier == 2)
					{
						healthValue = healthPoint + GROWTH_hp + SLPLUS_HP + RANDOM_healthValue;
					}
					else if (healthPoint + GROWTH_hp + SLPLUS_HP + RANDOM_healthValue < 30)
					{
						healthValue = healthPoint + GROWTH_hp + SLPLUS_HP + RANDOM_healthValue;
					}
					else
					{
						healthValue = 30;
					}
				}
				else if (unitTier == 1)
				{
					healthValue = healthPoint + GROWTH_hp + SLPLUS_HP + RANDOM_healthValue;
				}
				else if (unitTier == 2)
				{
					healthValue = healthPoint + GROWTH_hp + SLPLUS_HP + RANDOM_healthValue;
				}
				else if (healthPoint + GROWTH_hp + SLPLUS_HP + RANDOM_healthValue < 30)
				{
					healthValue = healthPoint + GROWTH_hp + SLPLUS_HP + RANDOM_healthValue;
				}
				else
				{
					healthValue = 30;
				}
				break;
			}
		}
		if (waveNumber != scriptGameLogic.gameWaveNumber && scriptGameLogic.gameWaveNumber != 0)
		{
			if (scriptUnitControl.attributeHealthValue < healthValue && healthRegenValue > 0)
			{
				scriptUnitControl.AttributeEffectHP(2, healthRegenValue, 0);
			}
			waveNumber = scriptGameLogic.gameWaveNumber;
		}
	}

	private void DamageAttribute()
	{
		if (currentDamagePoint + plusDamagePoint < 0)
		{
			damageValue = 0;
		}
		else
		{
			damageValue = currentDamagePoint + plusDamagePoint;
		}
	}

	private void MovementSpeedAttribute()
	{
		if (movementSpeedPoint != 0f)
		{
			if (currentMovementSpeedPoint < 0f)
			{
				movementSpeedValue = 0.05f + RANDOM_movementSpeedValue * PERCENT_plusMovementSpeedValue;
			}
			else if (currentMovementSpeedPoint > 0f)
			{
				if (currentMovementSpeedPoint > 5f && movementSpeedPoint <= 5f && scriptGameLogic.gameMode != 2)
				{
					movementSpeedValue = (0.5f + RANDOM_movementSpeedValue) * PERCENT_plusMovementSpeedValue;
				}
				else if (currentMovementSpeedPoint < maxMovementSpeedPoint)
				{
					movementSpeedValue = (currentMovementSpeedPoint * 0.1f + RANDOM_movementSpeedValue) * PERCENT_plusMovementSpeedValue;
				}
				else if (currentMovementSpeedPoint >= maxMovementSpeedPoint)
				{
					movementSpeedValue = (maxMovementSpeedPoint * 0.1f + RANDOM_movementSpeedValue) * PERCENT_plusMovementSpeedValue;
				}
			}
			if (plusMovementSpeedPoint + plusStaticMovementSpeedPoint > 10)
			{
				PERCENT_plusMovementSpeedValue = 3f;
			}
			else if (plusMovementSpeedPoint + plusStaticMovementSpeedPoint < -10)
			{
				PERCENT_plusMovementSpeedValue = 0f;
			}
			else
			{
				switch (plusMovementSpeedPoint + plusStaticMovementSpeedPoint)
				{
				case -10:
					PERCENT_plusMovementSpeedValue = 0f;
					break;
				case -9:
					PERCENT_plusMovementSpeedValue = 0.1f;
					break;
				case -8:
					PERCENT_plusMovementSpeedValue = 0.2f;
					break;
				case -7:
					PERCENT_plusMovementSpeedValue = 0.3f;
					break;
				case -6:
					PERCENT_plusMovementSpeedValue = 0.4f;
					break;
				case -5:
					PERCENT_plusMovementSpeedValue = 0.5f;
					break;
				case -4:
					PERCENT_plusMovementSpeedValue = 0.6f;
					break;
				case -3:
					PERCENT_plusMovementSpeedValue = 0.7f;
					break;
				case -2:
					PERCENT_plusMovementSpeedValue = 0.8f;
					break;
				case -1:
					PERCENT_plusMovementSpeedValue = 0.9f;
					break;
				case 0:
					PERCENT_plusMovementSpeedValue = 1f;
					break;
				case 1:
					PERCENT_plusMovementSpeedValue = 1.2f;
					break;
				case 2:
					PERCENT_plusMovementSpeedValue = 1.4f;
					break;
				case 3:
					PERCENT_plusMovementSpeedValue = 1.6f;
					break;
				case 4:
					PERCENT_plusMovementSpeedValue = 1.8f;
					break;
				case 5:
					PERCENT_plusMovementSpeedValue = 2f;
					break;
				case 6:
					PERCENT_plusMovementSpeedValue = 2.2f;
					break;
				case 7:
					PERCENT_plusMovementSpeedValue = 2.4f;
					break;
				case 8:
					PERCENT_plusMovementSpeedValue = 2.6f;
					break;
				case 9:
					PERCENT_plusMovementSpeedValue = 2.8f;
					break;
				case 10:
					PERCENT_plusMovementSpeedValue = 3f;
					break;
				case 11:
					PERCENT_plusMovementSpeedValue = 3.2f;
					break;
				case 12:
					PERCENT_plusMovementSpeedValue = 3.4f;
					break;
				case 13:
					PERCENT_plusMovementSpeedValue = 3.6f;
					break;
				case 14:
					PERCENT_plusMovementSpeedValue = 3.8f;
					break;
				case 15:
					PERCENT_plusMovementSpeedValue = 4f;
					break;
				case 16:
					PERCENT_plusMovementSpeedValue = 4.2f;
					break;
				case 17:
					PERCENT_plusMovementSpeedValue = 4.4f;
					break;
				case 18:
					PERCENT_plusMovementSpeedValue = 4.6f;
					break;
				case 19:
					PERCENT_plusMovementSpeedValue = 4.8f;
					break;
				case 20:
					PERCENT_plusMovementSpeedValue = 5f;
					break;
				}
			}
			if (movementSpeedVelocity < -2f)
			{
				movementSpeedVelocityValue = 0.01f;
			}
			else
			{
				movementSpeedVelocityValue = 2f + movementSpeedVelocity;
			}
		}
		else
		{
			movementSpeedValue = 0f;
		}
	}

	private void AttackSpeedAttribute()
	{
		if (currentAttackSpeedPoint > 20)
		{
			attackSpeedDelay = 0.1f;
			return;
		}
		if (currentAttackSpeedPoint < 0)
		{
			attackSpeedDelay = 2.2f;
			return;
		}
		switch (currentAttackSpeedPoint)
		{
		case 0:
			attackSpeedDelay = 3f;
			break;
		case 1:
			attackSpeedDelay = 2.85f;
			break;
		case 2:
			attackSpeedDelay = 2.7f;
			break;
		case 3:
			attackSpeedDelay = 2.55f;
			break;
		case 4:
			attackSpeedDelay = 2.4f;
			break;
		case 5:
			attackSpeedDelay = 2.25f;
			break;
		case 6:
			attackSpeedDelay = 2.1f;
			break;
		case 7:
			attackSpeedDelay = 1.95f;
			break;
		case 8:
			attackSpeedDelay = 1.8f;
			break;
		case 9:
			attackSpeedDelay = 1.65f;
			break;
		case 10:
			attackSpeedDelay = 1.5f;
			break;
		case 11:
			attackSpeedDelay = 1.35f;
			break;
		case 12:
			attackSpeedDelay = 1.2f;
			break;
		case 13:
			attackSpeedDelay = 1.05f;
			break;
		case 14:
			attackSpeedDelay = 0.9f;
			break;
		case 15:
			attackSpeedDelay = 0.75f;
			break;
		case 16:
			attackSpeedDelay = 0.6f;
			break;
		case 17:
			attackSpeedDelay = 0.45f;
			break;
		case 18:
			attackSpeedDelay = 0.3f;
			break;
		case 19:
			attackSpeedDelay = 0.15f;
			break;
		case 20:
			attackSpeedDelay = 0.1f;
			break;
		}
	}

	private void ArmorAttribute()
	{
		if (currentArmorPoint > 10)
		{
			damageMultiplier = -10f;
			return;
		}
		if (currentArmorPoint < -10)
		{
			damageMultiplier = 10f;
			return;
		}
		switch (currentArmorPoint)
		{
		case -10:
			damageMultiplier = 10f;
			break;
		case -9:
			damageMultiplier = 9f;
			break;
		case -8:
			damageMultiplier = 8f;
			break;
		case -7:
			damageMultiplier = 7f;
			break;
		case -6:
			damageMultiplier = 6f;
			break;
		case -5:
			damageMultiplier = 5f;
			break;
		case -4:
			damageMultiplier = 4f;
			break;
		case -3:
			damageMultiplier = 3f;
			break;
		case -2:
			damageMultiplier = 2f;
			break;
		case -1:
			damageMultiplier = 1f;
			break;
		case 0:
			damageMultiplier = 0f;
			break;
		case 1:
			damageMultiplier = -1f;
			break;
		case 2:
			damageMultiplier = -2f;
			break;
		case 3:
			damageMultiplier = -3f;
			break;
		case 4:
			damageMultiplier = -4f;
			break;
		case 5:
			damageMultiplier = -5f;
			break;
		case 6:
			damageMultiplier = -6f;
			break;
		case 7:
			damageMultiplier = -7f;
			break;
		case 8:
			damageMultiplier = -8f;
			break;
		case 9:
			damageMultiplier = -9f;
			break;
		case 10:
			damageMultiplier = -10f;
			break;
		}
	}

	private void ManaAttribute()
	{
		if (manaPoint < 0)
		{
			manaValue = 0;
		}
		else
		{
			manaValue = manaPoint * 10 + GROWTH_mp;
		}
	}

	private void ManaRegenAttribute()
	{
		if (currentManaRegenPoint > 20)
		{
			manaRegenValue = 20;
			return;
		}
		if (currentManaRegenPoint < 0)
		{
			manaRegenValue = 0;
			return;
		}
		switch (currentManaRegenPoint)
		{
		case 0:
			manaRegenValue = 0;
			break;
		case 1:
			manaRegenValue = 1;
			break;
		case 2:
			manaRegenValue = 2;
			break;
		case 3:
			manaRegenValue = 3;
			break;
		case 4:
			manaRegenValue = 4;
			break;
		case 5:
			manaRegenValue = 5;
			break;
		case 6:
			manaRegenValue = 6;
			break;
		case 7:
			manaRegenValue = 7;
			break;
		case 8:
			manaRegenValue = 8;
			break;
		case 9:
			manaRegenValue = 9;
			break;
		case 10:
			manaRegenValue = 10;
			break;
		case 11:
			manaRegenValue = 11;
			break;
		case 12:
			manaRegenValue = 12;
			break;
		case 13:
			manaRegenValue = 13;
			break;
		case 14:
			manaRegenValue = 14;
			break;
		case 15:
			manaRegenValue = 15;
			break;
		case 16:
			manaRegenValue = 16;
			break;
		case 17:
			manaRegenValue = 17;
			break;
		case 18:
			manaRegenValue = 18;
			break;
		case 19:
			manaRegenValue = 19;
			break;
		case 20:
			manaRegenValue = 20;
			break;
		}
	}

	private void CriticalAttribute()
	{
		if (currentCriticalPoint + Offense[unitOffenseNumber].attackCriticalPrecision > 20)
		{
			criticalValue = 48f;
			return;
		}
		if (currentCriticalPoint + Offense[unitOffenseNumber].attackCriticalPrecision < 0)
		{
			criticalValue = 0f;
			return;
		}
		switch (currentCriticalPoint + Offense[unitOffenseNumber].attackCriticalPrecision)
		{
		case 0:
			criticalValue = 0f;
			break;
		case 1:
			criticalValue = 1.5f;
			break;
		case 2:
			criticalValue = 3f;
			break;
		case 3:
			criticalValue = 4.5f;
			break;
		case 4:
			criticalValue = 6f;
			break;
		case 5:
			criticalValue = 7.5f;
			break;
		case 6:
			criticalValue = 9f;
			break;
		case 7:
			criticalValue = 10.5f;
			break;
		case 8:
			criticalValue = 12f;
			break;
		case 9:
			criticalValue = 13.5f;
			break;
		case 10:
			criticalValue = 15f;
			break;
		case 11:
			criticalValue = 16.5f;
			break;
		case 12:
			criticalValue = 18f;
			break;
		case 13:
			criticalValue = 19.5f;
			break;
		case 14:
			criticalValue = 21f;
			break;
		case 15:
			criticalValue = 23f;
			break;
		case 16:
			criticalValue = 26f;
			break;
		case 17:
			criticalValue = 30f;
			break;
		case 18:
			criticalValue = 35f;
			break;
		case 19:
			criticalValue = 41f;
			break;
		case 20:
			criticalValue = 48f;
			break;
		}
	}

	private void AccuracyAttribute()
	{
		if (unitOffenseNumber >= 0)
		{
			MODIFIED_accuracyPoint = currentAccuracyPoint + Offense[unitOffenseNumber].attackAccuracyPrecision;
		}
		else
		{
			MODIFIED_accuracyPoint = currentAccuracyPoint;
		}
		if (MODIFIED_accuracyPoint > 10)
		{
			accuracyValue = 100f;
			return;
		}
		if (MODIFIED_accuracyPoint < -10)
		{
			accuracyValue = 0f;
			return;
		}
		switch (MODIFIED_accuracyPoint)
		{
		case -10:
			accuracyValue = 0f;
			break;
		case -9:
			accuracyValue = 8f;
			break;
		case -8:
			accuracyValue = 16f;
			break;
		case -7:
			accuracyValue = 24f;
			break;
		case -6:
			accuracyValue = 32f;
			break;
		case -5:
			accuracyValue = 40f;
			break;
		case -4:
			accuracyValue = 48f;
			break;
		case -3:
			accuracyValue = 56f;
			break;
		case -2:
			accuracyValue = 64f;
			break;
		case -1:
			accuracyValue = 72f;
			break;
		case 0:
			accuracyValue = 80f;
			break;
		case 1:
			accuracyValue = 82f;
			break;
		case 2:
			accuracyValue = 84f;
			break;
		case 3:
			accuracyValue = 86f;
			break;
		case 4:
			accuracyValue = 88f;
			break;
		case 5:
			accuracyValue = 90f;
			break;
		case 6:
			accuracyValue = 92f;
			break;
		case 7:
			accuracyValue = 94f;
			break;
		case 8:
			accuracyValue = 96f;
			break;
		case 9:
			accuracyValue = 98f;
			break;
		case 10:
			accuracyValue = 100f;
			break;
		}
	}

	private void EvasionAttribute()
	{
		if (currentEvasionPoint > 20 && currentEvasionPoint < 100)
		{
			evasionValue = 30f;
			return;
		}
		if (currentEvasionPoint < 0)
		{
			evasionValue = 0f;
			return;
		}
		if (currentEvasionPoint >= 100)
		{
			evasionValue = 100f;
			return;
		}
		switch (currentEvasionPoint)
		{
		case 0:
			evasionValue = 0f;
			break;
		case 1:
			evasionValue = 1.5f;
			break;
		case 2:
			evasionValue = 3f;
			break;
		case 3:
			evasionValue = 4.5f;
			break;
		case 4:
			evasionValue = 6f;
			break;
		case 5:
			evasionValue = 7.5f;
			break;
		case 6:
			evasionValue = 9f;
			break;
		case 7:
			evasionValue = 10.5f;
			break;
		case 8:
			evasionValue = 12f;
			break;
		case 9:
			evasionValue = 13.5f;
			break;
		case 10:
			evasionValue = 15f;
			break;
		case 11:
			evasionValue = 16.5f;
			break;
		case 12:
			evasionValue = 18f;
			break;
		case 13:
			evasionValue = 19.5f;
			break;
		case 14:
			evasionValue = 21f;
			break;
		case 15:
			evasionValue = 22.5f;
			break;
		case 16:
			evasionValue = 24f;
			break;
		case 17:
			evasionValue = 25.5f;
			break;
		case 18:
			evasionValue = 27f;
			break;
		case 19:
			evasionValue = 28.5f;
			break;
		case 20:
			evasionValue = 30f;
			break;
		}
	}

	private void AnchorAttribute()
	{
		if (currentAnchorPoint > 10)
		{
			knockResistanceValue = 0f;
			return;
		}
		if (currentAnchorPoint < -10)
		{
			knockResistanceValue = 4f;
			return;
		}
		switch (currentAnchorPoint)
		{
		case -10:
			knockResistanceValue = 3.2f;
			break;
		case -9:
			knockResistanceValue = 3f;
			break;
		case -8:
			knockResistanceValue = 2.8f;
			break;
		case -7:
			knockResistanceValue = 2.6f;
			break;
		case -6:
			knockResistanceValue = 2.4f;
			break;
		case -5:
			knockResistanceValue = 2.2f;
			break;
		case -4:
			knockResistanceValue = 2f;
			break;
		case -3:
			knockResistanceValue = 1.8f;
			break;
		case -2:
			knockResistanceValue = 1.6f;
			break;
		case -1:
			knockResistanceValue = 1.4f;
			break;
		case 0:
			knockResistanceValue = 1.2f;
			break;
		case 1:
			knockResistanceValue = 1f;
			break;
		case 2:
			knockResistanceValue = 0.9f;
			break;
		case 3:
			knockResistanceValue = 0.8f;
			break;
		case 4:
			knockResistanceValue = 0.7f;
			break;
		case 5:
			knockResistanceValue = 0.6f;
			break;
		case 6:
			knockResistanceValue = 0.5f;
			break;
		case 7:
			knockResistanceValue = 0.4f;
			break;
		case 8:
			knockResistanceValue = 0.3f;
			break;
		case 9:
			knockResistanceValue = 0.2f;
			break;
		case 10:
			knockResistanceValue = 0.1f;
			break;
		}
	}

	private void LateUpdate()
	{
		if (TOGGLE_statisticAttributeUpdate != scriptStatisticLogic.inGameAttributeUpdate)
		{
			StatisticAttributeUpdate();
			TOGGLE_statisticAttributeUpdate = scriptStatisticLogic.inGameAttributeUpdate;
		}
		if (unitDuration > 0f && Time.time >= TIMER_unitDuration && scriptUnitControl.attributeHealthValue > 0)
		{
			scriptUnitControl.attributeHealthValue = 0;
		}
		HUDSetup();
		AttributeUpdate();
		UnitAttackActionUpdate();
		HealthAttribute();
		DamageAttribute();
		MovementSpeedAttribute();
		AttackSpeedAttribute();
		ArmorAttribute();
		AnchorAttribute();
		ManaAttribute();
		ManaRegenAttribute();
		CriticalAttribute();
		AccuracyAttribute();
		EvasionAttribute();
		RetreatSpawnFunction();
	}

	private void RetreatSpawnFunction()
	{
		switch (retreatDropTier)
		{
		case 0:
			AMOUNT_retreatDrop = 0f;
			break;
		case 1:
			AMOUNT_retreatDrop = 20f;
			break;
		case 2:
			AMOUNT_retreatDrop = 40f;
			break;
		case 3:
			AMOUNT_retreatDrop = 60f;
			break;
		case 4:
			AMOUNT_retreatDrop = 80f;
			break;
		case 5:
			AMOUNT_retreatDrop = 100f;
			break;
		}
		if (scriptUnitControl.state == 2)
		{
			if (TOGGLE_retreatDrop == 0 && retreatDrop != null && enableRetreatDrop == 1)
			{
				INST_retreatDrop = PoolManager.Pools["Pickup Pool"].Spawn(retreatDrop.transform, myTransform.position, retreatDrop.transform.rotation);
				INST_retreatDrop.GetComponent<Random_Instantiate_Script>().DropSetup(1, AMOUNT_retreatDrop);
				TOGGLE_retreatDrop = 1;
			}
			if (TOGGLE_retreatEffect == 0 && retreatEffect.Length > 0 && enableRetreatEffect == 1)
			{
				for (int i = 0; i < retreatEffect.Length; i++)
				{
					PoolManager.Pools["Effect Pool"].Spawn(retreatEffect[i].transform, myTransform.position, retreatEffect[i].transform.rotation);
				}
				TOGGLE_retreatEffect = 1;
			}
		}
		else
		{
			if (TOGGLE_retreatDrop != 0)
			{
				TOGGLE_retreatDrop = 0;
			}
			if (TOGGLE_retreatEffect != 0)
			{
				TOGGLE_retreatEffect = 0;
			}
		}
	}

	private void UnitAttackActionUpdate()
	{
		if (unitOffenseNumber >= 0 && unitOffenseNumber <= Offense.Length && unitOffenseAction != Offense[unitOffenseNumber].unitOffenseAction)
		{
			unitOffenseAction = Offense[unitOffenseNumber].unitOffenseAction;
		}
	}

	public void TriggerTransfer(_Trigger scriptTrigger, int criticalMultiplier)
	{
		scriptTrigger.alignment = unitAlignment;
		scriptTrigger.alignmentType = Offense[unitOffenseNumber].projectileType;
		scriptTrigger.triggerType = 0;
		scriptTrigger.triggerClass = unitMagicClass;
		scriptTrigger.pureEffect = Offense[unitOffenseNumber].pureEffect;
		scriptTrigger.effectType = Offense[unitOffenseNumber].effectType;
		scriptTrigger.effectClass = Offense[unitOffenseNumber].effectClass;
		scriptTrigger.hpAttributeCriticalMultiplier = criticalMultiplier;
		scriptTrigger.hpAttributeToggle = Offense[unitOffenseNumber].hpAttributeToggle;
		if (Offense[unitOffenseNumber].hpAttributeToggle == 1)
		{
			scriptTrigger.hpAttributeAmount = Offense[unitOffenseNumber].hpAttributeAmount + damageValue;
		}
		else
		{
			scriptTrigger.hpAttributeAmount = Offense[unitOffenseNumber].hpAttributeAmount;
		}
		scriptTrigger.hpOverTimeAttributeToggle = Offense[unitOffenseNumber].hpOverTimeAttributeToggle;
		scriptTrigger.hpOverTimeAttributeAmount = Offense[unitOffenseNumber].hpOverTimeAttributeAmount;
		scriptTrigger.hpOverTimeAttributeNumber = Offense[unitOffenseNumber].hpOverTimeAttributeNumber;
		scriptTrigger.hpOverTimeAttributeDelay = Offense[unitOffenseNumber].hpOverTimeAttributeDelay;
		scriptTrigger.hpOverTimeAttributeEffectClass = Offense[unitOffenseNumber].hpOverTimeAttributeEffectClass;
		scriptTrigger.hpOverTimeAttributeEffectNumber = Offense[unitOffenseNumber].hpOverTimeAttributeEffectNumber;
		scriptTrigger.mpAttributeToggle = Offense[unitOffenseNumber].mpAttributeToggle;
		scriptTrigger.mpAttributeAmount = Offense[unitOffenseNumber].mpAttributeAmount;
		scriptTrigger.colorEffectToggle = Offense[unitOffenseNumber].colorEffectToggle;
		scriptTrigger.colorEffectColor = Offense[unitOffenseNumber].colorEffectColor;
		scriptTrigger.colorEffectDuration = Offense[unitOffenseNumber].colorEffectDuration;
		scriptTrigger.disableEffectToggle = Offense[unitOffenseNumber].disableEffectToggle;
		scriptTrigger.disableEffectDuration = Offense[unitOffenseNumber].disableEffectDuration;
		scriptTrigger.riseEffectToggle = Offense[unitOffenseNumber].riseEffectToggle;
		scriptTrigger.riseEffectDistance = Offense[unitOffenseNumber].riseEffectDistance;
		scriptTrigger.riseEffectDuration = Offense[unitOffenseNumber].riseEffectDuration;
		scriptTrigger.riseEffectDamping = Offense[unitOffenseNumber].riseEffectDamping;
		scriptTrigger.knockEffectToggle = Offense[unitOffenseNumber].knockEffectToggle;
		scriptTrigger.knockEffectDistance = Offense[unitOffenseNumber].knockEffectDistance;
		scriptTrigger.knockEffectDuration = Offense[unitOffenseNumber].knockEffectDuration;
		scriptTrigger.knockEffectDamping = Offense[unitOffenseNumber].knockEffectDamping;
		scriptTrigger.dmgAttributeToggle = Offense[unitOffenseNumber].dmgAttributeToggle;
		scriptTrigger.dmgAttributeAmount = Offense[unitOffenseNumber].dmgAttributeAmount;
		scriptTrigger.dmgAttributeDuration = Offense[unitOffenseNumber].dmgAttributeDuration;
		scriptTrigger.msAttributeToggle = Offense[unitOffenseNumber].msAttributeToggle;
		scriptTrigger.msAttributeAmount = Offense[unitOffenseNumber].msAttributeAmount;
		scriptTrigger.msAttributeDuration = Offense[unitOffenseNumber].msAttributeDuration;
		scriptTrigger.asAttributeToggle = Offense[unitOffenseNumber].asAttributeToggle;
		scriptTrigger.asAttributeAmount = Offense[unitOffenseNumber].asAttributeAmount;
		scriptTrigger.asAttributeDuration = Offense[unitOffenseNumber].asAttributeDuration;
		scriptTrigger.apAttributeToggle = Offense[unitOffenseNumber].apAttributeToggle;
		scriptTrigger.apAttributeAmount = Offense[unitOffenseNumber].apAttributeAmount;
		scriptTrigger.apAttributeDuration = Offense[unitOffenseNumber].apAttributeDuration;
		scriptTrigger.anpAttributeToggle = Offense[unitOffenseNumber].anpAttributeToggle;
		scriptTrigger.anpAttributeAmount = Offense[unitOffenseNumber].anpAttributeAmount;
		scriptTrigger.anpAttributeDuration = Offense[unitOffenseNumber].anpAttributeDuration;
		scriptTrigger.mrpAttributeToggle = Offense[unitOffenseNumber].mrpAttributeToggle;
		scriptTrigger.mrpAttributeAmount = Offense[unitOffenseNumber].mrpAttributeAmount;
		scriptTrigger.mrpAttributeDuration = Offense[unitOffenseNumber].mrpAttributeDuration;
		scriptTrigger.crpAttributeToggle = Offense[unitOffenseNumber].crpAttributeToggle;
		scriptTrigger.crpAttributeAmount = Offense[unitOffenseNumber].crpAttributeAmount;
		scriptTrigger.crpAttributeDuration = Offense[unitOffenseNumber].crpAttributeDuration;
		scriptTrigger.acpAttributeToggle = Offense[unitOffenseNumber].acpAttributeAmount;
		scriptTrigger.acpAttributeAmount = Offense[unitOffenseNumber].acpAttributeAmount;
		scriptTrigger.acpAttributeDuration = Offense[unitOffenseNumber].acpAttributeDuration;
		scriptTrigger.evpAttributeToggle = Offense[unitOffenseNumber].evpAttributeToggle;
		scriptTrigger.evpAttributeAmount = Offense[unitOffenseNumber].evpAttributeAmount;
		scriptTrigger.evpAttributeDuration = Offense[unitOffenseNumber].evpAttributeDuration;
		scriptTrigger.effectClassID = Offense[unitOffenseNumber].effectClass;
		scriptTrigger.effectSubID = Offense[unitOffenseNumber].effectSubID;
	}
}
