using System;
using UnityEngine;

public class Object_Attributes : MonoBehaviour
{
	[Serializable]
	public class offense
	{
		public GameObject spawnObject;

		public Transform spawnObjectPosition;

		public int alignment;

		public int objectAlignmentType;

		public int pureEffect;

		public int effectType;

		public int effectClass;

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

		public int effectSubID;
	}

	public int objectLevitationValue = 1;

	public int objectAlignment;

	public int objectType;

	public int objectTier;

	public int objectIdleType;

	public int objectState;

	private int CLASS_triggerType;

	public int offenseNumber;

	public int healthPoint;

	public int armorPoint;

	public float speedPoint;

	public int criticalPoint;

	public int anchorPoint;

	public int chargeClass;

	public float chargeSize = 1f;

	public int[] effectTypeDefense = new int[10];

	public int[] effectClassDefense = new int[30];

	public offense[] Offense;

	public GameObject[] breakUniqueEffect;

	public GameObject dropEffect;

	public int currentArmorPoint;

	public float currentSpeedPoint;

	public int currentCriticalPoint;

	public int currentAnchorPoint;

	public int plusArmorPoint;

	public int plusSpeedPoint;

	public int plusCriticalPoint;

	public int plusAnchorPoint;

	public int plusStaticArmorPoint;

	public int plusStaticSpeedPoint;

	public int plusStaticCriticalPoint;

	public int plusStaticAnchorPoint;

	public int healthValue;

	public float speedValue;

	public float damageMultiplier;

	public float criticalValue;

	public float knockResistanceValue;

	public float chargeUpDuration;

	private float PERCENT_plusSpeedValue;

	private Statistic_Logic scriptStatisticLogic;

	private int SLPLUS_DMG;

	private float SLPLUS_MS;

	private void Start()
	{
		base.useGUILayout = false;
		scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
	}

	private void OnSpawned()
	{
		AttributePlusReset();
	}

	private void AttributePlusReset()
	{
		healthValue = healthPoint;
		currentArmorPoint = 0;
		currentSpeedPoint = 0f;
		currentCriticalPoint = 0;
		currentAnchorPoint = 0;
		plusArmorPoint = 0;
		plusSpeedPoint = 0;
		plusCriticalPoint = 0;
		plusAnchorPoint = 0;
		plusStaticArmorPoint = 0;
		plusStaticSpeedPoint = 0;
		plusStaticCriticalPoint = 0;
		plusStaticAnchorPoint = 0;
	}

	private void AttributeUpdate()
	{
		if (SLPLUS_DMG != scriptStatisticLogic.InGameAttribute[0].objectPlusDMG + scriptStatisticLogic.InGameAttribute[0].difficultyObjectPlusDMG)
		{
			SLPLUS_DMG = scriptStatisticLogic.InGameAttribute[0].objectPlusDMG + scriptStatisticLogic.InGameAttribute[0].difficultyObjectPlusDMG;
		}
		if (SLPLUS_MS != scriptStatisticLogic.InGameAttribute[0].objectPlusMS)
		{
			SLPLUS_MS = scriptStatisticLogic.InGameAttribute[0].objectPlusMS;
		}
		currentArmorPoint = armorPoint + plusArmorPoint + plusStaticArmorPoint;
		currentSpeedPoint = speedPoint + SLPLUS_MS;
		currentCriticalPoint = criticalPoint + plusCriticalPoint + plusStaticCriticalPoint;
		currentAnchorPoint = anchorPoint + plusAnchorPoint + plusStaticAnchorPoint;
	}

	private void LateUpdate()
	{
		AttributeUpdate();
		ArmorAttribute();
		SpeedAttribute();
		CriticalAttribute();
		AnchorAttribute();
		ChargeUpAttribute();
	}

	private void ArmorAttribute()
	{
		if (currentArmorPoint + plusArmorPoint > 10)
		{
			damageMultiplier = -10f;
			return;
		}
		if (currentArmorPoint + plusArmorPoint < -10)
		{
			damageMultiplier = 10f;
			return;
		}
		switch (currentArmorPoint + plusArmorPoint)
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

	private void ChargeUpAttribute()
	{
		switch (chargeClass)
		{
		case 0:
			chargeUpDuration = 3f;
			break;
		case 1:
			chargeUpDuration = 2.75f;
			break;
		case 2:
			chargeUpDuration = 2.5f;
			break;
		case 3:
			chargeUpDuration = 2.25f;
			break;
		case 4:
			chargeUpDuration = 2f;
			break;
		case 5:
			chargeUpDuration = 1.75f;
			break;
		case 6:
			chargeUpDuration = 1.5f;
			break;
		case 7:
			chargeUpDuration = 1.25f;
			break;
		case 8:
			chargeUpDuration = 1f;
			break;
		case 9:
			chargeUpDuration = 0.75f;
			break;
		case 10:
			chargeUpDuration = 0.5f;
			break;
		case 11:
			chargeUpDuration = 0.4f;
			break;
		case 12:
			chargeUpDuration = 0.3f;
			break;
		case 13:
			chargeUpDuration = 0.2f;
			break;
		case 14:
			chargeUpDuration = 0.15f;
			break;
		case 15:
			chargeUpDuration = 0.1f;
			break;
		}
	}

	private void SpeedAttribute()
	{
		if (currentSpeedPoint < 0f)
		{
			speedValue = 0.05f * PERCENT_plusSpeedValue;
		}
		else
		{
			speedValue = currentSpeedPoint * PERCENT_plusSpeedValue;
		}
		if (plusSpeedPoint + plusStaticSpeedPoint > 10)
		{
			PERCENT_plusSpeedValue = 3f;
			return;
		}
		if (plusSpeedPoint + plusStaticSpeedPoint < -10)
		{
			PERCENT_plusSpeedValue = 0f;
			return;
		}
		switch (plusSpeedPoint)
		{
		case -10:
			PERCENT_plusSpeedValue = 0f;
			break;
		case -9:
			PERCENT_plusSpeedValue = 0.1f;
			break;
		case -8:
			PERCENT_plusSpeedValue = 0.2f;
			break;
		case -7:
			PERCENT_plusSpeedValue = 0.3f;
			break;
		case -6:
			PERCENT_plusSpeedValue = 0.4f;
			break;
		case -5:
			PERCENT_plusSpeedValue = 0.5f;
			break;
		case -4:
			PERCENT_plusSpeedValue = 0.6f;
			break;
		case -3:
			PERCENT_plusSpeedValue = 0.7f;
			break;
		case -2:
			PERCENT_plusSpeedValue = 0.8f;
			break;
		case -1:
			PERCENT_plusSpeedValue = 0.9f;
			break;
		case 0:
			PERCENT_plusSpeedValue = 1f;
			break;
		case 1:
			PERCENT_plusSpeedValue = 1.2f;
			break;
		case 2:
			PERCENT_plusSpeedValue = 1.4f;
			break;
		case 3:
			PERCENT_plusSpeedValue = 1.6f;
			break;
		case 4:
			PERCENT_plusSpeedValue = 1.8f;
			break;
		case 5:
			PERCENT_plusSpeedValue = 2f;
			break;
		case 6:
			PERCENT_plusSpeedValue = 2.2f;
			break;
		case 7:
			PERCENT_plusSpeedValue = 2.4f;
			break;
		case 8:
			PERCENT_plusSpeedValue = 2.6f;
			break;
		case 9:
			PERCENT_plusSpeedValue = 2.8f;
			break;
		case 10:
			PERCENT_plusSpeedValue = 3f;
			break;
		}
	}

	private void CriticalAttribute()
	{
		if (currentCriticalPoint > 20)
		{
			criticalValue = 48f;
			return;
		}
		if (currentCriticalPoint < 0)
		{
			criticalValue = 0f;
			return;
		}
		switch (currentCriticalPoint + criticalPoint)
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
		switch (currentAnchorPoint + plusAnchorPoint)
		{
		case -10:
			knockResistanceValue = 3f;
			break;
		case -9:
			knockResistanceValue = 2.8f;
			break;
		case -8:
			knockResistanceValue = 2.6f;
			break;
		case -7:
			knockResistanceValue = 2.4f;
			break;
		case -6:
			knockResistanceValue = 2.2f;
			break;
		case -5:
			knockResistanceValue = 2f;
			break;
		case -4:
			knockResistanceValue = 1.8f;
			break;
		case -3:
			knockResistanceValue = 1.6f;
			break;
		case -2:
			knockResistanceValue = 1.4f;
			break;
		case -1:
			knockResistanceValue = 1.2f;
			break;
		case 0:
			knockResistanceValue = 1f;
			break;
		case 1:
			knockResistanceValue = 0.9f;
			break;
		case 2:
			knockResistanceValue = 0.8f;
			break;
		case 3:
			knockResistanceValue = 0.7f;
			break;
		case 4:
			knockResistanceValue = 0.6f;
			break;
		case 5:
			knockResistanceValue = 0.5f;
			break;
		case 6:
			knockResistanceValue = 0.4f;
			break;
		case 7:
			knockResistanceValue = 0.3f;
			break;
		case 8:
			knockResistanceValue = 0.2f;
			break;
		case 9:
			knockResistanceValue = 0.1f;
			break;
		case 10:
			knockResistanceValue = 0f;
			break;
		}
	}

	public void TriggerTransfer(_Trigger scriptTrigger, int criticalMultiplier)
	{
		scriptTrigger.alignment = objectAlignment;
		scriptTrigger.alignmentType = Offense[offenseNumber].objectAlignmentType;
		switch (objectType)
		{
		case 0:
			switch (objectTier)
			{
			case 0:
				scriptTrigger.triggerType = 2;
				break;
			case 1:
				scriptTrigger.triggerType = 4;
				break;
			}
			scriptTrigger.triggerClass = offenseNumber;
			break;
		case 1:
			switch (objectTier)
			{
			case 0:
				scriptTrigger.triggerType = 2;
				break;
			case 1:
				scriptTrigger.triggerType = 4;
				break;
			}
			scriptTrigger.triggerClass = 0;
			break;
		case 2:
			switch (objectTier)
			{
			case 0:
				scriptTrigger.triggerType = 3;
				break;
			case 1:
				scriptTrigger.triggerType = 4;
				break;
			}
			scriptTrigger.triggerClass = offenseNumber;
			break;
		case 3:
			switch (objectTier)
			{
			case 0:
				scriptTrigger.triggerType = 0;
				break;
			case 1:
				scriptTrigger.triggerType = 4;
				break;
			}
			scriptTrigger.triggerClass = 0;
			break;
		}
		scriptTrigger.pureEffect = Offense[offenseNumber].pureEffect;
		scriptTrigger.effectType = Offense[offenseNumber].effectType;
		scriptTrigger.effectClass = Offense[offenseNumber].effectClass;
		scriptTrigger.hpAttributeCriticalMultiplier = criticalMultiplier;
		scriptTrigger.hpAttributeToggle = Offense[offenseNumber].hpAttributeToggle;
		if (Offense[offenseNumber].hpAttributeToggle == 1)
		{
			scriptTrigger.hpAttributeAmount = Offense[offenseNumber].hpAttributeAmount + SLPLUS_DMG;
		}
		else
		{
			scriptTrigger.hpAttributeAmount = Offense[offenseNumber].hpAttributeAmount;
		}
		scriptTrigger.hpOverTimeAttributeToggle = Offense[offenseNumber].hpOverTimeAttributeToggle;
		scriptTrigger.hpOverTimeAttributeAmount = Offense[offenseNumber].hpOverTimeAttributeAmount;
		scriptTrigger.hpOverTimeAttributeNumber = Offense[offenseNumber].hpOverTimeAttributeNumber;
		scriptTrigger.hpOverTimeAttributeDelay = Offense[offenseNumber].hpOverTimeAttributeDelay;
		scriptTrigger.hpOverTimeAttributeEffectClass = Offense[offenseNumber].hpOverTimeAttributeEffectClass;
		scriptTrigger.hpOverTimeAttributeEffectNumber = Offense[offenseNumber].hpOverTimeAttributeEffectNumber;
		scriptTrigger.mpAttributeToggle = Offense[offenseNumber].mpAttributeToggle;
		scriptTrigger.mpAttributeAmount = Offense[offenseNumber].mpAttributeAmount;
		scriptTrigger.colorEffectToggle = Offense[offenseNumber].colorEffectToggle;
		scriptTrigger.colorEffectColor = Offense[offenseNumber].colorEffectColor;
		scriptTrigger.colorEffectDuration = Offense[offenseNumber].colorEffectDuration;
		scriptTrigger.disableEffectToggle = Offense[offenseNumber].disableEffectToggle;
		scriptTrigger.disableEffectDuration = Offense[offenseNumber].disableEffectDuration;
		scriptTrigger.riseEffectToggle = Offense[offenseNumber].riseEffectToggle;
		scriptTrigger.riseEffectDistance = Offense[offenseNumber].riseEffectDistance;
		scriptTrigger.riseEffectDuration = Offense[offenseNumber].riseEffectDuration;
		scriptTrigger.riseEffectDamping = Offense[offenseNumber].riseEffectDamping;
		scriptTrigger.knockEffectToggle = Offense[offenseNumber].knockEffectToggle;
		scriptTrigger.knockEffectDistance = Offense[offenseNumber].knockEffectDistance;
		scriptTrigger.knockEffectDuration = Offense[offenseNumber].knockEffectDuration;
		scriptTrigger.knockEffectDamping = Offense[offenseNumber].knockEffectDamping;
		scriptTrigger.dmgAttributeToggle = Offense[offenseNumber].dmgAttributeToggle;
		scriptTrigger.dmgAttributeAmount = Offense[offenseNumber].dmgAttributeAmount;
		scriptTrigger.dmgAttributeDuration = Offense[offenseNumber].dmgAttributeDuration;
		scriptTrigger.msAttributeToggle = Offense[offenseNumber].msAttributeToggle;
		scriptTrigger.msAttributeAmount = Offense[offenseNumber].msAttributeAmount;
		scriptTrigger.msAttributeDuration = Offense[offenseNumber].msAttributeDuration;
		scriptTrigger.asAttributeToggle = Offense[offenseNumber].asAttributeToggle;
		scriptTrigger.asAttributeAmount = Offense[offenseNumber].asAttributeAmount;
		scriptTrigger.asAttributeDuration = Offense[offenseNumber].asAttributeDuration;
		scriptTrigger.apAttributeToggle = Offense[offenseNumber].apAttributeToggle;
		scriptTrigger.apAttributeAmount = Offense[offenseNumber].apAttributeAmount;
		scriptTrigger.apAttributeDuration = Offense[offenseNumber].apAttributeDuration;
		scriptTrigger.mrpAttributeToggle = Offense[offenseNumber].mrpAttributeToggle;
		scriptTrigger.mrpAttributeAmount = Offense[offenseNumber].mrpAttributeAmount;
		scriptTrigger.mrpAttributeDuration = Offense[offenseNumber].mrpAttributeDuration;
		scriptTrigger.crpAttributeToggle = Offense[offenseNumber].crpAttributeToggle;
		scriptTrigger.crpAttributeAmount = Offense[offenseNumber].crpAttributeAmount;
		scriptTrigger.crpAttributeDuration = Offense[offenseNumber].crpAttributeDuration;
		scriptTrigger.acpAttributeToggle = Offense[offenseNumber].acpAttributeAmount;
		scriptTrigger.acpAttributeAmount = Offense[offenseNumber].acpAttributeAmount;
		scriptTrigger.acpAttributeDuration = Offense[offenseNumber].acpAttributeDuration;
		scriptTrigger.evpAttributeToggle = Offense[offenseNumber].evpAttributeToggle;
		scriptTrigger.evpAttributeAmount = Offense[offenseNumber].evpAttributeAmount;
		scriptTrigger.evpAttributeDuration = Offense[offenseNumber].evpAttributeDuration;
		scriptTrigger.effectClassID = Offense[offenseNumber].effectClass;
		scriptTrigger.effectSubID = Offense[offenseNumber].effectSubID;
	}
}
