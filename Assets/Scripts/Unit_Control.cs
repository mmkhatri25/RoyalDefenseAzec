using UnityEngine;

public class Unit_Control : MonoBehaviour
{
	public CharacterAnimationSet scriptCharacterAnimation;

	private Unit_Attributes scriptUnitAttribute;

	public int state;

	private int TOGGLE_state;

	public float unitDefaultAltitude;

	public int unitAlignment;

	public int unitAltitudeType;

	public int unitState;

	private int TOGGLE_unitState;

	public int unitDirection;

	private Transform myTransform;

	private Vector3 VECTOR_scriptCharacterAnimation;

	private Statistic_Logic scriptStatisticLogic;

	private int TOGGLE_waveTierBehaviour;

	private int TOGGLE_unitTier = -1;

	private Game_Statistics scriptGameStatistic;

	public GameObject unitDetector;

	private Transform INST_unitDetector;

	private Vector3 VECTOR_alignmentDetector;

	public int unitTier;

	public int attributeHealthMaximumValue = 10;

	public int attributeManaMaximumValue = 10;

	public int attributeHealthValue = 10;

	public int attributeManaValue = 10;

	public int attributeManaRegenValue;

	public float attributeMovementSpeed = 2f;

	private float BASE_attributeMovementSpeed;

	public float attributeMovementVelocity;

	public float attributeAttackSpeedDelay;

	public float attributeDamageMultiplier;

	public float attributeCriticalValue;

	public float attributeAccuracyValue;

	public float attributeEvasionValue;

	public float attributeKnockResistanceValue;

	private int attributeEffectHexable;

	private float SLPLUS_objectKNK;

	private int debugMode;

	private int TOGGLE_screenEffectDamagedEffect;

	private int unitEntranceBehaviourState;

	public int unitEntranceBehaviour;

	public float unitEntranceBehaviourAmountA;

	public float unitEntranceBehaviourAmountB;

	public float unitEntranceBehaviourAmountC;

	public float unitEntranceBehaviourAmountD;

	private int TOGGLE_unitEntranceBehaviour;

	private float RANDOM_unitEntranceBehaviour;

	public int unitAttackBehaviour;

	public float unitAttackBehaviourAmountA;

	public float unitAttackBehaviourAmountB;

	public float unitAttackBehaviourAmountC;

	public float unitAttackBehaviourAmountD;

	private int TOGGLE_unitAttackBehaviour;

	private int TOGGLE_attackAmount;

	private int unitDefensiveBehaviourState;

	public int unitDefensiveBehaviour;

	public float unitDefensiveBehaviourAmountA;

	public float unitDefensiveBehaviourAmountB;

	public float unitDefensiveBehaviourAmountC;

	public float unitDefensiveBehaviourAmountD;

	private int TOGGLE_healthValue;

	private int TOGGLE_defenseBehaviour;

	private int TOGGLE2_defenseBehaviour;

	private float AMOUNT_defenseBehaviour;

	private float POSITION_defenseBehaviour;

	private int unitUniqueBehaviourState;

	public int unitUniqueBehaviour;

	public float unitUniqueBehaviourAmountA;

	public float unitUniqueBehaviourAmountB;

	public float unitUniqueBehaviourAmountC;

	public float unitUniqueBehaviourAmountD;

	private int TOGGLE_unitUniqueBehaviour;

	private int TOGGLE2_unitUniqueBehaviour;

	private float TIMER_unitUniqueBehaviour;

	private float POSITION_unitUniqueBehaviour;

	public int unitRetreatBehaviour;

	public float unitRetreatBehaviourAmountA;

	public float unitRetreatBehaviourAmountB;

	public float unitRetreatBehaviourAmountC;

	public float unitRetreatBehaviourAmountD;

	private float RANDOM_riseSpeed;

	private int TOGGLE_unitRetreatBehaviour;

	private float RANDOM_unitRetreatBehaviour;

	private int TOGGLE_unitIdle;

	private float statisticWeightValue;

	private int AMOUNT_altitubeControl;

	private float VELOCITY_altitubeControl;

	private int unitGravityState;

	public int unitMovementType;

	private int TOGGLE_movementType;

	private int CONTROL_movementType;

	private float VELOCITY_attributeMovementSpeed;

	public float unitAltitudeAirMotionSpeed;

	public float unitAltitudeAirHeightThreshold;

	public float unitAltitudeAirDisableDropSpeed;

	public float unitAltitudeAirDisableDropThreshold;

	private int TOGGLE_airMotion;

	private int TOGGLE_airMotionState;

	private float TRANSFORM_airMotion;

	private float VELOCITY_airMotionDisableDropSpeed;

	private float VELOCITY_airMotionDisableDropRecoverySpeed = 0.5f;

	private float VELOCITY_airMotionDisableDropRecoveryRiseSpeed = 2f;

	private int airMotionState;

	public GameObject attackSpawnObject;

	public Transform attackPosition;

	public float attackStartDelay;

	public float attackDelay = 1f;

	public float attackEndDelay = 0.5f;

	public int attackManaCost;

	public int attackHealthCost;

	private Vector3 VECTOR_alignmentAttackSpawnPosition;

	private int TOGGLE_attack;

	private float TIMER_attackDelay;

	private float TIMER_attackEndDelay;

	private float ROLL_attributeAccuracyValue;

	private float ROLL_attributeCriticalValue;

	private Transform INST_attackTrigger;

	private int attackAmount;

	public int unitOffenseAction;

	public float attackRange = 1f;

	public float attackRangeDistance;

	private Vector3 VECTOR_rayPointAttack;

	private Vector3 VECTOR_rayPointAttackDistance;

	private int offenseDetectionState;

	private float TIMER_rayFPS;

	public int unitColorState;

	private Color COLOR_unitColorDamaged = Color.red;

	private Color COLOR_unitColorHeal = Color.green;

	private Color COLOR_unitColorMana = Color.cyan;

	private Color COLOR_unitColorDefault = Color.white;

	private float TIMER_unitColorState;

	private float TIMER_unitActionTaunt;

	private int TOGGLE_unitActionTaunt;

	private float TIMER_unitActionDash;

	private Vector3 VECTOR_unitActionDash;

	private float DAMPING_unitActionDash;

	private int TOGGLE_unitActionDash;

	private int AMOUNT_attributeManaRegenFunction;

	private int TOGGLE_attributeManaRegenFunction;

	private float TIMER_attributeManaRegenFunction;

	private Color COLOR_unitEffectColor;

	private int TOGGLE_unitEffectColor;

	private float TIMER_unitEffectColor;

	public GameObject effectPosition;

	public GameObject effectPropertyDisplay;

	private Transform INST_effectTextDisplay;

	private float SIZE_effectTextDisplay;

	private Color COLOR_effectTextDisplay;

	private float FADE_effectTextDisplay;

	private Transform INST_effectArmorState;

	private int TOGGLE_unitAttributeArmorPoint;

	private Transform INST_unitAttributeStatisticAltered;

	private float TOGGLE_unitAttributeStatisticAltered;

	private int DisableComboFunctionState;

	private int AMOUNT_disableCombo;

	private int TOGGLEAMOUNT_disableCombo;

	private int TOGGLE_disableCombo;

	private float TIMER_disableCombo;

	private int disableComboState;

	private int AMOUNT_attributeOverTimeEffectHP;

	private int NUMBER_attributeOverTimeEffectHP;

	private float DELAY_attributeOverTimeEffectHP;

	private float TIMER_attributeOverTimeEffectHP;

	private int TOGGLE_attributeOverTimeEffectHP;

	private int EFFECTCLASS_attributeOverTimeEffectHP;

	private int EFFECTNUMBER_attributeOverTimeEffectHP;

	private int TOGGLE_attributeOverTimeEffectCurrentHP;

	private int AMOUNT_attributeEffectHP;

	private int TOGGLE_attributeEffectHP;

	private int AMOUNT_attributeEffectMP;

	private int TOGGLE_attributeEffectMP;

	private int AMOUNT_attributeEffectDMG;

	private int TOGGLE_attributeEffectDMG;

	private float TIMER_attributeEffectDMG;

	private int AMOUNT_attributeEffectMS;

	private int TOGGLE_attributeEffectMS;

	private float TIMER_attributeEffectMS;

	private int AMOUNT_attributeEffectAS;

	private int TOGGLE_attributeEffectAS;

	private float TIMER_attributeEffectAS;

	private int AMOUNT_attributeEffectAP;

	private int TOGGLE_attributeEffectAP;

	private float TIMER_attributeEffectAP;

	private int AMOUNT_attributeEffectMRP;

	private int TOGGLE_attributeEffectMRP;

	private float TIMER_attributeEffectMRP;

	private int AMOUNT_attributeEffectCRP;

	private int TOGGLE_attributeEffectCRP;

	private float TIMER_attributeEffectCRP;

	private int AMOUNT_attributeEffectACP;

	private int TOGGLE_attributeEffectACP;

	private float TIMER_attributeEffectACP;

	private int AMOUNT_attributeEffectEVP;

	private int TOGGLE_attributeEffectEVP;

	private float TIMER_attributeEffectEVP;

	private int AMOUNT_attributeEffectANP;

	private int TOGGLE_attributeEffectANP;

	private float TIMER_attributeEffectANP;

	private int TOGGLE_positionLock;

	private float TIMER_unitEffectKnock;

	private Vector3 VECTOR_unitEffectKnock;

	private float DAMPING_unitEffectKnock;

	private int TOGGLE_unitEffectKnock;

	private float TIMER_unitEffectRise;

	private Vector3 VECTOR_unitEffectRise;

	private float DAMPING_unitEffectRise;

	private int TOGGLE_unitEffectRise;

	private int TOGGLE_unitHexEffect;

	private float TIMER_unitHexEffect;

	private int WEIGHT_unitHexEffect;

	private float WEIGHTVALUE_unitHexEffect;

	private float MOVEMENTSPEED_unitHexEffect;

	private Transform INST_effectStateDisable;

	private float TIMER_unitEffectDisable;

	private int TOGGLE_unitEffectDisable;

	private float TIMER_stunDurationRemain;

	private int TOGGLE_stunEffectScale;

	private int TOGGLE2_stunEffectScale;

	private float stageLength;

	private float POSITION_unitDestinationPosition;

	private int TOGGLE_unitDestinationPosition;

	private float BALANCE_attributeMovmentSpeed;

	private int TOGGLE_unitAlignment;

	private float RANDOMPLUS_unitDestinationPosition;

	private int TOGGLE_triggerType;

	private float TIMER_triggerDelay;

	private string ID_triggerName = "xxx";

	private _Trigger scriptTrigger;

	public GameObject effectHitDisplay;

	private Transform INST_effectHitDisplay;

	private float ROLL_evasionPercent;

	private float ROLL_criticalAccept;

	private int DAMAGE_setToggle;

	private int DAMAGE_setAmount;

	private int DAMAGE_bonusAmount;

	private int DAMAGE_pureEffect;

	private float OBJECTCHARGE_knockDistance;

	public int statusAttackCount;

	public int statusDamagedCount;

	public int statusDisabledCount;

	private void TestFunction()
	{
		int num = unitAlignment;
		if (num == 1 && UnityEngine.Input.GetKey(KeyCode.F10) && state == 1)
		{
			attributeHealthValue = 0;
		}
	}

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		scriptUnitAttribute = GetComponent<Unit_Attributes>();
		scriptGameStatistic = GameScriptsManager.gameStatisticScript;
		scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		VECTOR_scriptCharacterAnimation = scriptCharacterAnimation.transform.localPosition;
		unitDefaultAltitude = scriptUnitAttribute.unitDefaultHeight;
	}

	private void Start()
	{
		stageLength = GameScriptsManager.masterControlScript.stageLength;
		Vector3 localPosition = scriptCharacterAnimation.transform.localPosition;
		POSITION_defenseBehaviour = localPosition.z;
		debugMode = GameScriptsManager.masterControlScript.debugMode;
	}

	private void OnSpawned()
	{
		state = -1;
	}

	private void OnDespawned()
	{
		if (INST_effectArmorState != null)
		{
			PoolManager.Pools["HUD Pool"].Despawn(INST_effectArmorState);
			INST_effectArmorState = null;
		}
		if (INST_effectStateDisable != null)
		{
			PoolManager.Pools["HUD Pool"].Despawn(INST_effectStateDisable);
			INST_effectArmorState = null;
		}
		if (INST_unitAttributeStatisticAltered != null)
		{
			PoolManager.Pools["HUD Pool"].Despawn(INST_unitAttributeStatisticAltered);
			INST_effectArmorState = null;
		}
		UnitReset();
		INST_unitDetector = null;
	}

	private void UnitReset()
	{
		scriptCharacterAnimation.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
		Transform transform = scriptCharacterAnimation.transform;
		Vector3 localPosition = scriptCharacterAnimation.transform.localPosition;
		transform.localPosition = new Vector3(localPosition.x, VECTOR_scriptCharacterAnimation.y, VECTOR_scriptCharacterAnimation.z);
		scriptCharacterAnimation.spriteColor = Color.white;
		scriptTrigger = null;
		TOGGLE_unitRetreatBehaviour = -2;
	}

	private void WaveTierBehaviour()
	{
		switch (unitAlignment)
		{
		case 0:
			switch (state)
			{
			case 0:
				break;
			case 3:
				break;
			case 1:
			{
				int num;
				if (TOGGLE_unitTier != state)
				{
					num = unitTier;
					if (num != 0 && num == 1)
					{
						scriptGameStatistic.gameStateWaveTierTeamA = 2;
					}
					scriptGameStatistic.gameStatusUnitSpawnNumberTeamA++;
					TOGGLE_unitTier = state;
				}
				if (scriptGameStatistic.gameStateWaveTierTeamA != 3 && unitMovementType != scriptUnitAttribute.unitMovementType)
				{
					unitMovementType = scriptUnitAttribute.unitMovementType;
				}
				if (scriptGameStatistic.gameStateWaveTierTeamB == 3)
				{
					attributeHealthValue = -1;
				}
				switch (scriptGameStatistic.gameStateWaveTierTeamA)
				{
				case 0:
					state = 2;
					break;
				case 1:
					TOGGLE_waveTierBehaviour = 1;
					break;
				case 2:
					TOGGLE_waveTierBehaviour = 2;
					break;
				}
				num = TOGGLE_waveTierBehaviour;
				if (num == 1 || num != 2)
				{
					break;
				}
				switch (unitTier)
				{
				case 0:
					if (attributeHealthValue > attributeHealthMaximumValue / 2)
					{
						attributeHealthValue = attributeHealthMaximumValue / 2;
					}
					break;
				}
				break;
			}
			case 2:
			{
				int num;
				if (TOGGLE_unitTier != state)
				{
					num = unitTier;
					if (num == -1)
					{
						scriptGameStatistic.guardUnitsRemaing--;
					}
					scriptGameStatistic.gameStatusUnitSpawnNumberTeamA--;
					TOGGLE_unitTier = state;
				}
				num = unitTier;
				if (num != 0 && num == 1 && scriptGameStatistic.gameStateWaveTierTeamA != 0)
				{
					scriptGameStatistic.gameStateWaveTierTeamA = 0;
				}
				break;
			}
			}
			break;
		case 1:
			switch (state)
			{
			case 0:
				break;
			case 3:
				break;
			case 1:
			{
				int num;
				if (TOGGLE_unitTier != state)
				{
					num = unitTier;
					if (num != 0 && num == 1)
					{
						GameScriptsManager.hudControlcScript.unitControl = GetComponent<Unit_Control>();
						scriptGameStatistic.gameStateWaveTierTeamB = 2;
					}
					scriptGameStatistic.gameStatusUnitSpawnNumberTeamB++;
					TOGGLE_unitTier = state;
				}
				Vector3 position = myTransform.position;
				if (position.x <= -2.2f && scriptGameStatistic.gameStateWaveTierTeamB != 3)
				{
					scriptGameStatistic.gameStateWaveTierTeamB = 3;
				}
				if (scriptGameStatistic.gameStateWaveTierTeamB != 3)
				{
					if (unitMovementType != scriptUnitAttribute.unitMovementType)
					{
						unitMovementType = scriptUnitAttribute.unitMovementType;
					}
				}
				else if (scriptGameStatistic.gameStateWaveTierTeamB == 3 && unitMovementType != 0)
				{
					unitMovementType = 0;
				}
				switch (scriptGameStatistic.gameStateWaveTierTeamB)
				{
				case 0:
					state = 2;
					break;
				case 1:
					TOGGLE_waveTierBehaviour = 1;
					break;
				case 2:
					TOGGLE_waveTierBehaviour = 2;
					break;
				}
				num = TOGGLE_waveTierBehaviour;
				if (num == 1 || num != 2)
				{
					break;
				}
				switch (unitTier)
				{
				case 0:
					if (attributeHealthValue > attributeHealthMaximumValue / 2)
					{
						attributeHealthValue = attributeHealthMaximumValue / 2;
					}
					break;
				}
				break;
			}
			case 2:
			{
				if (TOGGLE_unitTier != state)
				{
					scriptGameStatistic.scoreUnitDefeated++;
					scriptGameStatistic.gameStatusUnitSpawnNumberTeamB--;
					TOGGLE_unitTier = state;
				}
				int num = unitTier;
				if (num != 0 && num == 1 && scriptGameStatistic.gameStateWaveTierTeamB != 0)
				{
					scriptGameStatistic.gameStateWaveTierTeamB = 0;
				}
				break;
			}
			}
			break;
		}
	}

	private void UnitSetup()
	{
		state++;
	}

	private void UnitDetectorFunction()
	{
		switch (unitAlignment)
		{
		case 0:
		{
			if (GetComponent<Collider>().enabled || state == 2)
			{
				if (base.tag != "TmA")
				{
					base.tag = "TmA";
				}
			}
			else if (base.tag != "Untagged")
			{
				base.tag = "Untagged";
			}
			Vector3 vECTOR_alignmentAttackSpawnPosition2 = VECTOR_alignmentAttackSpawnPosition;
			Vector3 position9 = myTransform.position;
			float x3 = position9.x + (attackRangeDistance + attackRange);
			Vector3 position10 = myTransform.position;
			if (vECTOR_alignmentAttackSpawnPosition2 != new Vector3(x3, position10.y, 0f))
			{
				Vector3 position11 = myTransform.position;
				float x4 = position11.x + (attackRangeDistance + attackRange);
				Vector3 position12 = myTransform.position;
				VECTOR_alignmentAttackSpawnPosition = new Vector3(x4, position12.y, 0f);
			}
			Vector3 vECTOR_rayPointAttack2 = VECTOR_rayPointAttack;
			Vector3 position13 = myTransform.position;
			if (vECTOR_rayPointAttack2 != new Vector3(position13.x + attackRangeDistance, -1.5f, 0f))
			{
				Vector3 position14 = myTransform.position;
				VECTOR_rayPointAttack = new Vector3(position14.x + attackRangeDistance, -1.5f, 0f);
			}
			Vector3 vECTOR_rayPointAttackDistance2 = VECTOR_rayPointAttackDistance;
			Vector3 position15 = myTransform.position;
			if (vECTOR_rayPointAttackDistance2 != new Vector3(position15.x, -1.5f, 0f))
			{
				Vector3 position16 = myTransform.position;
				VECTOR_rayPointAttackDistance = new Vector3(position16.x, -1.5f, 0f);
			}
			if (VECTOR_alignmentDetector != new Vector3(0f, -1.5f, 1f))
			{
				VECTOR_alignmentDetector = new Vector3(0f, -1.5f, 1f);
			}
			if (TOGGLE_unitAlignment != 0)
			{
				TOGGLE_unitAlignment = 0;
			}
			break;
		}
		case 1:
		{
			if (GetComponent<Collider>().enabled || state == 2)
			{
				if (base.tag != "TmB")
				{
					base.tag = "TmB";
				}
			}
			else if (base.tag != "Untagged")
			{
				base.tag = "Untagged";
			}
			Vector3 vECTOR_alignmentAttackSpawnPosition = VECTOR_alignmentAttackSpawnPosition;
			Vector3 position = myTransform.position;
			float x = position.x - (attackRangeDistance + attackRange);
			Vector3 position2 = myTransform.position;
			if (vECTOR_alignmentAttackSpawnPosition != new Vector3(x, position2.y, 0f))
			{
				Vector3 position3 = myTransform.position;
				float x2 = position3.x - (attackRangeDistance + attackRange);
				Vector3 position4 = myTransform.position;
				VECTOR_alignmentAttackSpawnPosition = new Vector3(x2, position4.y, 0f);
			}
			Vector3 vECTOR_rayPointAttack = VECTOR_rayPointAttack;
			Vector3 position5 = myTransform.position;
			if (vECTOR_rayPointAttack != new Vector3(position5.x - attackRangeDistance, -1.5f, 1f))
			{
				Vector3 position6 = myTransform.position;
				VECTOR_rayPointAttack = new Vector3(position6.x - attackRangeDistance, -1.5f, 1f);
			}
			Vector3 vECTOR_rayPointAttackDistance = VECTOR_rayPointAttackDistance;
			Vector3 position7 = myTransform.position;
			if (vECTOR_rayPointAttackDistance != new Vector3(position7.x, -1.5f, 1f))
			{
				Vector3 position8 = myTransform.position;
				VECTOR_rayPointAttackDistance = new Vector3(position8.x, -1.5f, 1f);
			}
			if (VECTOR_alignmentDetector != new Vector3(0f, -1.5f, 0f))
			{
				VECTOR_alignmentDetector = new Vector3(0f, -1.5f, 0f);
			}
			if (TOGGLE_unitAlignment != 1)
			{
				TOGGLE_unitAlignment = 1;
			}
			break;
		}
		}
		if (!(unitDetector != null))
		{
			return;
		}
		switch (state)
		{
		case 0:
			if (INST_unitDetector == null)
			{
				SpawnPool spawnPool = PoolManager.Pools["HUD Pool"];
				Transform transform = unitDetector.transform;
				Vector3 position17 = myTransform.position;
				INST_unitDetector = spawnPool.Spawn(transform, new Vector3(position17.x, VECTOR_alignmentDetector.y, VECTOR_alignmentDetector.z), myTransform.rotation);
				INST_unitDetector.GetComponent<Unit_Detection>().targetObject = base.gameObject;
				BoxCollider component = INST_unitDetector.GetComponent<BoxCollider>();
				Vector3 size = GetComponent<BoxCollider>().size;
				component.size = new Vector3(0.5f, 0.5f, size.z);
			}
			break;
		case 1:
			if (unitTier == -2)
			{
				if (attributeHealthValue <= 0)
				{
					if (INST_unitDetector != null)
					{
						PoolManager.Pools["HUD Pool"].Despawn(INST_unitDetector);
						INST_unitDetector = null;
					}
				}
				else if (INST_unitDetector == null)
				{
					SpawnPool spawnPool2 = PoolManager.Pools["HUD Pool"];
					Transform transform2 = unitDetector.transform;
					Vector3 position18 = myTransform.position;
					INST_unitDetector = spawnPool2.Spawn(transform2, new Vector3(position18.x, VECTOR_alignmentDetector.y, VECTOR_alignmentDetector.z), myTransform.rotation);
					INST_unitDetector.GetComponent<Unit_Detection>().targetObject = base.gameObject;
					BoxCollider component2 = INST_unitDetector.GetComponent<BoxCollider>();
					Vector3 size2 = GetComponent<BoxCollider>().size;
					component2.size = new Vector3(0.5f, 0.5f, size2.z);
				}
			}
			else if (INST_unitDetector == null)
			{
				SpawnPool spawnPool3 = PoolManager.Pools["HUD Pool"];
				Transform transform3 = unitDetector.transform;
				Vector3 position19 = myTransform.position;
				INST_unitDetector = spawnPool3.Spawn(transform3, new Vector3(position19.x, VECTOR_alignmentDetector.y, VECTOR_alignmentDetector.z), myTransform.rotation);
				INST_unitDetector.GetComponent<Unit_Detection>().targetObject = base.gameObject;
				BoxCollider component3 = INST_unitDetector.GetComponent<BoxCollider>();
				Vector3 size3 = GetComponent<BoxCollider>().size;
				component3.size = new Vector3(0.5f, 0.5f, size3.z);
			}
			break;
		case 2:
			if (INST_unitDetector != null)
			{
				INST_unitDetector.GetComponent<Unit_Detection>().targetObject = null;
				INST_unitDetector = null;
			}
			break;
		}
	}

	private void AttributeUpdate()
	{
		scriptUnitAttribute.unitState = unitState;
		scriptUnitAttribute.state = state;
		switch (state)
		{
		case 0:
			attributeHealthValue = scriptUnitAttribute.healthValue;
			attributeManaValue = scriptUnitAttribute.manaValue;
			attributeHealthMaximumValue = scriptUnitAttribute.healthValue;
			attributeManaMaximumValue = scriptUnitAttribute.manaValue;
			BASE_attributeMovementSpeed = scriptUnitAttribute.movementSpeedValue;
			unitAltitudeAirMotionSpeed = scriptUnitAttribute.unitAltitudeAirMotionSpeed;
			unitAltitudeAirHeightThreshold = scriptUnitAttribute.unitAltitudeAirHeightThreshold;
			unitAltitudeAirDisableDropSpeed = scriptUnitAttribute.unitAltitudeAirDisableDropSpeed;
			unitAltitudeAirDisableDropThreshold = scriptUnitAttribute.unitAltitudeAirDisableDropThreshold;
			unitAlignment = scriptUnitAttribute.unitAlignment;
			unitAltitudeType = scriptUnitAttribute.unitAltitudeType;
			unitTier = scriptUnitAttribute.unitTier;
			attributeEffectHexable = scriptUnitAttribute.effectHexable;
			statisticWeightValue = scriptUnitAttribute.unitStatisticWeightValue;
			break;
		case 1:
			attributeHealthMaximumValue = scriptUnitAttribute.healthValue;
			attributeManaMaximumValue = scriptUnitAttribute.manaValue;
			if (attributeHealthValue <= 0 && scriptUnitAttribute.unitTier != -2)
			{
				state = 2;
			}
			else if (attributeHealthValue > attributeHealthMaximumValue)
			{
				attributeHealthValue = attributeHealthMaximumValue;
			}
			else if (scriptUnitAttribute.unitTier == -2)
			{
				if (attributeHealthValue <= 0)
				{
					offenseDetectionState = 1;
					unitState = 1;
				}
				else if (attributeHealthValue > attributeHealthMaximumValue)
				{
					attributeHealthValue = attributeHealthMaximumValue;
				}
				else if (offenseDetectionState != 0)
				{
					offenseDetectionState = 0;
				}
			}
			if (attributeManaValue > attributeManaMaximumValue)
			{
				attributeManaValue = attributeManaMaximumValue;
			}
			else if (attributeManaValue < 0)
			{
				attributeManaValue = 0;
			}
			attributeManaRegenValue = scriptUnitAttribute.manaRegenValue;
			attributeMovementSpeed = scriptUnitAttribute.movementSpeedValue + BALANCE_attributeMovmentSpeed;
			attributeMovementVelocity = scriptUnitAttribute.movementSpeedVelocityValue;
			attributeAttackSpeedDelay = scriptUnitAttribute.attackSpeedDelay;
			attributeDamageMultiplier = scriptUnitAttribute.damageMultiplier;
			attributeCriticalValue = scriptUnitAttribute.criticalValue;
			attributeAccuracyValue = scriptUnitAttribute.accuracyValue;
			attributeEvasionValue = scriptUnitAttribute.evasionValue;
			attributeKnockResistanceValue = scriptUnitAttribute.knockResistanceValue;
			if (TOGGLE_unitHexEffect == 0)
			{
				if (unitAltitudeType != scriptUnitAttribute.unitAltitudeType)
				{
					unitAltitudeType = scriptUnitAttribute.unitAltitudeType;
				}
				if (scriptUnitAttribute.unitOffenseAction >= 0)
				{
					scriptCharacterAnimation.OffenseNumber = scriptUnitAttribute.unitOffenseNumber;
					unitOffenseAction = scriptUnitAttribute.unitOffenseAction;
					attackSpawnObject = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackSpawnObject;
					attackPosition = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackPosition;
					if (unitOffenseAction == 3)
					{
						if (TOGGLE_unitDestinationPosition == 1)
						{
							attackRange = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackRange + scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].rangeDistance;
							attackRangeDistance = 0f;
						}
						else
						{
							attackRange = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackRange;
							attackRangeDistance = 0f;
						}
					}
					else if (unitOffenseAction == 4)
					{
						if (TOGGLE_unitDestinationPosition == 1)
						{
							attackRange = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackRange + scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].rangeDistance + scriptUnitAttribute.unitDestinationPosition;
							attackRangeDistance = 0f;
						}
						else
						{
							attackRange = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackRange;
							attackRangeDistance = 0f;
						}
					}
					else
					{
						attackRange = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackRange;
						attackRangeDistance = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].rangeDistance;
					}
					attackStartDelay = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackStartDelay;
					attackDelay = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackDelay;
					attackEndDelay = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackEndDelay;
					attackManaCost = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackManaCost;
					attackHealthCost = scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].attackHealthCost;
				}
				else if (scriptUnitAttribute.unitOffenseAction == -1)
				{
					unitOffenseAction = 4;
					attackRange = 0.5f;
					attackRangeDistance = 0f;
				}
				else if (scriptUnitAttribute.unitOffenseAction == -2)
				{
					offenseDetectionState = 0;
				}
			}
			if (SLPLUS_objectKNK != scriptStatisticLogic.InGameAttribute[0].objectPlusKNK)
			{
				SLPLUS_objectKNK = scriptStatisticLogic.InGameAttribute[0].objectPlusKNK;
			}
			break;
		case 2:
			attributeMovementSpeed = BASE_attributeMovementSpeed;
			break;
		}
	}

	private void LateUpdate()
	{
		AttributeUpdate();
		AttributeStatePerksFunction();
	}

	private void Update()
	{
		if (debugMode == 1)
		{
			TestFunction();
		}
		UnitStatusInfo();
		if (Time.timeScale == 0f)
		{
			return;
		}
		if (scriptTrigger != null)
		{
			switch (TOGGLE_triggerType)
			{
			case 0:
				TriggerFunction();
				break;
			case 1:
				TriggerMinorFunction();
				break;
			}
		}
		WaveTierBehaviour();
		UnitDetectorFunction();
		DistanceControlFunction();
		if (unitTier != 0)
		{
			SpecialFunction();
		}
		if (TOGGLE_unitHexEffect == 0)
		{
			if (unitEntranceBehaviourState == 0)
			{
				unitEntranceBehaviourFunction();
			}
			if (unitAttackBehaviour != 0)
			{
				unitAttackBehaviourFunction();
			}
			else if (TOGGLE_attackAmount != attackAmount)
			{
				TOGGLE_attackAmount = attackAmount;
			}
			if (unitDefensiveBehaviourState == 0)
			{
				unitDefensiveBehaviourFunction();
			}
			if (unitUniqueBehaviourState == 0)
			{
				unitUniqueBehaviourFunction();
			}
		}
		switch (state)
		{
		case -1:
			unitEntranceBehaviourState = 0;
			unitDefensiveBehaviourState = 0;
			unitUniqueBehaviourState = 0;
			DisableComboFunctionState = -1;
			TOGGLE_attributeEffectHP = -1;
			TOGGLE_attributeOverTimeEffectHP = -1;
			TOGGLE_attributeEffectMP = -1;
			TOGGLE_attributeEffectDMG = -1;
			TOGGLE_attributeEffectMS = -1;
			TOGGLE_attributeEffectAS = -1;
			TOGGLE_attributeEffectAP = -1;
			TOGGLE_attributeEffectANP = -1;
			TOGGLE_attributeEffectMRP = -1;
			TOGGLE_attributeEffectCRP = -1;
			TOGGLE_attributeEffectACP = -1;
			TOGGLE_attributeEffectEVP = -1;
			TOGGLE_unitEffectKnock = -1;
			TOGGLE_unitEffectRise = -1;
			TOGGLE_unitActionTaunt = -1;
			TOGGLE_unitActionDash = -1;
			TOGGLE_attributeManaRegenFunction = -1;
			state++;
			break;
		case 0:
			UnitReset();
			UnitSetup();
			break;
		case 1:
			if (TOGGLE_attributeEffectHP != 0)
			{
				AttributeEffectHP();
			}
			if (TOGGLE_attributeOverTimeEffectHP != 0)
			{
				AttributeOverTimeEffectHP();
			}
			if (TOGGLE_attributeEffectMP != 0)
			{
				AttributeEffectMP();
			}
			if (TOGGLE_attributeEffectDMG != 0)
			{
				AttributeEffectDMG();
			}
			if (TOGGLE_attributeEffectMS != 0)
			{
				AttributeEffectMS();
			}
			if (TOGGLE_attributeEffectAS != 0)
			{
				AttributeEffectAS();
			}
			if (TOGGLE_attributeEffectAP != 0)
			{
				AttributeEffectAP();
			}
			if (TOGGLE_attributeEffectANP != 0)
			{
				AttributeEffectANP();
			}
			if (TOGGLE_attributeEffectMRP != 0)
			{
				AttributeEffectMRP();
			}
			if (TOGGLE_attributeEffectCRP != 0)
			{
				AttributeEffectCRP();
			}
			if (TOGGLE_attributeEffectACP != 0)
			{
				AttributeEffectACP();
			}
			if (TOGGLE_attributeEffectEVP != 0)
			{
				AttributeEffectEVP();
			}
			if (TOGGLE_unitEffectKnock != 0)
			{
				UnitEffectKnock();
			}
			if (DisableComboFunctionState != 0)
			{
				DisableComboFunction();
			}
			if (unitState != 4)
			{
				if (TOGGLE_unitActionTaunt != 0)
				{
					UnitActionTaunt();
				}
				if (TOGGLE_unitActionDash != 0)
				{
					UnitActionDash();
				}
			}
			if (attributeManaRegenValue > 0)
			{
				AttributeManaRegenFunction();
			}
			switch (unitState)
			{
			case 0:
				ActionFunction();
				break;
			case 1:
				MovementFunction();
				OffenseDetection();
				break;
			case 2:
				OffenseFunction();
				OffenseDetection();
				break;
			case 3:
				DefenseFunction();
				OffenseDetection();
				break;
			case 4:
				DisableFunction();
				break;
			}
			break;
		case 2:
			StateRetreat();
			break;
		case 3:
			StateExit();
			break;
		}
		if (TOGGLE_unitEffectRise != 0)
		{
			UnitEffectRise();
		}
		UnitEffectDisable();
		UnitEffectHex();
		UnitColorFunction();
		UnitEffectColor();
		AttributePropDisplay();
		switch (unitAltitudeType)
		{
		case -1:
			if (unitAltitudeAirMotionSpeed > 0f)
			{
				AirMotionFunction();
			}
			break;
		case 0:
			AltitudeControlFunction();
			break;
		case 1:
			if (unitAltitudeAirMotionSpeed > 0f)
			{
				AirMotionFunction();
			}
			break;
		}
	}

	private void SpecialFunction()
	{
		switch (state)
		{
		case 0:
			TOGGLE_screenEffectDamagedEffect = 0;
			break;
		case 1:
			if (TOGGLE_screenEffectDamagedEffect > attributeHealthValue)
			{
				switch (TOGGLE_unitAlignment)
				{
				case 0:
					GameScriptsManager.cameraShakeScript.damageEffect = 1;
					break;
				case 1:
					GameScriptsManager.cameraShakeScript.damageEffect = 2;
					break;
				}
				TOGGLE_screenEffectDamagedEffect = attributeHealthValue;
			}
			else if (TOGGLE_screenEffectDamagedEffect < attributeHealthValue)
			{
				TOGGLE_screenEffectDamagedEffect = attributeHealthValue;
			}
			break;
		}
	}

	private void StateExit()
	{
		if (TOGGLE_state != state)
		{
			TOGGLE_state = state;
		}
		UnitReset();
		scriptCharacterAnimation.AnimationNumber = 0;
		PoolManager.Pools["Unit Pool"].Despawn(base.transform);
	}

	private void unitEntranceBehaviourFunction()
	{
		switch (unitEntranceBehaviour)
		{
		case 0:
			switch (state)
			{
			case 2:
				break;
			case 0:
				TOGGLE_unitEntranceBehaviour = 1;
				break;
			case 1:
				switch (TOGGLE_unitEntranceBehaviour)
				{
				case 0:
					unitEntranceBehaviourState = 1;
					break;
				case 1:
					GetComponent<Collider>().enabled = true;
					if (unitEntranceBehaviourAmountA == 0f)
					{
						Transform transform = myTransform;
						Vector3 position = myTransform.position;
						transform.position = new Vector3(position.x, unitDefaultAltitude, 0f);
					}
					TOGGLE_unitEntranceBehaviour = 0;
					break;
				}
				break;
			}
			break;
		case 1:
			unitEntranceBehaviourDashIn();
			break;
		case 2:
			unitEntranceBehaviourMiddleSpawn();
			break;
		case 3:
			unitEntranceBehaviourLeapIn();
			break;
		}
	}

	private void unitEntranceBehaviourDashIn()
	{
		switch (state)
		{
		case 2:
			break;
		case 0:
			GetComponent<Collider>().enabled = true;
			break;
		case 1:
		{
			switch (TOGGLE_unitAlignment)
			{
			case 0:
				if (unitEntranceBehaviourAmountA != 0f)
				{
					Vector3 position2 = myTransform.position;
					if (position2.x < unitEntranceBehaviourAmountA)
					{
						TOGGLE_unitEntranceBehaviour = 1;
					}
				}
				break;
			case 1:
			{
				Vector3 position = myTransform.position;
				if (position.x > unitEntranceBehaviourAmountA + stageLength)
				{
					TOGGLE_unitEntranceBehaviour = 1;
				}
				break;
			}
			}
			int tOGGLE_unitEntranceBehaviour = TOGGLE_unitEntranceBehaviour;
			if (tOGGLE_unitEntranceBehaviour == 1)
			{
				UnitActionDash(1, unitEntranceBehaviourAmountB, unitEntranceBehaviourAmountC, unitEntranceBehaviourAmountD);
				TOGGLE_unitEntranceBehaviour = 0;
			}
			break;
		}
		}
	}

	private void unitEntranceBehaviourMiddleSpawn()
	{
		switch (state)
		{
		case 2:
			break;
		case 0:
			GetComponent<Collider>().enabled = false;
			TOGGLE_unitEntranceBehaviour = 1;
			break;
		case 1:
			switch (TOGGLE_unitEntranceBehaviour)
			{
			case 0:
				unitEntranceBehaviourState = 1;
				break;
			case 1:
			{
				GetComponent<Collider>().enabled = false;
				if (unitEntranceBehaviourAmountA == 0f && unitEntranceBehaviourAmountB == 0f)
				{
					Vector3 position10 = myTransform.position;
					RANDOM_unitEntranceBehaviour = position10.x;
				}
				else
				{
					switch (TOGGLE_unitAlignment)
					{
					case 0:
						RANDOM_unitEntranceBehaviour = UnityEngine.Random.Range(unitEntranceBehaviourAmountA, unitEntranceBehaviourAmountB);
						break;
					case 1:
						RANDOM_unitEntranceBehaviour = UnityEngine.Random.Range(unitEntranceBehaviourAmountA, unitEntranceBehaviourAmountB + stageLength);
						break;
					}
				}
				Transform transform4 = myTransform;
				float rANDOM_unitEntranceBehaviour4 = RANDOM_unitEntranceBehaviour;
				float y4 = unitEntranceBehaviourAmountC;
				Vector3 position11 = myTransform.position;
				transform4.position = new Vector3(rANDOM_unitEntranceBehaviour4, y4, position11.z);
				TOGGLE_unitEntranceBehaviour = 2;
				break;
			}
			case 2:
			{
				Vector3 position = myTransform.position;
				if (position.x != RANDOM_unitEntranceBehaviour)
				{
					Transform transform = myTransform;
					float rANDOM_unitEntranceBehaviour = RANDOM_unitEntranceBehaviour;
					Vector3 position2 = myTransform.position;
					float y = position2.y;
					Vector3 position3 = myTransform.position;
					transform.position = new Vector3(rANDOM_unitEntranceBehaviour, y, position3.z);
				}
				if (unitEntranceBehaviourAmountC > unitDefaultAltitude)
				{
					Vector3 position4 = myTransform.position;
					if (position4.y > unitDefaultAltitude)
					{
						GetComponent<Collider>().enabled = false;
						unitState = 0;
						scriptCharacterAnimation.AnimationNumber = 0;
						myTransform.Translate(-myTransform.up * unitEntranceBehaviourAmountD * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 position5 = myTransform.position;
					if (position5.y <= unitDefaultAltitude)
					{
						GetComponent<Collider>().enabled = true;
						unitState = 1;
						Transform transform2 = myTransform;
						float rANDOM_unitEntranceBehaviour2 = RANDOM_unitEntranceBehaviour;
						float y2 = unitDefaultAltitude;
						Vector3 position6 = myTransform.position;
						transform2.position = new Vector3(rANDOM_unitEntranceBehaviour2, y2, position6.z);
						TOGGLE_unitEntranceBehaviour = 0;
					}
				}
				else
				{
					if (!(unitEntranceBehaviourAmountC < unitDefaultAltitude))
					{
						break;
					}
					Vector3 position7 = myTransform.position;
					if (position7.y < unitDefaultAltitude)
					{
						GetComponent<Collider>().enabled = false;
						unitState = 0;
						scriptCharacterAnimation.AnimationNumber = 0;
						myTransform.Translate(myTransform.up * unitEntranceBehaviourAmountD * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 position8 = myTransform.position;
					if (position8.y >= unitDefaultAltitude)
					{
						GetComponent<Collider>().enabled = true;
						unitState = 1;
						Transform transform3 = myTransform;
						float rANDOM_unitEntranceBehaviour3 = RANDOM_unitEntranceBehaviour;
						float y3 = unitDefaultAltitude;
						Vector3 position9 = myTransform.position;
						transform3.position = new Vector3(rANDOM_unitEntranceBehaviour3, y3, position9.z);
						TOGGLE_unitEntranceBehaviour = 0;
					}
				}
				break;
			}
			}
			break;
		}
	}

	private void unitEntranceBehaviourLeapIn()
	{
		switch (state)
		{
		case 2:
			break;
		case 0:
			GetComponent<Collider>().enabled = true;
			break;
		case 1:
		{
			switch (TOGGLE_unitAlignment)
			{
			case 0:
				if (unitEntranceBehaviourAmountA != 0f)
				{
					Vector3 position2 = myTransform.position;
					if (position2.x < unitEntranceBehaviourAmountA)
					{
						TOGGLE_unitEntranceBehaviour = 1;
					}
				}
				break;
			case 1:
			{
				Vector3 position = myTransform.position;
				if (position.x > unitEntranceBehaviourAmountA + stageLength)
				{
					TOGGLE_unitEntranceBehaviour = 1;
				}
				break;
			}
			}
			int tOGGLE_unitEntranceBehaviour = TOGGLE_unitEntranceBehaviour;
			if (tOGGLE_unitEntranceBehaviour == 1)
			{
				UnitActionDash(1, unitEntranceBehaviourAmountB, unitEntranceBehaviourAmountC, 5f);
				UnitEffectRise(1, 0.2f, unitEntranceBehaviourAmountD, 5f);
				TOGGLE_unitEntranceBehaviour = 0;
			}
			break;
		}
		}
	}

	private void unitAttackBehaviourFunction()
	{
		switch (unitAttackBehaviour)
		{
		case 0:
			if (TOGGLE_attackAmount != attackAmount)
			{
				TOGGLE_attackAmount = attackAmount;
			}
			break;
		case 1:
			unitAttackBehaviourDash();
			break;
		case 2:
			unitAttackBehaviourKnock();
			break;
		}
	}

	private void unitAttackBehaviourDash()
	{
		switch (state)
		{
		case 0:
			break;
		case 2:
			break;
		case 1:
			if (TOGGLE_attackAmount != attackAmount)
			{
				UnitActionDash(Mathf.RoundToInt(unitAttackBehaviourAmountA), unitAttackBehaviourAmountB, unitAttackBehaviourAmountC, unitAttackBehaviourAmountD);
				TOGGLE_attackAmount = attackAmount;
			}
			break;
		}
	}

	private void unitAttackBehaviourKnock()
	{
		switch (state)
		{
		case 0:
			break;
		case 2:
			break;
		case 1:
			if (TOGGLE_attackAmount != attackAmount)
			{
				UnitEffectKnock(Mathf.RoundToInt(unitAttackBehaviourAmountA), unitAttackBehaviourAmountB, unitAttackBehaviourAmountC, unitAttackBehaviourAmountD);
				TOGGLE_attackAmount = attackAmount;
			}
			break;
		}
	}

	private void unitDefensiveBehaviourFunction()
	{
		switch (unitDefensiveBehaviour)
		{
		case 0:
			switch (state)
			{
			case 0:
				TOGGLE_healthValue = attributeHealthMaximumValue;
				TOGGLE_defenseBehaviour = 0;
				break;
			case 1:
				unitDefensiveBehaviourState = 1;
				break;
			}
			break;
		case 1:
			unitDefensiveBehaviourGuard();
			break;
		case 2:
			unitDefensiveBehaviourDash();
			break;
		case 3:
			unitDefensiveBehaviourThresholdRecovery();
			break;
		}
	}

	private void unitDefensiveBehaviourGuard()
	{
		switch (state)
		{
		case 0:
		{
			offenseDetectionState = 0;
			Vector3 localPosition3 = scriptCharacterAnimation.transform.localPosition;
			POSITION_defenseBehaviour = localPosition3.z;
			TOGGLE_healthValue = 0;
			TOGGLE_defenseBehaviour = -1;
			break;
		}
		case 1:
			if (TOGGLE_defenseBehaviour == -1)
			{
				TOGGLE_healthValue = attributeHealthValue;
				TOGGLE_defenseBehaviour = 0;
				break;
			}
			if (unitState == 4)
			{
				TOGGLE_defenseBehaviour = 1;
				break;
			}
			if (unitDefensiveBehaviourAmountA == 0f)
			{
				if (TOGGLE_healthValue > attributeHealthValue)
				{
					TOGGLE_defenseBehaviour = 1;
					TOGGLE_healthValue = attributeHealthValue;
				}
			}
			else if (unitDefensiveBehaviourAmountA == 1f && TOGGLE_unitEffectKnock > 0)
			{
				TOGGLE_defenseBehaviour = 1;
			}
			if (unitDefensiveBehaviourAmountC > 0f)
			{
				switch (TOGGLE_defenseBehaviour)
				{
				case 1:
				{
					offenseDetectionState = 1;
					unitState = 3;
					TIMER_attackEndDelay = Time.time + unitDefensiveBehaviourAmountB;
					Transform transform3 = scriptCharacterAnimation.transform;
					Vector3 localPosition6 = scriptCharacterAnimation.transform.localPosition;
					float x2 = localPosition6.x;
					Vector3 localPosition7 = scriptCharacterAnimation.transform.localPosition;
					transform3.localPosition = new Vector3(x2, localPosition7.y, POSITION_defenseBehaviour);
					AMOUNT_defenseBehaviour = 0f;
					TOGGLE2_defenseBehaviour = 0;
					TOGGLE_defenseBehaviour++;
					break;
				}
				case 2:
					if (Time.time < TIMER_attackEndDelay)
					{
						if (Time.time < TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 2f)
						{
							AMOUNT_defenseBehaviour = 0f;
						}
						if (Time.time >= TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 2f && Time.time < TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 4f)
						{
							AMOUNT_defenseBehaviour = 0.5f;
						}
						else if (Time.time >= TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 4f && Time.time < TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 8f)
						{
							AMOUNT_defenseBehaviour = 1f;
						}
						else if (Time.time >= TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 8f)
						{
							AMOUNT_defenseBehaviour = 2f;
						}
						if (!(AMOUNT_defenseBehaviour > 0f))
						{
							break;
						}
						if (TOGGLE2_defenseBehaviour == 0)
						{
							Vector3 localPosition8 = scriptCharacterAnimation.transform.localPosition;
							if (localPosition8.z < 0.01f)
							{
								scriptCharacterAnimation.transform.Translate(-scriptCharacterAnimation.transform.right * AMOUNT_defenseBehaviour * Time.smoothDeltaTime, Space.World);
								break;
							}
							Vector3 localPosition9 = scriptCharacterAnimation.transform.localPosition;
							if (localPosition9.z >= 0.01f)
							{
								Transform transform4 = scriptCharacterAnimation.transform;
								Vector3 localPosition10 = scriptCharacterAnimation.transform.localPosition;
								float x3 = localPosition10.x;
								Vector3 localPosition11 = scriptCharacterAnimation.transform.localPosition;
								transform4.localPosition = new Vector3(x3, localPosition11.y, POSITION_defenseBehaviour + 0.05f);
								TOGGLE2_defenseBehaviour = 1;
							}
						}
						else
						{
							if (TOGGLE2_defenseBehaviour != 1)
							{
								break;
							}
							Vector3 localPosition12 = scriptCharacterAnimation.transform.localPosition;
							if (localPosition12.z > -0.01f)
							{
								scriptCharacterAnimation.transform.Translate(scriptCharacterAnimation.transform.right * AMOUNT_defenseBehaviour * Time.smoothDeltaTime, Space.World);
								break;
							}
							Vector3 localPosition13 = scriptCharacterAnimation.transform.localPosition;
							if (localPosition13.z <= -0.01f)
							{
								Transform transform5 = scriptCharacterAnimation.transform;
								Vector3 localPosition14 = scriptCharacterAnimation.transform.localPosition;
								float x4 = localPosition14.x;
								Vector3 localPosition15 = scriptCharacterAnimation.transform.localPosition;
								transform5.localPosition = new Vector3(x4, localPosition15.y, POSITION_defenseBehaviour - 0.05f);
								TOGGLE2_defenseBehaviour = 0;
							}
						}
					}
					else if (Time.time >= TIMER_attackEndDelay)
					{
						TOGGLE_defenseBehaviour++;
					}
					break;
				case 3:
				{
					if (unitDefensiveBehaviourAmountD > 0f)
					{
						AttributeEffectHP(2, Mathf.RoundToInt(unitDefensiveBehaviourAmountD), 0);
					}
					else if (unitDefensiveBehaviourAmountD < 0f)
					{
						AttributeEffectHP(2, attributeHealthMaximumValue, 0);
					}
					Transform transform2 = scriptCharacterAnimation.transform;
					Vector3 localPosition4 = scriptCharacterAnimation.transform.localPosition;
					float x = localPosition4.x;
					Vector3 localPosition5 = scriptCharacterAnimation.transform.localPosition;
					transform2.localPosition = new Vector3(x, localPosition5.y, POSITION_defenseBehaviour);
					offenseDetectionState = 0;
					TOGGLE_defenseBehaviour = 0;
					break;
				}
				}
				break;
			}
			switch (TOGGLE_defenseBehaviour)
			{
			case 1:
				unitState = 3;
				TIMER_attackEndDelay = Time.time + unitDefensiveBehaviourAmountB;
				if (unitDefensiveBehaviourAmountD > 0f)
				{
					TOGGLE_defenseBehaviour++;
				}
				else
				{
					TOGGLE_defenseBehaviour = 0;
				}
				break;
			case 2:
				if (unitState != 3)
				{
					if (unitDefensiveBehaviourAmountD > 0f)
					{
						AttributeEffectHP(2, Mathf.RoundToInt(unitDefensiveBehaviourAmountD), 0);
					}
					TOGGLE_defenseBehaviour = 0;
				}
				break;
			}
			break;
		case 2:
			if (TOGGLE_defenseBehaviour != 0)
			{
				offenseDetectionState = 0;
				Transform transform = scriptCharacterAnimation.transform;
				float pOSITION_defenseBehaviour = POSITION_defenseBehaviour;
				Vector3 localPosition = scriptCharacterAnimation.transform.localPosition;
				float y = localPosition.y;
				Vector3 localPosition2 = scriptCharacterAnimation.transform.localPosition;
				transform.localPosition = new Vector3(pOSITION_defenseBehaviour, y, localPosition2.z);
				TOGGLE_healthValue = 0;
				TOGGLE_defenseBehaviour = -1;
			}
			break;
		}
	}

	private void unitDefensiveBehaviourDash()
	{
		switch (state)
		{
		case 0:
			TOGGLE_healthValue = attributeHealthMaximumValue;
			TOGGLE_defenseBehaviour = -1;
			break;
		case 1:
		{
			if (TOGGLE_defenseBehaviour == -1)
			{
				TOGGLE_healthValue = attributeHealthValue;
				TOGGLE_defenseBehaviour = 0;
			}
			if (unitState == 4)
			{
				TOGGLE_defenseBehaviour = 1;
				break;
			}
			if (unitDefensiveBehaviourAmountA == 0f && TOGGLE_healthValue > attributeHealthValue)
			{
				TOGGLE_defenseBehaviour = 1;
				TOGGLE_healthValue = attributeHealthValue;
			}
			int tOGGLE_defenseBehaviour = TOGGLE_defenseBehaviour;
			if (tOGGLE_defenseBehaviour == 1)
			{
				UnitActionDash(2, unitDefensiveBehaviourAmountB, unitDefensiveBehaviourAmountC, unitDefensiveBehaviourAmountD);
				TOGGLE_defenseBehaviour = 0;
			}
			break;
		}
		case 2:
			if (TOGGLE_defenseBehaviour != 0)
			{
				TOGGLE_healthValue = attributeHealthMaximumValue;
				TOGGLE_defenseBehaviour = -1;
			}
			break;
		}
	}

	private void unitDefensiveBehaviourThresholdRecovery()
	{
		switch (state)
		{
		case 0:
		{
			offenseDetectionState = 0;
			Vector3 localPosition3 = scriptCharacterAnimation.transform.localPosition;
			POSITION_defenseBehaviour = localPosition3.z;
			TOGGLE_healthValue = attributeHealthMaximumValue;
			TOGGLE_defenseBehaviour = 0;
			break;
		}
		case 1:
			if (unitState != 4)
			{
				switch (TOGGLE_defenseBehaviour)
				{
				case 0:
					if ((float)attributeHealthValue <= unitDefensiveBehaviourAmountA)
					{
						TOGGLE_defenseBehaviour++;
					}
					break;
				case 1:
				{
					offenseDetectionState = 1;
					unitState = 3;
					TIMER_attackEndDelay = Time.time + unitDefensiveBehaviourAmountB;
					Transform transform5 = scriptCharacterAnimation.transform;
					Vector3 localPosition14 = scriptCharacterAnimation.transform.localPosition;
					float x4 = localPosition14.x;
					Vector3 localPosition15 = scriptCharacterAnimation.transform.localPosition;
					transform5.localPosition = new Vector3(x4, localPosition15.y, POSITION_defenseBehaviour);
					AMOUNT_defenseBehaviour = 0f;
					TOGGLE2_defenseBehaviour = 0;
					if (unitDefensiveBehaviourAmountC == 1f && scriptUnitAttribute.retreatEffect.Length > 0)
					{
						for (int i = 0; i < scriptUnitAttribute.retreatEffect.Length; i++)
						{
							PoolManager.Pools["Effect Pool"].Spawn(scriptUnitAttribute.retreatEffect[i].transform, myTransform.position, scriptUnitAttribute.retreatEffect[i].transform.rotation);
						}
					}
					TOGGLE_defenseBehaviour++;
					break;
				}
				case 2:
					if (Time.time < TIMER_attackEndDelay)
					{
						if (Time.time < TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 2f)
						{
							AMOUNT_defenseBehaviour = 0f;
						}
						if (Time.time >= TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 2f && Time.time < TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 4f)
						{
							AMOUNT_defenseBehaviour = 0.5f;
						}
						else if (Time.time >= TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 4f && Time.time < TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 8f)
						{
							AMOUNT_defenseBehaviour = 1f;
						}
						else if (Time.time >= TIMER_attackEndDelay - unitDefensiveBehaviourAmountB / 8f)
						{
							AMOUNT_defenseBehaviour = 2f;
						}
						if (!(AMOUNT_defenseBehaviour > 0f))
						{
							break;
						}
						if (TOGGLE2_defenseBehaviour == 0)
						{
							Vector3 localPosition6 = scriptCharacterAnimation.transform.localPosition;
							if (localPosition6.z < 0.01f)
							{
								scriptCharacterAnimation.transform.Translate(-scriptCharacterAnimation.transform.right * AMOUNT_defenseBehaviour * Time.smoothDeltaTime, Space.World);
								break;
							}
							Vector3 localPosition7 = scriptCharacterAnimation.transform.localPosition;
							if (localPosition7.z >= 0.01f)
							{
								Transform transform3 = scriptCharacterAnimation.transform;
								Vector3 localPosition8 = scriptCharacterAnimation.transform.localPosition;
								float x2 = localPosition8.x;
								Vector3 localPosition9 = scriptCharacterAnimation.transform.localPosition;
								transform3.localPosition = new Vector3(x2, localPosition9.y, POSITION_defenseBehaviour + 0.05f);
								TOGGLE2_defenseBehaviour = 1;
							}
						}
						else
						{
							if (TOGGLE2_defenseBehaviour != 1)
							{
								break;
							}
							Vector3 localPosition10 = scriptCharacterAnimation.transform.localPosition;
							if (localPosition10.z > -0.01f)
							{
								scriptCharacterAnimation.transform.Translate(scriptCharacterAnimation.transform.right * AMOUNT_defenseBehaviour * Time.smoothDeltaTime, Space.World);
								break;
							}
							Vector3 localPosition11 = scriptCharacterAnimation.transform.localPosition;
							if (localPosition11.z <= -0.01f)
							{
								Transform transform4 = scriptCharacterAnimation.transform;
								Vector3 localPosition12 = scriptCharacterAnimation.transform.localPosition;
								float x3 = localPosition12.x;
								Vector3 localPosition13 = scriptCharacterAnimation.transform.localPosition;
								transform4.localPosition = new Vector3(x3, localPosition13.y, POSITION_defenseBehaviour - 0.05f);
								TOGGLE2_defenseBehaviour = 0;
							}
						}
					}
					else if (Time.time >= TIMER_attackEndDelay)
					{
						TOGGLE_defenseBehaviour++;
					}
					break;
				case 3:
				{
					if (unitDefensiveBehaviourAmountD > unitDefensiveBehaviourAmountA)
					{
						AttributeEffectHP(2, Mathf.RoundToInt(unitDefensiveBehaviourAmountD), 0);
					}
					else if (unitDefensiveBehaviourAmountD == 0f)
					{
						AttributeEffectHP(2, Mathf.RoundToInt(unitDefensiveBehaviourAmountA * 2f), 0);
						unitDefensiveBehaviourAmountA /= 1.25f;
					}
					else if (unitDefensiveBehaviourAmountD < 0f)
					{
						AttributeEffectHP(2, attributeHealthMaximumValue, 0);
					}
					if (unitDefensiveBehaviourAmountC == 1f)
					{
						Camera_Control cameraControlScript = GameScriptsManager.cameraControlScript;
						Vector3 position = myTransform.position;
						cameraControlScript.setPositionX = position.x;
						GameScriptsManager.cameraShakeScript.defeatEffect = 1;
						GameScriptsManager.cameraControlScript.setCameraPosition = 1;
					}
					Transform transform2 = scriptCharacterAnimation.transform;
					Vector3 localPosition4 = scriptCharacterAnimation.transform.localPosition;
					float x = localPosition4.x;
					Vector3 localPosition5 = scriptCharacterAnimation.transform.localPosition;
					transform2.localPosition = new Vector3(x, localPosition5.y, POSITION_defenseBehaviour);
					offenseDetectionState = 0;
					TOGGLE_defenseBehaviour = 0;
					break;
				}
				}
			}
			else if (TOGGLE_defenseBehaviour > 0 && (unitState == 4 || TOGGLE_unitEffectDisable > 0))
			{
				TOGGLE_unitEffectDisable = 0;
				unitState = 3;
			}
			break;
		case 2:
			if (TOGGLE_defenseBehaviour != 0)
			{
				offenseDetectionState = 0;
				Transform transform = scriptCharacterAnimation.transform;
				float pOSITION_defenseBehaviour = POSITION_defenseBehaviour;
				Vector3 localPosition = scriptCharacterAnimation.transform.localPosition;
				float y = localPosition.y;
				Vector3 localPosition2 = scriptCharacterAnimation.transform.localPosition;
				transform.localPosition = new Vector3(pOSITION_defenseBehaviour, y, localPosition2.z);
				TOGGLE_healthValue = attributeHealthMaximumValue;
				TOGGLE_defenseBehaviour = 0;
			}
			break;
		}
	}

	private void unitUniqueBehaviourFunction()
	{
		switch (unitUniqueBehaviour)
		{
		case 0:
			unitUniqueBehaviourState = 1;
			break;
		case 1:
			unitUniqueBehaviourIdleDelay();
			break;
		case 2:
			unitUniqueBehaviourReappearing();
			break;
		case 3:
			unitUniqueBehaviourFade();
			break;
		}
	}

	private void unitUniqueBehaviourIdleDelay()
	{
		switch (state)
		{
		case 0:
			if (unitUniqueBehaviourAmountC == 0f)
			{
				TOGGLE_unitUniqueBehaviour = 0;
			}
			else if (unitUniqueBehaviourAmountC == 1f)
			{
				TOGGLE_unitUniqueBehaviour = 3;
				TIMER_unitUniqueBehaviour = Time.time + unitUniqueBehaviourAmountB;
				scriptCharacterAnimation.AnimationNumber = 0;
				TOGGLE_unitIdle = 1;
				unitState = 0;
			}
			break;
		case 1:
			switch (TOGGLE_unitUniqueBehaviour)
			{
			case 0:
				switch (unitState)
				{
				case 0:
					TOGGLE_unitIdle = 0;
					unitState = 1;
					TIMER_unitUniqueBehaviour = Time.time + unitUniqueBehaviourAmountA;
					TOGGLE_unitUniqueBehaviour++;
					break;
				case 1:
					TOGGLE_unitIdle = 0;
					unitState = 1;
					TIMER_unitUniqueBehaviour = Time.time + unitUniqueBehaviourAmountA;
					TOGGLE_unitUniqueBehaviour++;
					break;
				}
				break;
			case 1:
				if (Time.time >= TIMER_unitUniqueBehaviour)
				{
					TOGGLE_unitUniqueBehaviour++;
				}
				break;
			case 2:
			{
				int num = unitState;
				if (num == 1)
				{
					scriptCharacterAnimation.AnimationNumber = 0;
					TOGGLE_unitIdle = 1;
					unitState = 0;
					TIMER_unitUniqueBehaviour = Time.time + unitUniqueBehaviourAmountB;
					TOGGLE_unitUniqueBehaviour++;
				}
				break;
			}
			case 3:
				if (unitState != 0 && unitState != 4)
				{
					scriptCharacterAnimation.AnimationNumber = 0;
					unitState = 0;
				}
				if (Time.time >= TIMER_unitUniqueBehaviour)
				{
					TOGGLE_unitUniqueBehaviour = 0;
				}
				break;
			}
			break;
		case 2:
			if (TOGGLE_unitIdle == 1)
			{
				TOGGLE_unitIdle = 0;
			}
			break;
		}
	}

	private void unitUniqueBehaviourReappearing()
	{
		switch (state)
		{
		case 2:
			break;
		case 0:
			TOGGLE_healthValue = attributeHealthMaximumValue;
			TOGGLE_unitUniqueBehaviour = 0;
			break;
		case 1:
		{
			if (unitState == 4)
			{
				TOGGLE2_unitUniqueBehaviour = 1;
				break;
			}
			switch (TOGGLE_unitUniqueBehaviour)
			{
			case 1:
				if (unitUniqueBehaviourAmountC > 0f)
				{
					Vector3 position9 = myTransform.position;
					if (position9.y < 6.5f)
					{
						GetComponent<Collider>().enabled = false;
						TOGGLE_unitIdle = 1;
						unitState = 0;
						scriptCharacterAnimation.AnimationNumber = 0;
						myTransform.Translate(myTransform.up * unitUniqueBehaviourAmountC * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 position10 = myTransform.position;
					if (position10.y >= 6.5f)
					{
						Transform transform3 = myTransform;
						Vector3 position11 = myTransform.position;
						float x3 = position11.x;
						Vector3 position12 = myTransform.position;
						transform3.position = new Vector3(x3, 6.5f, position12.z);
						TOGGLE_unitUniqueBehaviour++;
					}
				}
				else
				{
					if (!(unitUniqueBehaviourAmountC < 0f))
					{
						break;
					}
					Vector3 position13 = myTransform.position;
					if (position13.y > -2.5f)
					{
						GetComponent<Collider>().enabled = false;
						TOGGLE_unitIdle = 1;
						unitState = 0;
						scriptCharacterAnimation.AnimationNumber = 0;
						myTransform.Translate(myTransform.up * unitUniqueBehaviourAmountC * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 position14 = myTransform.position;
					if (position14.y <= -2.5f)
					{
						Transform transform4 = myTransform;
						Vector3 position15 = myTransform.position;
						float x4 = position15.x;
						Vector3 position16 = myTransform.position;
						transform4.position = new Vector3(x4, -2.5f, position16.z);
						TOGGLE_unitUniqueBehaviour++;
					}
				}
				break;
			case 2:
			{
				TRANSFORM_airMotion = 0f;
				Transform transform5 = myTransform;
				Vector3 position17 = myTransform.position;
				float y3 = position17.y;
				Vector3 position18 = myTransform.position;
				transform5.position = new Vector3(100f, y3, position18.z);
				POSITION_unitUniqueBehaviour = UnityEngine.Random.Range(unitUniqueBehaviourAmountB, 5f + stageLength);
				TIMER_unitUniqueBehaviour = Time.time + unitUniqueBehaviourAmountD;
				TOGGLE_unitUniqueBehaviour++;
				break;
			}
			case 3:
				if (Time.time >= TIMER_unitUniqueBehaviour)
				{
					scriptCharacterAnimation.AnimationNumber = 0;
					Transform transform6 = myTransform;
					float pOSITION_unitUniqueBehaviour = POSITION_unitUniqueBehaviour;
					Vector3 position19 = myTransform.position;
					float y4 = position19.y;
					Vector3 position20 = myTransform.position;
					transform6.position = new Vector3(pOSITION_unitUniqueBehaviour, y4, position20.z);
					TOGGLE_unitUniqueBehaviour++;
				}
				break;
			case 4:
				if (unitUniqueBehaviourAmountC > 0f)
				{
					Vector3 position = myTransform.position;
					if (position.y > unitDefaultAltitude)
					{
						myTransform.Translate(-myTransform.up * unitUniqueBehaviourAmountC * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 position2 = myTransform.position;
					if (position2.y <= unitDefaultAltitude)
					{
						GetComponent<Collider>().enabled = true;
						TOGGLE_unitIdle = 0;
						unitState = 1;
						Transform transform = myTransform;
						Vector3 position3 = myTransform.position;
						float x = position3.x;
						float y = unitDefaultAltitude;
						Vector3 position4 = myTransform.position;
						transform.position = new Vector3(x, y, position4.z);
						TOGGLE_unitUniqueBehaviour = 0;
					}
				}
				else
				{
					if (!(unitUniqueBehaviourAmountC < 0f))
					{
						break;
					}
					Vector3 position5 = myTransform.position;
					if (position5.y < unitDefaultAltitude)
					{
						myTransform.Translate(-myTransform.up * unitUniqueBehaviourAmountC * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 position6 = myTransform.position;
					if (position6.y >= unitDefaultAltitude)
					{
						GetComponent<Collider>().enabled = true;
						TOGGLE_unitIdle = 0;
						unitState = 1;
						Transform transform2 = myTransform;
						Vector3 position7 = myTransform.position;
						float x2 = position7.x;
						float y2 = unitDefaultAltitude;
						Vector3 position8 = myTransform.position;
						transform2.position = new Vector3(x2, y2, position8.z);
						TOGGLE_unitUniqueBehaviour = 0;
					}
				}
				break;
			}
			int tOGGLE2_unitUniqueBehaviour = TOGGLE2_unitUniqueBehaviour;
			if (tOGGLE2_unitUniqueBehaviour == 1)
			{
				TOGGLE_unitUniqueBehaviour = 1;
				TOGGLE2_unitUniqueBehaviour = 0;
			}
			if (unitUniqueBehaviourAmountA == 0f && TOGGLE_healthValue > attributeHealthValue)
			{
				TOGGLE2_unitUniqueBehaviour = 1;
				TOGGLE_healthValue = attributeHealthValue;
			}
			break;
		}
		}
	}

	private void unitUniqueBehaviourFade()
	{
		switch (state)
		{
		case 2:
			break;
		case 0:
			POSITION_unitUniqueBehaviour = scriptCharacterAnimation.originalColor.a;
			TOGGLE_healthValue = attributeHealthMaximumValue;
			TOGGLE_unitUniqueBehaviour = 0;
			break;
		case 1:
			if (unitState == 4 || unitColorState != 0)
			{
				scriptCharacterAnimation.originalColor.a = POSITION_unitUniqueBehaviour;
				TOGGLE_unitUniqueBehaviour = 0;
				break;
			}
			switch (TOGGLE_unitUniqueBehaviour)
			{
			case 0:
				TIMER_unitUniqueBehaviour = Time.time + unitUniqueBehaviourAmountC / 2f;
				scriptCharacterAnimation.originalColor.a = POSITION_unitUniqueBehaviour;
				TOGGLE_unitUniqueBehaviour++;
				break;
			case 1:
				if (Time.time >= TIMER_unitUniqueBehaviour)
				{
					TOGGLE_unitUniqueBehaviour++;
				}
				break;
			case 2:
				if (scriptCharacterAnimation.originalColor.a > 0f)
				{
					scriptCharacterAnimation.originalColor.a -= unitUniqueBehaviourAmountB / 255f;
				}
				else if (scriptCharacterAnimation.originalColor.a <= 0f)
				{
					scriptCharacterAnimation.originalColor.a = 0f;
					TOGGLE_unitUniqueBehaviour++;
				}
				break;
			case 3:
				scriptCharacterAnimation.originalColor.a = 0f;
				TIMER_unitUniqueBehaviour = Time.time + unitUniqueBehaviourAmountD;
				TOGGLE_unitUniqueBehaviour++;
				break;
			case 4:
				if (Time.time >= TIMER_unitUniqueBehaviour)
				{
					TOGGLE_unitUniqueBehaviour++;
				}
				break;
			case 5:
				if (scriptCharacterAnimation.originalColor.a < POSITION_unitUniqueBehaviour)
				{
					scriptCharacterAnimation.originalColor.a += unitUniqueBehaviourAmountB / 255f;
				}
				else if (scriptCharacterAnimation.originalColor.a >= POSITION_unitUniqueBehaviour)
				{
					scriptCharacterAnimation.originalColor.a = POSITION_unitUniqueBehaviour;
					TOGGLE_unitUniqueBehaviour++;
				}
				break;
			case 6:
				scriptCharacterAnimation.originalColor.a = POSITION_unitUniqueBehaviour;
				TIMER_unitUniqueBehaviour = Time.time + unitUniqueBehaviourAmountC;
				TOGGLE_unitUniqueBehaviour++;
				break;
			case 7:
				if (Time.time >= TIMER_unitUniqueBehaviour)
				{
					TOGGLE_unitUniqueBehaviour = 2;
				}
				break;
			}
			if (unitUniqueBehaviourAmountA == 0f && TOGGLE_healthValue > attributeHealthValue)
			{
				scriptCharacterAnimation.originalColor.a = POSITION_unitUniqueBehaviour;
				TOGGLE_unitUniqueBehaviour = 0;
				TOGGLE_healthValue = attributeHealthValue;
			}
			break;
		}
	}

	private void StateRetreat()
	{
		if (TOGGLE_state != state)
		{
			if (unitRetreatBehaviour == -1)
			{
				RANDOM_unitRetreatBehaviour = UnityEngine.Random.Range(0, 100);
			}
			TOGGLE_unitRetreatBehaviour = unitRetreatBehaviour;
			RANDOM_riseSpeed = UnityEngine.Random.Range(1, 5);
			ResetAttribute();
			TOGGLE_state = state;
		}
		if (GetComponent<Collider>().enabled)
		{
			GetComponent<Collider>().enabled = false;
		}
		Vector3 position = myTransform.position;
		if (position.z != 0.5f)
		{
			scriptCharacterAnimation.spriteColor = Color.grey;
			Transform transform = scriptCharacterAnimation.transform;
			Vector3 localPosition = scriptCharacterAnimation.transform.localPosition;
			float y = localPosition.y;
			Vector3 localPosition2 = scriptCharacterAnimation.transform.localPosition;
			transform.localPosition = new Vector3(0f, y, localPosition2.z);
			Transform transform2 = myTransform;
			Vector3 position2 = myTransform.position;
			float x = position2.x;
			Vector3 position3 = myTransform.position;
			transform2.position = new Vector3(x, position3.y, 0.5f);
		}
		switch (TOGGLE_unitRetreatBehaviour)
		{
		case -1:
			if (RANDOM_unitRetreatBehaviour > 50f)
			{
				TOGGLE_unitRetreatBehaviour = 0;
			}
			else if (RANDOM_unitRetreatBehaviour <= 50f)
			{
				TOGGLE_unitRetreatBehaviour = 1;
			}
			break;
		case 0:
			scriptCharacterAnimation.AnimationNumber = 11;
			myTransform.Translate(-myTransform.forward * (attributeMovementSpeed + 1.5f) * Time.smoothDeltaTime, Space.World);
			break;
		case 1:
			scriptCharacterAnimation.AnimationNumber = 12;
			scriptCharacterAnimation.transform.Rotate(0f, 0f, 5f * Time.timeScale);
			scriptCharacterAnimation.transform.Translate(myTransform.up * (RANDOM_riseSpeed * 0.4f) * Time.smoothDeltaTime, Space.World);
			myTransform.Translate(-myTransform.forward * (attributeMovementSpeed + 2.5f) * Time.smoothDeltaTime, Space.World);
			break;
		case 2:
			retreatBehaviourMiddleDespawn();
			break;
		}
	}

	private void retreatBehaviourMiddleDespawn()
	{
		scriptCharacterAnimation.AnimationNumber = 11;
		if (unitDefaultAltitude < unitRetreatBehaviourAmountB)
		{
			myTransform.Translate(myTransform.up * unitRetreatBehaviourAmountA * Time.smoothDeltaTime, Space.World);
			Vector3 position = myTransform.position;
			if (position.y >= unitRetreatBehaviourAmountB)
			{
				state = 3;
			}
		}
		else if (unitDefaultAltitude > unitRetreatBehaviourAmountB)
		{
			myTransform.Translate(-myTransform.up * unitRetreatBehaviourAmountA * Time.smoothDeltaTime, Space.World);
			Vector3 position2 = myTransform.position;
			if (position2.y <= unitRetreatBehaviourAmountB)
			{
				state = 3;
			}
		}
	}

	private void ResetAttribute()
	{
		attackAmount = 0;
		TOGGLE_attack = 0;
		TIMER_attackEndDelay = 0f;
	}

	private void StateNormal()
	{
		if (TOGGLE_state != state)
		{
			TOGGLE_state = state;
		}
		switch (unitState)
		{
		case -1:
			break;
		case 5:
			break;
		case 0:
			ActionFunction();
			break;
		case 1:
			MovementFunction();
			OffenseDetection();
			break;
		case 2:
			OffenseFunction();
			OffenseDetection();
			break;
		case 3:
			DefenseFunction();
			OffenseDetection();
			break;
		case 4:
			DisableFunction();
			break;
		}
	}

	private void UnitEffectFunction()
	{
		UnitColorFunction();
		UnitEffectKnock();
		UnitEffectRise();
		UnitEffectDisable();
		UnitEffectColor();
	}

	private void AttributeEffectFunction()
	{
		AttributePropDisplay();
		AttributeEffectHP();
		AttributeOverTimeEffectHP();
		AttributeEffectMP();
		AttributeEffectDMG();
		AttributeEffectMS();
		AttributeEffectAS();
		AttributeEffectAP();
		AttributeEffectANP();
		AttributeEffectMRP();
		AttributeEffectCRP();
		AttributeEffectACP();
		AttributeEffectEVP();
		AttributeManaRegenFunction();
		AttributeStatePerksFunction();
	}

	private void UnitActionFunction()
	{
		UnitActionTaunt();
		UnitActionDash();
	}

	private void ActionFunction()
	{
		if (TOGGLE_unitState != unitState)
		{
			TOGGLE_unitState = unitState;
		}
		if (TOGGLE_unitActionDash == 0 && TOGGLE_unitActionTaunt == 0 && TOGGLE_unitIdle != 1)
		{
			unitState = 1;
		}
	}

	private void DefenseFunction()
	{
		if (TOGGLE_unitState != unitState)
		{
			TOGGLE_unitState = unitState;
		}
		scriptCharacterAnimation.AnimationNumber = 13;
	}

	private void AttributeStatePerksFunction()
	{
		switch (unitState)
		{
		case 0:
			if (scriptUnitAttribute.plusUnitStateArmorPoint != -1)
			{
				scriptUnitAttribute.plusUnitStateArmorPoint = -1;
			}
			if (scriptUnitAttribute.plusUnitStateAnchorPoint != -1)
			{
				scriptUnitAttribute.plusUnitStateAnchorPoint = -1;
			}
			break;
		case 1:
			if (scriptUnitAttribute.plusUnitStateArmorPoint != 0)
			{
				scriptUnitAttribute.plusUnitStateArmorPoint = 0;
			}
			if (scriptUnitAttribute.plusUnitStateAnchorPoint != 0)
			{
				scriptUnitAttribute.plusUnitStateAnchorPoint = 0;
			}
			break;
		case 2:
			if (scriptUnitAttribute.plusUnitStateArmorPoint != -1)
			{
				scriptUnitAttribute.plusUnitStateArmorPoint = -1;
			}
			if (scriptUnitAttribute.plusUnitStateAnchorPoint != -1)
			{
				scriptUnitAttribute.plusUnitStateAnchorPoint = -1;
			}
			break;
		case 3:
			if (scriptUnitAttribute.plusUnitStateArmorPoint != 3 + scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].defendPlusArmorPoint)
			{
				scriptUnitAttribute.plusUnitStateArmorPoint = 3 + scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].defendPlusArmorPoint;
			}
			if (scriptUnitAttribute.plusUnitStateAnchorPoint != 2 + scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].defendPlusAnchorPoint)
			{
				scriptUnitAttribute.plusUnitStateAnchorPoint = 2 + scriptUnitAttribute.Offense[scriptUnitAttribute.unitOffenseNumber].defendPlusAnchorPoint;
			}
			break;
		case 4:
			if (scriptUnitAttribute.plusUnitStateArmorPoint != -2)
			{
				scriptUnitAttribute.plusUnitStateArmorPoint = -2;
			}
			if (scriptUnitAttribute.plusUnitStateAnchorPoint != -2)
			{
				scriptUnitAttribute.plusUnitStateAnchorPoint = -2;
			}
			break;
		}
	}

	private void DisableFunction()
	{
		if (TOGGLE_unitState != unitState)
		{
			statusDisabledCount++;
			TOGGLE_unitState = unitState;
		}
		if (TOGGLE_unitEffectDisable == 0 && TOGGLE_unitEffectKnock == 0)
		{
			unitState = 1;
		}
		scriptCharacterAnimation.AnimationNumber = 10;
	}

	private void AltitudeControlFunction()
	{
		if (state > 0 && TOGGLE_unitEffectRise == 0 && TOGGLE_unitRetreatBehaviour <= 0 && unitAltitudeType == 0 && TOGGLE_unitEntranceBehaviour == 0)
		{
			if (unitUniqueBehaviour != 2)
			{
				unitGravityState = 1;
			}
			else if (unitUniqueBehaviour == 2)
			{
				if (TOGGLE_unitUniqueBehaviour == 0)
				{
					unitGravityState = 1;
				}
				else
				{
					unitGravityState = 0;
				}
			}
			else
			{
				unitGravityState = 0;
			}
		}
		else
		{
			unitGravityState = 0;
		}
		if (state > 0 && TOGGLE_unitEffectRise == 0)
		{
			switch (unitGravityState)
			{
			case 0:
				if (VELOCITY_altitubeControl != 0f)
				{
					VELOCITY_altitubeControl = 0f;
				}
				break;
			case 1:
				{
					Vector3 position = myTransform.position;
					if (position.y > unitDefaultAltitude)
					{
						Vector3 position2 = myTransform.position;
						if (position2.y < 1f)
						{
							if (AMOUNT_altitubeControl < 0)
							{
								AMOUNT_altitubeControl = 0;
							}
						}
						else
						{
							Vector3 position3 = myTransform.position;
							if (position3.y >= 1f)
							{
								Vector3 position4 = myTransform.position;
								if (position4.y < 1.6f)
								{
									if (AMOUNT_altitubeControl < scriptUnitAttribute.unitStatisticWeightClass * 2)
									{
										AMOUNT_altitubeControl = scriptUnitAttribute.unitStatisticWeightClass * 2;
									}
									goto IL_0256;
								}
							}
							Vector3 position5 = myTransform.position;
							if (position5.y >= 1.4f)
							{
								Vector3 position6 = myTransform.position;
								if (position6.y < 2.4f)
								{
									if (AMOUNT_altitubeControl < scriptUnitAttribute.unitStatisticWeightClass * 3)
									{
										AMOUNT_altitubeControl = scriptUnitAttribute.unitStatisticWeightClass * 3;
									}
									goto IL_0256;
								}
							}
							Vector3 position7 = myTransform.position;
							if (position7.y >= 2.4f && AMOUNT_altitubeControl < scriptUnitAttribute.unitStatisticWeightClass * 4)
							{
								AMOUNT_altitubeControl = scriptUnitAttribute.unitStatisticWeightClass * 4;
							}
						}
						goto IL_0256;
					}
					Vector3 position8 = myTransform.position;
					if (position8.y < unitDefaultAltitude)
					{
						Transform transform = myTransform;
						Vector3 position9 = myTransform.position;
						float x = position9.x;
						float y = unitDefaultAltitude;
						Vector3 position10 = myTransform.position;
						transform.position = new Vector3(x, y, position10.z);
						break;
					}
					Vector3 position11 = myTransform.position;
					if (position11.y == unitDefaultAltitude)
					{
						if (VELOCITY_altitubeControl != 0f)
						{
							VELOCITY_altitubeControl = 0f;
						}
						if (AMOUNT_altitubeControl > 0)
						{
							AttributeEffectHP(1, AMOUNT_altitubeControl, 0);
							AMOUNT_altitubeControl = 0;
						}
					}
					break;
				}
				IL_0256:
				VELOCITY_altitubeControl += statisticWeightValue;
				myTransform.Translate(-myTransform.up * VELOCITY_altitubeControl * Time.smoothDeltaTime, Space.World);
				break;
			}
		}
		else if (VELOCITY_altitubeControl != 0f)
		{
			AMOUNT_altitubeControl = 0;
			VELOCITY_altitubeControl = 0f;
		}
	}

	private void MovementFunction()
	{
		if (TOGGLE_unitState != unitState)
		{
			VELOCITY_attributeMovementSpeed = 0f;
			TOGGLE_unitState = unitState;
		}
		if (TOGGLE_movementType != CONTROL_movementType)
		{
			VELOCITY_attributeMovementSpeed = 0f;
			TOGGLE_movementType = CONTROL_movementType;
		}
		switch (TOGGLE_unitDestinationPosition)
		{
		case 0:
			switch (CONTROL_movementType)
			{
			case -2:
				scriptCharacterAnimation.AnimationNumber = 1;
				myTransform.Translate(-myTransform.forward * VELOCITY_attributeMovementSpeed * 2f * Time.smoothDeltaTime, Space.World);
				break;
			case -1:
				scriptCharacterAnimation.AnimationNumber = 3;
				myTransform.Translate(-myTransform.forward * VELOCITY_attributeMovementSpeed * Time.smoothDeltaTime, Space.World);
				break;
			case 0:
				scriptCharacterAnimation.AnimationNumber = 0;
				if (VELOCITY_attributeMovementSpeed != 0f)
				{
					VELOCITY_attributeMovementSpeed = 0f;
				}
				break;
			case 1:
				scriptCharacterAnimation.AnimationNumber = 3;
				myTransform.Translate(myTransform.forward * VELOCITY_attributeMovementSpeed * Time.smoothDeltaTime, Space.World);
				break;
			case 2:
				scriptCharacterAnimation.AnimationNumber = 1;
				myTransform.Translate(myTransform.forward * VELOCITY_attributeMovementSpeed * 2f * Time.smoothDeltaTime, Space.World);
				break;
			}
			break;
		case 1:
			scriptCharacterAnimation.AnimationNumber = 0;
			if (VELOCITY_attributeMovementSpeed != 0f)
			{
				VELOCITY_attributeMovementSpeed = 0f;
			}
			break;
		case 2:
			switch (CONTROL_movementType)
			{
			case -2:
				scriptCharacterAnimation.AnimationNumber = 1;
				myTransform.Translate(myTransform.forward * VELOCITY_attributeMovementSpeed * 2f * Time.smoothDeltaTime, Space.World);
				break;
			case -1:
				scriptCharacterAnimation.AnimationNumber = 3;
				myTransform.Translate(myTransform.forward * VELOCITY_attributeMovementSpeed * Time.smoothDeltaTime, Space.World);
				break;
			case 0:
				scriptCharacterAnimation.AnimationNumber = 0;
				if (VELOCITY_attributeMovementSpeed != 0f)
				{
					VELOCITY_attributeMovementSpeed = 0f;
				}
				break;
			case 1:
				scriptCharacterAnimation.AnimationNumber = 3;
				myTransform.Translate(-myTransform.forward * VELOCITY_attributeMovementSpeed * Time.smoothDeltaTime, Space.World);
				break;
			case 2:
				scriptCharacterAnimation.AnimationNumber = 1;
				myTransform.Translate(-myTransform.forward * VELOCITY_attributeMovementSpeed * 2f * Time.smoothDeltaTime, Space.World);
				break;
			}
			break;
		}
		if (TOGGLE_unitHexEffect == 0)
		{
			if (VELOCITY_attributeMovementSpeed < attributeMovementSpeed)
			{
				VELOCITY_attributeMovementSpeed += attributeMovementSpeed * 0.01f * attributeMovementVelocity;
			}
			else if (VELOCITY_attributeMovementSpeed >= attributeMovementSpeed)
			{
				VELOCITY_attributeMovementSpeed = attributeMovementSpeed;
			}
		}
		else if (VELOCITY_attributeMovementSpeed < MOVEMENTSPEED_unitHexEffect)
		{
			VELOCITY_attributeMovementSpeed += MOVEMENTSPEED_unitHexEffect * 0.01f * attributeMovementVelocity;
		}
		else if (VELOCITY_attributeMovementSpeed >= MOVEMENTSPEED_unitHexEffect)
		{
			VELOCITY_attributeMovementSpeed = MOVEMENTSPEED_unitHexEffect;
		}
	}

	private void AirMotionFunction()
	{
		if (state != 1)
		{
			TOGGLE_airMotion = 0;
			TOGGLE_airMotionState = 0;
			TRANSFORM_airMotion = 0f;
			return;
		}
		if (TOGGLE_unitHexEffect == 0)
		{
			if (unitAltitudeType != 0 && unitAltitudeAirMotionSpeed > 0f && TOGGLE_unitEntranceBehaviour == 0)
			{
				if (unitUniqueBehaviour != 2)
				{
					airMotionState = 1;
				}
				else if (unitUniqueBehaviour == 2)
				{
					if (TOGGLE_unitUniqueBehaviour == 0)
					{
						airMotionState = 1;
					}
					else
					{
						airMotionState = 0;
					}
				}
				else
				{
					airMotionState = 0;
				}
			}
			else
			{
				airMotionState = 0;
			}
			if (unitAltitudeType != 0 && unitAltitudeAirMotionSpeed > 0f)
			{
				int num = airMotionState;
				if (num == 1)
				{
					Transform transform = myTransform;
					Vector3 localPosition = myTransform.localPosition;
					float x = localPosition.x;
					float y = unitDefaultAltitude + TRANSFORM_airMotion;
					Vector3 localPosition2 = myTransform.localPosition;
					transform.localPosition = new Vector3(x, y, localPosition2.z);
					switch (TOGGLE_airMotionState)
					{
					case 0:
						if (unitState != 4 || unitAltitudeAirDisableDropSpeed == 0f)
						{
							switch (TOGGLE_airMotion)
							{
							case 0:
								if (TRANSFORM_airMotion < unitAltitudeAirHeightThreshold)
								{
									if (TRANSFORM_airMotion < 0f)
									{
										if (VELOCITY_airMotionDisableDropRecoveryRiseSpeed < 2f)
										{
											VELOCITY_airMotionDisableDropRecoveryRiseSpeed += 0.1f;
										}
										TRANSFORM_airMotion += unitAltitudeAirMotionSpeed * VELOCITY_airMotionDisableDropRecoveryRiseSpeed;
									}
									else if (VELOCITY_airMotionDisableDropRecoveryRiseSpeed > 1f)
									{
										VELOCITY_airMotionDisableDropRecoveryRiseSpeed -= 0.01f;
										TRANSFORM_airMotion += unitAltitudeAirMotionSpeed * VELOCITY_airMotionDisableDropRecoveryRiseSpeed;
									}
									else
									{
										TRANSFORM_airMotion += unitAltitudeAirMotionSpeed;
									}
								}
								else if (TRANSFORM_airMotion >= unitAltitudeAirHeightThreshold)
								{
									TOGGLE_airMotion = 1;
								}
								break;
							case 1:
								if (TRANSFORM_airMotion > 0f)
								{
									TRANSFORM_airMotion -= unitAltitudeAirMotionSpeed;
								}
								else if (TRANSFORM_airMotion <= 0f)
								{
									TOGGLE_airMotion = 0;
								}
								break;
							}
						}
						else
						{
							TOGGLE_airMotionState = 1;
						}
						break;
					case 1:
						if (unitState == 4)
						{
							VELOCITY_airMotionDisableDropSpeed = 0f - unitAltitudeAirDisableDropSpeed;
							Vector3 position3 = myTransform.position;
							if (position3.y > unitAltitudeAirDisableDropThreshold)
							{
								TRANSFORM_airMotion -= unitAltitudeAirDisableDropSpeed;
							}
						}
						else
						{
							TOGGLE_airMotionState = 2;
						}
						break;
					case 2:
						if (unitState != 4)
						{
							if (VELOCITY_airMotionDisableDropSpeed < 0f)
							{
								VELOCITY_airMotionDisableDropSpeed += unitAltitudeAirMotionSpeed * VELOCITY_airMotionDisableDropRecoverySpeed;
								Vector3 position = myTransform.position;
								if (position.y > unitAltitudeAirDisableDropThreshold)
								{
									TRANSFORM_airMotion += VELOCITY_airMotionDisableDropSpeed;
								}
							}
							else if (VELOCITY_airMotionDisableDropSpeed < unitAltitudeAirMotionSpeed && VELOCITY_airMotionDisableDropSpeed >= 0f)
							{
								VELOCITY_airMotionDisableDropSpeed += unitAltitudeAirMotionSpeed * VELOCITY_airMotionDisableDropRecoverySpeed;
								Vector3 position2 = myTransform.position;
								if (position2.y > unitAltitudeAirDisableDropThreshold)
								{
									TRANSFORM_airMotion += VELOCITY_airMotionDisableDropSpeed;
								}
							}
							else if (VELOCITY_airMotionDisableDropSpeed >= unitAltitudeAirMotionSpeed)
							{
								VELOCITY_airMotionDisableDropRecoveryRiseSpeed = 1f;
								TOGGLE_airMotion = 0;
								TOGGLE_airMotionState = 0;
							}
						}
						else
						{
							TOGGLE_airMotionState = 1;
						}
						break;
					}
				}
			}
			if (VELOCITY_altitubeControl != 0f)
			{
				VELOCITY_altitubeControl = 0f;
			}
			return;
		}
		if (state > 0 && TOGGLE_unitEffectRise == 0)
		{
			switch (WEIGHT_unitHexEffect)
			{
			case -3:
				WEIGHTVALUE_unitHexEffect = 0.001f;
				break;
			case -2:
				WEIGHTVALUE_unitHexEffect = 0.005f;
				break;
			case -1:
				WEIGHTVALUE_unitHexEffect = 0.01f;
				break;
			case 0:
				WEIGHTVALUE_unitHexEffect = 0.05f;
				break;
			case 1:
				WEIGHTVALUE_unitHexEffect = 0.1f;
				break;
			case 2:
				WEIGHTVALUE_unitHexEffect = 0.2f;
				break;
			case 3:
				WEIGHTVALUE_unitHexEffect = 0.4f;
				break;
			}
			Vector3 position4 = myTransform.position;
			if (position4.y > 0.35f)
			{
				Vector3 position5 = myTransform.position;
				if (position5.y < 1f)
				{
					if (AMOUNT_altitubeControl < 0)
					{
						AMOUNT_altitubeControl = 0;
					}
				}
				else
				{
					Vector3 position6 = myTransform.position;
					if (position6.y >= 1f)
					{
						Vector3 position7 = myTransform.position;
						if (position7.y < 1.6f)
						{
							if (AMOUNT_altitubeControl < WEIGHT_unitHexEffect * 2)
							{
								AMOUNT_altitubeControl = WEIGHT_unitHexEffect * 2;
							}
							goto IL_0652;
						}
					}
					Vector3 position8 = myTransform.position;
					if (position8.y >= 1.4f)
					{
						Vector3 position9 = myTransform.position;
						if (position9.y < 2.4f)
						{
							if (AMOUNT_altitubeControl < WEIGHT_unitHexEffect * 3)
							{
								AMOUNT_altitubeControl = WEIGHT_unitHexEffect * 3;
							}
							goto IL_0652;
						}
					}
					Vector3 position10 = myTransform.position;
					if (position10.y >= 2.4f && AMOUNT_altitubeControl < WEIGHT_unitHexEffect * 4)
					{
						AMOUNT_altitubeControl = WEIGHT_unitHexEffect * 4;
					}
				}
				goto IL_0652;
			}
			Vector3 position11 = myTransform.position;
			if (position11.y < 0.35f)
			{
				Transform transform2 = myTransform;
				Vector3 position12 = myTransform.position;
				float x2 = position12.x;
				Vector3 position13 = myTransform.position;
				transform2.position = new Vector3(x2, 0.35f, position13.z);
			}
			else
			{
				Vector3 position14 = myTransform.position;
				if (position14.y == unitDefaultAltitude)
				{
					if (VELOCITY_altitubeControl != 0f)
					{
						VELOCITY_altitubeControl = 0f;
					}
					if (AMOUNT_altitubeControl > 0)
					{
						AttributeEffectHP(1, AMOUNT_altitubeControl, 0);
						AMOUNT_altitubeControl = 0;
					}
				}
			}
			goto IL_0756;
		}
		goto IL_0769;
		IL_0769:
		Vector3 position15 = myTransform.position;
		if (position15.y > 3.8f)
		{
			Transform transform3 = myTransform;
			Vector3 position16 = myTransform.position;
			float x3 = position16.x;
			Vector3 position17 = myTransform.position;
			transform3.position = new Vector3(x3, 3.8f, position17.z);
		}
		Vector3 position18 = myTransform.position;
		TRANSFORM_airMotion = position18.y - unitDefaultAltitude;
		return;
		IL_0756:
		if (airMotionState != 2)
		{
			airMotionState = 2;
		}
		goto IL_0769;
		IL_0652:
		VELOCITY_altitubeControl += WEIGHTVALUE_unitHexEffect;
		myTransform.Translate(-myTransform.up * VELOCITY_altitubeControl * Time.smoothDeltaTime, Space.World);
		goto IL_0756;
	}

	private void OffenseFunction()
	{
		if (TOGGLE_unitState != unitState)
		{
			scriptCharacterAnimation.AnimationNumber = 6;
			TIMER_attackDelay = Time.time + attackStartDelay;
			TOGGLE_unitState = unitState;
		}
		int tOGGLE_attack = TOGGLE_attack;
		if (tOGGLE_attack == 0 || tOGGLE_attack != 1 || Time.time < TIMER_attackDelay + attributeAttackSpeedDelay)
		{
			return;
		}
		if (Time.time >= TIMER_attackDelay + attributeAttackSpeedDelay)
		{
			if (attributeManaValue >= attackManaCost * -1)
			{
				ROLL_attributeAccuracyValue = UnityEngine.Random.Range(0, 100);
				ROLL_attributeCriticalValue = UnityEngine.Random.Range(0, 100);
				scriptCharacterAnimation.AnimationNumber = 7;
				if (ROLL_attributeAccuracyValue <= attributeAccuracyValue || unitOffenseAction == 2)
				{
					if (attackSpawnObject != null)
					{
						if (attackPosition != null)
						{
							INST_attackTrigger = PoolManager.Pools["Effect Pool"].Spawn(attackSpawnObject.transform, attackPosition.position, attackPosition.transform.rotation);
						}
						else
						{
							INST_attackTrigger = PoolManager.Pools["Effect Pool"].Spawn(attackSpawnObject.transform, VECTOR_alignmentAttackSpawnPosition, attackSpawnObject.transform.rotation);
						}
						if (INST_attackTrigger.GetComponent<_Trigger>() != null)
						{
							if (ROLL_attributeCriticalValue <= attributeCriticalValue)
							{
								scriptUnitAttribute.TriggerTransfer(INST_attackTrigger.GetComponent<_Trigger>(), 3);
							}
							else
							{
								scriptUnitAttribute.TriggerTransfer(INST_attackTrigger.GetComponent<_Trigger>(), 0);
							}
						}
					}
					int num = unitOffenseAction;
					if (num == 2)
					{
						scriptUnitAttribute.enableRetreatDrop = 0;
						scriptUnitAttribute.enableRetreatEffect = 0;
						attributeHealthValue = -1;
					}
					statusAttackCount++;
				}
				else if (ROLL_attributeAccuracyValue > attributeAccuracyValue)
				{
					UnitEffectPropDisplay(2, string.Empty, 0);
				}
				if (attackHealthCost < 0)
				{
					AttributeEffectHP(3, attackHealthCost * -1, 0);
				}
				else if (attackHealthCost > 0)
				{
					AttributeEffectHP(2, attackHealthCost, 0);
				}
				if (attackManaCost < 0)
				{
					AttributeEffectMP(1, attackManaCost * -1);
				}
				else if (attackManaCost > 0)
				{
					AttributeEffectMP(2, attackManaCost);
				}
				attackAmount++;
			}
			else
			{
				UnitEffectPropDisplay(4, string.Empty, 0);
			}
			TIMER_attackDelay = Time.time + attackDelay;
		}
		TIMER_attackEndDelay = Time.time + attackEndDelay;
	}

	private void OffenseDetection()
	{
		switch (offenseDetectionState)
		{
		case -1:
			offenseDetectionState = 0;
			break;
		case 0:
			if (TOGGLE_unitHexEffect != 0 || Time.time < TIMER_rayFPS || !(Time.time >= TIMER_rayFPS))
			{
				break;
			}
			if (attackRange > 0f)
			{
				Vector3 direction = myTransform.TransformDirection(Vector3.forward);
				Vector3 vECTOR_rayPointAttack = VECTOR_rayPointAttack;
				if (Physics.Raycast(vECTOR_rayPointAttack, direction, out RaycastHit hitInfo, attackRange))
				{
					UnityEngine.Debug.DrawLine(vECTOR_rayPointAttack, vECTOR_rayPointAttack + myTransform.forward * hitInfo.distance, Color.green);
					switch (unitOffenseAction)
					{
					case 0:
						if (unitState != 2)
						{
							unitState = 2;
						}
						if (TOGGLE_attack != 1)
						{
							TOGGLE_attack = 1;
						}
						break;
					case 1:
						if (unitState != 3)
						{
							unitState = 3;
						}
						TIMER_attackEndDelay = Time.time + attackEndDelay;
						break;
					case 2:
						if (unitState != 2)
						{
							unitState = 2;
						}
						if (TOGGLE_attack != 1)
						{
							TOGGLE_attack = 1;
						}
						break;
					case 3:
						if (unitState != 2)
						{
							unitState = 2;
						}
						if (TOGGLE_attack != 1)
						{
							TOGGLE_attack = 1;
						}
						break;
					case 4:
						if (unitState != 2)
						{
							unitState = 2;
						}
						if (TOGGLE_attack != 1)
						{
							TOGGLE_attack = 1;
						}
						break;
					case 5:
						if (CONTROL_movementType != 0)
						{
							CONTROL_movementType = 0;
						}
						break;
					case 6:
						if (unitState != 0)
						{
							CONTROL_movementType = 0;
						}
						break;
					}
				}
				else
				{
					UnityEngine.Debug.DrawLine(vECTOR_rayPointAttack, vECTOR_rayPointAttack + myTransform.forward * attackRange, Color.red);
					if (Time.time < TIMER_attackEndDelay)
					{
						if (TOGGLE_attack != 0)
						{
							TOGGLE_attack = 0;
						}
					}
					else if (Time.time >= TIMER_attackEndDelay)
					{
						if (unitState != 1)
						{
							unitState = 1;
						}
						if (CONTROL_movementType != unitMovementType)
						{
							CONTROL_movementType = unitMovementType;
						}
					}
				}
			}
			else if (CONTROL_movementType != unitMovementType)
			{
				CONTROL_movementType = unitMovementType;
			}
			if (attackRangeDistance > 0f)
			{
				Vector3 direction2 = myTransform.TransformDirection(Vector3.forward);
				Vector3 vECTOR_rayPointAttackDistance = VECTOR_rayPointAttackDistance;
				if (Physics.Raycast(vECTOR_rayPointAttackDistance, direction2, out RaycastHit hitInfo2, attackRangeDistance))
				{
					UnityEngine.Debug.DrawLine(vECTOR_rayPointAttackDistance, vECTOR_rayPointAttackDistance + myTransform.forward * hitInfo2.distance, Color.green);
					if (unitState != 1)
					{
						unitState = 1;
					}
					if (CONTROL_movementType != -unitMovementType)
					{
						CONTROL_movementType = -unitMovementType;
					}
				}
				else
				{
					UnityEngine.Debug.DrawLine(vECTOR_rayPointAttackDistance, vECTOR_rayPointAttackDistance + myTransform.forward * attackRangeDistance, Color.cyan);
				}
			}
			TIMER_rayFPS = Time.time + 0.05f;
			break;
		}
	}

	private void UnitToggleColorFunction(int colorState)
	{
		if (colorState > 0)
		{
			switch (colorState)
			{
			case 1:
				unitColorState = colorState;
				TIMER_unitColorState = Time.time + 0.5f;
				break;
			case 2:
				unitColorState = colorState;
				TIMER_unitColorState = Time.time + 1f;
				break;
			case 3:
				unitColorState = 1;
				TIMER_unitColorState = Time.time + 0.25f;
				break;
			case 4:
				unitColorState = 2;
				TIMER_unitColorState = Time.time + 0.25f;
				break;
			case 5:
				unitColorState = 3;
				TIMER_unitColorState = Time.time + 0.2f;
				break;
			}
			colorState = 0;
		}
	}

	private void UnitColorFunction()
	{
		switch (state)
		{
		case 0:
			unitColorState = 0;
			TIMER_unitColorState = 0f;
			break;
		case 1:
			switch (unitColorState)
			{
			case -1:
				if (TOGGLE_unitEffectColor != 1)
				{
					unitColorState = 0;
				}
				break;
			case 0:
				if (scriptCharacterAnimation.spriteColor != COLOR_unitColorDefault)
				{
					scriptCharacterAnimation.spriteColor = COLOR_unitColorDefault;
				}
				break;
			case 1:
				if (Time.time < TIMER_unitColorState)
				{
					scriptCharacterAnimation.spriteColor = COLOR_unitColorDamaged;
				}
				else if (Time.time >= TIMER_unitColorState)
				{
					unitColorState = -1;
				}
				break;
			case 2:
				if (Time.time < TIMER_unitColorState)
				{
					scriptCharacterAnimation.spriteColor = COLOR_unitColorHeal;
				}
				else if (Time.time >= TIMER_unitColorState)
				{
					unitColorState = -1;
				}
				break;
			case 3:
				if (Time.time < TIMER_unitColorState)
				{
					scriptCharacterAnimation.spriteColor = COLOR_unitColorMana;
				}
				else if (Time.time >= TIMER_unitColorState)
				{
					unitColorState = -1;
				}
				break;
			}
			break;
		case 2:
			if (scriptCharacterAnimation.spriteColor != Color.gray)
			{
				scriptCharacterAnimation.spriteColor = Color.gray;
			}
			break;
		}
	}

	public void UnitActionTaunt(int Toggle, int Duration)
	{
		if (state == 1 && unitState != 4)
		{
			switch (Toggle)
			{
			case 1:
				scriptCharacterAnimation.AnimationNumber = 13;
				TIMER_unitActionTaunt = Time.time + (float)Duration;
				TOGGLE_unitActionTaunt = 1;
				unitState = 0;
				Toggle = 0;
				break;
			case 2:
				scriptCharacterAnimation.AnimationNumber = 13;
				TOGGLE_unitActionTaunt = 2;
				unitState = 0;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitActionTaunt()
	{
		switch (TOGGLE_unitActionTaunt)
		{
		case 0:
			break;
		case 2:
			break;
		case -1:
			TIMER_unitActionTaunt = 0f;
			TOGGLE_unitActionTaunt = 0;
			break;
		case 1:
			if (!(Time.time < TIMER_unitActionTaunt) && Time.time >= TIMER_unitActionTaunt)
			{
				TOGGLE_unitActionTaunt = 0;
			}
			break;
		}
	}

	public void UnitActionDash(int Toggle, float Duration, float Distance, float Damping)
	{
		if (state == 1 && unitState != 4)
		{
			switch (Toggle)
			{
			case 1:
				TIMER_unitActionDash = Time.time + Duration;
				scriptCharacterAnimation.AnimationNumber = 4;
				switch (TOGGLE_unitAlignment)
				{
				case 0:
				{
					Vector3 localPosition4 = myTransform.localPosition;
					float x4 = localPosition4.x + Distance;
					Vector3 position4 = myTransform.position;
					VECTOR_unitActionDash = new Vector3(x4, position4.y, 0f);
					break;
				}
				case 1:
				{
					Vector3 localPosition3 = myTransform.localPosition;
					float x3 = localPosition3.x - Distance;
					Vector3 position3 = myTransform.position;
					VECTOR_unitActionDash = new Vector3(x3, position3.y, 0f);
					break;
				}
				}
				DAMPING_unitActionDash = Damping;
				TOGGLE_unitActionDash = Toggle;
				unitState = 0;
				Toggle = 0;
				break;
			case 2:
				TIMER_unitActionDash = Time.time + Duration;
				scriptCharacterAnimation.AnimationNumber = 5;
				switch (TOGGLE_unitAlignment)
				{
				case 0:
				{
					Vector3 localPosition2 = myTransform.localPosition;
					float x2 = localPosition2.x - Distance;
					Vector3 position2 = myTransform.position;
					VECTOR_unitActionDash = new Vector3(x2, position2.y, 0f);
					break;
				}
				case 1:
				{
					Vector3 localPosition = myTransform.localPosition;
					float x = localPosition.x + Distance;
					Vector3 position = myTransform.position;
					VECTOR_unitActionDash = new Vector3(x, position.y, 0f);
					break;
				}
				}
				DAMPING_unitActionDash = Damping;
				TOGGLE_unitActionDash = Toggle;
				unitState = 0;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitActionDash()
	{
		switch (TOGGLE_unitActionDash)
		{
		case 0:
			break;
		case -1:
			TIMER_unitActionDash = 0f;
			DAMPING_unitActionDash = 0f;
			TOGGLE_unitActionDash = 0;
			break;
		case 1:
			if (Time.time < TIMER_unitActionDash)
			{
				float x2 = VECTOR_unitActionDash.x;
				Vector3 position2 = myTransform.position;
				VECTOR_unitActionDash = new Vector3(x2, position2.y, 0f);
				myTransform.position = Vector3.Lerp(myTransform.position, VECTOR_unitActionDash, Time.deltaTime * DAMPING_unitActionDash);
			}
			else if (Time.time >= TIMER_unitActionDash)
			{
				TOGGLE_unitActionDash = 0;
			}
			break;
		case 2:
			if (Time.time < TIMER_unitActionDash)
			{
				float x = VECTOR_unitActionDash.x;
				Vector3 position = myTransform.position;
				VECTOR_unitActionDash = new Vector3(x, position.y, 0f);
				myTransform.position = Vector3.Lerp(myTransform.position, VECTOR_unitActionDash, Time.deltaTime * DAMPING_unitActionDash);
			}
			else if (Time.time >= TIMER_unitActionDash)
			{
				TOGGLE_unitActionDash = 0;
			}
			break;
		}
	}

	private void AttributeManaRegenFunction()
	{
		switch (TOGGLE_attributeManaRegenFunction)
		{
		case -1:
			TOGGLE_attributeManaRegenFunction = 0;
			break;
		case 0:
			if (attributeManaValue < attributeManaMaximumValue)
			{
				TIMER_attributeManaRegenFunction = Time.time + 2f;
				AMOUNT_attributeManaRegenFunction = attributeManaRegenValue;
				TOGGLE_attributeManaRegenFunction = 1;
			}
			break;
		case 1:
			if (Time.time >= TIMER_attributeManaRegenFunction)
			{
				if (attributeManaValue + AMOUNT_attributeManaRegenFunction > attributeManaMaximumValue)
				{
					attributeManaValue = attributeManaMaximumValue;
				}
				else
				{
					attributeManaValue += AMOUNT_attributeManaRegenFunction;
				}
				TOGGLE_attributeManaRegenFunction = 0;
			}
			break;
		}
	}

	public void UnitEffectColor(int Toggle, Color colorCode, float duration)
	{
		if (state == 1)
		{
			int num = Toggle;
			if (num == 1)
			{
				unitColorState = -1;
				TIMER_unitEffectColor = Time.time + duration;
				COLOR_unitEffectColor = colorCode;
				TOGGLE_unitEffectColor = 1;
				Toggle = 0;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitEffectColor()
	{
		if (state == 1)
		{
			int tOGGLE_unitEffectColor = TOGGLE_unitEffectColor;
			if (tOGGLE_unitEffectColor == 0 || tOGGLE_unitEffectColor != 1)
			{
				return;
			}
			if (Time.time < TIMER_unitEffectColor)
			{
				if (unitColorState == -1)
				{
					scriptCharacterAnimation.spriteColor = COLOR_unitEffectColor;
				}
			}
			else if (Time.time >= TIMER_unitEffectColor)
			{
				TOGGLE_unitEffectColor = 0;
			}
		}
		else if (TOGGLE_unitEffectColor != 0)
		{
			TIMER_unitEffectColor = 0f;
			COLOR_unitEffectColor = Color.white;
			TOGGLE_unitEffectColor = 0;
		}
	}

	public void UnitEffectPropDisplay(int toggle, string text, int amount)
	{
		switch (toggle)
		{
		case 1:
			if (amount <= 0)
			{
				SIZE_effectTextDisplay = 2.5f;
				COLOR_effectTextDisplay = new Color(1f, 1f, 1f, 1f);
				FADE_effectTextDisplay = 0.05f;
			}
			else if (amount > 0 && amount <= 5)
			{
				SIZE_effectTextDisplay = 2.5f;
				COLOR_effectTextDisplay = new Color(1f, 0f, 0f, 1f);
				FADE_effectTextDisplay = 0.04f;
			}
			else if (amount > 5 && amount <= 10)
			{
				SIZE_effectTextDisplay = 3f;
				COLOR_effectTextDisplay = new Color(1f, 0.2f, 0f, 1f);
				FADE_effectTextDisplay = 0.03f;
			}
			else if (amount > 10 && amount <= 20)
			{
				SIZE_effectTextDisplay = 3.5f;
				COLOR_effectTextDisplay = new Color(1f, 0.4f, 0f, 1f);
				FADE_effectTextDisplay = 0.02f;
			}
			else if (amount > 20 && amount <= 30)
			{
				SIZE_effectTextDisplay = 4.5f;
				COLOR_effectTextDisplay = new Color(1f, 0.6f, 0f, 1f);
				FADE_effectTextDisplay = 0.01f;
			}
			else if (amount > 30)
			{
				SIZE_effectTextDisplay = 5.5f;
				COLOR_effectTextDisplay = new Color(1f, 0.8f, 0f, 1f);
				FADE_effectTextDisplay = 0.01f;
			}
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, effectPosition.transform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(effectPosition, 1, COLOR_effectTextDisplay, text, SIZE_effectTextDisplay, 0.1f, FADE_effectTextDisplay, 0.5f, 0.35f);
			toggle = 0;
			break;
		case 2:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, Color.white, "miss", 2f, 0.1f, 0.02f, -0.25f, 0f);
			toggle = 0;
			break;
		case 3:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(1f, 0.6f, 0f, 1f), "critical", 3f, 0.1f, 0.05f, -0.1f, 0f);
			toggle = 0;
			break;
		case 4:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.5f, 1f, 1f, 1f), "no mana", 2.25f, 0.1f, 0.02f, 0f, 0f);
			toggle = 0;
			break;
		case 5:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, Color.white, "evaded", 2.5f, 0.1f, 0.02f, -0.1f, 0f);
			toggle = 0;
			break;
		case 6:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, Color.green, text, 2.5f, 0.1f, 0.02f, -0.1f, 0f);
			toggle = 0;
			break;
		case 7:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.5f, 1f, 1f, 1f), text, 2f, 0.1f, 0.02f, -0.2f, 0.2f);
			toggle = 0;
			break;
		case 8:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, Color.red, text, 2f, 0.1f, 0.02f, -0.3f, 0.2f);
			toggle = 0;
			break;
		case 9:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(1f, 0.6f, 0f, 1f), text, 2.5f, 0.1f, 0.05f, -0.025f, 0.2f);
			toggle = 0;
			break;
		case 10:
			if (amount > 0)
			{
				INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
				INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.5f, 1f, 1f, 1f), text + "+", 2.5f, 0.1f, 0.01f, 0.3f, 0f);
			}
			else if (amount < 0)
			{
				INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
				INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.8f, 1f, 1f, 1f), text + "-", 2.5f, 0.1f, 0.01f, -0.2f, 0f);
			}
			toggle = 0;
			break;
		case 11:
			if (amount > 0)
			{
				INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
				INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.8f, 1f, 1f, 1f), text, 2.5f, 0.1f, 0.01f, -0.2f, 0f);
			}
			else if (amount < 0)
			{
				INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
				INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(0.8f, 1f, 1f, 1f), text, 2.5f, 0.1f, 0.01f, -0.2f, 0f);
			}
			toggle = 0;
			break;
		case 12:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(1f, 0.6f, 0f, 1f), "instant", 3f, 0.1f, 0.05f, -0.1f, 0f);
			toggle = 0;
			break;
		}
	}

	private void AttributePropDisplay()
	{
		if (state == 1)
		{
			if (TOGGLE_unitAttributeArmorPoint != scriptUnitAttribute.statisticAlteredAP)
			{
				if (scriptUnitAttribute.statisticAlteredAP != 0)
				{
					if (INST_effectArmorState == null)
					{
						INST_effectArmorState = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, effectPosition.transform.position, effectPropertyDisplay.transform.rotation);
					}
					if (scriptUnitAttribute.statisticAlteredAP > 0)
					{
						if (scriptUnitAttribute.statisticAlteredAP <= 10)
						{
							switch (scriptUnitAttribute.statisticAlteredAP)
							{
							case 1:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 1f);
								break;
							case 2:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 1.15f);
								break;
							case 3:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 1.3f);
								break;
							case 4:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 1.45f);
								break;
							case 5:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 1.6f);
								break;
							case 6:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 1.75f);
								break;
							case 7:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 1.9f);
								break;
							case 8:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 2.05f);
								break;
							case 9:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 2.2f);
								break;
							case 10:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 2.35f);
								break;
							}
						}
						else
						{
							INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(base.gameObject, 1, TOGGLE_unitAlignment, 1, 2, 2.6f);
						}
					}
					else if (scriptUnitAttribute.statisticAlteredAP < 0)
					{
						if (scriptUnitAttribute.statisticAlteredAP >= -10)
						{
							switch (scriptUnitAttribute.statisticAlteredAP)
							{
							case -1:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 1f);
								break;
							case -2:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 1.15f);
								break;
							case -3:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 1.3f);
								break;
							case -4:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 1.45f);
								break;
							case -5:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 1.6f);
								break;
							case -6:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 1.75f);
								break;
							case -7:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 1.9f);
								break;
							case -8:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 2.05f);
								break;
							case -9:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 2.2f);
								break;
							case -10:
								INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 2.35f);
								break;
							}
						}
						else
						{
							INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, TOGGLE_unitAlignment, 1, 1, 2.35f);
						}
					}
				}
				else if (INST_effectArmorState != null)
				{
					INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
					INST_effectArmorState = null;
				}
				TOGGLE_unitAttributeArmorPoint = scriptUnitAttribute.statisticAlteredAP;
			}
			if (TOGGLE_unitAttributeStatisticAltered == scriptUnitAttribute.statisticAltered)
			{
				return;
			}
			if (scriptUnitAttribute.statisticAltered != 0f)
			{
				if (INST_unitAttributeStatisticAltered == null)
				{
					INST_unitAttributeStatisticAltered = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, effectPosition.transform.position, effectPropertyDisplay.transform.rotation);
				}
				if (scriptUnitAttribute.statisticAltered > 0f)
				{
					if (scriptUnitAttribute.statisticAltered <= 2f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 1, 1f);
					}
					else if (scriptUnitAttribute.statisticAltered > 2f && scriptUnitAttribute.statisticAltered <= 4f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 1, 1.25f);
					}
					else if (scriptUnitAttribute.statisticAltered > 4f && scriptUnitAttribute.statisticAltered <= 6f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 1, 1.5f);
					}
					else if (scriptUnitAttribute.statisticAltered > 6f && scriptUnitAttribute.statisticAltered <= 8f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 1, 1.75f);
					}
					else if (scriptUnitAttribute.statisticAltered > 8f && scriptUnitAttribute.statisticAltered <= 10f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 1, 2f);
					}
					else if (scriptUnitAttribute.statisticAltered >= 10f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 1, 2.25f);
					}
				}
				else if (scriptUnitAttribute.statisticAltered < 0f)
				{
					if (scriptUnitAttribute.statisticAltered >= -2f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 2, 1f);
					}
					else if (scriptUnitAttribute.statisticAltered < -2f && scriptUnitAttribute.statisticAltered >= -4f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 2, 1.25f);
					}
					else if (scriptUnitAttribute.statisticAltered < -4f && scriptUnitAttribute.statisticAltered >= -6f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 2, 1.5f);
					}
					else if (scriptUnitAttribute.statisticAltered < -6f && scriptUnitAttribute.statisticAltered >= -8f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 2, 1.75f);
					}
					else if (scriptUnitAttribute.statisticAltered < -8f && scriptUnitAttribute.statisticAltered >= -10f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 2, 2f);
					}
					else if (scriptUnitAttribute.statisticAltered <= -10f)
					{
						INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 3, TOGGLE_unitAlignment, 2, 2, 2.25f);
					}
				}
			}
			else if (INST_unitAttributeStatisticAltered != null)
			{
				INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
				INST_unitAttributeStatisticAltered = null;
			}
			TOGGLE_unitAttributeStatisticAltered = scriptUnitAttribute.statisticAltered;
		}
		else
		{
			if (TOGGLE_unitAttributeArmorPoint != 0 || TOGGLE_unitAttributeStatisticAltered != 0f)
			{
				TOGGLE_unitAttributeArmorPoint = 0;
				TOGGLE_unitAttributeStatisticAltered = 0f;
			}
			if (INST_effectArmorState != null)
			{
				INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
				INST_effectArmorState = null;
			}
			if (INST_unitAttributeStatisticAltered != null)
			{
				INST_unitAttributeStatisticAltered.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
				INST_unitAttributeStatisticAltered = null;
			}
		}
	}

	private void DisableComboFunction()
	{
		switch (DisableComboFunctionState)
		{
		case 0:
			break;
		case -1:
			AMOUNT_disableCombo = 0;
			TOGGLEAMOUNT_disableCombo = 0;
			TOGGLE_disableCombo = 0;
			disableComboState = 0;
			DisableComboFunctionState = 0;
			break;
		case 1:
			if (unitState == 4)
			{
				TIMER_disableCombo = Time.time + 2.5f;
			}
			else if (TOGGLEAMOUNT_disableCombo != AMOUNT_disableCombo)
			{
				TIMER_disableCombo = Time.time + 2.5f;
				TOGGLEAMOUNT_disableCombo = AMOUNT_disableCombo;
			}
			switch (disableComboState)
			{
			case 0:
				if (AMOUNT_disableCombo > 0)
				{
					disableComboState = 1;
				}
				break;
			case 1:
				if (AMOUNT_disableCombo >= 2)
				{
					disableComboState = 2;
				}
				break;
			case 2:
				if (unitState == 4)
				{
					if (AMOUNT_disableCombo >= 2 && AMOUNT_disableCombo <= 11)
					{
						switch (AMOUNT_disableCombo)
						{
						case 2:
							TOGGLE_disableCombo = 2;
							break;
						case 5:
							TOGGLE_disableCombo = 4;
							break;
						case 7:
							TOGGLE_disableCombo = 6;
							break;
						case 9:
							TOGGLE_disableCombo = 8;
							break;
						case 11:
							TOGGLE_disableCombo = 10;
							break;
						}
					}
					else if (AMOUNT_disableCombo > 11)
					{
						TOGGLE_disableCombo = 10;
					}
				}
				else if (unitTier == -1)
				{
					if (AMOUNT_disableCombo >= 2 && AMOUNT_disableCombo <= 5)
					{
						switch (AMOUNT_disableCombo)
						{
						case 2:
							TOGGLE_disableCombo = 1;
							break;
						case 5:
							TOGGLE_disableCombo = 2;
							break;
						}
					}
					else if (AMOUNT_disableCombo > 5)
					{
						TOGGLE_disableCombo = 2;
						AMOUNT_disableCombo = 5;
					}
				}
				else if (AMOUNT_disableCombo >= 2 && AMOUNT_disableCombo <= 5)
				{
					switch (AMOUNT_disableCombo)
					{
					case 2:
						TOGGLE_disableCombo = 2;
						break;
					case 5:
						TOGGLE_disableCombo = 4;
						break;
					}
				}
				else if (AMOUNT_disableCombo > 5)
				{
					TOGGLE_disableCombo = 4;
					AMOUNT_disableCombo = 5;
				}
				break;
			}
			if (Time.time >= TIMER_disableCombo)
			{
				DisableComboFunctionState = -1;
			}
			break;
		}
	}

	public void AttributeOverTimeEffectHP(int Toggle, int amount, int number, float delay, int effectClass, int effectNumber)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				EFFECTCLASS_attributeOverTimeEffectHP = effectClass;
				EFFECTNUMBER_attributeOverTimeEffectHP = effectNumber;
				DELAY_attributeOverTimeEffectHP = delay;
				TIMER_attributeOverTimeEffectHP = Time.time + delay;
				NUMBER_attributeOverTimeEffectHP = number;
				AMOUNT_attributeOverTimeEffectHP = amount;
				TOGGLE_attributeOverTimeEffectHP = Toggle;
				Toggle = 0;
				break;
			case 2:
				EFFECTCLASS_attributeOverTimeEffectHP = effectClass;
				EFFECTNUMBER_attributeOverTimeEffectHP = effectNumber;
				DELAY_attributeOverTimeEffectHP = delay;
				TIMER_attributeOverTimeEffectHP = Time.time + delay;
				NUMBER_attributeOverTimeEffectHP = number;
				AMOUNT_attributeOverTimeEffectHP = amount;
				TOGGLE_attributeOverTimeEffectHP = Toggle;
				Toggle = 0;
				break;
			case 3:
				EFFECTCLASS_attributeOverTimeEffectHP = effectClass;
				EFFECTNUMBER_attributeOverTimeEffectHP = effectNumber;
				TOGGLE_attributeOverTimeEffectCurrentHP = attributeHealthValue;
				DELAY_attributeOverTimeEffectHP = delay;
				TIMER_attributeOverTimeEffectHP = Time.time + delay;
				NUMBER_attributeOverTimeEffectHP = number;
				AMOUNT_attributeOverTimeEffectHP = amount;
				TOGGLE_attributeOverTimeEffectHP = Toggle;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeOverTimeEffectHP()
	{
		switch (TOGGLE_attributeOverTimeEffectHP)
		{
		case 0:
			break;
		case -1:
			NUMBER_attributeOverTimeEffectHP = 0;
			DELAY_attributeOverTimeEffectHP = 0f;
			TIMER_attributeOverTimeEffectHP = 0f;
			AMOUNT_attributeOverTimeEffectHP = 0;
			TOGGLE_attributeOverTimeEffectHP = 0;
			break;
		case 1:
			if (TOGGLE_attributeEffectHP == 2)
			{
				NUMBER_attributeOverTimeEffectHP = 0;
			}
			if (NUMBER_attributeOverTimeEffectHP > 0)
			{
				if (Time.time >= TIMER_attributeOverTimeEffectHP)
				{
					if (EFFECTNUMBER_attributeOverTimeEffectHP != 0)
					{
						INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, myTransform.position, effectHitDisplay.transform.rotation);
						INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, scriptCharacterAnimation.gameObject, EFFECTCLASS_attributeOverTimeEffectHP, EFFECTNUMBER_attributeOverTimeEffectHP);
					}
					UnitToggleColorFunction(3);
					AttributeEffectHP(1, Mathf.RoundToInt((float)AMOUNT_attributeOverTimeEffectHP * attributeDamageMultiplier), 0);
					NUMBER_attributeOverTimeEffectHP--;
					TIMER_attributeOverTimeEffectHP = Time.time + DELAY_attributeOverTimeEffectHP;
				}
			}
			else
			{
				TOGGLE_attributeOverTimeEffectHP = 0;
			}
			break;
		case 2:
			if (NUMBER_attributeOverTimeEffectHP > 0)
			{
				if (Time.time >= TIMER_attributeOverTimeEffectHP)
				{
					if (EFFECTNUMBER_attributeOverTimeEffectHP != 0)
					{
						INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, myTransform.position, effectHitDisplay.transform.rotation);
						INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, scriptCharacterAnimation.gameObject, EFFECTCLASS_attributeOverTimeEffectHP, EFFECTNUMBER_attributeOverTimeEffectHP);
					}
					UnitToggleColorFunction(4);
					AttributeEffectHP(2, AMOUNT_attributeOverTimeEffectHP, 0);
					NUMBER_attributeOverTimeEffectHP--;
					TIMER_attributeOverTimeEffectHP = Time.time + DELAY_attributeOverTimeEffectHP;
				}
			}
			else
			{
				TOGGLE_attributeOverTimeEffectHP = 0;
			}
			break;
		case 3:
			if (TOGGLE_attributeEffectHP == 1)
			{
				NUMBER_attributeOverTimeEffectHP = 0;
			}
			if (TOGGLE_attributeOverTimeEffectCurrentHP > attributeHealthValue)
			{
				NUMBER_attributeOverTimeEffectHP = 0;
			}
			if (NUMBER_attributeOverTimeEffectHP > 0)
			{
				if (Time.time >= TIMER_attributeOverTimeEffectHP)
				{
					if (EFFECTNUMBER_attributeOverTimeEffectHP != 0)
					{
						INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, myTransform.position, effectHitDisplay.transform.rotation);
						INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, scriptCharacterAnimation.gameObject, EFFECTCLASS_attributeOverTimeEffectHP, EFFECTNUMBER_attributeOverTimeEffectHP);
					}
					UnitToggleColorFunction(4);
					AttributeEffectHP(2, AMOUNT_attributeOverTimeEffectHP, 0);
					TOGGLE_attributeOverTimeEffectCurrentHP = attributeHealthValue;
					NUMBER_attributeOverTimeEffectHP--;
					TIMER_attributeOverTimeEffectHP = Time.time + DELAY_attributeOverTimeEffectHP;
				}
			}
			else
			{
				TOGGLE_attributeOverTimeEffectHP = 0;
			}
			break;
		}
	}

	public void AttributeEffectHP(int Toggle, int amount, int pureEffect)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				switch (pureEffect)
				{
				case 0:
					AMOUNT_attributeEffectHP = Mathf.RoundToInt((float)amount + attributeDamageMultiplier);
					break;
				case 1:
					if (attributeDamageMultiplier > 1f)
					{
						AMOUNT_attributeEffectHP = Mathf.RoundToInt((float)amount + attributeDamageMultiplier);
					}
					else
					{
						AMOUNT_attributeEffectHP = Mathf.RoundToInt(amount);
					}
					break;
				case 2:
					AMOUNT_attributeEffectHP = Mathf.RoundToInt(amount);
					break;
				case 3:
					AMOUNT_attributeEffectHP = attributeHealthMaximumValue + 1;
					break;
				case 4:
					AMOUNT_attributeEffectHP = Mathf.RoundToInt(amount);
					break;
				}
				if (AMOUNT_attributeEffectHP <= 0 && amount != 0)
				{
					AMOUNT_attributeEffectHP = 1;
				}
				if (pureEffect < 3)
				{
					if (TOGGLE_disableCombo >= 2)
					{
						AMOUNT_attributeEffectHP *= TOGGLE_disableCombo;
						UnitEffectPropDisplay(9, "x" + TOGGLE_disableCombo, 0);
					}
					if (AMOUNT_attributeEffectHP > 50)
					{
						AMOUNT_attributeEffectHP = 50;
					}
				}
				TOGGLE_attributeEffectHP = Toggle;
				Toggle = 0;
				break;
			case 2:
				AMOUNT_attributeEffectHP = amount;
				if (AMOUNT_attributeEffectHP <= 0 && amount != 0)
				{
					AMOUNT_attributeEffectHP = 1;
				}
				TOGGLE_attributeEffectHP = Toggle;
				Toggle = 0;
				break;
			case 3:
				AMOUNT_attributeEffectHP = Mathf.RoundToInt(amount);
				if (AMOUNT_attributeEffectHP <= 0 && amount != 0)
				{
					AMOUNT_attributeEffectHP = 1;
				}
				TOGGLE_attributeEffectHP = Toggle;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectHP()
	{
		switch (TOGGLE_attributeEffectHP)
		{
		case 0:
			break;
		case -1:
			AMOUNT_attributeEffectHP = 0;
			TOGGLE_attributeEffectHP = 0;
			break;
		case 1:
			UnitToggleColorFunction(1);
			UnitEffectPropDisplay(1, string.Empty + AMOUNT_attributeEffectHP, AMOUNT_attributeEffectHP);
			attributeHealthValue -= AMOUNT_attributeEffectHP;
			TOGGLE_attributeEffectHP = 0;
			break;
		case 2:
			UnitToggleColorFunction(2);
			if (AMOUNT_attributeEffectHP + attributeHealthValue <= attributeHealthMaximumValue)
			{
				UnitEffectPropDisplay(6, "+" + AMOUNT_attributeEffectHP, 0);
				attributeHealthValue += AMOUNT_attributeEffectHP;
			}
			else if (attributeHealthMaximumValue - attributeHealthValue <= attributeHealthMaximumValue)
			{
				AMOUNT_attributeEffectHP = attributeHealthMaximumValue - attributeHealthValue;
				UnitEffectPropDisplay(6, "+" + AMOUNT_attributeEffectHP, 0);
				attributeHealthValue += AMOUNT_attributeEffectHP;
			}
			else
			{
				UnitEffectPropDisplay(6, "0", 0);
			}
			TOGGLE_attributeEffectHP = 0;
			break;
		case 3:
			UnitToggleColorFunction(1);
			UnitEffectPropDisplay(8, "-" + AMOUNT_attributeEffectHP, 0);
			attributeHealthValue -= AMOUNT_attributeEffectHP;
			TOGGLE_attributeEffectHP = 0;
			break;
		}
	}

	public void AttributeEffectMP(int Toggle, int amount)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				AMOUNT_attributeEffectMP = amount;
				TOGGLE_attributeEffectMP = Toggle;
				Toggle = 0;
				break;
			case 2:
				AMOUNT_attributeEffectMP = amount;
				TOGGLE_attributeEffectMP = Toggle;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectMP()
	{
		switch (TOGGLE_attributeEffectMP)
		{
		case 0:
			break;
		case -1:
			AMOUNT_attributeEffectMP = 0;
			TOGGLE_attributeEffectMP = 0;
			break;
		case 1:
			attributeManaValue -= AMOUNT_attributeEffectMP;
			UnitEffectPropDisplay(7, "-" + AMOUNT_attributeEffectMP, AMOUNT_attributeEffectMP);
			TOGGLE_attributeEffectMP = 0;
			break;
		case 2:
			if (AMOUNT_attributeEffectMP + attributeManaValue <= attributeManaMaximumValue)
			{
				UnitEffectPropDisplay(7, "+" + AMOUNT_attributeEffectMP, AMOUNT_attributeEffectMP);
				attributeManaValue += AMOUNT_attributeEffectMP;
			}
			else if (attributeManaMaximumValue - attributeManaValue <= attributeManaMaximumValue)
			{
				AMOUNT_attributeEffectMP = attributeManaMaximumValue - attributeManaValue;
				UnitEffectPropDisplay(7, "+" + AMOUNT_attributeEffectMP, AMOUNT_attributeEffectMP);
				attributeManaValue += AMOUNT_attributeEffectMP;
			}
			else
			{
				UnitEffectPropDisplay(7, "0", 0);
			}
			TOGGLE_attributeEffectMP = 0;
			break;
		}
	}

	public void AttributeEffectDMG(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (AMOUNT_attributeEffectDMG != amount && amount != 0)
				{
					UnitEffectPropDisplay(10, "damage", amount);
				}
				TIMER_attributeEffectDMG = Time.time + duration;
				AMOUNT_attributeEffectDMG = amount;
				TOGGLE_attributeEffectDMG = 1;
				Toggle = 0;
				break;
			case 2:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "damage", amount);
				}
				if (TOGGLE_attributeEffectDMG == 0)
				{
					TIMER_attributeEffectDMG = Time.time + duration;
					AMOUNT_attributeEffectDMG = amount;
				}
				else
				{
					TIMER_attributeEffectDMG = Time.time + duration;
					AMOUNT_attributeEffectDMG += amount;
				}
				TOGGLE_attributeEffectDMG = 1;
				Toggle = 0;
				break;
			case 3:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "damage", amount);
				}
				scriptUnitAttribute.plusStaticDamagePoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectDMG()
	{
		switch (TOGGLE_attributeEffectDMG)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectDMG = 0f;
			AMOUNT_attributeEffectDMG = 0;
			TOGGLE_attributeEffectDMG = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectDMG)
			{
				scriptUnitAttribute.plusDamagePoint = AMOUNT_attributeEffectDMG;
			}
			else if (Time.time >= TIMER_attributeEffectDMG)
			{
				scriptUnitAttribute.plusDamagePoint = 0;
				AMOUNT_attributeEffectDMG = 0;
				TOGGLE_attributeEffectDMG = 0;
			}
			break;
		}
	}

	public void AttributeEffectMS(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (amount > 0 && AMOUNT_attributeEffectMS != amount)
				{
					UnitEffectPropDisplay(10, "speed", amount);
				}
				else if (amount < 0 && AMOUNT_attributeEffectMS != amount)
				{
					UnitEffectPropDisplay(11, "slowed", amount);
				}
				TIMER_attributeEffectMS = Time.time + duration;
				AMOUNT_attributeEffectMS = amount;
				TOGGLE_attributeEffectMS = 1;
				Toggle = 0;
				break;
			case 2:
				if (amount > 0)
				{
					UnitEffectPropDisplay(10, "speed", amount);
				}
				else if (amount < 0)
				{
					UnitEffectPropDisplay(11, "slowed", amount);
				}
				if (TOGGLE_attributeEffectMS == 0)
				{
					TIMER_attributeEffectMS = Time.time + duration;
					AMOUNT_attributeEffectMS = amount;
				}
				else
				{
					TIMER_attributeEffectMS = Time.time + duration;
					AMOUNT_attributeEffectMS += amount;
				}
				TOGGLE_attributeEffectMS = 1;
				Toggle = 0;
				break;
			case 3:
				if (amount > 0)
				{
					UnitEffectPropDisplay(10, "speed", amount);
				}
				else if (amount < 0)
				{
					UnitEffectPropDisplay(11, "slowed", amount);
				}
				scriptUnitAttribute.plusStaticMovementSpeedPoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectMS()
	{
		switch (TOGGLE_attributeEffectMS)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectMS = 0f;
			AMOUNT_attributeEffectMS = 0;
			TOGGLE_attributeEffectMS = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectMS)
			{
				scriptUnitAttribute.plusMovementSpeedPoint = AMOUNT_attributeEffectMS;
			}
			else if (Time.time >= TIMER_attributeEffectMS)
			{
				scriptUnitAttribute.plusMovementSpeedPoint = 0;
				AMOUNT_attributeEffectMS = 0;
				TOGGLE_attributeEffectMS = 0;
			}
			break;
		}
	}

	public void AttributeEffectAS(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (AMOUNT_attributeEffectAS != amount && amount != 0)
				{
					UnitEffectPropDisplay(10, "attack", amount);
				}
				TIMER_attributeEffectAS = Time.time + duration;
				AMOUNT_attributeEffectAS = amount;
				TOGGLE_attributeEffectAS = 1;
				Toggle = 0;
				break;
			case 2:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "attack", amount);
				}
				if (TOGGLE_attributeEffectAS == 0)
				{
					TIMER_attributeEffectAS = Time.time + duration;
					AMOUNT_attributeEffectAS = amount;
				}
				else
				{
					TIMER_attributeEffectAS += duration;
					AMOUNT_attributeEffectAS += amount;
				}
				TOGGLE_attributeEffectAS = 1;
				Toggle = 0;
				break;
			case 3:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "attack", amount);
				}
				scriptUnitAttribute.plusStaticAttackSpeedPoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectAS()
	{
		switch (TOGGLE_attributeEffectAS)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectAS = 0f;
			AMOUNT_attributeEffectAS = 0;
			TOGGLE_attributeEffectAS = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectAS)
			{
				scriptUnitAttribute.plusAttackSpeedPoint = AMOUNT_attributeEffectAS;
			}
			else if (Time.time >= TIMER_attributeEffectAS)
			{
				scriptUnitAttribute.plusAttackSpeedPoint = 0;
				AMOUNT_attributeEffectAS = 0;
				TOGGLE_attributeEffectAS = 0;
			}
			break;
		}
	}

	public void AttributeEffectAP(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (amount > 0 && AMOUNT_attributeEffectAP != amount)
				{
					UnitEffectPropDisplay(10, "armor", amount);
				}
				else if (amount < 0 && AMOUNT_attributeEffectAP != amount)
				{
					UnitEffectPropDisplay(11, "wounded", amount);
				}
				TIMER_attributeEffectAP = Time.time + duration;
				AMOUNT_attributeEffectAP = amount;
				TOGGLE_attributeEffectAP = 1;
				Toggle = 0;
				break;
			case 2:
				if (amount > 0)
				{
					UnitEffectPropDisplay(10, "armor", amount);
				}
				else if (amount < 0)
				{
					UnitEffectPropDisplay(11, "wounded", amount);
				}
				if (TOGGLE_attributeEffectAP == 0)
				{
					TIMER_attributeEffectAP = Time.time + duration;
					AMOUNT_attributeEffectAP = amount;
				}
				else
				{
					TIMER_attributeEffectAP += duration;
					AMOUNT_attributeEffectAP += amount;
				}
				TOGGLE_attributeEffectAP = 1;
				Toggle = 0;
				break;
			case 3:
				if (amount > 0)
				{
					UnitEffectPropDisplay(10, "armor", amount);
				}
				else if (amount < 0)
				{
					UnitEffectPropDisplay(11, "wounded", amount);
				}
				scriptUnitAttribute.plusStaticArmorPoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectAP()
	{
		switch (TOGGLE_attributeEffectAP)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectAP = 0f;
			AMOUNT_attributeEffectAP = 0;
			TOGGLE_attributeEffectAP = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectAP)
			{
				scriptUnitAttribute.plusArmorPoint = AMOUNT_attributeEffectAP;
			}
			else if (Time.time >= TIMER_attributeEffectAP)
			{
				scriptUnitAttribute.plusArmorPoint = 0;
				AMOUNT_attributeEffectAP = 0;
				TOGGLE_attributeEffectAP = 0;
			}
			break;
		}
	}

	public void AttributeEffectMRP(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (AMOUNT_attributeEffectMRP != amount && amount != 0)
				{
					UnitEffectPropDisplay(10, "regen", amount);
				}
				TIMER_attributeEffectMRP = Time.time + duration;
				AMOUNT_attributeEffectMRP = amount;
				TOGGLE_attributeEffectMRP = 1;
				UnitEffectPropDisplay(10, "regen", amount);
				Toggle = 0;
				break;
			case 2:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "regen", amount);
				}
				if (TOGGLE_attributeEffectMRP == 0)
				{
					TIMER_attributeEffectMRP = Time.time + duration;
					AMOUNT_attributeEffectMRP = amount;
				}
				else
				{
					TIMER_attributeEffectMRP += duration;
					AMOUNT_attributeEffectMRP += amount;
				}
				TOGGLE_attributeEffectMRP = 1;
				UnitEffectPropDisplay(10, "regen", amount);
				Toggle = 0;
				break;
			case 3:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "regen", amount);
				}
				scriptUnitAttribute.plusStaticManaRegenPoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectMRP()
	{
		switch (TOGGLE_attributeEffectMRP)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectMRP = 0f;
			AMOUNT_attributeEffectMRP = 0;
			TOGGLE_attributeEffectMRP = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectMRP)
			{
				scriptUnitAttribute.plusManaRegenPoint = AMOUNT_attributeEffectMRP;
			}
			else if (Time.time >= TIMER_attributeEffectMRP)
			{
				scriptUnitAttribute.plusManaRegenPoint = 0;
				AMOUNT_attributeEffectMRP = 0;
				TOGGLE_attributeEffectMRP = 0;
			}
			break;
		}
	}

	public void AttributeEffectCRP(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (AMOUNT_attributeEffectCRP != amount && amount != 0)
				{
					UnitEffectPropDisplay(10, "critical", amount);
				}
				TIMER_attributeEffectCRP = Time.time + duration;
				AMOUNT_attributeEffectCRP = amount;
				TOGGLE_attributeEffectCRP = 1;
				Toggle = 0;
				break;
			case 2:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "critical", amount);
				}
				if (TOGGLE_attributeEffectCRP == 0)
				{
					TIMER_attributeEffectCRP = Time.time + duration;
					AMOUNT_attributeEffectCRP = amount;
				}
				else
				{
					TIMER_attributeEffectCRP += duration;
					AMOUNT_attributeEffectCRP += amount;
				}
				TOGGLE_attributeEffectCRP = 1;
				Toggle = 0;
				break;
			case 3:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "critical", amount);
				}
				scriptUnitAttribute.plusStaticCriticalPoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectCRP()
	{
		switch (TOGGLE_attributeEffectCRP)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectCRP = 0f;
			AMOUNT_attributeEffectCRP = 0;
			TOGGLE_attributeEffectCRP = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectCRP)
			{
				scriptUnitAttribute.plusCriticalPoint = AMOUNT_attributeEffectCRP;
			}
			else if (Time.time >= TIMER_attributeEffectCRP)
			{
				scriptUnitAttribute.plusCriticalPoint = 0;
				AMOUNT_attributeEffectCRP = 0;
				TOGGLE_attributeEffectCRP = 0;
			}
			break;
		}
	}

	public void AttributeEffectACP(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "precision", amount);
				}
				TIMER_attributeEffectACP = Time.time + duration;
				AMOUNT_attributeEffectACP = amount;
				TOGGLE_attributeEffectACP = 1;
				Toggle = 0;
				break;
			case 2:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "precision", amount);
				}
				if (TOGGLE_attributeEffectACP == 0)
				{
					TIMER_attributeEffectACP = Time.time + duration;
					AMOUNT_attributeEffectACP = amount;
				}
				else
				{
					TIMER_attributeEffectACP += duration;
					AMOUNT_attributeEffectACP += amount;
				}
				TOGGLE_attributeEffectACP = 1;
				Toggle = 0;
				break;
			case 3:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "precision", amount);
				}
				scriptUnitAttribute.plusStaticAccuracyPoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectACP()
	{
		switch (TOGGLE_attributeEffectACP)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectACP = 0f;
			AMOUNT_attributeEffectACP = 0;
			TOGGLE_attributeEffectACP = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectACP)
			{
				scriptUnitAttribute.plusAccuracyPoint = AMOUNT_attributeEffectACP;
			}
			else if (Time.time >= TIMER_attributeEffectACP)
			{
				scriptUnitAttribute.plusAccuracyPoint = 0;
				AMOUNT_attributeEffectACP = 0;
				TOGGLE_attributeEffectACP = 0;
			}
			break;
		}
	}

	public void AttributeEffectEVP(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "evasion", amount);
				}
				TIMER_attributeEffectEVP = Time.time + duration;
				AMOUNT_attributeEffectEVP = amount;
				TOGGLE_attributeEffectEVP = 1;
				Toggle = 0;
				break;
			case 2:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "evasion", amount);
				}
				if (TOGGLE_attributeEffectEVP == 0)
				{
					TIMER_attributeEffectEVP = Time.time + duration;
					AMOUNT_attributeEffectEVP = amount;
				}
				else
				{
					TIMER_attributeEffectEVP += duration;
					AMOUNT_attributeEffectEVP += amount;
				}
				TOGGLE_attributeEffectEVP = 1;
				Toggle = 0;
				break;
			case 3:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "evasion", amount);
				}
				scriptUnitAttribute.plusStaticEvasionPoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectEVP()
	{
		switch (TOGGLE_attributeEffectEVP)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectEVP = 0f;
			AMOUNT_attributeEffectEVP = 0;
			TOGGLE_attributeEffectEVP = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectEVP)
			{
				scriptUnitAttribute.plusEvasionPoint = AMOUNT_attributeEffectEVP;
			}
			else if (Time.time >= TIMER_attributeEffectEVP)
			{
				scriptUnitAttribute.plusEvasionPoint = 0;
				AMOUNT_attributeEffectEVP = 0;
				TOGGLE_attributeEffectEVP = 0;
			}
			break;
		}
	}

	public void AttributeEffectANP(int Toggle, int amount, float duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "anchor", amount);
				}
				TIMER_attributeEffectANP = Time.time + duration;
				AMOUNT_attributeEffectANP = amount;
				TOGGLE_attributeEffectANP = 1;
				Toggle = 0;
				break;
			case 2:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "anchor", amount);
				}
				if (TOGGLE_attributeEffectANP == 0)
				{
					TIMER_attributeEffectANP = Time.time + duration;
					AMOUNT_attributeEffectANP = amount;
				}
				else
				{
					TIMER_attributeEffectANP += duration;
					AMOUNT_attributeEffectANP += amount;
				}
				TOGGLE_attributeEffectANP = 1;
				Toggle = 0;
				break;
			case 3:
				if (amount != 0)
				{
					UnitEffectPropDisplay(10, "anchor", amount);
				}
				scriptUnitAttribute.plusStaticEvasionPoint += amount;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectANP()
	{
		switch (TOGGLE_attributeEffectANP)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectANP = 0f;
			AMOUNT_attributeEffectANP = 0;
			TOGGLE_attributeEffectANP = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectANP)
			{
				scriptUnitAttribute.plusAnchorPoint = AMOUNT_attributeEffectANP;
			}
			else if (Time.time >= TIMER_attributeEffectANP)
			{
				scriptUnitAttribute.plusAnchorPoint = 0;
				AMOUNT_attributeEffectANP = 0;
				TOGGLE_attributeEffectANP = 0;
			}
			break;
		}
	}

	public void UnitEffectKnock(int Toggle, float Duration, float Distance, float Damping)
	{
		if (state == 1)
		{
			if (Toggle != 1)
			{
				return;
			}
			if (TOGGLE_unitEffectKnock == 0)
			{
				TIMER_unitEffectKnock = Time.time + Duration;
				switch (TOGGLE_unitAlignment)
				{
				case 0:
				{
					Vector3 position3 = myTransform.position;
					float x2 = position3.x - Distance;
					Vector3 position4 = myTransform.position;
					VECTOR_unitEffectKnock = new Vector3(x2, position4.y, 0f);
					break;
				}
				case 1:
				{
					Vector3 position = myTransform.position;
					float x = position.x + Distance;
					Vector3 position2 = myTransform.position;
					VECTOR_unitEffectKnock = new Vector3(x, position2.y, 0f);
					break;
				}
				}
				DAMPING_unitEffectKnock = Damping;
			}
			else
			{
				switch (TOGGLE_unitAlignment)
				{
				case 0:
				{
					float x4 = VECTOR_unitEffectKnock.x - Distance;
					Vector3 position6 = myTransform.position;
					VECTOR_unitEffectKnock = new Vector3(x4, position6.y, 0f);
					break;
				}
				case 1:
				{
					float x3 = VECTOR_unitEffectKnock.x + Distance;
					Vector3 position5 = myTransform.position;
					VECTOR_unitEffectKnock = new Vector3(x3, position5.y, 0f);
					break;
				}
				}
				TIMER_unitEffectKnock += Duration / 2f;
				if (Damping > DAMPING_unitEffectKnock)
				{
					DAMPING_unitEffectKnock = Damping;
				}
			}
			TOGGLE_unitEffectKnock = Toggle;
			if (unitState != 3)
			{
				unitState = 4;
			}
			Toggle = 0;
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitEffectKnock()
	{
		switch (TOGGLE_unitEffectKnock)
		{
		case 0:
			break;
		case -1:
			TIMER_unitEffectKnock = 0f;
			DAMPING_unitEffectKnock = 0f;
			TOGGLE_unitEffectKnock = 0;
			break;
		case 1:
			if (Time.time < TIMER_unitEffectKnock)
			{
				if (unitAltitudeType != -1 && TOGGLE_positionLock != 1)
				{
					Transform transform = myTransform;
					Vector3 position = myTransform.position;
					float x = VECTOR_unitEffectKnock.x;
					Vector3 position2 = myTransform.position;
					float y = position2.y;
					Vector3 position3 = myTransform.position;
					transform.position = Vector3.Lerp(position, new Vector3(x, y, position3.z), Time.deltaTime * DAMPING_unitEffectKnock);
				}
			}
			else if (Time.time >= TIMER_unitEffectKnock)
			{
				TOGGLE_unitEffectKnock = 0;
			}
			break;
		}
	}

	public void UnitEffectRise(int Toggle, float Duration, float Height, float Damping)
	{
		if (state == 1)
		{
			if (unitAltitudeType != 0 && TOGGLE_unitHexEffect == 0)
			{
				return;
			}
			switch (Toggle)
			{
			case 1:
				if (TOGGLE_unitEffectRise == 0)
				{
					TIMER_unitEffectRise = Time.time + Duration;
					Vector3 localPosition3 = myTransform.localPosition;
					VECTOR_unitEffectRise = new Vector3(localPosition3.x, Height, 0f);
					DAMPING_unitEffectRise = Damping;
				}
				else
				{
					if (VECTOR_unitEffectRise.y < Height)
					{
						Vector3 position2 = myTransform.position;
						VECTOR_unitEffectRise = new Vector3(position2.x, Height, 0f);
					}
					if (Time.time + Duration > TIMER_unitEffectRise)
					{
						TIMER_unitEffectRise = Time.time + Duration;
					}
					if (Damping > DAMPING_unitEffectRise)
					{
						DAMPING_unitEffectRise = Damping;
					}
				}
				TOGGLE_unitEffectRise = Toggle;
				Toggle = 0;
				break;
			case 2:
				if (TOGGLE_unitEffectRise == 0)
				{
					TIMER_unitEffectRise = Time.time + Duration;
					Vector3 localPosition = myTransform.localPosition;
					float x = localPosition.x;
					Vector3 localPosition2 = myTransform.localPosition;
					VECTOR_unitEffectRise = new Vector3(x, localPosition2.y + Height, 0f);
					DAMPING_unitEffectRise = Damping;
				}
				else
				{
					Vector3 position = myTransform.position;
					VECTOR_unitEffectRise = new Vector3(position.x, VECTOR_unitEffectRise.y + Height, 0f);
					TIMER_unitEffectRise += Duration;
					if (Damping > DAMPING_unitEffectRise)
					{
						DAMPING_unitEffectRise = Damping;
					}
				}
				TOGGLE_unitEffectRise = 1;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitEffectRise()
	{
		switch (TOGGLE_unitEffectRise)
		{
		case 0:
			break;
		case -1:
			TIMER_unitEffectRise = 0f;
			DAMPING_unitEffectRise = 0f;
			TOGGLE_unitEffectRise = 0;
			break;
		case 1:
			if (Time.time < TIMER_unitEffectRise)
			{
				Transform transform = myTransform;
				Vector3 position = myTransform.position;
				Vector3 position2 = myTransform.position;
				float x = position2.x;
				float y = VECTOR_unitEffectRise.y;
				Vector3 position3 = myTransform.position;
				transform.position = Vector3.Lerp(position, new Vector3(x, y, position3.z), Time.deltaTime * DAMPING_unitEffectRise);
			}
			else if (Time.time >= TIMER_unitEffectRise)
			{
				TOGGLE_unitEffectRise = 0;
			}
			break;
		}
	}

	public void UnitEffectHex(int Toggle, float Duration)
	{
		if (state == 1 && attributeEffectHexable == 1)
		{
			switch (Toggle)
			{
			case 1:
				TOGGLE_unitHexEffect = Toggle;
				scriptCharacterAnimation.hexNumber = Toggle;
				TIMER_unitHexEffect = Time.time + Duration;
				if (unitState != 4)
				{
					unitState = 1;
				}
				CONTROL_movementType = 0;
				WEIGHT_unitHexEffect = 0;
				MOVEMENTSPEED_unitHexEffect = 0f;
				Toggle = 0;
				break;
			case 2:
				TOGGLE_unitHexEffect = Toggle;
				scriptCharacterAnimation.hexNumber = Toggle;
				TIMER_unitHexEffect = Time.time + Duration;
				if (unitState != 4)
				{
					unitState = 1;
				}
				CONTROL_movementType = 0;
				WEIGHT_unitHexEffect = 0;
				MOVEMENTSPEED_unitHexEffect = 0f;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	public void UnitEffectHex()
	{
		if (state == 1)
		{
			switch (TOGGLE_unitHexEffect)
			{
			case 0:
				break;
			case -1:
				TIMER_unitHexEffect = 0f;
				scriptCharacterAnimation.hexNumber = 0;
				WEIGHT_unitHexEffect = 0;
				TOGGLE_unitHexEffect = 0;
				break;
			case 1:
				if (Time.time >= TIMER_unitHexEffect)
				{
					TOGGLE_unitHexEffect = -1;
				}
				break;
			case 2:
				if (Time.time >= TIMER_unitHexEffect)
				{
					TOGGLE_unitHexEffect = -1;
				}
				break;
			}
		}
		else if (TOGGLE_unitHexEffect != 0)
		{
			TIMER_unitHexEffect = 0f;
			scriptCharacterAnimation.hexNumber = 0;
			WEIGHT_unitHexEffect = 0;
			TOGGLE_unitHexEffect = 0;
		}
	}

	public void UnitEffectDisable(int Toggle, float Duration)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				if (TOGGLE_unitEffectDisable == 0)
				{
					TIMER_unitEffectDisable = Time.time + Duration;
				}
				else
				{
					TIMER_unitEffectDisable += Duration / 2f;
				}
				if (INST_effectStateDisable == null)
				{
					TOGGLE2_stunEffectScale = -1;
					INST_effectStateDisable = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, effectPosition.transform.position, effectPropertyDisplay.transform.rotation);
					INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 2, TOGGLE_unitAlignment, 0, Toggle, 0f);
				}
				TOGGLE_unitEffectDisable = Toggle;
				unitState = 4;
				Toggle = 0;
				break;
			case 2:
				if (TOGGLE_unitEffectDisable == 0)
				{
					TIMER_unitEffectDisable = Time.time + Duration;
				}
				else
				{
					TIMER_unitEffectDisable += Duration / 2f;
				}
				TOGGLE_positionLock = 1;
				TOGGLE_unitEffectDisable = Toggle;
				unitState = 4;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitEffectDisable()
	{
		if (state == 1)
		{
			switch (TOGGLE_unitEffectDisable)
			{
			case -1:
				if (INST_effectStateDisable != null)
				{
					INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
					INST_effectStateDisable = null;
				}
				TIMER_unitEffectDisable = 0f;
				TOGGLE_unitEffectDisable = 0;
				break;
			case 0:
				if (TOGGLE_positionLock != 0)
				{
					TOGGLE_positionLock = 0;
				}
				break;
			case 1:
				if (Time.time < TIMER_unitEffectDisable)
				{
					TIMER_stunDurationRemain = TIMER_unitEffectDisable - Time.time;
					if (TIMER_stunDurationRemain <= 2f)
					{
						TOGGLE_stunEffectScale = 0;
					}
					else if (TIMER_stunDurationRemain > 2f && TIMER_stunDurationRemain <= 4f)
					{
						TOGGLE_stunEffectScale = 1;
					}
					else if (TIMER_stunDurationRemain > 4f && TIMER_stunDurationRemain <= 6f)
					{
						TOGGLE_stunEffectScale = 2;
					}
					else if (TIMER_stunDurationRemain > 6f && TIMER_stunDurationRemain <= 8f)
					{
						TOGGLE_stunEffectScale = 3;
					}
					else if (TIMER_stunDurationRemain > 8f && TIMER_stunDurationRemain <= 10f)
					{
						TOGGLE_stunEffectScale = 4;
					}
					else if (TIMER_stunDurationRemain >= 10f)
					{
						TOGGLE_stunEffectScale = 5;
					}
					if (TOGGLE2_stunEffectScale != TOGGLE_stunEffectScale)
					{
						switch (TOGGLE_stunEffectScale)
						{
						case 0:
							INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 2, TOGGLE_unitAlignment, 0, 1, 1.25f);
							break;
						case 1:
							INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 2, TOGGLE_unitAlignment, 0, 1, 1.5f);
							break;
						case 2:
							INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 2, TOGGLE_unitAlignment, 0, 1, 1.75f);
							break;
						case 3:
							INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 2, TOGGLE_unitAlignment, 0, 1, 2f);
							break;
						case 4:
							INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 2, TOGGLE_unitAlignment, 0, 1, 2.25f);
							break;
						case 5:
							INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 2, TOGGLE_unitAlignment, 0, 1, 2.5f);
							break;
						}
						TOGGLE2_stunEffectScale = TOGGLE_stunEffectScale;
					}
				}
				else if (Time.time >= TIMER_unitEffectDisable)
				{
					TOGGLE_unitEffectDisable = -1;
				}
				break;
			case 2:
				if (Time.time < TIMER_unitEffectDisable)
				{
					TOGGLE_positionLock = 1;
				}
				else if (Time.time >= TIMER_unitEffectDisable)
				{
					TOGGLE_positionLock = 0;
					TOGGLE_unitEffectDisable = -1;
				}
				break;
			}
		}
		else
		{
			if (INST_effectStateDisable != null)
			{
				INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
				INST_effectStateDisable = null;
			}
			if (TOGGLE_unitEffectDisable != 0)
			{
				TOGGLE_positionLock = 0;
				TIMER_unitEffectDisable = 0f;
				TOGGLE_unitEffectDisable = 0;
			}
		}
	}

	private void DistanceControlFunction()
	{
		if (unitOffenseAction == 4)
		{
			if (POSITION_unitDestinationPosition != 5.4f + RANDOMPLUS_unitDestinationPosition + stageLength - scriptUnitAttribute.unitDestinationPosition)
			{
				POSITION_unitDestinationPosition = 5.4f + RANDOMPLUS_unitDestinationPosition + stageLength - scriptUnitAttribute.unitDestinationPosition;
			}
		}
		else if (POSITION_unitDestinationPosition != scriptUnitAttribute.unitDestinationPosition + RANDOMPLUS_unitDestinationPosition)
		{
			POSITION_unitDestinationPosition = scriptUnitAttribute.unitDestinationPosition + RANDOMPLUS_unitDestinationPosition;
		}
		if (TOGGLE_unitAlignment == 0)
		{
			switch (state)
			{
			case 0:
				if (scriptUnitAttribute.unitTier != -2)
				{
					RANDOMPLUS_unitDestinationPosition = UnityEngine.Random.Range(-0.1f, 0.1f);
				}
				break;
			case 1:
			{
				Vector3 position2 = myTransform.position;
				if (position2.x < POSITION_unitDestinationPosition)
				{
					TOGGLE_unitDestinationPosition = 0;
				}
				else
				{
					Vector3 position3 = myTransform.position;
					if (position3.x > POSITION_unitDestinationPosition + 0.25f)
					{
						TOGGLE_unitDestinationPosition = 2;
					}
					else
					{
						Vector3 position4 = myTransform.position;
						if (position4.x >= POSITION_unitDestinationPosition)
						{
							TOGGLE_unitDestinationPosition = 1;
						}
					}
				}
				if (TOGGLE_unitEffectKnock > 0)
				{
					Vector3 position5 = myTransform.position;
					if (position5.x < -5.35f)
					{
						float x = UnityEngine.Random.Range(-5f, -4f);
						Vector3 position6 = myTransform.position;
						float y = position6.y;
						Vector3 position7 = myTransform.position;
						VECTOR_unitEffectKnock = new Vector3(x, y, position7.z);
					}
				}
				Vector3 position8 = myTransform.position;
				if (position8.x < -1.85f)
				{
					BALANCE_attributeMovmentSpeed = scriptUnitAttribute.movementSpeedValue;
					break;
				}
				Vector3 position9 = myTransform.position;
				if (position9.x >= -1.85f)
				{
					Vector3 position10 = myTransform.position;
					if (position10.x < 2.25f)
					{
						if (BALANCE_attributeMovmentSpeed > 0f)
						{
							BALANCE_attributeMovmentSpeed -= 0.001f;
						}
						else if (BALANCE_attributeMovmentSpeed < 0f)
						{
							BALANCE_attributeMovmentSpeed = 0f;
						}
						break;
					}
				}
				Vector3 position11 = myTransform.position;
				if (position11.x >= 2.25f)
				{
					if (BALANCE_attributeMovmentSpeed > (0f - scriptUnitAttribute.movementSpeedValue) / 2f)
					{
						BALANCE_attributeMovmentSpeed -= 0.001f;
					}
					else if (BALANCE_attributeMovmentSpeed < (0f - scriptUnitAttribute.movementSpeedValue) / 2f)
					{
						BALANCE_attributeMovmentSpeed = (0f - scriptUnitAttribute.movementSpeedValue) / 2f;
					}
				}
				break;
			}
			case 2:
			{
				Vector3 position = myTransform.position;
				if (position.x <= -6.5f)
				{
					state = 3;
				}
				break;
			}
			}
		}
		else
		{
			if (TOGGLE_unitAlignment != 1)
			{
				return;
			}
			switch (state)
			{
			case 0:
				if (scriptUnitAttribute.unitTier != -2)
				{
					RANDOMPLUS_unitDestinationPosition = UnityEngine.Random.Range(-0.1f, 0.1f);
				}
				break;
			case 1:
			{
				Vector3 position13 = myTransform.position;
				if (position13.x > POSITION_unitDestinationPosition)
				{
					TOGGLE_unitDestinationPosition = 0;
				}
				else
				{
					Vector3 position14 = myTransform.position;
					if (position14.x < POSITION_unitDestinationPosition - 0.25f)
					{
						TOGGLE_unitDestinationPosition = 2;
					}
					else
					{
						Vector3 position15 = myTransform.position;
						if (position15.x <= POSITION_unitDestinationPosition)
						{
							TOGGLE_unitDestinationPosition = 1;
						}
					}
				}
				if (TOGGLE_unitEffectKnock > 0)
				{
					Vector3 position16 = myTransform.position;
					if (position16.x > 5.25f + stageLength)
					{
						float x2 = UnityEngine.Random.Range(3.5f + stageLength, 5f + stageLength);
						Vector3 position17 = myTransform.position;
						float y2 = position17.y;
						Vector3 position18 = myTransform.position;
						VECTOR_unitEffectKnock = new Vector3(x2, y2, position18.z);
					}
				}
				Vector3 position19 = myTransform.position;
				if (position19.x > 4.25f + stageLength)
				{
					BALANCE_attributeMovmentSpeed = scriptUnitAttribute.movementSpeedValue;
					break;
				}
				Vector3 position20 = myTransform.position;
				if (position20.x <= 4.25f + stageLength)
				{
					Vector3 position21 = myTransform.position;
					if (position21.x > 0.25f)
					{
						if (BALANCE_attributeMovmentSpeed > 0f)
						{
							BALANCE_attributeMovmentSpeed -= 0.001f;
						}
						else if (BALANCE_attributeMovmentSpeed < 0f)
						{
							BALANCE_attributeMovmentSpeed = 0f;
						}
						break;
					}
				}
				Vector3 position22 = myTransform.position;
				if (position22.x <= 0.25f)
				{
					if (BALANCE_attributeMovmentSpeed > (0f - scriptUnitAttribute.movementSpeedValue) / 6f)
					{
						BALANCE_attributeMovmentSpeed -= 0.001f;
					}
					else if (BALANCE_attributeMovmentSpeed < (0f - scriptUnitAttribute.movementSpeedValue) / 6f)
					{
						BALANCE_attributeMovmentSpeed = (0f - scriptUnitAttribute.movementSpeedValue) / 6f;
					}
				}
				break;
			}
			case 2:
			{
				Vector3 position12 = myTransform.position;
				if (position12.x >= 6.5f + stageLength)
				{
					state = 3;
				}
				break;
			}
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!GetComponent<Collider>().enabled || !(scriptTrigger == null) || !(Time.time >= TIMER_triggerDelay))
		{
			return;
		}
		int num = state;
		if (num != 1 || other.gameObject.name == ID_triggerName || !(other.gameObject.name != ID_triggerName))
		{
			return;
		}
		switch (unitAlignment)
		{
		case 0:
			if (other.gameObject.CompareTag("AtAA") || other.gameObject.CompareTag("AtAAB"))
			{
				TOGGLE_triggerType = 0;
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			if (other.gameObject.CompareTag("AtBA") || other.gameObject.CompareTag("AtBAB"))
			{
				TOGGLE_triggerType = 0;
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			if (other.gameObject.CompareTag("AtSA"))
			{
				TOGGLE_triggerType = 0;
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			if (other.gameObject.CompareTag("AtSAB"))
			{
				if (unitTier == -1)
				{
					TOGGLE_triggerType = 1;
				}
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			break;
		case 1:
			if (other.gameObject.CompareTag("AtAB") || other.gameObject.CompareTag("AtAAB"))
			{
				TOGGLE_triggerType = 0;
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			if (other.gameObject.CompareTag("AtBB") || other.gameObject.CompareTag("AtBAB"))
			{
				TOGGLE_triggerType = 0;
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			if (other.gameObject.CompareTag("AtSB"))
			{
				TOGGLE_triggerType = 0;
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			if (other.gameObject.CompareTag("AtSAB"))
			{
				if (unitTier == -1)
				{
					TOGGLE_triggerType = 1;
				}
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			break;
		}
	}

	private void TriggerDetectFunction(_Trigger detectTrigger)
	{
		if (scriptTrigger == null)
		{
			scriptTrigger = detectTrigger;
			TIMER_triggerDelay = Time.time + 0.1f;
		}
	}

	private void TriggerMinorFunction()
	{
		if (!(scriptTrigger != null))
		{
			return;
		}
		ROLL_evasionPercent = UnityEngine.Random.Range(0, 100);
		ROLL_criticalAccept = UnityEngine.Random.Range(0, 100);
		if (!(ROLL_evasionPercent >= attributeEvasionValue) && unitState != 4 && scriptTrigger.pureEffect <= 0 && scriptTrigger.triggerType != 3)
		{
			return;
		}
		if (scriptTrigger.hpAttributeToggle > 0 && scriptTrigger.hpAttributeAmount > 0)
		{
			DAMAGE_pureEffect = scriptTrigger.pureEffect;
			if (scriptTrigger.hpAttributeToggle == 2)
			{
				if (scriptTrigger.hpAttributeCriticalMultiplier > 1)
				{
					AttributeEffectHP(scriptTrigger.hpAttributeToggle, scriptTrigger.hpAttributeAmount * scriptTrigger.hpAttributeCriticalMultiplier, DAMAGE_pureEffect);
					UnitEffectPropDisplay(3, string.Empty, 0);
				}
				else
				{
					AttributeEffectHP(scriptTrigger.hpAttributeToggle, scriptTrigger.hpAttributeAmount, DAMAGE_pureEffect);
				}
			}
		}
		if (scriptTrigger.hpOverTimeAttributeToggle > 2)
		{
			AttributeOverTimeEffectHP(scriptTrigger.hpOverTimeAttributeToggle, scriptTrigger.hpOverTimeAttributeAmount, scriptTrigger.hpOverTimeAttributeNumber, scriptTrigger.hpOverTimeAttributeDelay, scriptTrigger.hpOverTimeAttributeEffectClass, scriptTrigger.hpOverTimeAttributeEffectNumber);
		}
		if (scriptTrigger.knockEffectToggle > 0)
		{
			UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * attributeKnockResistanceValue, scriptTrigger.knockEffectDamping);
		}
		if (scriptTrigger.riseEffectToggle > 0)
		{
			UnitEffectRise(scriptTrigger.riseEffectToggle, scriptTrigger.riseEffectDuration, scriptTrigger.riseEffectDistance, scriptTrigger.riseEffectDamping);
		}
		if (scriptTrigger.hexEffectToggle > 0)
		{
			UnitEffectHex(scriptTrigger.hexEffectToggle, scriptTrigger.hexEffectDuration);
		}
		if (scriptTrigger.effectSubID != 0)
		{
			INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, myTransform.position, effectHitDisplay.transform.rotation);
			INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, scriptCharacterAnimation.gameObject, scriptTrigger.effectClass, scriptTrigger.effectSubID);
		}
		ID_triggerName = scriptTrigger.name;
		scriptTrigger = null;
	}

	private void TriggerFunction()
	{
		if (!(scriptTrigger != null))
		{
			return;
		}
		ROLL_evasionPercent = UnityEngine.Random.Range(0, 100);
		ROLL_criticalAccept = UnityEngine.Random.Range(0, 100);
		if (scriptTrigger.triggerType == 4 && scriptUnitAttribute.unitTier != 1)
		{
			AttributeEffectHP(1, attributeHealthMaximumValue + 1, 3);
			UnitEffectPropDisplay(3, string.Empty, 0);
			ID_triggerName = scriptTrigger.name;
			scriptTrigger = null;
		}
		else if (ROLL_evasionPercent >= attributeEvasionValue || unitState == 4 || scriptTrigger.pureEffect > 0 || scriptTrigger.triggerType == 3)
		{
			if (scriptTrigger.hpAttributeToggle > 0 && scriptTrigger.hpAttributeAmount > 0)
			{
				if (scriptTrigger.hpAttributeToggle == 1)
				{
					DAMAGE_setToggle = scriptTrigger.hpAttributeToggle;
					DAMAGE_setAmount = scriptTrigger.hpAttributeAmount;
					DAMAGE_pureEffect = scriptTrigger.pureEffect;
					if (scriptUnitAttribute.effectTypeDefense[scriptTrigger.effectType] != 0)
					{
						if (scriptUnitAttribute.effectTypeDefense[scriptTrigger.effectType] > 0)
						{
							if (scriptUnitAttribute.effectTypeDefense[scriptTrigger.effectType] >= 100)
							{
								DAMAGE_setToggle = 2;
							}
							else
							{
								DAMAGE_setAmount -= scriptUnitAttribute.effectTypeDefense[scriptTrigger.effectType];
								if (DAMAGE_setAmount < 1)
								{
									DAMAGE_setAmount = 1;
								}
							}
						}
						else if (scriptUnitAttribute.effectTypeDefense[scriptTrigger.effectType] < 0)
						{
							if (scriptUnitAttribute.effectTypeDefense[scriptTrigger.effectType] <= -100)
							{
								if (unitTier == 1)
								{
									DAMAGE_setAmount -= scriptUnitAttribute.effectTypeDefense[scriptTrigger.effectType];
									DAMAGE_pureEffect = 4;
								}
								else
								{
									DAMAGE_setAmount = attributeHealthValue + 1;
									DAMAGE_pureEffect = 3;
									UnitEffectPropDisplay(12, string.Empty, 0);
								}
							}
							else
							{
								DAMAGE_setAmount -= scriptUnitAttribute.effectTypeDefense[scriptTrigger.effectType];
							}
						}
					}
					if (scriptTrigger.effectClass >= 0 && scriptUnitAttribute.effectClassDefense[scriptTrigger.effectClass] != 0)
					{
						if (scriptUnitAttribute.effectClassDefense[scriptTrigger.effectClass] > 0)
						{
							if (scriptUnitAttribute.effectClassDefense[scriptTrigger.effectClass] > 100)
							{
								DAMAGE_setToggle = 2;
							}
							else
							{
								DAMAGE_setAmount -= scriptUnitAttribute.effectClassDefense[scriptTrigger.effectClass];
								if (DAMAGE_setAmount < 1)
								{
									DAMAGE_setAmount = 1;
								}
							}
						}
						else if (scriptUnitAttribute.effectClassDefense[scriptTrigger.effectClass] < 0)
						{
							if (scriptUnitAttribute.effectClassDefense[scriptTrigger.effectClass] <= -100)
							{
								if (unitTier == 1)
								{
									DAMAGE_setAmount -= scriptUnitAttribute.effectClassDefense[scriptTrigger.effectClass];
									DAMAGE_pureEffect = 4;
								}
								else
								{
									DAMAGE_setAmount = attributeHealthValue + 1;
									DAMAGE_pureEffect = 3;
									UnitEffectPropDisplay(12, string.Empty, 0);
								}
							}
							else
							{
								DAMAGE_setAmount -= scriptUnitAttribute.effectClassDefense[scriptTrigger.effectClass];
							}
						}
					}
					if (DAMAGE_setAmount > 0)
					{
						if (scriptTrigger.hpAttributeCriticalMultiplier > 1 && ROLL_criticalAccept >= 25f)
						{
							AttributeEffectHP(DAMAGE_setToggle, DAMAGE_setAmount * scriptTrigger.hpAttributeCriticalMultiplier, DAMAGE_pureEffect);
							UnitEffectPropDisplay(3, string.Empty, 0);
						}
						else
						{
							AttributeEffectHP(DAMAGE_setToggle, DAMAGE_setAmount, DAMAGE_pureEffect);
						}
						statusDamagedCount++;
					}
					else
					{
						AttributeEffectHP(DAMAGE_setToggle, 0, 0);
					}
				}
				else if (scriptTrigger.hpAttributeToggle == 2)
				{
					if (scriptTrigger.hpAttributeCriticalMultiplier > 1)
					{
						AttributeEffectHP(scriptTrigger.hpAttributeToggle, scriptTrigger.hpAttributeAmount * scriptTrigger.hpAttributeCriticalMultiplier, DAMAGE_pureEffect);
						UnitEffectPropDisplay(3, string.Empty, 0);
					}
					else
					{
						AttributeEffectHP(scriptTrigger.hpAttributeToggle, scriptTrigger.hpAttributeAmount, DAMAGE_pureEffect);
					}
				}
			}
			if (scriptTrigger.hpOverTimeAttributeToggle > 0)
			{
				AttributeOverTimeEffectHP(scriptTrigger.hpOverTimeAttributeToggle, scriptTrigger.hpOverTimeAttributeAmount, scriptTrigger.hpOverTimeAttributeNumber, scriptTrigger.hpOverTimeAttributeDelay, scriptTrigger.hpOverTimeAttributeEffectClass, scriptTrigger.hpOverTimeAttributeEffectNumber);
			}
			if (scriptTrigger.mpAttributeToggle > 0)
			{
				AttributeEffectMP(scriptTrigger.mpAttributeToggle, scriptTrigger.mpAttributeAmount);
			}
			if (scriptTrigger.mrpAttributeToggle > 0)
			{
				AttributeEffectMRP(scriptTrigger.mrpAttributeToggle, scriptTrigger.mrpAttributeAmount, scriptTrigger.mrpAttributeDuration);
			}
			if (scriptTrigger.msAttributeToggle > 0)
			{
				AttributeEffectMS(scriptTrigger.msAttributeToggle, scriptTrigger.msAttributeAmount, scriptTrigger.msAttributeDuration);
			}
			if (scriptTrigger.asAttributeToggle > 0)
			{
				AttributeEffectAS(scriptTrigger.asAttributeToggle, scriptTrigger.asAttributeAmount, scriptTrigger.asAttributeDuration);
			}
			if (scriptTrigger.apAttributeToggle > 0)
			{
				AttributeEffectAP(scriptTrigger.apAttributeToggle, scriptTrigger.apAttributeAmount, scriptTrigger.apAttributeDuration);
			}
			if (scriptTrigger.anpAttributeToggle > 0)
			{
				AttributeEffectANP(scriptTrigger.anpAttributeToggle, scriptTrigger.anpAttributeAmount, scriptTrigger.anpAttributeDuration);
			}
			if (scriptTrigger.dmgAttributeToggle > 0)
			{
				AttributeEffectDMG(scriptTrigger.dmgAttributeToggle, scriptTrigger.dmgAttributeAmount, scriptTrigger.dmgAttributeDuration);
			}
			if (scriptTrigger.crpAttributeToggle > 0)
			{
				AttributeEffectCRP(scriptTrigger.crpAttributeToggle, scriptTrigger.crpAttributeAmount, scriptTrigger.crpAttributeDuration);
			}
			if (scriptTrigger.acpAttributeToggle > 0)
			{
				AttributeEffectACP(scriptTrigger.acpAttributeToggle, scriptTrigger.acpAttributeAmount, scriptTrigger.acpAttributeDuration);
			}
			if (scriptTrigger.evpAttributeToggle > 0)
			{
				AttributeEffectEVP(scriptTrigger.evpAttributeToggle, scriptTrigger.evpAttributeAmount, scriptTrigger.evpAttributeDuration);
			}
			if (scriptTrigger.colorEffectToggle > 0)
			{
				UnitEffectColor(scriptTrigger.colorEffectToggle, scriptTrigger.colorEffectColor, scriptTrigger.colorEffectDuration);
			}
			switch (scriptTrigger.triggerType)
			{
			case 0:
				if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * attributeKnockResistanceValue, scriptTrigger.knockEffectDamping);
				}
				break;
			case 1:
				if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance, scriptTrigger.knockEffectDamping);
				}
				scriptGameStatistic.scoreSpellPoints++;
				break;
			case 2:
				if (scriptTrigger.triggerClass <= 2)
				{
					OBJECTCHARGE_knockDistance = SLPLUS_objectKNK + attributeKnockResistanceValue / 2f * ((float)(scriptTrigger.triggerClass + 1) * 0.6f);
					if (scriptTrigger.knockEffectToggle > 0 && scriptTrigger.knockEffectDistance * attributeKnockResistanceValue > OBJECTCHARGE_knockDistance)
					{
						UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * attributeKnockResistanceValue, scriptTrigger.knockEffectDamping);
					}
					else if (OBJECTCHARGE_knockDistance > 0f)
					{
						UnitEffectKnock(1, 0.4f, OBJECTCHARGE_knockDistance, 5f);
					}
				}
				else if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * attributeKnockResistanceValue, scriptTrigger.knockEffectDamping);
				}
				scriptGameStatistic.scoreObjectPoints++;
				break;
			case 3:
				if (scriptTrigger.triggerClass <= 2)
				{
					OBJECTCHARGE_knockDistance = 1f + SLPLUS_objectKNK + attributeKnockResistanceValue / 4f * ((float)(scriptTrigger.triggerClass + 1) * 0.6f);
					if (scriptTrigger.knockEffectToggle > 0 && scriptTrigger.knockEffectDistance * attributeKnockResistanceValue > OBJECTCHARGE_knockDistance)
					{
						UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * attributeKnockResistanceValue, scriptTrigger.knockEffectDamping);
					}
					else if (OBJECTCHARGE_knockDistance > 0f)
					{
						UnitEffectKnock(1, 0.4f, OBJECTCHARGE_knockDistance, 5f);
					}
				}
				else if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * attributeKnockResistanceValue, scriptTrigger.knockEffectDamping);
				}
				scriptGameStatistic.scoreObjectPoints++;
				break;
			case 4:
				if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance, scriptTrigger.knockEffectDamping);
				}
				scriptGameStatistic.scoreObjectPoints++;
				break;
			}
			if (scriptTrigger.riseEffectToggle > 0)
			{
				UnitEffectRise(scriptTrigger.riseEffectToggle, scriptTrigger.riseEffectDuration, scriptTrigger.riseEffectDistance, scriptTrigger.riseEffectDamping);
			}
			if (scriptTrigger.disableEffectToggle > 0)
			{
				UnitEffectDisable(scriptTrigger.disableEffectToggle, scriptTrigger.disableEffectDuration);
			}
			if (scriptTrigger.hexEffectToggle > 0)
			{
				UnitEffectHex(scriptTrigger.hexEffectToggle, scriptTrigger.hexEffectDuration);
			}
			if (scriptTrigger.effectSubID != 0)
			{
				INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, myTransform.position, effectHitDisplay.transform.rotation);
				INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, scriptCharacterAnimation.gameObject, scriptTrigger.effectClass, scriptTrigger.effectSubID);
			}
			if (scriptTrigger.effectType != 2)
			{
				if (unitTier != -1)
				{
					AMOUNT_disableCombo++;
					DisableComboFunctionState = 1;
				}
				else if (unitTier == -1)
				{
					AMOUNT_disableCombo++;
					DisableComboFunctionState = 1;
				}
			}
			ID_triggerName = scriptTrigger.name;
			scriptTrigger = null;
		}
		else
		{
			UnitEffectPropDisplay(5, string.Empty, 0);
			ID_triggerName = scriptTrigger.name;
			scriptTrigger = null;
		}
	}

	private void UnitStatusInfo()
	{
		switch (state)
		{
		case 1:
			break;
		case 2:
			break;
		case 0:
			statusAttackCount = 0;
			statusDamagedCount = 0;
			statusDisabledCount = 0;
			break;
		}
	}
}
