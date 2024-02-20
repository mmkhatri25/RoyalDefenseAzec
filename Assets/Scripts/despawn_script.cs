using UnityEngine;

public class despawn_script : MonoBehaviour
{
	public string poolName;

	public float delay = 10f;

	private float timer;

	private void Start()
	{
	}

	private void OnSpawned()
	{
		timer = Time.time + delay;
	}

	private void OnDespawned()
	{
		timer = 0f;
	}

	private void FixedUpdate()
	{
		if (Time.time >= timer)
		{
			PoolManager.Pools[poolName].Despawn(base.transform);
		}
	}
}
