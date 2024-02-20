using System.Collections;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
	public string poolName;

	public Transform testPrefab;

	public int spawnAmount = 50;

	public float spawnInterval = 0.25f;

	public string particlesPoolName;

	public ParticleSystem particleSystemPrefab;

	private SpawnPool shapesPool;

	private SpawnPool particlesPool;

	private void Start()
	{
		shapesPool = PoolManager.Pools[poolName];
		StartCoroutine(Spawner());
		StartCoroutine(ParticleSpawner());
	}

	private IEnumerator ParticleSpawner()
	{
		particlesPool = PoolManager.Pools[particlesPoolName];
		ParticleSystem prefab = particleSystemPrefab;
		Vector3 prefabXform = particleSystemPrefab.transform.position;
		Quaternion prefabRot = particleSystemPrefab.transform.rotation;
		ParticleSystem emitter = particlesPool.Spawn(prefab, prefabXform, prefabRot);
		while (emitter.IsAlive(withChildren: true))
		{
			yield return new WaitForSeconds(3f);
		}
		ParticleSystem inst = particlesPool.Spawn(prefab, prefabXform, prefabRot);
		yield return new WaitForSeconds(3f);
		particlesPool.Despawn(inst.transform);
		yield return new WaitForSeconds(2f);
		particlesPool.Spawn(prefab, prefabXform, prefabRot);
	}

	private IEnumerator Spawner()
	{
		int count = spawnAmount;
		while (count > 0)
		{
			Transform inst = shapesPool.Spawn(testPrefab);
			inst.localPosition = new Vector3(spawnAmount + 2 - count, 0f, 0f);
			count--;
			yield return new WaitForSeconds(spawnInterval);
		}
		StartCoroutine(Despawner());
		yield return null;
	}

	private IEnumerator Despawner()
	{
		while (shapesPool.Count > 0)
		{
			Transform instance = shapesPool[shapesPool.Count - 1];
			shapesPool.Despawn(instance);
			yield return new WaitForSeconds(spawnInterval);
		}
		yield return null;
	}
}
