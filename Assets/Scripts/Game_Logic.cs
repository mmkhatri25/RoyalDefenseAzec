using System;
using UnityEngine;

public class Game_Logic : MonoBehaviour
{
	public int gameState;

	private int TOGGLE_gameState = -100;

	public AudioClip accessClip;

	public int gameMode;

	public int gameWavesComplete;

	public int gameWaveNumber;

	public int gameWaveTier;

	public int gameLevel;

	public int gameStage;

	private HUD_Control scriptHudControl;

	private Camera_Control scriptCameraControl;

	private Game_Statistics scriptGameStatistic;

	private Statistic_Logic scriptStatisticLogic;

	private GameMasterScriptsControl scriptMasterControl;

	private float TIMER_gameAdvancementState;

	private int TOGGLE_gameAdvancementState = -1;

	private int TOGGLE_TutorialGameplayType = -1;

	private float TIMER_gameStateloading;

	private float DELAY_gameStateloading = 2f;

	private int TOGGLE_stageSetup;

	private float DELAY_stageSetup;

	private int TOGGLE_gameWave;

	private int TOGGLE_music;

	private int TOGGLE_musicPace;

	private int TOGGLE_gameReload;

    public Admobs admob;

	private void Start()
	{
		base.useGUILayout = false;
		Resources.UnloadUnusedAssets();
		GC.Collect();
		if (gameMode != -1)
		{
			scriptMasterControl = GameScriptsManager.masterControlScript;
			scriptHudControl = GameScriptsManager.hudControlcScript;
			scriptCameraControl = GameScriptsManager.cameraControlScript;
			scriptGameStatistic = GameScriptsManager.gameStatisticScript;
			gameMode = scriptMasterControl.gameMode;
			gameLevel = scriptMasterControl.gameLevel;
			gameStage = scriptMasterControl.gameStage;
		}
		CameraScreenTransition.control.Clear(-1);
        admob = GameObject.FindObjectOfType<Admobs>();
    }

	private void Update()
	{
		switch (gameMode)
		{
		case 0:
			if (scriptMasterControl.tutorialMode == 0)
			{
				GameAdvancement();
			}
			NormalModeFunction();
			break;
		case 1:
			TutorialModeFunction();
			break;
		case 2:
			ChallengeModeFunction();
			break;
		}
	}

	private void GameAdvancement()
	{
		if (gameState != 2 && TOGGLE_gameAdvancementState != -1)
		{
			TOGGLE_gameAdvancementState = -1;
		}
		int num = gameState;
		if (num != 2)
		{
			return;
		}
		switch (gameLevel)
		{
		case 0:
			if (TOGGLE_gameAdvancementState != gameState)
			{
				GameScriptsManager.itemControlScript.ItemTutorialEquipFunction(1);
				TIMER_gameAdvancementState = Time.time + 1f;
				TOGGLE_gameAdvancementState = gameState;
			}
			if (TIMER_gameAdvancementState != 0f && Time.time >= TIMER_gameAdvancementState)
			{
				scriptHudControl.hintNumber = 5;
				scriptHudControl.state = 9;
				TIMER_gameAdvancementState = 0f;
			}
			break;
		case 1:
			if (TOGGLE_gameAdvancementState != gameState)
			{
				GameScriptsManager.itemControlScript.ItemTutorialEquipFunction(1);
				TIMER_gameAdvancementState = Time.time + 1f;
				TOGGLE_gameAdvancementState = gameState;
			}
			if (TIMER_gameAdvancementState != 0f && Time.time >= TIMER_gameAdvancementState)
			{
				scriptHudControl.hintNumber = 7;
				scriptHudControl.state = 9;
				TIMER_gameAdvancementState = 0f;
			}
			break;
		case 2:
			if (TOGGLE_gameAdvancementState != gameState)
			{
				GameScriptsManager.itemControlScript.ItemTutorialEquipFunction(1);
				scriptHudControl.hintNumber = 8;
				TIMER_gameAdvancementState = Time.time + 1f;
				TOGGLE_gameAdvancementState = gameState;
			}
			if (TIMER_gameAdvancementState != 0f && Time.time >= TIMER_gameAdvancementState)
			{
				scriptHudControl.state = 9;
				TIMER_gameAdvancementState = 0f;
			}
			break;
		case 3:
			if (TOGGLE_gameAdvancementState != gameState)
			{
				GameScriptsManager.itemControlScript.ItemTutorialEquipFunction(1);
				scriptHudControl.hintNumber = 9;
				TIMER_gameAdvancementState = Time.time + 1f;
				TOGGLE_gameAdvancementState = gameState;
			}
			if (TIMER_gameAdvancementState != 0f && Time.time >= TIMER_gameAdvancementState)
			{
				scriptHudControl.state = 9;
				TIMER_gameAdvancementState = 0f;
			}
			break;
		case 4:
			if (TOGGLE_gameAdvancementState != gameState)
			{
				GameScriptsManager.itemControlScript.ItemClear();
				TIMER_gameAdvancementState = Time.time + 1f;
				TOGGLE_gameAdvancementState = gameState;
			}
			if (TIMER_gameAdvancementState != 0f && Time.time >= TIMER_gameAdvancementState)
			{
				scriptHudControl.hintNumber = 10;
				scriptHudControl.state = 9;
				TIMER_gameAdvancementState = 0f;
			}
			break;
		}
		if (scriptHudControl.shopState != 0 && gameLevel < 4)
		{
			scriptHudControl.shopState = 0;
		}
	}

	private void TutorialModeFunction()
	{
		switch (gameState)
		{
		case 3:
		case 4:
			break;
		case -1:
			scriptMasterControl.PlayMusic(0, 0);
			gameState++;
			break;
		case 0:
			GameStateStartLoading();
			break;
		case 1:
			TutorialSpeech();
			break;
		case 2:
			TutorialGameplay(gameWaveNumber);
			break;
		case 5:
			scriptHudControl.mode = 0;
			gameMode = 0;
			break;
		}
	}

	private void TutorialSpeech()
	{
		if (TOGGLE_gameState != gameState)
		{
			scriptGameStatistic.state = 0;
			scriptHudControl.state = 1;
			scriptCameraControl.state = 4;
			TOGGLE_gameState = gameState;
		}
		TutorialButtonFunction(0);
	}

	private void TutorialGameplay(int type)
	{
		if (TOGGLE_gameState != gameState)
		{
			scriptHudControl.state = 4;
			TOGGLE_gameState = gameState;
		}
		switch (type)
		{
		case 1:
			if (TOGGLE_TutorialGameplayType != type)
			{
				scriptCameraControl.state = 4;
				scriptGameStatistic.state = 1;
				TOGGLE_TutorialGameplayType = type;
			}
			break;
		case 2:
			if (TOGGLE_TutorialGameplayType != type)
			{
				scriptCameraControl.state = 4;
				scriptGameStatistic.state = 1;
				scriptGameStatistic.objectState = -1;
				TOGGLE_TutorialGameplayType = type;
			}
			if (Time.timeScale != 0f)
			{
				scriptHudControl.manaDisplayState = 1;
			}
			break;
		case 3:
			if (TOGGLE_TutorialGameplayType != type)
			{
				GameScriptsManager.spellLogicScript.spellState = 1;
				scriptCameraControl.state = 2;
				scriptGameStatistic.state = 1;
				TOGGLE_TutorialGameplayType = type;
			}
			if (Time.timeScale != 0f)
			{
				scriptHudControl.manaDisplayState = 1;
				scriptHudControl.spellButtonState = 1;
			}
			break;
		case 4:
			if (TOGGLE_TutorialGameplayType != type)
			{
				scriptCameraControl.state = 4;
				scriptGameStatistic.state = 1;
				scriptGameStatistic.objectState = -1;
				TOGGLE_TutorialGameplayType = type;
			}
			if (Time.timeScale != 0f)
			{
				scriptHudControl.manaDisplayState = 1;
				scriptHudControl.itemButtonState = 1;
			}
			break;
		case 5:
			scriptGameStatistic.manaRecoverAmount = 0;
			scriptHudControl.state = 0;
			scriptHudControl.mode = 0;
			scriptMasterControl.gameMode = 0;
			gameMode = 0;
			gameState = 1;
			break;
		}
		TutorialButtonFunction(0);
	}

	private void TutorialButtonFunction(int type)
	{
		switch (type)
		{
		case 0:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray2 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray2, out RaycastHit hitInfo2))
			{
				if (hitInfo2.collider.transform.name == "BTN_RESTART")
				{
					scriptHudControl.state = 1;
					ButtonLoadFunctions(0);
				}
				if (hitInfo2.collider.transform.name == "BTN_MENU")
				{
					scriptHudControl.state = 1;
					ButtonLoadFunctions(1);
				}
			}
			break;
		}
		case 1:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hitInfo))
			{
				if (hitInfo.collider.transform.name == "BTN_RESTART")
				{
					scriptHudControl.state = 2;
					ButtonLoadFunctions(0);
				}
				if (hitInfo.collider.transform.name == "BTN_MENU")
				{
					scriptHudControl.state = 2;
					ButtonLoadFunctions(1);
				}
			}
			break;
		}
		}
	}

	private void NormalModeFunction()
	{
		switch (gameState)
		{
		case -1:
			GameStateStartLoading();
			break;
		case 0:
			GameStateLoading();
			break;
		case 1:
			GameStateIntroduction();
			break;
		case 2:
			GameStateGameplay();
			break;
		case 3:
			GameStateVictoryStatisticSave();
			break;
		case 4:
			GameStateVictory();
			break;
		case 5:
			GameStateDefeatStatisticSave();
			break;
		case 6:
			GameStateDefeat();
			break;
		}
	}

	private void ChallengeModeFunction()
	{
		switch (gameState)
		{
		case -1:
			if (TOGGLE_gameState != gameState)
			{
				TIMER_gameStateloading = Time.time + DELAY_gameStateloading;
				scriptHudControl.state = 0;
				scriptCameraControl.state = -1;
				scriptMasterControl.StageSetup(3, 18);
				TOGGLE_gameState = gameState;
			}
			if (Time.time >= TIMER_gameStateloading)
			{
				Resources.UnloadUnusedAssets();
				GC.Collect();
				scriptGameStatistic.StatusReset();
				gameState = 1;
			}
			gameWaveNumber = 1;
			break;
		case 0:
			if (TOGGLE_gameState != gameState)
			{
				gameLevel++;
				TOGGLE_stageSetup = 0;
				DELAY_stageSetup = Time.time + DELAY_gameStateloading / 2f;
				scriptMasterControl.gameLevel++;
				scriptGameStatistic.StatusReset();
				TIMER_gameStateloading = Time.time + DELAY_gameStateloading;
				scriptHudControl.state = 0;
				scriptCameraControl.state = 0;
				Resources.UnloadUnusedAssets();
				GC.Collect();
				TOGGLE_gameState = gameState;
			}
			gameLevel = scriptMasterControl.gameLevel;
			gameWaveNumber = 1;
			gameWavesComplete = 0;
			if (Time.time >= DELAY_stageSetup && TOGGLE_stageSetup != 1)
			{
				scriptMasterControl.ObjectLogicState(0);
				TOGGLE_stageSetup = 1;
			}
			if (Time.time >= TIMER_gameStateloading)
			{
				gameState = 1;
			}
			break;
		case 1:
			if (TOGGLE_gameState != gameState)
			{
				GC.Collect();
				GameScriptsManager.spellLogicScript.spellState = -2;
				scriptGameStatistic.characterAnimationNumber = 1;
				scriptMasterControl.PlayMusic(0, 1);
				scriptHudControl.state = 1;
				scriptCameraControl.state = 1;
				TOGGLE_gameState = gameState;
			}
			ButtonFunction(0);
			break;
		case 2:
			if (TOGGLE_gameState != gameState)
			{
				GC.Collect();
				scriptMasterControl.GameStart(1, 0);
				TOGGLE_gameWave = gameWaveNumber;
				TIMER_gameStateloading = Time.time + DELAY_gameStateloading;
				GameScriptsManager.spellLogicScript.spellState = -1;
				TOGGLE_music = 0;
				scriptMasterControl.PlayStageMusic(0);
				scriptGameStatistic.state = 1;
				scriptHudControl.state = 2;
				scriptCameraControl.state = 2;
				TOGGLE_gameState = gameState;
			}
			if (TIMER_gameStateloading != 0f && Time.time >= TIMER_gameStateloading)
			{
				scriptMasterControl.StageSetup(3, 0);
				TIMER_gameStateloading = 0f;
			}
			if (TOGGLE_gameWave != gameWaveNumber)
			{
				scriptGameStatistic.characterAnimationNumber = 1;
				TOGGLE_gameWave = gameWaveNumber;
			}
			switch (gameWaveTier)
			{
			case 0:
				if (scriptGameStatistic.guardUnitsRemaing > 1)
				{
					if (TOGGLE_music != 0)
					{
						scriptMasterControl.PlayStageMusic(0);
						TOGGLE_music = 0;
					}
				}
				else if (TOGGLE_music != 1)
				{
					scriptMasterControl.PlayStageMusic(1);
					TOGGLE_music = 1;
				}
				break;
			case 1:
				if (scriptGameStatistic.guardUnitsRemaing > 1)
				{
					if (TOGGLE_music != 2)
					{
						scriptMasterControl.PlayBossMusic(0);
						TOGGLE_music = 2;
					}
				}
				else if (TOGGLE_music != 3)
				{
					scriptMasterControl.PlayBossMusic(1);
					TOGGLE_music = 3;
				}
				if (scriptGameStatistic.gameStateWaveTierTeamB == 0)
				{
					gameWaveTier = 0;
				}
				break;
			}
			ButtonFunction(1);
			break;
		case 3:
			gameState = 5;
			break;
		case 4:
			gameState = 5;
			break;
		case 5:
			scriptMasterControl.ObjectLogicState(2);
			scriptGameStatistic.StatusScore(1);
			scriptMasterControl.CharacterChallengeSave(gameWavesComplete, scriptGameStatistic.scoreUnitDefeated);
			scriptMasterControl.Currency(scriptGameStatistic.scoreCurrencyPoints);
			scriptCameraControl.state = 0;
			scriptMasterControl.GameCenter(2, 0, gameWavesComplete);
			gameState++;
			break;
		case 6:
			if (TOGGLE_gameState != gameState)
			{
				scriptGameStatistic.characterAnimationNumber = 2;
				scriptMasterControl.PlayMusic(0, 0);
				scriptHudControl.scoreScreenToggle = 3;
				scriptHudControl.state = 5;
				scriptCameraControl.state = 0;
				if (gameWavesComplete >= 12)
				{
					scriptMasterControl.GameCenter(2, 5, 0);
				}
				if (gameWavesComplete >= 24)
				{
					scriptMasterControl.GameCenter(2, 6, 0);
				}
				ScriptsManager.dataScript.iCloudData(3, "null", 0);
				TOGGLE_gameState = gameState;
			}
			ButtonFunction(2);
			break;
		}
	}

	private void GameStateStartLoading()
	{
		if (TOGGLE_gameState != gameState)
		{
			TIMER_gameStateloading = Time.time + DELAY_gameStateloading;
			scriptHudControl.state = 0;
			scriptCameraControl.state = -1;
			scriptMasterControl.StageSetup(gameStage, gameLevel + 1);
			TOGGLE_gameState = gameState;
		}
		if (Time.time >= TIMER_gameStateloading)
		{
			GC.Collect();
			scriptGameStatistic.StatusReset();
			gameState = 1;
		}
		gameWaveNumber = 1;
	}

	private void GameStateLoading()
	{
		if (TOGGLE_gameState != gameState)
		{
			gameLevel++;
			TOGGLE_stageSetup = 0;
			DELAY_stageSetup = Time.time + DELAY_gameStateloading / 2f;
			scriptMasterControl.gameLevel++;
			scriptGameStatistic.StatusReset();
			TIMER_gameStateloading = Time.time + DELAY_gameStateloading;
			scriptHudControl.state = 0;
			scriptCameraControl.state = 0;
			scriptMasterControl.StageSetup(gameStage, gameLevel + 1);
			GC.Collect();
			TOGGLE_gameState = gameState;
		}
		gameLevel = scriptMasterControl.gameLevel;
		gameWaveNumber = 1;
		gameWavesComplete = 0;
		if (Time.time >= DELAY_stageSetup && TOGGLE_stageSetup != 1)
		{
			scriptMasterControl.ObjectLogicState(0);
			TOGGLE_stageSetup = 1;
		}
		if (Time.time >= TIMER_gameStateloading)
		{
			gameState = 1;
		}
	}

	private void GameStateIntroduction()
	{
		if (TOGGLE_gameState != gameState)
		{
			GC.Collect();
			GameScriptsManager.spellLogicScript.spellState = -2;
			scriptGameStatistic.characterAnimationNumber = 1;
			scriptMasterControl.PlayMusic(0, 1);
			scriptHudControl.state = 1;
			scriptHudControl.weekNumber = gameLevel + 1;
			scriptCameraControl.state = 1;
			TOGGLE_gameState = gameState;
		}
		ButtonFunction(0);
	}

	private void GameStateGameplay()
	{
		if (TOGGLE_gameState != gameState)
		{
			GC.Collect();
			scriptMasterControl.GameStart(0, 0);
			TOGGLE_gameWave = gameWaveNumber;
			TIMER_gameStateloading = Time.time + DELAY_gameStateloading;
			GameScriptsManager.spellLogicScript.spellState = -1;
			TOGGLE_music = 0;
			scriptMasterControl.PlayStageMusic(0);
			scriptGameStatistic.state = 1;
			scriptHudControl.state = 2;
			scriptCameraControl.state = 2;
			TOGGLE_gameState = gameState;
		}
		if (TIMER_gameStateloading != 0f && Time.time >= TIMER_gameStateloading)
		{
			scriptMasterControl.StageSetup(gameStage, 0);
			TIMER_gameStateloading = 0f;
		}
		if (gameWaveNumber <= 0)
		{
			gameState = 3;
		}
		if (TOGGLE_gameWave != gameWaveNumber)
		{
			scriptGameStatistic.characterAnimationNumber = 1;
			TOGGLE_gameWave = gameWaveNumber;
		}
		switch (gameWaveTier)
		{
		case 0:
			if (scriptGameStatistic.guardUnitsRemaing > 1)
			{
				if (TOGGLE_music != 0)
				{
					scriptMasterControl.PlayStageMusic(0);
					TOGGLE_music = 0;
				}
			}
			else if (TOGGLE_music != 1)
			{
				scriptMasterControl.PlayStageMusic(1);
				TOGGLE_music = 1;
			}
			break;
		case 1:
			if (scriptGameStatistic.guardUnitsRemaing > 1)
			{
				if (TOGGLE_music != 2)
				{
					scriptMasterControl.PlayBossMusic(0);
					TOGGLE_music = 2;
				}
			}
			else if (TOGGLE_music != 3)
			{
				scriptMasterControl.PlayBossMusic(1);
				TOGGLE_music = 3;
			}
			if (scriptGameStatistic.gameStateWaveTierTeamB == 0)
			{
				gameWaveTier = 0;
			}
			break;
		}
		ButtonFunction(1);
	}

	private void GameStateVictoryStatisticSave()
	{
		scriptMasterControl.ObjectLogicState(2);
		scriptGameStatistic.StatusScore(0);
		scriptMasterControl.CharacterLevelSave(scriptGameStatistic.scoreRating);
		scriptMasterControl.Currency(scriptGameStatistic.scoreCurrencyPoints);
		scriptCameraControl.state = 0;
		scriptMasterControl.GameCenter(2, 0, gameWavesComplete);
		gameState++;
	}

	private void GameStateVictory()
	{
		if (TOGGLE_gameState != gameState)
		{
			scriptGameStatistic.characterAnimationNumber = 3;
			scriptMasterControl.PlayMusic(0, 0);
			scriptHudControl.scoreScreenToggle = 1;
			scriptHudControl.state = 5;
			scriptCameraControl.state = 0;
			ScriptsManager.dataScript.iCloudData(3, "null", 0);
			TOGGLE_gameState = gameState;
		}
		ButtonFunction(2);
        admob.ShowAds();
    }

	private void GameStateDefeatStatisticSave()
	{
		switch (gameWaveTier)
		{
		case 0:
			ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat", 0f);
			break;
		case 1:
			ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:boss", 0f);
			break;
		}
		scriptMasterControl.ObjectLogicState(2);
		scriptGameStatistic.StatusScore(1);
		scriptMasterControl.Currency(scriptGameStatistic.scoreCurrencyPoints);
		scriptCameraControl.state = 0;
		scriptMasterControl.GameCenter(2, 0, gameWavesComplete);
		gameState++;
	}

	private void GameStateDefeat()
	{
		if (TOGGLE_gameState != gameState)
		{
			scriptGameStatistic.characterAnimationNumber = 2;
			scriptMasterControl.PlayMusic(0, 1);
			scriptHudControl.scoreScreenToggle = 2;
			scriptHudControl.state = 5;
			scriptCameraControl.state = 0;
			ScriptsManager.dataScript.iCloudData(3, "null", 0);
			TOGGLE_gameState = gameState;
		}
		ButtonFunction(2);
        //admob.ShowAds();
	}

	private void GameStateChallengeDefeat()
	{
		if (TOGGLE_gameState != gameState)
		{
			scriptGameStatistic.characterAnimationNumber = 2;
			scriptMasterControl.PlayMusic(0, 1);
			scriptHudControl.scoreScreenToggle = 3;
			scriptHudControl.state = 5;
			scriptCameraControl.state = 0;
			TOGGLE_gameState = gameState;
		}
		ButtonFunction(2);
	}

	private void ButtonFunction(int type)
	{
		switch (type)
		{
		case 0:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray3 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray3, out RaycastHit hitInfo3))
			{
				if (hitInfo3.collider.transform.name == "BTN_RESTART")
				{
					scriptHudControl.state = 1;
					ButtonLoadFunctions(0);
				}
				if (hitInfo3.collider.transform.name == "BTN_MENU")
				{
					scriptHudControl.state = 1;
					ButtonLoadFunctions(1);
				}
			}
			break;
		}
		case 1:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray2 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (!Physics.Raycast(ray2, out RaycastHit hitInfo2))
			{
				break;
			}
			if (hitInfo2.collider.transform.name == "BTN_RESTART")
			{
				ScriptsManager.dataScript.iCloudData(3, "null", 0);
				if (gameWaveTier == 1)
				{
					switch (scriptGameStatistic.scoreRating)
					{
					case 1:
						ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:restart:bronze:boss", 0f);
						break;
					case 2:
						ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:restart:silver:boss", 0f);
						break;
					case 3:
						ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:restart:gold:boss", 0f);
						break;
					}
				}
				else
				{
					switch (scriptGameStatistic.scoreRating)
					{
					case 1:
						ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:restart:bronze", 0f);
						break;
					case 2:
						ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:restart:silver", 0f);
						break;
					case 3:
						ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:restart:gold", 0f);
						break;
					}
				}
				scriptHudControl.state = 2;
				ButtonLoadFunctions(0);
			}
			if (!(hitInfo2.collider.transform.name == "BTN_MENU"))
			{
				break;
			}
			ScriptsManager.dataScript.iCloudData(3, "null", 0);
			if (gameMode == 2)
			{
				ScriptsManager.dataScript.GameAnalytics("arena:quit", 0f);
				ScriptsManager.dataScript.GameAnalytics("arena:quit:wavesCleared:" + gameWavesComplete, 0f);
			}
			else if (gameWaveTier == 1)
			{
				switch (scriptGameStatistic.scoreRating)
				{
				case 1:
					ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:quit:bronze:boss", 0f);
					break;
				case 2:
					ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:quit:silver:boss", 0f);
					break;
				case 3:
					ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:quit:gold:boss", 0f);
					break;
				}
			}
			else
			{
				switch (scriptGameStatistic.scoreRating)
				{
				case 1:
					ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:quit:bronze", 0f);
					break;
				case 2:
					ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:quit:silver", 0f);
					break;
				case 3:
					ScriptsManager.dataScript.GameAnalytics("level:" + gameLevel + ":defeat:quit:gold", 0f);
					break;
				}
			}
			scriptHudControl.state = 2;
			ButtonLoadFunctions(1);
			break;
		}
		case 2:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (!Physics.Raycast(ray, out RaycastHit hitInfo))
			{
				break;
			}
			if (hitInfo.collider.transform.name == "BTN_CONTINUE")
			{
				if (gameMode != 2)
				{
					if (gameLevel == 0 && PlayerPrefs.GetInt("libraryIntro") == 0)
					{
						ButtonLoadFunctions(6);
					}
					else if (gameLevel >= scriptMasterControl.gameMaximumLevel - 1)
					{
						ButtonLoadFunctions(5);
					}
					else if (gameLevel == scriptMasterControl.gameLevelPerStage - 1 || gameLevel == scriptMasterControl.gameLevelPerStage * 2 - 1)
					{
						ButtonLoadFunctions(4);
					}
					else if (scriptMasterControl.characterUnlock[3] != 1 && scriptMasterControl.characterCompletionPercent >= 100)
					{
						ButtonLoadFunctions(4);
					}
					else
					{
						ButtonLoadFunctions(7);
					}
				}
				else if (gameMode == 2)
				{
					ButtonLoadFunctions(6);
				}
			}
			if (hitInfo.collider.transform.name == "BTN_RESTART")
			{
                        print("restart button click hua");

                        ButtonLoadFunctions(2);
			}
			if (hitInfo.collider.transform.name == "BTN_MENU")
			{
				ButtonLoadFunctions(3);
			}
			break;
		}
		}
	}

	private void ButtonLoadFunctions(int toggle)
	{
        print("Koi button click hua- " + toggle);

        //if (toggle == 0)
        //	Camera_Control.instance.isObjectClciked = true;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(accessClip);
		scriptMasterControl.PlayMusic(-1, 0);
		GC.Collect();
		if (gameMode != 2)
		{
			scriptMasterControl.StageSetup(gameStage, 0);
		}
		else
		{
			scriptMasterControl.StageSetup(3, 0);
		}
		scriptMasterControl.ObjectLogicState(10);
		scriptMasterControl.CharacterDataLoad();
		Time.timeScale = 1f;
		GameScriptsManager.loading = 1;
		switch (toggle)
		{
		case 0:
                
                //scriptMasterControl.LoadTransition(0);
			AutoFade.LoadLevel("Load - Game", 0.1f, 0.1f, Color.green);
			break;
		case 1:
			//scriptMasterControl.LoadTransition(0);
			//CameraScreenTransition.control.uniqueScreenTransition = -1;
			AutoFade.LoadLevel("Load - Menu", 0.1f, 0.1f, Color.green);
			break;
		case 2:
			//scriptMasterControl.LoadTransition(0);
			if (gameLevel == scriptMasterControl.gameLevelPerStage - 1 || gameLevel == scriptMasterControl.gameLevelPerStage * 2 - 1 || gameLevel == scriptMasterControl.gameLevelPerStage * 3 - 1)
			{
				scriptMasterControl.SceneLoadAfterUnlock("Load - Game");
				AutoFade.LoadLevel("Load - Unlock", 2.4f, 1f, Color.clear);
			}
			else if (scriptMasterControl.characterUnlock[3] != 1 && scriptMasterControl.characterCompletionPercent >= 100)
			{
				scriptMasterControl.SceneLoadAfterUnlock("Load - Game");
				AutoFade.LoadLevel("Load - Unlock", 2.4f, 1f, Color.clear);
			}
			else
			{
				scriptMasterControl.SceneLoadAfterUnlock("Load - Game");
				AutoFade.LoadLevel("Load - Game", 2.4f, 1f, Color.clear);
			}
			break;
		case 3:
			//scriptMasterControl.LoadTransition(0);
			if (gameLevel == scriptMasterControl.gameLevelPerStage - 1 || gameLevel == scriptMasterControl.gameLevelPerStage * 2 - 1 || gameLevel == scriptMasterControl.gameLevelPerStage * 3 - 1)
			{
				CameraScreenTransition.control.uniqueScreenTransition = -1;
				scriptMasterControl.SceneLoadAfterUnlock("Load - Menu");
				AutoFade.LoadLevel("Load - Unlock", 2.4f, 1f, Color.clear);
			}
			else if (scriptMasterControl.characterUnlock[3] != 1 && scriptMasterControl.characterCompletionPercent >= 100)
			{
				scriptMasterControl.SceneLoadAfterUnlock("Load - Menu");
				AutoFade.LoadLevel("Load - Unlock", 2.4f, 1f, Color.clear);
			}
			else
			{
				CameraScreenTransition.control.uniqueScreenTransition = -1;
				AutoFade.LoadLevel("Load - Menu", 2.4f, 1f, Color.clear);
			}
			break;
		case 4:
			//scriptMasterControl.LoadTransition(0);
			scriptMasterControl.SceneLoadAfterUnlock("Load - Game");
			scriptMasterControl.gameLevel++;
			AutoFade.LoadLevel("Load - Unlock", 2.4f, 1f, Color.clear);
			break;
		case 5:
			CameraScreenTransition.control.uniqueScreenTransition = -1;
			scriptMasterControl.SceneLoadAfterUnlock("Load - Menu");
			AutoFade.LoadLevel("Load - Story End", 3f, 1f, Color.white);
			break;
		case 6:
			scriptMasterControl.LoadTransition(0);
			CameraScreenTransition.control.uniqueScreenTransition = -1;
			AutoFade.LoadLevel("Load - Library", 2.4f, 1f, Color.clear);
			break;
		case 7:
			scriptMasterControl.gameLevel++;
			scriptMasterControl.LoadTransition(0);
			AutoFade.LoadLevel("Load - Game Reload", 2.4f, 1f, Color.clear);
			break;
		}
	}
}
