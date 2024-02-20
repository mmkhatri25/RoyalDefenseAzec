using System;
using UnityEngine;

public class Content_Data : MonoBehaviour
{
	[Serializable]
	public class storeIAPs
	{
		public string iapID;

		public string iapValue;

		public string iapName;

		public GameObject iapObject;

		public int iapState;

		public string iapProductID;

		public int iapType;

		public int characterNumber;

		public int characterDifficulty;

		public int characterCompletion;

		public string miscDescription;
	}

	[Serializable]
	public class stageList
	{
		[Serializable]
		public class stageObject
		{
			public string objectID;

			public GameObject[] objectPrefab;

			public float raritySpawn;

			public float spawnDuration;

			public int spawnType;
		}

		[Serializable]
		public class LevelContents
		{
			public string levelContentID;

			public Level_Content levelContentScript;
		}

		public string stageID;

		public string stageName;

		public GameObject environmentPrefab;

		public int objectLogicPrefab;

		public int stageMusicTrackA;

		public int stageMusicTrackB;

		public float additionStageLength;

		public stageObject[] StageObject;

		public LevelContents[] levelContents;
	}

	public bool itemReset;

	public int itemDebug;

	public Game_Data data;

	public int state;

	public int musicPlaying;

	public storeIAPs[] StoreIAPs = new storeIAPs[100];

	public int productAmountOwned;

	public int productAmountAvaliable;

	public int productAmountTotal;

	public stageList[] StageList;

	public GameObject[] musicGeneral;

	public GameObject[] musicGameplay;

	public GameObject[] musicBoss;

	public AudioClip[] clickSound = new AudioClip[10];

	private GameObject instMusicObject;

	private void Awake()
	{
		base.useGUILayout = false;
		ScriptsManager.contentDataScript = GetComponent<Content_Data>();
		state = -2;
	}

	private void Update()
	{
		switch (state)
		{
		case 1:
			break;
		case -2:
			for (int i = 0; i < clickSound.Length; i++)
			{
				ScriptsManager.audioClip[i] = clickSound[i];
			}
			CharacterOrganization();
			state++;
			break;
		case -1:
			state++;
			break;
		case 0:
			productAmountOwned = 0;
			productAmountAvaliable = 0;
			productAmountTotal = 0;
			StoreDataUpdate();
			state++;
			break;
		}
	}

	private void CharacterOrganization()
	{
		for (int i = 0; i < StoreIAPs.Length; i++)
		{
			for (int j = 0; j < ScriptsManager.dataScript.CharacterData.Length; j++)
			{
				if (StoreIAPs[i].iapID == ScriptsManager.dataScript.CharacterData[j].characterID)
				{
					StoreIAPs[i].iapName = ScriptsManager.dataScript.CharacterData[j].characterName;
					StoreIAPs[i].iapObject = ScriptsManager.dataScript.CharacterData[j].characterObject;
					StoreIAPs[i].iapType = 1;
					StoreIAPs[i].characterDifficulty = StoreIAPs[i].iapObject.GetComponent<PlayerCharacterInfo>().characterDifficulty;
					StoreIAPs[i].characterNumber = j;
				}
			}
		}
	}

	private void StoreDataUpdate()
	{
		for (int i = 0; i < StoreIAPs.Length; i++)
		{
			if (StoreIAPs[i].iapName != string.Empty)
			{
				StoreIAPs[i].iapState = PlayerPrefs.GetInt(StoreIAPs[i].iapID + "LOCK");
				productAmountTotal++;
				if (StoreIAPs[i].iapState == 1)
				{
					productAmountOwned++;
					StoreIAPs[i].characterCompletion = PlayerPrefs.GetInt(StoreIAPs[i].iapID + "completionPercent");
				}
				else if (StoreIAPs[i].iapState == 0 && StoreIAPs[i].iapType == 1)
				{
					productAmountAvaliable++;
				}
			}
		}
	}

	private void ItemReset()
	{
	}

	public void PlayMusic(int musicType, int musicNumber)
	{
		if (ScriptsManager.dataScript.soundMode == 0)
		{
			PoolManager.Pools["Music Pool"].DespawnAll();
			switch (musicType)
			{
			case -1:
				musicPlaying = 0;
				break;
			case 0:
				PoolManager.Pools["Music Pool"].Spawn(musicGeneral[musicNumber].transform, Vector3.zero, base.transform.rotation);
				musicPlaying = 1;
				break;
			case 1:
				PoolManager.Pools["Music Pool"].Spawn(musicGameplay[musicNumber].transform, Vector3.zero, base.transform.rotation);
				musicPlaying = 2;
				break;
			case 2:
				PoolManager.Pools["Music Pool"].Spawn(musicBoss[musicNumber].transform, Vector3.zero, base.transform.rotation);
				musicPlaying = 3;
				break;
			}
		}
		else
		{
			musicPlaying = 0;
			PoolManager.Pools["Music Pool"].DespawnAll();
		}
	}
}
