using System;
using UnityEngine;

public class StoreMenu : MonoBehaviour
{
	[Serializable]
	public class characterSelect
	{
		public tk2dAnimatedSprite characterIcon;

		public tk2dAnimatedSprite characterDifficulty;

		public tk2dTextMesh characterCompletion;

		public Renderer storeIcon;

		public GameObject iconTrigger;

		public int iapState;

		public int characterNumber;

		public string characterID;

		public string characterPrice;
	}

	[Serializable]
	public class productGroup
	{
		[Serializable]
		public class productInfo
		{
			public string iapName;

			public string iapID;

			public int iapState;

			public string iapProductID;

			public string iapValue;

			public int iapType;

			public int characterNumber;

			public int characterDifficulty;

			public int characterCompletion;

			public string miscDescription;
		}

		public productInfo[] ProductInfo = new productInfo[6];
	}

	public Content_Data dataContent;

	private Game_Data data;

	public MenuTransition characterSelectionTransition;

	public MenuTransition iconMenuTransition;

	public CharacterMenu characterMenu;

	public MenuTransition characterMenuTransition;

	private string characterID;

	public int pageInfoState;

	public bool nextPage;

	public bool previousPage;

	public int currentCharacterPage;

	public int characterPages = -1;

	public tk2dTextMesh pageText;

	private int toggleButtonNumber;

	public characterSelect[] CharacterSelect = new characterSelect[6];

	public GameObject[] pageArrows;

	public tk2dAnimatedSprite priceTag;

	public tk2dTextMesh priceTagText;

	public productGroup[] ProductGroup = new productGroup[10];

	private int linkIcon;

	private AudioClip regularClick;

	private AudioClip specialClick;

	public Menu_Logic scriptMenuLogic;

	private void Start()
	{
		dataContent = ScriptsManager.contentDataScript;
		data = ScriptsManager.dataScript;
		regularClick = ScriptsManager.audioClip[0];
		specialClick = ScriptsManager.audioClip[3];
	}

	private void ListSetupFunction()
	{
		for (int i = 0; i < dataContent.StoreIAPs.Length; i++)
		{
			for (int j = 0; j < ProductGroup.Length; j++)
			{
				for (int k = 0; k < ProductGroup[k].ProductInfo.Length; k++)
				{
					if (ProductGroup[j].ProductInfo[k].iapName == string.Empty && i != dataContent.StoreIAPs.Length && PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "LOCK") == 0 && dataContent.StoreIAPs[i].iapType == 2)
					{
						ProductGroup[j].ProductInfo[k].iapName = dataContent.StoreIAPs[i].iapName;
						ProductGroup[j].ProductInfo[k].iapID = dataContent.StoreIAPs[i].iapID;
						ProductGroup[j].ProductInfo[k].iapState = 0;
						ProductGroup[j].ProductInfo[k].iapProductID = dataContent.StoreIAPs[i].iapProductID;
						ProductGroup[j].ProductInfo[k].iapValue = dataContent.StoreIAPs[i].iapValue;
						ProductGroup[j].ProductInfo[k].iapType = 2;
						ProductGroup[j].ProductInfo[k].characterNumber = dataContent.StoreIAPs[i].characterNumber;
						ProductGroup[j].ProductInfo[k].characterDifficulty = dataContent.StoreIAPs[i].characterDifficulty;
						ProductGroup[j].ProductInfo[k].characterCompletion = PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent");
						ProductGroup[j].ProductInfo[k].miscDescription = dataContent.StoreIAPs[i].miscDescription;
						i++;
					}
				}
			}
		}
		for (int l = 0; l < dataContent.StoreIAPs.Length; l++)
		{
			for (int m = 0; m < ProductGroup.Length; m++)
			{
				for (int n = 0; n < ProductGroup[n].ProductInfo.Length; n++)
				{
					if (ProductGroup[m].ProductInfo[n].iapName == string.Empty && l != dataContent.StoreIAPs.Length && PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "LOCK") == 0 && dataContent.StoreIAPs[l].iapType == 1)
					{
						ProductGroup[m].ProductInfo[n].iapName = dataContent.StoreIAPs[l].iapName;
						ProductGroup[m].ProductInfo[n].iapID = dataContent.StoreIAPs[l].iapID;
						ProductGroup[m].ProductInfo[n].iapState = 0;
						ProductGroup[m].ProductInfo[n].iapProductID = dataContent.StoreIAPs[l].iapProductID;
						ProductGroup[m].ProductInfo[n].iapValue = dataContent.StoreIAPs[l].iapValue;
						ProductGroup[m].ProductInfo[n].iapType = 1;
						ProductGroup[m].ProductInfo[n].characterNumber = dataContent.StoreIAPs[l].characterNumber;
						ProductGroup[m].ProductInfo[n].characterDifficulty = dataContent.StoreIAPs[l].characterDifficulty;
						ProductGroup[m].ProductInfo[n].characterCompletion = PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent");
						ProductGroup[m].ProductInfo[n].miscDescription = dataContent.StoreIAPs[l].miscDescription;
						l++;
					}
				}
			}
		}
		for (int num = 0; num < ProductGroup.Length; num++)
		{
			for (int num2 = 0; num2 < ProductGroup[num2].ProductInfo.Length; num2++)
			{
				if (ProductGroup[num].ProductInfo[num2].iapName == string.Empty && linkIcon == 0)
				{
					ProductGroup[num].ProductInfo[num2].iapName = "Store Menu Link";
					ProductGroup[num].ProductInfo[num2].iapID = string.Empty;
					ProductGroup[num].ProductInfo[num2].iapState = -1;
					ProductGroup[num].ProductInfo[num2].iapProductID = string.Empty;
					ProductGroup[num].ProductInfo[num2].iapValue = string.Empty;
					ProductGroup[num].ProductInfo[num2].iapType = -1;
					ProductGroup[num].ProductInfo[num2].characterNumber = 0;
					ProductGroup[num].ProductInfo[num2].characterDifficulty = 0;
					ProductGroup[num].ProductInfo[num2].characterCompletion = 0;
					ProductGroup[num].ProductInfo[num2].miscDescription = string.Empty;
					linkIcon = 1;
				}
			}
		}
		characterPages = -1;
		for (int num3 = 0; num3 < ProductGroup.Length; num3++)
		{
			if (ProductGroup[num3].ProductInfo[0].iapName != string.Empty)
			{
				characterPages++;
			}
		}
		if (characterPages > 0)
		{
			pageArrows[0].SetActiveRecursively(state: false);
			pageArrows[1].SetActiveRecursively(state: true);
		}
		else
		{
			pageArrows[0].SetActiveRecursively(state: false);
			pageArrows[1].SetActiveRecursively(state: false);
		}
		pageText.text = string.Empty + (currentCharacterPage + 1) + " | " + (characterPages + 1);
		pageText.Commit();
		characterID = data.selectedCharacterID;
	}

	private void ListClearFunction()
	{
		linkIcon = 0;
		currentCharacterPage = 0;
		for (int i = 0; i < dataContent.StoreIAPs.Length; i++)
		{
			for (int j = 0; j < ProductGroup.Length; j++)
			{
				for (int k = 0; k < ProductGroup[k].ProductInfo.Length; k++)
				{
					if (ProductGroup[j].ProductInfo[k].iapName != string.Empty)
					{
						ProductGroup[j].ProductInfo[k].iapName = string.Empty;
						ProductGroup[j].ProductInfo[k].iapID = string.Empty;
						ProductGroup[j].ProductInfo[k].iapState = 0;
						ProductGroup[j].ProductInfo[k].iapProductID = string.Empty;
						ProductGroup[j].ProductInfo[k].iapValue = string.Empty;
						ProductGroup[j].ProductInfo[k].iapType = 0;
						ProductGroup[j].ProductInfo[k].characterNumber = 0;
						ProductGroup[j].ProductInfo[k].characterDifficulty = 0;
						ProductGroup[j].ProductInfo[k].characterCompletion = 0;
						ProductGroup[j].ProductInfo[k].miscDescription = string.Empty;
					}
				}
			}
		}
	}

	private void SelectionArrowFunction()
	{
		if (nextPage)
		{
			if (characterPages == 0)
			{
				if (pageArrows[0].active || pageArrows[1].active)
				{
					pageArrows[0].SetActiveRecursively(state: false);
					pageArrows[1].SetActiveRecursively(state: false);
				}
			}
			else if (currentCharacterPage + 1 == 0)
			{
				if (pageArrows[0].active)
				{
					pageArrows[0].SetActiveRecursively(state: false);
				}
				if (!pageArrows[1].active)
				{
					pageArrows[1].SetActiveRecursively(state: true);
				}
			}
			else if (currentCharacterPage + 1 == characterPages)
			{
				if (pageArrows[1].active)
				{
					pageArrows[1].SetActiveRecursively(state: false);
				}
				if (!pageArrows[0].active)
				{
					pageArrows[0].SetActiveRecursively(state: true);
				}
				if (!pageArrows[0].active && !pageArrows[1].active)
				{
					pageArrows[0].SetActiveRecursively(state: true);
					pageArrows[1].SetActiveRecursively(state: true);
				}
			}
			else if (currentCharacterPage + 1 != 0 && currentCharacterPage + 1 != characterPages && (!pageArrows[0].active || !pageArrows[1].active))
			{
				pageArrows[0].SetActiveRecursively(state: true);
				pageArrows[1].SetActiveRecursively(state: true);
			}
		}
		else
		{
			if (!previousPage)
			{
				return;
			}
			if (characterPages == 0)
			{
				if (pageArrows[0].active || pageArrows[1].active)
				{
					pageArrows[0].SetActiveRecursively(state: false);
					pageArrows[1].SetActiveRecursively(state: false);
				}
			}
			else if (currentCharacterPage - 1 == 0)
			{
				if (pageArrows[0].active)
				{
					pageArrows[0].SetActiveRecursively(state: false);
				}
				if (!pageArrows[1].active)
				{
					pageArrows[1].SetActiveRecursively(state: true);
				}
			}
			else if (currentCharacterPage - 1 == characterPages)
			{
				if (pageArrows[1].active)
				{
					pageArrows[1].SetActiveRecursively(state: false);
				}
				if (!pageArrows[0].active)
				{
					pageArrows[0].SetActiveRecursively(state: true);
				}
				if (!pageArrows[0].active && !pageArrows[1].active)
				{
					pageArrows[0].SetActiveRecursively(state: true);
					pageArrows[1].SetActiveRecursively(state: true);
				}
			}
			else if (currentCharacterPage - 1 != 0 && currentCharacterPage - 1 != characterPages && (!pageArrows[0].active || !pageArrows[1].active))
			{
				pageArrows[0].SetActiveRecursively(state: true);
				pageArrows[1].SetActiveRecursively(state: true);
			}
		}
	}

	private void SelectionSetupFunction()
	{
		for (int i = 0; i < ProductGroup[currentCharacterPage].ProductInfo.Length; i++)
		{
			if (ProductGroup[currentCharacterPage].ProductInfo[i].iapName != string.Empty)
			{
				CharacterSelect[i].iconTrigger.active = true;
				if (ProductGroup[currentCharacterPage].ProductInfo[i].iapType == 2)
				{
					CharacterSelect[i].characterIcon.Play("iap_" + ProductGroup[currentCharacterPage].ProductInfo[i].iapID);
					CharacterSelect[i].characterDifficulty.Play("iap_difficulty_" + ProductGroup[currentCharacterPage].ProductInfo[i].characterDifficulty);
					CharacterSelect[i].characterCompletion.text = string.Empty;
					CharacterSelect[i].characterCompletion.Commit();
					CharacterSelect[i].storeIcon.enabled = true;
					CharacterSelect[i].iapState = 0;
					CharacterSelect[i].characterNumber = ProductGroup[currentCharacterPage].ProductInfo[i].characterNumber;
					CharacterSelect[i].characterID = ProductGroup[currentCharacterPage].ProductInfo[i].iapID;
					CharacterSelect[i].characterPrice = "$" + ProductGroup[currentCharacterPage].ProductInfo[i].iapValue;
				}
				else if (ProductGroup[currentCharacterPage].ProductInfo[i].iapState == 0)
				{
					CharacterSelect[i].characterIcon.Play("iap_" + ProductGroup[currentCharacterPage].ProductInfo[i].iapID);
					CharacterSelect[i].characterDifficulty.Play("iap_difficulty_" + ProductGroup[currentCharacterPage].ProductInfo[i].characterDifficulty);
					CharacterSelect[i].characterCompletion.text = string.Empty;
					CharacterSelect[i].characterCompletion.Commit();
					CharacterSelect[i].storeIcon.enabled = false;
					CharacterSelect[i].iapState = 0;
					CharacterSelect[i].characterNumber = ProductGroup[currentCharacterPage].ProductInfo[i].characterNumber;
					CharacterSelect[i].characterID = ProductGroup[currentCharacterPage].ProductInfo[i].iapID;
					CharacterSelect[i].characterPrice = "$" + ProductGroup[currentCharacterPage].ProductInfo[i].iapValue;
				}
				else if (ProductGroup[currentCharacterPage].ProductInfo[i].iapType != 2 && ProductGroup[currentCharacterPage].ProductInfo[i].iapState == -1)
				{
					CharacterSelect[i].characterIcon.Play("iap_store_01");
					CharacterSelect[i].characterDifficulty.Play("blank");
					CharacterSelect[i].characterCompletion.text = string.Empty;
					CharacterSelect[i].characterCompletion.Commit();
					CharacterSelect[i].storeIcon.enabled = false;
					CharacterSelect[i].iapState = -1;
					CharacterSelect[i].characterNumber = -1;
					CharacterSelect[i].characterID = string.Empty;
					CharacterSelect[i].characterPrice = string.Empty;
				}
			}
			else if (ProductGroup[currentCharacterPage].ProductInfo[i].iapName == string.Empty)
			{
				CharacterSelect[i].characterIcon.Play("iap_empty");
				CharacterSelect[i].characterDifficulty.Play("blank");
				CharacterSelect[i].characterCompletion.text = string.Empty;
				CharacterSelect[i].characterCompletion.Commit();
				CharacterSelect[i].storeIcon.enabled = false;
				CharacterSelect[i].iconTrigger.active = false;
				CharacterSelect[i].characterPrice = string.Empty;
			}
		}
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
			if (currentCharacterPage - 1 >= 0)
			{
				currentCharacterPage--;
				iconMenuTransition.transitionNumber = 7;
				pageText.text = string.Empty + (currentCharacterPage + 1) + " | " + (characterPages + 1);
				pageText.Commit();
				pageInfoState = -2;
			}
			else if (currentCharacterPage - 1 < 0)
			{
				pageInfoState = 1;
			}
			break;
		case -10:
			if (currentCharacterPage + 1 <= characterPages)
			{
				currentCharacterPage++;
				iconMenuTransition.transitionNumber = 6;
				pageText.text = string.Empty + (currentCharacterPage + 1) + " | " + (characterPages + 1);
				pageText.Commit();
				pageInfoState = -1;
			}
			else if (currentCharacterPage + 1 > characterPages)
			{
				pageInfoState = 1;
			}
			break;
		case -3:
			ListClearFunction();
			ListSetupFunction();
			SelectionSetupFunction();
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
			SelectionSetupFunction();
			pageInfoState = 1;
			break;
		}
	}

	private void Update()
	{
		if (pageInfoState != -4)
		{
			if (characterID != data.selectedCharacterID)
			{
				ListClearFunction();
				ListSetupFunction();
				SelectionSetupFunction();
			}
			PageFunction();
			ButtonFunction();
		}
	}

	private void ToggleCharacterScreenFunction()
	{
		Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
		switch (CharacterSelect[toggleButtonNumber].iapState)
		{
		case -1:
			Application.OpenURL("http://fantasync.com/");
			break;
		case 0:
			characterSelectionTransition.transitionNumber = 1;
			characterMenu.viewCharacterID = CharacterSelect[toggleButtonNumber].characterID;
			characterMenuTransition.transitionNumber = 0;
			UnityEngine.Debug.Log("Unlock");
			priceTag.color = new Color(0.41f, 0.7f, 1f, 1f);
			priceTagText.text = CharacterSelect[toggleButtonNumber].characterPrice;
			priceTagText.Commit();
			break;
		case 1:
			characterSelectionTransition.transitionNumber = 1;
			characterMenu.viewCharacterID = CharacterSelect[toggleButtonNumber].characterID;
			characterMenuTransition.transitionNumber = 0;
			priceTag.color = Color.white;
			priceTagText.text = "SELECT";
			priceTagText.Commit();
			break;
		}
	}

	private void ButtonFunction()
	{
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			if (hitInfo.collider.transform.name == "ss_previous")
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
				previousPage = true;
			}
			if (hitInfo.collider.transform.name == "ss_next")
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
				nextPage = true;
			}
			if (pageInfoState == 1 && hitInfo.collider.transform.name == "cd_select")
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(specialClick);
				ScriptsManager.gameMusicScript.specialVolume = 0.1f;
				ScriptsManager.gameMusicScript.specialDuration = 6f;
				data.characterUnlock(CharacterSelect[toggleButtonNumber].characterID);
				scriptMenuLogic.characterScreenToggle = 1;
				pageInfoState = -3;
			}
			if (hitInfo.collider.transform.name == "Tss_1")
			{
				toggleButtonNumber = 0;
				ToggleCharacterScreenFunction();
			}
			if (hitInfo.collider.transform.name == "Tss_2")
			{
				toggleButtonNumber = 1;
				ToggleCharacterScreenFunction();
			}
			if (hitInfo.collider.transform.name == "Tss_3")
			{
				toggleButtonNumber = 2;
				ToggleCharacterScreenFunction();
			}
			if (hitInfo.collider.transform.name == "Tss_4")
			{
				toggleButtonNumber = 3;
				ToggleCharacterScreenFunction();
			}
			if (hitInfo.collider.transform.name == "Tss_5")
			{
				toggleButtonNumber = 4;
				ToggleCharacterScreenFunction();
			}
			if (hitInfo.collider.transform.name == "Tss_6")
			{
				toggleButtonNumber = 5;
				ToggleCharacterScreenFunction();
			}
			if (!(hitInfo.collider.transform.name == "ms_home"))
			{
			}
		}
	}
}
