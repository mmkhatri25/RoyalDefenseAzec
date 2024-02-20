using System;
using UnityEngine;

public class UnlockScene : MonoBehaviour
{
	[Serializable]
	public class unlockList
	{
		public int unlockType;

		public string name;

		public string animationID;

		public string unlockInfo;

		public int tierNumber;
	}

	public string LoadScene;

	public AudioClip nextButton;

	public AudioClip unlockSound;

	public bool next;

	private int state = -1;

	public int unlockNumber;

	private int TOGGLE_unlockNumber = -1;

	public unlockList[] UnlockList = new unlockList[5];

	private int AMOUNT_unlockInfoItemNumber;

	private int AMOUNT_unlockInfoScrollNumber;

	private int AMOUNT_unlockInfoAccessoryNumber;

	public MenuTransition guardTransition;

	public MenuTransition doorTransition;

	public pop_effect unlockPopEffect;

	public pop_effect buttonPopEffect;

	public tk2dAnimatedSprite itemIconSprite;

	public tk2dAnimatedSprite itemBgSprite;

	public tk2dAnimatedSprite modeIconSprite;

	public tk2dTextMesh titleText;

	public tk2dTextMesh unlockNameText;

	public tk2dTextMesh unlockInfoText;

	public float delay;

	private float TIMER_delay;

	private Game_Data data;

	private level_setup levelSetup;

	private Content_Data contentData;

	private Item_Content_Data itemcontentData;

	private void Start()
	{
		data = ScriptsManager.dataScript;
		levelSetup = ScriptsManager.levelSetupScript;
		contentData = ScriptsManager.contentDataScript;
		LoadScene = levelSetup.LoadScene;
		itemcontentData = ScriptsManager.itemContentDataScript;
		if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") >= data.gameLevelPerStage)
		{
			UnlockItemSetup(0);
		}
		if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") >= data.gameLevelPerStage * 2)
		{
			UnlockItemSetup(1);
		}
		if (PlayerPrefs.GetInt(data.selectedCharacterID + "levelProgress") >= data.gameMaximumLevel)
		{
			UnlockItemSetup(2);
		}
		if (PlayerPrefs.GetInt(data.selectedCharacterID + "completionPercent") >= 100)
		{
			data.GameAnalytics("story:allGold", 0f);
			data.GameAnalytics("story:allGold:attempts:" + PlayerPrefs.GetInt(data.selectedCharacterID + "statStoryAttempts"), 0f);
			UnlockItemSetup(3);
		}
		if (UnlockList[0].name == string.Empty && LoadScene != string.Empty)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(LoadScene);
		}
		TIMER_delay = Time.time + 0.5f;
	}

	private void UnlockItemSetup(int unlockNumber)
	{
		if (levelSetup.ItemUnlockID[unlockNumber].itemState != 0 || !(levelSetup.ItemUnlockID[unlockNumber].itemID != string.Empty))
		{
			return;
		}
		for (int i = 0; i < UnlockList.Length; i++)
		{
			if (!(UnlockList[i].name == string.Empty))
			{
				continue;
			}
			AMOUNT_unlockInfoItemNumber = 1;
			AMOUNT_unlockInfoScrollNumber = 1;
			AMOUNT_unlockInfoAccessoryNumber = 1;
			for (int j = 0; j < itemcontentData.ItemIDs.Length; j++)
			{
				if (itemcontentData.ItemIDs[j].itemID == levelSetup.ItemUnlockID[unlockNumber].itemID)
				{
					UnlockList[i].unlockType = itemcontentData.ItemIDs[j].itemClass;
					UnlockList[i].name = itemcontentData.ItemIDs[j].itemName;
					UnlockList[i].animationID = itemcontentData.ItemIDs[j].itemID;
					switch (UnlockList[i].unlockType)
					{
					case 1:
						UnlockList[i].unlockInfo = string.Empty + AMOUNT_unlockInfoItemNumber;
						break;
					case 2:
						UnlockList[i].unlockInfo = string.Empty + AMOUNT_unlockInfoScrollNumber;
						break;
					case 3:
						UnlockList[i].unlockInfo = string.Empty + AMOUNT_unlockInfoAccessoryNumber;
						break;
					}
				}
				else
				{
					switch (itemcontentData.ItemIDs[j].itemClass)
					{
					case 1:
						AMOUNT_unlockInfoItemNumber++;
						break;
					case 2:
						AMOUNT_unlockInfoScrollNumber++;
						break;
					case 3:
						AMOUNT_unlockInfoAccessoryNumber++;
						break;
					}
				}
				UnlockList[i].tierNumber = unlockNumber + 1;
			}
			i = UnlockList.Length + 1;
		}
		PlayerPrefs.SetInt(levelSetup.ItemUnlockID[unlockNumber].itemID + "itemLock", 1);
		levelSetup.ItemUnlockID[unlockNumber].itemState = 1;
	}

	private void Update()
	{
		if (state < 0)
		{
			state++;
		}
		else if (state == 0)
		{
			if (unlockNumber < UnlockList.Length && UnlockList[unlockNumber].unlockType != 0)
			{
				if (TOGGLE_unlockNumber != unlockNumber)
				{
					TIMER_delay = Time.time + delay;
					CameraScreenTransition.control.SceneTransition(0, string.Empty);
					TOGGLE_unlockNumber = unlockNumber;
				}
				else
				{
					if (!(Time.time >= TIMER_delay))
					{
						return;
					}
					if (next)
					{
						unlockNumber++;
						next = false;
					}
					if (CameraScreenTransition.control.transitionDirection == 0)
					{
						unlockNameText.text = UnlockList[unlockNumber].name;
						switch (UnlockList[unlockNumber].unlockType)
						{
						case 1:
							titleText.text = "a new item";
							itemIconSprite.Play(string.Empty + UnlockList[unlockNumber].animationID);
							itemBgSprite.Play("Item Icon 1");
							break;
						case 2:
							titleText.text = "a new scroll";
							itemIconSprite.Play(string.Empty + UnlockList[unlockNumber].animationID);
							itemBgSprite.Play("Item Icon 2");
							break;
						case 3:
							titleText.text = "a new accessory";
							itemIconSprite.Play(string.Empty + UnlockList[unlockNumber].animationID);
							itemBgSprite.Play("Item Icon 3");
							break;
						}
						switch (UnlockList[unlockNumber].tierNumber)
						{
						case 0:
							unlockInfoText.text = string.Empty;
							break;
						case 1:
							unlockInfoText.text = "STAGE 1 COMPLETE";
							break;
						case 2:
							unlockInfoText.text = "STAGE 2 COMPLETE";
							break;
						case 3:
							unlockInfoText.text = "BOOK COMPLETE";
							break;
						case 4:
							unlockInfoText.text = "ALL GOLD ACHIEVED";
							break;
						}
						unlockNameText.Commit();
						titleText.Commit();
						unlockInfoText.Commit();
						unlockPopEffect.activate = true;
						if (data.soundMode != 2)
						{
							GetComponent<AudioSource>().PlayOneShot(unlockSound);
						}
						CameraScreenTransition.control.SceneTransition(1, string.Empty);
					}
					ButtonFunction();
				}
			}
			else if (unlockNumber >= UnlockList.Length || UnlockList[unlockNumber].unlockType == 0)
			{
				CameraScreenTransition.control.SceneTransition(0, string.Empty);
				TIMER_delay = Time.time + delay * 2f;
				state++;
			}
		}
		else if (state == 1 && Time.time >= TIMER_delay && LoadScene != string.Empty)
		{
			ScriptsManager.dataScript.iCloudData(3, "null", 0);
			CameraScreenTransition.control.SceneTransition(0, string.Empty);
			UnityEngine.SceneManagement.SceneManager.LoadScene(LoadScene);
		}
	}

	private void ButtonFunction()
	{
		if (!Input.GetMouseButtonUp(0))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.transform.name == "BTN_CONTINUE")
		{
			if (data.soundMode != 2)
			{
				GetComponent<AudioSource>().PlayOneShot(nextButton);
			}
			buttonPopEffect.activate = true;
			next = true;
		}
	}
}
