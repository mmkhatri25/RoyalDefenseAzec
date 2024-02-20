using UnityEngine;

public class Unit_Detection : MonoBehaviour
{
	public GameObject targetObject;

	public int state;

	private Transform myTransform;

	private float TIMER_delay;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void OnSpawned()
	{
		base.name = "Unit Detector";
		TIMER_delay = Time.time + 1f;
	}

	private void OnDespawned()
	{
		state = 0;
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			if (targetObject == null)
			{
				if (Time.time >= TIMER_delay)
				{
					state = 2;
				}
			}
			else
			{
				state++;
			}
			break;
		case 1:
			if (targetObject != null && targetObject.active)
			{
				Transform transform = myTransform;
				Vector3 position = targetObject.transform.position;
				float x = position.x;
				Vector3 position2 = myTransform.position;
				float y = position2.y;
				Vector3 position3 = myTransform.position;
				transform.position = new Vector3(x, y, position3.z);
			}
			else
			{
				state++;
			}
			break;
		case 2:
			targetObject = null;
			PoolManager.Pools["HUD Pool"].Despawn(base.transform);
			break;
		}
	}
}
