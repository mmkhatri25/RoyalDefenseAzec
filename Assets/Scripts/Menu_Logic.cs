using System;
using UnityEngine;

public class Menu_Logic : MonoBehaviour
{
	[Serializable]
	public class menuGroup
	{
		public string menuName;

		public MenuTransition[] menuTransitionScript;
	}

	private Game_Data data;

	private AudioClip regularClick;

	private AudioClip accessClick;

	public bool loading;

	public int menuNumber = -1;

	private int TOGGLE_menuNumber = -1;

	public menuGroup[] MenuGroup;

	public tk2dAnimatedSprite[] soundButtonSprite = new tk2dAnimatedSprite[2];

	public GameObject[] iapButtons;

	public GameObject keyHud;

	public tk2dTextMesh keyText;

	private int keyNumber;

	public tk2dTextMesh currencyTextSM;

	public tk2dTextMesh currencyTextCM;

	private int currencyNumber;

	public MenuInformation menuInformation;

	public LevelMenu scriptLevelMenu;

	public CharacterMenu scriptCharacterMenu;

	public CharacterSelections scriptCharacterScreen;

	public StoreMenu scriptStoreMenu;

	public int characterScreenToggle;

	public tk2dAnimatedSprite tutorialButton;

	private int tutorialMode = -1;

	private int unlockMode;

	private int maximumGameLevel;

	private int gameLevelPerStage;

	private string ID_finalCharacter;

	private int autoTutorialMode;

	private int TOGGLE_debug;

	private int TOGGLE_debug2;

	private int TOGGLE_debugNumber;

	private float startDelay = 1f;

	private void Start()
	{
		Resources.UnloadUnusedAssets();
		base.useGUILayout = false;
		data = ScriptsManager.dataScript;
		unlockMode = data.unlockMode;
		maximumGameLevel = data.gameMaximumLevel;
		gameLevelPerStage = data.gameLevelPerStage;
		autoTutorialMode = data.autoTutorialMode;
		for (int i = 0; i < soundButtonSprite.Length; i++)
		{
			soundButtonSprite[i].Play("sm_" + data.soundMode);
		}
		currencyNumber = data.playerCurrency;
		keyNumber = data.playerKey;
		keyText.text = string.Empty + keyNumber;
		keyText.Commit();
		currencyTextSM.text = string.Empty + currencyNumber;
		currencyTextSM.Commit();
		currencyTextCM.text = string.Empty + currencyNumber;
		currencyTextCM.Commit();
		if (ScriptsManager.contentDataScript.musicPlaying != 1)
		{
			ScriptsManager.contentDataScript.PlayMusic(0, 0);
		}
		tutorialMode = data.gameTutorialMode;
		tutorialButton.Play("tutorialButton_0" + data.gameTutorialMode);
		ScriptsManager.contentDataScript.state = 0;
		ScriptsManager.playerCharacter.GetComponent<PlayerAnimationSet>().animationNumber = 0;
		ScriptsManager.stageControlScript.state = 0;
		regularClick = ScriptsManager.audioClip[0];
		accessClick = ScriptsManager.audioClip[1];
		int num = unlockMode;
		if (num == 1)
		{
			keyHud.SetActiveRecursively(state: false);
		}
		if (data.iapMode == 0)
		{
			for (int j = 0; j < iapButtons.Length; j++)
			{
				iapButtons[j].SetActiveRecursively(state: false);
			}
		}
		startDelay = Time.time + 1f;
		ID_finalCharacter = ScriptsManager.contentDataScript.StoreIAPs[ScriptsManager.contentDataScript.StoreIAPs.Length - 1].iapID;
		CameraScreenTransition.control.Clear(-1);
		data.GameCenter(1, -2, 0);
	}

	private void Update()
	{
		if (data.debugMode == 1)
		{
			CheatFunction();
		}
		if (data.soundMode == 2)
		{
			if (!Camera.main.GetComponent<AudioSource>().mute)
			{
				Camera.main.GetComponent<AudioSource>().mute = true;
			}
		}
		else if (Camera.main.GetComponent<AudioSource>().mute)
		{
			Camera.main.GetComponent<AudioSource>().mute = false;
		}
		MenuControlFunction();
		MenuDataFunction();
		if (PlayerPrefs.GetInt("tutorialIntro") == 0)
		{
			if (tutorialButton.gameObject.active)
			{
				tutorialButton.gameObject.SetActiveRecursively(state: false);
			}
		}
		else if (PlayerPrefs.GetInt("tutorialIntro") == 1)
		{
			if (autoTutorialMode == 1)
			{
				tutorialButton.gameObject.SetActiveRecursively(state: false);
			}
			else
			{
				tutorialButton.gameObject.SetActiveRecursively(state: true);
				data.TutorialOption(1);
			}
			PlayerPrefs.SetInt("tutorialIntro", 2);
		}
		else if (PlayerPrefs.GetInt("tutorialIntro") == 2)
		{
			if (autoTutorialMode == 1)
			{
				if (tutorialButton.gameObject.active)
				{
					tutorialButton.gameObject.SetActiveRecursively(state: false);
				}
			}
			else if (!tutorialButton.gameObject.active)
			{
				tutorialButton.gameObject.SetActiveRecursively(state: true);
			}
		}
		if (!loading)
		{
			ButtonFunction();
			if (UnityEngine.Input.GetKeyUp(KeyCode.F1))
			{
				data.CharacterDataErase(data.selectedCharacterID, 1);
			}
		}
	}

	private void CheatFunction()
	{
		if (MenuGroup[1].menuTransitionScript[0].transitionNumber == 0)
		{
			if (Input.GetMouseButtonDown(1))
			{
				TOGGLE_debug = 1;
				TOGGLE_debugNumber++;
			}
			if (Input.GetMouseButtonDown(3))
			{
				TOGGLE_debug = 2;
				TOGGLE_debugNumber++;
			}
			if (Input.GetMouseButtonDown(2))
			{
				TOGGLE_debug = 3;
				TOGGLE_debugNumber++;
			}
		}
		else
		{
			TOGGLE_debug = 0;
			TOGGLE_debugNumber = 0;
		}
		if (TOGGLE_debug2 != TOGGLE_debug)
		{
			TOGGLE_debugNumber = 0;
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			TOGGLE_debug2 = TOGGLE_debug;
		}
		switch (TOGGLE_debug)
		{
		case 1:
			if (TOGGLE_debugNumber >= 3)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(accessClick);
				data.debugNumber = 1;
				TOGGLE_debug = 0;
			}
			break;
		case 2:
			if (TOGGLE_debugNumber >= 3)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(accessClick);
				data.debugNumber = 2;
				TOGGLE_debug = 0;
			}
			break;
		case 3:
			if (TOGGLE_debugNumber >= 3)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(accessClick);
				data.debugNumber = 3;
				TOGGLE_debug = 0;
			}
			break;
		}
	}

	private void MenuDataFunction()
	{
		if (currencyNumber != data.playerCurrency)
		{
			currencyTextSM.text = string.Empty + data.playerCurrency;
			currencyTextSM.Commit();
			currencyTextCM.text = string.Empty + data.playerCurrency;
			currencyTextCM.Commit();
			currencyNumber = data.playerCurrency;
		}
		if (keyNumber != data.playerKey)
		{
			if (keyNumber < data.playerKey)
			{
				menuInformation.informationNumber = 1;
				menuInformation.informationType = 2;
			}
			keyText.text = string.Empty + data.playerKey;
			keyText.Commit();
			keyNumber = data.playerKey;
		}
		if (tutorialMode != data.gameTutorialMode)
		{
			tutorialButton.Play("tutorialButton_0" + data.gameTutorialMode);
			tutorialMode = data.gameTutorialMode;
		}
	}

	private void ClearMenu()
	{
		for (int i = 0; i < MenuGroup.Length; i++)
		{
			for (int j = 0; j < MenuGroup[i].menuTransitionScript.Length; j++)
			{
				if (MenuGroup[i].menuTransitionScript[j].transitionNumber != 5)
				{
					MenuGroup[i].menuTransitionScript[j].transitionNumber = 5;
				}
			}
		}
		scriptLevelMenu.pageInfoState = -4;
		scriptCharacterScreen.pageInfoState = -4;
		scriptCharacterMenu.menuState = 0;
	}

	private void MenuControlFunction()
	{
		switch (characterScreenToggle)
		{
		case 1:
			scriptCharacterMenu.progressionMenuLock = 0;
			MenuGroup[4].menuTransitionScript[0].transitionNumber = 2;
			MenuGroup[11].menuTransitionScript[0].transitionNumber = 2;
			MenuGroup[6].menuTransitionScript[0].transitionNumber = 1;
			scriptCharacterMenu.menuState = 2;
			characterScreenToggle = 0;
			break;
		case 2:
			scriptCharacterMenu.progressionMenuLock = 0;
			MenuGroup[4].menuTransitionScript[0].transitionNumber = 0;
			MenuGroup[11].menuTransitionScript[0].transitionNumber = 0;
			MenuGroup[6].menuTransitionScript[0].transitionNumber = 1;
			scriptCharacterMenu.menuState = 2;
			characterScreenToggle = 0;
			break;
		}
		if (menuNumber == 0 && Time.time >= startDelay)
		{
			MenuGroup[0].menuTransitionScript[0].transitionNumber = 1;
			if (PlayerPrefs.GetInt("WZlevelProgress") < 1 && data.levelStartMode == 1)
			{
				menuNumber = 2;
			}
			else if (PlayerPrefs.GetInt(data.selectedCharacterID + "nextBookUnlock") == 0 && PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") >= gameLevelPerStage)
			{
				if (PlayerPrefs.GetInt(data.selectedCharacterID + "storyUnlocks") == 0 && PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") >= maximumGameLevel)
				{
					data.GameAnalytics("story:complete", 0f);
					data.GameAnalytics("story:complete:attempts:" + PlayerPrefs.GetInt(data.selectedCharacterID + "statStoryAttempts"), 0f);
					menuNumber = 7;
				}
				else
				{
					if (data.selectedCharacterID != ID_finalCharacter)
					{
						menuInformation.informationNumber = 2;
						menuInformation.informationType = 2;
					}
					PlayerPrefs.SetInt(data.selectedCharacterID + "nextBookUnlock", 1);
					menuNumber = 1;
				}
			}
			else if (PlayerPrefs.GetInt(data.selectedCharacterID + "storyUnlocks") == 0 && PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") >= maximumGameLevel)
			{
				data.GameAnalytics("story:complete", 0f);
				data.GameAnalytics("story:complete:attempts:" + PlayerPrefs.GetInt(data.selectedCharacterID + "statStoryAttempts"), 0f);
				menuNumber = 7;
			}
			else if (PlayerPrefs.GetInt("libraryIntro") == 0)
			{
				PlayerPrefs.SetInt("WZGCunlock", 1);
				menuNumber = 8;
			}
			else
			{
				menuNumber = 1;
			}
		}
		if (TOGGLE_menuNumber != menuNumber)
		{
			switch (menuNumber)
			{
			case -1:
				ClearMenu();
				menuNumber = 1;
				break;
			case 0:
				MenuGroup[11].menuTransitionScript[0].transitionNumber = 0;
				MenuGroup[0].menuTransitionScript[0].transitionNumber = 0;
				scriptCharacterMenu.menuState = 2;
				break;
			case 1:
				MenuGroup[4].menuTransitionScript[0].transitionNumber = 0;
				MenuGroup[11].menuTransitionScript[0].transitionNumber = 0;
				scriptCharacterMenu.menuState = 2;
				scriptCharacterScreen.pageInfoState = -3;
				menuNumber = 4;
				break;
			case 2:
				MenuGroup[11].menuTransitionScript[0].transitionNumber = 1;
				MenuGroup[2].menuTransitionScript[0].transitionNumber = 0;
				MenuGroup[4].menuTransitionScript[0].transitionNumber = 5;
				scriptCharacterMenu.menuState = 0;
				scriptLevelMenu.pageInfoState = -3;
				break;
			case 3:
			{
				Transform transform = Camera.main.transform;
				float additionStageLength = ScriptsManager.stageControlScript.StageInfo[3].additionStageLength;
				Vector3 position = Camera.main.transform.position;
				float y = position.y;
				Vector3 position2 = Camera.main.transform.position;
				transform.position = new Vector3(additionStageLength, y, position2.z);
				MenuGroup[11].menuTransitionScript[0].transitionNumber = 1;
				MenuGroup[3].menuTransitionScript[0].transitionNumber = 0;
				MenuGroup[4].menuTransitionScript[0].transitionNumber = 5;
				scriptCharacterMenu.menuState = 2;
				break;
			}
			case 4:
				MenuGroup[4].menuTransitionScript[0].transitionNumber = 0;
				MenuGroup[11].menuTransitionScript[0].transitionNumber = 0;
				scriptCharacterMenu.menuState = 2;
				scriptCharacterScreen.pageInfoState = -3;
				break;
			case 5:
				MenuGroup[8].menuTransitionScript[0].transitionNumber = 0;
				break;
			case 6:
				MenuGroup[2].menuTransitionScript[0].transitionNumber = 5;
				MenuGroup[3].menuTransitionScript[0].transitionNumber = 5;
				scriptCharacterMenu.viewCharacterID = string.Empty;
				scriptCharacterMenu.menuState = 1;
				MenuGroup[6].menuTransitionScript[0].transitionNumber = 0;
				break;
			case 7:
				menuInformation.informationNumber = 0;
				menuInformation.informationType = 2;
				break;
			case 8:
				menuInformation.informationNumber = 0;
				menuInformation.informationType = 1;
				PlayerPrefs.SetInt("libraryIntro", 1);
				break;
			}
			if (menuNumber != 1)
			{
				TOGGLE_menuNumber = menuNumber;
			}
		}
	}
	public GameObject canvasmain;
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
		if (hitInfo.collider.transform.name == "ms_home")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			menuNumber = 6;
		}
		if (hitInfo.collider.transform.name == "ms_option")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			MenuGroup[1].menuTransitionScript[0].transitionNumber = 0;
			canvasmain.SetActive(true);

        }
		if (hitInfo.collider.transform.name == "os_back")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			MenuGroup[1].menuTransitionScript[0].transitionNumber = 5;
            canvasmain.SetActive(false);

        }
        if (hitInfo.collider.transform.name == "ms_character")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			menuNumber = 4;
		}
		if (hitInfo.collider.transform.name == "ms_store")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			menuNumber = 6;
		}
		if (hitInfo.collider.transform.name == "ex_sound")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			data.SoundOption(data.soundMode + 1);
			for (int i = 0; i < soundButtonSprite.Length; i++)
			{
				soundButtonSprite[i].Play("sm_" + data.soundMode);
				if (data.soundMode > 2)
				{
					soundButtonSprite[i].Play("sm_0");
				}
			}
			ScriptsManager.contentDataScript.PlayMusic(0, 0);
		}
		if (hitInfo.collider.transform.name == "os_tutorial")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			if (tutorialMode == 0)
			{
				data.TutorialOption(1);
			}
			else if (tutorialMode == 1)
			{
				menuInformation.informationType = 1;
				menuInformation.informationNumber = 2;
				data.TutorialOption(0);
			}
		}
		if (hitInfo.collider.transform.name == "is_continue")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			if (menuNumber == 7)
			{
				switch (unlockMode)
				{
				case 0:
					if (PlayerPrefs.GetInt(data.selectedCharacterID + "storyUnlocks") == 0)
					{
						data.PlayerKey(1);
						PlayerPrefs.SetInt(data.selectedCharacterID + "storyUnlocks", 1);
					}
					else if (PlayerPrefs.GetInt(data.selectedCharacterID + "storyUnlocks") == 1)
					{
						menuNumber = 1;
						menuInformation.informationType = 0;
					}
					break;
				case 1:
					if (PlayerPrefs.GetInt(data.selectedCharacterID + "storyUnlocks") != 0)
					{
						break;
					}
					if (PlayerPrefs.GetInt("WZlevelProgress") >= maximumGameLevel && PlayerPrefs.GetInt("WLlevelProgress") >= maximumGameLevel && PlayerPrefs.GetInt("WTlevelProgress") >= maximumGameLevel)
					{
						menuInformation.informationNumber = 3;
						menuInformation.informationType = 2;
						PlayerPrefs.SetInt("GCallBooks", 1);
						PlayerPrefs.SetInt(data.selectedCharacterID + "nextBookUnlock", 1);
					}
					else if (PlayerPrefs.GetInt(data.selectedCharacterID + "nextBookUnlock") == 0)
					{
						if (data.selectedCharacterID != ID_finalCharacter)
						{
							menuInformation.informationNumber = 2;
							menuInformation.informationType = 2;
						}
						else
						{
							menuInformation.informationType = 0;
						}
						PlayerPrefs.SetInt(data.selectedCharacterID + "nextBookUnlock", 1);
					}
					else
					{
						menuInformation.informationType = 0;
					}
					menuNumber = 1;
					PlayerPrefs.SetInt(data.selectedCharacterID + "storyUnlocks", 1);
					break;
				}
			}
			else if (menuNumber == 8)
			{
				menuNumber = 1;
				menuInformation.informationType = 0;
			}
			else
			{
				menuInformation.informationType = 0;
			}
		}
		if (hitInfo.collider.transform.name == "is_key")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			menuInformation.informationNumber = 1;
			menuInformation.informationType = 1;
		}
		if (hitInfo.collider.transform.name == "ex_gc0")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			data.GameCenter(1, 0, 0);
		}
		if (hitInfo.collider.transform.name == "ex_gc1")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			data.GameCenter(1, 1, 0);
		}
		if (hitInfo.collider.transform.name == "ex_gc2")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			data.GameCenter(1, 2, 0);
		}
		if (hitInfo.collider.transform.name == "ex_extra")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			data.GameAnalytics2("main:button:website", 1f);
			Application.OpenURL("http://fantasync.com/applink/castleclysm.html");
		}
		if (hitInfo.collider.transform.name == "ex_rate")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			data.GameAnalytics2("main:button:rateMe:android", 1f);
			Application.OpenURL("market://details?id=com.fantasync.castleclysm00");
		}
		if (hitInfo.collider.transform.name == "ms_CS")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			scriptCharacterMenu.viewCharacterID = string.Empty;
			scriptCharacterMenu.menuState = 1;
			MenuGroup[6].menuTransitionScript[0].transitionNumber = 0;
		}
		if (hitInfo.collider.transform.name == "cd_back")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			scriptCharacterMenu.progressionMenuLock = 0;
			MenuGroup[4].menuTransitionScript[0].transitionNumber = 0;
			MenuGroup[11].menuTransitionScript[0].transitionNumber = 0;
			MenuGroup[6].menuTransitionScript[0].transitionNumber = 5;
			scriptCharacterMenu.menuState = 2;
			menuNumber = -1;
		}
	}
}
