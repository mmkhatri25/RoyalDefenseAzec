using UnityEngine;

public class Object_Spawner_Randomize : MonoBehaviour
{
	public GameObject[] spawnObjects;

	private int TOGGLE_randomSpawn;

	private Transform inst;

	private Game_Logic gameLogic;

	private void Start()
	{
		gameLogic = GameScriptsManager.gameLogicScript;
	}

	private void OnSpawned()
	{
		TOGGLE_randomSpawn = UnityEngine.Random.Range(0, spawnObjects.Length);
		inst = PoolManager.Pools["Object Pool"].Spawn(spawnObjects[TOGGLE_randomSpawn].transform, base.transform.position, base.transform.rotation);
	}

	private void OnDespawned()
	{
		if (inst != null)
		{
			Vector3 position = inst.position;
			if (position.y < 90f)
			{
				PoolManager.Pools["Object Pool"].Despawn(inst);
				inst = null;
			}
		}
		Transform transform = base.transform;
		Vector3 position2 = base.transform.position;
		float x = position2.x;
		Vector3 position3 = base.transform.position;
		transform.position = new Vector3(x, 100f, position3.z);
	}

	private void Update()
	{
		if (gameLogic.gameState == 4)
		{
			PoolManager.Pools["Object Pool"].Despawn(inst.transform);
			return;
		}
		Vector3 position = inst.position;
		if (position.y >= 90f)
		{
			base.transform.position = new Vector3(0f, 100f, 0f);
			inst = null;
			PoolManager.Pools["Object Pool"].Despawn(base.transform);
		}
	}
}
