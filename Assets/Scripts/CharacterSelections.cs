using System;
using UnityEngine;

public class CharacterSelections : MonoBehaviour
{
	[Serializable]
	public class characterSelect
	{
		public GameObject selectionBox;

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

	public int characterSelectType;

	public Content_Data dataContent;

	private Stage_Control stageControl;

	private Game_Data data;

	public MenuTransition characterSelectionTransition;

	public MenuTransition iconMenuTransition;

	public CharacterMenu characterMenu;

	public MenuTransition characterMenuTransition;

	public MenuTransition backGroundMenuTransition;

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

	public pop_effect lockPopEffect;

	public tk2dTextMesh lockInfoText;

	public pop_effect lockInfoPopEffect;

	private float TIMER_lockInfo;

	public Renderer characterHighlight;

	public productGroup[] ProductGroup = new productGroup[10];

	private int linkIcon;

	private AudioClip regularClick;

	private AudioClip specialClick;

	private AudioClip deniedClick;

	private int unlockMode;

	private int maximumGameLevel;

	private int characterSelectionAmount;

	private float ALPHA_lockInfoText;

	private int SELECTED_toggleButtonNumber;

	public Menu_Logic scriptMenuLogic;

	private void Awake()
	{
		dataContent = ScriptsManager.contentDataScript;
		SelectionBoxPositioning();
	}

	private void Start()
	{
		dataContent = ScriptsManager.contentDataScript;
		data = ScriptsManager.dataScript;
		unlockMode = data.unlockMode;
		maximumGameLevel = data.gameMaximumLevel;
		stageControl = ScriptsManager.stageControlScript;
		regularClick = ScriptsManager.audioClip[0];
		specialClick = ScriptsManager.audioClip[3];
		deniedClick = ScriptsManager.audioClip[2];
		ListSetupFunction();
	}

	private void SelectionBoxPositioning()
	{
		if (characterSelectType == 0)
		{
			return;
		}
		for (int i = 0; i < dataContent.StoreIAPs.Length; i++)
		{
			if (dataContent.StoreIAPs[i].iapName != string.Empty)
			{
				characterSelectionAmount++;
			}
		}
		switch (characterSelectionAmount)
		{
		case 1:
		{
			Transform transform25 = CharacterSelect[0].selectionBox.transform;
			Vector3 localPosition49 = CharacterSelect[0].selectionBox.transform.localPosition;
			float y25 = localPosition49.y;
			Vector3 localPosition50 = CharacterSelect[0].selectionBox.transform.localPosition;
			transform25.localPosition = new Vector3(0f, y25, localPosition50.z);
			Transform transform26 = CharacterSelect[1].selectionBox.transform;
			Vector3 localPosition51 = CharacterSelect[1].selectionBox.transform.localPosition;
			float y26 = localPosition51.y;
			Vector3 localPosition52 = CharacterSelect[1].selectionBox.transform.localPosition;
			transform26.localPosition = new Vector3(100f, y26, localPosition52.z);
			Transform transform27 = CharacterSelect[2].selectionBox.transform;
			Vector3 localPosition53 = CharacterSelect[2].selectionBox.transform.localPosition;
			float y27 = localPosition53.y;
			Vector3 localPosition54 = CharacterSelect[2].selectionBox.transform.localPosition;
			transform27.localPosition = new Vector3(100f, y27, localPosition54.z);
			Transform transform28 = CharacterSelect[3].selectionBox.transform;
			Vector3 localPosition55 = CharacterSelect[3].selectionBox.transform.localPosition;
			float y28 = localPosition55.y;
			Vector3 localPosition56 = CharacterSelect[3].selectionBox.transform.localPosition;
			transform28.localPosition = new Vector3(100f, y28, localPosition56.z);
			Transform transform29 = CharacterSelect[4].selectionBox.transform;
			Vector3 localPosition57 = CharacterSelect[4].selectionBox.transform.localPosition;
			float y29 = localPosition57.y;
			Vector3 localPosition58 = CharacterSelect[4].selectionBox.transform.localPosition;
			transform29.localPosition = new Vector3(100f, y29, localPosition58.z);
			Transform transform30 = CharacterSelect[5].selectionBox.transform;
			Vector3 localPosition59 = CharacterSelect[5].selectionBox.transform.localPosition;
			float y30 = localPosition59.y;
			Vector3 localPosition60 = CharacterSelect[5].selectionBox.transform.localPosition;
			transform30.localPosition = new Vector3(100f, y30, localPosition60.z);
			break;
		}
		case 2:
		{
			Transform transform19 = CharacterSelect[0].selectionBox.transform;
			Vector3 localPosition37 = CharacterSelect[0].selectionBox.transform.localPosition;
			float y19 = localPosition37.y;
			Vector3 localPosition38 = CharacterSelect[0].selectionBox.transform.localPosition;
			transform19.localPosition = new Vector3(-1f, y19, localPosition38.z);
			Transform transform20 = CharacterSelect[1].selectionBox.transform;
			Vector3 localPosition39 = CharacterSelect[1].selectionBox.transform.localPosition;
			float y20 = localPosition39.y;
			Vector3 localPosition40 = CharacterSelect[1].selectionBox.transform.localPosition;
			transform20.localPosition = new Vector3(1f, y20, localPosition40.z);
			Transform transform21 = CharacterSelect[2].selectionBox.transform;
			Vector3 localPosition41 = CharacterSelect[2].selectionBox.transform.localPosition;
			float y21 = localPosition41.y;
			Vector3 localPosition42 = CharacterSelect[2].selectionBox.transform.localPosition;
			transform21.localPosition = new Vector3(100f, y21, localPosition42.z);
			Transform transform22 = CharacterSelect[3].selectionBox.transform;
			Vector3 localPosition43 = CharacterSelect[3].selectionBox.transform.localPosition;
			float y22 = localPosition43.y;
			Vector3 localPosition44 = CharacterSelect[3].selectionBox.transform.localPosition;
			transform22.localPosition = new Vector3(100f, y22, localPosition44.z);
			Transform transform23 = CharacterSelect[4].selectionBox.transform;
			Vector3 localPosition45 = CharacterSelect[4].selectionBox.transform.localPosition;
			float y23 = localPosition45.y;
			Vector3 localPosition46 = CharacterSelect[4].selectionBox.transform.localPosition;
			transform23.localPosition = new Vector3(100f, y23, localPosition46.z);
			Transform transform24 = CharacterSelect[5].selectionBox.transform;
			Vector3 localPosition47 = CharacterSelect[5].selectionBox.transform.localPosition;
			float y24 = localPosition47.y;
			Vector3 localPosition48 = CharacterSelect[5].selectionBox.transform.localPosition;
			transform24.localPosition = new Vector3(100f, y24, localPosition48.z);
			break;
		}
		case 3:
		{
			Transform transform13 = CharacterSelect[0].selectionBox.transform;
			Vector3 localPosition25 = CharacterSelect[0].selectionBox.transform.localPosition;
			float y13 = localPosition25.y;
			Vector3 localPosition26 = CharacterSelect[0].selectionBox.transform.localPosition;
			transform13.localPosition = new Vector3(-1.5f, y13, localPosition26.z);
			Transform transform14 = CharacterSelect[1].selectionBox.transform;
			Vector3 localPosition27 = CharacterSelect[1].selectionBox.transform.localPosition;
			float y14 = localPosition27.y;
			Vector3 localPosition28 = CharacterSelect[1].selectionBox.transform.localPosition;
			transform14.localPosition = new Vector3(0f, y14, localPosition28.z);
			Transform transform15 = CharacterSelect[2].selectionBox.transform;
			Vector3 localPosition29 = CharacterSelect[2].selectionBox.transform.localPosition;
			float y15 = localPosition29.y;
			Vector3 localPosition30 = CharacterSelect[2].selectionBox.transform.localPosition;
			transform15.localPosition = new Vector3(1.5f, y15, localPosition30.z);
			Transform transform16 = CharacterSelect[3].selectionBox.transform;
			Vector3 localPosition31 = CharacterSelect[3].selectionBox.transform.localPosition;
			float y16 = localPosition31.y;
			Vector3 localPosition32 = CharacterSelect[3].selectionBox.transform.localPosition;
			transform16.localPosition = new Vector3(100f, y16, localPosition32.z);
			Transform transform17 = CharacterSelect[4].selectionBox.transform;
			Vector3 localPosition33 = CharacterSelect[4].selectionBox.transform.localPosition;
			float y17 = localPosition33.y;
			Vector3 localPosition34 = CharacterSelect[4].selectionBox.transform.localPosition;
			transform17.localPosition = new Vector3(100f, y17, localPosition34.z);
			Transform transform18 = CharacterSelect[5].selectionBox.transform;
			Vector3 localPosition35 = CharacterSelect[5].selectionBox.transform.localPosition;
			float y18 = localPosition35.y;
			Vector3 localPosition36 = CharacterSelect[5].selectionBox.transform.localPosition;
			transform18.localPosition = new Vector3(100f, y18, localPosition36.z);
			break;
		}
		case 4:
		{
			Transform transform7 = CharacterSelect[0].selectionBox.transform;
			Vector3 localPosition13 = CharacterSelect[0].selectionBox.transform.localPosition;
			float y7 = localPosition13.y;
			Vector3 localPosition14 = CharacterSelect[0].selectionBox.transform.localPosition;
			transform7.localPosition = new Vector3(-2.25f, y7, localPosition14.z);
			Transform transform8 = CharacterSelect[1].selectionBox.transform;
			Vector3 localPosition15 = CharacterSelect[1].selectionBox.transform.localPosition;
			float y8 = localPosition15.y;
			Vector3 localPosition16 = CharacterSelect[1].selectionBox.transform.localPosition;
			transform8.localPosition = new Vector3(-1.2f, y8, localPosition16.z);
			Transform transform9 = CharacterSelect[2].selectionBox.transform;
			Vector3 localPosition17 = CharacterSelect[2].selectionBox.transform.localPosition;
			float y9 = localPosition17.y;
			Vector3 localPosition18 = CharacterSelect[2].selectionBox.transform.localPosition;
			transform9.localPosition = new Vector3(1.2f, y9, localPosition18.z);
			Transform transform10 = CharacterSelect[3].selectionBox.transform;
			Vector3 localPosition19 = CharacterSelect[3].selectionBox.transform.localPosition;
			float y10 = localPosition19.y;
			Vector3 localPosition20 = CharacterSelect[3].selectionBox.transform.localPosition;
			transform10.localPosition = new Vector3(2.25f, y10, localPosition20.z);
			Transform transform11 = CharacterSelect[4].selectionBox.transform;
			Vector3 localPosition21 = CharacterSelect[4].selectionBox.transform.localPosition;
			float y11 = localPosition21.y;
			Vector3 localPosition22 = CharacterSelect[4].selectionBox.transform.localPosition;
			transform11.localPosition = new Vector3(100f, y11, localPosition22.z);
			Transform transform12 = CharacterSelect[5].selectionBox.transform;
			Vector3 localPosition23 = CharacterSelect[5].selectionBox.transform.localPosition;
			float y12 = localPosition23.y;
			Vector3 localPosition24 = CharacterSelect[5].selectionBox.transform.localPosition;
			transform12.localPosition = new Vector3(100f, y12, localPosition24.z);
			break;
		}
		case 5:
		{
			Transform transform = CharacterSelect[0].selectionBox.transform;
			Vector3 localPosition = CharacterSelect[0].selectionBox.transform.localPosition;
			float y = localPosition.y;
			Vector3 localPosition2 = CharacterSelect[0].selectionBox.transform.localPosition;
			transform.localPosition = new Vector3(-2.4f, y, localPosition2.z);
			Transform transform2 = CharacterSelect[1].selectionBox.transform;
			Vector3 localPosition3 = CharacterSelect[1].selectionBox.transform.localPosition;
			float y2 = localPosition3.y;
			Vector3 localPosition4 = CharacterSelect[1].selectionBox.transform.localPosition;
			transform2.localPosition = new Vector3(-1.2f, y2, localPosition4.z);
			Transform transform3 = CharacterSelect[2].selectionBox.transform;
			Vector3 localPosition5 = CharacterSelect[2].selectionBox.transform.localPosition;
			float y3 = localPosition5.y;
			Vector3 localPosition6 = CharacterSelect[2].selectionBox.transform.localPosition;
			transform3.localPosition = new Vector3(0f, y3, localPosition6.z);
			Transform transform4 = CharacterSelect[3].selectionBox.transform;
			Vector3 localPosition7 = CharacterSelect[3].selectionBox.transform.localPosition;
			float y4 = localPosition7.y;
			Vector3 localPosition8 = CharacterSelect[3].selectionBox.transform.localPosition;
			transform4.localPosition = new Vector3(1.2f, y4, localPosition8.z);
			Transform transform5 = CharacterSelect[4].selectionBox.transform;
			Vector3 localPosition9 = CharacterSelect[4].selectionBox.transform.localPosition;
			float y5 = localPosition9.y;
			Vector3 localPosition10 = CharacterSelect[4].selectionBox.transform.localPosition;
			transform5.localPosition = new Vector3(2.4f, y5, localPosition10.z);
			Transform transform6 = CharacterSelect[5].selectionBox.transform;
			Vector3 localPosition11 = CharacterSelect[5].selectionBox.transform.localPosition;
			float y6 = localPosition11.y;
			Vector3 localPosition12 = CharacterSelect[5].selectionBox.transform.localPosition;
			transform6.localPosition = new Vector3(100f, y6, localPosition12.z);
			break;
		}
		}
	}

	private void ListSetupFunction()
	{
		if (characterSelectType == 0)
		{
			for (int i = 0; i < dataContent.StoreIAPs.Length; i++)
			{
				for (int j = 0; j < ProductGroup.Length; j++)
				{
					for (int k = 0; k < ProductGroup[k].ProductInfo.Length; k++)
					{
						if (ProductGroup[j].ProductInfo[k].iapName == string.Empty && i != dataContent.StoreIAPs.Length && PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "LOCK") == 1 && dataContent.StoreIAPs[i].iapType >= 1 && data.selectedCharacterID == dataContent.StoreIAPs[i].iapID)
						{
							ProductGroup[j].ProductInfo[k].iapName = dataContent.StoreIAPs[i].iapName;
							ProductGroup[j].ProductInfo[k].iapID = dataContent.StoreIAPs[i].iapID;
							ProductGroup[j].ProductInfo[k].iapState = 1;
							ProductGroup[j].ProductInfo[k].iapProductID = dataContent.StoreIAPs[i].iapProductID;
							ProductGroup[j].ProductInfo[k].iapValue = dataContent.StoreIAPs[i].iapValue;
							ProductGroup[j].ProductInfo[k].iapType = 1;
							ProductGroup[j].ProductInfo[k].characterNumber = dataContent.StoreIAPs[i].characterNumber;
							ProductGroup[j].ProductInfo[k].characterCompletion = PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent");
							if (PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") < 20)
							{
								ProductGroup[j].ProductInfo[k].characterDifficulty = 0;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") >= 20 && PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") < 40)
							{
								ProductGroup[j].ProductInfo[k].characterDifficulty = 1;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") >= 40 && PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") < 60)
							{
								ProductGroup[j].ProductInfo[k].characterDifficulty = 2;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") >= 60 && PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") < 80)
							{
								ProductGroup[j].ProductInfo[k].characterDifficulty = 3;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") >= 80 && PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") < 100)
							{
								ProductGroup[j].ProductInfo[k].characterDifficulty = 4;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[i].iapID + "completionPercent") >= 100)
							{
								ProductGroup[j].ProductInfo[k].characterDifficulty = 5;
							}
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
						if (ProductGroup[m].ProductInfo[n].iapName == string.Empty && l != dataContent.StoreIAPs.Length && PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "LOCK") == 1 && dataContent.StoreIAPs[l].iapType >= 1 && data.selectedCharacterID != dataContent.StoreIAPs[l].iapID)
						{
							ProductGroup[m].ProductInfo[n].iapName = dataContent.StoreIAPs[l].iapName;
							ProductGroup[m].ProductInfo[n].iapID = dataContent.StoreIAPs[l].iapID;
							ProductGroup[m].ProductInfo[n].iapState = 1;
							ProductGroup[m].ProductInfo[n].iapProductID = dataContent.StoreIAPs[l].iapProductID;
							ProductGroup[m].ProductInfo[n].iapValue = dataContent.StoreIAPs[l].iapValue;
							ProductGroup[m].ProductInfo[n].iapType = 1;
							ProductGroup[m].ProductInfo[n].characterNumber = dataContent.StoreIAPs[l].characterNumber;
							ProductGroup[m].ProductInfo[n].characterCompletion = PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent");
							if (PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") < 20)
							{
								ProductGroup[m].ProductInfo[n].characterDifficulty = 0;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") >= 20 && PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") < 40)
							{
								ProductGroup[m].ProductInfo[n].characterDifficulty = 1;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") >= 40 && PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") < 60)
							{
								ProductGroup[m].ProductInfo[n].characterDifficulty = 2;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") >= 60 && PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") < 80)
							{
								ProductGroup[m].ProductInfo[n].characterDifficulty = 3;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") >= 80 && PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") < 100)
							{
								ProductGroup[m].ProductInfo[n].characterDifficulty = 4;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[l].iapID + "completionPercent") >= 100)
							{
								ProductGroup[m].ProductInfo[n].characterDifficulty = 5;
							}
							ProductGroup[m].ProductInfo[n].miscDescription = dataContent.StoreIAPs[l].miscDescription;
							l++;
						}
					}
				}
			}
		}
		else
		{
			characterHighlight.enabled = false;
			switch (characterSelectionAmount)
			{
			case 1:
			{
				Transform transform25 = CharacterSelect[0].selectionBox.transform;
				Vector3 localPosition49 = CharacterSelect[0].selectionBox.transform.localPosition;
				float y25 = localPosition49.y;
				Vector3 localPosition50 = CharacterSelect[0].selectionBox.transform.localPosition;
				transform25.localPosition = new Vector3(0f, y25, localPosition50.z);
				Transform transform26 = CharacterSelect[1].selectionBox.transform;
				Vector3 localPosition51 = CharacterSelect[1].selectionBox.transform.localPosition;
				float y26 = localPosition51.y;
				Vector3 localPosition52 = CharacterSelect[1].selectionBox.transform.localPosition;
				transform26.localPosition = new Vector3(100f, y26, localPosition52.z);
				Transform transform27 = CharacterSelect[2].selectionBox.transform;
				Vector3 localPosition53 = CharacterSelect[2].selectionBox.transform.localPosition;
				float y27 = localPosition53.y;
				Vector3 localPosition54 = CharacterSelect[2].selectionBox.transform.localPosition;
				transform27.localPosition = new Vector3(100f, y27, localPosition54.z);
				Transform transform28 = CharacterSelect[3].selectionBox.transform;
				Vector3 localPosition55 = CharacterSelect[3].selectionBox.transform.localPosition;
				float y28 = localPosition55.y;
				Vector3 localPosition56 = CharacterSelect[3].selectionBox.transform.localPosition;
				transform28.localPosition = new Vector3(100f, y28, localPosition56.z);
				Transform transform29 = CharacterSelect[4].selectionBox.transform;
				Vector3 localPosition57 = CharacterSelect[4].selectionBox.transform.localPosition;
				float y29 = localPosition57.y;
				Vector3 localPosition58 = CharacterSelect[4].selectionBox.transform.localPosition;
				transform29.localPosition = new Vector3(100f, y29, localPosition58.z);
				Transform transform30 = CharacterSelect[5].selectionBox.transform;
				Vector3 localPosition59 = CharacterSelect[5].selectionBox.transform.localPosition;
				float y30 = localPosition59.y;
				Vector3 localPosition60 = CharacterSelect[5].selectionBox.transform.localPosition;
				transform30.localPosition = new Vector3(100f, y30, localPosition60.z);
				break;
			}
			case 2:
			{
				Transform transform19 = CharacterSelect[0].selectionBox.transform;
				Vector3 localPosition37 = CharacterSelect[0].selectionBox.transform.localPosition;
				float y19 = localPosition37.y;
				Vector3 localPosition38 = CharacterSelect[0].selectionBox.transform.localPosition;
				transform19.localPosition = new Vector3(-1f, y19, localPosition38.z);
				Transform transform20 = CharacterSelect[1].selectionBox.transform;
				Vector3 localPosition39 = CharacterSelect[1].selectionBox.transform.localPosition;
				float y20 = localPosition39.y;
				Vector3 localPosition40 = CharacterSelect[1].selectionBox.transform.localPosition;
				transform20.localPosition = new Vector3(1f, y20, localPosition40.z);
				Transform transform21 = CharacterSelect[2].selectionBox.transform;
				Vector3 localPosition41 = CharacterSelect[2].selectionBox.transform.localPosition;
				float y21 = localPosition41.y;
				Vector3 localPosition42 = CharacterSelect[2].selectionBox.transform.localPosition;
				transform21.localPosition = new Vector3(100f, y21, localPosition42.z);
				Transform transform22 = CharacterSelect[3].selectionBox.transform;
				Vector3 localPosition43 = CharacterSelect[3].selectionBox.transform.localPosition;
				float y22 = localPosition43.y;
				Vector3 localPosition44 = CharacterSelect[3].selectionBox.transform.localPosition;
				transform22.localPosition = new Vector3(100f, y22, localPosition44.z);
				Transform transform23 = CharacterSelect[4].selectionBox.transform;
				Vector3 localPosition45 = CharacterSelect[4].selectionBox.transform.localPosition;
				float y23 = localPosition45.y;
				Vector3 localPosition46 = CharacterSelect[4].selectionBox.transform.localPosition;
				transform23.localPosition = new Vector3(100f, y23, localPosition46.z);
				Transform transform24 = CharacterSelect[5].selectionBox.transform;
				Vector3 localPosition47 = CharacterSelect[5].selectionBox.transform.localPosition;
				float y24 = localPosition47.y;
				Vector3 localPosition48 = CharacterSelect[5].selectionBox.transform.localPosition;
				transform24.localPosition = new Vector3(100f, y24, localPosition48.z);
				break;
			}
			case 3:
			{
				Transform transform13 = CharacterSelect[0].selectionBox.transform;
				Vector3 localPosition25 = CharacterSelect[0].selectionBox.transform.localPosition;
				float y13 = localPosition25.y;
				Vector3 localPosition26 = CharacterSelect[0].selectionBox.transform.localPosition;
				transform13.localPosition = new Vector3(-1.5f, y13, localPosition26.z);
				Transform transform14 = CharacterSelect[1].selectionBox.transform;
				Vector3 localPosition27 = CharacterSelect[1].selectionBox.transform.localPosition;
				float y14 = localPosition27.y;
				Vector3 localPosition28 = CharacterSelect[1].selectionBox.transform.localPosition;
				transform14.localPosition = new Vector3(0f, y14, localPosition28.z);
				Transform transform15 = CharacterSelect[2].selectionBox.transform;
				Vector3 localPosition29 = CharacterSelect[2].selectionBox.transform.localPosition;
				float y15 = localPosition29.y;
				Vector3 localPosition30 = CharacterSelect[2].selectionBox.transform.localPosition;
				transform15.localPosition = new Vector3(1.5f, y15, localPosition30.z);
				Transform transform16 = CharacterSelect[3].selectionBox.transform;
				Vector3 localPosition31 = CharacterSelect[3].selectionBox.transform.localPosition;
				float y16 = localPosition31.y;
				Vector3 localPosition32 = CharacterSelect[3].selectionBox.transform.localPosition;
				transform16.localPosition = new Vector3(100f, y16, localPosition32.z);
				Transform transform17 = CharacterSelect[4].selectionBox.transform;
				Vector3 localPosition33 = CharacterSelect[4].selectionBox.transform.localPosition;
				float y17 = localPosition33.y;
				Vector3 localPosition34 = CharacterSelect[4].selectionBox.transform.localPosition;
				transform17.localPosition = new Vector3(100f, y17, localPosition34.z);
				Transform transform18 = CharacterSelect[5].selectionBox.transform;
				Vector3 localPosition35 = CharacterSelect[5].selectionBox.transform.localPosition;
				float y18 = localPosition35.y;
				Vector3 localPosition36 = CharacterSelect[5].selectionBox.transform.localPosition;
				transform18.localPosition = new Vector3(100f, y18, localPosition36.z);
				break;
			}
			case 4:
			{
				Transform transform7 = CharacterSelect[0].selectionBox.transform;
				Vector3 localPosition13 = CharacterSelect[0].selectionBox.transform.localPosition;
				float y7 = localPosition13.y;
				Vector3 localPosition14 = CharacterSelect[0].selectionBox.transform.localPosition;
				transform7.localPosition = new Vector3(-2.25f, y7, localPosition14.z);
				Transform transform8 = CharacterSelect[1].selectionBox.transform;
				Vector3 localPosition15 = CharacterSelect[1].selectionBox.transform.localPosition;
				float y8 = localPosition15.y;
				Vector3 localPosition16 = CharacterSelect[1].selectionBox.transform.localPosition;
				transform8.localPosition = new Vector3(-1.2f, y8, localPosition16.z);
				Transform transform9 = CharacterSelect[2].selectionBox.transform;
				Vector3 localPosition17 = CharacterSelect[2].selectionBox.transform.localPosition;
				float y9 = localPosition17.y;
				Vector3 localPosition18 = CharacterSelect[2].selectionBox.transform.localPosition;
				transform9.localPosition = new Vector3(1.2f, y9, localPosition18.z);
				Transform transform10 = CharacterSelect[3].selectionBox.transform;
				Vector3 localPosition19 = CharacterSelect[3].selectionBox.transform.localPosition;
				float y10 = localPosition19.y;
				Vector3 localPosition20 = CharacterSelect[3].selectionBox.transform.localPosition;
				transform10.localPosition = new Vector3(2.25f, y10, localPosition20.z);
				Transform transform11 = CharacterSelect[4].selectionBox.transform;
				Vector3 localPosition21 = CharacterSelect[4].selectionBox.transform.localPosition;
				float y11 = localPosition21.y;
				Vector3 localPosition22 = CharacterSelect[4].selectionBox.transform.localPosition;
				transform11.localPosition = new Vector3(100f, y11, localPosition22.z);
				Transform transform12 = CharacterSelect[5].selectionBox.transform;
				Vector3 localPosition23 = CharacterSelect[5].selectionBox.transform.localPosition;
				float y12 = localPosition23.y;
				Vector3 localPosition24 = CharacterSelect[5].selectionBox.transform.localPosition;
				transform12.localPosition = new Vector3(100f, y12, localPosition24.z);
				break;
			}
			case 5:
			{
				Transform transform = CharacterSelect[0].selectionBox.transform;
				Vector3 localPosition = CharacterSelect[0].selectionBox.transform.localPosition;
				float y = localPosition.y;
				Vector3 localPosition2 = CharacterSelect[0].selectionBox.transform.localPosition;
				transform.localPosition = new Vector3(-2.4f, y, localPosition2.z);
				Transform transform2 = CharacterSelect[1].selectionBox.transform;
				Vector3 localPosition3 = CharacterSelect[1].selectionBox.transform.localPosition;
				float y2 = localPosition3.y;
				Vector3 localPosition4 = CharacterSelect[1].selectionBox.transform.localPosition;
				transform2.localPosition = new Vector3(-1.2f, y2, localPosition4.z);
				Transform transform3 = CharacterSelect[2].selectionBox.transform;
				Vector3 localPosition5 = CharacterSelect[2].selectionBox.transform.localPosition;
				float y3 = localPosition5.y;
				Vector3 localPosition6 = CharacterSelect[2].selectionBox.transform.localPosition;
				transform3.localPosition = new Vector3(0f, y3, localPosition6.z);
				Transform transform4 = CharacterSelect[3].selectionBox.transform;
				Vector3 localPosition7 = CharacterSelect[3].selectionBox.transform.localPosition;
				float y4 = localPosition7.y;
				Vector3 localPosition8 = CharacterSelect[3].selectionBox.transform.localPosition;
				transform4.localPosition = new Vector3(1.2f, y4, localPosition8.z);
				Transform transform5 = CharacterSelect[4].selectionBox.transform;
				Vector3 localPosition9 = CharacterSelect[4].selectionBox.transform.localPosition;
				float y5 = localPosition9.y;
				Vector3 localPosition10 = CharacterSelect[4].selectionBox.transform.localPosition;
				transform5.localPosition = new Vector3(2.4f, y5, localPosition10.z);
				Transform transform6 = CharacterSelect[5].selectionBox.transform;
				Vector3 localPosition11 = CharacterSelect[5].selectionBox.transform.localPosition;
				float y6 = localPosition11.y;
				Vector3 localPosition12 = CharacterSelect[5].selectionBox.transform.localPosition;
				transform6.localPosition = new Vector3(100f, y6, localPosition12.z);
				break;
			}
			}
			for (int num = 0; num < dataContent.StoreIAPs.Length; num++)
			{
				for (int num2 = 0; num2 < ProductGroup.Length; num2++)
				{
					for (int num3 = 0; num3 < ProductGroup[num3].ProductInfo.Length; num3++)
					{
						if (ProductGroup[num2].ProductInfo[num3].iapName == string.Empty && num != dataContent.StoreIAPs.Length && PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "LOCK") == 1 && dataContent.StoreIAPs[num].iapType >= 1)
						{
							ProductGroup[num2].ProductInfo[num3].iapName = dataContent.StoreIAPs[num].iapName;
							ProductGroup[num2].ProductInfo[num3].iapID = dataContent.StoreIAPs[num].iapID;
							ProductGroup[num2].ProductInfo[num3].iapState = 1;
							ProductGroup[num2].ProductInfo[num3].iapProductID = dataContent.StoreIAPs[num].iapProductID;
							ProductGroup[num2].ProductInfo[num3].iapValue = dataContent.StoreIAPs[num].iapValue;
							ProductGroup[num2].ProductInfo[num3].iapType = 1;
							ProductGroup[num2].ProductInfo[num3].characterNumber = dataContent.StoreIAPs[num].characterNumber;
							ProductGroup[num2].ProductInfo[num3].characterCompletion = PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent");
							if (PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") < 20)
							{
								ProductGroup[num2].ProductInfo[num3].characterDifficulty = 0;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") >= 20 && PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") < 40)
							{
								ProductGroup[num2].ProductInfo[num3].characterDifficulty = 1;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") >= 40 && PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") < 60)
							{
								ProductGroup[num2].ProductInfo[num3].characterDifficulty = 2;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") >= 60 && PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") < 80)
							{
								ProductGroup[num2].ProductInfo[num3].characterDifficulty = 3;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") >= 80 && PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") < 100)
							{
								ProductGroup[num2].ProductInfo[num3].characterDifficulty = 4;
							}
							else if (PlayerPrefs.GetInt(dataContent.StoreIAPs[num].iapID + "completionPercent") >= 100)
							{
								ProductGroup[num2].ProductInfo[num3].characterDifficulty = 5;
							}
							ProductGroup[num2].ProductInfo[num3].miscDescription = dataContent.StoreIAPs[num].miscDescription;
							num++;
						}
					}
				}
			}
		}
		for (int num4 = 0; num4 < dataContent.StoreIAPs.Length; num4++)
		{
			for (int num5 = 0; num5 < ProductGroup.Length; num5++)
			{
				for (int num6 = 0; num6 < ProductGroup[num6].ProductInfo.Length; num6++)
				{
					if (ProductGroup[num5].ProductInfo[num6].iapName == string.Empty && num4 != dataContent.StoreIAPs.Length && PlayerPrefs.GetInt(dataContent.StoreIAPs[num4].iapID + "LOCK") == 0 && dataContent.StoreIAPs[num4].iapType == 2)
					{
						ProductGroup[num5].ProductInfo[num6].iapName = dataContent.StoreIAPs[num4].iapName;
						ProductGroup[num5].ProductInfo[num6].iapID = dataContent.StoreIAPs[num4].iapID;
						ProductGroup[num5].ProductInfo[num6].iapState = 0;
						ProductGroup[num5].ProductInfo[num6].iapProductID = dataContent.StoreIAPs[num4].iapProductID;
						ProductGroup[num5].ProductInfo[num6].iapValue = dataContent.StoreIAPs[num4].iapValue;
						ProductGroup[num5].ProductInfo[num6].iapType = 2;
						ProductGroup[num5].ProductInfo[num6].characterNumber = dataContent.StoreIAPs[num4].characterNumber;
						ProductGroup[num5].ProductInfo[num6].characterDifficulty = 0;
						ProductGroup[num5].ProductInfo[num6].characterCompletion = PlayerPrefs.GetInt(dataContent.StoreIAPs[num4].iapID + "completionPercent");
						ProductGroup[num5].ProductInfo[num6].miscDescription = dataContent.StoreIAPs[num4].miscDescription;
						num4++;
					}
				}
			}
		}
		for (int num7 = 0; num7 < dataContent.StoreIAPs.Length; num7++)
		{
			for (int num8 = 0; num8 < ProductGroup.Length; num8++)
			{
				for (int num9 = 0; num9 < ProductGroup[num9].ProductInfo.Length; num9++)
				{
					if (ProductGroup[num8].ProductInfo[num9].iapName == string.Empty && num7 != dataContent.StoreIAPs.Length && PlayerPrefs.GetInt(dataContent.StoreIAPs[num7].iapID + "LOCK") == 0 && dataContent.StoreIAPs[num7].iapType == 1)
					{
						ProductGroup[num8].ProductInfo[num9].iapName = dataContent.StoreIAPs[num7].iapName;
						ProductGroup[num8].ProductInfo[num9].iapID = dataContent.StoreIAPs[num7].iapID;
						ProductGroup[num8].ProductInfo[num9].iapState = 0;
						ProductGroup[num8].ProductInfo[num9].iapProductID = dataContent.StoreIAPs[num7].iapProductID;
						ProductGroup[num8].ProductInfo[num9].iapValue = dataContent.StoreIAPs[num7].iapValue;
						ProductGroup[num8].ProductInfo[num9].iapType = 1;
						ProductGroup[num8].ProductInfo[num9].characterNumber = dataContent.StoreIAPs[num7].characterNumber;
						ProductGroup[num8].ProductInfo[num9].characterDifficulty = 0;
						ProductGroup[num8].ProductInfo[num9].characterCompletion = PlayerPrefs.GetInt(dataContent.StoreIAPs[num7].iapID + "completionPercent");
						ProductGroup[num8].ProductInfo[num9].miscDescription = dataContent.StoreIAPs[num7].miscDescription;
						num7++;
					}
				}
			}
		}
		if (characterSelectType == 0)
		{
			for (int num10 = 0; num10 < ProductGroup.Length; num10++)
			{
				for (int num11 = 0; num11 < ProductGroup[num11].ProductInfo.Length; num11++)
				{
					if (ProductGroup[num10].ProductInfo[num11].iapName == string.Empty && linkIcon == 0)
					{
						ProductGroup[num10].ProductInfo[num11].iapName = "Store Menu Link";
						ProductGroup[num10].ProductInfo[num11].iapID = string.Empty;
						ProductGroup[num10].ProductInfo[num11].iapState = -1;
						ProductGroup[num10].ProductInfo[num11].iapProductID = string.Empty;
						ProductGroup[num10].ProductInfo[num11].iapValue = string.Empty;
						ProductGroup[num10].ProductInfo[num11].iapType = -1;
						ProductGroup[num10].ProductInfo[num11].characterNumber = 0;
						ProductGroup[num10].ProductInfo[num11].characterDifficulty = 0;
						ProductGroup[num10].ProductInfo[num11].characterCompletion = 0;
						ProductGroup[num10].ProductInfo[num11].miscDescription = string.Empty;
						linkIcon = 1;
					}
				}
			}
		}
		characterPages = -1;
		for (int num12 = 0; num12 < ProductGroup.Length; num12++)
		{
			if (ProductGroup[num12].ProductInfo[0].iapName != string.Empty)
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
		if (characterPages > 1)
		{
			pageText.text = string.Empty + (currentCharacterPage + 1) + " | " + (characterPages + 1);
			pageText.Commit();
		}
		else
		{
			pageText.text = string.Empty;
			pageText.Commit();
		}
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
		if (currentCharacterPage == 0)
		{
			if (characterSelectType == 0 && !characterHighlight.enabled)
			{
				characterHighlight.enabled = true;
			}
		}
		else if (characterHighlight.enabled)
		{
			characterHighlight.enabled = false;
		}
		for (int i = 0; i < ProductGroup[currentCharacterPage].ProductInfo.Length; i++)
		{
			if (ProductGroup[currentCharacterPage].ProductInfo[i].iapName != string.Empty)
			{
				CharacterSelect[i].iconTrigger.active = true;
				if (ProductGroup[currentCharacterPage].ProductInfo[i].iapState == 2)
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
				else if (ProductGroup[currentCharacterPage].ProductInfo[i].iapState == 1)
				{
					CharacterSelect[i].characterIcon.Play("iap_" + ProductGroup[currentCharacterPage].ProductInfo[i].iapID);
					CharacterSelect[i].characterDifficulty.Play("iap_difficulty_" + ProductGroup[currentCharacterPage].ProductInfo[i].characterDifficulty);
					CharacterSelect[i].characterCompletion.text = string.Empty + ProductGroup[currentCharacterPage].ProductInfo[i].characterCompletion + "%";
					CharacterSelect[i].characterCompletion.Commit();
					CharacterSelect[i].storeIcon.enabled = false;
					CharacterSelect[i].iapState = 1;
					CharacterSelect[i].characterNumber = ProductGroup[currentCharacterPage].ProductInfo[i].characterNumber;
					CharacterSelect[i].characterID = ProductGroup[currentCharacterPage].ProductInfo[i].iapID;
					CharacterSelect[i].characterPrice = string.Empty;
				}
				else if (ProductGroup[currentCharacterPage].ProductInfo[i].iapState == 0)
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
				else if (ProductGroup[currentCharacterPage].ProductInfo[i].iapState == -1)
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
		Color color = lockInfoText.color;
		if (color.a > 0f)
		{
			if (Time.time < TIMER_lockInfo)
			{
				ALPHA_lockInfoText = 1f;
			}
			else if (Time.time >= TIMER_lockInfo)
			{
				ALPHA_lockInfoText -= 0.01f;
				lockInfoText.color = new Color(1f, 1f, 1f, ALPHA_lockInfoText);
				lockInfoText.Commit();
			}
		}
	}

	private void ToggleCharacterScreenFunction()
	{
		Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
		characterSelectionTransition.transitionNumber = 5;
		switch (CharacterSelect[toggleButtonNumber].iapState)
		{
		case -1:
			Application.OpenURL("http://fantasync.com/");
			break;
		case 0:
			characterMenu.menuState = 2;
			break;
		case 1:
			characterMenu.menuState = 1;
			break;
		}
		characterMenu.viewCharacterID = CharacterSelect[toggleButtonNumber].characterID;
		CameraScreenTransition.control.uniqueScreenTransition = toggleButtonNumber;
		characterMenuTransition.transitionNumber = 0;
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
		if (hitInfo.collider.transform.name == "cs_previous")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			previousPage = true;
		}
		if (hitInfo.collider.transform.name == "cs_next")
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
			nextPage = true;
		}
		if (hitInfo.collider.transform.name == "ms_home")
		{
		}
		if (pageInfoState == 1)
		{
			if (CharacterSelect[toggleButtonNumber].iapState == 1)
			{
				if (hitInfo.collider.transform.name == "cd_select")
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
					if (data.selectedCharacterID != CharacterSelect[toggleButtonNumber].characterID)
					{
						data.SelectCharacter(CharacterSelect[toggleButtonNumber].characterID);
						characterMenu.selectedCharacterID = CharacterSelect[toggleButtonNumber].characterID;
						characterMenu.viewCharacterID = string.Empty;
					}
					stageControl.state = 0;
					scriptMenuLogic.characterScreenToggle = 1;
					if (characterSelectType == 0)
					{
						toggleButtonNumber = 0;
					}
					scriptMenuLogic.menuNumber = 2;
					pageInfoState = -3;
				}
				if (hitInfo.collider.transform.name == "ms_challenge" && PlayerPrefs.GetInt(CharacterSelect[toggleButtonNumber].characterID + "levelProgress") >= maximumGameLevel)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
					if (data.selectedCharacterID != CharacterSelect[toggleButtonNumber].characterID)
					{
						data.SelectCharacter(CharacterSelect[toggleButtonNumber].characterID);
						characterMenu.selectedCharacterID = CharacterSelect[toggleButtonNumber].characterID;
						characterMenu.viewCharacterID = string.Empty;
					}
					stageControl.state = 0;
					scriptMenuLogic.characterScreenToggle = 1;
					if (characterSelectType == 0)
					{
						toggleButtonNumber = 0;
					}
					ScriptsManager.stageControlScript.stageNumber = 3;
					scriptMenuLogic.menuNumber = 3;
					pageInfoState = -3;
				}
			}
			else if (CharacterSelect[toggleButtonNumber].iapState == 0 && hitInfo.collider.transform.name == "cd_unlock")
			{
				switch (unlockMode)
				{
				case 0:
					if (data.playerKey > 0)
					{
						data.PlayerKey(-1);
						Camera.main.GetComponent<AudioSource>().PlayOneShot(specialClick);
						if (data.soundMode == 0)
						{
							ScriptsManager.gameMusicScript.specialVolume = 0.1f;
							ScriptsManager.gameMusicScript.specialDuration = 6f;
						}
						data.characterUnlock(CharacterSelect[toggleButtonNumber].characterID);
						data.SelectCharacter(CharacterSelect[toggleButtonNumber].characterID);
						characterMenu.selectedCharacterID = CharacterSelect[toggleButtonNumber].characterID;
						stageControl.state = 0;
						scriptMenuLogic.characterScreenToggle = 2;
						toggleButtonNumber = 0;
						characterMenu.viewCharacterID = string.Empty;
						pageInfoState = -3;
					}
					else if (data.playerKey <= 0)
					{
						Camera.main.GetComponent<AudioSource>().PlayOneShot(deniedClick);
						lockPopEffect.activate = true;
						lockInfoPopEffect.activate = true;
						lockInfoText.text = "require a jinx key to unlock";
						lockInfoText.color = Color.white;
						TIMER_lockInfo = Time.time + 1f;
						lockInfoText.Commit();
					}
					break;
				case 1:
					if (CharacterSelect[toggleButtonNumber].characterID == "WL")
					{
						characterToCharacterUnlock("WL", "WZ");
					}
					if (CharacterSelect[toggleButtonNumber].characterID == "WT")
					{
						characterToCharacterUnlock("WT", "WL");
					}
					break;
				}
			}
		}
		if (hitInfo.collider.transform.name == "Tcs_1")
		{
			toggleButtonNumber = 0;
			ToggleCharacterScreenFunction();
		}
		if (hitInfo.collider.transform.name == "Tcs_2")
		{
			toggleButtonNumber = 1;
			ToggleCharacterScreenFunction();
		}
		if (hitInfo.collider.transform.name == "Tcs_3")
		{
			toggleButtonNumber = 2;
			ToggleCharacterScreenFunction();
		}
		if (hitInfo.collider.transform.name == "Tcs_4")
		{
			toggleButtonNumber = 3;
			ToggleCharacterScreenFunction();
		}
		if (hitInfo.collider.transform.name == "Tcs_5")
		{
			toggleButtonNumber = 4;
			ToggleCharacterScreenFunction();
		}
		if (hitInfo.collider.transform.name == "Tcs_6")
		{
			toggleButtonNumber = 5;
			ToggleCharacterScreenFunction();
		}
		if (!(hitInfo.collider.transform.name == "ms_home"))
		{
		}
	}

	private void characterToCharacterUnlock(string selectedCharacter, string requiredCharacter)
	{
		if (PlayerPrefs.GetInt(requiredCharacter + "nextBookUnlock") == 1)
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(specialClick);
			if (data.soundMode == 0)
			{
				ScriptsManager.gameMusicScript.specialVolume = 0.1f;
				ScriptsManager.gameMusicScript.specialDuration = 6f;
			}
			PlayerPrefs.SetInt(selectedCharacter + "GCunlock", 1);
			data.characterUnlock(selectedCharacter);
			data.SelectCharacter(selectedCharacter);
			characterMenu.selectedCharacterID = selectedCharacter;
			stageControl.state = 0;
			scriptMenuLogic.characterScreenToggle = 2;
			toggleButtonNumber = 0;
			characterMenu.viewCharacterID = string.Empty;
			ScriptsManager.dataScript.iCloudData(3, "null", 0);
			pageInfoState = -3;
		}
		else
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(deniedClick);
			lockPopEffect.activate = true;
			lockInfoPopEffect.activate = true;
			lockInfoText.text = "complete " + PlayerPrefs.GetString(requiredCharacter + "characterName") + " the " + PlayerPrefs.GetString(requiredCharacter + "characterClass") + "'s\nfirst stage to unlock";
			lockInfoText.color = Color.white;
			TIMER_lockInfo = Time.time + 1f;
			lockInfoText.Commit();
		}
	}
}
