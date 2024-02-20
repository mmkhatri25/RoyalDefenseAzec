using UnityEngine;

public class pool_spawner : MonoBehaviour
{
	public string poolName;

	public GameObject poolPrefeb;

	private bool activate = true;

	private bool act;

	private void Start()
	{
		activate = true;
		act = false;
	}

	private void OnSpawned()
	{
		activate = true;
		act = false;
	}

	private void Update()
	{
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
