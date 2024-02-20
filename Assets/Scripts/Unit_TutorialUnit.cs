using UnityEngine;

public class Unit_TutorialUnit : MonoBehaviour
{
	private Unit_Attributes unitAttributes;

	private Unit_Control unitControl;

	private Game_Statistics gameStatistic;

	public GameObject indicator;

	private Transform myTransform;

	private float TIMER_state;

	private int state;

	private Vector3 SpawnPosition;

	private void Start()
	{
		base.useGUILayout = false;
		gameStatistic = GameScriptsManager.gameStatisticScript;
		myTransform = base.transform;
		unitAttributes = GetComponent<Unit_Attributes>();
		unitControl = GetComponent<Unit_Control>();
	}

	private void OnSpawned()
	{
		state = 0;
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			if (indicator != null)
			{
				indicator.active = true;
			}
			SpawnPosition = myTransform.position;
			unitAttributes.unitDestinationPosition = -5f;
			unitAttributes.unitOffenseAction = 0;
			GetComponent<Collider>().enabled = true;
			state++;
			break;
		case 1:
			if (unitControl.attributeHealthValue <= 0)
			{
				if (indicator != null)
				{
					indicator.active = false;
				}
				Transform transform = myTransform;
				Vector3 position = myTransform.position;
				float x = position.x;
				float y = SpawnPosition.y;
				Vector3 position2 = myTransform.position;
				transform.position = new Vector3(x, y, position2.z);
				TIMER_state = Time.time + 30f;
				state++;
			}
			break;
		case 2:
			unitAttributes.unitDestinationPosition = SpawnPosition.x + 0.5f;
			unitAttributes.unitOffenseAction = -2;
			GetComponent<Collider>().enabled = false;
			unitControl.state = 2;
			state++;
			break;
		case 3:
			gameStatistic.scoreUnitDefeated++;
			state++;
			break;
		case 4:
			unitControl.state = 1;
			break;
		}
		if (state >= 2)
		{
			Vector3 position3 = myTransform.position;
			if (position3.y != SpawnPosition.y)
			{
				Transform transform2 = myTransform;
				Vector3 position4 = myTransform.position;
				float x2 = position4.x;
				float y2 = SpawnPosition.y;
				Vector3 position5 = myTransform.position;
				transform2.position = new Vector3(x2, y2, position5.z);
			}
			if (indicator != null && indicator.active)
			{
				indicator.active = false;
			}
		}
	}
}
