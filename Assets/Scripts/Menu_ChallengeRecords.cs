using System;
using UnityEngine;

public class Menu_ChallengeRecords : MonoBehaviour
{
	[Serializable]
	public class challengeWaveCharacterRecord
	{
		public string recordName;

		public int recordNumber;

		public string recordCharacter;
	}

	[Serializable]
	public class challengeWaveGameRecord
	{
		public string recordName;

		public int recordNumber;

		public string recordCharacter;
	}

	[Serializable]
	public class slotText
	{
		public tk2dAnimatedSprite characterIconSprite;

		public tk2dTextMesh characterClass;

		public tk2dTextMesh playerName;

		public tk2dTextMesh recordNumber;

		public tk2dSprite BG;
	}

	public int state;

	private int TOGGLE_state = -1;

	public int recordMenu;

	private int TOGGLE_recordMenu;

	public int challengeCostTier;

	private int challengeCost;

	private string characterID;

	public challengeWaveCharacterRecord[] ChallengeWaveCharacterRecord = new challengeWaveCharacterRecord[3];

	public challengeWaveGameRecord[] ChallengeWaveGameRecord = new challengeWaveGameRecord[3];

	public tk2dTextMesh recordTitle;

	public slotText[] SlotText = new slotText[3];

	public tk2dSprite titleBG;

	public pop_effect[] popEffects = new pop_effect[3];

	public Menu_Logic menuLogic;

	public MenuTransition scriptMenuTransition;

	public tk2dTextMesh challengeCostText;

	public pop_effect currencyPopEffect;

	private Game_Data scriptGameData;

	private float TIMER_transitionTime;

	public tk2dTextMesh tuneText;

	public int soundTrackNumber;

	private int TOGGLE_soundTrackNumber = -1;

	private AudioClip regularClick;

	private AudioClip accessClick;

	private AudioClip deniedClick;

	private Content_Data scriptContentData;

	private Stage_Control scriptStageControl;

	private bool gameLoading;

	private string loadPlayScene = "Load - LevelSetup";

	private void Start()
	{
		base.useGUILayout = false;
		scriptContentData = ScriptsManager.contentDataScript;
		scriptStageControl = ScriptsManager.stageControlScript;
		switch (scriptContentData.StageList[3].stageMusicTrackA)
		{
		case 0:
			soundTrackNumber = 0;
			break;
		case 2:
			soundTrackNumber = 1;
			break;
		case 4:
			soundTrackNumber = 2;
			break;
		}
		scriptGameData = ScriptsManager.dataScript;
		regularClick = ScriptsManager.audioClip[0];
		accessClick = ScriptsManager.audioClip[1];
		deniedClick = ScriptsManager.audioClip[2];
	}

	private void ButtonFunction()
	{
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (!Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			return;
		}
		if (hitInfo.collider.transform.name == "cs_START")
		{
			if (scriptGameData.selectedCharacterLevelProgress >= scriptGameData.gameMaximumLevel)
			{
				if (scriptGameData.playerCurrency >= challengeCost)
				{
					ScriptsManager.dataScript.GameAnalytics("arena:attempts", 0f);
					scriptGameData.PlayerCurrency(-challengeCost);
					currencyPopEffect.activate = true;
					scriptGameData.saveMode = 0;
					popEffects[0].activate = true;
					Camera.main.GetComponent<AudioSource>().PlayOneShot(accessClick);
					scriptGameData.gameLevel = 0;
					scriptGameData.gameMode = 2;
					scriptGameData.gameStage = 3;
					ScriptsManager.contentDataScript.PlayMusic(-1, 0);
					GC.Collect();
					AutoFade.LoadLevel(loadPlayScene, 3f, 1f, Color.black);
					gameLoading = true;
					menuLogic.loading = true;
					ScriptsManager.dataScript.iCloudData(3, "null", 0);
				}
				else
				{
					currencyPopEffect.activate = true;
					Camera.main.GetComponent<AudioSource>().PlayOneShot(deniedClick);
				}
			}
			else
			{
				popEffects[0].activate = true;
				Camera.main.GetComponent<AudioSource>().PlayOneShot(deniedClick);
			}
		}
		if (hitInfo.collider.transform.name == "cs_TUNE")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			soundTrackNumber++;
		}
		if (hitInfo.collider.transform.name == "cs_RECchar")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			popEffects[1].activate = true;
			recordMenu = -1;
		}
		if (hitInfo.collider.transform.name == "cs_RECgame")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			popEffects[2].activate = true;
			recordMenu = -2;
		}
	}

	private void trackSelect()
	{
		switch (soundTrackNumber)
		{
		case 0:
			if (TOGGLE_soundTrackNumber != soundTrackNumber)
			{
				scriptContentData.StageList[3].stageMusicTrackA = 0;
				scriptContentData.StageList[3].stageMusicTrackB = 0;
				scriptStageControl.StageInfo[3].stageMusicTrackA = 0;
				scriptStageControl.StageInfo[3].stageMusicTrackB = 0;
				tuneText.text = "tune: great hall";
				tuneText.Commit();
				TOGGLE_soundTrackNumber = soundTrackNumber;
			}
			break;
		case 1:
			if (TOGGLE_soundTrackNumber != soundTrackNumber)
			{
				scriptContentData.StageList[3].stageMusicTrackA = 2;
				scriptContentData.StageList[3].stageMusicTrackB = 2;
				scriptStageControl.StageInfo[3].stageMusicTrackA = 2;
				scriptStageControl.StageInfo[3].stageMusicTrackB = 2;
				tuneText.text = "tune: royal library";
				tuneText.Commit();
				TOGGLE_soundTrackNumber = soundTrackNumber;
			}
			break;
		case 2:
			if (TOGGLE_soundTrackNumber != soundTrackNumber)
			{
				scriptContentData.StageList[3].stageMusicTrackA = 4;
				scriptContentData.StageList[3].stageMusicTrackB = 4;
				scriptStageControl.StageInfo[3].stageMusicTrackA = 4;
				scriptStageControl.StageInfo[3].stageMusicTrackB = 4;
				tuneText.text = "tune: castle dungeon";
				tuneText.Commit();
				TOGGLE_soundTrackNumber = soundTrackNumber;
			}
			break;
		case 3:
			soundTrackNumber = 0;
			break;
		}
	}

	private void Update()
	{
		if (!gameLoading)
		{
			trackSelect();
			ButtonFunction();
		}
		if (characterID != scriptGameData.selectedCharacterID)
		{
			state++;
		}
		if (TOGGLE_state != state)
		{
			challengeCostTier = 0;
			recordMenu = 1;
			TOGGLE_recordMenu = -1;
			characterID = scriptGameData.selectedCharacterID;
			for (int i = 0; i < 3; i++)
			{
				if (scriptGameData.selectedCharacterBestWaveRecord[i] != 0)
				{
					ChallengeWaveCharacterRecord[i].recordName = characterID;
					ChallengeWaveCharacterRecord[i].recordNumber = scriptGameData.selectedCharacterBestWaveRecord[i];
					ChallengeWaveCharacterRecord[i].recordCharacter = characterID;
				}
				else
				{
					ChallengeWaveCharacterRecord[i].recordName = string.Empty;
					ChallengeWaveCharacterRecord[i].recordNumber = 0;
					ChallengeWaveCharacterRecord[i].recordCharacter = "FS";
				}
			}
			for (int j = 0; j < 3; j++)
			{
				if (scriptGameData.ChallengeWaveRecord[j].recordNumber != 0)
				{
					ChallengeWaveGameRecord[j].recordName = scriptGameData.ChallengeWaveRecord[j].recordName;
					ChallengeWaveGameRecord[j].recordNumber = scriptGameData.ChallengeWaveRecord[j].recordNumber;
					ChallengeWaveGameRecord[j].recordCharacter = scriptGameData.ChallengeWaveRecord[j].recordCharacter;
				}
				else
				{
					ChallengeWaveGameRecord[j].recordName = "empty";
					ChallengeWaveGameRecord[j].recordNumber = 0;
					ChallengeWaveGameRecord[j].recordCharacter = "FS";
				}
				if (ChallengeWaveGameRecord[j].recordCharacter == characterID)
				{
					challengeCostTier += 4 - j;
				}
			}
			TOGGLE_state = state;
		}
		if (TOGGLE_recordMenu != recordMenu)
		{
			challengeCost = challengeCostTier * scriptGameData.gameChallengeCost + scriptGameData.gameChallengeCost;
			challengeCostText.text = string.Empty + challengeCost;
			challengeCostText.Commit();
			switch (recordMenu)
			{
			case 0:
				scriptMenuTransition.transitionNumber = 2;
				TIMER_transitionTime = Time.time + 0.5f;
				break;
			case -1:
				scriptMenuTransition.transitionNumber = 5;
				TIMER_transitionTime = Time.time + 0.5f;
				break;
			case 1:
				scriptMenuTransition.transitionNumber = 0;
				recordTitle.text = "character record";
				recordTitle.Commit();
				titleBG.color = new Color(0.4f, 0.4f, 0.4f, 1f);
				for (int l = 0; l < 3; l++)
				{
					if (ChallengeWaveCharacterRecord[l].recordCharacter != "FS")
					{
						SlotText[l].characterIconSprite.Play("pp_" + characterID);
						SlotText[l].characterClass.text = PlayerPrefs.GetString(characterID + "characterClass");
						SlotText[l].playerName.text = PlayerPrefs.GetString(characterID + "characterName");
						SlotText[l].recordNumber.text = string.Empty + ChallengeWaveCharacterRecord[l].recordNumber;
					}
					else
					{
						SlotText[l].characterIconSprite.Play("pp_" + characterID);
						SlotText[l].characterClass.text = "no record";
						SlotText[l].playerName.text = string.Empty;
						SlotText[l].recordNumber.text = "0";
					}
					SlotText[l].characterClass.Commit();
					SlotText[l].playerName.Commit();
					SlotText[l].recordNumber.Commit();
					SlotText[l].BG.color = new Color(0.4f, 0.4f, 0.4f, 1f);
				}
				break;
			case -2:
				scriptMenuTransition.transitionNumber = 5;
				TIMER_transitionTime = Time.time + 0.5f;
				break;
			case 2:
				scriptMenuTransition.transitionNumber = 0;
				recordTitle.text = "game record";
				recordTitle.Commit();
				titleBG.color = new Color(0.55f, 0.55f, 0.4f, 1f);
				for (int k = 0; k < 3; k++)
				{
					if (ChallengeWaveGameRecord[k].recordCharacter != "FS")
					{
						SlotText[k].characterIconSprite.Play("pp_" + ChallengeWaveGameRecord[k].recordCharacter);
						SlotText[k].characterClass.text = PlayerPrefs.GetString(ChallengeWaveGameRecord[k].recordCharacter + "characterClass");
						SlotText[k].playerName.text = PlayerPrefs.GetString(ChallengeWaveGameRecord[k].recordCharacter + "characterName");
						SlotText[k].recordNumber.text = string.Empty + ChallengeWaveGameRecord[k].recordNumber;
					}
					else
					{
						SlotText[k].characterIconSprite.Play("pp_blank");
						SlotText[k].characterClass.text = "no record";
						SlotText[k].playerName.text = string.Empty;
						SlotText[k].recordNumber.text = "0";
					}
					SlotText[k].characterClass.Commit();
					SlotText[k].playerName.Commit();
					SlotText[k].recordNumber.Commit();
					SlotText[k].BG.color = new Color(0.55f, 0.55f, 0.4f, 1f);
				}
				break;
			}
			TOGGLE_recordMenu = recordMenu;
		}
		if ((recordMenu == -1 || recordMenu == -2 || recordMenu == 0) && Time.time >= TIMER_transitionTime)
		{
			switch (recordMenu)
			{
			case -1:
				recordMenu = 1;
				break;
			case 0:
				recordMenu = 1;
				break;
			case -2:
				recordMenu = 2;
				break;
			}
		}
	}
}
