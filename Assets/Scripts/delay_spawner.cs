using UnityEngine;

public class delay_spawner : MonoBehaviour
{
	public string poolName;

	public GameObject poolPrefeb;

	public float spawnDelay;

	private float TIMER_spawnDelay;

	private bool activate = true;

	private bool act;

	private void Start()
	{
		activate = false;
		act = false;
		TIMER_spawnDelay = Time.time + spawnDelay;
	}

	private void OnSpawned()
	{
		activate = false;
		act = false;
		TIMER_spawnDelay = Time.time + spawnDelay;
	}

	private void Update()
	{
		if (Time.time >= TIMER_spawnDelay)
		{
			activate = true;
		}
		if (activate)
		{
			if (!act)
			{
				PoolManager.Pools[poolName].Spawn(poolPrefeb.transform, base.transform.position, poolPrefeb.transform.rotation);
				act = true;
			}
			activate = false;
		}
		else
		{
			act = false;
		}
	}
}
