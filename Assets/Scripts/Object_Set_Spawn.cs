using System;
using UnityEngine;

public class Object_Set_Spawn : MonoBehaviour
{
	[Serializable]
	public class objectSpawn
	{
		public GameObject spawnObject;

		public Transform inst;
	}

	public int heightAdjustment;

	public objectSpawn[] ObjectSpawn;

	private int setAmount;

	private void Start()
	{
	}

	private void OnSpawned()
	{
		setAmount = ObjectSpawn.Length;
		for (int i = 0; i < ObjectSpawn.Length; i++)
		{
			objectSpawn obj = ObjectSpawn[i];
			SpawnPool spawnPool = PoolManager.Pools["Object Pool"];
			Transform transform = ObjectSpawn[i].spawnObject.transform;
			Vector3 position = base.transform.position;
			float x = position.x;
			Vector3 position2 = base.transform.position;
			float y = position2.y + (float)(heightAdjustment * i);
			Vector3 position3 = base.transform.position;
			obj.inst = spawnPool.Spawn(transform, new Vector3(x, y, position3.z), base.transform.rotation);
		}
	}

	private void OnDespawned()
	{
		for (int i = 0; i < ObjectSpawn.Length; i++)
		{
			if (ObjectSpawn[i].inst != null)
			{
				PoolManager.Pools["Object Pool"].Despawn(ObjectSpawn[i].inst);
				ObjectSpawn[i].inst = null;
			}
		}
		Transform transform = base.transform;
		Vector3 position = base.transform.position;
		float x = position.x;
		Vector3 position2 = base.transform.position;
		transform.position = new Vector3(x, 100f, position2.z);
	}

	private void LateUpdate()
	{
		if (setAmount > 0)
		{
			for (int i = 0; i < ObjectSpawn.Length; i++)
			{
				if (ObjectSpawn[i].inst != null)
				{
					Vector3 position = ObjectSpawn[i].inst.transform.position;
					if (position.y > 90f)
					{
						setAmount--;
						ObjectSpawn[i].inst = null;
					}
				}
			}
		}
		else if (setAmount <= 0)
		{
			PoolManager.Pools["Object Pool"].Despawn(base.transform);
		}
	}
}
