using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PrefabPool
{
	public Transform prefab;

	internal GameObject prefabGO;

	public int preloadAmount = 1;

	public bool limitInstances;

	public int limitAmount = 100;

	public bool cullDespawned;

	public int cullAbove = 50;

	public int cullDelay = 60;

	public int cullMaxPerPass = 5;

	public bool _logMessages;

	private bool forceLoggingSilent;

	internal SpawnPool spawnPool;

	private bool cullingActive;

	internal List<Transform> spawned = new List<Transform>();

	internal List<Transform> despawned = new List<Transform>();

	private bool _preloaded;

	private bool logMessages
	{
		get
		{
			if (forceLoggingSilent)
			{
				return false;
			}
			if (spawnPool.logMessages)
			{
				return spawnPool.logMessages;
			}
			return _logMessages;
		}
	}

	internal int totalCount
	{
		get
		{
			int num = 0;
			num += spawned.Count;
			return num + despawned.Count;
		}
	}

	internal bool preloaded
	{
		get
		{
			return _preloaded;
		}
		private set
		{
			_preloaded = value;
		}
	}

	public PrefabPool(Transform prefab)
	{
		this.prefab = prefab;
		prefabGO = prefab.gameObject;
	}

	public PrefabPool()
	{
	}

	internal void inspectorInstanceConstructor()
	{
		prefabGO = prefab.gameObject;
		spawned = new List<Transform>();
		despawned = new List<Transform>();
	}

	public void SelfDestruct()
	{
		prefab = null;
		prefabGO = null;
		spawnPool = null;
		foreach (Transform item in despawned)
		{
			UnityEngine.Object.Destroy(item);
		}
		foreach (Transform item2 in spawned)
		{
			UnityEngine.Object.Destroy(item2);
		}
		spawned.Clear();
		despawned.Clear();
	}

	internal bool DespawnInstance(Transform xform)
	{
		if (logMessages)
		{
			UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): Despawning '{xform.name}'");
		}
		spawned.Remove(xform);
		despawned.Add(xform);
		xform.gameObject.BroadcastMessage("OnDespawned", SendMessageOptions.DontRequireReceiver);
		xform.gameObject.SetActiveRecursively(state: false);
		if (!cullingActive && cullDespawned && totalCount > cullAbove)
		{
			cullingActive = true;
			spawnPool.StartCoroutine(CullDespawned());
		}
		return true;
	}

	internal IEnumerator CullDespawned()
	{
		if (logMessages)
		{
			UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): CULLING TRIGGERED! Waiting {cullDelay}sec to begin checking for despawns...");
		}
		yield return new WaitForSeconds(cullDelay);
		while (totalCount > cullAbove)
		{
			for (int i = 0; i < cullMaxPerPass; i++)
			{
				if (totalCount <= cullAbove)
				{
					break;
				}
				if (despawned.Count > 0)
				{
					Transform inst = despawned[0];
					despawned.RemoveAt(0);
					UnityEngine.Object.Destroy(inst.gameObject);
					if (logMessages)
					{
						UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): CULLING to {cullAbove} instances. Now at {totalCount}.");
					}
				}
				else if (logMessages)
				{
					UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): CULLING waiting for despawn. Checking again in {cullDelay}sec");
					break;
				}
			}
			yield return new WaitForSeconds(cullDelay);
		}
		if (logMessages)
		{
			UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): CULLING FINISHED! Stopping");
		}
		cullingActive = false;
		yield return null;
	}

	internal Transform SpawnInstance(Vector3 pos, Quaternion rot)
	{
		Transform transform;
		if (despawned.Count == 0)
		{
			transform = SpawnNew(pos, rot);
		}
		else
		{
			transform = despawned[0];
			despawned.RemoveAt(0);
			spawned.Add(transform);
			if (transform == null)
			{
				string message = "Make sure you didn't delete a despawned instance directly.";
				throw new MissingReferenceException(message);
			}
			if (logMessages)
			{
				UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): respawning '{transform.name}'.");
			}
			transform.position = pos;
			transform.rotation = rot;
			transform.gameObject.SetActiveRecursively(state: true);
		}
		if (transform != null)
		{
			transform.gameObject.BroadcastMessage("OnSpawned", SendMessageOptions.DontRequireReceiver);
		}
		return transform;
	}

	internal Transform SpawnNew(Vector3 pos, Quaternion rot)
	{
		if (limitInstances && totalCount >= limitAmount)
		{
			if (logMessages)
			{
				UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): LIMIT REACHED! Not creating new instances!");
			}
			return null;
		}
		if (pos == Vector3.zero)
		{
			pos = spawnPool.group.position;
		}
		if (rot == Quaternion.identity)
		{
			rot = spawnPool.group.rotation;
		}
		Transform transform = (Transform)UnityEngine.Object.Instantiate(prefab, pos, rot);
		nameInstance(transform);
		transform.parent = spawnPool.group;
		spawned.Add(transform);
		if (logMessages)
		{
			UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): Spawned new instance '{transform.name}'.");
		}
		return transform;
	}

	internal void AddUnpooled(Transform inst, bool despawn)
	{
		nameInstance(inst);
		if (despawn)
		{
			inst.gameObject.SetActiveRecursively(state: false);
			despawned.Add(inst);
		}
		else
		{
			spawned.Add(inst);
		}
	}

	internal List<Transform> PreloadInstances()
	{
		List<Transform> list = new List<Transform>();
		if (preloaded)
		{
			UnityEngine.Debug.Log($"SpawnPool {spawnPool.poolName} ({prefab.name}): Already preloaded! You cannot preload twice. If you are running this through code, make sure it isn't also defined in the Inspector.");
			return list;
		}
		if (prefab == null)
		{
			UnityEngine.Debug.LogError($"SpawnPool {spawnPool.poolName} ({prefab.name}): Prefab cannot be null.");
			return list;
		}
		forceLoggingSilent = true;
		while (totalCount < preloadAmount)
		{
			Transform transform = SpawnNew(Vector3.zero, Quaternion.identity);
			if (transform == null)
			{
				UnityEngine.Debug.LogError($"SpawnPool {spawnPool.poolName} ({prefab.name}): You turned ON 'Limit Instances' and entered a 'Limit Amount' greater than the 'Preload Amount'!");
				continue;
			}
			DespawnInstance(transform);
			list.Add(transform);
		}
		forceLoggingSilent = false;
		if (cullDespawned && totalCount > cullAbove)
		{
			UnityEngine.Debug.LogWarning($"SpawnPool {spawnPool.poolName} ({prefab.name}): You turned ON Culling and entered a 'Cull Above' threshold greater than the 'Preload Amount'! This will cause the culling feature to trigger immediatly, which is wrong conceptually. Only use culling for extreme situations. See the docs.");
		}
		return list;
	}

	private void nameInstance(Transform instance)
	{
		instance.name += (totalCount + 1).ToString("#000");
	}
}
