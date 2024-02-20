using System;
using UnityEngine;

public class UnitBehaviour_OffenseRotate : MonoBehaviour
{
	[Serializable]
	public class offensiveBehaviour
	{
		public int attackCountToggle;

		public int damagedCountToggle;

		public int disabledCountToggle;

		public float offensiveRotateDelay = 10f;

		public int unitAttackBehaviour = 1;

		public float unitAttackBehaviourAmountA = 2f;

		public float unitAttackBehaviourAmountB = 1f;

		public float unitAttackBehaviourAmountC = 2f;

		public float unitAttackBehaviourAmountD = 5f;

		public int unitDefensiveBehaviour;

		public float unitDefensiveBehaviourAmountA;

		public float unitDefensiveBehaviourAmountB;

		public float unitDefensiveBehaviourAmountC;

		public float unitDefensiveBehaviourAmountD;

		public Color chargingEffectColor;
	}

	private Unit_Attributes scriptUnitAttribute;

	private Unit_Control scriptUnitControl;

	private CharacterAnimationSet scriptUnitAnimationSet;

	private int AMOUNT_attackCountToggle;

	private int AMOUNT_damagedCountToggle;

	private int AMOUNT_disabledCountToggle;

	private float TIMER_offensiveRotateDelay;

	private float DELAY_CountToggles;

	public offensiveBehaviour[] OffensiveBehaviour = new offensiveBehaviour[5];

	public tk2dAnimatedSprite[] chargingEffectSprite;

	public int offensiveNumber;

	private int TOGGLE_offensiveNumber;

	private int offenseAmount;

	private int TOGGLE_animationNumber;

	private int PREVIOUS_offensiveNumber;

	private int state;

	private void Start()
	{
		base.useGUILayout = false;
		scriptUnitAttribute = GetComponent<Unit_Attributes>();
		scriptUnitControl = GetComponent<Unit_Control>();
		scriptUnitAnimationSet = scriptUnitControl.scriptCharacterAnimation;
		offenseAmount = OffensiveBehaviour.Length;
	}

	private void OnSpawned()
	{
		for (int i = 0; i < chargingEffectSprite.Length; i++)
		{
			chargingEffectSprite[i].GetComponent<Renderer>().enabled = false;
		}
		state = 0;
	}

	private void Update()
	{
		if (Time.timeScale == 0f || scriptUnitControl.state != 1)
		{
			return;
		}
		switch (state)
		{
		case 0:
			AMOUNT_attackCountToggle = scriptUnitControl.statusAttackCount;
			AMOUNT_damagedCountToggle = scriptUnitControl.statusDamagedCount;
			AMOUNT_disabledCountToggle = scriptUnitControl.statusDisabledCount;
			for (offensiveNumber = UnityEngine.Random.Range(0, offenseAmount); offensiveNumber == PREVIOUS_offensiveNumber; offensiveNumber = UnityEngine.Random.Range(0, offenseAmount))
			{
			}
			PREVIOUS_offensiveNumber = offensiveNumber;
			TIMER_offensiveRotateDelay = Time.time + OffensiveBehaviour[offensiveNumber].offensiveRotateDelay;
			scriptUnitControl.unitAttackBehaviour = OffensiveBehaviour[offensiveNumber].unitAttackBehaviour;
			scriptUnitControl.unitAttackBehaviourAmountA = OffensiveBehaviour[offensiveNumber].unitAttackBehaviourAmountA;
			scriptUnitControl.unitAttackBehaviourAmountB = OffensiveBehaviour[offensiveNumber].unitAttackBehaviourAmountB;
			scriptUnitControl.unitAttackBehaviourAmountC = OffensiveBehaviour[offensiveNumber].unitAttackBehaviourAmountC;
			scriptUnitControl.unitAttackBehaviourAmountD = OffensiveBehaviour[offensiveNumber].unitAttackBehaviourAmountD;
			scriptUnitControl.unitDefensiveBehaviour = OffensiveBehaviour[offensiveNumber].unitDefensiveBehaviour;
			scriptUnitControl.unitDefensiveBehaviourAmountA = OffensiveBehaviour[offensiveNumber].unitDefensiveBehaviourAmountA;
			scriptUnitControl.unitDefensiveBehaviourAmountB = OffensiveBehaviour[offensiveNumber].unitDefensiveBehaviourAmountB;
			scriptUnitControl.unitDefensiveBehaviourAmountC = OffensiveBehaviour[offensiveNumber].unitDefensiveBehaviourAmountC;
			scriptUnitControl.unitDefensiveBehaviourAmountD = OffensiveBehaviour[offensiveNumber].unitDefensiveBehaviourAmountD;
			for (int i = 0; i < chargingEffectSprite.Length; i++)
			{
				chargingEffectSprite[i].color = OffensiveBehaviour[offensiveNumber].chargingEffectColor;
				chargingEffectSprite[i].GetComponent<Renderer>().enabled = false;
			}
			scriptUnitAttribute.unitOffenseNumber = offensiveNumber;
			state++;
			break;
		case 1:
			if (scriptUnitControl.statusAttackCount >= OffensiveBehaviour[offensiveNumber].attackCountToggle + AMOUNT_attackCountToggle && OffensiveBehaviour[offensiveNumber].attackCountToggle > 0)
			{
				state = 2;
			}
			if (scriptUnitControl.statusDamagedCount >= OffensiveBehaviour[offensiveNumber].damagedCountToggle + AMOUNT_damagedCountToggle && OffensiveBehaviour[offensiveNumber].damagedCountToggle > 0)
			{
				state = 2;
			}
			if (scriptUnitControl.statusDisabledCount >= OffensiveBehaviour[offensiveNumber].disabledCountToggle + AMOUNT_disabledCountToggle && OffensiveBehaviour[offensiveNumber].disabledCountToggle > 0)
			{
				state = 2;
			}
			if (Time.time >= TIMER_offensiveRotateDelay)
			{
				state = 2;
			}
			if (scriptUnitAttribute.unitOffenseNumber != offensiveNumber)
			{
				scriptUnitAttribute.unitOffenseNumber = offensiveNumber;
			}
			break;
		case 2:
			DELAY_CountToggles = Time.time + 2f;
			state++;
			break;
		case 3:
			if (Time.time >= DELAY_CountToggles)
			{
				state = 0;
			}
			break;
		}
		if (scriptUnitAnimationSet.AnimationNumber == 6)
		{
			if (TOGGLE_animationNumber == scriptUnitAnimationSet.AnimationNumber)
			{
				return;
			}
			if (offensiveNumber != 0)
			{
				for (int j = 0; j < chargingEffectSprite.Length; j++)
				{
					chargingEffectSprite[j].GetComponent<Renderer>().enabled = true;
				}
			}
			TOGGLE_animationNumber = scriptUnitAnimationSet.AnimationNumber;
		}
		else if (TOGGLE_animationNumber == 6)
		{
			for (int k = 0; k < chargingEffectSprite.Length; k++)
			{
				chargingEffectSprite[k].GetComponent<Renderer>().enabled = false;
			}
			TOGGLE_animationNumber = scriptUnitAnimationSet.AnimationNumber;
		}
	}
}
