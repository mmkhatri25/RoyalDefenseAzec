using System;
using UnityEngine;

public class spawnerTest : MonoBehaviour
{
	[Serializable]
	public class unit
	{
		public KeyCode unitSpawnKey;

		public Transform unitSpawnPosition;

		public GameObject[] spawnUnit;
	}

	[Serializable]
	public class objectSpawn
	{
		public GameObject spawnObject;

		public Transform spawnObjectPosition;

		public Transform INST;
	}

	private int spawnAmount = 6;

	public int gameWave = 1;

	public int gameLevel;

	public int gameStage;

	public unit[] Unit;

	public objectSpawn[] ObjectSpawn;

	public Object_Logic objectLogic;

	public game_intro_script introScript;

	private int RANDOM_unit;

	private void Start()
	{
		Application.targetFrameRate = 60;
	}

	private void Update()
	{
		if (Time.frameCount % 30 == 0)
		{
			GC.Collect();
		}
		if (UnityEngine.Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
		{
			GC.Collect();
			if (!introScript.activate)
			{
				introScript.activate = true;
			}
			GameScriptsManager.gameLogicScript.gameWaveNumber = gameWave;
			GameScriptsManager.gameLogicScript.gameLevel = gameLevel;
			GameScriptsManager.gameLogicScript.gameStage = gameStage;
			GameScriptsManager.hudControlcScript.waveNumber = gameWave;
			GameScriptsManager.gameStatisticScript.gameStateWaveTierTeamB = 1;
			GameScriptsManager.gameStatisticScript.manaNumber = 1000;
			if (objectLogic != null)
			{
				if (objectLogic.state == -2)
				{
					objectLogic.state = -1;
				}
				else if (objectLogic.state == 1)
				{
					objectLogic.objectState = 1;
				}
			}
			GameScriptsManager.spellLogicScript.spellState = 1;
		}
		if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (gameStage == 0)
			{
				gameWave = 12;
				gameLevel = 17;
				gameStage = 2;
			}
			else if (gameStage == 2)
			{
				gameWave = 1;
				gameLevel = 0;
				gameStage = 0;
			}
		}
		if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
		{
			gameWave++;
			if (gameWave > 12)
			{
				gameWave = 1;
			}
		}
		if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
		{
			gameLevel++;
			if (gameLevel <= 5)
			{
				gameStage = 0;
			}
			else if (gameLevel > 5 && gameLevel <= 11)
			{
				gameStage = 1;
			}
			else if (gameLevel > 11 && gameLevel <= 17)
			{
				gameStage = 2;
			}
			else if (gameLevel > 17)
			{
				gameStage = 0;
				gameLevel = 0;
			}
		}
		if (Input.GetMouseButtonDown(2))
		{
			spawnAmount = 0;
		}
		if (spawnAmount < 6)
		{
			for (int i = 0; i < Unit.Length; i++)
			{
				RANDOM_unit = UnityEngine.Random.Range(0, Unit[i].spawnUnit.Length);
				PoolManager.Pools["Unit Pool"].Spawn(Unit[i].spawnUnit[RANDOM_unit].transform, Unit[i].unitSpawnPosition.position, Unit[i].spawnUnit[RANDOM_unit].transform.rotation);
			}
			spawnAmount++;
		}
		for (int j = 0; j < Unit.Length; j++)
		{
			if (UnityEngine.Input.GetKeyDown(Unit[j].unitSpawnKey))
			{
				RANDOM_unit = UnityEngine.Random.Range(0, Unit[j].spawnUnit.Length);
				PoolManager.Pools["Unit Pool"].Spawn(Unit[j].spawnUnit[RANDOM_unit].transform, Unit[j].unitSpawnPosition.position, Unit[j].spawnUnit[RANDOM_unit].transform.rotation);
			}
		}
		for (int k = 0; k < ObjectSpawn.Length; k++)
		{
			if (ObjectSpawn[k].INST != null)
			{
				Vector3 position = ObjectSpawn[k].INST.position;
				if (position.y >= 100f)
				{
					ObjectSpawn[k].INST = PoolManager.Pools["Object Pool"].Spawn(ObjectSpawn[k].spawnObject.transform, ObjectSpawn[k].spawnObjectPosition.position, ObjectSpawn[k].spawnObject.transform.rotation);
				}
			}
			else
			{
				ObjectSpawn[k].INST = PoolManager.Pools["Object Pool"].Spawn(ObjectSpawn[k].spawnObject.transform, ObjectSpawn[k].spawnObjectPosition.position, ObjectSpawn[k].spawnObject.transform.rotation);
			}
		}
	}
}
