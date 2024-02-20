using System.Collections;
using UnityEngine;

public class CreationExample : MonoBehaviour
{
	public Transform testPrefab;

	public string poolName = "Creator";

	public int spawnAmount = 50;

	public float spawnInterval = 0.25f;

	private SpawnPool pool;

	private void Start()
	{
		pool = PoolManager.Pools.Create(poolName);
		pool.group.parent = base.transform;
		pool.group.localPosition = new Vector3(1.5f, 0f, 0f);
		pool.group.localRotation = Quaternion.identity;
		PrefabPool prefabPool = new PrefabPool(testPrefab);
		prefabPool.preloadAmount = 5;
		prefabPool.cullDespawned = true;
		prefabPool.cullAbove = 10;
		prefabPool.cullDelay = 1;
		prefabPool.limitInstances = false;
		prefabPool.limitAmount = 20;
		pool.CreatePrefabPool(prefabPool);
		StartCoroutine(Spawner());
		Transform prefab = PoolManager.Pools["Shapes"].prefabs["Cube"];
		Transform transform = PoolManager.Pools["Shapes"].Spawn(prefab);
		transform.name = "Cube (Spawned By CreationExample.cs)";
	}

	private IEnumerator Spawner()
	{
		int count = spawnAmount;
		while (count > 0)
		{
			Transform inst = pool.Spawn(testPrefab, Vector3.zero, Quaternion.identity);
			inst.localPosition = new Vector3(spawnAmount - count, 0f, 0f);
			count--;
			yield return new WaitForSeconds(spawnInterval);
		}
		StartCoroutine(Despawner());
	}

	private IEnumerator Despawner()
	{
		while (pool.Count > 0)
		{
			Transform instance = pool[pool.Count - 1];
			pool.Despawn(instance);
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
