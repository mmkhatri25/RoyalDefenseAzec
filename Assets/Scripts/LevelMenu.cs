using System;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
	[Serializable]
	public class levelIcon
	{
		public tk2dTextMesh levelNumber;

		public tk2dAnimatedSprite ratingIcon;

		public Renderer levelHighlight;

		public Renderer levelLock;

		public int gameLevel;

		public pop_effect popEffect;
	}

	[Serializable]
	public class levelInfo
	{
		public int levelNumber;

		public int levelState;

		public int levelRating;

		public int gameLevel;
	}

	[Serializable]
	public class levelGroup
	{
		[Serializable]
		public class levelInfo
		{
			public int levelNumber;

			public int levelState;

			public int levelRating;

			public int gameLevel;
		}

		public string stageName;

		public levelInfo[] LevelInfo = new levelInfo[7];
	}

	private AudioClip regularClick;

	private AudioClip accessClick;

	private AudioClip deniedClick;

	public Game_Data data;

	public MenuTransition iconMenuTransition;

	public Stage_Control stageControlScript;

	public Menu_Logic menuLogic;

	private string loadPlayScene = "Load - LevelSetup";

	public int pageInfoState;

	public bool nextPage;

	public bool previousPage;

	private int pageNumbers;

	public int currentPage;

	private int TOGGLE_currentPage;

	public levelIcon[] LevelIcon = new levelIcon[7];

	public GameObject[] pageArrows;

	public tk2dTextMesh stageText;

	public tk2dSprite stageBackground;

	public GameObject backButton;

	private string characterID;

	private int currentLevel;

	private int toggleButtonNumber;

	private bool gameLoading;

	public levelInfo[] LevelInfo;

	public levelGroup[] LevelGroup = new levelGroup[3];

	private void Start()
	{
		data = ScriptsManager.dataScript;
		stageControlScript = ScriptsManager.stageControlScript;
		regularClick = ScriptsManager.audioClip[0];
		accessClick = ScriptsManager.audioClip[1];
		deniedClick = ScriptsManager.audioClip[2];
		if (PlayerPrefs.GetInt("WZlevelProgress") < 1)
		{
			backButton.SetActiveRecursively(state: false);
		}
	}

	private void LevelDataSetupFunction()
	{
		currentLevel = PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress");
		for (int i = 0; i < LevelInfo.Length; i++)
		{
			LevelInfo[i].levelNumber = i + 1;
			LevelInfo[i].gameLevel = i;
			if (i < currentLevel)
			{
				LevelInfo[i].levelState = 0;
			}
			else if (i > currentLevel)
			{
				LevelInfo[i].levelState = 1;
			}
			else if (i == currentLevel)
			{
				LevelInfo[i].levelState = 2;
			}
			LevelInfo[i].levelRating = PlayerPrefs.GetInt(data.selectedCharacterID + "levelRating" + i);
		}
	}

	private void LevelSetupFunction()
	{
		for (int i = 0; i < LevelInfo.Length; i++)
		{
			for (int j = 0; j < LevelGroup.Length; j++)
			{
				LevelGroup[j].stageName = stageControlScript.StageInfo[j].stageName;
				for (int k = 0; k < LevelGroup[j].LevelInfo.Length; k++)
				{
					LevelGroup[j].LevelInfo[k].levelNumber = LevelInfo[i].levelNumber;
					LevelGroup[j].LevelInfo[k].levelState = LevelInfo[i].levelState;
					LevelGroup[j].LevelInfo[k].levelRating = LevelInfo[i].levelRating;
					LevelGroup[j].LevelInfo[k].gameLevel = LevelInfo[i].gameLevel;
					if (LevelGroup[j].LevelInfo[k].levelState == 2)
					{
						currentPage = j;
					}
					i++;
				}
			}
		}
		pageNumbers = LevelGroup.Length - 1;
		if (currentPage == 0)
		{
			if (pageArrows[0].active)
			{
				pageArrows[0].SetActiveRecursively(state: false);
			}
			if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") > data.gameLevelPerStage - 1)
			{
				if (!pageArrows[1].active)
				{
					pageArrows[1].SetActiveRecursively(state: true);
				}
			}
			else if (pageArrows[1].active)
			{
				pageArrows[1].SetActiveRecursively(state: false);
			}
		}
		else if (currentPage == pageNumbers)
		{
			if (pageArrows[1].active || !pageArrows[0].active)
			{
				pageArrows[1].SetActiveRecursively(state: false);
				pageArrows[0].SetActiveRecursively(state: true);
			}
		}
		else
		{
			if (currentPage == 0 || currentPage == pageNumbers)
			{
				return;
			}
			if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") > data.gameLevelPerStage * 2 - 1)
			{
				if (!pageArrows[0].active || !pageArrows[1].active)
				{
					pageArrows[0].SetActiveRecursively(state: true);
					pageArrows[1].SetActiveRecursively(state: true);
				}
			}
			else if (pageArrows[1].active || !pageArrows[0].active)
			{
				pageArrows[1].SetActiveRecursively(state: false);
				pageArrows[0].SetActiveRecursively(state: true);
			}
		}
	}

	private void SelectionArrowFunction()
	{
		if (nextPage)
		{
			if (pageNumbers == 0)
			{
				if (pageArrows[0].active || pageArrows[1].active)
				{
					pageArrows[0].SetActiveRecursively(state: false);
					pageArrows[1].SetActiveRecursively(state: false);
				}
			}
			else if (currentPage + 1 == 0)
			{
				if (pageArrows[0].active)
				{
					pageArrows[0].SetActiveRecursively(state: false);
				}
				if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") > data.gameLevelPerStage - 1)
				{
					if (!pageArrows[1].active)
					{
						pageArrows[1].SetActiveRecursively(state: true);
					}
				}
				else if (pageArrows[1].active)
				{
					pageArrows[1].SetActiveRecursively(state: false);
				}
			}
			else if (currentPage + 1 == pageNumbers)
			{
				if (pageArrows[1].active || !pageArrows[0].active)
				{
					pageArrows[1].SetActiveRecursively(state: false);
					pageArrows[0].SetActiveRecursively(state: true);
				}
			}
			else
			{
				if (currentPage + 1 == 0 || currentPage + 1 == pageNumbers)
				{
					return;
				}
				if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") > data.gameLevelPerStage * 2 - 1)
				{
					if (!pageArrows[0].active || !pageArrows[1].active)
					{
						pageArrows[0].SetActiveRecursively(state: true);
						pageArrows[1].SetActiveRecursively(state: true);
					}
				}
				else if (pageArrows[1].active || !pageArrows[0].active)
				{
					pageArrows[1].SetActiveRecursively(state: false);
					pageArrows[0].SetActiveRecursively(state: true);
				}
			}
		}
		else
		{
			if (!previousPage)
			{
				return;
			}
			if (pageNumbers == 0)
			{
				if (pageArrows[0].active || pageArrows[1].active)
				{
					pageArrows[0].SetActiveRecursively(state: false);
					pageArrows[1].SetActiveRecursively(state: false);
				}
			}
			else if (currentPage - 1 == 0)
			{
				if (pageArrows[0].active)
				{
					pageArrows[0].SetActiveRecursively(state: false);
				}
				if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") > data.gameLevelPerStage - 1)
				{
					if (!pageArrows[1].active)
					{
						pageArrows[1].SetActiveRecursively(state: true);
					}
				}
				else if (pageArrows[1].active)
				{
					pageArrows[1].SetActiveRecursively(state: false);
				}
			}
			else if (currentPage - 1 == pageNumbers)
			{
				if (pageArrows[1].active || !pageArrows[0].active)
				{
					pageArrows[1].SetActiveRecursively(state: false);
					pageArrows[0].SetActiveRecursively(state: true);
				}
			}
			else
			{
				if (currentPage - 1 == 0 || currentPage - 1 == pageNumbers)
				{
					return;
				}
				if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") > data.gameLevelPerStage * 2 - 1)
				{
					if (!pageArrows[0].active || !pageArrows[1].active)
					{
						pageArrows[0].SetActiveRecursively(state: true);
						pageArrows[1].SetActiveRecursively(state: true);
					}
				}
				else if (pageArrows[1].active || !pageArrows[0].active)
				{
					pageArrows[1].SetActiveRecursively(state: false);
					pageArrows[0].SetActiveRecursively(state: true);
				}
			}
		}
	}

	private void LevelSelectionSetupFunction()
	{
		SelectionArrowFunction();
		for (int i = 0; i < LevelInfo.Length; i++)
		{
			for (int j = 0; j < LevelGroup.Length; j++)
			{
				LevelGroup[j].stageName = stageControlScript.StageInfo[j].stageName;
			}
		}
		for (int k = 0; k < LevelGroup[currentPage].LevelInfo.Length; k++)
		{
			switch (LevelGroup[currentPage].LevelInfo[k].levelState)
			{
			case 0:
				LevelIcon[k].levelNumber.text = string.Empty + LevelGroup[currentPage].LevelInfo[k].levelNumber;
				LevelIcon[k].levelNumber.Commit();
				LevelIcon[k].ratingIcon.Play("r" + LevelGroup[currentPage].LevelInfo[k].levelRating);
				LevelIcon[k].levelHighlight.enabled = false;
				LevelIcon[k].levelLock.enabled = false;
				LevelIcon[k].gameLevel = LevelGroup[currentPage].LevelInfo[k].gameLevel;
				break;
			case 1:
				LevelIcon[k].levelNumber.text = string.Empty + LevelGroup[currentPage].LevelInfo[k].levelNumber;
				LevelIcon[k].levelNumber.Commit();
				LevelIcon[k].ratingIcon.Play("r" + LevelGroup[currentPage].LevelInfo[k].levelRating);
				LevelIcon[k].levelHighlight.enabled = false;
				LevelIcon[k].levelLock.enabled = true;
				LevelIcon[k].gameLevel = LevelGroup[currentPage].LevelInfo[k].gameLevel;
				break;
			case 2:
				LevelIcon[k].levelNumber.text = string.Empty + LevelGroup[currentPage].LevelInfo[k].levelNumber;
				LevelIcon[k].levelNumber.Commit();
				LevelIcon[k].ratingIcon.Play("r" + LevelGroup[currentPage].LevelInfo[k].levelRating);
				LevelIcon[k].levelHighlight.enabled = true;
				LevelIcon[k].levelLock.enabled = false;
				LevelIcon[k].gameLevel = LevelGroup[currentPage].LevelInfo[k].gameLevel;
				break;
			}
		}
		StageColor();
	}

	private void Update()
	{
		if (pageInfoState != -4)
		{
			if (characterID != data.selectedCharacterID)
			{
				LevelDataSetupFunction();
				LevelSetupFunction();
				LevelSelectionSetupFunction();
				characterID = data.selectedCharacterID;
			}
			PageFunction();
			if (!gameLoading)
			{
				ButtonFunction();
			}
		}
	}

	private void StageColor()
	{
		stageControlScript.stageNumber = currentPage;
		Transform transform = Camera.main.transform;
		float additionStageLength = stageControlScript.StageInfo[currentPage].additionStageLength;
		Vector3 position = Camera.main.transform.position;
		float y = position.y;
		Vector3 position2 = Camera.main.transform.position;
		transform.position = new Vector3(additionStageLength, y, position2.z);
		switch (currentPage)
		{
		case 0:
			stageBackground.color = new Color(0f, 0f, 0f, 0f);
			stageText.text = string.Empty + LevelGroup[currentPage].stageName;
			break;
		case 1:
			if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") < data.gameLevelPerStage - 1)
			{
				stageBackground.color = new Color(0f, 0f, 0f, 1f);
				stageText.text = "? ? ?";
			}
			else
			{
				stageBackground.color = new Color(0f, 0f, 0f, 0f);
				stageText.text = string.Empty + LevelGroup[currentPage].stageName;
			}
			break;
		case 2:
			if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") < data.gameLevelPerStage * 2 - 1)
			{
				stageBackground.color = new Color(0f, 0f, 0f, 1f);
				stageText.text = "? ? ?";
			}
			else
			{
				stageBackground.color = new Color(0f, 0f, 0f, 0f);
				stageText.text = string.Empty + LevelGroup[currentPage].stageName;
			}
			break;
		}
		stageText.Commit();
	}

	private void PageFunction()
	{
		if (pageInfoState == 1)
		{
			if (nextPage)
			{
				pageInfoState = -10;
				SelectionArrowFunction();
				nextPage = false;
			}
			if (previousPage)
			{
				pageInfoState = -20;
				SelectionArrowFunction();
				previousPage = false;
			}
		}
		switch (pageInfoState)
		{
		case -20:
			if (currentPage - 1 >= 0)
			{
				currentPage--;
				iconMenuTransition.transitionNumber = 7;
				stageText.text = string.Empty + LevelGroup[currentPage].stageName;
				stageText.Commit();
				StageColor();
				pageInfoState = -2;
			}
			else if (currentPage - 1 < 0)
			{
				pageInfoState = 1;
			}
			break;
		case -10:
			if (currentPage + 1 <= pageNumbers)
			{
				currentPage++;
				iconMenuTransition.transitionNumber = 6;
				stageText.text = string.Empty + LevelGroup[currentPage].stageName;
				stageText.Commit();
				StageColor();
				pageInfoState = -1;
			}
			else if (currentPage + 1 > pageNumbers)
			{
				pageInfoState = 1;
			}
			break;
		case -3:
			LevelDataSetupFunction();
			LevelSetupFunction();
			LevelSelectionSetupFunction();
			pageInfoState = 0;
			break;
		case -2:
			if (iconMenuTransition.transitionNumber == -5)
			{
				pageInfoState = 0;
			}
			break;
		case -1:
			if (iconMenuTransition.transitionNumber == 0)
			{
				pageInfoState = 0;
			}
			break;
		case 0:
			LevelSelectionSetupFunction();
			pageInfoState = 1;
			break;
		}
	}

	private void ToggleLevelFunction()
	{
		switch (LevelGroup[currentPage].LevelInfo[toggleButtonNumber].levelState)
		{
		case 0:
			data.saveMode = 0;
			LevelIcon[toggleButtonNumber].popEffect.activate = true;
			Camera.main.GetComponent<AudioSource>().PlayOneShot(accessClick);
			data.gameLevel = LevelIcon[toggleButtonNumber].gameLevel;
			if (LevelIcon[toggleButtonNumber].gameLevel == 0)
			{
				data.gameMode = 1;
			}
			else
			{
				data.gameMode = 0;
			}
			data.gameMode = 0;
			ScriptsManager.contentDataScript.PlayMusic(-1, 0);
			GC.Collect();
			AutoFade.LoadLevel(loadPlayScene, 3f, 1f, Color.black);
			gameLoading = true;
			menuLogic.loading = true;
			break;
		case 1:
			LevelIcon[toggleButtonNumber].popEffect.activate = true;
			Camera.main.GetComponent<AudioSource>().PlayOneShot(deniedClick);
			break;
		case 2:
			data.saveMode = 0;
			LevelIcon[toggleButtonNumber].popEffect.activate = true;
			Camera.main.GetComponent<AudioSource>().PlayOneShot(accessClick);
			data.gameLevel = LevelIcon[toggleButtonNumber].gameLevel;
			if (LevelIcon[toggleButtonNumber].gameLevel == 0)
			{
				data.gameMode = 1;
			}
			else
			{
				data.gameMode = 0;
			}
			ScriptsManager.contentDataScript.PlayMusic(-1, 0);
			GC.Collect();
			AutoFade.LoadLevel(loadPlayScene, 3f, 1f, Color.black);
			gameLoading = true;
			menuLogic.loading = true;
			break;
		}
	}

	private void ButtonFunction()
	{
		if (gameLoading || !Input.GetMouseButtonDown(0))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			if (hitInfo.collider.transform.name == "ls_previous")
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
				previousPage = true;
			}
			if (hitInfo.collider.transform.name == "ls_next")
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
				nextPage = true;
			}
			if (hitInfo.collider.transform.name == "Tls_1")
			{
				toggleButtonNumber = 0;
				ToggleLevelFunction();
			}
			if (hitInfo.collider.transform.name == "Tls_2")
			{
				toggleButtonNumber = 1;
				ToggleLevelFunction();
			}
			if (hitInfo.collider.transform.name == "Tls_3")
			{
				toggleButtonNumber = 2;
				ToggleLevelFunction();
			}
			if (hitInfo.collider.transform.name == "Tls_4")
			{
				toggleButtonNumber = 3;
				ToggleLevelFunction();
			}
			if (hitInfo.collider.transform.name == "Tls_5")
			{
				toggleButtonNumber = 4;
				ToggleLevelFunction();
			}
			if (hitInfo.collider.transform.name == "Tls_6")
			{
				toggleButtonNumber = 5;
				ToggleLevelFunction();
			}
		}
	}
}
