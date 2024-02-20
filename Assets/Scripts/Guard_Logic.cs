using System;
using UnityEngine;

public class Guard_Logic : MonoBehaviour
{
	[Serializable]
	public class playerGuard
	{
		public GameObject guardUnit;

		public Transform guardUnitPosition;

		public Transform guardObject;

		public Unit_Control scriptUnitControl;
	}

	public int state;

	public int guardNumber;

	public int guardHealthPoint;

	public int guardHealthRegeneration;

	public int effectToggle;

	public float effectDuration;

	public int effectHP;

	public int effectMP;

	public int effectMRP;

	public int effectAP;

	public int effectANP;

	public int effectMS;

	public int effectAS;

	public int effectCRP;

	public int effectACP;

	public int effectEVP;

	public int effectToggleHPOT;

	public int effectAmountHPOT;

	public int effectNumberHPOT;

	public float effectDelayHPOT;

	public int effectIdHPOT;

	public int effectSubIdHPOT;

	public playerGuard[] PlayerGuard;

	public Effect_Property_Display effectTextDisplay;

	private Transform INST_effectTextDisplay;

	private Statistic_Logic scriptStatisticLogic;

	private int TOGGLE_effectHP;

	private int PLUS_hp;

	private int PLUS_HRP;

	private void Awake()
	{
		base.useGUILayout = false;
		GameScriptsManager.guardLogicScript = GetComponent<Guard_Logic>();
	}

	private void Start()
	{
		scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		state = -1;
	}

	private void Update()
	{
		switch (state)
		{
		case -1:
			guardHealthPoint = scriptStatisticLogic.CharacterBaseAttribute[0].characterGuardHealth;
			guardHealthRegeneration = scriptStatisticLogic.CharacterBaseAttribute[0].characterGuardHealthRegeneration;
			break;
		case 0:
			guardHealthPoint = scriptStatisticLogic.InGameAttribute[0].playerGuardHealth;
			guardHealthRegeneration = scriptStatisticLogic.InGameAttribute[0].playerGuardHealthRegeneration;
			for (int m = 0; m < PlayerGuard.Length; m++)
			{
				if (PlayerGuard[m].guardObject != null)
				{
					if (PlayerGuard[m].guardObject.gameObject.active)
					{
						PoolManager.Pools["Unit Pool"].Despawn(PlayerGuard[m].guardObject);
					}
					PlayerGuard[m].guardObject = null;
				}
			}
			for (int n = 0; n < PlayerGuard.Length; n++)
			{
				if (PlayerGuard[n].guardObject == null)
				{
					PlayerGuard[n].guardObject = PoolManager.Pools["Unit Pool"].Spawn(PlayerGuard[n].guardUnit.transform, PlayerGuard[n].guardUnitPosition.position, PlayerGuard[n].guardUnit.transform.rotation);
					Unit_Attributes component = PlayerGuard[n].guardObject.GetComponent<Unit_Attributes>();
					Vector3 position = PlayerGuard[n].guardUnitPosition.position;
					component.unitDestinationPosition = position.x;
					PlayerGuard[n].guardObject.GetComponent<Unit_Attributes>().healthPoint = guardHealthPoint + 10 * n;
					PlayerGuard[n].scriptUnitControl = PlayerGuard[n].guardObject.GetComponent<Unit_Control>();
				}
			}
			state++;
			break;
		case 1:
			for (int l = 0; l < PlayerGuard.Length; l++)
			{
				if (PlayerGuard[l].guardObject.transform.position != PlayerGuard[l].guardUnitPosition.position)
				{
					PlayerGuard[l].guardObject.transform.position = PlayerGuard[l].guardUnitPosition.position;
				}
			}
			state++;
			break;
		case 2:
			if (effectToggle > 0)
			{
				state = 4;
			}
			break;
		case 3:
			state = 2;
			break;
		case 4:
			for (int i = 0; i < PlayerGuard.Length; i++)
			{
				switch (effectToggle)
				{
				case 1:
					if (!PlayerGuard[i].guardObject.gameObject.active || PlayerGuard[i].scriptUnitControl.state != 1)
					{
						break;
					}
					if (effectHP > 0)
					{
						TOGGLE_effectHP = effectHP;
						if (PlayerGuard[i].scriptUnitControl.attributeHealthValue < PlayerGuard[i].scriptUnitControl.attributeHealthMaximumValue)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectHP(2, effectHP, 0);
							TOGGLE_effectHP = 0;
						}
						else
						{
							for (int j = i; j < PlayerGuard.Length; j++)
							{
								if (PlayerGuard[j].scriptUnitControl.attributeHealthValue < PlayerGuard[j].scriptUnitControl.attributeHealthMaximumValue)
								{
									PlayerGuard[j].scriptUnitControl.AttributeEffectHP(2, effectHP, 0);
									TOGGLE_effectHP = 0;
									j = PlayerGuard.Length;
								}
							}
						}
						if (TOGGLE_effectHP > 0)
						{
							PlayerGuard[0].scriptUnitControl.AttributeEffectHP(2, effectHP, 0);
							TOGGLE_effectHP = 0;
						}
					}
					else if (effectHP < 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectHP(3, effectHP * -1, 0);
					}
					if (effectMP > 0)
					{
						if (PlayerGuard[i].scriptUnitControl.attributeManaValue < PlayerGuard[i].scriptUnitControl.attributeManaMaximumValue)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectMP(2, effectMP);
						}
						else
						{
							for (int k = i; k < PlayerGuard.Length; k++)
							{
								if (PlayerGuard[k].scriptUnitControl.attributeManaValue < PlayerGuard[k].scriptUnitControl.attributeManaMaximumValue)
								{
									PlayerGuard[k].scriptUnitControl.AttributeEffectMP(2, effectMP);
									k = PlayerGuard.Length;
								}
							}
						}
					}
					else if (effectMP < 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectMP(1, effectMP * -1);
					}
					if (effectMRP != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectMRP(1, effectMRP, effectDuration);
					}
					if (effectAP != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectAP(1, effectAP, effectDuration);
					}
					if (effectANP != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectANP(1, effectANP, effectDuration);
					}
					if (effectMS != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectMS(1, effectMS, effectDuration);
					}
					if (effectAS != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectAS(1, effectAS, effectDuration);
					}
					if (effectCRP != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectCRP(1, effectCRP, effectDuration);
					}
					if (effectACP != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectACP(1, effectACP, effectDuration);
					}
					if (effectEVP != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeEffectEVP(1, effectEVP, effectDuration);
					}
					if (effectAmountHPOT != 0)
					{
						PlayerGuard[i].scriptUnitControl.AttributeOverTimeEffectHP(effectToggleHPOT, effectAmountHPOT, effectNumberHPOT, effectDelayHPOT, effectIdHPOT, effectSubIdHPOT);
					}
					i = PlayerGuard.Length;
					break;
				case 2:
					if (PlayerGuard[i].guardObject.gameObject.active)
					{
						if (effectHP > 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectHP(2, effectHP, 0);
						}
						else if (effectHP < 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectHP(3, effectHP * -1, 0);
						}
						if (effectMP > 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectMP(2, effectMP);
						}
						else if (effectMP < 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectMP(1, effectMP * -1);
						}
						if (effectMRP != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectMRP(1, effectMP, effectDuration);
						}
						if (effectAP != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectAP(1, effectAP, effectDuration);
						}
						if (effectANP != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectANP(1, effectANP, effectDuration);
						}
						if (effectMS != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectMS(1, effectMS, effectDuration);
						}
						if (effectAS != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectAS(1, effectAS, effectDuration);
						}
						if (effectCRP != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectCRP(1, effectCRP, effectDuration);
						}
						if (effectACP != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectACP(1, effectACP, effectDuration);
						}
						if (effectEVP != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeEffectEVP(1, effectEVP, effectDuration);
						}
						if (effectAmountHPOT != 0)
						{
							PlayerGuard[i].scriptUnitControl.AttributeOverTimeEffectHP(effectToggleHPOT, effectAmountHPOT, effectNumberHPOT, effectDelayHPOT, effectIdHPOT, effectSubIdHPOT);
						}
					}
					break;
				}
			}
			effectHP = 0;
			effectMP = 0;
			effectMRP = 0;
			effectAP = 0;
			effectANP = 0;
			effectMS = 0;
			effectAS = 0;
			effectCRP = 0;
			effectACP = 0;
			effectEVP = 0;
			effectToggleHPOT = 0;
			effectAmountHPOT = 0;
			effectNumberHPOT = 0;
			effectDelayHPOT = 0f;
			effectIdHPOT = 0;
			effectSubIdHPOT = 0;
			effectToggle = 0;
			state = 2;
			break;
		}
	}
}
