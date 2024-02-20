using UnityEngine;

public class Game_Statistics : MonoBehaviour
{
	public AudioClip unitRetreatClip;

	public AudioClip unitChampionRetreatClip;

	public int state;

	public int characterAnimationNumber;

	private int TOGGLE_characterAnimationNumber;

	public GameObject closesIntruder;

	public int gameStatisticMaximumUnitSpawn;

	public int gameStatusUnitSpawnNumberTeamA;

	public int gameStatusUnitSpawnNumberTeamB;

	public int gameStateWaveTierTeamA;

	public int gameStateWaveTierTeamB;

	public int currencyRate = 6;

	private Guard_Logic scriptGuardLogic;

	private HUD_Control scriptHudControl;

	private Game_Logic scriptGameLogic;

	private Statistic_Logic scriptStatistic;

	private Spell_Logic scriptSpellLogic;

	private Camera_Control scriptCameraControl;

	private PlayerAnimationSet characterAnimationScript;

	public int scoreBestWaveRecord;

	public int scoreCurrentBestWaveRecord;

	public int scoreCurrencyPoints;

	public int scoreSpellPoints;

	public int scoreObjectPoints;

	public int scoreWavesCompleted;

	public int scoreRating;

	public int scoreUnitDefeated;

	public int scoreShardsCollected;

	public int scoreItemsUsed;

	public int scoreItemsPurchused;

	private int GRADE_spellAverge;

	private int GRADE_objectAverge;

	private int AMOUNT_currency;

	public int analyticRedSpellCasted;

	public int analyticBlueSpellCasted;

	public int analyticYellowSpellCasted;

	public int analyticGreenSpeelCasted;

	public int analyticUnitsDefeated;

	public int analyticGuardsDefeated;

	public int analyticShardsCollected;

	private int gameMode;

	private int TOGGLE_GameStatusWaveNumber;

	private int TOGGLE_scoreUnitDefeated;

	private int TOGGLE_championDefeatClip;

	public int guardUnitsAmount;

	public float guardUnitValue;

	public int guardUnitsRemaing;

	private int guardState;

	private float VALUE_guardRating;

	private float VALUE_rating;

	public int shardPickUp;

	public int manaMaximumLimit;

	public int manaStartingAmount;

	public int manaWaveRegenerateAmount;

	public int manaRegenerationOverTime;

	private float TIMER_manaRegenerationOverTime;

	public int manaRecoverAmount;

	private int TOGGLE_manaRecoverAmount;

	public int manaNumber;

	private int manaState;

	private int TOGGLE_manaGameWaveNumber;

	public int objectState;

	public int objectManaCost;

	public int objectMaximumLevitation;

	public int objectLevitating;

	private void Start()
	{
		base.useGUILayout = false;
		scriptGuardLogic = GameScriptsManager.guardLogicScript;
		scriptHudControl = GameScriptsManager.hudControlcScript;
		scriptGameLogic = GameScriptsManager.gameLogicScript;
		scriptStatistic = GameScriptsManager.statisticLogicScript;
		characterAnimationScript = GameMasterScriptsControl.characterAnimationScript;
		scriptCameraControl = GameScriptsManager.cameraControlScript;
		gameMode = scriptGameLogic.gameMode;
		gameStatisticMaximumUnitSpawn = 6;
	}

	private void Update()
	{
		if (characterAnimationNumber != -1)
		{
			if (characterAnimationScript != null)
			{
				characterAnimationScript.animationNumber = characterAnimationNumber;
			}
			characterAnimationNumber = -1;
		}
		if (closesIntruder != scriptCameraControl.enemyDetected)
		{
			closesIntruder = scriptCameraControl.enemyDetected;
		}
		switch (state)
		{
		case 0:
			if (characterAnimationScript != null)
			{
				characterAnimationScript.characterState = 0;
			}
			guardState = 0;
			manaState = 0;
			objectState = 0;
			break;
		case 1:
			GuardStatus();
			ManaStatus();
			ObjectLevitationStatus();
			GameStatus();
			break;
		}
	}

	public void StatusReset()
	{
		state = 0;
		scriptGuardLogic.state = 0;
		guardUnitsRemaing = guardUnitsAmount;
		gameStateWaveTierTeamA = 1;
		gameStateWaveTierTeamB = 1;
		gameStatusUnitSpawnNumberTeamA = 0;
		gameStatusUnitSpawnNumberTeamB = 0;
		gameMode = scriptGameLogic.gameMode;
		scoreCurrencyPoints = 0;
		scoreSpellPoints = 15;
		scoreObjectPoints = 15;
		scoreUnitDefeated = 0;
		scoreShardsCollected = 0;
		scoreItemsUsed = 0;
		scoreItemsPurchused = 0;
		scoreWavesCompleted = 0;
		objectLevitating = 0;
	}

	public void StatusScore(int gameResult)
	{
		state = 0;
		scriptHudControl.scoreScreenNumberOfGuardsRemaining = guardUnitsRemaing;
		scriptHudControl.scoreScreenNumberOfGuards = guardUnitsAmount;
		scriptHudControl.scoreScreenWavesCompleted = scoreWavesCompleted;
		scriptHudControl.scoreScreenSpellAverageGrade = GRADE_spellAverge;
		scriptHudControl.scoreScreenObjectAverageGrade = GRADE_objectAverge;
		if (gameMode != 2)
		{
			scriptHudControl.scoreScreenRankMedal = scoreRating;
			if (GameScriptsManager.masterControlScript.saveMode == 0 && scoreRating > ScriptsManager.dataScript.selectedCharacterLevelRating[scriptGameLogic.gameLevel])
			{
				scoreCurrentBestWaveRecord = 1;
			}
			scriptHudControl.scoreScreenNewBestState = scoreCurrentBestWaveRecord;
			switch (gameResult)
			{
			case 0:
				AMOUNT_currency = UnityEngine.Random.Range((scriptGameLogic.gameLevel + 1) * currencyRate, (scriptGameLogic.gameLevel + 2) * currencyRate);
				scoreCurrencyPoints = AMOUNT_currency + scoreRating * 4 + GRADE_spellAverge * 2 + GRADE_objectAverge * 2;
				scriptHudControl.scoreScreenCurrencyGained = scoreCurrencyPoints;
				switch (scoreRating)
				{
				case 1:
					ScriptsManager.dataScript.GameAnalytics("level:" + scriptGameLogic.gameLevel + ":victory:bronze", 0f);
					break;
				case 2:
					ScriptsManager.dataScript.GameAnalytics("level:" + scriptGameLogic.gameLevel + ":victory:silver", 0f);
					break;
				case 3:
					ScriptsManager.dataScript.GameAnalytics("level:" + scriptGameLogic.gameLevel + ":victory:gold", 0f);
					break;
				}
				break;
			case 1:
				AMOUNT_currency = scoreWavesCompleted * (scriptGameLogic.gameStage + 1);
				scoreCurrencyPoints = AMOUNT_currency + GRADE_spellAverge * 1 + GRADE_objectAverge * 1;
				scriptHudControl.scoreScreenCurrencyGained = scoreCurrencyPoints;
				break;
			}
		}
		else
		{
			if (gameMode != 2)
			{
				return;
			}
			if (GameScriptsManager.masterControlScript.saveMode == 0)
			{
				if (scoreWavesCompleted > ScriptsManager.dataScript.selectedCharacterBestWaveRecord[0])
				{
					scoreRating = 3;
					scoreCurrentBestWaveRecord = 1;
				}
				else if (scoreWavesCompleted > ScriptsManager.dataScript.selectedCharacterBestWaveRecord[1] && scoreWavesCompleted <= ScriptsManager.dataScript.selectedCharacterBestWaveRecord[0])
				{
					scoreRating = 2;
					scoreCurrentBestWaveRecord = 1;
				}
				else if (scoreWavesCompleted > ScriptsManager.dataScript.selectedCharacterBestWaveRecord[2] && scoreWavesCompleted <= ScriptsManager.dataScript.selectedCharacterBestWaveRecord[1])
				{
					scoreRating = 1;
					scoreCurrentBestWaveRecord = 1;
				}
				else if (scoreWavesCompleted <= ScriptsManager.dataScript.selectedCharacterBestWaveRecord[2])
				{
					scoreRating = 0;
				}
				for (int i = 0; i < 3; i++)
				{
					if (scoreWavesCompleted > ScriptsManager.dataScript.ChallengeWaveRecord[i].recordNumber)
					{
						scoreCurrentBestWaveRecord = 1;
					}
				}
				if (scoreWavesCompleted == 0)
				{
					scoreCurrentBestWaveRecord = 0;
				}
			}
			scriptHudControl.scoreScreenNewBestState = scoreCurrentBestWaveRecord;
			scriptHudControl.scoreScreenRankMedal = scoreRating;
			AMOUNT_currency = scoreWavesCompleted * (scoreWavesCompleted / 2);
			scoreCurrencyPoints = AMOUNT_currency + scoreRating * 4 + GRADE_spellAverge * 2 + GRADE_objectAverge * 2;
			scriptHudControl.scoreScreenCurrencyGained = scoreCurrencyPoints;
			ScriptsManager.dataScript.GameAnalytics("arena:wavesCleared:" + scoreWavesCompleted, 0f);
		}
	}

	private void GameAnalytics()
	{
	}

	private void GameStatus()
	{
		if (scoreObjectPoints < 10)
		{
			GRADE_objectAverge = 0;
		}
		else if (scoreObjectPoints >= 10 && scoreObjectPoints < 30)
		{
			GRADE_objectAverge = 1;
		}
		else if (scoreObjectPoints >= 30 && scoreObjectPoints < 40)
		{
			GRADE_objectAverge = 2;
		}
		else if (scoreObjectPoints >= 40 && scoreObjectPoints < 50)
		{
			GRADE_objectAverge = 3;
		}
		else if (scoreObjectPoints >= 50)
		{
			GRADE_objectAverge = 4;
			if (scoreObjectPoints > 60)
			{
				scoreObjectPoints = 60;
			}
		}
		if (scoreSpellPoints < 10)
		{
			GRADE_spellAverge = 0;
		}
		else if (scoreSpellPoints >= 10 && scoreSpellPoints < 30)
		{
			GRADE_spellAverge = 1;
		}
		else if (scoreSpellPoints >= 30 && scoreSpellPoints < 40)
		{
			GRADE_spellAverge = 2;
		}
		else if (scoreSpellPoints >= 40 && scoreSpellPoints < 50)
		{
			GRADE_spellAverge = 3;
		}
		else if (scoreSpellPoints >= 50)
		{
			GRADE_spellAverge = 4;
			if (scoreSpellPoints > 60)
			{
				scoreSpellPoints = 60;
			}
		}
		if (TOGGLE_scoreUnitDefeated < scoreUnitDefeated)
		{
			GameScriptsManager.audioSourceC.PlayOneShot(unitRetreatClip);
			TOGGLE_scoreUnitDefeated = scoreUnitDefeated;
		}
		if (gameStateWaveTierTeamB == 2)
		{
			TOGGLE_championDefeatClip = 1;
		}
		else if (gameStateWaveTierTeamB == 0 && TOGGLE_championDefeatClip == 1)
		{
			GameScriptsManager.audioSourceC.PlayOneShot(unitChampionRetreatClip);
			TOGGLE_championDefeatClip = 0;
		}
		if (gameStateWaveTierTeamB == 3)
		{
			scriptGameLogic.gameState = 5;
		}
	}

	private void GuardStatus()
	{
		switch (guardState)
		{
		case 0:
			guardUnitsAmount = scriptStatistic.CharacterBaseAttribute[0].characterNumberOfGuards;
			guardUnitsRemaing = guardUnitsAmount;
			guardUnitValue = scriptStatistic.CharacterBaseAttribute[0].characterGuardRatingValue;
			guardState++;
			break;
		case 1:
			VALUE_guardRating = (float)(guardUnitsAmount - guardUnitsRemaing) * guardUnitValue;
			VALUE_rating = 100f - VALUE_guardRating;
			if (gameMode != 2)
			{
				if (VALUE_rating > 50f)
				{
					scoreRating = 3;
				}
				else if (VALUE_rating <= 50f && VALUE_rating > 0f)
				{
					scoreRating = 2;
				}
				else if (VALUE_rating <= 0f)
				{
					scoreRating = 1;
				}
			}
			if (!(characterAnimationScript != null))
			{
				break;
			}
			if (guardUnitsRemaing <= 1)
			{
				if (!characterAnimationScript.panicMark)
				{
					characterAnimationScript.panicMark = true;
				}
			}
			else if (characterAnimationScript.panicMark)
			{
				characterAnimationScript.panicMark = false;
			}
			break;
		}
	}

	private void ManaStatus()
	{
		switch (manaState)
		{
		case 0:
			shardPickUp = 0;
			manaMaximumLimit = scriptStatistic.InGameAttribute[0].playerMaxManaPoint;
			manaStartingAmount = scriptStatistic.InGameAttribute[0].playerStartingManaPoint;
			manaRegenerationOverTime = scriptStatistic.InGameAttribute[0].playerManaRegenerate;
			manaWaveRegenerateAmount = scriptStatistic.InGameAttribute[0].playerManaWaveRegenerate;
			manaNumber = manaStartingAmount;
			scriptHudControl.manaNumber = manaNumber;
			scriptHudControl.maxManaNumber = scriptStatistic.InGameAttribute[0].playerMaxManaPoint;
			TIMER_manaRegenerationOverTime = Time.time + 4f;
			manaState++;
			break;
		case 1:
			if (Time.timeScale == 0f)
			{
				break;
			}
			if (!Input.GetMouseButton(0) && shardPickUp != 0)
			{
				shardPickUp = 0;
			}
			if (manaRecoverAmount != 0)
			{
				TOGGLE_manaRecoverAmount += manaRecoverAmount;
				manaRecoverAmount = 0;
			}
			if (manaMaximumLimit != scriptStatistic.InGameAttribute[0].playerMaxManaPoint)
			{
				scriptHudControl.maxManaNumber = scriptStatistic.InGameAttribute[0].playerMaxManaPoint;
				manaMaximumLimit = scriptStatistic.InGameAttribute[0].playerMaxManaPoint;
			}
			if (manaRegenerationOverTime != scriptStatistic.InGameAttribute[0].playerManaRegenerate)
			{
				TIMER_manaRegenerationOverTime = Time.time + 4f;
				manaRegenerationOverTime = scriptStatistic.InGameAttribute[0].playerManaRegenerate;
			}
			if (manaWaveRegenerateAmount != scriptStatistic.InGameAttribute[0].playerManaWaveRegenerate)
			{
				manaWaveRegenerateAmount = scriptStatistic.InGameAttribute[0].playerManaWaveRegenerate;
			}
			if (manaRegenerationOverTime != 0 && Time.time >= TIMER_manaRegenerationOverTime)
			{
				manaNumber += manaRegenerationOverTime;
				TIMER_manaRegenerationOverTime = Time.time + 4f;
			}
			if (manaNumber > manaMaximumLimit)
			{
				manaNumber = manaMaximumLimit;
				TIMER_manaRegenerationOverTime = Time.time + 4f;
				TOGGLE_manaRecoverAmount = 0;
			}
			else if (manaNumber < manaMaximumLimit && manaNumber >= 0)
			{
				if (manaRegenerationOverTime != 0 && Time.time >= TIMER_manaRegenerationOverTime)
				{
					manaNumber += manaRegenerationOverTime;
					TIMER_manaRegenerationOverTime = Time.time + 4f;
				}
				if (TOGGLE_manaRecoverAmount > 0)
				{
					manaNumber++;
					TOGGLE_manaRecoverAmount--;
				}
				else if (TOGGLE_manaRecoverAmount < 0)
				{
					manaNumber--;
					TOGGLE_manaRecoverAmount++;
				}
			}
			else if (manaNumber == manaMaximumLimit)
			{
				if (TOGGLE_manaRecoverAmount != 0)
				{
					if (TOGGLE_manaRecoverAmount < 0)
					{
						manaNumber--;
						TOGGLE_manaRecoverAmount++;
					}
					else
					{
						TOGGLE_manaRecoverAmount = 0;
					}
				}
				if (manaRegenerationOverTime != 0)
				{
					if (manaRegenerationOverTime < 0)
					{
						if (Time.time >= TIMER_manaRegenerationOverTime)
						{
							manaNumber += manaRegenerationOverTime;
							TIMER_manaRegenerationOverTime = Time.time + 4f;
						}
					}
					else
					{
						TIMER_manaRegenerationOverTime = Time.time + 4f;
					}
				}
			}
			else if (manaNumber < 0)
			{
				manaNumber = 0;
				TOGGLE_manaRecoverAmount = 0;
			}
			if (scriptHudControl.manaNumber != manaNumber)
			{
				scriptHudControl.manaNumber = manaNumber;
			}
			if (TOGGLE_manaGameWaveNumber != scriptGameLogic.gameWaveNumber)
			{
				manaNumber += manaWaveRegenerateAmount;
				TOGGLE_manaGameWaveNumber = scriptGameLogic.gameWaveNumber;
			}
			break;
		}
	}

	private void ObjectLevitationStatus()
	{
		switch (objectState)
		{
		case -1:
			if (characterAnimationScript != null)
			{
				characterAnimationScript.characterState = 0;
			}
			objectMaximumLevitation = 0;
			break;
		case 0:
			if (characterAnimationScript != null)
			{
				characterAnimationScript.characterState = 1;
			}
			objectMaximumLevitation = scriptStatistic.CharacterBaseAttribute[0].characterMaximumObjectInput;
			objectManaCost = scriptStatistic.CharacterBaseAttribute[0].characterObjectControlManaCost;
			objectState++;
			break;
		case 1:
			if (objectMaximumLevitation != scriptStatistic.CharacterBaseAttribute[0].characterMaximumObjectInput)
			{
				objectMaximumLevitation = scriptStatistic.CharacterBaseAttribute[0].characterMaximumObjectInput;
			}
			if (objectManaCost != scriptStatistic.CharacterBaseAttribute[0].characterObjectControlManaCost)
			{
				objectManaCost = scriptStatistic.CharacterBaseAttribute[0].characterObjectControlManaCost;
			}
			if (!Input.GetMouseButton(0) && objectLevitating >= 0 && objectLevitating != objectMaximumLevitation)
			{
				objectLevitating = objectMaximumLevitation;
			}
			if (objectLevitating >= objectMaximumLevitation)
			{
			}
			break;
		}
	}
}
