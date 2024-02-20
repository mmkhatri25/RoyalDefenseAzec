using System;
using UnityEngine;

public class Level_Logic : MonoBehaviour
{
	[Serializable]
	public class LevelSpawn
	{
		[Serializable]
		public class WaveSpawn
		{
			[Serializable]
			public class EnemySpawn
			{
				public GameObject EnemyPrefab;

				public int EnemyAmount = 10;

				public int EnemyChance = 10;
			}

			public int NumberOfEnemy;

			public float SpawnRatio = 5f;

			public EnemySpawn[] enemySpawn;
		}

		public string levelName;

		public WaveSpawn[] waveSpawn;
	}

	[Serializable]
	public class bossSpeech
	{
		public int speechType;

		public string portraitID;

		public string warningQuote = "A CHAMPION";

		public string introductionSpeech = "speech";

		public string championName = "name";

		public float minSpawnRatio;

		public float maxSpawnRatio;

		public int musicTrackNumber;
	}

	private Vector3 spawnPosition = new Vector3(6.5f, 0f, 0f);

	private float stageLength;

	private Game_Data data;

	private HUD_Control hudControl;

	private Game_Logic gameLogic;

	private Game_Statistics gameStatistic;

	private Guard_Logic scriptGuardLogic;

	private level_setup levelSetup;

	public int gameStage = -1;

	public int gameLevel = -1;

	public int levelWaveAmount;

	public int currentLevelWaveNumber;

	public float waveDuration = 10f;

	private float TIMER_waveDuration;

	private int TOGGLE_waveDuration;

	public float waveSpawnRatio;

	private float TIMER_waveSpawnRatio;

	private float MIN_waveSpawnRatio;

	private float MAX_waveSpawnRatio;

	public int enemySpawnAmount;

	public int currentEnemySpawnNumber;

	public int levelMode = -1;

	private int TOGGLE_levelMode = -100;

	public int waveMode = -1;

	private int RANDOM_unitType;

	public GameObject championManaSpawn;

	public LevelSpawn[] levelSpawn;

	private float introDelay = 4f;

	private float TIMER_introDelay;

	public game_intro_script scriptIntro;

	public bossSpeech[] BossSpeech = new bossSpeech[21];

	public GameObject[] challengeUnits = new GameObject[54];

	public GameObject[] challengeChampionUnits = new GameObject[18];

	public int challengeWaveNumber;

	public int challengeUnitAmount;

	public int challengeUnitSpawnedAmount;

	public int challengeUnitLineUpAmount;

	public float challengeSpawnRatio = 5f;

	private int challengeChampionWave = 6;

	public int challengeChampionLevelNumber = 1;

	public int challengeChampionNumber;

	public int challengeNextChampionNumber;

	public GameObject[] challengeEnemySpawn = new GameObject[8];

	public GameObject[] challengeNextEnemySpawn = new GameObject[8];

	private int challengeState;

	private float TIMER_challengeSpawnRatio;

	private int EnemySpawnRandom;

	private int PREVIOUS_EnemySpawnRandom;

	private int TOGGLE_characterTutorial;

	public GameObject characterTutorial;

	private int debugMode;

	private int TOGGLE_preLoad;

	private Transform INST1_preLoadUnit;

	private Transform INST2_preLoadUnit;

	private float TIMER_championStartDelay;

	private int TOGGLE_challengeWaveType;

	private int RANDOM_challengeChampionSpawnNumber;

	private int stageGrowthNumber = 4;

	private int stageGrowthLevelNumber = 1;

	private int NUMBER_waveSpawnRatio;

	private void Start()
	{
		base.useGUILayout = false;
		data = ScriptsManager.dataScript;
		hudControl = GameScriptsManager.hudControlcScript;
		gameLogic = GameScriptsManager.gameLogicScript;
		gameStatistic = GameScriptsManager.gameStatisticScript;
		scriptGuardLogic = GameScriptsManager.guardLogicScript;
		levelSetup = ScriptsManager.levelSetupScript;
		stageLength = GameScriptsManager.masterControlScript.stageLength;
		debugMode = GameScriptsManager.masterControlScript.debugMode;
		characterTutorial = levelSetup.characterTutorial;
		spawnPosition = new Vector3(6.5f + stageLength, 0f, 0f);
		LevelSetup();
		ScriptsManager.objectLogicScript.state = -1;
	}

	private void LevelSetup()
	{
		if (data.gameMode != 2)
		{
			for (int i = 0; i < levelSpawn.Length; i++)
			{
				levelSpawn[i].levelName = levelSetup.levelSpawn[i].levelName;
				for (int j = 0; j < levelSpawn[i].waveSpawn.Length; j++)
				{
					levelSpawn[i].waveSpawn[j].NumberOfEnemy = levelSetup.levelSpawn[i].waveSpawn[j].NumberOfEnemy;
					levelSpawn[i].waveSpawn[j].SpawnRatio = levelSetup.levelSpawn[i].waveSpawn[j].SpawnRatio;
					for (int k = 0; k < levelSpawn[i].waveSpawn[j].enemySpawn.Length; k++)
					{
						levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyPrefab = levelSetup.levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyPrefab;
						levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyAmount = levelSetup.levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyAmount;
						levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyChance = levelSetup.levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyChance;
					}
				}
			}
			for (int l = 0; l < BossSpeech.Length - 1; l++)
			{
				BossSpeech[l].speechType = levelSetup.BossSpeech[l].speechType;
				BossSpeech[l].portraitID = levelSetup.BossSpeech[l].portraitID;
				BossSpeech[l].warningQuote = levelSetup.BossSpeech[l].warningQuote;
				BossSpeech[l].introductionSpeech = levelSetup.BossSpeech[l].introductionSpeech;
				BossSpeech[l].championName = levelSetup.BossSpeech[l].championName;
				BossSpeech[l].minSpawnRatio = levelSetup.BossSpeech[l].minSpawnRatio;
				BossSpeech[l].maxSpawnRatio = levelSetup.BossSpeech[l].maxSpawnRatio;
				BossSpeech[l].musicTrackNumber = levelSetup.BossSpeech[l].musicTrackNumber;
			}
			return;
		}
		for (int m = 0; m < levelSetup.levelSpawn.Length; m++)
		{
			BossSpeech[m].speechType = levelSetup.BossSpeech[m].speechType;
			BossSpeech[m].portraitID = levelSetup.BossSpeech[m].portraitID;
			BossSpeech[m].warningQuote = levelSetup.BossSpeech[m].warningQuote;
			BossSpeech[m].introductionSpeech = levelSetup.BossSpeech[m].introductionSpeech;
			BossSpeech[m].championName = levelSetup.BossSpeech[m].championName;
			BossSpeech[m].minSpawnRatio = levelSetup.BossSpeech[m].minSpawnRatio;
			BossSpeech[m].maxSpawnRatio = levelSetup.BossSpeech[m].maxSpawnRatio;
			BossSpeech[m].musicTrackNumber = levelSetup.BossSpeech[m].musicTrackNumber;
		}
		for (int n = 0; n < levelSetup.RecurringUnitList.Length; n++)
		{
			for (int num = 0; num < levelSetup.RecurringUnitList[n].recurringUnits.Length; num++)
			{
				challengeUnits[n * 3 + num] = levelSetup.RecurringUnitList[n].recurringUnits[num];
			}
		}
		for (int num2 = 0; num2 < levelSetup.levelSpawn.Length; num2++)
		{
			challengeChampionUnits[num2] = levelSetup.levelSpawn[num2].waveSpawn[levelSetup.levelSpawn[num2].waveSpawn.Length - 1].enemySpawn[0].EnemyPrefab;
		}
	}

	private void Update()
	{
		LevelUpdate();
		switch (gameLogic.gameMode)
		{
		case 0:
			LevelFunction();
			break;
		case 1:
			TutorialSetup();
			break;
		case 2:
			ChallengeFunction();
			break;
		}
	}

	private void TutorialSetup()
	{
		if (TOGGLE_characterTutorial != 0)
		{
			return;
		}
		for (int i = 0; i < levelSpawn[gameLevel].waveSpawn.Length; i++)
		{
			if (i == levelSpawn[gameLevel].waveSpawn.Length - 1)
			{
				for (int j = 0; j < levelSpawn[gameLevel].waveSpawn[i].enemySpawn.Length; j++)
				{
					INST1_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[i].enemySpawn[j].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[i].enemySpawn[j].EnemyPrefab.transform.rotation);
					PoolManager.Pools["Unit Pool"].Despawn(INST1_preLoadUnit);
				}
				continue;
			}
			for (int k = 0; k < levelSpawn[gameLevel].waveSpawn[i].enemySpawn.Length; k++)
			{
				INST1_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[i].enemySpawn[k].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[i].enemySpawn[k].EnemyPrefab.transform.rotation);
				INST2_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[i].enemySpawn[k].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[i].enemySpawn[k].EnemyPrefab.transform.rotation);
				PoolManager.Pools["Unit Pool"].Despawn(INST1_preLoadUnit);
				PoolManager.Pools["Unit Pool"].Despawn(INST2_preLoadUnit);
			}
		}
		TOGGLE_preLoad = 1;
		if (characterTutorial != null)
		{
			UnityEngine.Object.Instantiate(characterTutorial, Vector3.zero, Quaternion.identity);
		}
		else
		{
			gameLogic.gameMode = 0;
		}
		TOGGLE_characterTutorial = 1;
	}

	private void LevelUpdate()
	{
		if (gameStage != data.gameStage)
		{
			gameStage = data.gameStage;
		}
		if (gameLevel != data.gameLevel)
		{
			gameLevel = data.gameLevel;
		}
	}

	private void LevelFunction()
	{
		switch (gameLogic.gameState)
		{
		case 3:
			break;
		case -1:
			if (TOGGLE_preLoad == 1)
			{
				break;
			}
			for (int i = 0; i < levelSpawn[gameLevel].waveSpawn.Length; i++)
			{
				if (i == levelSpawn[gameLevel].waveSpawn.Length - 1)
				{
					for (int j = 0; j < levelSpawn[gameLevel].waveSpawn[i].enemySpawn.Length; j++)
					{
						INST1_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[i].enemySpawn[j].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[i].enemySpawn[j].EnemyPrefab.transform.rotation);
						PoolManager.Pools["Unit Pool"].Despawn(INST1_preLoadUnit);
					}
					continue;
				}
				for (int k = 0; k < levelSpawn[gameLevel].waveSpawn[i].enemySpawn.Length; k++)
				{
					INST1_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[i].enemySpawn[k].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[i].enemySpawn[k].EnemyPrefab.transform.rotation);
					INST2_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[i].enemySpawn[k].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[i].enemySpawn[k].EnemyPrefab.transform.rotation);
					PoolManager.Pools["Unit Pool"].Despawn(INST1_preLoadUnit);
					PoolManager.Pools["Unit Pool"].Despawn(INST2_preLoadUnit);
				}
			}
			TOGGLE_preLoad = 1;
			break;
		case 0:
			if (TOGGLE_preLoad == 1)
			{
				break;
			}
			for (int l = 0; l < levelSpawn[gameLevel + 1].waveSpawn.Length; l++)
			{
				if (l == levelSpawn[gameLevel + 1].waveSpawn.Length - 1)
				{
					for (int m = 0; m < levelSpawn[gameLevel + 1].waveSpawn[l].enemySpawn.Length; m++)
					{
						INST1_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel + 1].waveSpawn[l].enemySpawn[m].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel + 1].waveSpawn[l].enemySpawn[m].EnemyPrefab.transform.rotation);
						PoolManager.Pools["Unit Pool"].Despawn(INST1_preLoadUnit);
					}
					continue;
				}
				for (int n = 0; n < levelSpawn[gameLevel + 1].waveSpawn[l].enemySpawn.Length; n++)
				{
					INST1_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel + 1].waveSpawn[l].enemySpawn[n].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel + 1].waveSpawn[l].enemySpawn[n].EnemyPrefab.transform.rotation);
					INST2_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel + 1].waveSpawn[l].enemySpawn[n].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel + 1].waveSpawn[l].enemySpawn[n].EnemyPrefab.transform.rotation);
					PoolManager.Pools["Unit Pool"].Despawn(INST1_preLoadUnit);
					PoolManager.Pools["Unit Pool"].Despawn(INST2_preLoadUnit);
				}
			}
			TOGGLE_preLoad = 1;
			break;
		case 1:
			TIMER_introDelay = Time.time;
			break;
		case 2:
			LevelIntroFunction();
			WaveFunction();
			break;
		case 4:
			if (TOGGLE_preLoad != 0)
			{
				scriptIntro.activate = false;
				waveMode = 0;
				TOGGLE_levelMode = -1;
				levelMode = 0;
				TOGGLE_preLoad = 0;
			}
			break;
		}
	}

	private void ChallengeFunction()
	{
		switch (gameLogic.gameState)
		{
		case 3:
			break;
		case -1:
			if (TOGGLE_preLoad != 1)
			{
				for (int i = 0; i < challengeUnits.Length; i++)
				{
					INST1_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(challengeUnits[i].transform, spawnPosition, challengeUnits[i].transform.rotation);
					INST2_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(challengeUnits[i].transform, spawnPosition, challengeUnits[i].transform.rotation);
					PoolManager.Pools["Unit Pool"].Despawn(INST1_preLoadUnit);
					PoolManager.Pools["Unit Pool"].Despawn(INST2_preLoadUnit);
				}
				for (int j = 0; j < challengeEnemySpawn.Length; j++)
				{
					challengeEnemySpawn[j] = challengeUnits[UnityEngine.Random.Range(0, challengeUnits.Length)];
				}
				challengeNextChampionNumber = UnityEngine.Random.Range(1, 6);
				GameScriptsManager.masterControlScript.bossTrack = BossSpeech[challengeNextChampionNumber].musicTrackNumber;
				challengeUnitLineUpAmount = 3;
				challengeWaveNumber = 0;
				gameLogic.gameWaveNumber = 1;
				TOGGLE_preLoad = 1;
			}
			break;
		case 0:
			if (TOGGLE_preLoad != 1)
			{
				for (int k = 0; k < challengeUnits.Length; k++)
				{
					INST1_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(challengeUnits[k].transform, spawnPosition, challengeUnits[k].transform.rotation);
					INST2_preLoadUnit = PoolManager.Pools["Unit Pool"].Spawn(challengeUnits[k].transform, spawnPosition, challengeUnits[k].transform.rotation);
					PoolManager.Pools["Unit Pool"].Despawn(INST1_preLoadUnit);
					PoolManager.Pools["Unit Pool"].Despawn(INST2_preLoadUnit);
				}
				challengeNextChampionNumber = UnityEngine.Random.Range(1, 6);
				GameScriptsManager.masterControlScript.bossTrack = BossSpeech[challengeNextChampionNumber].musicTrackNumber;
				challengeUnitLineUpAmount = 3;
				challengeWaveNumber = 0;
				gameLogic.gameWaveNumber = 1;
				TOGGLE_preLoad = 1;
			}
			break;
		case 1:
			TIMER_introDelay = Time.time;
			break;
		case 2:
			ChallengeIntroFunction();
			ChallengeWaveFunction();
			break;
		case 4:
			if (TOGGLE_preLoad != 0)
			{
				scriptIntro.activate = false;
				waveMode = 0;
				challengeState = 0;
				TOGGLE_preLoad = 0;
			}
			break;
		}
	}

	private void ModeFunction()
	{
		if (TOGGLE_levelMode != levelMode)
		{
			if (levelMode != 0)
			{
			}
			TOGGLE_levelMode = levelMode;
		}
	}

	private void ChallengeIntroFunction()
	{
		if (!scriptIntro.activate && Time.time >= TIMER_introDelay + introDelay)
		{
			hudControl.waveNumber = 0;
			challengeState = 2;
			scriptIntro.activate = true;
		}
	}

	private void LevelIntroFunction()
	{
		if (!scriptIntro.activate)
		{
			if (debugMode == 1 && (UnityEngine.Input.GetKeyDown(KeyCode.F11) || Input.GetMouseButtonDown(1)))
			{
				gameStatistic.gameStateWaveTierTeamB = 0;
				currentLevelWaveNumber = levelWaveAmount;
				WaveCompleteFunction();
			}
			if (Time.time >= TIMER_introDelay + introDelay)
			{
				hudControl.waveNumber = levelSpawn[gameLevel].waveSpawn.Length;
				levelMode = 2;
				scriptIntro.activate = true;
			}
		}
	}

	private void WaveFunction()
	{
		if (TOGGLE_levelMode != levelMode)
		{
			waveMode = 0;
			currentLevelWaveNumber = 0;
			currentEnemySpawnNumber = 0;
			TIMER_waveSpawnRatio = Time.time;
			gameLogic.gameWaveNumber = levelSpawn[gameLevel].waveSpawn.Length;
			TOGGLE_levelMode = levelMode;
		}
		else
		{
			if (TOGGLE_levelMode != 2)
			{
				return;
			}
			levelWaveAmount = levelSpawn[gameLevel].waveSpawn.Length;
			enemySpawnAmount = levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].NumberOfEnemy;
			if (debugMode == 1 && (UnityEngine.Input.GetKeyDown(KeyCode.F12) || Input.GetMouseButtonDown(2)))
			{
				InstantBossWaveFunction();
			}
			if (waveMode == 0)
			{
				waveSpawnRatio = levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].SpawnRatio;
				if (currentLevelWaveNumber < levelWaveAmount - 1)
				{
					if (currentEnemySpawnNumber < enemySpawnAmount)
					{
						if (gameStatistic.gameStatusUnitSpawnNumberTeamB < gameStatistic.gameStatisticMaximumUnitSpawn)
						{
							if (Time.time >= TIMER_waveSpawnRatio + waveSpawnRatio)
							{
								BasicSpawnFunction();
							}
						}
						else
						{
							TIMER_waveSpawnRatio = Time.time;
						}
					}
					else
					{
						WaveCheckFunction();
					}
				}
				else if (currentLevelWaveNumber == levelWaveAmount - 1)
				{
					PoolManager.Pools["Pickup Pool"].Spawn(championManaSpawn.transform, new Vector3(0f + stageLength, 0f, 0f), championManaSpawn.transform.rotation);
					gameLogic.gameWaveTier = 1;
					hudControl.championDisplaySpeechType = BossSpeech[gameLevel].speechType;
					hudControl.championDisplayPortraitID = BossSpeech[gameLevel].portraitID;
					hudControl.championDisplayWarningQuote = BossSpeech[gameLevel].warningQuote;
					hudControl.championDisplayIntroductionSpeech = BossSpeech[gameLevel].introductionSpeech;
					hudControl.championDisplayChampionName = BossSpeech[gameLevel].championName;
					hudControl.championDisplayState = 1;
					MIN_waveSpawnRatio = BossSpeech[gameLevel].minSpawnRatio;
					MAX_waveSpawnRatio = BossSpeech[gameLevel].maxSpawnRatio;
					ScriptsManager.dataScript.GameAnalytics("level:" + gameLogic.gameLevel + ":boss:guards:" + gameStatistic.guardUnitsRemaing, 0f);
					TIMER_waveSpawnRatio = Time.time + 0.5f;
					TIMER_championStartDelay = Time.time + 4f;
					waveMode = 1;
				}
			}
			else if (waveMode == 1)
			{
				if (gameLogic.gameWaveTier == 1)
				{
					if (gameStatistic.gameStatusUnitSpawnNumberTeamB < gameStatistic.gameStatisticMaximumUnitSpawn && Time.time >= TIMER_championStartDelay)
					{
						if (currentEnemySpawnNumber == levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].NumberOfEnemy)
						{
							ChampionSpawnFunction();
						}
						else if (Time.time >= TIMER_waveSpawnRatio + waveSpawnRatio)
						{
							ChampionUnitSpawnFunction();
						}
					}
					else
					{
						TIMER_waveSpawnRatio = Time.time + 0.5f;
					}
				}
				else
				{
					waveMode = 2;
				}
			}
			else if (waveMode == 2)
			{
				WaveCheckFunction();
			}
		}
	}

	private void ChallengeWaveFunction()
	{
		switch (challengeState)
		{
		case 0:
			break;
		case 1:
			for (int i = 0; i < challengeEnemySpawn.Length; i++)
			{
				challengeEnemySpawn[i] = challengeUnits[UnityEngine.Random.Range(0, challengeUnits.Length)];
			}
			switch (challengeWaveNumber)
			{
			case 0:
				challengeUnitLineUpAmount = 3;
				break;
			case 1:
				challengeUnitLineUpAmount = 3;
				break;
			case 6:
				challengeUnitLineUpAmount = 3;
				break;
			case 12:
				challengeUnitLineUpAmount = 4;
				break;
			case 18:
				challengeUnitLineUpAmount = 5;
				break;
			case 24:
				challengeUnitLineUpAmount = 6;
				break;
			case 30:
				challengeUnitLineUpAmount = 7;
				break;
			case 36:
				challengeUnitLineUpAmount = 8;
				break;
			case 42:
				challengeUnitLineUpAmount = 9;
				break;
			}
			if (gameLogic.gameStage <= 10 && challengeWaveNumber == stageGrowthNumber * stageGrowthLevelNumber)
			{
				gameLogic.gameStage++;
				stageGrowthLevelNumber++;
			}
			challengeState++;
			break;
		case 2:
			challengeUnitSpawnedAmount = 0;
			if (challengeWaveNumber == challengeChampionWave * challengeChampionLevelNumber - 1)
			{
				challengeUnitAmount = 24;
			}
			else
			{
				challengeUnitAmount = UnityEngine.Random.Range(6, 12);
			}
			challengeSpawnRatio = UnityEngine.Random.Range(0.2f, 2.5f);
			TIMER_waveSpawnRatio = Time.time + challengeSpawnRatio;
			TIMER_challengeSpawnRatio = Time.time + 10f;
			challengeState++;
			break;
		case 3:
			switch (TOGGLE_challengeWaveType)
			{
			case 0:
				if (Time.time >= TIMER_challengeSpawnRatio)
				{
					challengeSpawnRatio = UnityEngine.Random.Range(0.2f, 2.5f);
					TIMER_challengeSpawnRatio = Time.time + 10f;
				}
				if (challengeUnitSpawnedAmount <= challengeUnitAmount)
				{
					if (gameStatistic.gameStatusUnitSpawnNumberTeamB < gameStatistic.gameStatisticMaximumUnitSpawn && Time.time >= TIMER_waveSpawnRatio)
					{
						RANDOM_unitType = UnityEngine.Random.Range(0, challengeUnitLineUpAmount);
						PoolManager.Pools["Unit Pool"].Spawn(challengeEnemySpawn[RANDOM_unitType].transform, spawnPosition, challengeEnemySpawn[RANDOM_unitType].transform.rotation);
						challengeUnitSpawnedAmount++;
						TIMER_waveSpawnRatio = Time.time + challengeSpawnRatio;
					}
				}
				else if (challengeUnitSpawnedAmount > challengeUnitAmount)
				{
					challengeState++;
				}
				break;
			case 1:
				if (Time.time >= TIMER_challengeSpawnRatio)
				{
					if (MIN_waveSpawnRatio != 0f && MAX_waveSpawnRatio != 0f)
					{
						waveSpawnRatio = UnityEngine.Random.Range(MIN_waveSpawnRatio, MAX_waveSpawnRatio);
					}
					else
					{
						waveSpawnRatio = UnityEngine.Random.Range(0.5f, 5f);
					}
					TIMER_challengeSpawnRatio = Time.time + 10f;
				}
				if (gameLogic.gameWaveTier == 1)
				{
					if (gameStatistic.gameStatusUnitSpawnNumberTeamB < gameStatistic.gameStatisticMaximumUnitSpawn && Time.time >= TIMER_championStartDelay)
					{
						if (Time.time >= TIMER_waveSpawnRatio)
						{
							if (RANDOM_challengeChampionSpawnNumber == challengeUnitSpawnedAmount)
							{
								PoolManager.Pools["Unit Pool"].Spawn(challengeChampionUnits[challengeChampionNumber].transform, spawnPosition, challengeChampionUnits[challengeChampionNumber].transform.rotation);
							}
							else
							{
								RANDOM_unitType = UnityEngine.Random.Range(0, challengeUnitLineUpAmount);
								PoolManager.Pools["Unit Pool"].Spawn(challengeEnemySpawn[RANDOM_unitType].transform, spawnPosition, challengeEnemySpawn[RANDOM_unitType].transform.rotation);
							}
							challengeUnitSpawnedAmount++;
							TIMER_waveSpawnRatio = Time.time + challengeSpawnRatio;
						}
					}
					else
					{
						TIMER_waveSpawnRatio = Time.time + challengeSpawnRatio;
					}
				}
				else if (gameLogic.gameWaveTier == 0)
				{
					ScriptsManager.dataScript.GameAnalytics("arena:champion:" + BossSpeech[challengeChampionNumber].portraitID + ":level:" + challengeChampionLevelNumber + ":pass", 1f);
					TOGGLE_challengeWaveType++;
				}
				break;
			case 2:
			{
				GameObject x = GameObject.FindWithTag("TmB");
				if (x == null)
				{
					TOGGLE_challengeWaveType++;
				}
				break;
			}
			case 3:
				hudControl.championDisplayState = 0;
				gameStatistic.gameStateWaveTierTeamB = 1;
				gameStatistic.gameStatusUnitSpawnNumberTeamB = 0;
				challengeState++;
				break;
			}
			break;
		case 4:
			TOGGLE_challengeWaveType = 0;
			challengeWaveNumber++;
			hudControl.waveNumber = challengeWaveNumber;
			gameLogic.gameWaveNumber = challengeWaveNumber;
			gameLogic.gameLevel = challengeWaveNumber * 2;
			gameStatistic.scoreWavesCompleted++;
			gameLogic.gameWavesComplete++;
			if (challengeWaveNumber == challengeChampionWave * challengeChampionLevelNumber)
			{
				challengeState++;
			}
			else
			{
				challengeState = 1;
			}
			break;
		case 5:
			challengeChampionNumber = challengeNextChampionNumber;
			GameScriptsManager.masterControlScript.bossTrack = BossSpeech[challengeChampionNumber].musicTrackNumber;
			PoolManager.Pools["Pickup Pool"].Spawn(championManaSpawn.transform, new Vector3(0f + stageLength, 0f, 0f), championManaSpawn.transform.rotation);
			gameLogic.gameWaveTier = 1;
			hudControl.championDisplaySpeechType = BossSpeech[challengeChampionNumber].speechType;
			hudControl.championDisplayPortraitID = BossSpeech[challengeChampionNumber].portraitID;
			hudControl.championDisplayWarningQuote = BossSpeech[challengeChampionNumber].warningQuote;
			hudControl.championDisplayIntroductionSpeech = BossSpeech[challengeChampionNumber].introductionSpeech;
			hudControl.championDisplayChampionName = BossSpeech[challengeChampionNumber].championName;
			hudControl.championDisplayState = 1;
			MIN_waveSpawnRatio = BossSpeech[challengeChampionNumber].minSpawnRatio;
			MAX_waveSpawnRatio = BossSpeech[challengeChampionNumber].maxSpawnRatio;
			TIMER_waveSpawnRatio = Time.time + 0.5f;
			TIMER_championStartDelay = Time.time + 4f;
			RANDOM_challengeChampionSpawnNumber = UnityEngine.Random.Range(5, 10);
			TOGGLE_challengeWaveType = 1;
			ScriptsManager.dataScript.GameAnalytics("arena:champion:" + BossSpeech[challengeChampionNumber].portraitID + ":level:" + challengeChampionLevelNumber + ":enter", 1f);
			challengeState++;
			break;
		case 6:
			challengeNextChampionNumber = UnityEngine.Random.Range(1, challengeChampionUnits.Length);
			challengeChampionLevelNumber++;
			challengeState = 1;
			break;
		}
	}

	private void WaveCheckFunction()
	{
		GameObject x = GameObject.FindWithTag("TmB");
		if (x == null)
		{
			WaveCompleteFunction();
		}
		if (waveMode != 0)
		{
			return;
		}
		if (gameStatistic.gameStatusUnitSpawnNumberTeamB < gameStatistic.gameStatisticMaximumUnitSpawn)
		{
			if (TOGGLE_waveDuration == 0)
			{
				TIMER_waveDuration = Time.time;
				TOGGLE_waveDuration = 1;
			}
			else if (TOGGLE_waveDuration == 1 && Time.time >= TIMER_waveDuration + waveDuration)
			{
				WaveCompleteFunction();
			}
		}
		else if (TOGGLE_waveDuration != 0)
		{
			TOGGLE_waveDuration = 0;
		}
	}

	private void WaveCompleteFunction()
	{
		TIMER_waveSpawnRatio = Time.time;
		hudControl.waveNumber--;
		gameStatistic.scoreWavesCompleted++;
		gameLogic.gameWaveNumber--;
		gameLogic.gameWavesComplete++;
		GC.Collect();
		currentLevelWaveNumber++;
		currentEnemySpawnNumber = 0;
		TOGGLE_waveDuration = 0;
		if (currentLevelWaveNumber < levelWaveAmount)
		{
			scriptGuardLogic.state = 3;
		}
		if (currentLevelWaveNumber >= levelWaveAmount)
		{
			gameLogic.gameWaveNumber = 0;
			hudControl.waveNumber = 0;
		}
	}

	private void InstantBossWaveFunction()
	{
		TIMER_waveSpawnRatio = Time.time;
		hudControl.waveNumber = 1;
		gameStatistic.scoreWavesCompleted = levelWaveAmount - 1;
		gameLogic.gameWaveNumber = 1;
		gameLogic.gameWavesComplete = levelWaveAmount - 1;
		GC.Collect();
		currentLevelWaveNumber = levelWaveAmount - 1;
		currentEnemySpawnNumber = 0;
		TOGGLE_waveDuration = 0;
		if (currentLevelWaveNumber < levelWaveAmount)
		{
			scriptGuardLogic.state = 3;
		}
	}

	private void ChampionSpawnFunction()
	{
		PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[0].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[0].EnemyPrefab.transform.rotation);
		TIMER_waveSpawnRatio = Time.time;
		currentEnemySpawnNumber++;
	}

	private void ChampionUnitSpawnFunction()
	{
		for (int i = 1; i < levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn.Length; i++)
		{
			if (levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyAmount > 0)
			{
				RANDOM_unitType = UnityEngine.Random.Range(0, 100);
				if (RANDOM_unitType < levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyChance)
				{
					levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyChance = 10;
					PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyPrefab.transform.rotation);
					TIMER_waveSpawnRatio = Time.time;
					currentEnemySpawnNumber++;
					levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyAmount--;
					return;
				}
				if (levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyChance < 50)
				{
					levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyChance += 5;
				}
			}
		}
		RANDOM_unitType = UnityEngine.Random.Range(1, levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn.Length);
		levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[RANDOM_unitType].EnemyAmount--;
		levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[RANDOM_unitType].EnemyChance = 10;
		PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[RANDOM_unitType].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[RANDOM_unitType].EnemyPrefab.transform.rotation);
		TIMER_waveSpawnRatio = Time.time;
		if (NUMBER_waveSpawnRatio >= 12)
		{
			if (MIN_waveSpawnRatio != 0f && MAX_waveSpawnRatio != 0f)
			{
				waveSpawnRatio = UnityEngine.Random.Range(MIN_waveSpawnRatio, MAX_waveSpawnRatio);
			}
			else
			{
				waveSpawnRatio = UnityEngine.Random.Range(0.25f, 3f);
			}
			NUMBER_waveSpawnRatio = 0;
		}
		else if (NUMBER_waveSpawnRatio < 12)
		{
			NUMBER_waveSpawnRatio++;
		}
		currentEnemySpawnNumber++;
	}

	private void BasicSpawnFunction()
	{
		for (int i = 0; i < levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn.Length; i++)
		{
			if (levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyAmount > 0)
			{
				RANDOM_unitType = UnityEngine.Random.Range(0, 100);
				if (RANDOM_unitType < levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyChance)
				{
					levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyChance = 10;
					PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyPrefab.transform.rotation);
					TIMER_waveSpawnRatio = Time.time;
					currentEnemySpawnNumber++;
					levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyAmount--;
					return;
				}
				if (levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyChance < 50)
				{
					levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[i].EnemyChance += 5;
				}
			}
		}
		RANDOM_unitType = UnityEngine.Random.Range(0, levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn.Length);
		levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[RANDOM_unitType].EnemyAmount--;
		levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[RANDOM_unitType].EnemyChance = 10;
		PoolManager.Pools["Unit Pool"].Spawn(levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[RANDOM_unitType].EnemyPrefab.transform, spawnPosition, levelSpawn[gameLevel].waveSpawn[currentLevelWaveNumber].enemySpawn[RANDOM_unitType].EnemyPrefab.transform.rotation);
		TIMER_waveSpawnRatio = Time.time;
		currentEnemySpawnNumber++;
	}
}
