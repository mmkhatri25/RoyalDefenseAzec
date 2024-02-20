using UnityEngine;

public class HUD_Control : MonoBehaviour
{
	public bool isRestartClicket;
	public GameObject MainCanvas;
    public tk2dAnimatedSprite[] soundButtonSprite = new tk2dAnimatedSprite[2];
    private Game_Data data;
	public AudioClip regularClick;
    public AudioClip clickClip;

	public int mode;

	public int state;

	private int TOGGLE_state;

	public GameObject pauseButton;

	public GameObject pauseRestartButton;

	public GameObject logo;

	private GameMasterScriptsControl gameMasterControl;

	private float stageLength;

	private int audioPauseState;

	public float TIMER_cinemaControlState;

	public int cinemaControlState;

	public GameObject cinemaControlHUD;

	public GameObject cinemaControlArrowHUD;

	private Vector3 VECTORON_cinemaControlHUD;

	private Vector3 VECTOROFF_cinemaControlHUD;

	private int scoreScreenState;

	private int TOGGLE_scoreScreenState;

	public int scoreScreenToggle;

	public int scoreScreenRankMedal;

	public int scoreScreenNumberOfGuards;

	public int scoreScreenNumberOfGuardsRemaining;

	public int scoreScreenCurrencyGained;

	public int scoreScreenWavesCompleted;

	public int scoreScreenNewBestState;

	public int scoreScreenObjectAverageGrade;

	public int scoreScreenSpellAverageGrade;

	public ScoreScreen_Control scriptScoreScreenControl;

	public Unit_Control unitControl;

	public int championDisplayState;

	public int championDisplaySpeechType;

	public string championDisplayPortraitID;

	public string championDisplayWarningQuote;

	public string championDisplayIntroductionSpeech;

	public string championDisplayChampionName;

	public Champion_HUD_Control scriptChampionHUD;

	public int waveNumberDisplayState;

	private int TOGGLE_waveNumberDisplayState;

	public int waveNumber;

	private int TOGGLE_waveNumber;

	private string STRING_waveNumber;

	public tk2dAnimatedSprite wavesNumberTenth;

	public tk2dAnimatedSprite wavesNumberOneth;

	public GameObject waveNumberDisplayHUD;

	private pop_effect waveNumberDisplayPopEffect;

	private Vector3 VECTORON_waveNumberDisplayHUD;

	private Vector3 VECTOROFF_waveNumberDisplayHUD;

	public int manaDisplayState;

	public int maxManaNumber;

	public int manaNumber;

	private int TOGGLE_manaNumber;

	public tk2dTextMesh manaNumberText;

	public GameObject manaNumberDisplayHUD;

	private pop_effect manaNumberDisplayPopEffect;

	private Color COLOR_manaNumber = new Color(0.63f, 1f, 1f, 1f);

	private Color COLOR_manaMaxNumber = Color.green;

	private Color COLOR_manaNoneNumber = Color.red;

	private Vector3 VECTORON_manaNumberDisplayHUD;

	private Vector3 VECTOROFF_manaNumberDisplayHUD;

	public int spellButtonState;

	public GameObject spellButtonHUD;

	private Vector3 VECTORON_spellButtonHUD;

	private Vector3 VECTOROFF_spellButtonHUD;

	public int itemButtonState;

	public GameObject itemButtonHUD;

	public tk2dAnimatedSprite shopButtonSprite;

	private Vector3 VECTORON_itemButtonHUD;

	private Vector3 VECTOROFF_itemButtonHUD;

	private Vector3 VECTORON2_itemButtonHUD;

	public int itemIconState;

	public GameObject itemIconOne;

	private Vector3 VECTORON_itemIconOne;

	private Vector3 VECTOROFF_itemIconOne;

	public GameObject itemIconTwo;

	private Vector3 VECTORON_itemIconTwo;

	private Vector3 VECTOROFF_itemIconTwo;

	public int shopState;

	public GameObject shopButtonHUD;

	private Vector3 VECTORON_shopButtonHUD;

	private Vector3 VECTOROFF_shopButtonHUD;

	public GameObject shopMenuHUD;

	private Vector3 VECTORON_shopMenuHUD;

	private Vector3 VECTOROFF_shopMenuHUD;

	public GameObject currencyHUD;

	private Vector3 VECTORON_currencyHUD;

	private Vector3 VECTOROFF_currencyHUD;

	public int miscScreenState;

	private int TOGGLE_miscScreenState;

	public GameObject pauseScreen;

	public int continueButtonState;

	public GameObject continueButtonHUD;

	private Vector3 VECTORON_continueButtonHUD;

	private Vector3 VECTOROFF_continueButtonHUD;

	public int levelIconState;

	public int weekNumber;

	private int TOGGLE_weekNumber;

	public GameObject levelIconHUD;

	public tk2dTextMesh gameModeText;

	public tk2dTextMesh weekNumberText;

	public tk2dSprite levelIconSprite;

	private Vector3 VECTORON_levelIconHUD;

	private Vector3 VECTOROFF_levelIconHUD;

	public int hintState;

	public int hintNumber;

	private int TOGGLE_hintNumber = -1;

	public GameObject hintButton;

	private Vector3 VECTORON_hintButtonHUD;

	private Vector3 VECTOROFF_hintButtonHUD;

	public tk2dAnimatedSprite hintImage;

	public tk2dTextMesh hintText;

	public GameObject hintImageObject;

	private Vector3 VECTORON_hintImageObjectHUD;

	private Vector3 VECTOROFF_hintImageObjectHUD;
	//public GameMasterScriptsControl gameMasterControl;
    private void Start()
	{
        isRestartClicket = false;
        base.useGUILayout = false;
		mode = GameScriptsManager.gameLogicScript.gameMode;
		gameMasterControl = GameScriptsManager.masterControlScript;
		stageLength = GameScriptsManager.masterControlScript.stageLength;
		waveNumberDisplayState = -1;
		manaDisplayState = -1;
		spellButtonState = -1;
		itemButtonState = -1;
		shopState = -1;
		levelIconState = -1;
		miscScreenState = -1;
		continueButtonState = -1;
		cinemaControlState = -1;
		hintState = -1;
        data = ScriptsManager.dataScript;
        for (int i = 0; i < soundButtonSprite.Length; i++)
        {
            soundButtonSprite[i].Play("sm_" + data.soundMode);
        }
		//mera kaam
		gameMasterControl.Currency(100000000);
	}

	private void Update()
	{
		//mera kaam
        //Time.timeScale = 2f;

		cinemaControlFunction();
		WaveDisplayFunction();
		ManaDisplayFunction();
		SpellHUDFunction();
		itemHUDFunction();
		shopHUDFunction();
		LevelIconFunction();
		miscScreenFunction();
		ChampionDisplayFunction();
		ScoreDisplayFunction();
		continueHUDFunction();
		HintHUDFunction();
		switch (mode)
		{
		case 0:
			NormalMode();
			break;
		case 1:
			TutorialMode();
			break;
		case 2:
			ChallengeMode();
			break;
		}
		switch (audioPauseState)
		{
		case 0:
			if (AudioListener.pause)
			{
				AudioListener.pause = false;
			}
			break;
		case 1:
			if (!AudioListener.pause)
			{
				AudioListener.pause = true;
			}
			break;
		}

		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (!Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			return;
		}
		if (hitInfo.collider.transform.name == "ex_sound")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			data.SoundOption(data.soundMode + 1);
			print("on firts ex_sound - "+ data.soundMode);
			for (int i = 0; i < soundButtonSprite.Length; i++)
			{
				soundButtonSprite[i].Play("sm_" + data.soundMode);
				if (data.soundMode > 2)
				{
					soundButtonSprite[i].Play("sm_0");
				}
			}
			ScriptsManager.contentDataScript.PlayMusic(0, 0);
            if (ScriptsManager.dataScript.soundMode == 2)
            {
				GameScriptsManager.audioSourceA.mute = true;
			}
			else
			{
                GameScriptsManager.audioSourceA.mute = false;

            }
        }
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (!pauseStatus || (state != 1 && state != 2 && state != 4 && state != 9))
		{
			return;
		}
		switch (state)
		{
		case 1:
			if (Time.timeScale == 1f)
			{
				if (mode == 1)
				{
					state = 5;
				}
				else
				{
					state = 7;
				}
			}
			break;
		case 2:
			if (Time.timeScale == 1f)
			{
				state = 3;
			}
			break;
		case 4:
			if (mode != 1 && Time.timeScale == 0f)
			{
				state = 3;
			}
			break;
		case 9:
			if (mode != 1 && Time.timeScale == 0f)
			{
				hintState = 1;
				state = 3;
			}
			break;
		}
	}

	private void NormalMode()
	{
		NormalModeButton();
		switch (state)
		{
		case 0:
			miscScreenState = 2;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				championDisplayState = 0;
				scoreScreenState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				championDisplayState = 0;
				miscScreenState = 0;
				scoreScreenState = 0;
				miscScreenState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 1;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		case 2:
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				miscScreenState = 0;
				scoreScreenState = 0;
				waveNumberDisplayState = 1;
				manaDisplayState = 1;
				spellButtonState = 1;
				itemButtonState = 1;
				shopState = 1;
				levelIconState = 1;
				TOGGLE_state = state;
			}
			break;
		case 3:
			miscScreenState = 1;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = true;
				audioPauseState = 1;
				Time.timeScale = 0f;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				cinemaControlState = 0;
				TOGGLE_state = state;
			}
			break;
		case 4:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				AudioListener.pause = false;
				audioPauseState = 0;
				miscScreenState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				levelIconState = 0;
				TOGGLE_state = state;
			}
			continueButtonState = 1;
			itemButtonState = 2;
			shopState = 2;
			break;
		case 5:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 1f;
				AudioListener.pause = false;
				audioPauseState = 0;
				continueButtonState = 0;
				championDisplayState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			scoreScreenState = 1;
			break;
		case 6:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				AudioListener.pause = true;
				audioPauseState = 1;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				TOGGLE_state = state;
			}
			break;
		case 7:
			miscScreenState = 1;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = true;
				audioPauseState = 1;
				Time.timeScale = 0f;
				continueButtonState = 0;
				championDisplayState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				cinemaControlState = 0;
				TOGGLE_state = state;
			}
			break;
		case 8:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				AudioListener.pause = true;
				audioPauseState = 1;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				TIMER_cinemaControlState = Time.realtimeSinceStartup + 1f;
				cinemaControlState = 3;
				TOGGLE_state = state;
			}
			break;
		case 9:
			if (gameMasterControl.tutorialMode == 1)
			{
				state = 2;
				TOGGLE_state = state;
			}
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				audioPauseState = 0;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 2;
				TOGGLE_state = state;
			}
			break;
		}
	}

	private void ChallengeMode()
	{
		NormalModeButton();
		switch (state)
		{
		case 0:
			miscScreenState = 2;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				championDisplayState = 0;
				scoreScreenState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				championDisplayState = 0;
				miscScreenState = 0;
				scoreScreenState = 0;
				miscScreenState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 2;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		case 2:
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				miscScreenState = 0;
				scoreScreenState = 0;
				waveNumberDisplayState = 1;
				manaDisplayState = 1;
				spellButtonState = 1;
				itemButtonState = 1;
				shopState = 1;
				levelIconState = 2;
				TOGGLE_state = state;
			}
			break;
		case 3:
			miscScreenState = 1;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = true;
				audioPauseState = 1;
				Time.timeScale = 0f;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				cinemaControlState = 0;
				TOGGLE_state = state;
			}
			break;
		case 4:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				AudioListener.pause = false;
				audioPauseState = 0;
				miscScreenState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				levelIconState = 0;
				TOGGLE_state = state;
			}
			continueButtonState = 1;
			itemButtonState = 2;
			shopState = 2;
			break;
		case 5:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 1f;
				AudioListener.pause = false;
				audioPauseState = 0;
				continueButtonState = 0;
				championDisplayState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			scoreScreenState = 1;
			break;
		case 6:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				AudioListener.pause = true;
				audioPauseState = 1;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				TOGGLE_state = state;
			}
			break;
		case 7:
			miscScreenState = 1;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = true;
				audioPauseState = 1;
				Time.timeScale = 0f;
				continueButtonState = 0;
				championDisplayState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				cinemaControlState = 0;
				TOGGLE_state = state;
			}
			break;
		case 8:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				AudioListener.pause = true;
				audioPauseState = 1;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				TIMER_cinemaControlState = Time.realtimeSinceStartup + 1f;
				cinemaControlState = 3;
				TOGGLE_state = state;
			}
			break;
		case 9:
			if (gameMasterControl.tutorialMode == 1)
			{
				state = 2;
				TOGGLE_state = state;
			}
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				audioPauseState = 0;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 2;
				TOGGLE_state = state;
			}
			break;
		}
	}

	private void NormalModeButton()
	{
		switch (state)
		{
		case 1:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray2 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray2, out RaycastHit hitInfo2))
			{
				if (hitInfo2.collider.transform.name == "BTN_PAUSE" && Time.timeScale == 1f)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 7;
				}
				if (hitInfo2.collider.transform.name == "BTN_CONTINUE")
				{
                            //print("restart clicked");

                            Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					GameScriptsManager.gameLogicScript.gameState = 2;
				}
			}
			break;
		}
		case 2:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray8 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray8, out RaycastHit hitInfo8))
			{
				if (hitInfo8.collider.transform.name == "BTN_PAUSE" && Time.timeScale == 1f)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 3;
				}
				if (hitInfo8.collider.transform.name == "BTN_HINT" && Time.timeScale == 1f)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 9;
				}
			}
			break;
		}
		case 3:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray3 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray3, out RaycastHit hitInfo3))
			{
				if (hitInfo3.collider.transform.name == "BTN_CONTINUE")
				{
                            //print("restart clicked");

                            Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 2;
				}
				if (hitInfo3.collider.transform.name == "BTN_RESTART")
				{
                            print("BTN_RESTART");

                            Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 2;
							MainCanvas.SetActive(false);
							print("restartclicked here...");
				}

				if (hitInfo3.collider.transform.name == "BTN_MENU")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 2;
				}
				if (hitInfo3.collider.transform.name == "BTN_PICTURE")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 6;
				}
			}
			break;
		}
		case 7:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray4 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray4, out RaycastHit hitInfo4))
			{
				if (hitInfo4.collider.transform.name == "BTN_CONTINUE")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 1;
				}
				if (hitInfo4.collider.transform.name == "BTN_RESTART")
				{
							print("BTN_RESTART");
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 1;
				}
				if (hitInfo4.collider.transform.name == "BTN_MENU")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 1;
				}
				if (hitInfo4.collider.transform.name == "BTN_PICTURE")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 8;
				}
			}
			break;
		}
		case 6:
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray5 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray5, out RaycastHit hitInfo5) && hitInfo5.collider.transform.name == "BTN_BACK")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 3;
				}
			}
			if (!Input.GetMouseButton(0))
			{
				break;
			}
			Ray ray6 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray6, out RaycastHit hitInfo6))
			{
				if (hitInfo6.collider.transform.name == "BTN_RIGHT")
				{
					Vector3 position = Camera.main.transform.position;
					if (position.x < 3.2f + stageLength)
					{
						Camera.main.transform.Translate(Camera.main.transform.right * 0.05f, Space.World);
					}
				}
				if (hitInfo6.collider.transform.name == "BTN_LEFT")
				{
					Vector3 position2 = Camera.main.transform.position;
					if (position2.x > -3.2f)
					{
						Camera.main.transform.Translate(-Camera.main.transform.right * 0.05f, Space.World);
					}
				}
			}
			TIMER_cinemaControlState = Time.realtimeSinceStartup + 1f;
			cinemaControlState = 2;
			break;
		}
		case 8:
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray7 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray7, out RaycastHit hitInfo7) && hitInfo7.collider.transform.name == "BTN_BACK")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 7;
				}
				TIMER_cinemaControlState = Time.realtimeSinceStartup + 1f;
				cinemaControlState = 3;
			}
			break;
		case 9:
			if (Input.GetMouseButtonDown(0) && GameScriptsManager.loading == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.transform.name == "BTN_CONTINUE")
				{
						//print("restart clicked");
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					hintState = 1;
					state = 2;

                    }
                }
			break;
		}
		if (state == 6 || state == 8)
		{
			if (pauseButton.active)
			{
				pauseButton.SetActiveRecursively(state: false);
			}
			if (!logo.active)
			{
				Transform transform = logo.transform;
				Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));
				transform.position = new Vector3(vector.x - 1.3f, -1.1f, -8f);
				logo.SetActiveRecursively(state: true);
			}
		}
		else
		{
			if (!pauseButton.active)
			{
				pauseButton.SetActiveRecursively(state: true);
			}
			if (logo.active)
			{
				logo.SetActiveRecursively(state: false);
			}
		}
	}

	private void TutorialMode()
	{
		TutorialModeButton();
		switch (state)
		{
		case 6:
		case 7:
			break;
		case 0:
			miscScreenState = 2;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				championDisplayState = 0;
				scoreScreenState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				TOGGLE_state = state;
			}
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 3;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		case 2:
			if (TOGGLE_state != state)
			{
				AudioListener.pause = false;
				audioPauseState = 0;
				Time.timeScale = 1f;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 3;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 1;
				TOGGLE_state = state;
			}
			break;
		case 3:
			miscScreenState = 1;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = true;
				audioPauseState = 1;
				Time.timeScale = 0f;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		case 4:
			if (gameMasterControl.tutorialMode == 1)
			{
				state = 2;
				TOGGLE_state = state;
			}
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				audioPauseState = 0;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 2;
				TOGGLE_state = state;
			}
			break;
		case 5:
			miscScreenState = 1;
			if (TOGGLE_state != state)
			{
				AudioListener.pause = true;
				audioPauseState = 1;
				Time.timeScale = 0f;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		case 8:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				AudioListener.pause = true;
				audioPauseState = 1;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		case 9:
			if (TOGGLE_state != state)
			{
				Time.timeScale = 0f;
				AudioListener.pause = true;
				audioPauseState = 1;
				continueButtonState = 0;
				waveNumberDisplayState = 0;
				manaDisplayState = 0;
				spellButtonState = 0;
				itemButtonState = 0;
				shopState = 0;
				levelIconState = 0;
				miscScreenState = 0;
				cinemaControlState = 0;
				hintState = 0;
				TOGGLE_state = state;
			}
			break;
		}
	}

	private void TutorialModeButton()
	{
		switch (state)
		{
		case 1:
			if (Input.GetMouseButtonDown(0) && GameScriptsManager.loading == 0)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray2, out RaycastHit hitInfo2) && hitInfo2.collider.transform.name == "BTN_PAUSE" && Time.timeScale == 1f)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 5;
				}
			}
			break;
		case 2:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray5 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray5, out RaycastHit hitInfo5))
			{
				if (hitInfo5.collider.transform.name == "BTN_PAUSE" && Time.timeScale == 1f)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 3;
				}
				if (hitInfo5.collider.transform.name == "BTN_HINT")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 4;
				}
			}
			break;
		}
		case 3:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray7 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray7, out RaycastHit hitInfo7))
			{
				if (hitInfo7.collider.transform.name == "BTN_CONTINUE")
				{
                            //print("restart clicked");

                            Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 2;
				}
				if (hitInfo7.collider.transform.name == "BTN_RESTART")
				{
                            print("BTN_RESTART");

                            Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 2;
				}
				if (hitInfo7.collider.transform.name == "BTN_MENU")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 2;
				}
				if (hitInfo7.collider.transform.name == "BTN_PICTURE")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 8;
				}
			}
			break;
		}
		case 4:
			if (Input.GetMouseButtonDown(0) && GameScriptsManager.loading == 0)
			{
				Ray ray3 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray3, out RaycastHit hitInfo3) && hitInfo3.collider.transform.name == "BTN_CONTINUE")
				{
                        //print("restart clicked");

                        Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 2;
				}
			}
			break;
		case 5:
		{
			if (!Input.GetMouseButtonDown(0) || GameScriptsManager.loading != 0)
			{
				break;
			}
			Ray ray4 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray4, out RaycastHit hitInfo4))
			{
				if (hitInfo4.collider.transform.name == "BTN_CONTINUE")
				{
                            //print("restart clicked");

                            Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 1;
				}
				if (hitInfo4.collider.transform.name == "BTN_RESTART")
				{
                            print("BTN_RESTART");

                            Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 1;
				}
				if (hitInfo4.collider.transform.name == "BTN_MENU")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 1;
				}
				if (hitInfo4.collider.transform.name == "BTN_PICTURE")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 9;
				}
			}
			break;
		}
		case 8:
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray6 = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray6, out RaycastHit hitInfo6) && hitInfo6.collider.transform.name == "BTN_BACK")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 3;
				}
				TIMER_cinemaControlState = Time.realtimeSinceStartup + 1f;
				cinemaControlState = 3;
			}
			break;
		case 9:
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.transform.name == "BTN_BACK")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(clickClip);
					state = 5;
				}
				TIMER_cinemaControlState = Time.realtimeSinceStartup + 1f;
				cinemaControlState = 3;
			}
			break;
		}
		if (state == 8 || state == 9)
		{
			if (pauseButton.active)
			{
				pauseButton.SetActiveRecursively(state: false);
			}
			if (!logo.active)
			{
				Transform transform = logo.transform;
				Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));
				transform.position = new Vector3(vector.x - 1.3f, -1.1f, -8f);
				logo.SetActiveRecursively(state: true);
			}
		}
		else
		{
			if (!pauseButton.active)
			{
				pauseButton.SetActiveRecursively(state: true);
			}
			if (logo.active)
			{
				logo.SetActiveRecursively(state: false);
			}
		}
	}

	private void cinemaControlFunction()
	{
		if (cinemaControlState > 0)
		{
			if (!cinemaControlHUD.active)
			{
				cinemaControlHUD.SetActiveRecursively(state: true);
			}
		}
		else if (cinemaControlHUD.active)
		{
			cinemaControlHUD.SetActiveRecursively(state: false);
		}
		switch (cinemaControlState)
		{
		case -1:
			VECTORON_cinemaControlHUD = Vector3.zero;
			VECTOROFF_cinemaControlHUD = new Vector3(0f, -10f, 0f);
			cinemaControlState++;
			break;
		case 0:
			if (cinemaControlHUD.transform.localPosition != VECTOROFF_cinemaControlHUD)
			{
				cinemaControlHUD.transform.localPosition = VECTOROFF_cinemaControlHUD;
			}
			if (!cinemaControlArrowHUD.active)
			{
				cinemaControlArrowHUD.SetActiveRecursively(state: true);
			}
			break;
		case 1:
			if (cinemaControlHUD.transform.localPosition != VECTOROFF_cinemaControlHUD)
			{
				cinemaControlHUD.transform.localPosition = Vector3.Lerp(cinemaControlHUD.transform.localPosition, VECTOROFF_cinemaControlHUD, 0.05f);
			}
			break;
		case 2:
			if (Time.realtimeSinceStartup >= TIMER_cinemaControlState)
			{
				cinemaControlState = 1;
			}
			if (cinemaControlHUD.transform.localPosition != VECTORON_cinemaControlHUD)
			{
				cinemaControlHUD.transform.localPosition = Vector3.Lerp(cinemaControlHUD.transform.localPosition, VECTORON_cinemaControlHUD, 0.2f);
			}
			break;
		case 3:
			if (Time.realtimeSinceStartup >= TIMER_cinemaControlState)
			{
				cinemaControlState = 1;
			}
			if (cinemaControlArrowHUD.active)
			{
				cinemaControlArrowHUD.SetActiveRecursively(state: false);
			}
			if (cinemaControlHUD.transform.localPosition != VECTORON_cinemaControlHUD)
			{
				cinemaControlHUD.transform.localPosition = Vector3.Lerp(cinemaControlHUD.transform.localPosition, VECTORON_cinemaControlHUD, 0.2f);
			}
			break;
		}
	}

	private void ScoreDisplayFunction()
	{
		switch (scoreScreenState)
		{
		case 0:
			if (scriptScoreScreenControl.state != 0)
			{
				scriptScoreScreenControl.state = 0;
			}
			if (TOGGLE_scoreScreenState != scoreScreenState)
			{
				TOGGLE_scoreScreenState = scoreScreenState;
			}
			break;
		case 1:
			if (TOGGLE_scoreScreenState != scoreScreenState)
			{
				scriptScoreScreenControl.StateFunction(scoreScreenToggle, scoreScreenRankMedal, scoreScreenNumberOfGuards, scoreScreenNumberOfGuardsRemaining, scoreScreenCurrencyGained, scoreScreenWavesCompleted, scoreScreenNewBestState, scoreScreenObjectAverageGrade, scoreScreenSpellAverageGrade);
				TOGGLE_scoreScreenState = scoreScreenState;
			}
			break;
		}
	}

	private void ChampionDisplayFunction()
	{
		switch (championDisplayState)
		{
		case 0:
			if (scriptChampionHUD.state != 0)
			{
				scriptChampionHUD.state = 0;
			}
			break;
		case 1:
			if (scriptChampionHUD.state != 1)
			{
				scriptChampionHUD.ActivationFunction(1, championDisplaySpeechType, championDisplayPortraitID, championDisplayWarningQuote, championDisplayIntroductionSpeech, championDisplayChampionName);
				scriptChampionHUD.state = 1;
			}
			if (unitControl != null)
			{
				scriptChampionHUD.scriptUnitControl = unitControl;
				unitControl = null;
			}
			break;
		}
	}

	private void WaveDisplayFunction()
	{
		switch (waveNumberDisplayState)
		{
		case -1:
		{
					print("waveNumberDisplayHUD -1");
			waveNumberDisplayPopEffect = waveNumberDisplayHUD.GetComponent<pop_effect>();
			Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
			float num = vector.x + 0.75f;
			Vector3 position = Camera.main.transform.position;
			VECTORON_waveNumberDisplayHUD = new Vector3(num - position.x, 2.5f, 4f);
			Vector3 vector2 = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
			float num2 = vector2.x + 0.75f;
			Vector3 position2 = Camera.main.transform.position;
			VECTOROFF_waveNumberDisplayHUD = new Vector3(num2 - position2.x, 12.5f, 4f);
			waveNumberDisplayState++;
			break;
		}
		case 0:
			if (TOGGLE_waveNumberDisplayState != waveNumberDisplayState)
			{
				TOGGLE_waveNumberDisplayState = waveNumberDisplayState;
			}
			if (waveNumberDisplayHUD.transform.localPosition != VECTOROFF_waveNumberDisplayHUD)
			{
                    print("waveNumberDisplayHUD 0");
                    MainCanvas.SetActive(false);
                    waveNumberDisplayHUD.transform.localPosition = Vector3.Lerp(waveNumberDisplayHUD.transform.localPosition, VECTOROFF_waveNumberDisplayHUD, 0.2f);
			}
			break;
		case 1:
			if (waveNumberDisplayHUD.transform.localPosition != VECTORON_waveNumberDisplayHUD)
			{
                   
                    waveNumberDisplayHUD.transform.localPosition = Vector3.Lerp(waveNumberDisplayHUD.transform.localPosition, VECTORON_waveNumberDisplayHUD, 0.2f);
                    print(" yahi h apna kaam waveNumberDisplayHUD 1");
					if (!isRestartClicket)
                        MainCanvas.SetActive(true);


                }
                if (TOGGLE_waveNumber != waveNumber)
			{
				if (waveNumber >= 100)
				{
					wavesNumberTenth.Play("#9");
					wavesNumberOneth.Play("#9");
				}
				else if (waveNumber < 100 && waveNumber >= 10)
				{
					STRING_waveNumber = string.Empty + waveNumber;
					wavesNumberTenth.Play("#" + STRING_waveNumber[0]);
					wavesNumberOneth.Play("#" + STRING_waveNumber[1]);
				}
				else if (waveNumber < 10 && waveNumber >= 1)
				{
					STRING_waveNumber = "0" + waveNumber;
					wavesNumberTenth.Play("#0");
					wavesNumberOneth.Play("#" + STRING_waveNumber[1]);
				}
				else
				{
					wavesNumberTenth.Play("#0");
					wavesNumberOneth.Play("#0");
				}
				waveNumberDisplayPopEffect.activate = true;
				TOGGLE_waveNumber = waveNumber;
			}
			break;
		}
	}

	private void ManaDisplayFunction()
	{
		switch (manaDisplayState)
		{
		case -1:
		{
			manaNumberDisplayPopEffect = manaNumberDisplayHUD.GetComponent<pop_effect>();
			VECTORON_manaNumberDisplayHUD = manaNumberDisplayHUD.transform.localPosition;
			Vector3 localPosition = manaNumberDisplayHUD.transform.localPosition;
			float x = localPosition.x;
			Vector3 localPosition2 = manaNumberDisplayHUD.transform.localPosition;
			float y = localPosition2.y - 10f;
			Vector3 localPosition3 = manaNumberDisplayHUD.transform.localPosition;
			VECTOROFF_manaNumberDisplayHUD = new Vector3(x, y, localPosition3.z);
			manaDisplayState++;
			break;
		}
		case 0:
			if (manaNumberDisplayHUD.transform.localPosition != VECTOROFF_manaNumberDisplayHUD)
			{
				manaNumberDisplayHUD.transform.localPosition = Vector3.Lerp(manaNumberDisplayHUD.transform.localPosition, VECTOROFF_manaNumberDisplayHUD, 0.2f);
				TOGGLE_manaNumber = -1;
			}
			break;
		case 1:
			if (manaNumberDisplayHUD.transform.localPosition != VECTORON_manaNumberDisplayHUD)
			{
				manaNumberDisplayHUD.transform.localPosition = Vector3.Lerp(manaNumberDisplayHUD.transform.localPosition, VECTORON_manaNumberDisplayHUD, 0.2f);
			}
			if (TOGGLE_manaNumber == manaNumber)
			{
				break;
			}
			if (manaNumber < maxManaNumber && manaNumber > 0)
			{
				if (manaNumberText.color != COLOR_manaNumber)
				{
					manaNumberText.color = COLOR_manaNumber;
				}
				manaNumberText.text = string.Empty + manaNumber;
				manaNumberText.Commit();
			}
			else if (manaNumber >= maxManaNumber)
			{
				if (manaNumberText.color != COLOR_manaMaxNumber)
				{
					manaNumberText.color = COLOR_manaMaxNumber;
				}
				manaNumber = maxManaNumber;
				manaNumberText.text = string.Empty + manaNumber;
				manaNumberText.Commit();
			}
			else if (manaNumber <= 0)
			{
				manaNumberText.color = COLOR_manaNoneNumber;
				manaNumber = 0;
				manaNumberText.text = "0";
				manaNumberText.Commit();
			}
			manaNumberDisplayPopEffect.activate = true;
			TOGGLE_manaNumber = manaNumber;
			break;
		}
	}

	private void SpellHUDFunction()
	{
		switch (spellButtonState)
		{
		case -1:
		{
			VECTORON_spellButtonHUD = spellButtonHUD.transform.localPosition;
			Vector3 localPosition = spellButtonHUD.transform.localPosition;
			float x = localPosition.x;
			Vector3 localPosition2 = spellButtonHUD.transform.localPosition;
			float y = localPosition2.y - 10f;
			Vector3 localPosition3 = spellButtonHUD.transform.localPosition;
			VECTOROFF_spellButtonHUD = new Vector3(x, y, localPosition3.z);
			spellButtonState++;
			break;
		}
		case 0:
			if (spellButtonHUD.transform.localPosition != VECTOROFF_spellButtonHUD)
			{
				spellButtonHUD.transform.localPosition = Vector3.Lerp(spellButtonHUD.transform.localPosition, VECTOROFF_spellButtonHUD, 0.2f);
			}
			break;
		case 1:
			switch (itemIconState)
			{
			case 0:
				if (spellButtonHUD.transform.localPosition != new Vector3(VECTORON_spellButtonHUD.x + 0.52f, VECTORON_spellButtonHUD.y, VECTORON_spellButtonHUD.z))
				{
					spellButtonHUD.transform.localPosition = Vector3.Lerp(spellButtonHUD.transform.localPosition, new Vector3(VECTORON_spellButtonHUD.x + 0.52f, VECTORON_spellButtonHUD.y, VECTORON_spellButtonHUD.z), 0.2f);
				}
				break;
			case 1:
				if (spellButtonHUD.transform.localPosition != new Vector3(VECTORON_spellButtonHUD.x + 0.26f, VECTORON_spellButtonHUD.y, VECTORON_spellButtonHUD.z))
				{
					spellButtonHUD.transform.localPosition = Vector3.Lerp(spellButtonHUD.transform.localPosition, new Vector3(VECTORON_spellButtonHUD.x + 0.26f, VECTORON_spellButtonHUD.y, VECTORON_spellButtonHUD.z), 0.2f);
				}
				break;
			case 2:
				if (spellButtonHUD.transform.localPosition != new Vector3(VECTORON_spellButtonHUD.x + 0.26f, VECTORON_spellButtonHUD.y, VECTORON_spellButtonHUD.z))
				{
					spellButtonHUD.transform.localPosition = Vector3.Lerp(spellButtonHUD.transform.localPosition, new Vector3(VECTORON_spellButtonHUD.x + 0.26f, VECTORON_spellButtonHUD.y, VECTORON_spellButtonHUD.z), 0.2f);
				}
				break;
			case 3:
				if (spellButtonHUD.transform.localPosition != VECTORON_spellButtonHUD)
				{
					spellButtonHUD.transform.localPosition = Vector3.Lerp(spellButtonHUD.transform.localPosition, VECTORON_spellButtonHUD, 0.2f);
				}
				break;
			}
			break;
		}
	}

	private void itemHUDFunction()
	{
		switch (itemButtonState)
		{
		case -1:
		{
			VECTORON_itemButtonHUD = itemButtonHUD.transform.localPosition;
			Vector3 localPosition4 = itemButtonHUD.transform.localPosition;
			float x2 = localPosition4.x;
			Vector3 localPosition5 = itemButtonHUD.transform.localPosition;
			float y2 = localPosition5.y - 10f;
			Vector3 localPosition6 = itemButtonHUD.transform.localPosition;
			VECTOROFF_itemButtonHUD = new Vector3(x2, y2, localPosition6.z);
			Vector3 localPosition7 = itemButtonHUD.transform.localPosition;
			float y3 = localPosition7.y;
			Vector3 localPosition8 = itemButtonHUD.transform.localPosition;
			VECTORON2_itemButtonHUD = new Vector3(-0.51f, y3, localPosition8.z);
			VECTORON_itemIconOne = itemIconOne.transform.localPosition;
			Vector3 localPosition9 = itemIconOne.transform.localPosition;
			float x3 = localPosition9.x;
			Vector3 localPosition10 = itemIconOne.transform.localPosition;
			float y4 = localPosition10.y - 5f;
			Vector3 localPosition11 = itemIconOne.transform.localPosition;
			VECTOROFF_itemIconOne = new Vector3(x3, y4, localPosition11.z);
			VECTORON_itemIconTwo = itemIconTwo.transform.localPosition;
			Vector3 localPosition12 = itemIconTwo.transform.localPosition;
			float x4 = localPosition12.x;
			Vector3 localPosition13 = itemIconTwo.transform.localPosition;
			float y5 = localPosition13.y - 5f;
			Vector3 localPosition14 = itemIconTwo.transform.localPosition;
			VECTOROFF_itemIconTwo = new Vector3(x4, y5, localPosition14.z);
			itemButtonState++;
			break;
		}
		case 0:
			if (itemButtonHUD.transform.localPosition != VECTOROFF_itemButtonHUD)
			{
				itemButtonHUD.transform.localPosition = Vector3.Lerp(itemButtonHUD.transform.localPosition, VECTOROFF_itemButtonHUD, 0.2f);
			}
			break;
		case 2:
		{
			Vector3 localPosition = itemButtonHUD.transform.localPosition;
			if (localPosition.y < -9f)
			{
				Transform transform = itemButtonHUD.transform;
				float x = VECTORON2_itemButtonHUD.x;
				Vector3 localPosition2 = itemButtonHUD.transform.localPosition;
				float y = localPosition2.y;
				Vector3 localPosition3 = itemButtonHUD.transform.localPosition;
				transform.localPosition = new Vector3(x, y, localPosition3.z);
			}
			if (itemButtonHUD.transform.localPosition != VECTORON2_itemButtonHUD)
			{
				itemButtonHUD.transform.localPosition = Vector3.Lerp(itemButtonHUD.transform.localPosition, VECTORON2_itemButtonHUD, 0.2f);
			}
			itemIconState = -1;
			break;
		}
		}
		switch (itemIconState)
		{
		case -1:
			if (itemIconOne.transform.localPosition != VECTORON_itemIconOne)
			{
				itemIconOne.transform.localPosition = VECTORON_itemIconOne;
			}
			if (itemIconTwo.transform.localPosition != VECTORON_itemIconTwo)
			{
				itemIconTwo.transform.localPosition = VECTORON_itemIconTwo;
			}
			if (itemButtonState != 2)
			{
				itemIconState = 3;
			}
			break;
		case 0:
			if (itemButtonHUD.transform.localPosition != new Vector3(VECTORON_itemButtonHUD.x + 0.52f, VECTORON_itemButtonHUD.y, VECTORON_itemButtonHUD.z))
			{
				itemButtonHUD.transform.localPosition = Vector3.Lerp(itemButtonHUD.transform.localPosition, new Vector3(VECTORON_itemButtonHUD.x + 0.52f, VECTORON_itemButtonHUD.y, VECTORON_itemButtonHUD.z), 0.2f);
			}
			if (itemIconOne.transform.localPosition != VECTOROFF_itemIconOne)
			{
				itemIconOne.transform.localPosition = Vector3.Lerp(itemIconOne.transform.localPosition, VECTOROFF_itemIconOne, 0.1f);
			}
			if (itemIconTwo.transform.localPosition != VECTOROFF_itemIconTwo)
			{
				itemIconTwo.transform.localPosition = Vector3.Lerp(itemIconTwo.transform.localPosition, VECTOROFF_itemIconTwo, 0.1f);
			}
			break;
		case 1:
			if (itemButtonHUD.transform.localPosition != new Vector3(VECTORON_itemButtonHUD.x + 0.26f, VECTORON_itemButtonHUD.y, VECTORON_itemButtonHUD.z))
			{
				itemButtonHUD.transform.localPosition = Vector3.Lerp(itemButtonHUD.transform.localPosition, new Vector3(VECTORON_itemButtonHUD.x + 0.26f, VECTORON_itemButtonHUD.y, VECTORON_itemButtonHUD.z), 0.2f);
			}
			if (itemIconOne.transform.localPosition != VECTORON_itemIconOne)
			{
				itemIconOne.transform.localPosition = Vector3.Lerp(itemIconOne.transform.localPosition, VECTORON_itemIconOne, 0.2f);
			}
			if (itemIconTwo.transform.localPosition != VECTOROFF_itemIconTwo)
			{
				itemIconTwo.transform.localPosition = Vector3.Lerp(itemIconTwo.transform.localPosition, VECTOROFF_itemIconTwo, 0.1f);
			}
			break;
		case 2:
			if (itemButtonHUD.transform.localPosition != new Vector3(VECTORON_itemButtonHUD.x - 0.69f, VECTORON_itemButtonHUD.y, VECTORON_itemButtonHUD.z))
			{
				itemButtonHUD.transform.localPosition = Vector3.Lerp(itemButtonHUD.transform.localPosition, new Vector3(VECTORON_itemButtonHUD.x - 0.69f, VECTORON_itemButtonHUD.y, VECTORON_itemButtonHUD.z), 0.2f);
			}
			if (itemIconOne.transform.localPosition != VECTOROFF_itemIconOne)
			{
				itemIconOne.transform.localPosition = Vector3.Lerp(itemIconOne.transform.localPosition, VECTOROFF_itemIconOne, 0.2f);
			}
			if (itemIconTwo.transform.localPosition != VECTORON_itemIconTwo)
			{
				itemIconTwo.transform.localPosition = Vector3.Lerp(itemIconTwo.transform.localPosition, VECTORON_itemIconTwo, 0.1f);
			}
			break;
		case 3:
			if (itemButtonHUD.transform.localPosition != VECTORON_itemButtonHUD)
			{
				itemButtonHUD.transform.localPosition = Vector3.Lerp(itemButtonHUD.transform.localPosition, VECTORON_itemButtonHUD, 0.2f);
			}
			if (itemIconOne.transform.localPosition != VECTORON_itemIconOne)
			{
				itemIconOne.transform.localPosition = Vector3.Lerp(itemIconOne.transform.localPosition, VECTORON_itemIconOne, 0.2f);
			}
			if (itemIconTwo.transform.localPosition != VECTORON_itemIconTwo)
			{
				itemIconTwo.transform.localPosition = Vector3.Lerp(itemIconTwo.transform.localPosition, VECTORON_itemIconTwo, 0.2f);
			}
			break;
		}
	}

	private void shopHUDFunction()
	{
		switch (shopState)
		{
		case -1:
		{
			VECTORON_shopButtonHUD = shopButtonHUD.transform.localPosition;
			Vector3 localPosition = shopButtonHUD.transform.localPosition;
			float x = localPosition.x;
			Vector3 localPosition2 = shopButtonHUD.transform.localPosition;
			float y = localPosition2.y + 10f;
			Vector3 localPosition3 = shopButtonHUD.transform.localPosition;
			VECTOROFF_shopButtonHUD = new Vector3(x, y, localPosition3.z);
			Vector3 localPosition4 = shopMenuHUD.transform.localPosition;
			float x2 = localPosition4.x;
			Vector3 localPosition5 = shopMenuHUD.transform.localPosition;
			VECTORON_shopMenuHUD = new Vector3(x2, localPosition5.y, 3f);
			Vector3 localPosition6 = shopMenuHUD.transform.localPosition;
			float x3 = localPosition6.x;
			Vector3 localPosition7 = shopMenuHUD.transform.localPosition;
			VECTOROFF_shopMenuHUD = new Vector3(x3, localPosition7.y + 10f, 3f);
			Vector3 localPosition8 = currencyHUD.transform.localPosition;
			float x4 = localPosition8.x;
			Vector3 localPosition9 = currencyHUD.transform.localPosition;
			VECTORON_currencyHUD = new Vector3(x4, localPosition9.y, 1.75f);
			Vector3 localPosition10 = currencyHUD.transform.localPosition;
			float x5 = localPosition10.x;
			Vector3 localPosition11 = currencyHUD.transform.localPosition;
			VECTOROFF_currencyHUD = new Vector3(x5, localPosition11.y - 10f, 1.75f);
			shopState++;
			break;
		}
		case 0:
			if (shopButtonHUD.transform.localPosition != VECTOROFF_shopButtonHUD)
			{
				shopButtonHUD.transform.localPosition = Vector3.Lerp(shopButtonHUD.transform.localPosition, VECTOROFF_shopButtonHUD, 0.2f);
			}
			if (shopMenuHUD.transform.localPosition != VECTOROFF_shopMenuHUD)
			{
				shopMenuHUD.transform.localPosition = Vector3.Lerp(shopMenuHUD.transform.localPosition, VECTOROFF_shopMenuHUD, 0.2f);
			}
			if (currencyHUD.transform.localPosition != VECTOROFF_currencyHUD)
			{
				currencyHUD.transform.localPosition = Vector3.Lerp(currencyHUD.transform.localPosition, VECTOROFF_currencyHUD, 0.2f);
			}
			break;
		case 1:
			if (shopButtonHUD.transform.localPosition != VECTORON_shopButtonHUD)
			{
				shopButtonHUD.transform.localPosition = Vector3.Lerp(shopButtonHUD.transform.localPosition, VECTORON_shopButtonHUD, 0.2f);
			}
			if (shopMenuHUD.transform.localPosition != VECTOROFF_shopMenuHUD)
			{
				shopMenuHUD.transform.localPosition = Vector3.Lerp(shopMenuHUD.transform.localPosition, VECTOROFF_shopMenuHUD, 0.2f);
			}
			if (currencyHUD.transform.localPosition != VECTOROFF_currencyHUD)
			{
				currencyHUD.transform.localPosition = Vector3.Lerp(currencyHUD.transform.localPosition, VECTOROFF_currencyHUD, 0.2f);
			}
			break;
		case 2:
			if (shopButtonHUD.transform.localPosition != VECTOROFF_shopButtonHUD)
			{
				shopButtonHUD.transform.localPosition = Vector3.Lerp(shopButtonHUD.transform.localPosition, VECTOROFF_shopButtonHUD, 0.2f);
			}
			if (shopMenuHUD.transform.localPosition != VECTORON_shopMenuHUD)
			{
				shopMenuHUD.transform.localPosition = Vector3.Lerp(shopMenuHUD.transform.localPosition, VECTORON_shopMenuHUD, 0.2f);
			}
			if (currencyHUD.transform.localPosition != VECTORON_currencyHUD)
			{
				currencyHUD.transform.localPosition = Vector3.Lerp(currencyHUD.transform.localPosition, VECTORON_currencyHUD, 0.4f);
			}
			break;
		}
	}

	private void miscScreenFunction()
	{
		switch (miscScreenState)
		{
		case -1:
		{
			Transform transform = pauseScreen.transform;
			Vector3 localPosition = pauseScreen.transform.localPosition;
			transform.localPosition = new Vector3(0f, 0f, localPosition.z);
			miscScreenState++;
			break;
		}
		case 0:
			if (pauseScreen.active)
			{
				pauseScreen.SetActiveRecursively(state: false);
			}
			break;
		case 1:
			if (!pauseScreen.active)
			{
				pauseScreen.SetActiveRecursively(state: true);
			}
			if (mode == 2 && pauseRestartButton.active)
			{
					print("restart button clicked.");
                    MainCanvas.SetActive(false);
                    isRestartClicket = true;
                    pauseRestartButton.SetActiveRecursively(state: false);
					
			}
			break;
		case 2:
			if (pauseScreen.active)
			{
				pauseScreen.SetActiveRecursively(state: false);
			}
			break;
		}
	}

	private void continueHUDFunction()
	{
		if (continueButtonState > 0)
		{
			if (!continueButtonHUD.active)
			{
				continueButtonHUD.SetActiveRecursively(state: true);
			}
		}
		else if (continueButtonHUD.active)
		{
			continueButtonHUD.SetActiveRecursively(state: false);
		}
		switch (continueButtonState)
		{
		case -1:
		{
			VECTORON_continueButtonHUD = continueButtonHUD.transform.localPosition;
			Vector3 localPosition = continueButtonHUD.transform.localPosition;
			float x = localPosition.x + 20f;
			Vector3 localPosition2 = continueButtonHUD.transform.localPosition;
			float y = localPosition2.y;
			Vector3 localPosition3 = continueButtonHUD.transform.localPosition;
			VECTOROFF_continueButtonHUD = new Vector3(x, y, localPosition3.z);
			continueButtonState++;
			break;
		}
		case 0:
			if (continueButtonHUD.transform.localPosition != VECTOROFF_continueButtonHUD)
			{
				continueButtonHUD.transform.localPosition = Vector3.Lerp(continueButtonHUD.transform.localPosition, VECTOROFF_continueButtonHUD, 0.2f);
			}
			break;
		case 1:
			if (continueButtonHUD.transform.localPosition != VECTORON_continueButtonHUD)
			{
				continueButtonHUD.transform.localPosition = Vector3.Lerp(continueButtonHUD.transform.localPosition, VECTORON_continueButtonHUD, 0.2f);
			}
			break;
		}
	}

	private void LevelIconFunction()
	{
		switch (levelIconState)
		{
		case -1:
		{
			Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
			float num = vector.x + 2.3f;
			Vector3 position = Camera.main.transform.position;
			VECTORON_levelIconHUD = new Vector3(num - position.x, 2.6f, 4.3f);
			Vector3 vector2 = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
			float num2 = vector2.x + 2.3f;
			Vector3 position2 = Camera.main.transform.position;
			VECTOROFF_levelIconHUD = new Vector3(num2 - position2.x, 12.6f, 4.3f);
			levelIconState++;
			break;
		}
		case 0:
			if (levelIconHUD.transform.localPosition != VECTOROFF_levelIconHUD)
			{
				levelIconHUD.transform.localPosition = Vector3.Lerp(levelIconHUD.transform.localPosition, VECTOROFF_levelIconHUD, 0.2f);
				TOGGLE_weekNumber = -2;
				gameModeText.text = string.Empty;
			}
			break;
		case 1:
			if (levelIconHUD.transform.localPosition != VECTORON_levelIconHUD)
			{
				levelIconHUD.transform.localPosition = Vector3.Lerp(levelIconHUD.transform.localPosition, VECTORON_levelIconHUD, 0.2f);
			}
			if (gameModeText.text != "week")
			{
				levelIconSprite.color = new Color(1f, 0.5f, 0.5f, 1f);
				gameModeText.scale = new Vector3(2f, 2f, 2f);
				gameModeText.transform.localPosition = new Vector3(0f, -0.25f, 0f);
				gameModeText.text = "week";
				gameModeText.Commit();
			}
			if (TOGGLE_weekNumber != weekNumber)
			{
				weekNumberText.text = string.Empty + weekNumber;
				weekNumberText.Commit();
				TOGGLE_weekNumber = weekNumber;
			}
			break;
		case 2:
			if (levelIconHUD.transform.localPosition != VECTORON_levelIconHUD)
			{
				levelIconHUD.transform.localPosition = Vector3.Lerp(levelIconHUD.transform.localPosition, VECTORON_levelIconHUD, 0.2f);
			}
			if (gameModeText.text != "arena")
			{
				levelIconSprite.color = new Color(0.4f, 0.6f, 1f, 1f);
				gameModeText.scale = new Vector3(1.8f, 1.8f, 2f);
				gameModeText.transform.localPosition = new Vector3(0f, -0.06f, 0f);
				gameModeText.text = "arena";
				gameModeText.Commit();
			}
			if (TOGGLE_weekNumber != -1)
			{
				weekNumberText.text = string.Empty;
				weekNumberText.Commit();
				TOGGLE_weekNumber = -1;
			}
			break;
		case 3:
			if (levelIconHUD.transform.localPosition != VECTORON_levelIconHUD)
			{
				levelIconHUD.transform.localPosition = Vector3.Lerp(levelIconHUD.transform.localPosition, VECTORON_levelIconHUD, 0.2f);
			}
			if (gameModeText.text != "story")
			{
				levelIconSprite.color = new Color(0.4f, 1f, 0.4f, 1f);
				gameModeText.scale = new Vector3(1.8f, 1.8f, 2f);
				gameModeText.transform.localPosition = new Vector3(0f, -0.06f, 0f);
				gameModeText.text = "story";
				gameModeText.Commit();
			}
			if (TOGGLE_weekNumber != -1)
			{
				weekNumberText.text = string.Empty;
				weekNumberText.Commit();
				TOGGLE_weekNumber = -1;
			}
			break;
		}
	}

	private void HintHUDFunction()
	{
		if (hintState > 0)
		{
			if (!hintButton.active)
			{
				hintButton.SetActiveRecursively(state: true);
			}
			if (!hintImageObject.active)
			{
				hintImageObject.SetActiveRecursively(state: true);
			}
		}
		else
		{
			if (hintButton.active)
			{
				hintButton.SetActiveRecursively(state: false);
			}
			if (hintImageObject.active)
			{
				hintImageObject.SetActiveRecursively(state: false);
			}
		}
		if (TOGGLE_hintNumber != hintNumber)
		{
			if (hintNumber == -1)
			{
				hintImage.Play("blank");
				hintText.text = string.Empty;
			}
			else
			{
				hintImage.Play("hint_" + hintNumber);
				switch (hintNumber)
				{
				case 1:
					hintText.text = "OBJECTS:\ntap and hold onto objects to pick them up. aim the\ncursor at an enemy and let fly!\n";
					break;
				case 2:
					hintText.text = "MANA SHARDS:\ntap on the mana shards to pick them up,\nmana shards recover mana points.\n";
					break;
				case 3:
					hintText.text = "SPELLS:\nclick and drag a color button to the screen to unleash\na spell. spells require mana to cast and will need to\nrecharge after use.\n";
					break;
				case 4:
					hintText.text = "ITEMS:\ntap on the item button to use them. items enhance your\nattributes, magic, or units. items are located to the right\nof your spell buttons.\n";
					break;
				case 5:
					hintText.text = "GAME OF PUSH:\ndo anything you can to prevent any intruder from reaching\nyou. intruders will enter from the right and move towards\nthe left to bring you down.";
					break;
				case 6:
					hintText.text = "LEADERS:\na mob leader has entered the castle. in order to stop the\nintruders, you must force their leader to retreat. the mob\nleader's health is shown on the top of the screen.";
					break;
				case 7:
					hintText.text = "DAMAGE MULTIPLIER:\na consistent hit on a unit will multiply the damage they\nreceive. multiplier duration will not decrease plus\nmultiplier limit is increased while unit is stunned.";
					break;
				case 8:
					hintText.text = "WEAKNESSES:\ncertain units are weaker against specific types of damage.\n\nshort unit: short units are weak to falling objects.\nwood material: intruders with wood material are weak to fire.";
					break;
				case 9:
					hintText.text = "ARMOR UNITS:\narmor is strong against physical damage but weak against\nmagic damage.";
					break;
				case 10:
					hintText.text = "SHOP:\nthe shop is open! you may click on the shop button located\non the upper part of the screen to check out what they\nhave in stock. items will reroll after each wave.";
					break;
				case 11:
					hintText.text = "DRAGONS:\ndragons have tormented the populace for many generations.\nhowever, it was then discovered that dragons are\nafraid  of magic!";
					break;
				case 12:
					hintText.text = "WEAKNESSES:\ncertain units are weaker against specific types of damage.";
					break;
				case 13:
					hintText.text = "JINX VS JINX:\nmagic user are skilled with magic decreasing major damage\nfrom any magical damages they recieve. Fortunately they\nare weak against physical damages making them more\nvulnerable towards objects.";
					break;
				case 100:
					hintText.text = string.Empty;
					break;
				}
			}
			hintText.Commit();
			TOGGLE_hintNumber = hintNumber;
		}
		if (gameMasterControl.tutorialMode == 1 && hintState > 0)
		{
			hintState = 0;
		}
		switch (hintState)
		{
		case -1:
			VECTORON_hintButtonHUD = new Vector3(-0.8f, 2.61f, 2f);
			VECTOROFF_hintButtonHUD = new Vector3(-0.8f, 12.61f, 2f);
			VECTORON_hintImageObjectHUD = new Vector3(0f, 0f, 2f);
			VECTOROFF_hintImageObjectHUD = new Vector3(0f, -10f, 2f);
			hintState++;
			break;
		case 0:
			if (hintButton.transform.localPosition != VECTOROFF_hintButtonHUD)
			{
				hintButton.transform.localPosition = VECTOROFF_hintButtonHUD;
			}
			if (hintImageObject.transform.localPosition != VECTOROFF_hintImageObjectHUD)
			{
				hintNumber = -1;
				hintImageObject.transform.localPosition = VECTOROFF_hintImageObjectHUD;
			}
			break;
		case 1:
			if (Time.timeScale == 0f)
			{
				if (hintButton.transform.localPosition != VECTOROFF_hintButtonHUD)
				{
					hintButton.transform.localPosition = VECTOROFF_hintButtonHUD;
				}
			}
			else if (hintButton.transform.localPosition != VECTORON_hintButtonHUD)
			{
				hintButton.transform.localPosition = Vector3.Lerp(hintButton.transform.localPosition, VECTORON_hintButtonHUD, 0.2f);
			}
			if (hintImageObject.transform.localPosition != VECTOROFF_hintImageObjectHUD)
			{
				hintImageObject.transform.localPosition = Vector3.Lerp(hintImageObject.transform.localPosition, VECTOROFF_hintImageObjectHUD, 0.2f);
			}
			break;
		case 2:
			if (hintButton.transform.localPosition != VECTOROFF_hintButtonHUD)
			{
				hintButton.transform.localPosition = Vector3.Lerp(hintButton.transform.localPosition, VECTOROFF_hintButtonHUD, 0.2f);
			}
			if (hintImageObject.transform.localPosition != VECTORON_hintImageObjectHUD)
			{
				hintImageObject.transform.localPosition = Vector3.Lerp(hintImageObject.transform.localPosition, VECTORON_hintImageObjectHUD, 0.2f);
			}
			break;
		}
	}
}
