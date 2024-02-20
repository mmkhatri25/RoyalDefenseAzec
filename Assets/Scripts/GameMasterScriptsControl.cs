using UnityEngine;

public class GameMasterScriptsControl : MonoBehaviour
{
	public GameObject healthIndicator;

	public int state;

	public int playerCurrency;

	public int iapMode;

	public int saveMode;

	public int debugMode;

	public int tutorialMode;

	public int gameMode;

	public int gameLevel;

	public int gameStage;

	public int gameLevelPerStage;

	public int gameMaximumLevel;

	public int[] characterUnlock = new int[4];

	public int characterCompletionPercent;

	public int soundMode;

	public string characterID;

	public float stageLength;

	public int stageTrackA;

	public int stageTrackB;

	public int bossTrack;

	private Game_Data dataScript;

	private Stage_Control stageControlScript;

	private Object_Logic objectLogicScript;

	private Content_Data contentDataScript;

	private level_setup levelSetup;

	public MenuTransition scriptLoadTransition;

	public static PlayerAnimationSet characterAnimationScript;

	private void Awake()
	{
		base.useGUILayout = false;
		switch (state)
		{
		case 0:
			dataScript = ScriptsManager.dataScript;
			contentDataScript = ScriptsManager.contentDataScript;
			levelSetup = ScriptsManager.levelSetupScript;
			stageControlScript = ScriptsManager.stageControlScript;
			objectLogicScript = ScriptsManager.objectLogicScript;
			characterAnimationScript = ScriptsManager.playerCharacter.GetComponent<PlayerAnimationSet>();
			Object.Instantiate(ScriptsManager.playerCharacter.GetComponent<PlayerCharacterData>().characterGuardLogic, Vector3.zero, Quaternion.identity);
			characterUnlock[0] = ScriptsManager.levelSetupScript.ItemUnlockID[0].itemState;
			characterUnlock[1] = ScriptsManager.levelSetupScript.ItemUnlockID[1].itemState;
			characterUnlock[2] = ScriptsManager.levelSetupScript.ItemUnlockID[2].itemState;
			characterUnlock[3] = ScriptsManager.levelSetupScript.ItemUnlockID[3].itemState;
			characterCompletionPercent = dataScript.selectedCharacterCompletionPercent;
			playerCurrency = dataScript.playerCurrency;
			if (dataScript.gameMode != 2)
			{
				iapMode = dataScript.iapMode;
			}
			else
			{
				iapMode = 0;
			}
			saveMode = dataScript.saveMode;
			debugMode = dataScript.debugMode;
			tutorialMode = dataScript.gameTutorialMode;
			gameMode = dataScript.gameMode;
			gameLevel = dataScript.gameLevel;
			gameStage = dataScript.gameStage;
			gameLevelPerStage = dataScript.gameLevelPerStage;
			gameMaximumLevel = dataScript.gameMaximumLevel;
			characterID = dataScript.selectedCharacterID;
			soundMode = dataScript.soundMode;
			stageLength = ScriptsManager.stageControlScript.StageInfo[gameStage].additionStageLength;
			stageTrackA = stageControlScript.StageInfo[gameStage].stageMusicTrackA;
			stageTrackB = stageControlScript.StageInfo[gameStage].stageMusicTrackB;
			bossTrack = levelSetup.BossSpeech[gameLevel].musicTrackNumber;
			break;
		}
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			if (playerCurrency != dataScript.playerCurrency)
			{
				playerCurrency = dataScript.playerCurrency;
			}
			if (dataScript.gameMode != gameMode)
			{
				dataScript.gameMode = gameMode;
			}
			if (gameMode != 2)
			{
				if (dataScript.gameLevel != gameLevel)
				{
					dataScript.gameLevel = gameLevel;
				}
				if (gameStage != dataScript.gameStage)
				{
					gameStage = dataScript.gameStage;
				}
				if (bossTrack != levelSetup.BossSpeech[gameLevel].musicTrackNumber)
				{
					bossTrack = levelSetup.BossSpeech[gameLevel].musicTrackNumber;
				}
			}
			if (characterCompletionPercent != dataScript.selectedCharacterCompletionPercent)
			{
				characterCompletionPercent = dataScript.selectedCharacterCompletionPercent;
			}
			if (soundMode == 2 && !Camera.main.GetComponent<AudioSource>().mute)
			{
				GameScriptsManager.audioSourceA.mute = true;
				GameScriptsManager.audioSourceB.mute = true;
				GameScriptsManager.audioSourceC.mute = true;
				Camera.main.GetComponent<AudioSource>().mute = true;
			}
			break;
		}
	}

	public void GameCenter(int toggle, int number, int score)
	{
		if (dataScript != null)
		{
			dataScript.GameCenter(toggle, number, score);
		}
	}

	public void Currency(int amount)
	{
		if (dataScript != null)
		{
			dataScript.PlayerCurrency(amount);
			print("currency is now  - "+ playerCurrency);
		}
		else
		{
			playerCurrency += amount;
		}
	}

	public void GameStart(int mode, int type)
	{
		if (saveMode == 0)
		{
			dataScript.GameStart(mode, type);
		}
	}

	public void CharacterChallengeSave(int waveAmount, int unitAmount)
	{
		if (saveMode == 0)
		{
			dataScript.CharacterChallengeSave(characterID, waveAmount, unitAmount);
		}
	}

	public void CharacterLevelSave(int currentLevelRating)
	{
		if (saveMode == 0)
		{
			dataScript.GameStart(0, 1);
			dataScript.CharacterLevelSave(characterID, gameLevel, currentLevelRating);
		}
	}

	public void PlayStageMusic(int toggle)
	{
		if (soundMode == 0 && contentDataScript != null)
		{
			if (gameLevel % 2 == 0)
			{
				contentDataScript.PlayMusic(1, stageTrackA + toggle);
			}
			else if (gameLevel % 2 == 1)
			{
				contentDataScript.PlayMusic(1, stageTrackB + toggle);
			}
		}
	}

	public void PlayBossMusic(int toggle)
	{
		if (soundMode == 0 && contentDataScript != null)
		{
			contentDataScript.PlayMusic(2, bossTrack + toggle);
		}
	}

	public void PlayMusic(int musicType, int musicNumber)
	{
		if (soundMode == 0 && contentDataScript != null)
		{
			contentDataScript.PlayMusic(musicType, musicNumber);
		}
	}

	public void StageSetup(int stage, int preview)
	{
		if (stageControlScript != null)
		{
			if (stageControlScript.stageNumber != stage)
			{
				stageControlScript.stageNumber = stage;
				stageLength = ScriptsManager.stageControlScript.StageInfo[stage].additionStageLength;
			}
			if (stageControlScript.previewNumber != preview)
			{
				stageControlScript.previewNumber = preview;
			}
		}
	}

	public void CharacterDataLoad()
	{
		if (saveMode == 0)
		{
			dataScript.CharacterDataLoad(characterAnimationScript.characterID);
		}
	}

	public void ObjectLogicState(int state)
	{
		if (objectLogicScript != null)
		{
			objectLogicScript.state = state;
		}
	}

	public void LoadTransition(int transitionNumber)
	{
		if (scriptLoadTransition != null)
		{
			scriptLoadTransition.transitionNumber = transitionNumber;
		}
	}

	public void SceneLoadAfterUnlock(string sceneName)
	{
		if (levelSetup != null)
		{
			levelSetup.LoadScene = sceneName;
		}
	}
}
