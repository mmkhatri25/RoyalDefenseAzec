using UnityEngine;

public class Unit_ObjectActiveDeactive : MonoBehaviour
{
	public int activationType;

	private int TOGGLE_activation;

	public Unit_Control scriptUnitControl;

	public GameObject[] gameobjects;

	private int TOGGLE_unitState;

	private void Start()
	{
		base.useGUILayout = false;
	}

	private void OnSpawned()
	{
		TOGGLE_activation = -1;
	}

	private void Update()
	{
		switch (scriptUnitControl.state)
		{
		case 1:
		{
			if (TOGGLE_activation != 1)
			{
				switch (activationType)
				{
				case 0:
					for (int l = 0; l < gameobjects.Length; l++)
					{
						gameobjects[l].SetActiveRecursively(state: true);
					}
					break;
				case 1:
					for (int k = 0; k < gameobjects.Length; k++)
					{
						gameobjects[k].SetActiveRecursively(state: false);
					}
					break;
				}
				TOGGLE_activation = 1;
			}
			int num = activationType;
			if (num != 2)
			{
				break;
			}
			if (scriptUnitControl.GetComponent<Collider>().enabled)
			{
				if (TOGGLE_unitState != 1)
				{
					Transform transform = scriptUnitControl.transform;
					Vector3 position = scriptUnitControl.transform.position;
					float x = position.x;
					Vector3 position2 = scriptUnitControl.transform.position;
					transform.position = new Vector3(x, position2.y, 0f);
					for (int m = 0; m < gameobjects.Length; m++)
					{
						gameobjects[m].SetActiveRecursively(state: false);
					}
					TOGGLE_unitState = 1;
				}
			}
			else if (!scriptUnitControl.GetComponent<Collider>().enabled && TOGGLE_unitState != 0)
			{
				Transform transform2 = scriptUnitControl.transform;
				Vector3 position3 = scriptUnitControl.transform.position;
				float x2 = position3.x;
				Vector3 position4 = scriptUnitControl.transform.position;
				transform2.position = new Vector3(x2, position4.y, -100f);
				for (int n = 0; n < gameobjects.Length; n++)
				{
					gameobjects[n].SetActiveRecursively(state: true);
					Transform transform3 = gameobjects[n].transform;
					Vector3 position5 = gameobjects[n].transform.position;
					float x3 = position5.x;
					Vector3 position6 = gameobjects[n].transform.position;
					transform3.position = new Vector3(x3, position6.y, 0f);
				}
				TOGGLE_unitState = 0;
			}
			break;
		}
		case 2:
			if (TOGGLE_activation == 2)
			{
				break;
			}
			switch (activationType)
			{
			case 0:
				for (int j = 0; j < gameobjects.Length; j++)
				{
					gameobjects[j].SetActiveRecursively(state: false);
				}
				break;
			case 1:
				for (int i = 0; i < gameobjects.Length; i++)
				{
					gameobjects[i].SetActiveRecursively(state: true);
				}
				break;
			}
			TOGGLE_activation = 2;
			break;
		}
	}
}
