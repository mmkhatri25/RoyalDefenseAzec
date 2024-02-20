using System;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
	[Serializable]
	public class spellDescription
	{
		public tk2dAnimatedSprite spellIcon;

		public tk2dTextMesh spellName;

		public tk2dAnimatedSprite spellManaCost;

		public tk2dTextMesh spellDescriptionInfo;
	}

	public int menuState;

	public int progressionMenuLock;

	private int TOGGLE_menuState;

	private int TOGGLE2_menuState;

	private float scriptTimer = 5f;

	private float TIME_scriptTimer;

	private Game_Data scriptData;

	public GameObject playerCharacter;

	public PlayerCharacterInfo characterInfoData;

	public PlayerCharacterData characterData;

	public string selectedCharacterID;

	private string TOGGLE_selectedCharacterID;

	public string viewCharacterID;

	public string characterID;

	public GameObject characterProgressionHUD;

	public float characterProgressionTransitionSpeed;

	public GameObject characterSelectButton;

	public GameObject characterSelectButton2;

	public GameObject characterUnlockButton;

	public GameObject characterProgressionCharacterIcon;

	public tk2dAnimatedSprite characterProgressionCharacterIconPicture;

	public tk2dTextMesh characterProgressionMode;

	public tk2dTextMesh characterProgressionLevelNumber;

	public tk2dTextMesh characterProgressionPlusNumber;

	public tk2dTextMesh characterProgressionGoldNumber;

	public tk2dTextMesh characterProgressionSilverNumber;

	public tk2dTextMesh characterProgressionBronzeNumber;

	public tk2dTextMesh characterName;

	public tk2dTextMesh characterClass;

	public tk2dAnimatedSprite characterDifficulty;

	public tk2dAnimatedSprite characterPortrait;

	public tk2dAnimatedSprite characterPortrait2;

	public tk2dAnimatedSprite characterBackground;

	public tk2dAnimatedSprite characterIcon;

	public spellDescription[] SpellDescription;

	public Vector3 characterProgressionCharacterIconOn;

	public Vector3 characterProgressionMiddleOn;

	public Vector3 characterProgressionMiddleOff;

	public Vector3 characterProgressionLeftOn;

	public Vector3 characterProgressionLeftOff;

	public Vector3 characterProgressionOff;

	public int characterProgressionState;

	private float TIMER_viewCharacterIDDelay;

	private int NUMBER_levelProgress;

	private int TOGGLE_characterProgressionHUD;

	private void Start()
	{
		characterProgressionCharacterIconOn = characterProgressionCharacterIcon.transform.localPosition;
		scriptData = ScriptsManager.dataScript;
	}

	private void Update()
	{
		ScreenTransition();
		DataUpdate();
	}

	private void LateUpdate()
	{
	}

	private void CharacterMenuData()
	{
		NUMBER_levelProgress = PlayerPrefs.GetInt(characterID + "levelProgress") + 1;
		if (NUMBER_levelProgress <= scriptData.gameMaximumLevel)
		{
			characterProgressionMode.text = "week";
			characterProgressionLevelNumber.text = string.Empty + NUMBER_levelProgress;
		}
		else
		{
			characterProgressionMode.text = "best";
			characterProgressionLevelNumber.text = string.Empty + PlayerPrefs.GetInt(characterID + "bestWaveRecord0");
		}
		characterProgressionLevelNumber.Commit();
		characterProgressionMode.Commit();
		characterProgressionGoldNumber.text = string.Empty + PlayerPrefs.GetInt(characterID + "ratingGold");
		characterProgressionGoldNumber.Commit();
		characterProgressionSilverNumber.text = string.Empty + PlayerPrefs.GetInt(characterID + "ratingSilver");
		characterProgressionSilverNumber.Commit();
		characterProgressionBronzeNumber.text = string.Empty + PlayerPrefs.GetInt(characterID + "ratingBronze");
		characterProgressionBronzeNumber.Commit();
		characterName.text = string.Empty + characterInfoData.characterName;
		characterName.Commit();
		characterClass.text = "the " + PlayerPrefs.GetString(characterID + "characterClass");
		characterClass.Commit();
		if (PlayerPrefs.GetInt(characterID + "completionPercent") < 20)
		{
			characterDifficulty.Play("iap_difficultyA_0");
		}
		else if (PlayerPrefs.GetInt(characterID + "completionPercent") >= 20 && PlayerPrefs.GetInt(characterID + "completionPercent") < 40)
		{
			characterDifficulty.Play("iap_difficultyA_1");
		}
		else if (PlayerPrefs.GetInt(characterID + "completionPercent") >= 40 && PlayerPrefs.GetInt(characterID + "completionPercent") < 60)
		{
			characterDifficulty.Play("iap_difficultyA_2");
		}
		else if (PlayerPrefs.GetInt(characterID + "completionPercent") >= 60 && PlayerPrefs.GetInt(characterID + "completionPercent") < 80)
		{
			characterDifficulty.Play("iap_difficultyA_3");
		}
		else if (PlayerPrefs.GetInt(characterID + "completionPercent") >= 80 && PlayerPrefs.GetInt(characterID + "completionPercent") < 100)
		{
			characterDifficulty.Play("iap_difficultyA_4");
		}
		else if (PlayerPrefs.GetInt(characterID + "completionPercent") >= 100)
		{
			characterDifficulty.Play("iap_difficultyA_5");
		}
		characterPortrait.Play(string.Empty + characterID);
		characterPortrait2.Play(string.Empty + characterID);
		characterBackground.color = characterInfoData.characterBackgroundColor;
		characterIcon.Play("icon_" + characterID);
	}

	private void DataUpdate()
	{
		if (playerCharacter != ScriptsManager.playerCharacter)
		{
			characterProgressionCharacterIconPicture.Play("pp_" + scriptData.selectedCharacterID);
			playerCharacter = ScriptsManager.playerCharacter;
		}
		if (viewCharacterID == string.Empty)
		{
			if (selectedCharacterID != "SELECT" && TOGGLE_selectedCharacterID != scriptData.selectedCharacterID)
			{
				playerCharacter = ScriptsManager.playerCharacter;
				characterInfoData = ScriptsManager.playerCharacter.GetComponent<PlayerCharacterInfo>();
				characterData = ScriptsManager.playerCharacter.GetComponent<PlayerCharacterData>();
				selectedCharacterID = characterInfoData.characterID;
				characterID = characterInfoData.characterID;
				characterProgressionCharacterIconPicture.Play("pp_" + characterID);
				CharacterMenuData();
				TOGGLE_selectedCharacterID = selectedCharacterID;
			}
			if (!characterSelectButton.active)
			{
				characterSelectButton.SetActiveRecursively(state: true);
			}
			if (characterUnlockButton.active)
			{
				characterUnlockButton.SetActiveRecursively(state: false);
			}
			if (PlayerPrefs.GetInt(selectedCharacterID + "levelProgress") >= scriptData.gameMaximumLevel)
			{
				if (!characterSelectButton2.active)
				{
					characterSelectButton2.SetActiveRecursively(state: true);
				}
			}
			else if (characterSelectButton2.active)
			{
				characterSelectButton2.SetActiveRecursively(state: false);
			}
			return;
		}
		if (TOGGLE_selectedCharacterID != viewCharacterID)
		{
			if (viewCharacterID != scriptData.selectedCharacterID)
			{
				for (int i = 0; i < scriptData.CharacterData.Length; i++)
				{
					if (viewCharacterID == scriptData.CharacterData[i].characterID)
					{
						characterInfoData = scriptData.CharacterData[i].characterObjectInst.GetComponent<PlayerCharacterInfo>();
						characterData = scriptData.CharacterData[i].characterObjectInst.GetComponent<PlayerCharacterData>();
						i = scriptData.CharacterData.Length;
					}
				}
				characterID = characterInfoData.characterID;
				CharacterMenuData();
				TOGGLE_selectedCharacterID = viewCharacterID;
			}
			else
			{
				viewCharacterID = string.Empty;
			}
			TOGGLE_selectedCharacterID = viewCharacterID;
		}
		else if (viewCharacterID == selectedCharacterID)
		{
			viewCharacterID = string.Empty;
		}
		if (viewCharacterID != selectedCharacterID)
		{
			if (PlayerPrefs.GetInt(viewCharacterID + "LOCK") == 1)
			{
				if (!characterSelectButton.active)
				{
					characterSelectButton.SetActiveRecursively(state: true);
				}
				if (characterUnlockButton.active)
				{
					characterUnlockButton.SetActiveRecursively(state: false);
				}
				if (PlayerPrefs.GetInt(viewCharacterID + "levelProgress") >= scriptData.gameMaximumLevel - 1)
				{
					if (!characterSelectButton2.active)
					{
						characterSelectButton2.SetActiveRecursively(state: true);
					}
				}
				else if (characterSelectButton2.active)
				{
					characterSelectButton2.SetActiveRecursively(state: false);
				}
			}
			else if (PlayerPrefs.GetInt(viewCharacterID + "LOCK") == 0)
			{
				if (characterSelectButton.active)
				{
					characterSelectButton.SetActiveRecursively(state: false);
				}
				if (!characterUnlockButton.active)
				{
					characterUnlockButton.SetActiveRecursively(state: true);
				}
				if (characterSelectButton2.active)
				{
					characterSelectButton2.SetActiveRecursively(state: false);
				}
			}
			return;
		}
		if (!characterSelectButton.active)
		{
			characterSelectButton.SetActiveRecursively(state: true);
		}
		if (characterUnlockButton.active)
		{
			characterUnlockButton.SetActiveRecursively(state: false);
		}
		if (PlayerPrefs.GetInt(viewCharacterID + "levelProgress") >= scriptData.gameMaximumLevel - 1)
		{
			if (!characterSelectButton2.active)
			{
				characterSelectButton2.SetActiveRecursively(state: true);
			}
		}
		else if (characterSelectButton2.active)
		{
			characterSelectButton2.SetActiveRecursively(state: false);
		}
	}

	private void ScreenTransition()
	{
		if (TOGGLE_menuState != menuState)
		{
			if (characterProgressionState == 1)
			{
				switch (menuState)
				{
				case 0:
					if (characterProgressionHUD.transform.localPosition != characterProgressionMiddleOff)
					{
						characterProgressionHUD.transform.localPosition = characterProgressionMiddleOff;
					}
					if (characterProgressionCharacterIcon.transform.localPosition != characterProgressionCharacterIconOn)
					{
						characterProgressionCharacterIcon.transform.localPosition = characterProgressionCharacterIconOn;
					}
					break;
				case 1:
					if (characterProgressionHUD.transform.localPosition != characterProgressionLeftOff)
					{
						characterProgressionHUD.transform.localPosition = characterProgressionLeftOff;
					}
					if (characterProgressionCharacterIcon.transform.localPosition != characterProgressionOff)
					{
						characterProgressionCharacterIcon.transform.localPosition = characterProgressionOff;
					}
					break;
				case 2:
					if (characterProgressionCharacterIcon.transform.localPosition != characterProgressionOff)
					{
						characterProgressionCharacterIcon.transform.localPosition = characterProgressionOff;
					}
					break;
				}
			}
			switch (menuState)
			{
			case 0:
				if (characterProgressionCharacterIcon.transform.localPosition != characterProgressionCharacterIconOn)
				{
					characterProgressionCharacterIcon.transform.localPosition = characterProgressionCharacterIconOn;
				}
				break;
			case 1:
				if (characterProgressionCharacterIcon.transform.localPosition != characterProgressionOff)
				{
					characterProgressionCharacterIcon.transform.localPosition = characterProgressionOff;
				}
				break;
			case 2:
				if (characterProgressionCharacterIcon.transform.localPosition != characterProgressionOff)
				{
					characterProgressionCharacterIcon.transform.localPosition = characterProgressionOff;
				}
				break;
			}
			TIME_scriptTimer = scriptTimer + Time.time;
			TOGGLE2_menuState = -1;
			TOGGLE_menuState = menuState;
		}
		if (menuState == 1)
		{
			if (TOGGLE2_menuState != TOGGLE_menuState)
			{
				characterProgressionState = 0;
				TOGGLE_characterProgressionHUD = -1;
				TOGGLE2_menuState = TOGGLE_menuState;
			}
			else
			{
				if (TOGGLE2_menuState != TOGGLE_menuState)
				{
					return;
				}
				switch (TOGGLE_characterProgressionHUD)
				{
				case -1:
					if (characterProgressionHUD.transform.localPosition != characterProgressionLeftOn)
					{
						characterProgressionHUD.transform.localPosition = Vector3.Lerp(characterProgressionHUD.transform.localPosition, characterProgressionLeftOn, Time.deltaTime * characterProgressionTransitionSpeed);
					}
					break;
				case 0:
					if (characterProgressionHUD.transform.localPosition != characterProgressionLeftOn)
					{
						characterProgressionHUD.transform.localPosition = Vector3.Lerp(characterProgressionHUD.transform.localPosition, characterProgressionLeftOn, Time.deltaTime * characterProgressionTransitionSpeed * 2f);
					}
					break;
				case 1:
				{
					if (characterProgressionState != 1)
					{
						characterProgressionState = 1;
					}
					Vector3 localPosition = characterProgressionHUD.transform.localPosition;
					if (localPosition.y != characterProgressionOff.y)
					{
						Transform transform = characterProgressionHUD.transform;
						Vector3 localPosition2 = characterProgressionHUD.transform.localPosition;
						Vector3 localPosition3 = characterProgressionHUD.transform.localPosition;
						float x = localPosition3.x;
						float y = characterProgressionOff.y;
						Vector3 localPosition4 = characterProgressionHUD.transform.localPosition;
						transform.localPosition = Vector3.Lerp(localPosition2, new Vector3(x, y, localPosition4.z), Time.deltaTime * characterProgressionTransitionSpeed / 2f);
					}
					break;
				}
				}
				switch (progressionMenuLock)
				{
				case 1:
					break;
				case -1:
					if (Input.GetMouseButtonDown(0))
					{
						if (TOGGLE_characterProgressionHUD == 0 || TOGGLE_characterProgressionHUD == -1)
						{
							TOGGLE_characterProgressionHUD = 1;
						}
						else if (TOGGLE_characterProgressionHUD == 1)
						{
							TOGGLE_characterProgressionHUD = 0;
						}
					}
					break;
				case 0:
					progressionMenuLock = -1;
					break;
				}
			}
		}
		else
		{
			if (TOGGLE2_menuState == TOGGLE_menuState)
			{
				return;
			}
			switch (TOGGLE_menuState)
			{
			case 0:
				if (characterProgressionState != 0)
				{
					characterProgressionState = 0;
				}
				if (characterProgressionHUD.transform.localPosition != characterProgressionMiddleOn)
				{
					characterProgressionHUD.transform.localPosition = Vector3.Lerp(characterProgressionHUD.transform.localPosition, characterProgressionMiddleOn, Time.deltaTime * characterProgressionTransitionSpeed);
				}
				break;
			case 1:
				if (characterProgressionState != 0)
				{
					characterProgressionState = 0;
				}
				if (characterProgressionHUD.transform.localPosition != characterProgressionLeftOn)
				{
					characterProgressionHUD.transform.localPosition = Vector3.Lerp(characterProgressionHUD.transform.localPosition, characterProgressionLeftOn, Time.deltaTime * characterProgressionTransitionSpeed);
				}
				break;
			case 2:
			{
				if (characterProgressionState != 1)
				{
					characterProgressionState = 1;
				}
				Vector3 localPosition5 = characterProgressionHUD.transform.localPosition;
				if (localPosition5.y != characterProgressionOff.y)
				{
					Transform transform2 = characterProgressionHUD.transform;
					Vector3 localPosition6 = characterProgressionHUD.transform.localPosition;
					Vector3 localPosition7 = characterProgressionHUD.transform.localPosition;
					float x2 = localPosition7.x;
					float y2 = characterProgressionOff.y;
					Vector3 localPosition8 = characterProgressionHUD.transform.localPosition;
					transform2.localPosition = Vector3.Lerp(localPosition6, new Vector3(x2, y2, localPosition8.z), Time.deltaTime * characterProgressionTransitionSpeed);
				}
				break;
			}
			}
			if (Time.time >= TIME_scriptTimer)
			{
				TOGGLE2_menuState = TOGGLE_menuState;
			}
		}
	}
}
