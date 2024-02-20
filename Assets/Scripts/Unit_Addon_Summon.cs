using UnityEngine;

public class Unit_Addon_Summon : MonoBehaviour
{
	public string summonID;

	public float summonDuration;

	public float summonDestination;

	public int summonNumber;

	public int setNumber;

	private Unit_Control scriptUnitControl;

	private Statistic_Logic scriptStatisticLogic;

	private Transform myTransform;

	private int summonAlignment;

	private int state;

	private float TIMER_summonDuration;

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		scriptUnitControl = GetComponent<Unit_Control>();
		scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		if (summonID == "ISUMMON")
		{
			summonAlignment = 1;
		}
	}

	private void Start()
	{
		if (summonDuration > 0f)
		{
			TIMER_summonDuration = Time.time + summonDuration;
		}
	}

	private void OnSpawned()
	{
		switch (summonAlignment)
		{
		case 0:
			state = 0;
			if (summonDuration > 0f)
			{
				TIMER_summonDuration = Time.time + summonDuration;
			}
			break;
		case 1:
			state = 4;
			if (summonDuration > 0f)
			{
				TIMER_summonDuration = Time.time + summonDuration;
			}
			break;
		}
	}

	private void OnDespawned()
	{
		switch (summonAlignment)
		{
		case 0:
			state = 0;
			if (scriptStatisticLogic != null && summonNumber == scriptStatisticLogic.SummonControl[setNumber].summonNumber)
			{
				scriptStatisticLogic.SummonControl[setNumber].summonID = "null";
				scriptStatisticLogic.SummonControl[setNumber].scriptUnitControl = null;
				scriptStatisticLogic.SummonControl[setNumber].summonNumber = 0;
			}
			break;
		case 1:
			state = 4;
			break;
		}
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			if (summonID != string.Empty)
			{
				for (int l = 0; l < scriptStatisticLogic.SummonControl.Length; l++)
				{
					if (scriptStatisticLogic.SummonControl[l].summonID == summonID)
					{
						scriptStatisticLogic.SummonControl[l].scriptUnitControl.attributeHealthValue = -1;
						scriptStatisticLogic.SummonControl[l].scriptUnitControl = scriptUnitControl;
						scriptStatisticLogic.SummonControl[l].summonNumber = scriptStatisticLogic.currentSummonNumber;
						summonNumber = scriptStatisticLogic.currentSummonNumber;
						scriptStatisticLogic.currentSummonNumber++;
						setNumber = l;
						state = 3;
						l = scriptStatisticLogic.SummonControl.Length;
					}
				}
			}
			state++;
			break;
		case 1:
			for (int k = 0; k < scriptStatisticLogic.SummonControl.Length; k++)
			{
				if (scriptStatisticLogic.SummonControl[k].summonID == "null")
				{
					if (summonID != string.Empty)
					{
						scriptStatisticLogic.SummonControl[k].summonID = summonID;
					}
					else
					{
						scriptStatisticLogic.SummonControl[k].summonID = "STANDARD";
					}
					scriptStatisticLogic.SummonControl[k].scriptUnitControl = GetComponent<Unit_Control>();
					scriptStatisticLogic.SummonControl[k].summonNumber = scriptStatisticLogic.currentSummonNumber;
					summonNumber = scriptStatisticLogic.currentSummonNumber;
					scriptStatisticLogic.currentSummonNumber++;
					setNumber = k;
					state = 3;
					k = scriptStatisticLogic.SummonControl.Length;
				}
			}
			state++;
			break;
		case 2:
			for (int i = 0; i < scriptStatisticLogic.currentSummonNumber; i++)
			{
				for (int j = 0; j < scriptStatisticLogic.SummonControl.Length; j++)
				{
					if (i == scriptStatisticLogic.SummonControl[j].summonNumber)
					{
						scriptStatisticLogic.SummonControl[j].scriptUnitControl.attributeHealthValue = -1;
						if (summonID != string.Empty)
						{
							scriptStatisticLogic.SummonControl[j].summonID = summonID;
						}
						else
						{
							scriptStatisticLogic.SummonControl[j].summonID = "STANDARD";
						}
						scriptStatisticLogic.SummonControl[j].scriptUnitControl = GetComponent<Unit_Control>();
						scriptStatisticLogic.SummonControl[j].summonNumber = scriptStatisticLogic.currentSummonNumber;
						summonNumber = scriptStatisticLogic.currentSummonNumber;
						scriptStatisticLogic.currentSummonNumber++;
						setNumber = j;
						state = 3;
						i = scriptStatisticLogic.currentSummonNumber + 1;
					}
				}
			}
			state++;
			break;
		case 4:
			if (summonDuration > 0f && Time.time >= TIMER_summonDuration)
			{
				state = 10;
			}
			if (summonDestination == 0f)
			{
				break;
			}
			switch (summonAlignment)
			{
			case 0:
			{
				Vector3 position2 = myTransform.position;
				if (position2.x >= summonDestination)
				{
					state = 10;
				}
				break;
			}
			case 1:
			{
				Vector3 position = myTransform.position;
				if (position.x <= summonDestination)
				{
					state = 10;
				}
				break;
			}
			}
			break;
		case 10:
			scriptUnitControl.attributeHealthValue = -1;
			break;
		}
	}
}
