using System;
using UnityEngine;

public class level_setup : MonoBehaviour
{
	[Serializable]
	public class waveIDs
	{
		public string waveID;

		public enemy_bundle enemyBundle;
	}

	[Serializable]
	public class recurringUnitList
	{
		public string unitID;

		public GameObject[] recurringUnits = new GameObject[3];
	}

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

				public int EnemyAmount;

				public int EnemyChance;
			}

			public int NumberOfEnemy;

			public float SpawnRatio;

			public EnemySpawn[] enemySpawn;
		}

		public string levelName;

		public GameObject[] EnemyRandomPrefab;

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

		public int musicTrackNumber;

		public float minSpawnRatio;

		public float maxSpawnRatio;
	}

	[Serializable]
	public class itemUnlockID
	{
		public string itemID;

		public int itemState;
	}

	[Serializable]
	public class shopItems
	{
		[Serializable]
		public class itemInfos
		{
			public string itemName;

			public int itemCost;

			public string itemID;

			public string itemIconID;

			public int itemShopAmount;

			public int itemManaValue;

			public int itemBG;

			public string itemDescriptionLine1;

			public string itemDescriptionLine2;
		}

		public string ClassNames;

		public itemInfos[] ItemInfos = new itemInfos[100];
	}

	public int activate;

	public string LoadScene;

	public float loadDelay = 1f;

	public string playerCharacterID;

	public Game_Data data;

	public Content_Data contentData;

	public PlayerCharacterData playerData;

	public Stage_Control stageControl;

	public Unit_Content_Data unitContentData;

	public Item_Content_Data itemContentData;

	public string[] levelIDs = new string[21];

	public waveIDs[] WaveIDs = new waveIDs[21];

	public recurringUnitList[] RecurringUnitList = new recurringUnitList[21];

	public LevelSpawn[] levelSpawn = new LevelSpawn[21];

	public bossSpeech[] BossSpeech = new bossSpeech[21];

	public GameObject[] levelPreview = new GameObject[21];

	public GameObject[] objectPreviewSigns;

	public GameObject characterTutorial;

	public string[] storyElements = new string[5];

	public itemUnlockID[] ItemUnlockID = new itemUnlockID[4];

	public shopItems[] ShopItems = new shopItems[3];

	private int INT_LevelSetupWaveAmount;

	private int EnemySpawnRandom;

	private int PREVIOUS_EnemySpawnRandom;

	private float TIMER_delay;

	private Transform inst;

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
		Resources.UnloadUnusedAssets();
		GC.Collect();
		data = ScriptsManager.dataScript;
		contentData = ScriptsManager.contentDataScript;
		stageControl = ScriptsManager.stageControlScript;
		ScriptsManager.levelSetupScript = GetComponent<level_setup>();
	}

	private void LateUpdate()
	{
		if (activate == -1)
		{
			playerData = null;
			if (data == null)
			{
				data = ScriptsManager.dataScript;
			}
			if (stageControl == null)
			{
				stageControl = ScriptsManager.stageControlScript;
			}
			playerData = ScriptsManager.playerCharacter.GetComponent<PlayerCharacterData>();
			if (data.gameMode != 2)
			{
				if (data.gameLevel == 0)
				{
					data.gameMode = 1;
					LoadScene = "Load - Story Beginning";
				}
				else
				{
					data.gameMode = 0;
					LoadScene = "Load - Game";
				}
			}
			else
			{
				LoadScene = "Load - Game";
			}
			TIMER_delay = Time.time + 1f;
			activate++;
		}
		else if (activate >= 10)
		{
			switch (activate)
			{
			case 10:
				itemContentData = ScriptsManager.itemContentDataScript;
				if (itemContentData != null)
				{
					if (itemContentData.state == 3)
					{
						itemContentData.ItemUpdate();
						ShopSetupFunction();
					}
				}
				else
				{
					itemContentData = ScriptsManager.itemContentDataScript;
				}
				break;
			case 20:
				itemContentData.state = 4;
				UnityEngine.Object.Destroy(base.gameObject);
				activate = 60;
				break;
			case 50:
				UnityEngine.SceneManagement.SceneManager.LoadScene(storyElements[0]);
				activate = 60;
				break;
			case 51:
				UnityEngine.SceneManagement.SceneManager.LoadScene(storyElements[1]);
				activate = 60;
				break;
			case 52:
				UnityEngine.SceneManagement.SceneManager.LoadScene(storyElements[2]);
				activate = 60;
				break;
			case 53:
				UnityEngine.SceneManagement.SceneManager.LoadScene(storyElements[3]);
				activate = 60;
				break;
			case 54:
				UnityEngine.SceneManagement.SceneManager.LoadScene(storyElements[4]);
				activate = 60;
				break;
			}
		}
		else
		{
			if (!(Time.time >= TIMER_delay) || activate >= 10)
			{
				return;
			}
			if (Time.time < TIMER_delay + 10f)
			{
				switch (activate)
				{
				case 0:
					unitContentData = GameObject.Find("UC").GetComponent<Unit_Content_Data>();
					playerCharacterID = playerData.characterID;
					LevelIDs();
					break;
				case 1:
					LevelSetup();
					break;
				case 2:
					SpawnSetup();
					break;
				case 3:
					UnitSetup();
					break;
				case 4:
					ExtraUnitSetup();
					break;
				case 5:
					BossSpeechSetup();
					break;
				case 6:
					LevelExtraSetup();
					break;
				case 7:
					activate++;
					break;
				case 8:
					activate++;
					break;
				case 9:
					if (LoadScene != string.Empty)
					{
						UnityEngine.SceneManagement.SceneManager.LoadScene(LoadScene);
					}
					activate++;
					break;
				}
			}
			else if (Time.time >= TIMER_delay + 5f)
			{
				activate = -1;
				TIMER_delay = Time.time;
			}
		}
	}

	private void LevelIDs()
	{
		for (int i = 0; i < levelIDs.Length; i++)
		{
			levelIDs[i] = playerData.levelIDs[i];
		}
		for (int j = 0; j < WaveIDs.Length; j++)
		{
			for (int k = 0; k < unitContentData.EnemyIDs.Length; k++)
			{
				if (levelIDs[j] != string.Empty && levelIDs[j] == unitContentData.EnemyIDs[k].enemyID)
				{
					WaveIDs[j].waveID = unitContentData.EnemyIDs[k].enemyID;
					WaveIDs[j].enemyBundle = unitContentData.EnemyIDs[k].enemyBundle.GetComponent<enemy_bundle>();
					RecurringUnitList[j].unitID = string.Empty + j;
					for (int l = 0; l < RecurringUnitList[j].recurringUnits.Length; l++)
					{
						RecurringUnitList[j].recurringUnits[l] = WaveIDs[j].enemyBundle.recurringUnits[l];
					}
				}
			}
		}
		TIMER_delay = Time.time + loadDelay;
		activate++;
	}

	private void LevelSetup()
	{
		characterTutorial = playerData.characterTutorial;
		storyElements[0] = playerData.storyBeginning;
		storyElements[1] = playerData.storyEnd;
		storyElements[2] = playerData.cutsceneStage1;
		storyElements[3] = playerData.cutsceneStage2;
		storyElements[4] = playerData.cutsceneStage3;
		for (int i = 0; i < levelSpawn.Length; i++)
		{
			levelSpawn[i].levelName = "level " + (i + 1) + " " + WaveIDs[i].waveID;
			if (i > 1)
			{
				levelSpawn[i].EnemyRandomPrefab = new GameObject[(i - 1) * 3];
			}
			for (int j = 0; j < levelSpawn[i].EnemyRandomPrefab.Length; j++)
			{
				for (int k = 1; k < RecurringUnitList.Length; k++)
				{
					for (int l = 0; l < RecurringUnitList[k].recurringUnits.Length; l++)
					{
						if (j != levelSpawn[i].EnemyRandomPrefab.Length)
						{
							levelSpawn[i].EnemyRandomPrefab[j] = RecurringUnitList[k].recurringUnits[l];
							j++;
						}
					}
				}
			}
		}
		TIMER_delay = Time.time + loadDelay;
		activate++;
	}

	private void LevelSetupWaveAmount(int i)
	{
		switch (i)
		{
		case 0:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[4];
			break;
		case 1:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[4];
			break;
		case 2:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[5];
			break;
		case 3:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[5];
			break;
		case 4:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[6];
			break;
		case 5:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[6];
			break;
		case 6:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[6];
			break;
		case 7:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[8];
			break;
		case 8:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[8];
			break;
		case 9:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[8];
			break;
		case 10:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[10];
			break;
		case 11:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[10];
			break;
		case 12:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[10];
			break;
		case 13:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[10];
			break;
		case 14:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[10];
			break;
		case 15:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[12];
			break;
		case 16:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[12];
			break;
		case 17:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[12];
			break;
		case 18:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[12];
			break;
		case 19:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[12];
			break;
		case 20:
			levelSpawn[i].waveSpawn = new LevelSpawn.WaveSpawn[12];
			break;
		}
	}

	private void SpawnSetup()
	{
		for (int i = 0; i < levelSpawn.Length; i++)
		{
			if (i <= 1)
			{
				for (int j = 0; j < levelSpawn[i].waveSpawn.Length; j++)
				{
					if (j == levelSpawn[i].waveSpawn.Length - 1)
					{
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = 6;
						continue;
					}
					switch (j)
					{
					case 0:
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = 3;
						break;
					case 1:
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = 6;
						break;
					case 2:
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = 8;
						break;
					case 3:
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = 10;
						break;
					case 4:
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = 10;
						break;
					}
				}
			}
			else
			{
				switch (i)
				{
				case 2:
					levelSpawn[i].waveSpawn[levelSpawn[i].waveSpawn.Length - 2].NumberOfEnemy = 12;
					break;
				case 3:
					levelSpawn[i].waveSpawn[levelSpawn[i].waveSpawn.Length - 2].NumberOfEnemy = 16;
					break;
				case 4:
					levelSpawn[i].waveSpawn[levelSpawn[i].waveSpawn.Length - 2].NumberOfEnemy = 20;
					break;
				}
			}
		}
		TIMER_delay = Time.time + loadDelay;
		activate++;
	}

	private void UnitSetup()
	{
		for (int i = 0; i < levelSpawn.Length; i++)
		{
			if (i <= 1)
			{
				for (int j = 0; j < levelSpawn[i].waveSpawn.Length; j++)
				{
					if (j == levelSpawn[i].waveSpawn.Length - 1)
					{
						levelSpawn[i].waveSpawn[j].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.bossUnits[0];
						levelSpawn[i].waveSpawn[j].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						levelSpawn[i].waveSpawn[j].enemySpawn[2].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[1];
						levelSpawn[i].waveSpawn[j].enemySpawn[3].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[2];
						continue;
					}
					switch (j)
					{
					case 0:
						levelSpawn[i].waveSpawn[j].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						break;
					case 1:
						levelSpawn[i].waveSpawn[j].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						levelSpawn[i].waveSpawn[j].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[1];
						break;
					case 2:
						levelSpawn[i].waveSpawn[j].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						levelSpawn[i].waveSpawn[j].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[1];
						levelSpawn[i].waveSpawn[j].enemySpawn[2].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[2];
						break;
					case 3:
						levelSpawn[i].waveSpawn[j].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						levelSpawn[i].waveSpawn[j].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[1];
						levelSpawn[i].waveSpawn[j].enemySpawn[2].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[2];
						break;
					}
				}
				continue;
			}
			for (int k = 0; k < levelSpawn[i].waveSpawn.Length; k++)
			{
				if (k == levelSpawn[i].waveSpawn.Length - 1)
				{
					for (int l = 0; l < WaveIDs[i].enemyBundle.bossUnits.Length; l++)
					{
						if (WaveIDs[i].enemyBundle.bossUnits[l] != null)
						{
							levelSpawn[i].waveSpawn[k].enemySpawn[l].EnemyPrefab = WaveIDs[i].enemyBundle.bossUnits[l];
						}
					}
					if (levelSpawn[i].waveSpawn[k].enemySpawn[WaveIDs[i].enemyBundle.bossUnits.Length].EnemyPrefab == null)
					{
						levelSpawn[i].waveSpawn[k].enemySpawn[WaveIDs[i].enemyBundle.bossUnits.Length].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
					}
					if (levelSpawn[i].waveSpawn[k].enemySpawn[1 + WaveIDs[i].enemyBundle.bossUnits.Length].EnemyPrefab == null)
					{
						levelSpawn[i].waveSpawn[k].enemySpawn[1 + WaveIDs[i].enemyBundle.bossUnits.Length].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[1];
					}
					if (levelSpawn[i].waveSpawn[k].enemySpawn[2 + WaveIDs[i].enemyBundle.bossUnits.Length].EnemyPrefab == null)
					{
						levelSpawn[i].waveSpawn[k].enemySpawn[2 + WaveIDs[i].enemyBundle.bossUnits.Length].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[2];
					}
				}
				else if (k <= 5)
				{
					switch (k)
					{
					case 0:
						levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyAmount = 2;
						levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyChance = 80;
						break;
					case 1:
						levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						break;
					case 2:
						levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[1];
						levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyAmount = 2;
						levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyChance = 80;
						break;
					case 3:
						levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[0];
						levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[1];
						break;
					case 4:
						levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[UnityEngine.Random.Range(0, 1)];
						levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[2];
						levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyAmount = 2;
						levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyChance = 80;
						break;
					case 5:
						levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[UnityEngine.Random.Range(0, 1)];
						levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[2];
						break;
					}
				}
				else
				{
					levelSpawn[i].waveSpawn[k].enemySpawn[0].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[UnityEngine.Random.Range(0, WaveIDs[i].enemyBundle.waveUnits.Length)];
					levelSpawn[i].waveSpawn[k].enemySpawn[1].EnemyPrefab = WaveIDs[i].enemyBundle.waveUnits[UnityEngine.Random.Range(0, WaveIDs[i].enemyBundle.waveUnits.Length)];
				}
			}
		}
		TIMER_delay = Time.time + loadDelay;
		activate++;
	}

	private void ExtraUnitSetup()
	{
		for (int i = 0; i < levelSpawn.Length; i++)
		{
			for (int j = 0; j < levelSpawn[i].waveSpawn.Length; j++)
			{
				if (levelSpawn[i].waveSpawn[j].NumberOfEnemy == 0)
				{
					if (j == levelSpawn[i].waveSpawn.Length - 2)
					{
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = 24;
					}
					else if (j == levelSpawn[i].waveSpawn.Length - 1)
					{
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = UnityEngine.Random.Range(5, 10);
					}
					else
					{
						levelSpawn[i].waveSpawn[j].NumberOfEnemy = UnityEngine.Random.Range(6, 12);
					}
				}
				if (levelSpawn[i].waveSpawn[j].SpawnRatio == 0f)
				{
					levelSpawn[i].waveSpawn[j].SpawnRatio = UnityEngine.Random.Range(0.25f, 2f);
				}
				for (int k = 0; k < levelSpawn[i].waveSpawn[j].enemySpawn.Length; k++)
				{
					if (i > 1 && levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyPrefab == null)
					{
						for (EnemySpawnRandom = UnityEngine.Random.Range(0, levelSpawn[i].EnemyRandomPrefab.Length); EnemySpawnRandom == PREVIOUS_EnemySpawnRandom; EnemySpawnRandom = UnityEngine.Random.Range(0, levelSpawn[i].EnemyRandomPrefab.Length))
						{
						}
						if (EnemySpawnRandom != PREVIOUS_EnemySpawnRandom)
						{
							levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyPrefab = levelSpawn[i].EnemyRandomPrefab[EnemySpawnRandom];
							PREVIOUS_EnemySpawnRandom = EnemySpawnRandom;
						}
					}
					if (levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyAmount == 0)
					{
						levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyAmount = UnityEngine.Random.Range(1, 20);
					}
					if (levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyChance == 0)
					{
						levelSpawn[i].waveSpawn[j].enemySpawn[k].EnemyChance = UnityEngine.Random.Range(10, 90);
					}
				}
			}
		}
		TIMER_delay = Time.time + loadDelay;
		activate++;
	}

	private void BossSpeechSetup()
	{
		for (int i = 0; i < BossSpeech.Length; i++)
		{
			BossSpeech[i].portraitID = levelIDs[i];
			for (int j = 0; j < WaveIDs[i].enemyBundle.BossSpeech.Length; j++)
			{
				if (WaveIDs[i].enemyBundle.BossSpeech[j].playerCharacterID == playerCharacterID)
				{
					BossSpeech[i].speechType = 1;
					BossSpeech[i].warningQuote = WaveIDs[i].enemyBundle.BossSpeech[j].warningQuote;
					BossSpeech[i].introductionSpeech = WaveIDs[i].enemyBundle.BossSpeech[j].introductionSpeech;
					BossSpeech[i].championName = WaveIDs[i].enemyBundle.BossSpeech[j].championName;
					BossSpeech[i].musicTrackNumber = WaveIDs[i].enemyBundle.BossSpeech[j].musicTrackNumber;
					BossSpeech[i].minSpawnRatio = WaveIDs[i].enemyBundle.BossSpeech[j].minSpawnRatio;
					BossSpeech[i].maxSpawnRatio = WaveIDs[i].enemyBundle.BossSpeech[j].maxSpawnRatio;
				}
			}
			if (BossSpeech[i].speechType == 0)
			{
				BossSpeech[i].speechType = 0;
				BossSpeech[i].warningQuote = WaveIDs[i].enemyBundle.BossSpeech[0].warningQuote;
				BossSpeech[i].introductionSpeech = WaveIDs[i].enemyBundle.BossSpeech[0].introductionSpeech;
				BossSpeech[i].championName = WaveIDs[i].enemyBundle.BossSpeech[0].championName;
				BossSpeech[i].musicTrackNumber = WaveIDs[i].enemyBundle.BossSpeech[0].musicTrackNumber;
				BossSpeech[i].minSpawnRatio = WaveIDs[i].enemyBundle.BossSpeech[0].minSpawnRatio;
				BossSpeech[i].maxSpawnRatio = WaveIDs[i].enemyBundle.BossSpeech[0].maxSpawnRatio;
			}
		}
		activate++;
	}

	private void LevelExtraSetup()
	{
		for (int i = 0; i < WaveIDs.Length; i++)
		{
			levelPreview[i + 1] = WaveIDs[i].enemyBundle.levelPreview;
		}
		for (int j = 0; j < playerData.ItemUnlockID.Length; j++)
		{
			ItemUnlockID[j].itemID = playerData.ItemUnlockID[j].itemID;
			ItemUnlockID[j].itemState = PlayerPrefs.GetInt(ItemUnlockID[j].itemID + "itemLock");
		}
		TIMER_delay = Time.time + loadDelay;
		activate++;
	}

	private void ShopSetupFunction()
	{
		for (int i = 0; i < ShopItems.Length; i++)
		{
			for (int j = 0; j < ShopItems[i].ItemInfos.Length; j++)
			{
				if (ShopItems[i].ItemInfos[j].itemName != string.Empty)
				{
					ShopItems[i].ItemInfos[j].itemName = string.Empty;
					ShopItems[i].ItemInfos[j].itemID = string.Empty;
					ShopItems[i].ItemInfos[j].itemCost = 0;
					ShopItems[i].ItemInfos[j].itemIconID = string.Empty;
					ShopItems[i].ItemInfos[j].itemManaValue = 0;
					ShopItems[i].ItemInfos[j].itemBG = 0;
					ShopItems[i].ItemInfos[j].itemDescriptionLine1 = string.Empty;
					ShopItems[i].ItemInfos[j].itemDescriptionLine2 = string.Empty;
				}
			}
		}
		for (int k = 0; k < itemContentData.ItemIDs.Length; k++)
		{
			for (int l = 0; l < ShopItems[0].ItemInfos.Length; l++)
			{
				if (ShopItems[0].ItemInfos[l].itemName == string.Empty && k != itemContentData.ItemIDs.Length && itemContentData.ItemIDs[k].itemClass == 1 && itemContentData.ItemIDs[k].itemLock == 1)
				{
					ShopItems[0].ItemInfos[l].itemName = itemContentData.ItemIDs[k].itemName;
					ShopItems[0].ItemInfos[l].itemID = itemContentData.ItemIDs[k].itemID;
					ShopItems[0].ItemInfos[l].itemCost = itemContentData.ItemIDs[k].itemCost;
					ShopItems[0].ItemInfos[l].itemIconID = itemContentData.ItemIDs[k].itemID;
					ShopItems[0].ItemInfos[l].itemShopAmount = itemContentData.ItemIDs[k].itemShopAmount;
					ShopItems[0].ItemInfos[l].itemManaValue = 0;
					ShopItems[0].ItemInfos[l].itemBG = itemContentData.ItemIDs[k].itemClass;
					ShopItems[0].ItemInfos[l].itemDescriptionLine1 = itemContentData.ItemIDs[k].itemDescriptionQuote;
					ShopItems[0].ItemInfos[l].itemDescriptionLine2 = itemContentData.ItemIDs[k].itemDescriptionInfo;
					k++;
				}
			}
		}
		for (int m = 0; m < itemContentData.ItemIDs.Length; m++)
		{
			for (int n = 0; n < ShopItems[1].ItemInfos.Length; n++)
			{
				if (ShopItems[1].ItemInfos[n].itemName == string.Empty && m != itemContentData.ItemIDs.Length && itemContentData.ItemIDs[m].itemClass == 2 && itemContentData.ItemIDs[m].itemLock == 1)
				{
					ShopItems[1].ItemInfos[n].itemName = itemContentData.ItemIDs[m].itemName;
					ShopItems[1].ItemInfos[n].itemID = itemContentData.ItemIDs[m].itemID;
					ShopItems[1].ItemInfos[n].itemCost = itemContentData.ItemIDs[m].itemCost;
					ShopItems[1].ItemInfos[n].itemIconID = itemContentData.ItemIDs[m].itemID;
					ShopItems[1].ItemInfos[n].itemShopAmount = 0;
					ShopItems[1].ItemInfos[n].itemManaValue = itemContentData.ItemIDs[m].itemManaCost;
					ShopItems[1].ItemInfos[n].itemBG = itemContentData.ItemIDs[m].itemClass;
					ShopItems[1].ItemInfos[n].itemDescriptionLine1 = itemContentData.ItemIDs[m].itemDescriptionQuote;
					ShopItems[1].ItemInfos[n].itemDescriptionLine2 = itemContentData.ItemIDs[m].itemDescriptionInfo;
					m++;
				}
			}
		}
		for (int num = 0; num < itemContentData.ItemIDs.Length; num++)
		{
			for (int num2 = 0; num2 < ShopItems[2].ItemInfos.Length; num2++)
			{
				if (ShopItems[2].ItemInfos[num2].itemName == string.Empty && num != itemContentData.ItemIDs.Length && itemContentData.ItemIDs[num].itemClass == 3 && itemContentData.ItemIDs[num].itemLock == 1)
				{
					ShopItems[2].ItemInfos[num2].itemName = itemContentData.ItemIDs[num].itemName;
					ShopItems[2].ItemInfos[num2].itemID = itemContentData.ItemIDs[num].itemID;
					ShopItems[2].ItemInfos[num2].itemCost = itemContentData.ItemIDs[num].itemCost;
					ShopItems[2].ItemInfos[num2].itemIconID = itemContentData.ItemIDs[num].itemID;
					ShopItems[2].ItemInfos[num2].itemShopAmount = 0;
					ShopItems[2].ItemInfos[num2].itemManaValue = 0;
					ShopItems[2].ItemInfos[num2].itemBG = itemContentData.ItemIDs[num].itemClass;
					ShopItems[2].ItemInfos[num2].itemDescriptionLine1 = itemContentData.ItemIDs[num].itemDescriptionQuote;
					ShopItems[2].ItemInfos[num2].itemDescriptionLine2 = itemContentData.ItemIDs[num].itemDescriptionInfo;
					num++;
				}
			}
		}
		TIMER_delay = Time.time + loadDelay;
		activate = 60;
	}

	private void UnitContentErase()
	{
		for (int i = 0; i < levelIDs.Length; i++)
		{
			levelIDs[i] = string.Empty;
		}
		for (int j = 0; j < WaveIDs.Length; j++)
		{
			WaveIDs[j].waveID = string.Empty;
			WaveIDs[j].enemyBundle = null;
			RecurringUnitList[j].unitID = string.Empty;
			for (int k = 0; k < RecurringUnitList[j].recurringUnits.Length; k++)
			{
				RecurringUnitList[j].recurringUnits[k] = null;
			}
		}
		characterTutorial = null;
		storyElements[0] = string.Empty;
		storyElements[1] = string.Empty;
		storyElements[2] = string.Empty;
		storyElements[3] = string.Empty;
		storyElements[4] = string.Empty;
		for (int l = 0; l < levelSpawn.Length; l++)
		{
			levelSpawn[l].levelName = string.Empty;
			for (int m = 0; m < levelSpawn[l].EnemyRandomPrefab.Length; m++)
			{
				levelSpawn[l].EnemyRandomPrefab[m] = null;
			}
			for (int n = 0; n < levelSpawn[l].waveSpawn.Length; n++)
			{
				levelSpawn[l].waveSpawn[n].NumberOfEnemy = 0;
				levelSpawn[l].waveSpawn[n].SpawnRatio = 0f;
				for (int num = 0; num < levelSpawn[l].waveSpawn[n].enemySpawn.Length; num++)
				{
					levelSpawn[l].waveSpawn[n].enemySpawn[num].EnemyPrefab = null;
					levelSpawn[l].waveSpawn[n].enemySpawn[num].EnemyAmount = 0;
					levelSpawn[l].waveSpawn[n].enemySpawn[num].EnemyChance = 0;
				}
			}
		}
		for (int num2 = 0; num2 < levelPreview.Length; num2++)
		{
			levelPreview[num2] = null;
		}
	}
}
