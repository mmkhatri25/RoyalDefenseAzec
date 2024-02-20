using UnityEngine;

public class spawn_manager : MonoBehaviour
{
	public int activation;

	private int TOGGLE_activation;

	public int spawnerType;

	public int randomType;

	public int randomPositionSet;

	public float raritySpawn;

	public int state;

	private float TIMER_spawnDuration;

	private Transform inst;

	private float offVectorY;

	private Game_Logic gameLogic;

	private float RANDOM_objectType;

	private int SPAWN_objectNumber;

	public GameObject spawnObject;

	public float spawnDuration;

	public int spawnType;

	public int spawnPositionType;

	public Vector3 spawnLocation;

	public GameObject nextSpawnObject;

	public Vector3 nextSpawnLocation;

	public GameObject[] objectSet = new GameObject[10];

	public Vector3[] positionSet = new Vector3[5];

	public int objectSetLength;

	public int positionSetLength;

	public Object_Logic objectLogic;

	private int TOGGLE_objectState;

	private int TOGGLE_waveNumber;

	private void Start()
	{
		base.useGUILayout = false;
		gameLogic = GameScriptsManager.gameLogicScript;
		offVectorY = 90f;
		state = -2;
	}

	private void OnSpawned()
	{
		for (int i = 0; i < objectSet.Length; i++)
		{
			objectSet[i] = null;
		}
		for (int j = 0; j < positionSet.Length; j++)
		{
			positionSet[j] = Vector3.zero;
		}
	}

	private void OnDespawned()
	{
		ResetSpawn();
		randomPositionSet = 0;
		for (int i = 0; i < objectSet.Length; i++)
		{
			objectSet[i] = null;
		}
		for (int j = 0; j < positionSet.Length; j++)
		{
			positionSet[j] = Vector3.zero;
		}
		activation = -2;
		TOGGLE_activation = -2;
	}

	private void Update()
	{
		if (TOGGLE_objectState != objectLogic.objectState)
		{
			switch (objectLogic.objectState)
			{
			case -1:
				activation = 0;
				break;
			case 0:
				activation = 1;
				break;
			case 1:
				if (spawnType > 0)
				{
					if (activation != 1)
					{
						activation = 1;
					}
					else if (state == 1)
					{
						state++;
					}
				}
				break;
			case 2:
				if (activation != 1)
				{
					activation = 1;
				}
				else if (state == 1)
				{
					state++;
				}
				break;
			}
			TOGGLE_objectState = objectLogic.objectState;
		}
		switch (activation)
		{
		case -1:
			break;
		case 0:
			if (TOGGLE_activation != activation)
			{
				ResetSpawn();
				TOGGLE_activation = activation;
			}
			break;
		case 1:
			if (TOGGLE_activation != activation)
			{
				Setup();
				TOGGLE_activation = activation;
			}
			SpawnFunction();
			break;
		}
	}

	private void Setup()
	{
		for (int i = 0; i < objectSet.Length; i++)
		{
			if (objectSet[i] != null)
			{
				objectSetLength++;
			}
		}
		for (int j = 0; j < positionSet.Length; j++)
		{
			if (positionSet[j] != Vector3.zero)
			{
				positionSetLength++;
			}
		}
		if (objectSet[1] != null)
		{
			if (positionSet[1] != Vector3.zero)
			{
				randomType = 3;
			}
			else if (randomPositionSet > 0)
			{
				randomType = 3;
			}
			else if (positionSet[1] == Vector3.zero && randomPositionSet == 0)
			{
				randomType = 1;
			}
		}
		else if (positionSet[1] != Vector3.zero)
		{
			randomType = 2;
		}
		else if (randomPositionSet > 0)
		{
			randomType = 2;
		}
		else if (positionSet[1] == Vector3.zero && randomPositionSet == 0)
		{
			randomType = 0;
		}
	}

	private void ResetSpawn()
	{
		if (inst != null)
		{
			Vector3 position = inst.transform.position;
			if (position.y < offVectorY)
			{
				PoolManager.Pools["Object Pool"].Despawn(inst);
			}
		}
		inst = null;
		TIMER_spawnDuration = 0f;
		spawnObject = null;
		spawnLocation = Vector3.zero;
		nextSpawnObject = null;
		nextSpawnLocation = Vector3.zero;
		objectSetLength = 0;
		positionSetLength = 0;
		state = -2;
	}

	private void SpawnTimerFunction()
	{
		switch (spawnType)
		{
		case 0:
			if (Time.time >= TIMER_spawnDuration)
			{
				state++;
			}
			break;
		case 1:
			if (Time.time >= TIMER_spawnDuration)
			{
				state++;
			}
			break;
		case 2:
			if (TOGGLE_waveNumber != gameLogic.gameWaveNumber)
			{
				TIMER_spawnDuration = 0f;
				TOGGLE_waveNumber = gameLogic.gameWaveNumber;
			}
			if (Time.time >= TIMER_spawnDuration)
			{
				state++;
			}
			break;
		case 3:
			if (gameLogic.gameWaveTier == 1)
			{
				if (Time.time >= TIMER_spawnDuration)
				{
					state++;
				}
			}
			else if (TOGGLE_waveNumber != gameLogic.gameWaveNumber)
			{
				state++;
				TOGGLE_waveNumber = gameLogic.gameWaveNumber;
			}
			break;
		case 4:
			if (Time.time >= TIMER_spawnDuration)
			{
				if (gameLogic.gameWaveTier == 1)
				{
					state++;
				}
				else if (TOGGLE_waveNumber != gameLogic.gameWaveNumber)
				{
					state++;
					TOGGLE_waveNumber = gameLogic.gameWaveNumber;
				}
			}
			break;
		}
	}

	private void SpawnFunctionX()
	{
		switch (state)
		{
		case 0:
			state++;
			break;
		case 1:
			if (gameLogic.gameState != 2)
			{
				state++;
			}
			else
			{
				SpawnTimerFunction();
			}
			break;
		case 2:
			inst = PoolManager.Pools["Object Pool"].Spawn(spawnObject.transform, spawnLocation, spawnObject.transform.rotation);
			state++;
			break;
		case 3:
		{
			Vector3 position = inst.transform.position;
			if (position.y >= offVectorY)
			{
				state++;
				break;
			}
			Vector3 position2 = inst.transform.position;
			if (position2.y <= 0f - offVectorY && inst != null)
			{
				PoolManager.Pools["Object Pool"].Despawn(inst);
			}
			break;
		}
		case 4:
			TIMER_spawnDuration = Time.time + spawnDuration;
			state = 0;
			break;
		}
	}

	private void RandomSpawnObject()
	{
		switch (randomType)
		{
		case 0:
			nextSpawnObject = objectSet[0];
			nextSpawnLocation = positionSet[0];
			break;
		case 1:
			if (raritySpawn > 0f)
			{
				RANDOM_objectType = UnityEngine.Random.Range(0, 100);
				if (RANDOM_objectType >= 100f - raritySpawn)
				{
					SPAWN_objectNumber = UnityEngine.Random.Range(1, objectSetLength);
				}
				else if (RANDOM_objectType < 100f - raritySpawn)
				{
					SPAWN_objectNumber = 0;
				}
			}
			else
			{
				SPAWN_objectNumber = UnityEngine.Random.Range(0, objectSetLength);
			}
			nextSpawnObject = objectSet[SPAWN_objectNumber];
			nextSpawnLocation = positionSet[0];
			break;
		case 2:
			nextSpawnObject = objectSet[0];
			if (randomPositionSet > 0)
			{
				nextSpawnLocation = objectLogic.spawnPositions[randomPositionSet].position[Random.Range(0, objectLogic.spawnPositions[randomPositionSet].position.Length)].transform.position;
				nextSpawnLocation = new Vector3(nextSpawnLocation.x, nextSpawnLocation.y + (float)UnityEngine.Random.Range(0, 4), nextSpawnLocation.z);
			}
			else
			{
				nextSpawnLocation = positionSet[Random.Range(0, positionSetLength)];
			}
			break;
		case 3:
			if (raritySpawn > 0f)
			{
				RANDOM_objectType = UnityEngine.Random.Range(0, 100);
				if (RANDOM_objectType >= 100f - raritySpawn)
				{
					SPAWN_objectNumber = UnityEngine.Random.Range(1, objectSetLength);
				}
				else if (RANDOM_objectType < 100f - raritySpawn)
				{
					SPAWN_objectNumber = 0;
				}
			}
			else
			{
				SPAWN_objectNumber = UnityEngine.Random.Range(0, objectSetLength);
			}
			nextSpawnObject = objectSet[SPAWN_objectNumber];
			if (randomPositionSet > 0)
			{
				nextSpawnLocation = objectLogic.spawnPositions[randomPositionSet].position[Random.Range(0, objectLogic.spawnPositions[randomPositionSet].position.Length)].transform.position;
				nextSpawnLocation = new Vector3(nextSpawnLocation.x, nextSpawnLocation.y + (float)UnityEngine.Random.Range(0, 4), nextSpawnLocation.z);
			}
			else
			{
				nextSpawnLocation = positionSet[Random.Range(0, positionSetLength)];
			}
			break;
		}
	}

	private void SpawnFunction()
	{
		switch (state)
		{
		case 5:
			break;
		case -2:
			TIMER_spawnDuration = 0f;
			RandomSpawnObject();
			state++;
			break;
		case -1:
			spawnObject = nextSpawnObject;
			spawnLocation = nextSpawnLocation;
			state++;
			break;
		case 0:
			if (randomType > 0)
			{
				RandomSpawnObject();
			}
			state++;
			break;
		case 1:
			switch (spawnerType)
			{
			case 0:
				SpawnTimerFunction();
				break;
			case 1:
				if (gameLogic.gameState != 2)
				{
					state++;
				}
				else
				{
					SpawnTimerFunction();
				}
				break;
			}
			break;
		case 2:
			inst = PoolManager.Pools["Object Pool"].Spawn(spawnObject.transform, spawnLocation, spawnObject.transform.rotation);
			state++;
			break;
		case 3:
		{
			if (TOGGLE_waveNumber != gameLogic.gameWaveNumber)
			{
				TOGGLE_waveNumber = gameLogic.gameWaveNumber;
			}
			Vector3 position = inst.transform.position;
			if (position.y >= offVectorY)
			{
				state++;
				break;
			}
			Vector3 position2 = inst.transform.position;
			if (position2.y <= 0f - offVectorY && inst != null)
			{
				PoolManager.Pools["Object Pool"].Despawn(inst);
				if (!inst.gameObject.GetComponent<Rigidbody>().isKinematic)
				{
					inst.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, -1f, 0f);
				}
				state++;
			}
			break;
		}
		case 4:
			if (randomType > 0)
			{
				spawnObject = nextSpawnObject;
				spawnLocation = nextSpawnLocation;
			}
			inst = null;
			TIMER_spawnDuration = Time.time + spawnDuration;
			state = 0;
			break;
		}
	}

	private void SpawnTestFunction()
	{
		switch (state)
		{
		case 5:
			break;
		case -2:
			TIMER_spawnDuration = 0f;
			RandomSpawnObject();
			state++;
			break;
		case -1:
			spawnObject = nextSpawnObject;
			spawnLocation = nextSpawnLocation;
			state++;
			break;
		case 0:
			if (randomType > 0)
			{
				RandomSpawnObject();
			}
			state++;
			break;
		case 1:
			switch (spawnerType)
			{
			case 0:
				SpawnTimerFunction();
				break;
			case 1:
				if (gameLogic.gameState != 2)
				{
					state++;
				}
				else
				{
					SpawnTimerFunction();
				}
				break;
			}
			break;
		case 2:
			inst = PoolManager.Pools["Object Pool"].Spawn(spawnObject.transform, spawnLocation, spawnObject.transform.rotation);
			state++;
			break;
		case 3:
		{
			if (TOGGLE_waveNumber != gameLogic.gameWaveNumber)
			{
				TOGGLE_waveNumber = gameLogic.gameWaveNumber;
			}
			Vector3 position = inst.transform.position;
			if (position.y >= offVectorY)
			{
				state++;
				break;
			}
			Vector3 position2 = inst.transform.position;
			if (position2.y <= 0f - offVectorY && inst != null)
			{
				PoolManager.Pools["Object Pool"].Despawn(inst);
			}
			break;
		}
		case 4:
			if (randomType > 0)
			{
				spawnObject = nextSpawnObject;
				spawnLocation = nextSpawnLocation;
			}
			inst = null;
			TIMER_spawnDuration = Time.time + spawnDuration;
			state = 0;
			break;
		}
	}
}
