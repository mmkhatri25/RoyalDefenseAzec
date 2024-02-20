using UnityEngine;

public class random_pool_spawner : MonoBehaviour
{
	public string poolName;

	public GameObject[] poolPrefeb;

	private bool activate = true;

	private bool act;

	private int RANDOM_poolPrefeb;

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
				RANDOM_poolPrefeb = UnityEngine.Random.Range(0, poolPrefeb.Length);
				PoolManager.Pools[poolName].Spawn(poolPrefeb[RANDOM_poolPrefeb].transform, base.transform.position, poolPrefeb[RANDOM_poolPrefeb].transform.rotation);
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
