using UnityEngine;

public class SpellType_TrapTrigger : MonoBehaviour
{
	public string despawnPool;

	public int type;

	public int state;

	private int TOGGLE_state;

	public float startDelay;

	private float TIMER_startDelay;

	public float readyDelay;

	private float TIMER_readyDelay;

	public float endDelay;

	private float TIMER_endDelay;

	public string spawnObjectPool;

	public Transform spawnObjectTransform;

	public GameObject spawnObject;

	private float TIMER_rayFPS;

	private float DELAY_rayFPS = 0.2f;

	private Transform myTransform;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		TIMER_startDelay = Time.time + startDelay;
	}

	private void OnSpawned()
	{
		state = 0;
		TIMER_startDelay = Time.time + startDelay;
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			if (TOGGLE_state != state)
			{
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_startDelay)
			{
				state++;
			}
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				TIMER_rayFPS = Time.time + DELAY_rayFPS;
				TIMER_readyDelay = Time.time + readyDelay;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_readyDelay)
			{
				state = 4;
			}
			break;
		case 2:
			PoolManager.Pools[spawnObjectPool].Spawn(spawnObject.transform, spawnObjectTransform.position, spawnObjectTransform.rotation);
			state++;
			break;
		case 3:
			if (TOGGLE_state != state)
			{
				TIMER_endDelay = Time.time + endDelay;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_endDelay)
			{
				state++;
			}
			break;
		case 4:
			switch (type)
			{
			case 0:
				PoolManager.Pools[despawnPool].Despawn(myTransform);
				break;
			case 1:
				state = 0;
				break;
			}
			break;
		}
	}

	private void LateUpdate()
	{
		if (state == 1 && Time.time >= TIMER_rayFPS)
		{
			Vector3 direction = myTransform.TransformDirection(Vector3.forward);
			Vector3 position = myTransform.position;
			Vector3 vector = new Vector3(position.x, -1.5f, -2f);
			if (Physics.Raycast(vector, direction, out RaycastHit hitInfo, 5f))
			{
				UnityEngine.Debug.DrawLine(vector, vector + myTransform.forward * hitInfo.distance, Color.green);
				state = 2;
			}
			else
			{
				UnityEngine.Debug.DrawLine(vector, vector + myTransform.forward * 5f, Color.red);
			}
			TIMER_rayFPS = Time.time + DELAY_rayFPS;
		}
	}
}
