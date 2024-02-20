using System;
using UnityEngine;

public class Object_Logic : MonoBehaviour
{
	[Serializable]
	public class SpawnPositions
	{
		public string positionID;

		public Transform[] position;
	}

	[Serializable]
	public class StageObject
	{
		public string stageObjectID;

		public Transform[] setPosition = new Transform[3];

		public GameObject[] spawnObject = new GameObject[3];

		public float raritySpawn;

		public float spawnDuration;

		public int spawnType;
	}

	[Serializable]
	public class LevelObject
	{
		[Serializable]
		public class StageLevel
		{
			[Serializable]
			public class PositionSet
			{
				public int A;

				public int B;

				public int C;
			}

			public GameObject[] spawnObject = new GameObject[10];

			public float raritySpawn;

			public float spawnDuration;

			public int spawnType;

			public PositionSet[] positionSet = new PositionSet[5];
		}

		public string levelContentID;

		public StageLevel[] stageLevel = new StageLevel[15];
	}

	[Serializable]
	public class objectSets
	{
		public string groupName;

		public string[] objectID = new string[20];
	}

	public string LoadScene;

	public string stageID;

	public int gameStage;

	public int gameLevel;

	public int state = -2;

	private int TOGGLE_state;

	public int objectState;

	public Content_Data contentData;

	public Object_Content_Data objectContentData;

	private int stageID_contentData;

	public PlayerCharacterData characterData;

	public Game_Data dataScript;

	public GameObject spawnManager;

	private Transform INST_spawnManager;

	private spawn_manager INST_scriptSpawnManager;

	public SpawnPositions[] spawnPositions;

	public StageObject[] stageObject;

	public LevelObject[] levelObject = new LevelObject[7];

	private string SET_behaviourA;

	private string SET_behaviourB;

	private string SET_behaviourC;

	private string SET_positionA;

	private string SET_positionB;

	private string SET_positionC;

	private string[] SET_objectID = new string[10];

	private string SETID_objectID;

	private string SETID_objectNo;

	private int OR_objectSets;

	private int poolSetupState;

	public objectSets[] ObjectSets;

	private int RANDOM_setLevelContents;

	public Level_Content[] setLevelContents;

	public GameObject testObject;

	private int debugMode;

	private int section_test;

	private float TIMER_objecState;

	private int TOGGLE_objectState;

	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		ScriptsManager.objectLogicScript = GetComponent<Object_Logic>();
		contentData = ScriptsManager.contentDataScript;
		characterData = ScriptsManager.playerCharacter.GetComponent<PlayerCharacterData>();
		dataScript = ScriptsManager.dataScript;
		poolSetupState = 0;
		if (contentData == null)
		{
			contentData = ScriptsManager.contentDataScript;
		}
		if (characterData == null)
		{
			characterData = ScriptsManager.playerCharacter.GetComponent<PlayerCharacterData>();
		}
		if (dataScript == null)
		{
			dataScript = ScriptsManager.dataScript;
			debugMode = ScriptsManager.dataScript.debugMode;
		}
		objectContentData = GameObject.Find("OC").GetComponent<Object_Content_Data>();
		state = -4;
	}

	private void OnSpawned()
	{
		ScriptsManager.objectLogicScript = GetComponent<Object_Logic>();
		contentData = ScriptsManager.contentDataScript;
		characterData = ScriptsManager.playerCharacter.GetComponent<PlayerCharacterData>();
		dataScript = ScriptsManager.dataScript;
		poolSetupState = 0;
		for (int i = 0; i < levelObject.Length; i++)
		{
			levelObject[i].levelContentID = string.Empty;
		}
		state = -4;
	}

	private void OnDespawned()
	{
		for (int i = 0; i < levelObject.Length; i++)
		{
			levelObject[i].levelContentID = string.Empty;
			for (int j = 0; j < levelObject[i].stageLevel.Length; j++)
			{
				for (int k = 0; k < levelObject[i].stageLevel[j].spawnObject.Length; k++)
				{
					levelObject[i].stageLevel[j].spawnObject[k] = null;
				}
				for (int l = 0; l < levelObject[i].stageLevel[j].positionSet.Length; l++)
				{
					levelObject[i].stageLevel[j].positionSet[l].A = 0;
					levelObject[i].stageLevel[j].positionSet[l].B = 0;
					levelObject[i].stageLevel[j].positionSet[l].C = 0;
				}
				levelObject[i].stageLevel[j].raritySpawn = 0f;
				levelObject[i].stageLevel[j].spawnDuration = 0f;
				levelObject[i].stageLevel[j].spawnType = 0;
			}
		}
		for (int m = 0; m < levelObject.Length; m++)
		{
			levelObject[m].levelContentID = string.Empty;
		}
	}

	private void PoolSetup()
	{
		switch (poolSetupState)
		{
		case 0:
			for (int num2 = 0; num2 < levelObject.Length; num2++)
			{
				levelObject[num2].levelContentID = string.Empty;
				for (int num3 = 0; num3 < levelObject[num2].stageLevel.Length; num3++)
				{
					for (int num4 = 0; num4 < levelObject[num2].stageLevel[num3].spawnObject.Length; num4++)
					{
						levelObject[num2].stageLevel[num3].spawnObject[num4] = null;
					}
					for (int num5 = 0; num5 < levelObject[num2].stageLevel[num3].positionSet.Length; num5++)
					{
						levelObject[num2].stageLevel[num3].positionSet[num5].A = 0;
						levelObject[num2].stageLevel[num3].positionSet[num5].B = 0;
						levelObject[num2].stageLevel[num3].positionSet[num5].C = 0;
					}
					levelObject[num2].stageLevel[num3].raritySpawn = 0f;
					levelObject[num2].stageLevel[num3].spawnDuration = 0f;
					levelObject[num2].stageLevel[num3].spawnType = 0;
				}
			}
			for (int num6 = 0; num6 < levelObject.Length; num6++)
			{
				levelObject[num6].levelContentID = string.Empty;
			}
			poolSetupState++;
			break;
		case 1:
			for (int num11 = 0; num11 < contentData.StageList.Length; num11++)
			{
				if (contentData.StageList[num11].stageID == stageID)
				{
					stageID_contentData = num11;
					num11 = contentData.StageList.Length;
				}
			}
			poolSetupState++;
			break;
		case 2:
			for (int num7 = 0; num7 < stageObject.Length; num7++)
			{
				for (int num8 = 0; num8 < contentData.StageList[stageID_contentData].StageObject.Length; num8++)
				{
					if (!(stageObject[num7].stageObjectID == contentData.StageList[stageID_contentData].StageObject[num8].objectID))
					{
						continue;
					}
					for (int num9 = 0; num9 < contentData.StageList[stageID_contentData].StageObject[num8].objectPrefab.Length; num9++)
					{
						if (contentData.StageList[stageID_contentData].StageObject[num8].objectPrefab != null)
						{
							stageObject[num7].spawnObject[num9] = contentData.StageList[stageID_contentData].StageObject[num8].objectPrefab[num9];
						}
					}
					stageObject[num7].raritySpawn = contentData.StageList[stageID_contentData].StageObject[num8].raritySpawn;
					stageObject[num7].spawnDuration = contentData.StageList[stageID_contentData].StageObject[num8].spawnDuration;
					stageObject[num7].spawnType = contentData.StageList[stageID_contentData].StageObject[num8].spawnType;
				}
			}
			poolSetupState++;
			break;
		case 3:
			for (int num10 = 0; num10 < levelObject.Length; num10++)
			{
				if (characterData.StageIDs[gameStage].levelContentIDs[num10] != string.Empty)
				{
					levelObject[num10].levelContentID = characterData.StageIDs[gameStage].levelContentIDs[num10];
				}
				else
				{
					levelObject[num10].levelContentID = setLevelContents[UnityEngine.Random.Range(0, setLevelContents.Length)].name;
				}
			}
			poolSetupState++;
			break;
		case 4:
			for (int i = 0; i < levelObject.Length; i++)
			{
				for (int j = 0; j < contentData.StageList[stageID_contentData].levelContents.Length; j++)
				{
					if (!(contentData.StageList[stageID_contentData].levelContents[j].levelContentID == levelObject[i].levelContentID))
					{
						continue;
					}
					for (int k = 0; k < contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel.Length; k++)
					{
						if (contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].behaviourID != string.Empty && contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].behaviourID.Length >= 6)
						{
							SET_behaviourA = string.Empty + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].behaviourID[0] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].behaviourID[1];
							SET_behaviourB = string.Empty + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].behaviourID[2] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].behaviourID[3];
							SET_behaviourC = string.Empty + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].behaviourID[4] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].behaviourID[5];
							levelObject[i].stageLevel[k].spawnType = int.Parse(SET_behaviourA);
							levelObject[i].stageLevel[k].spawnDuration = int.Parse(SET_behaviourB);
							levelObject[i].stageLevel[k].raritySpawn = int.Parse(SET_behaviourC);
						}
						else
						{
							levelObject[i].stageLevel[k].raritySpawn = 0f;
							levelObject[i].stageLevel[k].spawnDuration = 0f;
							levelObject[i].stageLevel[k].spawnType = 0;
						}
						for (int l = 0; l < SET_objectID.Length; l++)
						{
							SET_objectID[l] = string.Empty;
						}
						for (int m = 0; m < contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].objectIDs.Length / 6; m++)
						{
							SET_objectID[m] = string.Empty;
							SETID_objectID = string.Empty;
							SET_objectID[m] = string.Empty + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].objectIDs[m * 6] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].objectIDs[m * 6 + 1] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].objectIDs[m * 6 + 2] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].objectIDs[m * 6 + 3] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].objectIDs[m * 6 + 4];
							SETID_objectID = string.Empty + SET_objectID[m][0] + SET_objectID[m][1];
							if (SETID_objectID == "OR")
							{
								SETID_objectNo = string.Empty + SET_objectID[m][3] + SET_objectID[m][4];
								OR_objectSets = int.Parse(SETID_objectNo);
								SET_objectID[m] = ObjectSets[OR_objectSets].objectID[UnityEngine.Random.Range(0, ObjectSets[OR_objectSets].objectID.Length)];
							}
							for (int n = 0; n < objectContentData.ObjectList.Length; n++)
							{
								if (SET_objectID[m] == objectContentData.ObjectList[n].objectID)
								{
									levelObject[i].stageLevel[k].spawnObject[m] = objectContentData.ObjectList[n].objectPrefab;
									if (levelObject[i].stageLevel[k].spawnDuration == 0f)
									{
										levelObject[i].stageLevel[k].spawnDuration = objectContentData.ObjectList[n].defaultDuration;
									}
									if (levelObject[i].stageLevel[k].spawnType == 0)
									{
										levelObject[i].stageLevel[k].spawnType = objectContentData.ObjectList[n].defaultSpawnType;
									}
								}
							}
						}
						for (int num = 0; num < contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].positionIDs.Length / 7; num++)
						{
							SET_positionA = string.Empty + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].positionIDs[num * 7] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].positionIDs[num * 7 + 1];
							SET_positionB = string.Empty + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].positionIDs[num * 7 + 2] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].positionIDs[num * 7 + 3];
							SET_positionC = string.Empty + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].positionIDs[num * 7 + 4] + contentData.StageList[stageID_contentData].levelContents[j].levelContentScript.stageLevel[k].positionIDs[num * 7 + 5];
							levelObject[i].stageLevel[k].positionSet[num].A = int.Parse(SET_positionA);
							if (SET_positionB == "RD")
							{
								levelObject[i].stageLevel[k].positionSet[num].B = -1;
							}
							else if (SET_positionB == "RN")
							{
								levelObject[i].stageLevel[k].positionSet[num].B = UnityEngine.Random.Range(0, spawnPositions[levelObject[i].stageLevel[k].positionSet[num].A].position.Length);
							}
							else
							{
								levelObject[i].stageLevel[k].positionSet[num].B = int.Parse(SET_positionB);
							}
							if (SET_positionC == "RN")
							{
								levelObject[i].stageLevel[k].positionSet[num].C = k;
							}
							else
							{
								levelObject[i].stageLevel[k].positionSet[num].C = int.Parse(SET_positionC);
							}
						}
					}
				}
			}
			poolSetupState++;
			break;
		case 5:
			state++;
			break;
		}
	}

	private void LevelNumberFunction()
	{
		if (dataScript != null)
		{
			gameStage = dataScript.gameStage;
			switch (gameStage)
			{
			case 0:
				gameLevel = dataScript.gameLevel;
				break;
			case 1:
				gameLevel = dataScript.gameLevel - dataScript.gameLevelPerStage;
				break;
			case 2:
				gameLevel = dataScript.gameLevel - dataScript.gameLevelPerStage * 2;
				break;
			}
		}
	}

	private void Test()
	{
		if (UnityEngine.Input.GetKey(KeyCode.F1))
		{
			switch (state)
			{
			case -2:
				state = -1;
				break;
			case 1:
				objectState = 2;
				break;
			}
		}
		if (!Input.GetKeyDown(KeyCode.F4))
		{
			return;
		}
		int num = state;
		if (num == -2)
		{
			PoolManager.Pools["HUD Pool"].DespawnAll();
			for (int i = 0; i < spawnPositions[section_test].position.Length; i++)
			{
				PoolManager.Pools["HUD Pool"].Spawn(testObject.transform, spawnPositions[section_test].position[i].position, base.transform.rotation);
			}
			section_test++;
			if (section_test > spawnPositions.Length - 1)
			{
				section_test = 0;
			}
		}
	}

	private void Update()
	{
		if (debugMode == 1)
		{
			Test();
		}
		switch (state)
		{
		case -2:
			break;
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			break;
		case -4:
			LevelNumberFunction();
			state++;
			break;
		case -3:
			ScriptsManager.objectLogicScript = GetComponent<Object_Logic>();
			PoolSetup();
			break;
		case -1:
			for (int i = 0; i < stageObject.Length; i++)
			{
				if (stageObject[i].spawnObject == null)
				{
					continue;
				}
				INST_spawnManager = PoolManager.Pools["Stage Spawn Managers"].Spawn(spawnManager.transform, Vector3.zero, base.transform.rotation);
				INST_scriptSpawnManager = INST_spawnManager.GetComponent<spawn_manager>();
				INST_scriptSpawnManager.objectLogic = GetComponent<Object_Logic>();
				INST_scriptSpawnManager.raritySpawn = stageObject[i].raritySpawn;
				INST_scriptSpawnManager.spawnDuration = stageObject[i].spawnDuration;
				INST_scriptSpawnManager.spawnType = stageObject[i].spawnType;
				INST_scriptSpawnManager.spawnerType = 1;
				for (int j = 0; j < stageObject[i].spawnObject.Length; j++)
				{
					if (stageObject[i].spawnObject[j] != null)
					{
						INST_scriptSpawnManager.objectSet[j] = stageObject[i].spawnObject[j];
					}
				}
				for (int k = 0; k < stageObject[i].setPosition.Length; k++)
				{
					if (stageObject[i].setPosition[k] != null)
					{
						INST_scriptSpawnManager.positionSet[k] = stageObject[i].setPosition[k].transform.position;
					}
				}
				INST_scriptSpawnManager.activation = 1;
			}
			state++;
			break;
		case 0:
			LevelNumberFunction();
			for (int l = 0; l < levelObject[gameLevel].stageLevel.Length; l++)
			{
				if (!(levelObject[gameLevel].stageLevel[l].spawnObject[0] != null))
				{
					continue;
				}
				INST_spawnManager = PoolManager.Pools["Spawn Managers"].Spawn(spawnManager.transform, Vector3.zero, base.transform.rotation);
				INST_scriptSpawnManager = INST_spawnManager.GetComponent<spawn_manager>();
				INST_scriptSpawnManager.objectLogic = GetComponent<Object_Logic>();
				for (int m = 0; m < levelObject[gameLevel].stageLevel[l].spawnObject.Length; m++)
				{
					INST_scriptSpawnManager.objectSet[m] = levelObject[gameLevel].stageLevel[l].spawnObject[m];
				}
				INST_scriptSpawnManager.raritySpawn = levelObject[gameLevel].stageLevel[l].raritySpawn;
				INST_scriptSpawnManager.spawnDuration = levelObject[gameLevel].stageLevel[l].spawnDuration;
				INST_scriptSpawnManager.spawnType = levelObject[gameLevel].stageLevel[l].spawnType;
				for (int n = 0; n < levelObject[gameLevel].stageLevel[l].positionSet.Length; n++)
				{
					if (levelObject[gameLevel].stageLevel[l].positionSet[n].A != 0)
					{
						if (levelObject[gameLevel].stageLevel[l].positionSet[n].B == -1)
						{
							INST_scriptSpawnManager.randomPositionSet = levelObject[gameLevel].stageLevel[l].positionSet[n].A;
							continue;
						}
						ref Vector3 reference = ref INST_scriptSpawnManager.positionSet[n];
						Vector3 position = spawnPositions[levelObject[gameLevel].stageLevel[l].positionSet[n].A].position[levelObject[gameLevel].stageLevel[l].positionSet[n].B].transform.position;
						float x = position.x;
						Vector3 position2 = spawnPositions[levelObject[gameLevel].stageLevel[l].positionSet[n].A].position[levelObject[gameLevel].stageLevel[l].positionSet[n].B].transform.position;
						float y = position2.y + (float)levelObject[gameLevel].stageLevel[l].positionSet[n].C;
						Vector3 position3 = spawnPositions[levelObject[gameLevel].stageLevel[l].positionSet[n].A].position[levelObject[gameLevel].stageLevel[l].positionSet[n].B].transform.position;
						reference = new Vector3(x, y, position3.z);
					}
				}
				INST_scriptSpawnManager.activation = 1;
			}
			TOGGLE_objectState = 0;
			objectState = 0;
			state++;
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				TOGGLE_state = state;
			}
			if (objectState != 0)
			{
				if (TOGGLE_objectState != objectState)
				{
					TIMER_objecState = Time.time + 0.1f;
					TOGGLE_objectState = objectState;
				}
				if (Time.time >= TIMER_objecState)
				{
					TOGGLE_objectState = 0;
					objectState = 0;
				}
			}
			break;
		case 2:
			if (TOGGLE_state != state)
			{
				PoolManager.Pools["Spawn Managers"].DespawnAll();
				TOGGLE_state = state;
			}
			break;
		case 10:
			UnityEngine.Object.Destroy(base.gameObject);
			break;
		}
	}
}
