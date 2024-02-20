using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using UnityEngine;

public class Game_Data : MonoBehaviour
{
	[Serializable]
	public class characterData
	{
		public int characterStoryUnlocks;

		public int characterNextBookUnlock;

		public string characterID;

		public string characterName;

		public string characterClass;

		public GameObject characterObject;

		public GameObject characterObjectInst;

		public int characterLOCK;

		public int levelProgress;

		public int[] levelRating = new int[18];

		public int ratingGold;

		public int ratingSilver;

		public int ratingBronze;

		public int completionPercent;

		public int itemLock;

		public int[] bestWaveRecord = new int[3];

		public int[] bestUnitRecord = new int[3];

		public int gameStoryAttempts;

		public int gameStoryVictories;

		public int gameStoryDefeats;

		public int gameStoryVictoryRate;

		public int gameChallengeAttempts;

		public int gameChallengeStreak;

		public int[] gameSpellsCasted = new int[4];

		public string[] gameItemRating = new string[3];
	}

	[Serializable]
	public class challengeWaveRecord
	{
		public string recordName;

		public int recordNumber;

		public string recordCharacter;
	}

	[Serializable]
	public class challengeUnitRecord
	{
		public string recordName;

		public int recordNumber;

		public string recordCharacter;
	}

	public string gameVersion;

	public int targetFrameRate;

	public int releaseMode;

	public int unlockMode;

	public int levelStartMode;

	public int iapMode;

	public int iCloudSave;

	public int gameCenterMode;

	public int gameAnalyticsMode;

	public int autoTutorialMode;

	public int saveMode;

	public int debugMode;

	public int debugNumber;

	public int soundMode;

	public int gameTutorialMode;

	public int gameMode;

	public int gameLevel;

	public int gameStage;

	public int gameLevelPerStage;

	public int gameMaximumLevel;

	public int gameChallengeCost;

	public int playerCurrency;

	private int playerCurrencyLimit = 1000;

	private int TOGGLE_playerCurrency;

	public int playerKey;

	private int playerKeyLimit = 99;

	private int TOGGGLE_playerKey;

	public string selectedCharacterID;

	public string selectedCharacterName;

	public string selectedCharacterClass;

	public int selectedCharacterLevelProgress;

	public int[] selectedCharacterLevelRating = new int[18];

	public int selectedCharacterRatingGold;

	public int selectedCharacterRatingSilver;

	public int selectedCharacterRatingBronze;

	public int selectedCharacterCompletionPercent;

	public int[] selectedCharacterBestWaveRecord = new int[3];

	public int[] selectedCharacterBestUnitRecord = new int[3];

	public int selectedCharacterStoryAttempts;

	public int selectedCharacterStoryVictories;

	public int selectedCharacterStoryDefeats;

	public int selectedCharacterStoryVictoryRate;

	public int selectedCharacterChallengeAttempts;

	public int selectedCharacterChallengeStreak;

	public int[] selectedCharacterSpellsCasted = new int[4];

	public string[] selectedCharacterItemRating = new string[3];

	public characterData[] CharacterData;

	public challengeWaveRecord[] ChallengeWaveRecord = new challengeWaveRecord[3];

	public challengeUnitRecord[] ChallengeUnitRecord = new challengeUnitRecord[3];

	private int firstLoad;

	private int state = -2;

	private string iCloudCharacterID;

	private bool turnOffGooglePlayGames = true;

	private bool isAuthenticated;

	private Transform instCharacter;

	private string ID_character;

	private PlayerCharacterData scriptCharacterData;

	private void Start()
	{
		base.useGUILayout = false;
		ScriptsManager.dataScript = GetComponent<Game_Data>();
		Resources.UnloadUnusedAssets();
		Application.targetFrameRate = targetFrameRate;
		switch (releaseMode)
		{
		case 0:
			gameVersion += " DEVELOPMENT";
			unlockMode = 1;
			iapMode = 0;
			iCloudSave = 1;
			autoTutorialMode = 1;
			debugMode = 1;
			break;
		case 1:
			gameVersion += "T";
			unlockMode = 1;
			levelStartMode = 1;
			iCloudSave = 1;
			iapMode = 0;
			gameCenterMode = 3;
			gameAnalyticsMode = 0;
			autoTutorialMode = 1;
			saveMode = 0;
			debugMode = 0;
			break;
		case 2:
			unlockMode = 1;
			levelStartMode = 1;
			iCloudSave = 1;
			iapMode = 0;
			gameCenterMode = 3;
			gameAnalyticsMode = 2;
			autoTutorialMode = 1;
			saveMode = 0;
			debugMode = 0;
			break;
		}
	}

	private void Update()
	{
		if (Time.frameCount % 30 == 0)
		{
			GC.Collect();
		}
		switch (state)
		{
		case -2:
			firstLoad = PlayerPrefs.GetInt("libraryIntro");
			if (firstLoad == 0)
			{
				PlayerPrefs.SetInt("libraryIntro", 0);
				PlayerPrefs.SetInt("iCloudUpdateNumber", 0);
			}
			switch (releaseMode)
			{
			case 0:
				unlockMode = 1;
				iCloudSave = 1;
				iapMode = 0;
				autoTutorialMode = 1;
				debugMode = 1;
				break;
			case 1:
				unlockMode = 1;
				levelStartMode = 1;
				iCloudSave = 1;
				iapMode = 0;
				gameCenterMode = 3;
				gameAnalyticsMode = 0;
				autoTutorialMode = 1;
				saveMode = 0;
				debugMode = 0;
				break;
			case 2:
				unlockMode = 1;
				levelStartMode = 1;
				iCloudSave = 1;
				iapMode = 0;
				gameCenterMode = 3;
				gameAnalyticsMode = 2;
				autoTutorialMode = 1;
				saveMode = 0;
				debugMode = 0;
				break;
			}
			state++;
			break;
		case -1:
			if (JCloudData.GetString("clientID") != string.Empty)
			{
				PlayerPrefs.SetString("clientID", JCloudData.GetString("clientID"));
			}
			else if (PlayerPrefs.GetString("clientID") != string.Empty)
			{
				JCloudData.SetString("clientID", PlayerPrefs.GetString("clientID"));
				JCloudData.Save();
			}
			if (PlayerPrefs.GetInt("libraryIntro") == 0)
			{
				iCloudData(1, "null", 0);
			}
			else if (PlayerPrefs.GetInt("iCloudUpdateNumber") < JCloudData.GetInt("iCloudUpdateNumber"))
			{
				iCloudData(1, "null", 0);
			}
			else if (PlayerPrefs.GetInt("iCloudUpdateNumber") > JCloudData.GetInt("iCloudUpdateNumber"))
			{
				iCloudData(4, "null", 0);
			}
			PlayerPrefs.SetInt("WZLOCK", 1);
			state++;
			break;
		case 0:
			GameDataLoad();
			state++;
			break;
		case 1:
			SelectCharacter(PlayerPrefs.GetString("SelectedCharacter"));
			TutorialOption(PlayerPrefs.GetInt("gameTutorialMode"));
			state++;
			break;
		case 2:
			GameStageLevelSetup();
			if (PlayerPrefs.GetInt("playerCurrency") > playerCurrencyLimit)
			{
				PlayerCurrency((playerCurrencyLimit - playerCurrency) * -1);
			}
			if (playerCurrency != PlayerPrefs.GetInt("playerCurrency"))
			{
				playerCurrency = PlayerPrefs.GetInt("playerCurrency");
			}
			if (debugMode != 1)
			{
				break;
			}
			if (playerCurrency == -1)
			{
				PlayerCurrency(-100000);
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.F1))
			{
				if (AudioListener.volume == 1f)
				{
					AudioListener.volume = 0.2f;
				}
				else if (AudioListener.volume == 0.2f)
				{
					AudioListener.volume = 1f;
				}
			}
			switch (debugNumber)
			{
			case 1:
				PlayerPrefs.SetInt("libraryIntro", 0);
				PlayerPrefs.SetInt("tutorialIntro", 0);
				PlayerPrefs.SetInt("GCallBooks", 0);
				TutorialOption(0);
				PlayerKey(-999999999);
				PlayerCurrency(-999999999);
				for (int i = 0; i < CharacterData.Length; i++)
				{
					if (CharacterData[i].characterID != string.Empty)
					{
						CharacterDataErase(CharacterData[i].characterID, 1);
						characterLock(CharacterData[i].characterID);
					}
				}
				ScriptsManager.contentDataScript.itemReset = true;
				JCloudData.DeleteAll();
				JCloudData.Save();
				PlayerPrefs.SetInt("iCloudUpdateNumber", 0);
				PlayerPrefs.DeleteAll();
				PlayerPrefs.SetInt("WZLOCK", 1);
				SelectCharacter("WZ");
				UnityEngine.SceneManagement.SceneManager.LoadScene("Load - Menu");
				debugNumber = 0;
				break;
			case 2:
				SelectCharacter(selectedCharacterID);
				CharacterDataErase(selectedCharacterID, 1);
				characterLock(selectedCharacterID);
				PlayerPrefs.SetInt("WZLOCK", 1);
				SelectCharacter("WZ");
				UnityEngine.SceneManagement.SceneManager.LoadScene("Load - Menu");
				debugNumber = 0;
				break;
			case 3:
				SelectCharacter(selectedCharacterID);
				CharacterDataErase(selectedCharacterID, 1);
				CharacterTestCompletion(selectedCharacterID);
				SelectCharacterUpdate(selectedCharacterID);
				UnityEngine.SceneManagement.SceneManager.LoadScene("Load - Menu");
				debugNumber = 0;
				break;
			}
			break;
		}
	}

	public void iCloudData(int toggle, string ID, int number)
	{
		if (iCloudSave != 1)
		{
			return;
		}
		switch (toggle)
		{
		case 0:
			break;
		case -1:
			JCloudData.SetInt("playerCurrency", PlayerPrefs.GetInt("playerCurrency"));
			JCloudData.Save();
			break;
		case 1:
			for (int num2 = 0; num2 < CharacterData.Length; num2++)
			{
				if (CharacterData[num2].characterID != string.Empty)
				{
					iCloudCharacterID = CharacterData[num2].characterID;
					scriptCharacterData = CharacterData[num2].characterObject.GetComponent<PlayerCharacterData>();
					PlayerPrefs.SetInt(iCloudCharacterID + "LOCK", JCloudData.GetInt(iCloudCharacterID + "LOCK"));
					PlayerPrefs.SetInt(iCloudCharacterID + "storyUnlocks", JCloudData.GetInt(iCloudCharacterID + "storyUnlocks"));
					PlayerPrefs.SetInt(iCloudCharacterID + "nextBookUnlock", JCloudData.GetInt(iCloudCharacterID + "nextBookUnlock"));
					PlayerPrefs.SetInt(iCloudCharacterID + "levelProgress", JCloudData.GetInt(iCloudCharacterID + "levelProgress"));
					PlayerPrefs.SetInt(iCloudCharacterID + "GCunlock", JCloudData.GetInt(iCloudCharacterID + "GCunlock"));
					PlayerPrefs.SetInt(iCloudCharacterID + "GCstage1", JCloudData.GetInt(iCloudCharacterID + "GCstage1"));
					PlayerPrefs.SetInt(iCloudCharacterID + "GCstage2", JCloudData.GetInt(iCloudCharacterID + "GCstage2"));
					PlayerPrefs.SetInt(iCloudCharacterID + "GCstage3", JCloudData.GetInt(iCloudCharacterID + "GCstage3"));
					PlayerPrefs.SetInt(iCloudCharacterID + "GCstageGold", JCloudData.GetInt(iCloudCharacterID + "GCstageGold"));
					PlayerPrefs.SetInt(iCloudCharacterID + "GCarena0", JCloudData.GetInt(iCloudCharacterID + "GCarena0"));
					PlayerPrefs.SetInt(iCloudCharacterID + "GCarena1", JCloudData.GetInt(iCloudCharacterID + "GCarena1"));
					for (int num3 = 0; num3 < CharacterData[num2].levelRating.Length; num3++)
					{
						PlayerPrefs.SetInt(iCloudCharacterID + "levelRating" + num3, JCloudData.GetInt(iCloudCharacterID + "levelRating" + num3));
					}
					PlayerPrefs.SetInt(iCloudCharacterID + "ratingBronze", JCloudData.GetInt(iCloudCharacterID + "ratingBronze"));
					PlayerPrefs.SetInt(iCloudCharacterID + "ratingSilver", JCloudData.GetInt(iCloudCharacterID + "ratingSilver"));
					PlayerPrefs.SetInt(iCloudCharacterID + "ratingGold", JCloudData.GetInt(iCloudCharacterID + "ratingGold"));
					PlayerPrefs.SetInt(iCloudCharacterID + "completionPercent", JCloudData.GetInt(iCloudCharacterID + "completionPercent"));
					for (int num4 = 0; num4 < 3; num4++)
					{
						PlayerPrefs.SetInt(iCloudCharacterID + "bestWaveRecord" + num4, JCloudData.GetInt(iCloudCharacterID + "bestWaveRecord" + num4));
						PlayerPrefs.SetInt(iCloudCharacterID + "bestUnitRecord" + num4, JCloudData.GetInt(iCloudCharacterID + "bestUnitRecord" + num4));
						PlayerPrefs.SetString(iCloudCharacterID + "bestWaveRecordName" + num4, JCloudData.GetString(iCloudCharacterID + "bestWaveRecordName" + num4));
						PlayerPrefs.SetString(iCloudCharacterID + "bestUnitRecordName" + num4, JCloudData.GetString(iCloudCharacterID + "bestUnitRecordName" + num4));
					}
					for (int num5 = 0; num5 < scriptCharacterData.ItemUnlockID.Length; num5++)
					{
						PlayerPrefs.SetInt(scriptCharacterData.ItemUnlockID[num5].itemID + "itemLock", JCloudData.GetInt(scriptCharacterData.ItemUnlockID[num5].itemID + "itemLock"));
					}
				}
			}
			PlayerPrefs.SetInt("playerCurrency", JCloudData.GetInt("playerCurrency"));
			PlayerPrefs.SetInt("tutorialIntro", JCloudData.GetInt("tutorialIntro"));
			PlayerPrefs.SetInt("GCallBooks", JCloudData.GetInt("GCallBooks"));
			PlayerPrefs.SetInt("libraryIntro", JCloudData.GetInt("libraryIntro"));
			PlayerPrefs.SetInt("WZLOCK", 1);
			JCloudData.SetInt("WZLOCK", 1);
			PlayerPrefs.SetInt("iCloudUpdateNumber", JCloudData.GetInt("iCloudUpdateNumber"));
			break;
		case 2:
			JCloudData.SetInt(ID + "LOCK", PlayerPrefs.GetInt(ID + "LOCK"));
			JCloudData.SetInt(ID + "storyUnlocks", PlayerPrefs.GetInt(ID + "storyUnlocks"));
			JCloudData.SetInt(ID + "nextBookUnlock", PlayerPrefs.GetInt(ID + "nextBookUnlock"));
			JCloudData.SetInt(ID + "levelProgress", PlayerPrefs.GetInt(ID + "levelProgress"));
			JCloudData.SetInt(ID + "GCunlock", PlayerPrefs.GetInt(ID + "GCunlock"));
			JCloudData.SetInt(ID + "GCstage1", PlayerPrefs.GetInt(ID + "GCstage1"));
			JCloudData.SetInt(ID + "GCstage2", PlayerPrefs.GetInt(ID + "GCstage2"));
			JCloudData.SetInt(ID + "GCstage3", PlayerPrefs.GetInt(ID + "GCstage3"));
			JCloudData.SetInt(ID + "GCstageGold", PlayerPrefs.GetInt(ID + "GCstageGold"));
			JCloudData.SetInt(ID + "GCarena0", PlayerPrefs.GetInt(ID + "GCarena0"));
			JCloudData.SetInt(ID + "GCarena1", PlayerPrefs.GetInt(ID + "GCarena1"));
			for (int m = 0; m < CharacterData[number].levelRating.Length; m++)
			{
				JCloudData.SetInt(ID + "levelRating" + m, PlayerPrefs.GetInt(ID + "levelRating" + m));
			}
			JCloudData.SetInt(ID + "ratingBronze", PlayerPrefs.GetInt(ID + "ratingBronze"));
			JCloudData.SetInt(ID + "ratingSilver", PlayerPrefs.GetInt(ID + "ratingSilver"));
			JCloudData.SetInt(ID + "ratingGold", PlayerPrefs.GetInt(ID + "ratingGold"));
			JCloudData.SetInt(ID + "completionPercent", PlayerPrefs.GetInt(ID + "completionPercent"));
			for (int n = 0; n < 3; n++)
			{
				JCloudData.SetInt(ID + "bestWaveRecord" + n, PlayerPrefs.GetInt(ID + "bestWaveRecord" + n));
				JCloudData.SetInt(ID + "bestUnitRecord" + n, PlayerPrefs.GetInt(ID + "bestUnitRecord" + n));
				JCloudData.SetString(ID + "bestWaveRecordName" + n, PlayerPrefs.GetString(ID + "bestWaveRecordName" + n));
				JCloudData.SetString(ID + "bestUnitRecordName" + n, PlayerPrefs.GetString(ID + "bestUnitRecordName" + n));
			}
			scriptCharacterData = CharacterData[number].characterObject.GetComponent<PlayerCharacterData>();
			for (int num = 0; num < scriptCharacterData.ItemUnlockID.Length; num++)
			{
				JCloudData.SetInt(scriptCharacterData.ItemUnlockID[num].itemID + "itemLock", PlayerPrefs.GetInt(scriptCharacterData.ItemUnlockID[num].itemID + "itemLock"));
			}
			JCloudData.SetInt("playerCurrency", PlayerPrefs.GetInt("playerCurrency"));
			JCloudData.SetInt("tutorialIntro", PlayerPrefs.GetInt("tutorialIntro"));
			JCloudData.SetInt("GCallBooks", PlayerPrefs.GetInt("GCallBooks"));
			JCloudData.SetInt("libraryIntro", PlayerPrefs.GetInt("libraryIntro"));
			PlayerPrefs.SetInt("iCloudUpdateNumber", PlayerPrefs.GetInt("iCloudUpdateNumber") + 1);
			JCloudData.SetInt("iCloudUpdateNumber", PlayerPrefs.GetInt("iCloudUpdateNumber"));
			JCloudData.Save();
			break;
		case 3:
			if (PlayerPrefs.GetInt("libraryIntro") == 0 || PlayerPrefs.GetInt("iCloudUpdateNumber") < JCloudData.GetInt("iCloudUpdateNumber"))
			{
				break;
			}
			for (int num6 = 0; num6 < CharacterData.Length; num6++)
			{
				if (CharacterData[num6].characterID != string.Empty)
				{
					iCloudCharacterID = CharacterData[num6].characterID;
					scriptCharacterData = CharacterData[num6].characterObject.GetComponent<PlayerCharacterData>();
					JCloudData.SetInt(iCloudCharacterID + "LOCK", PlayerPrefs.GetInt(iCloudCharacterID + "LOCK"));
					JCloudData.SetInt(iCloudCharacterID + "storyUnlocks", PlayerPrefs.GetInt(iCloudCharacterID + "storyUnlocks"));
					JCloudData.SetInt(iCloudCharacterID + "nextBookUnlock", PlayerPrefs.GetInt(iCloudCharacterID + "nextBookUnlock"));
					JCloudData.SetInt(iCloudCharacterID + "levelProgress", PlayerPrefs.GetInt(iCloudCharacterID + "levelProgress"));
					JCloudData.SetInt(iCloudCharacterID + "GCunlock", PlayerPrefs.GetInt(iCloudCharacterID + "GCunlock"));
					JCloudData.SetInt(iCloudCharacterID + "GCstage1", PlayerPrefs.GetInt(iCloudCharacterID + "GCstage1"));
					JCloudData.SetInt(iCloudCharacterID + "GCstage2", PlayerPrefs.GetInt(iCloudCharacterID + "GCstage2"));
					JCloudData.SetInt(iCloudCharacterID + "GCstage3", PlayerPrefs.GetInt(iCloudCharacterID + "GCstage3"));
					JCloudData.SetInt(iCloudCharacterID + "GCstageGold", PlayerPrefs.GetInt(iCloudCharacterID + "GCstageGold"));
					JCloudData.SetInt(iCloudCharacterID + "GCarena0", PlayerPrefs.GetInt(iCloudCharacterID + "GCarena0"));
					JCloudData.SetInt(iCloudCharacterID + "GCarena1", PlayerPrefs.GetInt(iCloudCharacterID + "GCarena1"));
					for (int num7 = 0; num7 < CharacterData[num6].levelRating.Length; num7++)
					{
						JCloudData.SetInt(iCloudCharacterID + "levelRating" + num7, PlayerPrefs.GetInt(iCloudCharacterID + "levelRating" + num7));
					}
					JCloudData.SetInt(iCloudCharacterID + "ratingBronze", PlayerPrefs.GetInt(iCloudCharacterID + "ratingBronze"));
					JCloudData.SetInt(iCloudCharacterID + "ratingSilver", PlayerPrefs.GetInt(iCloudCharacterID + "ratingSilver"));
					JCloudData.SetInt(iCloudCharacterID + "ratingGold", PlayerPrefs.GetInt(iCloudCharacterID + "ratingGold"));
					JCloudData.SetInt(iCloudCharacterID + "completionPercent", PlayerPrefs.GetInt(iCloudCharacterID + "completionPercent"));
					for (int num8 = 0; num8 < 3; num8++)
					{
						JCloudData.SetInt(iCloudCharacterID + "bestWaveRecord" + num8, PlayerPrefs.GetInt(iCloudCharacterID + "bestWaveRecord" + num8));
						JCloudData.SetInt(iCloudCharacterID + "bestUnitRecord" + num8, PlayerPrefs.GetInt(iCloudCharacterID + "bestUnitRecord" + num8));
						JCloudData.SetString(iCloudCharacterID + "bestWaveRecordName" + num8, PlayerPrefs.GetString(iCloudCharacterID + "bestWaveRecordName" + num8));
						JCloudData.SetString(iCloudCharacterID + "bestUnitRecordName" + num8, PlayerPrefs.GetString(iCloudCharacterID + "bestUnitRecordName" + num8));
					}
					for (int num9 = 0; num9 < scriptCharacterData.ItemUnlockID.Length; num9++)
					{
						JCloudData.SetInt(scriptCharacterData.ItemUnlockID[num9].itemID + "itemLock", PlayerPrefs.GetInt(scriptCharacterData.ItemUnlockID[num9].itemID + "itemLock"));
					}
				}
			}
			JCloudData.SetInt("playerCurrency", PlayerPrefs.GetInt("playerCurrency"));
			JCloudData.SetInt("tutorialIntro", PlayerPrefs.GetInt("tutorialIntro"));
			JCloudData.SetInt("GCallBooks", PlayerPrefs.GetInt("GCallBooks"));
			JCloudData.SetInt("libraryIntro", PlayerPrefs.GetInt("libraryIntro"));
			PlayerPrefs.SetInt("iCloudUpdateNumber", PlayerPrefs.GetInt("iCloudUpdateNumber") + 1);
			JCloudData.SetInt("iCloudUpdateNumber", PlayerPrefs.GetInt("iCloudUpdateNumber"));
			JCloudData.Save();
			break;
		case 4:
			if (PlayerPrefs.GetInt("iCloudUpdateNumber") <= JCloudData.GetInt("iCloudUpdateNumber"))
			{
				break;
			}
			for (int i = 0; i < CharacterData.Length; i++)
			{
				if (CharacterData[i].characterID != string.Empty)
				{
					iCloudCharacterID = CharacterData[i].characterID;
					scriptCharacterData = CharacterData[i].characterObject.GetComponent<PlayerCharacterData>();
					JCloudData.SetInt(iCloudCharacterID + "LOCK", PlayerPrefs.GetInt(iCloudCharacterID + "LOCK"));
					JCloudData.SetInt(iCloudCharacterID + "storyUnlocks", PlayerPrefs.GetInt(iCloudCharacterID + "storyUnlocks"));
					JCloudData.SetInt(iCloudCharacterID + "nextBookUnlock", PlayerPrefs.GetInt(iCloudCharacterID + "nextBookUnlock"));
					JCloudData.SetInt(iCloudCharacterID + "levelProgress", PlayerPrefs.GetInt(iCloudCharacterID + "levelProgress"));
					JCloudData.SetInt(iCloudCharacterID + "GCunlock", PlayerPrefs.GetInt(iCloudCharacterID + "GCunlock"));
					JCloudData.SetInt(iCloudCharacterID + "GCstage1", PlayerPrefs.GetInt(iCloudCharacterID + "GCstage1"));
					JCloudData.SetInt(iCloudCharacterID + "GCstage2", PlayerPrefs.GetInt(iCloudCharacterID + "GCstage2"));
					JCloudData.SetInt(iCloudCharacterID + "GCstage3", PlayerPrefs.GetInt(iCloudCharacterID + "GCstage3"));
					JCloudData.SetInt(iCloudCharacterID + "GCstageGold", PlayerPrefs.GetInt(iCloudCharacterID + "GCstageGold"));
					JCloudData.SetInt(iCloudCharacterID + "GCarena0", PlayerPrefs.GetInt(iCloudCharacterID + "GCarena0"));
					JCloudData.SetInt(iCloudCharacterID + "GCarena1", PlayerPrefs.GetInt(iCloudCharacterID + "GCarena1"));
					for (int j = 0; j < CharacterData[i].levelRating.Length; j++)
					{
						JCloudData.SetInt(iCloudCharacterID + "levelRating" + j, PlayerPrefs.GetInt(iCloudCharacterID + "levelRating" + j));
					}
					JCloudData.SetInt(iCloudCharacterID + "ratingBronze", PlayerPrefs.GetInt(iCloudCharacterID + "ratingBronze"));
					JCloudData.SetInt(iCloudCharacterID + "ratingSilver", PlayerPrefs.GetInt(iCloudCharacterID + "ratingSilver"));
					JCloudData.SetInt(iCloudCharacterID + "ratingGold", PlayerPrefs.GetInt(iCloudCharacterID + "ratingGold"));
					JCloudData.SetInt(iCloudCharacterID + "completionPercent", PlayerPrefs.GetInt(iCloudCharacterID + "completionPercent"));
					for (int k = 0; k < 3; k++)
					{
						JCloudData.SetInt(iCloudCharacterID + "bestWaveRecord" + k, PlayerPrefs.GetInt(iCloudCharacterID + "bestWaveRecord" + k));
						JCloudData.SetInt(iCloudCharacterID + "bestUnitRecord" + k, PlayerPrefs.GetInt(iCloudCharacterID + "bestUnitRecord" + k));
						JCloudData.SetString(iCloudCharacterID + "bestWaveRecordName" + k, PlayerPrefs.GetString(iCloudCharacterID + "bestWaveRecordName" + k));
						JCloudData.SetString(iCloudCharacterID + "bestUnitRecordName" + k, PlayerPrefs.GetString(iCloudCharacterID + "bestUnitRecordName" + k));
					}
					for (int l = 0; l < scriptCharacterData.ItemUnlockID.Length; l++)
					{
						JCloudData.SetInt(scriptCharacterData.ItemUnlockID[l].itemID + "itemLock", PlayerPrefs.GetInt(scriptCharacterData.ItemUnlockID[l].itemID + "itemLock"));
					}
				}
			}
			JCloudData.SetInt("playerCurrency", PlayerPrefs.GetInt("playerCurrency"));
			JCloudData.SetInt("tutorialIntro", PlayerPrefs.GetInt("tutorialIntro"));
			JCloudData.SetInt("GCallBooks", PlayerPrefs.GetInt("GCallBooks"));
			JCloudData.SetInt("libraryIntro", PlayerPrefs.GetInt("libraryIntro"));
			JCloudData.SetInt("iCloudUpdateNumber", PlayerPrefs.GetInt("iCloudUpdateNumber"));
			JCloudData.Save();
			break;
		}
	}

	public void GameCenter(int toggle, int number, int score)
	{
		if (turnOffGooglePlayGames || gameCenterMode == 0)
		{
			return;
		}
		string leaderboardId = "CgkI-LOTtu4VEAIQAA";
		string text = "CgkI-LOTtu4VEAIQAQ";
		string achievementID = string.Empty;
		string achievementID2 = string.Empty;
		string achievementID3 = string.Empty;
		string achievementID4 = string.Empty;
		string achievementID5 = string.Empty;
		string achievementID6 = string.Empty;
		string achievementID7 = string.Empty;
		switch (selectedCharacterID)
		{
		case "WZ":
			text = "CgkI-LOTtu4VEAIQAQ";
			achievementID = "CgkI-LOTtu4VEAIQBA";
			achievementID2 = "CgkI-LOTtu4VEAIQBQ";
			achievementID3 = "CgkI-LOTtu4VEAIQBg";
			achievementID4 = "CgkI-LOTtu4VEAIQBw";
			achievementID5 = "CgkI-LOTtu4VEAIQCA";
			achievementID6 = "CgkI-LOTtu4VEAIQCQ";
			achievementID7 = "CgkI-LOTtu4VEAIQCg";
			break;
		case "WL":
			text = "CgkI-LOTtu4VEAIQAg";
			achievementID = "CgkI-LOTtu4VEAIQCw";
			achievementID2 = "CgkI-LOTtu4VEAIQDA";
			achievementID3 = "CgkI-LOTtu4VEAIQDQ";
			achievementID4 = "CgkI-LOTtu4VEAIQDg";
			achievementID5 = "CgkI-LOTtu4VEAIQDw";
			achievementID6 = "CgkI-LOTtu4VEAIQEA";
			achievementID7 = "CgkI-LOTtu4VEAIQEQ";
			break;
		case "WT":
			text = "CgkI-LOTtu4VEAIQAw";
			achievementID = "CgkI-LOTtu4VEAIQEg";
			achievementID2 = "CgkI-LOTtu4VEAIQEw";
			achievementID3 = "CgkI-LOTtu4VEAIQFA";
			achievementID4 = "CgkI-LOTtu4VEAIQFQ";
			achievementID5 = "CgkI-LOTtu4VEAIQFg";
			achievementID6 = "CgkI-LOTtu4VEAIQFw";
			achievementID7 = "CgkI-LOTtu4VEAIQGA";
			break;
		}
		switch (toggle)
		{
		case 0:
			break;
		case 1:
			switch (number)
			{
			case -2:
				if (PlayGamesPlatform.Instance.IsAuthenticated())
				{
					Social.localUser.Authenticate(delegate(bool success)
					{
						isAuthenticated = success;
					});
				}
				break;
			case -1:
			{
				PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().Build();
				PlayGamesPlatform.InitializeInstance(configuration);
				PlayGamesPlatform.DebugLogEnabled = true;
				PlayGamesPlatform.Activate();
				Social.localUser.Authenticate(delegate(bool success)
				{
					isAuthenticated = success;
				});
				break;
			}
			case 0:
				if (PlayGamesPlatform.Instance.IsAuthenticated())
				{
					PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboardId);
				}
				else
				{
					Social.localUser.Authenticate(delegate(bool success)
					{
						isAuthenticated = success;
					});
				}
				break;
			case 1:
				if (PlayGamesPlatform.Instance.IsAuthenticated())
				{
					PlayGamesPlatform.Instance.ShowLeaderboardUI(text);
				}
				else
				{
					Social.localUser.Authenticate(delegate(bool success)
					{
						isAuthenticated = success;
					});
				}
				break;
			case 2:
				if (PlayGamesPlatform.Instance.IsAuthenticated())
				{
					PlayGamesPlatform.Instance.ShowAchievementsUI();
				}
				else
				{
					Social.localUser.Authenticate(delegate(bool success)
					{
						isAuthenticated = success;
					});
				}
				break;
			}
			break;
		case 2:
			if (gameCenterMode < 2)
			{
				break;
			}
			switch (number)
			{
			case 0:
				Social.ReportScore(score, "CgkI-LOTtu4VEAIQAA", delegate
				{
				});
				Social.ReportScore(score, text, delegate
				{
				});
				break;
			case 1:
				if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage1") == 0)
				{
					Social.ReportProgress(achievementID2, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCstage1", 1);
				}
				break;
			case 2:
				if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage2") == 0)
				{
					Social.ReportProgress(achievementID3, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCstage2", 1);
				}
				break;
			case 3:
				if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage3") == 0)
				{
					Social.ReportProgress(achievementID4, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCstage3", 1);
				}
				break;
			case 4:
				if (PlayerPrefs.GetInt(selectedCharacterID + "GCstageGold") == 0)
				{
					Social.ReportProgress(achievementID5, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCstageGold", 1);
				}
				break;
			case 5:
				if (PlayerPrefs.GetInt(selectedCharacterID + "GCarena0") == 0)
				{
					Social.ReportProgress(achievementID6, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCarena0", 1);
				}
				break;
			case 6:
				if (PlayerPrefs.GetInt(selectedCharacterID + "GCarena0") == 0)
				{
					Social.ReportProgress(achievementID6, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCarena0", 1);
				}
				if (PlayerPrefs.GetInt(selectedCharacterID + "GCarena1") == 0)
				{
					Social.ReportProgress(achievementID7, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCarena1", 1);
				}
				break;
			case 7:
				if (PlayerPrefs.GetInt(selectedCharacterID + "GCunlock") == 0)
				{
					Social.ReportProgress(achievementID, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCunlock", 1);
				}
				break;
			case 8:
				if (PlayerPrefs.GetInt("GCallBooks") == 0)
				{
					Social.ReportProgress("CgkI-LOTtu4VEAIQGQ", 100.0, delegate
					{
					});
					PlayerPrefs.SetInt("GCallBooks", 1);
				}
				break;
			}
			break;
		case 3:
			if (gameCenterMode < 3)
			{
				break;
			}
			switch (number)
			{
			case 0:
				for (int i = 0; i < CharacterData.Length; i++)
				{
					if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") > 17)
					{
						Social.ReportProgress(achievementID2, 100.0, delegate
						{
						});
						Social.ReportProgress(achievementID3, 100.0, delegate
						{
						});
						Social.ReportProgress(achievementID4, 100.0, delegate
						{
						});
					}
					else if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") <= 17)
					{
						if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") > 5 && PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") <= 11)
						{
							Social.ReportProgress(achievementID2, 100.0, delegate
							{
							});
						}
						else if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") > 11)
						{
							Social.ReportProgress(achievementID2, 100.0, delegate
							{
							});
							Social.ReportProgress(achievementID3, 100.0, delegate
							{
							});
						}
					}
					if (PlayerPrefs.GetInt(CharacterData[i].characterID + "completionPercent") >= 100)
					{
						Social.ReportProgress(achievementID5, 100.0, delegate
						{
						});
					}
					if (PlayerPrefs.GetInt(CharacterData[i].characterID + "bestWaveRecord0") >= 12)
					{
					}
					if (PlayerPrefs.GetInt(CharacterData[i].characterID + "bestWaveRecord0") >= 24)
					{
					}
				}
				break;
			case 1:
				if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") > 17)
				{
					if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage1") == 0)
					{
						Social.ReportProgress(achievementID2, 100.0, delegate
						{
						});
						PlayerPrefs.SetInt(selectedCharacterID + "GCstage1", 1);
					}
					if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage2") == 0)
					{
						Social.ReportProgress(achievementID3, 100.0, delegate
						{
						});
						PlayerPrefs.SetInt(selectedCharacterID + "GCstage2", 1);
					}
					if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage3") == 0)
					{
						Social.ReportProgress(achievementID4, 100.0, delegate
						{
						});
						PlayerPrefs.SetInt(selectedCharacterID + "GCstage3", 1);
					}
				}
				else if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") <= 17)
				{
					if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") > 5 && PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") <= 11)
					{
						if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage1") == 0)
						{
							Social.ReportProgress(achievementID2, 100.0, delegate
							{
							});
							PlayerPrefs.SetInt(selectedCharacterID + "GCstage1", 1);
						}
					}
					else if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") > 11)
					{
						if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage1") == 0)
						{
							Social.ReportProgress(achievementID2, 100.0, delegate
							{
							});
							PlayerPrefs.SetInt(selectedCharacterID + "GCstage1", 1);
						}
						if (PlayerPrefs.GetInt(selectedCharacterID + "GCstage2") == 0)
						{
							Social.ReportProgress(achievementID3, 100.0, delegate
							{
							});
							PlayerPrefs.SetInt(selectedCharacterID + "GCstage2", 1);
						}
					}
				}
				if (PlayerPrefs.GetInt(selectedCharacterID + "completionPercent") >= 100 && PlayerPrefs.GetInt(selectedCharacterID + "GCstageGold") == 0)
				{
					Social.ReportProgress(achievementID5, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCstageGold", 1);
				}
				if (PlayerPrefs.GetInt(selectedCharacterID + "bestWaveRecord0") >= 12 && PlayerPrefs.GetInt(selectedCharacterID + "GCarena0") == 0)
				{
					Social.ReportProgress(achievementID6, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCarena0", 1);
				}
				if (PlayerPrefs.GetInt(selectedCharacterID + "bestWaveRecord0") >= 24 && PlayerPrefs.GetInt(selectedCharacterID + "GCarena1") == 0)
				{
					Social.ReportProgress(achievementID7, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCarena1", 1);
				}
				if (selectedCharacterID == "WZ")
				{
					if (PlayerPrefs.GetInt("libraryIntro") == 1 && PlayerPrefs.GetInt("GCunlockWZ") == 0)
					{
						Social.ReportProgress("CgkI-LOTtu4VEAIQBA", 100.0, delegate
						{
						});
						PlayerPrefs.SetInt("GCunlockWZ", 1);
					}
				}
				else if (PlayerPrefs.GetInt(selectedCharacterID + "LOCK") == 1 && PlayerPrefs.GetInt(selectedCharacterID + "GCunlock") == 0)
				{
					Social.ReportProgress(achievementID, 100.0, delegate
					{
					});
					PlayerPrefs.SetInt(selectedCharacterID + "GCunlock", 1);
				}
				if (PlayerPrefs.GetInt("GCallBooks") == 0 && PlayerPrefs.GetInt("WZstoryUnlocks") == 1 && PlayerPrefs.GetInt("WLstoryUnlocks") == 1 && PlayerPrefs.GetInt("WTstoryUnlocks") == 1 && PlayerPrefs.GetInt("WZlevelProgress") >= gameMaximumLevel && PlayerPrefs.GetInt("WLlevelProgress") >= gameMaximumLevel && PlayerPrefs.GetInt("WTlevelProgress") >= gameMaximumLevel)
				{
					Social.ReportProgress("CgkI-LOTtu4VEAIQGQ", 100.0, delegate
					{
					});
					PlayerPrefs.SetInt("GCallBooks", 1);
				}
				break;
			}
			break;
		}
	}

	public void InAppPurchuse(int toggle, int number)
	{
	}

	public void GameAnalytics(string eventName, float eventValue)
	{
		switch (gameAnalyticsMode)
		{
		case 0:
			break;
		case 1:
			if (eventValue != 0f)
			{
			}
			break;
		case 2:
			if ((bool)GoogleAnalytics.instance)
			{
				GoogleAnalytics.instance.LogScreen(selectedCharacterID + ":" + eventName);
			}
			break;
		case 3:
			if (eventValue == 0f)
			{
			}
			if ((bool)GoogleAnalytics.instance)
			{
				GoogleAnalytics.instance.LogScreen(selectedCharacterID + ":" + eventName);
			}
			break;
		}
	}

	public void GameAnalytics2(string eventName, float eventValue)
	{
		switch (gameAnalyticsMode)
		{
		case 0:
			break;
		case 1:
			if (eventValue != 0f)
			{
			}
			break;
		case 2:
			if ((bool)GoogleAnalytics.instance)
			{
				GoogleAnalytics.instance.LogScreen(eventName);
			}
			break;
		case 3:
			if (eventValue == 0f)
			{
			}
			if ((bool)GoogleAnalytics.instance)
			{
				GoogleAnalytics.instance.LogScreen(eventName);
			}
			break;
		}
	}

	private void GameStageLevelSetup()
	{
		if (gameMode != 2)
		{
			if (gameLevel <= gameLevelPerStage - 1)
			{
				gameStage = 0;
			}
			else if (gameLevel > gameLevelPerStage - 1 && gameLevel <= gameLevelPerStage * 2 - 1)
			{
				gameStage = 1;
			}
			else if (gameLevel > gameLevelPerStage * 2 - 1)
			{
				gameStage = 2;
			}
		}
		else
		{
			gameStage = 3;
		}
	}

	public void TutorialOption(int tutorialMode)
	{
		PlayerPrefs.SetInt("gameTutorialMode", tutorialMode);
		gameTutorialMode = PlayerPrefs.GetInt("gameTutorialMode");
	}

	public void SoundOption(int SoundMode)
	{
		if (soundMode != SoundMode)
		{
			switch (SoundMode)
			{
			case 0:
				AudioListener.pause = false;
				break;
			case 1:
				AudioListener.pause = false;
				break;
			case 2:
				AudioListener.pause = true;
				break;
			}
			if (SoundMode > 2)
			{
				AudioListener.pause = false;
				SoundMode = 0;
				soundMode = 0;
			}
			PlayerPrefs.SetInt("soundMode", SoundMode);
			soundMode = PlayerPrefs.GetInt("soundMode");
		}
	}

	public void PlayerKey(int amount)
	{
		playerKey += amount;
		if (playerKey > playerKeyLimit)
		{
			playerKey = playerKeyLimit;
		}
		else if (playerKey < 0)
		{
			playerKey = 0;
		}
		PlayerPrefs.SetInt("playerKey", playerKey);
		playerKey = PlayerPrefs.GetInt("playerKey");
	}

	public void PlayerCurrency(int amount)
	{
		playerCurrency += amount;
		if (playerCurrency > playerCurrencyLimit)
		{
			playerCurrency = playerCurrencyLimit;
		}
		else if (playerCurrency < 0)
		{
			playerCurrency = 0;
		}
		PlayerPrefs.SetInt("playerCurrency", playerCurrency);
		playerCurrency = PlayerPrefs.GetInt("playerCurrency");
		JCloudData.SetInt("playerCurrency", PlayerPrefs.GetInt("playerCurrency"));
		JCloudData.Save();
	}

	public void characterUnlock(string ID)
	{
		for (int i = 0; i < CharacterData.Length; i++)
		{
			if (ID == CharacterData[i].characterID)
			{
				ID_character = CharacterData[i].characterID;
				PlayerPrefs.SetInt(ID_character + "LOCK", 1);
				ID_character = string.Empty;
				i = CharacterData.Length;
			}
		}
	}

	public void characterLock(string ID)
	{
		for (int i = 0; i < CharacterData.Length; i++)
		{
			if (ID == CharacterData[i].characterID)
			{
				ID_character = CharacterData[i].characterID;
				PlayerPrefs.SetInt(ID_character + "LOCK", 0);
				ID_character = string.Empty;
				i = CharacterData.Length;
			}
		}
	}

	public void GameDataLoad()
	{
		PlayerPrefs.SetInt("WZLOCK", 1);
		playerCurrency = PlayerPrefs.GetInt("playerCurrency");
		playerKey = PlayerPrefs.GetInt("playerKey");
		for (int i = 0; i < CharacterData.Length; i++)
		{
			if (CharacterData[i].characterID != string.Empty)
			{
				instCharacter = PoolManager.Pools["Character Pool"].Spawn(CharacterData[i].characterObject.transform, Vector3.zero, CharacterData[i].characterObject.transform.rotation);
				CharacterData[i].characterObjectInst = instCharacter.gameObject;
				ID_character = CharacterData[i].characterID;
				CharacterDataUpdate(i, CharacterData[i].characterID);
				ID_character = string.Empty;
			}
		}
		ChallengeDataLoad();
	}

	public void GameDataErase()
	{
		for (int i = 0; i < CharacterData.Length; i++)
		{
			CharacterDataErase(CharacterData[i].characterID, 1);
			CharacterDataUpdate(i, CharacterData[i].characterID);
		}
		ChallengeDataLoad();
		SelectCharacterUpdate(selectedCharacterID);
		ID_character = string.Empty;
	}

	public void CharacterDataLoad(string ID)
	{
		for (int i = 0; i < CharacterData.Length; i++)
		{
			if (ID == CharacterData[i].characterID)
			{
				ID_character = CharacterData[i].characterID;
				CharacterDataUpdate(i, CharacterData[i].characterID);
				i = CharacterData.Length;
			}
		}
		SelectCharacterUpdate(selectedCharacterID);
		ChallengeDataLoad();
		GameCenter(3, 1, 0);
		ID_character = string.Empty;
	}

	public void SelectCharacter(string ID)
	{
		if (ID == string.Empty)
		{
			ID = "WZ";
		}
		if (autoTutorialMode == 1)
		{
			if (ID == "WZ")
			{
				TutorialOption(0);
			}
			else
			{
				TutorialOption(1);
			}
		}
		for (int i = 0; i < CharacterData.Length; i++)
		{
			if (ID == CharacterData[i].characterID)
			{
				PoolManager.Pools["Character Pool"].DespawnAll();
				selectedCharacterID = ID;
				SelectCharacterUpdate(selectedCharacterID);
				Transform transform = PoolManager.Pools["Character Pool"].Spawn(CharacterData[i].characterObject.transform, Vector3.zero, CharacterData[i].characterObject.transform.rotation);
				transform.name = "Player Character";
				ScriptsManager.playerCharacter = transform.gameObject;
			}
		}
	}

	public void ChallengeDataLoad()
	{
		for (int i = 0; i < 3; i++)
		{
			ChallengeWaveRecord[i].recordName = string.Empty;
			ChallengeWaveRecord[i].recordNumber = 0;
			ChallengeWaveRecord[i].recordCharacter = string.Empty;
			ChallengeUnitRecord[i].recordName = string.Empty;
			ChallengeUnitRecord[i].recordNumber = 0;
			ChallengeUnitRecord[i].recordCharacter = string.Empty;
		}
		for (int j = 0; j < CharacterData.Length; j++)
		{
			for (int k = 0; k < CharacterData[j].bestWaveRecord.Length; k++)
			{
				if (CharacterData[j].bestWaveRecord[k] >= ChallengeWaveRecord[0].recordNumber)
				{
					ChallengeWaveRecord[2].recordName = ChallengeWaveRecord[1].recordName;
					ChallengeWaveRecord[2].recordNumber = ChallengeWaveRecord[1].recordNumber;
					ChallengeWaveRecord[2].recordCharacter = ChallengeWaveRecord[1].recordCharacter;
					ChallengeWaveRecord[1].recordName = ChallengeWaveRecord[0].recordName;
					ChallengeWaveRecord[1].recordNumber = ChallengeWaveRecord[0].recordNumber;
					ChallengeWaveRecord[1].recordCharacter = ChallengeWaveRecord[0].recordCharacter;
					ChallengeWaveRecord[0].recordName = PlayerPrefs.GetString(CharacterData[j].characterID + "bestWaveRecordName" + k);
					ChallengeWaveRecord[0].recordNumber = CharacterData[j].bestWaveRecord[k];
					ChallengeWaveRecord[0].recordCharacter = CharacterData[j].characterID;
				}
				else if (CharacterData[j].bestWaveRecord[k] >= ChallengeWaveRecord[1].recordNumber)
				{
					ChallengeWaveRecord[2].recordName = ChallengeWaveRecord[1].recordName;
					ChallengeWaveRecord[2].recordNumber = ChallengeWaveRecord[1].recordNumber;
					ChallengeWaveRecord[2].recordCharacter = ChallengeWaveRecord[1].recordCharacter;
					ChallengeWaveRecord[1].recordName = PlayerPrefs.GetString(CharacterData[j].characterID + "bestWaveRecordName" + k);
					ChallengeWaveRecord[1].recordNumber = CharacterData[j].bestWaveRecord[k];
					ChallengeWaveRecord[1].recordCharacter = CharacterData[j].characterID;
				}
				else if (CharacterData[j].bestWaveRecord[k] >= ChallengeWaveRecord[2].recordNumber)
				{
					ChallengeWaveRecord[2].recordName = PlayerPrefs.GetString(CharacterData[j].characterID + "bestWaveRecordName" + k);
					ChallengeWaveRecord[2].recordNumber = CharacterData[j].bestWaveRecord[k];
					ChallengeWaveRecord[2].recordCharacter = CharacterData[j].characterID;
				}
			}
		}
		for (int l = 0; l < CharacterData.Length; l++)
		{
			for (int m = 0; m < CharacterData[l].bestUnitRecord.Length; m++)
			{
				if (CharacterData[l].bestUnitRecord[m] >= ChallengeUnitRecord[0].recordNumber)
				{
					ChallengeUnitRecord[2].recordName = ChallengeUnitRecord[1].recordName;
					ChallengeUnitRecord[2].recordNumber = ChallengeUnitRecord[1].recordNumber;
					ChallengeUnitRecord[2].recordCharacter = ChallengeUnitRecord[1].recordCharacter;
					ChallengeUnitRecord[1].recordName = ChallengeUnitRecord[0].recordName;
					ChallengeUnitRecord[1].recordNumber = ChallengeUnitRecord[0].recordNumber;
					ChallengeUnitRecord[1].recordCharacter = ChallengeUnitRecord[0].recordCharacter;
					ChallengeUnitRecord[0].recordName = PlayerPrefs.GetString(CharacterData[l].characterID + "bestUnitRecordName" + m);
					ChallengeUnitRecord[0].recordNumber = CharacterData[l].bestUnitRecord[m];
					ChallengeUnitRecord[0].recordCharacter = CharacterData[l].characterID;
				}
				else if (CharacterData[l].bestUnitRecord[m] >= ChallengeUnitRecord[1].recordNumber)
				{
					ChallengeUnitRecord[2].recordName = ChallengeUnitRecord[1].recordName;
					ChallengeUnitRecord[2].recordNumber = ChallengeUnitRecord[1].recordNumber;
					ChallengeUnitRecord[2].recordCharacter = ChallengeUnitRecord[1].recordCharacter;
					ChallengeUnitRecord[1].recordName = PlayerPrefs.GetString(CharacterData[l].characterID + "bestUnitRecordName" + m);
					ChallengeUnitRecord[1].recordNumber = CharacterData[l].bestUnitRecord[m];
					ChallengeUnitRecord[1].recordCharacter = CharacterData[l].characterID;
				}
				else if (CharacterData[l].bestUnitRecord[m] >= ChallengeUnitRecord[2].recordNumber)
				{
					ChallengeUnitRecord[2].recordName = PlayerPrefs.GetString(CharacterData[l].characterID + "bestUnitRecordName" + m);
					ChallengeUnitRecord[2].recordNumber = CharacterData[l].bestUnitRecord[m];
					ChallengeUnitRecord[2].recordCharacter = CharacterData[l].characterID;
				}
			}
		}
		for (int n = 0; n < 3; n++)
		{
			if (ChallengeWaveRecord[n].recordNumber == 0)
			{
				ChallengeWaveRecord[n].recordName = "empty";
				ChallengeWaveRecord[n].recordNumber = 0;
				ChallengeWaveRecord[n].recordCharacter = "FS";
			}
			if (ChallengeUnitRecord[n].recordNumber == 0)
			{
				ChallengeUnitRecord[n].recordName = "empty";
				ChallengeUnitRecord[n].recordNumber = 0;
				ChallengeUnitRecord[n].recordCharacter = "FS";
			}
		}
	}

	public void CharacterDataUpdate(int i, string ID_character)
	{
		CharacterData[i].characterLOCK = PlayerPrefs.GetInt(ID_character + "LOCK");
		CharacterData[i].levelProgress = PlayerPrefs.GetInt(ID_character + "levelProgress");
		if (PlayerPrefs.GetInt("tutorialIntro") < 2 && PlayerPrefs.GetInt(ID_character + "levelProgress") > 5)
		{
			PlayerPrefs.SetInt("tutorialIntro", 1);
		}
		CharacterData[i].characterStoryUnlocks = PlayerPrefs.GetInt(ID_character + "storyUnlocks");
		CharacterData[i].characterNextBookUnlock = PlayerPrefs.GetInt(ID_character + "nextBookUnlock");
		CharacterData[i].characterName = CharacterData[i].characterObject.GetComponent<PlayerCharacterInfo>().characterName;
		PlayerPrefs.SetString(ID_character + "characterName", CharacterData[i].characterName);
		CharacterData[i].characterClass = CharacterData[i].characterObject.GetComponent<PlayerCharacterInfo>().characterClass;
		PlayerPrefs.SetString(ID_character + "characterClass", CharacterData[i].characterClass);
		for (int j = 0; j < CharacterData[i].levelRating.Length; j++)
		{
			CharacterData[i].levelRating[j] = PlayerPrefs.GetInt(ID_character + "levelRating" + j);
		}
		CharacterData[i].ratingBronze = PlayerPrefs.GetInt(ID_character + "ratingBronze");
		CharacterData[i].ratingSilver = PlayerPrefs.GetInt(ID_character + "ratingSilver");
		CharacterData[i].ratingGold = PlayerPrefs.GetInt(ID_character + "ratingGold");
		CharacterData[i].completionPercent = PlayerPrefs.GetInt(ID_character + "completionPercent");
		CharacterData[i].itemLock = PlayerPrefs.GetInt(ID_character + "itemLock");
		for (int k = 0; k < 3; k++)
		{
			CharacterData[i].bestWaveRecord[k] = PlayerPrefs.GetInt(ID_character + "bestWaveRecord" + k);
			CharacterData[i].bestUnitRecord[k] = PlayerPrefs.GetInt(ID_character + "bestUnitRecord" + k);
		}
		CharacterData[i].gameStoryAttempts = PlayerPrefs.GetInt(ID_character + "statStoryAttempts");
		CharacterData[i].gameStoryVictories = PlayerPrefs.GetInt(ID_character + "statStoryVictories");
		CharacterData[i].gameStoryDefeats = PlayerPrefs.GetInt(ID_character + "statStoryDefeats");
		if (CharacterData[i].gameStoryAttempts > 0)
		{
			PlayerPrefs.SetInt(ID_character + "statStoryVictoryRate", Mathf.RoundToInt(CharacterData[i].gameStoryVictories * 100 / CharacterData[i].gameStoryAttempts));
			CharacterData[i].gameStoryVictoryRate = PlayerPrefs.GetInt(ID_character + "statStoryVictoryRate");
		}
		else if (CharacterData[i].gameStoryAttempts == 0)
		{
			PlayerPrefs.SetInt(ID_character + "statStoryVictoryRate", 0);
			CharacterData[i].gameStoryVictoryRate = 0;
		}
		CharacterData[i].gameChallengeAttempts = PlayerPrefs.GetInt(ID_character + "statChallengeAttempts");
		CharacterData[i].gameChallengeStreak = PlayerPrefs.GetInt(ID_character + "statChallengeStreak");
		for (int l = 0; l < 4; l++)
		{
			CharacterData[i].gameSpellsCasted[l] = PlayerPrefs.GetInt(ID_character + "statSpellCasted" + l);
		}
		for (int m = 0; m < 3; m++)
		{
			CharacterData[i].gameItemRating[m] = "GI_none";
		}
		PlayerPrefs.SetInt(ID_character + "_GI_none", 0);
		for (int n = 1; n < 4; n++)
		{
			for (int num = 0; num < 20; num++)
			{
				if (PlayerPrefs.GetInt(ID_character + "_GI_" + n + "_" + num) >= PlayerPrefs.GetInt(ID_character + "_" + CharacterData[i].gameItemRating[0]))
				{
					CharacterData[i].gameItemRating[2] = CharacterData[i].gameItemRating[1];
					CharacterData[i].gameItemRating[1] = CharacterData[i].gameItemRating[0];
					CharacterData[i].gameItemRating[0] = "GI_" + n + "_" + num;
				}
				else if (PlayerPrefs.GetInt(ID_character + "_GI_" + n + "_" + num) >= PlayerPrefs.GetInt(ID_character + "_" + CharacterData[i].gameItemRating[1]))
				{
					CharacterData[i].gameItemRating[2] = CharacterData[i].gameItemRating[1];
					CharacterData[i].gameItemRating[1] = "GI_" + n + "_" + num;
				}
				else if (PlayerPrefs.GetInt(ID_character + "_GI_" + n + "_" + num) >= PlayerPrefs.GetInt(ID_character + "_" + CharacterData[i].gameItemRating[2]))
				{
					CharacterData[i].gameItemRating[2] = "GI_" + n + "_" + num;
				}
			}
		}
		for (int num2 = 0; num2 < 3; num2++)
		{
			if (0 >= PlayerPrefs.GetInt(ID_character + "_" + CharacterData[i].gameItemRating[num2]))
			{
				CharacterData[i].gameItemRating[num2] = "GI_none";
			}
		}
		for (int num3 = 0; num3 < 3; num3++)
		{
			PlayerPrefs.SetString(ID_character + "ItemRank" + num3, CharacterData[i].gameItemRating[num3]);
		}
	}

	public void SelectCharacterUpdate(string ID_character)
	{
		selectedCharacterName = PlayerPrefs.GetString(ID_character + "characterName");
		selectedCharacterClass = PlayerPrefs.GetString(ID_character + "characterClass");
		selectedCharacterLevelProgress = PlayerPrefs.GetInt(ID_character + "levelProgress");
		for (int i = 0; i < selectedCharacterLevelRating.Length; i++)
		{
			selectedCharacterLevelRating[i] = PlayerPrefs.GetInt(ID_character + "levelRating" + i);
		}
		selectedCharacterRatingBronze = PlayerPrefs.GetInt(ID_character + "ratingBronze");
		selectedCharacterRatingSilver = PlayerPrefs.GetInt(ID_character + "ratingSilver");
		selectedCharacterRatingGold = PlayerPrefs.GetInt(ID_character + "ratingGold");
		selectedCharacterCompletionPercent = PlayerPrefs.GetInt(ID_character + "completionPercent");
		for (int j = 0; j < 3; j++)
		{
			selectedCharacterBestWaveRecord[j] = PlayerPrefs.GetInt(ID_character + "bestWaveRecord" + j);
			selectedCharacterBestUnitRecord[j] = PlayerPrefs.GetInt(ID_character + "bestUnitRecord" + j);
		}
		PlayerPrefs.SetString("SelectedCharacter", ID_character);
		selectedCharacterStoryAttempts = PlayerPrefs.GetInt(ID_character + "statStoryAttempts");
		selectedCharacterStoryVictories = PlayerPrefs.GetInt(ID_character + "statStoryVictories");
		selectedCharacterStoryDefeats = PlayerPrefs.GetInt(ID_character + "statStoryDefeats");
		selectedCharacterStoryVictoryRate = PlayerPrefs.GetInt(ID_character + "statStoryVictoryRate");
		selectedCharacterChallengeAttempts = PlayerPrefs.GetInt(ID_character + "statChallengeAttempts");
		selectedCharacterChallengeStreak = PlayerPrefs.GetInt(ID_character + "statChallengeStreak");
		for (int k = 0; k < 4; k++)
		{
			selectedCharacterSpellsCasted[k] = PlayerPrefs.GetInt(ID_character + "statSpellCasted" + k);
		}
		for (int l = 0; l < 3; l++)
		{
			selectedCharacterItemRating[l] = PlayerPrefs.GetString(ID_character + "ItemRank" + l);
		}
	}

	public void CharacterDataErase(string ID, int confirm)
	{
		if (confirm == 1)
		{
			for (int i = 0; i < CharacterData.Length; i++)
			{
				if (!(ID == CharacterData[i].characterID))
				{
					continue;
				}
				ID_character = CharacterData[i].characterID;
				scriptCharacterData = CharacterData[i].characterObject.GetComponent<PlayerCharacterData>();
				PlayerPrefs.SetInt(ID_character + "storyUnlocks", 0);
				PlayerPrefs.SetInt(ID_character + "nextBookUnlock", 0);
				PlayerPrefs.SetInt(ID_character + "levelProgress", 0);
				PlayerPrefs.SetInt(selectedCharacterID + "GCunlock", 0);
				PlayerPrefs.SetInt(selectedCharacterID + "GCstage1", 0);
				PlayerPrefs.SetInt(selectedCharacterID + "GCstage2", 0);
				PlayerPrefs.SetInt(selectedCharacterID + "GCstage3", 0);
				PlayerPrefs.SetInt(selectedCharacterID + "GCstageGold", 0);
				PlayerPrefs.SetInt(selectedCharacterID + "GCarena0", 0);
				PlayerPrefs.SetInt(selectedCharacterID + "GCarena1", 0);
				for (int j = 0; j < CharacterData[i].levelRating.Length; j++)
				{
					PlayerPrefs.SetInt(ID_character + "levelRating" + j, 0);
				}
				PlayerPrefs.SetInt(ID_character + "ratingBronze", 0);
				PlayerPrefs.SetInt(ID_character + "ratingSilver", 0);
				PlayerPrefs.SetInt(ID_character + "ratingGold", 0);
				PlayerPrefs.SetInt(ID_character + "completionPercent", 0);
				for (int k = 0; k < 3; k++)
				{
					PlayerPrefs.SetInt(ID + "bestWaveRecord" + k, 0);
					PlayerPrefs.SetInt(ID + "bestUnitRecord" + k, 0);
					PlayerPrefs.SetString(ID + "bestWaveRecordName" + k, string.Empty);
					PlayerPrefs.SetString(ID + "bestUnitRecordName" + k, string.Empty);
					CharacterData[i].bestWaveRecord[k] = 0;
					CharacterData[i].bestUnitRecord[k] = 0;
				}
				PlayerPrefs.SetInt(ID_character + "statStoryAttempts", 0);
				PlayerPrefs.SetInt(ID_character + "statStoryVictories", 0);
				PlayerPrefs.SetInt(ID_character + "statStoryDefeats", 0);
				PlayerPrefs.SetInt(ID_character + "statChallengeAttempts", 0);
				PlayerPrefs.SetInt(ID_character + "statChallengeStreak", 0);
				for (int l = 0; l < 4; l++)
				{
					PlayerPrefs.SetInt(ID_character + "statSpellCasted" + l, 0);
				}
				for (int m = 1; m < 4; m++)
				{
					for (int n = 0; n < 20; n++)
					{
						PlayerPrefs.SetInt(ID_character + "_GI_" + m + "_" + n, 0);
					}
				}
				for (int num = 0; num < 3; num++)
				{
					PlayerPrefs.SetString(ID_character + "ItemRank" + num, "GI_none");
				}
				selectedCharacterLevelProgress = PlayerPrefs.GetInt(ID + "levelProgress");
				for (int num2 = 0; num2 < selectedCharacterLevelRating.Length; num2++)
				{
					selectedCharacterLevelRating[num2] = PlayerPrefs.GetInt(ID + "levelRating" + num2);
				}
				for (int num3 = 0; num3 < scriptCharacterData.ItemUnlockID.Length; num3++)
				{
					PlayerPrefs.SetInt(scriptCharacterData.ItemUnlockID[num3].itemID + "itemLock", 0);
					scriptCharacterData.ItemUnlockID[num3].itemState = 0;
				}
				CharacterDataUpdate(i, ID_character);
				i = CharacterData.Length;
			}
		}
		ChallengeDataLoad();
		SelectCharacterUpdate(selectedCharacterID);
		ID_character = string.Empty;
	}

	public void CharacterTestCompletion(string ID_character)
	{
		PlayerPrefs.SetInt(ID_character + "levelProgress", 18);
		for (int i = 0; i < 18; i++)
		{
			PlayerPrefs.SetInt(ID_character + "levelRating" + i, 1);
		}
		PlayerPrefs.SetInt(ID_character + "ratingBronze", 18);
		PlayerPrefs.SetInt(ID_character + "ratingSilver", 0);
		PlayerPrefs.SetInt(ID_character + "ratingGold", 0);
		PlayerPrefs.SetInt(ID_character + "completionPercent", 33);
		PlayerPrefs.SetInt(ID_character + "statStoryAttempts", 18);
		PlayerPrefs.SetInt(ID_character + "statStoryVictories", 18);
		PlayerPrefs.SetInt(ID_character + "statStoryDefeats", 0);
		PlayerPrefs.SetInt(ID_character + "statChallengeAttempts", 0);
		PlayerPrefs.SetInt(ID_character + "statChallengeStreak", 0);
		for (int j = 0; j < CharacterData.Length; j++)
		{
			if (CharacterData[j].characterID == ID_character)
			{
				CharacterDataUpdate(j, ID_character);
			}
		}
		ChallengeDataLoad();
	}

	public void GameStart(int mode, int state)
	{
		switch (mode)
		{
		case 0:
			switch (state)
			{
			case 2:
				break;
			case 0:
				PlayerPrefs.SetInt(selectedCharacterID + "statStoryAttempts", PlayerPrefs.GetInt(selectedCharacterID + "statStoryAttempts") + 1);
				PlayerPrefs.SetInt(selectedCharacterID + "statStoryDefeats", PlayerPrefs.GetInt(selectedCharacterID + "statStoryDefeats") + 1);
				break;
			case 1:
				PlayerPrefs.SetInt(selectedCharacterID + "statStoryVictories", PlayerPrefs.GetInt(selectedCharacterID + "statStoryVictories") + 1);
				PlayerPrefs.SetInt(selectedCharacterID + "statStoryDefeats", PlayerPrefs.GetInt(selectedCharacterID + "statStoryDefeats") - 1);
				break;
			}
			break;
		case 1:
			switch (state)
			{
			case 2:
				break;
			case 0:
				PlayerPrefs.SetInt(selectedCharacterID + "statChallengeAttempts", PlayerPrefs.GetInt(selectedCharacterID + "statChallengeAttempts") + 1);
				PlayerPrefs.SetInt(selectedCharacterID + "statChallengeStreak", PlayerPrefs.GetInt(selectedCharacterID + "statChallengeStreak") + 1);
				break;
			case 1:
				PlayerPrefs.SetInt(selectedCharacterID + "statChallengeStreak", 0);
				break;
			}
			break;
		}
	}

	public void CharacterLevelSave(string ID, int currentLevel, int currentLevelRating)
	{
		for (int i = 0; i < CharacterData.Length; i++)
		{
			if (!(ID == CharacterData[i].characterID))
			{
				continue;
			}
			ID_character = CharacterData[i].characterID;
			if (currentLevel + 1 > PlayerPrefs.GetInt(ID_character + "levelProgress"))
			{
				PlayerPrefs.SetInt(ID_character + "levelProgress", currentLevel + 1);
			}
			if (currentLevelRating > PlayerPrefs.GetInt(ID_character + "levelRating" + currentLevel))
			{
				PlayerPrefs.SetInt(ID_character + "levelRating" + currentLevel, currentLevelRating);
			}
			CharacterData[i].ratingBronze = 0;
			CharacterData[i].ratingSilver = 0;
			CharacterData[i].ratingGold = 0;
			for (int j = 0; j < CharacterData[i].levelRating.Length; j++)
			{
				CharacterData[i].levelRating[j] = PlayerPrefs.GetInt(ID_character + "levelRating" + j);
				switch (CharacterData[i].levelRating[j])
				{
				case 1:
					CharacterData[i].ratingBronze++;
					break;
				case 2:
					CharacterData[i].ratingSilver++;
					break;
				case 3:
					CharacterData[i].ratingGold++;
					break;
				}
			}
			CharacterData[i].completionPercent = Mathf.RoundToInt((float)(CharacterData[i].ratingBronze * 1 + CharacterData[i].ratingSilver * 2 + CharacterData[i].ratingGold * 3) * 100f) / (CharacterData[i].levelRating.Length * 3);
			PlayerPrefs.SetInt(ID_character + "ratingBronze", CharacterData[i].ratingBronze);
			PlayerPrefs.SetInt(ID_character + "ratingSilver", CharacterData[i].ratingSilver);
			PlayerPrefs.SetInt(ID_character + "ratingGold", CharacterData[i].ratingGold);
			PlayerPrefs.SetInt(ID_character + "completionPercent", CharacterData[i].completionPercent);
			CharacterDataUpdate(i, ID_character);
			i = CharacterData.Length;
		}
		ID_character = string.Empty;
		SelectCharacterUpdate(selectedCharacterID);
	}

	public void CharacterChallengeSave(string ID, int waveAmount, int unitAmount)
	{
		for (int i = 0; i < CharacterData.Length; i++)
		{
			if (!(ID == CharacterData[i].characterID))
			{
				continue;
			}
			ID_character = CharacterData[i].characterID;
			if (waveAmount > 0)
			{
				for (int j = 0; j < CharacterData[i].bestWaveRecord.Length; j++)
				{
					if (waveAmount >= CharacterData[i].bestWaveRecord[j])
					{
						GameStart(1, 1);
						switch (j)
						{
						case 0:
							PlayerPrefs.SetString(ID + "bestWaveRecordName2", PlayerPrefs.GetString(ID + "bestWaveRecordName1"));
							CharacterData[i].bestWaveRecord[2] = CharacterData[i].bestWaveRecord[1];
							PlayerPrefs.SetString(ID + "bestWaveRecordName1", PlayerPrefs.GetString(ID + "bestWaveRecordName0"));
							CharacterData[i].bestWaveRecord[1] = CharacterData[i].bestWaveRecord[0];
							break;
						case 1:
							PlayerPrefs.SetString(ID + "bestWaveRecordName2", PlayerPrefs.GetString(ID + "bestWaveRecordName1"));
							CharacterData[i].bestWaveRecord[2] = CharacterData[i].bestWaveRecord[1];
							break;
						}
						CharacterData[i].bestWaveRecord[j] = waveAmount;
						PlayerPrefs.SetString(ID + "bestWaveRecordName" + j, PlayerPrefs.GetString(ID + "characterName"));
						j = CharacterData[i].bestWaveRecord.Length;
					}
				}
			}
			if (unitAmount > 0)
			{
				for (int k = 0; k < CharacterData[i].bestUnitRecord.Length; k++)
				{
					if (unitAmount >= CharacterData[i].bestUnitRecord[k])
					{
						GameStart(1, 1);
						switch (k)
						{
						case 0:
							PlayerPrefs.SetString(ID + "bestUnitRecordName2", PlayerPrefs.GetString(ID + "bestUnitRecordName1"));
							CharacterData[i].bestUnitRecord[2] = CharacterData[i].bestUnitRecord[1];
							PlayerPrefs.SetString(ID + "bestUnitRecordName1", PlayerPrefs.GetString(ID + "bestUnitRecordName0"));
							CharacterData[i].bestUnitRecord[1] = CharacterData[i].bestUnitRecord[0];
							break;
						case 1:
							PlayerPrefs.SetString(ID + "bestUnitRecordName2", PlayerPrefs.GetString(ID + "bestUnitRecordName1"));
							CharacterData[i].bestUnitRecord[2] = CharacterData[i].bestUnitRecord[1];
							break;
						}
						PlayerPrefs.SetString(ID + "bestUnitRecordName" + k, PlayerPrefs.GetString(ID + "characterName"));
						CharacterData[i].bestUnitRecord[k] = unitAmount;
						k = CharacterData[i].bestUnitRecord.Length;
					}
				}
			}
			for (int l = 0; l < 3; l++)
			{
				PlayerPrefs.SetInt(ID + "bestWaveRecord" + l, CharacterData[i].bestWaveRecord[l]);
				PlayerPrefs.SetInt(ID + "bestUnitRecord" + l, CharacterData[i].bestUnitRecord[l]);
			}
			for (int m = 0; m < 3; m++)
			{
				CharacterData[i].bestWaveRecord[m] = PlayerPrefs.GetInt(ID + "bestWaveRecord" + m);
				CharacterData[i].bestUnitRecord[m] = PlayerPrefs.GetInt(ID + "bestUnitRecord" + m);
				selectedCharacterBestWaveRecord[m] = PlayerPrefs.GetInt(ID + "bestWaveRecord" + m);
				selectedCharacterBestUnitRecord[m] = PlayerPrefs.GetInt(ID + "bestUnitRecord" + m);
			}
			i = CharacterData.Length;
		}
		ID_character = string.Empty;
		SelectCharacterUpdate(selectedCharacterID);
		ChallengeDataLoad();
	}
}
