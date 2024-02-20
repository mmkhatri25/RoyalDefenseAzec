using System;
using UnityEngine;

public class Item_Control : MonoBehaviour
{
	[Serializable]
	public class shopItems
	{
		[Serializable]
		public class itemInfos
		{
			public string itemName;

			public int itemCost;

			public string itemID;

			public string itemIconID;

			public int itemManaValue;

			public int itemShopAmount;

			public int itemBG;

			public string itemDescriptionLine1;

			public string itemDescriptionLine2;
		}

		public string ClassNames;

		public int itemClassAmount;

		public itemInfos[] ItemInfos = new itemInfos[100];
	}

	[Serializable]
	public class shopHUDSlots
	{
		public GameObject shopHUDSlot_Gameobject;

		public GameObject shopHUDSlot_IconGameObject;

		public pop_effect shopHUDSlot_PopEffect;

		public tk2dAnimatedSprite shopHUDSlot_Icon;

		public tk2dAnimatedSprite shopHUDSlot_ManaCostIcon;

		public tk2dAnimatedSprite shopHUDSlot_BG;

		public tk2dAnimatedSprite shopHUDSlot_Class;

		public GameObject shopHUDSlot_ClassObject;

		public tk2dAnimatedSprite shopHUDSlot_Amount;
	}

	[Serializable]
	public class shopItemRandomSlots
	{
		public int itemNumber;

		public int itemClass;

		public string itemID;

		public int itemShopAmount;
	}

	public int state;

	public int playerCurrency;

	public GameObject iapButton;

	public GameObject shopButton;

	public bool shopMenu;

	public AudioClip accessMenu;

	public AudioClip selectionGranted;

	public AudioClip selectionDenied;

	public AudioClip itemRandomingClip;

	public AudioClip itemRandomedClip;

	public AudioClip itemDropped;

	private int menuState;

	public shopItems[] ShopItems = new shopItems[3];

	public shopHUDSlots[] ShopHUDSlots = new shopHUDSlots[3];

	public GameObject shopHighlighter;

	public GameObject shopSelectHighlighter;

	private bool shopSelectionChange;

	private int selectedSlot;

	private int selectedClassSlot;

	private int selectedNumberSlot;

	private int selectedItemCost;

	public tk2dTextMesh subMenuItemName;

	public tk2dTextMesh subMenuItemCost;

	public tk2dTextMesh subMenuDescriptionLine1;

	public tk2dTextMesh subMenuDescriptionLine2;

	public GameObject purchaseTrigger;

	public GameObject itemOneGameobject;

	public int itemOneType;

	public int itemOneSubType;

	public string itemOneID;

	public GameObject itemTwoGameobject;

	public int itemTwoType;

	public int itemTwoSubType;

	public string itemTwoID;

	public int itemSlotAvailable;

	public HUD_Control scriptHudControl;

	public Item_Content_Data contentData;

	public level_setup levelSetup;

	private GameMasterScriptsControl scriptMasterControl;

	private Game_Statistics scriptGameStatistic;

	public tk2dTextMesh currencyText;

	public pop_effect currencyPopEffect;

	public GameObject itemPopUp;

	public int itemOneState = 1;

	public GameObject itemOnePrefab;

	public GameObject itemOnePassivePrefab;

	public SpriteAnim_Script itemOneIcon;

	public SpriteAnim_Script itemOneBG;

	public GameObject itemOneHighlighter;

	public pop_effect itemOnePopEffect;

	public tk2dAnimatedSprite itemOneChargeCost;

	public Renderer itemOneDropIcon;

	private int itemOneCharges;

	private int itemOneManaCost;

	public BarMetre_Script itemOneCoolDownBar;

	public float itemOneCoolDown;

	public float TIMER_itemOneCoolDown;

	private int itemOneScrollType;

	private int itemOneIndicatorType;

	private float itemOneScrollDirection;

	private float itemOneCentreScrollTypeHeight;

	private AudioClip itemOneScrollActivateSound;

	public int itemTwoState = 1;

	public GameObject itemTwoPrefab;

	public GameObject itemTwoPassivePrefab;

	public SpriteAnim_Script itemTwoIcon;

	public SpriteAnim_Script itemTwoBG;

	public GameObject itemTwoHighlighter;

	public pop_effect itemTwoPopEffect;

	public tk2dAnimatedSprite itemTwoChargeCost;

	public Renderer itemTwoDropIcon;

	private int itemTwoCharges;

	private int itemTwoManaCost;

	public BarMetre_Script itemTwoCoolDownBar;

	private float itemTwoCoolDown;

	private float TIMER_itemTwoCoolDown;

	private int itemTwoScrollType;

	private int itemTwoIndicatorType;

	private float itemTwoScrollDirection;

	private float itemTwoCentreScrollTypeHeight;

	private AudioClip itemTwoScrollActivateSound;

	public GameObject itemScrollCaster;

	private Transform SCROLL_inst;

	private Transform CONSUMABLE_inst;

	private Transform itemOnePassivePrefabInst;

	private Transform itemTwoPassivePrefabInst;

	private Vector3 scrollStart;

	private string characterID;

	private string itemOneNameID;

	private string itemTwoNameID;

	private int statisticConsumableUseValue = 1;

	private int statisticScrollUseValue = 1;

	private int statisticAccessoryEquipValue = 1;

	private int statisticAccessoryUpKeepValue = 1;

	private int TOGGLEWAVE_StatisticAccessoryUpKeepValue;

	private int TOGGLE_scoreWavesCompleted;

	public int shopItemSlotRerollCost = 10;

	public int shopItemSlotRandomState;

	private int TOGGLE_shopItemSlotRandomState;

	public shopItemRandomSlots[] ShopItemRandomSlots = new shopItemRandomSlots[4];

	private string RANDOMEFFECT_itemID1;

	private int RANDOMEFFECT_itemNumber;

	private int RANDOMEFFECT_itemClass;

	private string RANDOMEFFECT_itemID;

	private int RANDOMEFFECT_randomEffectAmount;

	private float RANDOMEFFECT_itemDuration = 0.01f;

	private float TIMERRANDOMEFFECT_itemDuration;

	public tk2dTextMesh rerollCostText;

	private int MULTIPLIER_shopItemSlotRerollCost = 1;

	private int TOGGLE_currencyAmount;

	private void Start()
	{
		base.useGUILayout = false;
		scrollStart = new Vector3(-3.4f, 1.25f, 0f);
		itemOneChargeCost.Play("blank");
		itemTwoChargeCost.Play("blank");
		selectedSlot = -1;
		shopSelectionChange = true;
		scriptMasterControl = GameScriptsManager.masterControlScript;
		scriptGameStatistic = GameScriptsManager.gameStatisticScript;
		if (contentData == null)
		{
			contentData = ScriptsManager.itemContentDataScript;
		}
		levelSetup = ScriptsManager.levelSetupScript;
		if (levelSetup != null)
		{
			ShopSetupFunction();
		}
		if (scriptMasterControl.iapMode == 0)
		{
			iapButton.SetActiveRecursively(state: false);
		}
		characterID = scriptMasterControl.characterID;
	}

	private void ShopSetupFunction()
	{
		for (int i = 0; i < ShopItems[0].ItemInfos.Length; i++)
		{
			if (levelSetup.ShopItems[0].ItemInfos[i].itemName != string.Empty)
			{
				ShopItems[0].ItemInfos[i].itemName = levelSetup.ShopItems[0].ItemInfos[i].itemName;
				ShopItems[0].ItemInfos[i].itemID = levelSetup.ShopItems[0].ItemInfos[i].itemID;
				ShopItems[0].ItemInfos[i].itemCost = levelSetup.ShopItems[0].ItemInfos[i].itemCost;
				ShopItems[0].ItemInfos[i].itemIconID = levelSetup.ShopItems[0].ItemInfos[i].itemIconID;
				ShopItems[0].ItemInfos[i].itemShopAmount = levelSetup.ShopItems[0].ItemInfos[i].itemShopAmount;
				ShopItems[0].ItemInfos[i].itemManaValue = 0;
				ShopItems[0].ItemInfos[i].itemBG = levelSetup.ShopItems[0].ItemInfos[i].itemBG;
				ShopItems[0].ItemInfos[i].itemDescriptionLine1 = levelSetup.ShopItems[0].ItemInfos[i].itemDescriptionLine1;
				ShopItems[0].ItemInfos[i].itemDescriptionLine2 = levelSetup.ShopItems[0].ItemInfos[i].itemDescriptionLine2;
				ShopItems[0].itemClassAmount++;
			}
		}
		for (int j = 0; j < ShopItems[1].ItemInfos.Length; j++)
		{
			if (levelSetup.ShopItems[1].ItemInfos[j].itemName != string.Empty)
			{
				ShopItems[1].ItemInfos[j].itemName = levelSetup.ShopItems[1].ItemInfos[j].itemName;
				ShopItems[1].ItemInfos[j].itemID = levelSetup.ShopItems[1].ItemInfos[j].itemID;
				ShopItems[1].ItemInfos[j].itemCost = levelSetup.ShopItems[1].ItemInfos[j].itemCost;
				ShopItems[1].ItemInfos[j].itemIconID = levelSetup.ShopItems[1].ItemInfos[j].itemIconID;
				ShopItems[1].ItemInfos[j].itemShopAmount = levelSetup.ShopItems[1].ItemInfos[j].itemShopAmount;
				ShopItems[1].ItemInfos[j].itemManaValue = levelSetup.ShopItems[1].ItemInfos[j].itemManaValue;
				ShopItems[1].ItemInfos[j].itemBG = levelSetup.ShopItems[1].ItemInfos[j].itemBG;
				ShopItems[1].ItemInfos[j].itemDescriptionLine1 = levelSetup.ShopItems[1].ItemInfos[j].itemDescriptionLine1;
				ShopItems[1].ItemInfos[j].itemDescriptionLine2 = levelSetup.ShopItems[1].ItemInfos[j].itemDescriptionLine2;
				ShopItems[1].itemClassAmount++;
			}
		}
		for (int k = 0; k < ShopItems[2].ItemInfos.Length; k++)
		{
			if (levelSetup.ShopItems[2].ItemInfos[k].itemName != string.Empty)
			{
				ShopItems[2].ItemInfos[k].itemName = levelSetup.ShopItems[2].ItemInfos[k].itemName;
				ShopItems[2].ItemInfos[k].itemID = levelSetup.ShopItems[2].ItemInfos[k].itemID;
				ShopItems[2].ItemInfos[k].itemCost = levelSetup.ShopItems[2].ItemInfos[k].itemCost;
				ShopItems[2].ItemInfos[k].itemIconID = levelSetup.ShopItems[2].ItemInfos[k].itemIconID;
				ShopItems[2].ItemInfos[k].itemShopAmount = levelSetup.ShopItems[2].ItemInfos[k].itemShopAmount;
				ShopItems[2].ItemInfos[k].itemManaValue = 0;
				ShopItems[2].ItemInfos[k].itemBG = levelSetup.ShopItems[2].ItemInfos[k].itemBG;
				ShopItems[2].ItemInfos[k].itemDescriptionLine1 = levelSetup.ShopItems[2].ItemInfos[k].itemDescriptionLine1;
				ShopItems[2].ItemInfos[k].itemDescriptionLine2 = levelSetup.ShopItems[2].ItemInfos[k].itemDescriptionLine2;
				ShopItems[2].itemClassAmount++;
			}
		}
	}

	private void Update()
	{
		if ((itemOneType == 3 || itemTwoType == 3) && TOGGLEWAVE_StatisticAccessoryUpKeepValue != scriptGameStatistic.scoreWavesCompleted)
		{
			if (itemOneType == 3)
			{
				PlayerPrefs.SetInt(characterID + "_" + itemOneID, PlayerPrefs.GetInt(characterID + "_" + itemOneID) + statisticAccessoryUpKeepValue);
				ScriptsManager.dataScript.GameAnalytics("item:value:" + itemOneNameID, 0f);
			}
			if (itemTwoType == 3)
			{
				PlayerPrefs.SetInt(characterID + "_" + itemTwoID, PlayerPrefs.GetInt(characterID + "_" + itemTwoID) + statisticAccessoryUpKeepValue);
				ScriptsManager.dataScript.GameAnalytics("item:value:" + itemTwoNameID, 0f);
			}
			TOGGLEWAVE_StatisticAccessoryUpKeepValue = scriptGameStatistic.scoreWavesCompleted;
		}
		ShopFuntion();
		StatisticsFunction();
		ItemFuntion();
		ItemSystemFuntion();
		ItemCoolDownFunction();
		HUDFunction();
		HUDInteraction();
	}

	private void ShopFuntion()
	{
		if (shopItemSlotRandomState > 2 && ShopItemRandomSlots[0].itemClass != -1)
		{
			Vector3 localPosition = ShopHUDSlots[0].shopHUDSlot_ClassObject.transform.localPosition;
			if (localPosition.y != 0.8f)
			{
				Transform transform = ShopHUDSlots[0].shopHUDSlot_ClassObject.transform;
				Vector3 localPosition2 = ShopHUDSlots[0].shopHUDSlot_ClassObject.transform.localPosition;
				Vector3 localPosition3 = ShopHUDSlots[0].shopHUDSlot_ClassObject.transform.localPosition;
				float x = localPosition3.x;
				Vector3 localPosition4 = ShopHUDSlots[0].shopHUDSlot_ClassObject.transform.localPosition;
				transform.localPosition = Vector3.Lerp(localPosition2, new Vector3(x, 0.8f, localPosition4.z), 0.2f);
			}
		}
		if (shopItemSlotRandomState > 3 && ShopItemRandomSlots[1].itemClass != -1)
		{
			Vector3 localPosition5 = ShopHUDSlots[1].shopHUDSlot_ClassObject.transform.localPosition;
			if (localPosition5.y != 0.8f)
			{
				Transform transform2 = ShopHUDSlots[1].shopHUDSlot_ClassObject.transform;
				Vector3 localPosition6 = ShopHUDSlots[1].shopHUDSlot_ClassObject.transform.localPosition;
				Vector3 localPosition7 = ShopHUDSlots[1].shopHUDSlot_ClassObject.transform.localPosition;
				float x2 = localPosition7.x;
				Vector3 localPosition8 = ShopHUDSlots[1].shopHUDSlot_ClassObject.transform.localPosition;
				transform2.localPosition = Vector3.Lerp(localPosition6, new Vector3(x2, 0.8f, localPosition8.z), 0.2f);
			}
		}
		if (shopItemSlotRandomState > 4 && ShopItemRandomSlots[2].itemClass != -1)
		{
			Vector3 localPosition9 = ShopHUDSlots[2].shopHUDSlot_ClassObject.transform.localPosition;
			if (localPosition9.y != 0.8f)
			{
				Transform transform3 = ShopHUDSlots[2].shopHUDSlot_ClassObject.transform;
				Vector3 localPosition10 = ShopHUDSlots[2].shopHUDSlot_ClassObject.transform.localPosition;
				Vector3 localPosition11 = ShopHUDSlots[2].shopHUDSlot_ClassObject.transform.localPosition;
				float x3 = localPosition11.x;
				Vector3 localPosition12 = ShopHUDSlots[2].shopHUDSlot_ClassObject.transform.localPosition;
				transform3.localPosition = Vector3.Lerp(localPosition10, new Vector3(x3, 0.8f, localPosition12.z), 0.2f);
			}
		}
		if (shopItemSlotRandomState > 5 && ShopItemRandomSlots[3].itemClass != -1)
		{
			Vector3 localPosition13 = ShopHUDSlots[3].shopHUDSlot_ClassObject.transform.localPosition;
			if (localPosition13.y != 0.8f)
			{
				Transform transform4 = ShopHUDSlots[3].shopHUDSlot_ClassObject.transform;
				Vector3 localPosition14 = ShopHUDSlots[3].shopHUDSlot_ClassObject.transform.localPosition;
				Vector3 localPosition15 = ShopHUDSlots[3].shopHUDSlot_ClassObject.transform.localPosition;
				float x4 = localPosition15.x;
				Vector3 localPosition16 = ShopHUDSlots[3].shopHUDSlot_ClassObject.transform.localPosition;
				transform4.localPosition = Vector3.Lerp(localPosition14, new Vector3(x4, 0.8f, localPosition16.z), 0.2f);
			}
		}
		if (shopItemSlotRandomState < 6 && shopItemSlotRandomState > 2 && !shopMenu)
		{
			shopItemSlotRandomState = 6;
		}
		switch (shopItemSlotRandomState)
		{
		case 0:
		{
			TOGGLE_scoreWavesCompleted = scriptGameStatistic.scoreWavesCompleted;
			rerollCostText.text = string.Empty + shopItemSlotRerollCost * MULTIPLIER_shopItemSlotRerollCost;
			rerollCostText.Commit();
			selectedSlot = -1;
			shopSelectionChange = true;
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			Transform transform5 = shopHighlighter.transform;
			Vector3 position = shopHighlighter.transform.position;
			float x5 = position.x + 100f;
			Vector3 position2 = shopHighlighter.transform.position;
			transform5.position = new Vector3(x5, position2.y, -7.025f);
			for (int i = 0; i < ShopHUDSlots.Length; i++)
			{
				ShopHUDSlots[i].shopHUDSlot_PopEffect.regularScale = 1f;
				ShopHUDSlots[i].shopHUDSlot_Icon.Play("blank");
				ShopHUDSlots[i].shopHUDSlot_BG.Play("Item Icon 0");
				ShopHUDSlots[i].shopHUDSlot_Amount.Play("blank");
				ShopHUDSlots[i].shopHUDSlot_ManaCostIcon.Play("blank");
				Transform transform6 = ShopHUDSlots[i].shopHUDSlot_ClassObject.transform;
				Vector3 localPosition17 = ShopHUDSlots[i].shopHUDSlot_ClassObject.transform.localPosition;
				float x6 = localPosition17.x;
				Vector3 localPosition18 = ShopHUDSlots[i].shopHUDSlot_ClassObject.transform.localPosition;
				float y = localPosition18.y + 5f;
				Vector3 localPosition19 = ShopHUDSlots[i].shopHUDSlot_ClassObject.transform.localPosition;
				transform6.localPosition = new Vector3(x6, y, localPosition19.z);
			}
			for (int j = 0; j < ShopItemRandomSlots.Length; j++)
			{
				ShopItemRandomSlots[j].itemClass = UnityEngine.Random.Range(0, 3);
				ShopItemRandomSlots[j].itemNumber = UnityEngine.Random.Range(0, ShopItems[ShopItemRandomSlots[j].itemClass].itemClassAmount);
				ShopItemRandomSlots[j].itemID = ShopItems[ShopItemRandomSlots[j].itemClass].ItemInfos[ShopItemRandomSlots[j].itemNumber].itemID;
				switch (j)
				{
				case 0:
					while (ShopItemRandomSlots[j].itemID == RANDOMEFFECT_itemID1 || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[1].itemID || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[2].itemID || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[3].itemID)
					{
						ShopItemRandomSlots[j].itemClass = UnityEngine.Random.Range(0, 3);
						if (ShopItemRandomSlots[j].itemClass == 3)
						{
							ShopItemRandomSlots[j].itemClass = 2;
						}
						ShopItemRandomSlots[j].itemNumber = UnityEngine.Random.Range(0, ShopItems[ShopItemRandomSlots[j].itemClass].itemClassAmount);
						ShopItemRandomSlots[j].itemID = ShopItems[ShopItemRandomSlots[j].itemClass].ItemInfos[ShopItemRandomSlots[j].itemNumber].itemID;
					}
					RANDOMEFFECT_itemID1 = ShopItemRandomSlots[j].itemID;
					break;
				case 1:
					while (ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[0].itemID || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[2].itemID || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[3].itemID)
					{
						ShopItemRandomSlots[j].itemClass = UnityEngine.Random.Range(0, 3);
						if (ShopItemRandomSlots[j].itemClass == 3)
						{
							ShopItemRandomSlots[j].itemClass = 2;
						}
						ShopItemRandomSlots[j].itemNumber = UnityEngine.Random.Range(0, ShopItems[ShopItemRandomSlots[j].itemClass].itemClassAmount);
						ShopItemRandomSlots[j].itemID = ShopItems[ShopItemRandomSlots[j].itemClass].ItemInfos[ShopItemRandomSlots[j].itemNumber].itemID;
					}
					break;
				case 2:
					while (ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[0].itemID || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[1].itemID || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[3].itemID)
					{
						ShopItemRandomSlots[j].itemClass = UnityEngine.Random.Range(0, 3);
						if (ShopItemRandomSlots[j].itemClass == 3)
						{
							ShopItemRandomSlots[j].itemClass = 2;
						}
						ShopItemRandomSlots[j].itemNumber = UnityEngine.Random.Range(0, ShopItems[ShopItemRandomSlots[j].itemClass].itemClassAmount);
						ShopItemRandomSlots[j].itemID = ShopItems[ShopItemRandomSlots[j].itemClass].ItemInfos[ShopItemRandomSlots[j].itemNumber].itemID;
					}
					break;
				case 3:
					while (ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[0].itemID || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[1].itemID || ShopItemRandomSlots[j].itemID == ShopItemRandomSlots[2].itemID)
					{
						ShopItemRandomSlots[j].itemClass = UnityEngine.Random.Range(0, 3);
						if (ShopItemRandomSlots[j].itemClass == 3)
						{
							ShopItemRandomSlots[j].itemClass = 2;
						}
						ShopItemRandomSlots[j].itemNumber = UnityEngine.Random.Range(0, ShopItems[ShopItemRandomSlots[j].itemClass].itemClassAmount);
						ShopItemRandomSlots[j].itemID = ShopItems[ShopItemRandomSlots[j].itemClass].ItemInfos[ShopItemRandomSlots[j].itemNumber].itemID;
					}
					break;
				}
				if (ShopItemRandomSlots[j].itemClass == 0)
				{
					ShopItemRandomSlots[j].itemShopAmount = UnityEngine.Random.Range(1, ShopItems[ShopItemRandomSlots[j].itemClass].ItemInfos[ShopItemRandomSlots[j].itemNumber].itemShopAmount + 1);
				}
				else
				{
					ShopItemRandomSlots[j].itemShopAmount = -1;
				}
			}
			shopItemSlotRandomState++;
			break;
		}
		case 1:
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				scriptHudControl.shopButtonSprite.Play("shopButton 1");
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			if (TOGGLE_scoreWavesCompleted != scriptGameStatistic.scoreWavesCompleted)
			{
				shopItemSlotRandomState = 0;
			}
			if (shopMenu)
			{
				scriptHudControl.shopButtonSprite.Play("shopButton 0");
				shopItemSlotRandomState++;
			}
			break;
		case 2:
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				scriptHudControl.shopButtonSprite.Play("shopButton 0");
				Camera.main.GetComponent<AudioSource>().PlayOneShot(itemRandomingClip);
				RANDOMEFFECT_randomEffectAmount = 60;
				TIMERRANDOMEFFECT_itemDuration = 0f;
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			if (RANDOMEFFECT_randomEffectAmount > 0)
			{
				if (Time.realtimeSinceStartup >= TIMERRANDOMEFFECT_itemDuration)
				{
					for (int l = 0; l < ShopHUDSlots.Length; l++)
					{
						RANDOMEFFECT_itemClass = UnityEngine.Random.Range(0, 3);
						RANDOMEFFECT_itemNumber = UnityEngine.Random.Range(0, ShopItems[RANDOMEFFECT_itemClass].itemClassAmount);
						RANDOMEFFECT_itemID = ShopItems[RANDOMEFFECT_itemClass].ItemInfos[RANDOMEFFECT_itemNumber].itemID;
						ShopHUDSlots[l].shopHUDSlot_Icon.Play(RANDOMEFFECT_itemID);
						ShopHUDSlots[l].shopHUDSlot_BG.Play("Item Icon " + (RANDOMEFFECT_itemClass + 1));
					}
					RANDOMEFFECT_randomEffectAmount--;
					TIMERRANDOMEFFECT_itemDuration = Time.realtimeSinceStartup + RANDOMEFFECT_itemDuration;
				}
				break;
			}
			Camera.main.GetComponent<AudioSource>().PlayOneShot(itemRandomedClip);
			ShopHUDSlots[0].shopHUDSlot_Class.Play("itemClass_" + (ShopItemRandomSlots[0].itemClass + 1));
			ShopHUDSlots[0].shopHUDSlot_Icon.Play(ShopItemRandomSlots[0].itemID);
			ShopHUDSlots[0].shopHUDSlot_BG.Play("Item Icon " + (ShopItemRandomSlots[0].itemClass + 1));
			switch (ShopItemRandomSlots[0].itemClass)
			{
			case 0:
				ShopHUDSlots[0].shopHUDSlot_Amount.Play("charge " + ShopItemRandomSlots[0].itemShopAmount);
				break;
			case 1:
				ShopHUDSlots[0].shopHUDSlot_ManaCostIcon.Play("cost " + ShopItems[ShopItemRandomSlots[0].itemClass].ItemInfos[ShopItemRandomSlots[0].itemNumber].itemManaValue);
				break;
			}
			ShopHUDSlots[0].shopHUDSlot_PopEffect.activate = true;
			shopItemSlotRandomState++;
			break;
		case 3:
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				TIMERRANDOMEFFECT_itemDuration = 0f;
				RANDOMEFFECT_randomEffectAmount = 15;
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			if (RANDOMEFFECT_randomEffectAmount > 0)
			{
				if (Time.realtimeSinceStartup >= TIMERRANDOMEFFECT_itemDuration)
				{
					for (int num = 1; num < ShopHUDSlots.Length; num++)
					{
						RANDOMEFFECT_itemClass = UnityEngine.Random.Range(0, 2);
						RANDOMEFFECT_itemNumber = UnityEngine.Random.Range(0, ShopItems[RANDOMEFFECT_itemClass].itemClassAmount);
						RANDOMEFFECT_itemID = ShopItems[RANDOMEFFECT_itemClass].ItemInfos[RANDOMEFFECT_itemNumber].itemID;
						ShopHUDSlots[num].shopHUDSlot_Icon.Play(RANDOMEFFECT_itemID);
						ShopHUDSlots[num].shopHUDSlot_BG.Play("Item Icon " + (RANDOMEFFECT_itemClass + 1));
					}
					RANDOMEFFECT_randomEffectAmount--;
					TIMERRANDOMEFFECT_itemDuration = Time.realtimeSinceStartup + RANDOMEFFECT_itemDuration;
				}
				break;
			}
			Camera.main.GetComponent<AudioSource>().PlayOneShot(itemRandomedClip);
			ShopHUDSlots[1].shopHUDSlot_Class.Play("itemClass_" + (ShopItemRandomSlots[1].itemClass + 1));
			ShopHUDSlots[1].shopHUDSlot_Icon.Play(ShopItemRandomSlots[1].itemID);
			ShopHUDSlots[1].shopHUDSlot_BG.Play("Item Icon " + (ShopItemRandomSlots[1].itemClass + 1));
			switch (ShopItemRandomSlots[1].itemClass)
			{
			case 0:
				ShopHUDSlots[1].shopHUDSlot_Amount.Play("charge " + ShopItemRandomSlots[1].itemShopAmount);
				break;
			case 1:
				ShopHUDSlots[1].shopHUDSlot_ManaCostIcon.Play("cost " + ShopItems[ShopItemRandomSlots[1].itemClass].ItemInfos[ShopItemRandomSlots[1].itemNumber].itemManaValue);
				break;
			}
			ShopHUDSlots[1].shopHUDSlot_PopEffect.activate = true;
			shopItemSlotRandomState++;
			break;
		case 4:
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				TIMERRANDOMEFFECT_itemDuration = 0f;
				RANDOMEFFECT_randomEffectAmount = 7;
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			if (RANDOMEFFECT_randomEffectAmount > 0)
			{
				if (Time.realtimeSinceStartup >= TIMERRANDOMEFFECT_itemDuration)
				{
					for (int m = 2; m < ShopHUDSlots.Length; m++)
					{
						RANDOMEFFECT_itemClass = UnityEngine.Random.Range(0, 2);
						RANDOMEFFECT_itemNumber = UnityEngine.Random.Range(0, ShopItems[RANDOMEFFECT_itemClass].itemClassAmount);
						RANDOMEFFECT_itemID = ShopItems[RANDOMEFFECT_itemClass].ItemInfos[RANDOMEFFECT_itemNumber].itemID;
						ShopHUDSlots[m].shopHUDSlot_Icon.Play(RANDOMEFFECT_itemID);
						ShopHUDSlots[m].shopHUDSlot_BG.Play("Item Icon " + (RANDOMEFFECT_itemClass + 1));
					}
					RANDOMEFFECT_randomEffectAmount--;
					TIMERRANDOMEFFECT_itemDuration = Time.realtimeSinceStartup + RANDOMEFFECT_itemDuration;
				}
				break;
			}
			Camera.main.GetComponent<AudioSource>().PlayOneShot(itemRandomedClip);
			ShopHUDSlots[2].shopHUDSlot_Class.Play("itemClass_" + (ShopItemRandomSlots[2].itemClass + 1));
			ShopHUDSlots[2].shopHUDSlot_Icon.Play(ShopItemRandomSlots[2].itemID);
			ShopHUDSlots[2].shopHUDSlot_BG.Play("Item Icon " + (ShopItemRandomSlots[2].itemClass + 1));
			switch (ShopItemRandomSlots[2].itemClass)
			{
			case 0:
				ShopHUDSlots[2].shopHUDSlot_Amount.Play("charge " + ShopItemRandomSlots[2].itemShopAmount);
				break;
			case 1:
				ShopHUDSlots[2].shopHUDSlot_ManaCostIcon.Play("cost " + ShopItems[ShopItemRandomSlots[2].itemClass].ItemInfos[ShopItemRandomSlots[2].itemNumber].itemManaValue);
				break;
			}
			ShopHUDSlots[2].shopHUDSlot_PopEffect.activate = true;
			shopItemSlotRandomState++;
			break;
		case 5:
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				TIMERRANDOMEFFECT_itemDuration = 0f;
				RANDOMEFFECT_randomEffectAmount = 3;
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			if (RANDOMEFFECT_randomEffectAmount > 0)
			{
				if (Time.realtimeSinceStartup >= TIMERRANDOMEFFECT_itemDuration)
				{
					for (int k = 3; k < ShopHUDSlots.Length; k++)
					{
						RANDOMEFFECT_itemClass = UnityEngine.Random.Range(0, 2);
						RANDOMEFFECT_itemNumber = UnityEngine.Random.Range(0, ShopItems[RANDOMEFFECT_itemClass].itemClassAmount);
						RANDOMEFFECT_itemID = ShopItems[RANDOMEFFECT_itemClass].ItemInfos[RANDOMEFFECT_itemNumber].itemID;
						ShopHUDSlots[k].shopHUDSlot_Icon.Play(RANDOMEFFECT_itemID);
						ShopHUDSlots[k].shopHUDSlot_BG.Play("Item Icon " + (RANDOMEFFECT_itemClass + 1));
					}
					RANDOMEFFECT_randomEffectAmount--;
					TIMERRANDOMEFFECT_itemDuration = Time.realtimeSinceStartup + RANDOMEFFECT_itemDuration;
				}
				break;
			}
			Camera.main.GetComponent<AudioSource>().PlayOneShot(itemRandomedClip);
			ShopHUDSlots[3].shopHUDSlot_Class.Play("itemClass_" + (ShopItemRandomSlots[3].itemClass + 1));
			ShopHUDSlots[3].shopHUDSlot_Icon.Play(ShopItemRandomSlots[3].itemID);
			ShopHUDSlots[3].shopHUDSlot_BG.Play("Item Icon " + (ShopItemRandomSlots[3].itemClass + 1));
			switch (ShopItemRandomSlots[3].itemClass)
			{
			case 0:
				ShopHUDSlots[3].shopHUDSlot_Amount.Play("charge " + ShopItemRandomSlots[3].itemShopAmount);
				break;
			case 1:
				ShopHUDSlots[3].shopHUDSlot_ManaCostIcon.Play("cost " + ShopItems[ShopItemRandomSlots[3].itemClass].ItemInfos[ShopItemRandomSlots[3].itemNumber].itemManaValue);
				break;
			}
			ShopHUDSlots[3].shopHUDSlot_PopEffect.activate = true;
			shopItemSlotRandomState++;
			break;
		case 6:
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			for (int n = 0; n < ShopHUDSlots.Length; n++)
			{
				if (ShopItemRandomSlots[n].itemClass == 0 && ShopItemRandomSlots[n].itemShopAmount <= 0)
				{
					ShopItemRandomSlots[n].itemClass = -1;
					selectedSlot = -1;
					shopSelectionChange = true;
				}
				if (ShopItemRandomSlots[n].itemClass != -1)
				{
					ShopHUDSlots[n].shopHUDSlot_Class.Play("itemClass_" + (ShopItemRandomSlots[n].itemClass + 1));
					ShopHUDSlots[n].shopHUDSlot_Icon.Play(ShopItemRandomSlots[n].itemID);
					ShopHUDSlots[n].shopHUDSlot_BG.Play("Item Icon " + (ShopItemRandomSlots[n].itemClass + 1));
					switch (ShopItemRandomSlots[n].itemClass)
					{
					case 0:
						ShopHUDSlots[n].shopHUDSlot_Amount.Play("charge " + ShopItemRandomSlots[n].itemShopAmount);
						break;
					case 1:
						ShopHUDSlots[n].shopHUDSlot_ManaCostIcon.Play("cost " + ShopItems[ShopItemRandomSlots[n].itemClass].ItemInfos[ShopItemRandomSlots[n].itemNumber].itemManaValue);
						break;
					}
				}
				else
				{
					Transform transform7 = ShopHUDSlots[n].shopHUDSlot_ClassObject.transform;
					Vector3 localPosition20 = ShopHUDSlots[n].shopHUDSlot_ClassObject.transform.localPosition;
					float x7 = localPosition20.x;
					Vector3 localPosition21 = ShopHUDSlots[n].shopHUDSlot_ClassObject.transform.localPosition;
					float y2 = localPosition21.y + 5f;
					Vector3 localPosition22 = ShopHUDSlots[n].shopHUDSlot_ClassObject.transform.localPosition;
					transform7.localPosition = new Vector3(x7, y2, localPosition22.z);
					ShopHUDSlots[n].shopHUDSlot_Class.Play("blank");
					ShopHUDSlots[n].shopHUDSlot_Icon.Play("blank");
					ShopHUDSlots[n].shopHUDSlot_BG.Play("Item Icon 0");
					ShopHUDSlots[n].shopHUDSlot_Amount.Play("blank");
					ShopHUDSlots[n].shopHUDSlot_ManaCostIcon.Play("blank");
					ShopItemRandomSlots[n].itemClass = -1;
					ShopItemRandomSlots[n].itemNumber = 0;
				}
			}
			shopItemSlotRandomState++;
			break;
		case 7:
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			if (TOGGLE_scoreWavesCompleted != scriptGameStatistic.scoreWavesCompleted)
			{
				shopItemSlotRerollCost = 10;
				MULTIPLIER_shopItemSlotRerollCost = 1;
				shopItemSlotRandomState = 0;
			}
			break;
		case 8:
			if (TOGGLE_shopItemSlotRandomState != shopItemSlotRandomState)
			{
				TOGGLE_shopItemSlotRandomState = shopItemSlotRandomState;
			}
			shopItemSlotRandomState = 0;
			break;
		}
		if (!shopMenu)
		{
			selectedSlot = -1;
			shopSelectionChange = true;
		}
		if (!shopSelectionChange)
		{
			return;
		}
		for (int num2 = 0; num2 < ShopHUDSlots.Length; num2++)
		{
			if (num2 == selectedSlot)
			{
				ShopHUDSlots[selectedSlot].shopHUDSlot_PopEffect.regularScale = 1.25f;
				continue;
			}
			ShopHUDSlots[num2].shopHUDSlot_PopEffect.regularScale = 1f;
			ShopHUDSlots[num2].shopHUDSlot_IconGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		if (selectedSlot <= -2)
		{
			if (selectedSlot == -2)
			{
				itemOneDropIcon.GetComponent<Renderer>().enabled = true;
				itemTwoDropIcon.GetComponent<Renderer>().enabled = false;
				Transform transform8 = shopHighlighter.transform;
				Vector3 position3 = itemOneGameobject.transform.position;
				float x8 = position3.x;
				Vector3 position4 = itemOneGameobject.transform.position;
				transform8.position = new Vector3(x8, position4.y, -6.66f);
				shopSelectHighlighter.transform.position = shopHighlighter.transform.position;
			}
			else if (selectedSlot == -3)
			{
				itemOneDropIcon.GetComponent<Renderer>().enabled = false;
				itemTwoDropIcon.GetComponent<Renderer>().enabled = true;
				Transform transform9 = shopHighlighter.transform;
				Vector3 position5 = itemTwoGameobject.transform.position;
				float x9 = position5.x;
				Vector3 position6 = itemTwoGameobject.transform.position;
				transform9.position = new Vector3(x9, position6.y, -6.66f);
			}
			Transform transform10 = shopSelectHighlighter.transform;
			Vector3 position7 = shopSelectHighlighter.transform.position;
			float x10 = position7.x + 100f;
			Vector3 position8 = shopSelectHighlighter.transform.position;
			transform10.position = new Vector3(x10, position8.y, -8.025f);
			subMenuItemName.text = ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemName;
			subMenuItemName.Commit();
			subMenuItemCost.text = string.Empty;
			subMenuItemCost.Commit();
			subMenuDescriptionLine1.text = ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemDescriptionLine1;
			subMenuDescriptionLine1.Commit();
			subMenuDescriptionLine2.text = ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemDescriptionLine2;
			subMenuDescriptionLine2.Commit();
			selectedItemCost = 0;
			purchaseTrigger.name = string.Empty;
		}
		else if (selectedSlot == -1)
		{
			Transform transform11 = shopHighlighter.transform;
			Vector3 position9 = shopHighlighter.transform.position;
			float x11 = position9.x + 100f;
			Vector3 position10 = shopHighlighter.transform.position;
			transform11.position = new Vector3(x11, position10.y, -7.025f);
			Transform transform12 = shopSelectHighlighter.transform;
			Vector3 position11 = shopSelectHighlighter.transform.position;
			float x12 = position11.x + 100f;
			Vector3 position12 = shopSelectHighlighter.transform.position;
			transform12.position = new Vector3(x12, position12.y, -8.025f);
			subMenuItemName.text = string.Empty;
			subMenuItemName.Commit();
			subMenuItemCost.text = string.Empty;
			subMenuItemCost.Commit();
			subMenuDescriptionLine1.text = string.Empty;
			subMenuDescriptionLine1.Commit();
			subMenuDescriptionLine2.text = string.Empty;
			subMenuDescriptionLine2.Commit();
			selectedItemCost = 0;
			purchaseTrigger.name = string.Empty;
		}
		else
		{
			ShopHUDSlots[selectedSlot].shopHUDSlot_PopEffect.activate = true;
			Transform transform13 = shopHighlighter.transform;
			Vector3 position13 = ShopHUDSlots[selectedSlot].shopHUDSlot_Gameobject.transform.position;
			float x13 = position13.x;
			Vector3 position14 = ShopHUDSlots[selectedSlot].shopHUDSlot_Gameobject.transform.position;
			transform13.position = new Vector3(x13, position14.y, -7.025f);
			Transform transform14 = shopSelectHighlighter.transform;
			Vector3 position15 = ShopHUDSlots[selectedSlot].shopHUDSlot_Gameobject.transform.position;
			float x14 = position15.x - 0.225f;
			Vector3 position16 = ShopHUDSlots[selectedSlot].shopHUDSlot_Gameobject.transform.position;
			transform14.position = new Vector3(x14, position16.y - 0.425f, -8.025f);
			if (selectedClassSlot != -1)
			{
				subMenuItemName.text = ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemName;
				subMenuItemName.Commit();
				subMenuItemCost.text = string.Empty + ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemCost;
				subMenuItemCost.Commit();
				subMenuDescriptionLine1.text = ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemDescriptionLine1;
				subMenuDescriptionLine1.Commit();
				subMenuDescriptionLine2.text = ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemDescriptionLine2;
				subMenuDescriptionLine2.Commit();
				selectedItemCost = ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemCost;
				purchaseTrigger.name = ShopItems[selectedClassSlot].ItemInfos[selectedNumberSlot].itemID;
			}
			else
			{
				Transform transform15 = shopHighlighter.transform;
				Vector3 position17 = shopHighlighter.transform.position;
				float x15 = position17.x;
				Vector3 position18 = shopHighlighter.transform.position;
				transform15.position = new Vector3(x15, position18.y + 10f, -7.025f);
				Transform transform16 = shopSelectHighlighter.transform;
				Vector3 position19 = shopSelectHighlighter.transform.position;
				float x16 = position19.x;
				Vector3 position20 = shopSelectHighlighter.transform.position;
				transform16.position = new Vector3(x16, position20.y + 10f, -8.025f);
				subMenuItemName.text = string.Empty;
				subMenuItemName.Commit();
				subMenuItemCost.text = string.Empty;
				subMenuItemCost.Commit();
				subMenuDescriptionLine1.text = string.Empty;
				subMenuDescriptionLine1.Commit();
				subMenuDescriptionLine2.text = string.Empty;
				subMenuDescriptionLine2.Commit();
				selectedItemCost = 0;
				purchaseTrigger.name = string.Empty;
			}
		}
		if (selectedSlot > -2 && (itemOneDropIcon.GetComponent<Renderer>().enabled || itemTwoDropIcon.GetComponent<Renderer>().enabled))
		{
			itemOneDropIcon.GetComponent<Renderer>().enabled = false;
			itemTwoDropIcon.GetComponent<Renderer>().enabled = false;
		}
		shopSelectionChange = false;
	}

	private void StatisticsFunction()
	{
		if (TOGGLE_currencyAmount != 0)
		{
			scriptMasterControl.Currency(TOGGLE_currencyAmount);
			TOGGLE_currencyAmount = 0;
		}
		if (playerCurrency != PlayerPrefs.GetInt("playerCurrency"))
		{
			playerCurrency = PlayerPrefs.GetInt("playerCurrency");
		}
		if (currencyText.text != string.Empty + playerCurrency)
		{
			currencyText.text = string.Empty + playerCurrency;
			currencyText.Commit();
		}
	}

	private void HUDInteraction()
	{
		if (shopMenu && state == 1)
		{
			if (menuState != 1)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(accessMenu);
				scriptHudControl.state = 4;
				menuState = 1;
			}
			return;
		}
		if (itemOneDropIcon.GetComponent<Renderer>().enabled || itemTwoDropIcon.GetComponent<Renderer>().enabled)
		{
			itemOneDropIcon.GetComponent<Renderer>().enabled = false;
			itemTwoDropIcon.GetComponent<Renderer>().enabled = false;
		}
		if (menuState == 1)
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(accessMenu);
			scriptHudControl.state = 2;
			menuState = 0;
		}
		else if (menuState != 0)
		{
			menuState = 0;
		}
		if (itemOneType != 0 && itemTwoType != 0)
		{
			if (scriptHudControl.itemIconState != 3)
			{
				scriptHudControl.itemIconState = 3;
			}
		}
		else if (itemOneType != 0 && itemTwoType == 0)
		{
			if (scriptHudControl.itemIconState != 1)
			{
				scriptHudControl.itemIconState = 1;
			}
		}
		else if (itemOneType == 0 && itemTwoType != 0)
		{
			if (scriptHudControl.itemIconState != 2)
			{
				scriptHudControl.itemIconState = 2;
			}
		}
		else if (itemOneType == 0 && itemTwoType == 0 && scriptHudControl.itemIconState != 0)
		{
			scriptHudControl.itemIconState = 0;
		}
	}

	private void ItemFuntion()
	{
		if (state == 1 && shopMenu)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (shopItemSlotRandomState < 6)
				{
					RANDOMEFFECT_randomEffectAmount = 0;
				}
				Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hitInfo))
				{
					if (hitInfo.collider.transform.name == "BTN_CONTINUE")
					{
						shopMenu = false;
					}
					if (hitInfo.collider.transform.name == "ITEMSLOT0" && ShopItemRandomSlots[0].itemClass != -1)
					{
						if (selectedSlot != 0)
						{
							selectedSlot = 0;
							selectedNumberSlot = ShopItemRandomSlots[0].itemNumber;
							selectedClassSlot = ShopItemRandomSlots[0].itemClass;
							if (ShopItemRandomSlots[0].itemClass != -1)
							{
								shopSelectionChange = true;
							}
						}
						else
						{
							for (int i = 0; i < contentData.ItemIDs.Length; i++)
							{
								if (purchaseTrigger.name == contentData.ItemIDs[i].itemID)
								{
									ItemEquipFunction(i);
									i = contentData.ItemIDs.Length;
								}
							}
						}
					}
					else if (hitInfo.collider.transform.name == "ITEMSLOT1" && ShopItemRandomSlots[1].itemClass != -1)
					{
						if (selectedSlot != 1)
						{
							selectedSlot = 1;
							selectedNumberSlot = ShopItemRandomSlots[1].itemNumber;
							selectedClassSlot = ShopItemRandomSlots[1].itemClass;
							if (ShopItemRandomSlots[1].itemClass != -1)
							{
								shopSelectionChange = true;
							}
						}
						else
						{
							for (int j = 0; j < contentData.ItemIDs.Length; j++)
							{
								if (purchaseTrigger.name == contentData.ItemIDs[j].itemID)
								{
									ItemEquipFunction(j);
									j = contentData.ItemIDs.Length;
								}
							}
						}
					}
					else if (hitInfo.collider.transform.name == "ITEMSLOT2" && ShopItemRandomSlots[2].itemClass != -1)
					{
						if (selectedSlot != 2)
						{
							selectedSlot = 2;
							selectedNumberSlot = ShopItemRandomSlots[2].itemNumber;
							selectedClassSlot = ShopItemRandomSlots[2].itemClass;
							if (ShopItemRandomSlots[2].itemClass != -1)
							{
								shopSelectionChange = true;
							}
						}
						else
						{
							for (int k = 0; k < contentData.ItemIDs.Length; k++)
							{
								if (purchaseTrigger.name == contentData.ItemIDs[k].itemID)
								{
									ItemEquipFunction(k);
									k = contentData.ItemIDs.Length;
								}
							}
						}
					}
					else if (hitInfo.collider.transform.name == "ITEMSLOT3" && ShopItemRandomSlots[3].itemClass != -1)
					{
						if (selectedSlot != 3)
						{
							selectedSlot = 3;
							selectedNumberSlot = ShopItemRandomSlots[3].itemNumber;
							selectedClassSlot = ShopItemRandomSlots[3].itemClass;
							if (ShopItemRandomSlots[3].itemClass != -1)
							{
								shopSelectionChange = true;
							}
						}
						else
						{
							for (int l = 0; l < contentData.ItemIDs.Length; l++)
							{
								if (purchaseTrigger.name == contentData.ItemIDs[l].itemID)
								{
									ItemEquipFunction(l);
									l = contentData.ItemIDs.Length;
								}
							}
						}
					}
					if (hitInfo.collider.transform.name == "ITEMREROLL")
					{
						if (playerCurrency >= shopItemSlotRerollCost * MULTIPLIER_shopItemSlotRerollCost)
						{
							ScriptsManager.dataScript.GameAnalytics("item:button:reroll:" + shopItemSlotRerollCost * MULTIPLIER_shopItemSlotRerollCost, 0f);
							Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionGranted);
							TOGGLE_currencyAmount -= shopItemSlotRerollCost * MULTIPLIER_shopItemSlotRerollCost;
							MULTIPLIER_shopItemSlotRerollCost++;
							shopItemSlotRandomState = 8;
						}
						else
						{
							Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
							currencyPopEffect.activate = true;
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && ShopItemRandomSlots[1].itemClass != -1)
			{
				Vector3 vector = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				float x = vector.x;
				Vector3 position = purchaseTrigger.transform.position;
				if (x < position.x + 0.9f)
				{
					Vector3 vector2 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
					float x2 = vector2.x;
					Vector3 position2 = purchaseTrigger.transform.position;
					if (x2 > position2.x - 0.9f)
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
						float y = vector3.y;
						Vector3 position3 = purchaseTrigger.transform.position;
						if (y < position3.y + 0.2f)
						{
							Vector3 vector4 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
							float y2 = vector4.y;
							Vector3 position4 = purchaseTrigger.transform.position;
							if (y2 > position4.y - 0.2f && contentData != null)
							{
								for (int m = 0; m < contentData.ItemIDs.Length; m++)
								{
									if (purchaseTrigger.name == contentData.ItemIDs[m].itemID)
									{
										ItemEquipFunction(m);
									}
								}
							}
						}
					}
				}
			}
		}
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		if (Time.timeScale == 1f)
		{
			Vector3 vector5 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
			float x3 = vector5.x;
			Vector3 position5 = shopButton.transform.position;
			if (x3 < position5.x + 0.4f)
			{
				Vector3 vector6 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				float x4 = vector6.x;
				Vector3 position6 = shopButton.transform.position;
				if (x4 > position6.x - 0.4f)
				{
					Vector3 vector7 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
					float y3 = vector7.y;
					Vector3 position7 = shopButton.transform.position;
					if (y3 < position7.y + 0.4f)
					{
						Vector3 vector8 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
						float y4 = vector8.y;
						Vector3 position8 = shopButton.transform.position;
						if (y4 > position8.y - 0.4f)
						{
							shopMenu = true;
						}
					}
				}
			}
		}
		Vector3 vector9 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float x5 = vector9.x;
		Vector3 position9 = itemOneBG.transform.position;
		if (x5 < position9.x + 0.4f)
		{
			Vector3 vector10 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
			float x6 = vector10.x;
			Vector3 position10 = itemOneBG.transform.position;
			if (x6 > position10.x - 0.4f)
			{
				Vector3 vector11 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				float y5 = vector11.y;
				Vector3 position11 = itemOneBG.transform.position;
				if (y5 < position11.y + 0.4f)
				{
					Vector3 vector12 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
					float y6 = vector12.y;
					Vector3 position12 = itemOneBG.transform.position;
					if (y6 > position12.y - 0.4f && itemOneState == 1)
					{
						if (itemOneType != 0)
						{
							scriptGameStatistic.objectLevitating = 0;
							switch (itemOneType)
							{
							case 1:
								if (shopMenu)
								{
									if (selectedSlot != -2)
									{
										itemOnePopEffect.activate = true;
										selectedClassSlot = itemOneType - 1;
										selectedNumberSlot = itemOneSubType;
										selectedSlot = -2;
										shopSelectionChange = true;
									}
									else if (selectedSlot == -2)
									{
										Camera.main.GetComponent<AudioSource>().PlayOneShot(itemDropped);
										itemOnePopEffect.activate = true;
										itemOneChargeCost.Play("blank");
										itemOnePrefab = null;
										itemOneType = 0;
										itemOneSubType = 0;
										itemOneID = string.Empty;
										itemOneNameID = string.Empty;
										selectedSlot = -1;
										shopSelectionChange = true;
									}
								}
								else if (state == 1)
								{
									PlayerPrefs.SetInt(characterID + "_" + itemOneID, PlayerPrefs.GetInt(characterID + "_" + itemOneID) + statisticConsumableUseValue);
									if (scriptMasterControl.gameMode != 1)
									{
										ScriptsManager.dataScript.GameAnalytics("item:value:" + itemOneNameID, 0f);
									}
									if (itemOnePrefab != null)
									{
										CONSUMABLE_inst = PoolManager.Pools["Item Pool"].Spawn(itemPopUp.transform, itemOneGameobject.transform.position, itemOneGameobject.transform.rotation);
										CONSUMABLE_inst.GetComponent<ItemPopUpScript>().prefabSpawn = itemOnePrefab;
										CONSUMABLE_inst.GetComponent<ItemPopUpScript>().itemID = itemOneID;
										CONSUMABLE_inst.GetComponent<ItemPopUpScript>().effectSound = itemOneScrollActivateSound;
									}
									if (itemOneCharges <= 1)
									{
										itemOneChargeCost.Play("blank");
										itemOnePrefab = null;
										itemOneType = 0;
										itemOneSubType = 0;
										itemOneID = string.Empty;
										itemOneNameID = string.Empty;
									}
									else
									{
										itemOnePopEffect.activate = true;
										itemOneCharges--;
										itemOneChargeCost.Play("charge " + itemOneCharges);
									}
									scriptGameStatistic.scoreItemsUsed++;
									scriptGameStatistic.characterAnimationNumber = 15;
								}
								break;
							case 2:
								if (shopMenu)
								{
									if (selectedSlot != -2)
									{
										itemOnePopEffect.activate = true;
										selectedClassSlot = itemOneType - 1;
										selectedNumberSlot = itemOneSubType;
										selectedSlot = -2;
										shopSelectionChange = true;
									}
									else if (selectedSlot == -2)
									{
										Camera.main.GetComponent<AudioSource>().PlayOneShot(itemDropped);
										itemOnePopEffect.activate = true;
										itemOneChargeCost.Play("blank");
										itemOnePrefab = null;
										itemOneType = 0;
										itemOneSubType = 0;
										itemOneID = string.Empty;
										itemOneNameID = string.Empty;
										selectedSlot = -1;
										shopSelectionChange = true;
									}
								}
								else if (state == 1 && scriptGameStatistic.manaNumber >= itemOneManaCost && TIMER_itemOneCoolDown >= itemOneCoolDown)
								{
									if (itemOnePrefab != null)
									{
										SCROLL_inst = PoolManager.Pools["Item Pool"].Spawn(itemScrollCaster.transform, scrollStart, itemScrollCaster.transform.rotation);
										SCROLL_inst.GetComponent<Spell_Caster_Control>().SpellActivate(1, 4, itemOneScrollType, itemOneIndicatorType, itemOneScrollDirection, itemOneCentreScrollTypeHeight, itemOneScrollActivateSound, itemOnePrefab);
									}
									TIMER_itemOneCoolDown = 0f;
									scriptGameStatistic.manaNumber -= itemOneManaCost;
									PlayerPrefs.SetInt(characterID + "_" + itemOneID, PlayerPrefs.GetInt(characterID + "_" + itemOneID) + statisticScrollUseValue);
									ScriptsManager.dataScript.GameAnalytics("item:value:" + itemOneNameID, 0f);
									scriptGameStatistic.scoreItemsUsed++;
									scriptGameStatistic.characterAnimationNumber = 16;
								}
								break;
							case 3:
								if (!shopMenu)
								{
									break;
								}
								if (selectedSlot != -2)
								{
									itemOnePopEffect.activate = true;
									selectedClassSlot = itemOneType - 1;
									selectedNumberSlot = itemOneSubType;
									selectedSlot = -2;
									shopSelectionChange = true;
								}
								else if (selectedSlot == -2)
								{
									Camera.main.GetComponent<AudioSource>().PlayOneShot(itemDropped);
									itemOnePopEffect.activate = true;
									if (itemOnePrefab != null)
									{
										PoolManager.Pools["Item Pool"].Spawn(itemOnePrefab.transform, itemOneGameobject.transform.position, itemOneGameobject.transform.rotation);
									}
									if (itemOnePassivePrefabInst != null)
									{
										PoolManager.Pools["Item Pool"].Despawn(itemOnePassivePrefabInst);
									}
									itemOneChargeCost.Play("blank");
									itemOnePassivePrefabInst = null;
									itemOnePassivePrefab = null;
									itemOnePrefab = null;
									itemOneType = 0;
									itemOneSubType = 0;
									itemOneID = string.Empty;
									itemOneNameID = string.Empty;
									selectedSlot = -1;
									shopSelectionChange = true;
								}
								break;
							}
						}
						else if (Time.timeScale == 1f && !shopMenu)
						{
							shopMenu = true;
						}
					}
				}
			}
		}
		Vector3 vector13 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float x7 = vector13.x;
		Vector3 position13 = itemTwoBG.transform.position;
		if (!(x7 < position13.x + 0.4f))
		{
			return;
		}
		Vector3 vector14 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float x8 = vector14.x;
		Vector3 position14 = itemTwoBG.transform.position;
		if (!(x8 > position14.x - 0.4f))
		{
			return;
		}
		Vector3 vector15 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float y7 = vector15.y;
		Vector3 position15 = itemTwoBG.transform.position;
		if (!(y7 < position15.y + 0.4f))
		{
			return;
		}
		Vector3 vector16 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float y8 = vector16.y;
		Vector3 position16 = itemTwoBG.transform.position;
		if (!(y8 > position16.y - 0.4f) || itemTwoState != 1)
		{
			return;
		}
		if (itemTwoType != 0)
		{
			scriptGameStatistic.objectLevitating = 0;
			switch (itemTwoType)
			{
			case 0:
				break;
			case 1:
				if (shopMenu)
				{
					if (selectedSlot != -3)
					{
						itemTwoPopEffect.activate = true;
						selectedClassSlot = itemTwoType - 1;
						selectedNumberSlot = itemTwoSubType;
						selectedSlot = -3;
						shopSelectionChange = true;
					}
					else if (selectedSlot == -3)
					{
						Camera.main.GetComponent<AudioSource>().PlayOneShot(itemDropped);
						itemTwoPopEffect.activate = true;
						itemTwoChargeCost.Play("blank");
						itemTwoPrefab = null;
						itemTwoType = 0;
						itemTwoSubType = 0;
						itemTwoID = string.Empty;
						itemTwoNameID = string.Empty;
						selectedSlot = -1;
						shopSelectionChange = true;
					}
				}
				else if (state == 1)
				{
					PlayerPrefs.SetInt(characterID + "_" + itemTwoID, PlayerPrefs.GetInt(characterID + "_" + itemTwoID) + statisticConsumableUseValue);
					if (scriptMasterControl.gameMode != 1)
					{
						ScriptsManager.dataScript.GameAnalytics("item:value:" + itemTwoNameID, 0f);
					}
					if (itemTwoPrefab != null)
					{
						CONSUMABLE_inst = PoolManager.Pools["Item Pool"].Spawn(itemPopUp.transform, itemTwoGameobject.transform.position, itemTwoGameobject.transform.rotation);
						CONSUMABLE_inst.GetComponent<ItemPopUpScript>().prefabSpawn = itemTwoPrefab;
						CONSUMABLE_inst.GetComponent<ItemPopUpScript>().itemID = itemTwoID;
						CONSUMABLE_inst.GetComponent<ItemPopUpScript>().effectSound = itemTwoScrollActivateSound;
					}
					if (itemTwoCharges <= 1)
					{
						itemTwoChargeCost.Play("blank");
						itemTwoPrefab = null;
						itemTwoType = 0;
						itemTwoSubType = 0;
						itemTwoID = string.Empty;
						itemTwoNameID = string.Empty;
					}
					else
					{
						itemTwoPopEffect.activate = true;
						itemTwoCharges--;
						itemTwoChargeCost.Play("charge " + itemTwoCharges);
					}
					scriptGameStatistic.scoreItemsUsed++;
					scriptGameStatistic.characterAnimationNumber = 15;
				}
				break;
			case 2:
				if (shopMenu)
				{
					if (selectedSlot != -3)
					{
						itemTwoPopEffect.activate = true;
						selectedClassSlot = itemTwoType - 1;
						selectedNumberSlot = itemTwoSubType;
						selectedSlot = -3;
						shopSelectionChange = true;
					}
					else if (selectedSlot == -3)
					{
						Camera.main.GetComponent<AudioSource>().PlayOneShot(itemDropped);
						itemTwoPopEffect.activate = true;
						itemTwoChargeCost.Play("blank");
						itemTwoPrefab = null;
						itemTwoType = 0;
						itemTwoSubType = 0;
						itemTwoID = string.Empty;
						itemTwoNameID = string.Empty;
						selectedSlot = -1;
						shopSelectionChange = true;
					}
				}
				else if (scriptGameStatistic.manaNumber >= itemTwoManaCost && TIMER_itemTwoCoolDown >= itemTwoCoolDown)
				{
					if (itemTwoPrefab != null)
					{
						SCROLL_inst = PoolManager.Pools["Item Pool"].Spawn(itemScrollCaster.transform, scrollStart, itemScrollCaster.transform.rotation);
						SCROLL_inst.GetComponent<Spell_Caster_Control>().SpellActivate(1, 4, itemTwoScrollType, itemTwoIndicatorType, itemTwoScrollDirection, itemTwoCentreScrollTypeHeight, itemTwoScrollActivateSound, itemTwoPrefab);
					}
					TIMER_itemTwoCoolDown = 0f;
					scriptGameStatistic.manaNumber -= itemTwoManaCost;
					PlayerPrefs.SetInt(characterID + "_" + itemTwoID, PlayerPrefs.GetInt(characterID + "_" + itemTwoID) + statisticScrollUseValue);
					ScriptsManager.dataScript.GameAnalytics("item:value:" + itemTwoNameID, 0f);
					scriptGameStatistic.scoreItemsUsed++;
					scriptGameStatistic.characterAnimationNumber = 16;
				}
				break;
			case 3:
				if (!shopMenu)
				{
					break;
				}
				if (selectedSlot != -3)
				{
					itemTwoPopEffect.activate = true;
					selectedClassSlot = itemTwoType - 1;
					selectedNumberSlot = itemTwoSubType;
					selectedSlot = -3;
					shopSelectionChange = true;
				}
				else if (selectedSlot == -3)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(itemDropped);
					itemTwoPopEffect.activate = true;
					if (itemTwoPrefab != null)
					{
						PoolManager.Pools["Item Pool"].Spawn(itemTwoPrefab.transform, itemTwoGameobject.transform.position, itemTwoGameobject.transform.rotation);
					}
					if (itemTwoPassivePrefabInst != null)
					{
						PoolManager.Pools["Item Pool"].Despawn(itemTwoPassivePrefabInst);
					}
					itemTwoChargeCost.Play("blank");
					itemTwoPassivePrefabInst = null;
					itemTwoPassivePrefab = null;
					itemTwoPrefab = null;
					itemTwoType = 0;
					itemTwoSubType = 0;
					itemTwoID = string.Empty;
					itemTwoNameID = string.Empty;
					selectedSlot = -1;
					shopSelectionChange = true;
				}
				break;
			}
		}
		else if (Time.timeScale == 1f && !shopMenu)
		{
			shopMenu = true;
		}
	}

	public void ItemEquipFunction(int i)
	{
		if (itemOneType == 1 && itemOneID == contentData.ItemIDs[i].itemID)
		{
			if (itemOneCharges < contentData.ItemIDs[i].itemMaximumCharges)
			{
				if (playerCurrency >= selectedItemCost)
				{
					if (scriptMasterControl.gameMode != 1)
					{
						Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionGranted);
					}
					if (scriptMasterControl.gameMode != 1)
					{
						ScriptsManager.dataScript.GameAnalytics("item:purchuse:" + itemOneNameID, 0f);
					}
					currencyPopEffect.activate = true;
					TOGGLE_currencyAmount -= selectedItemCost;
					itemOneCharges++;
					itemOneChargeCost.Play("charge " + itemOneCharges);
					if (scriptMasterControl.gameMode != 1)
					{
						ShopItemRandomSlots[selectedSlot].itemShopAmount--;
					}
					shopItemSlotRandomState = 6;
					itemOnePopEffect.activate = true;
				}
				else
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
					currencyPopEffect.activate = true;
				}
			}
			else
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
				itemOnePopEffect.activate = true;
			}
			return;
		}
		if (itemTwoType == 1 && itemTwoID == contentData.ItemIDs[i].itemID)
		{
			if (itemTwoCharges < contentData.ItemIDs[i].itemMaximumCharges)
			{
				if (playerCurrency >= selectedItemCost)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionGranted);
					if (scriptMasterControl.gameMode != 1)
					{
						ScriptsManager.dataScript.GameAnalytics("item:purchuse:" + itemTwoNameID, 0f);
					}
					currencyPopEffect.activate = true;
					TOGGLE_currencyAmount -= selectedItemCost;
					itemTwoCharges++;
					itemTwoChargeCost.Play("charge " + itemTwoCharges);
					if (scriptMasterControl.gameMode != 1)
					{
						ShopItemRandomSlots[selectedSlot].itemShopAmount--;
					}
					shopItemSlotRandomState = 6;
					itemTwoPopEffect.activate = true;
				}
				else
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
					currencyPopEffect.activate = true;
				}
			}
			else
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
				itemTwoPopEffect.activate = true;
			}
			return;
		}
		if (itemOneType > 1 && itemOneID == contentData.ItemIDs[i].itemID)
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
			itemOnePopEffect.activate = true;
			return;
		}
		if (itemTwoType > 1 && itemTwoID == contentData.ItemIDs[i].itemID)
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
			itemTwoPopEffect.activate = true;
			return;
		}
		switch (itemSlotAvailable)
		{
		case 2:
			if (playerCurrency >= selectedItemCost)
			{
				TOGGLE_currencyAmount -= selectedItemCost;
				Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionGranted);
				currencyPopEffect.activate = true;
				itemOneID = contentData.ItemIDs[i].itemID;
				itemOneNameID = contentData.ItemIDs[i].itemNameID;
				itemOneType = contentData.ItemIDs[i].itemClass;
				itemOneSubType = selectedNumberSlot;
				itemOnePrefab = contentData.ItemIDs[i].ItemPrefab;
				itemOnePopEffect.activate = true;
				if (scriptMasterControl.gameMode != 1)
				{
					ScriptsManager.dataScript.GameAnalytics("item:purchuse:" + contentData.ItemIDs[i].itemNameID, 0f);
				}
				itemOneScrollType = contentData.ItemIDs[i].scrollType;
				itemOneIndicatorType = contentData.ItemIDs[i].indicatorType;
				itemOneScrollDirection = contentData.ItemIDs[i].arrowDirection;
				itemOneCentreScrollTypeHeight = contentData.ItemIDs[i].centreScrollTypeHeight;
				itemOneScrollActivateSound = contentData.ItemIDs[i].activateSound;
				switch (itemOneType)
				{
				case 1:
					itemOneIcon.animation2ClipName = contentData.ItemIDs[i].itemID;
					itemOneCharges = 1;
					itemOneChargeCost.Play("charge " + itemOneCharges);
					if (scriptMasterControl.gameMode != 1)
					{
						ShopItemRandomSlots[selectedSlot].itemShopAmount--;
					}
					shopItemSlotRandomState = 6;
					break;
				case 2:
					itemOneIcon.animation3ClipName = contentData.ItemIDs[i].itemID;
					itemOneCoolDown = contentData.ItemIDs[i].itemCoolDown;
					TIMER_itemOneCoolDown = itemOneCoolDown;
					itemOneManaCost = contentData.ItemIDs[i].itemManaCost;
					itemOneChargeCost.Play("cost " + itemOneManaCost);
					break;
				case 3:
					PlayerPrefs.SetInt(characterID + "_" + itemOneID, PlayerPrefs.GetInt(characterID + "_" + itemOneID) + statisticAccessoryEquipValue);
					ScriptsManager.dataScript.GameAnalytics("item:value:" + itemOneNameID, 0f);
					TOGGLEWAVE_StatisticAccessoryUpKeepValue = scriptGameStatistic.scoreWavesCompleted;
					scriptGameStatistic.scoreItemsUsed++;
					itemOneIcon.animation4ClipName = contentData.ItemIDs[i].itemID;
					itemOneChargeCost.Play("blank");
					break;
				}
				if (contentData.ItemIDs[i].PassivePrefab != null)
				{
					itemOnePassivePrefab = contentData.ItemIDs[i].PassivePrefab;
					itemOnePassivePrefabInst = PoolManager.Pools["Item Pool"].Spawn(itemOnePassivePrefab.transform, itemOneGameobject.transform.position, itemOneGameobject.transform.rotation);
				}
			}
			else
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
				currencyPopEffect.activate = true;
			}
			break;
		case 1:
			if (playerCurrency >= selectedItemCost)
			{
				TOGGLE_currencyAmount -= selectedItemCost;
				Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionGranted);
				currencyPopEffect.activate = true;
				itemTwoID = contentData.ItemIDs[i].itemID;
				itemTwoNameID = contentData.ItemIDs[i].itemNameID;
				itemTwoType = contentData.ItemIDs[i].itemClass;
				itemTwoSubType = selectedNumberSlot;
				itemTwoPrefab = contentData.ItemIDs[i].ItemPrefab;
				itemTwoPopEffect.activate = true;
				if (scriptMasterControl.gameMode != 1)
				{
					ScriptsManager.dataScript.GameAnalytics("item:purchuse:" + contentData.ItemIDs[i].itemNameID, 0f);
				}
				itemTwoScrollType = contentData.ItemIDs[i].scrollType;
				itemTwoIndicatorType = contentData.ItemIDs[i].indicatorType;
				itemTwoScrollDirection = contentData.ItemIDs[i].arrowDirection;
				itemTwoCentreScrollTypeHeight = contentData.ItemIDs[i].centreScrollTypeHeight;
				itemTwoScrollActivateSound = contentData.ItemIDs[i].activateSound;
				switch (itemTwoType)
				{
				case 1:
					itemTwoIcon.animation2ClipName = contentData.ItemIDs[i].itemID;
					itemTwoCharges = 1;
					itemTwoChargeCost.Play("charge " + itemTwoCharges);
					if (scriptMasterControl.gameMode != 1)
					{
						ShopItemRandomSlots[selectedSlot].itemShopAmount--;
					}
					shopItemSlotRandomState = 6;
					break;
				case 2:
					itemTwoIcon.animation3ClipName = contentData.ItemIDs[i].itemID;
					itemTwoCoolDown = contentData.ItemIDs[i].itemCoolDown;
					TIMER_itemTwoCoolDown = itemTwoCoolDown;
					itemTwoManaCost = contentData.ItemIDs[i].itemManaCost;
					itemTwoChargeCost.Play("cost " + itemTwoManaCost);
					break;
				case 3:
					PlayerPrefs.SetInt(characterID + "_" + itemTwoID, PlayerPrefs.GetInt(characterID + "_" + itemTwoID) + statisticAccessoryEquipValue);
					ScriptsManager.dataScript.GameAnalytics("item:value:" + itemTwoNameID, 0f);
					TOGGLEWAVE_StatisticAccessoryUpKeepValue = scriptGameStatistic.scoreWavesCompleted;
					scriptGameStatistic.scoreItemsUsed++;
					itemTwoIcon.animation4ClipName = contentData.ItemIDs[i].itemID;
					itemTwoChargeCost.Play("blank");
					break;
				}
				if (contentData.ItemIDs[i].PassivePrefab != null)
				{
					itemTwoPassivePrefab = contentData.ItemIDs[i].PassivePrefab;
					itemTwoPassivePrefabInst = PoolManager.Pools["Item Pool"].Spawn(itemTwoPassivePrefab.transform, itemTwoGameobject.transform.position, itemOneGameobject.transform.rotation);
				}
			}
			else
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
				currencyPopEffect.activate = true;
			}
			break;
		case 0:
			Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionDenied);
			itemOnePopEffect.activate = true;
			itemTwoPopEffect.activate = true;
			break;
		}
	}

	public void ItemTutorialEquipFunction(int i)
	{
		Camera.main.GetComponent<AudioSource>().PlayOneShot(selectionGranted);
		switch (i)
		{
		case 0:
			itemOneID = contentData.ItemIDs[0].itemID;
			itemOneNameID = contentData.ItemIDs[0].itemNameID;
			itemOneType = contentData.ItemIDs[0].itemClass;
			itemOneSubType = 0;
			itemOnePrefab = contentData.ItemIDs[0].ItemPrefab;
			itemOnePopEffect.activate = true;
			itemOneScrollType = contentData.ItemIDs[0].scrollType;
			itemOneIndicatorType = contentData.ItemIDs[0].indicatorType;
			itemOneScrollDirection = contentData.ItemIDs[0].arrowDirection;
			itemOneCentreScrollTypeHeight = contentData.ItemIDs[0].centreScrollTypeHeight;
			itemOneScrollActivateSound = contentData.ItemIDs[0].activateSound;
			itemOneIcon.animation2ClipName = contentData.ItemIDs[0].itemID;
			itemOneCharges = 1;
			itemOneChargeCost.Play("charge " + itemOneCharges);
			itemTwoID = contentData.ItemIDs[1].itemID;
			itemTwoNameID = contentData.ItemIDs[1].itemNameID;
			itemTwoType = contentData.ItemIDs[1].itemClass;
			itemTwoSubType = 1;
			itemTwoPrefab = contentData.ItemIDs[1].ItemPrefab;
			itemTwoPopEffect.activate = true;
			itemTwoScrollType = contentData.ItemIDs[1].scrollType;
			itemTwoIndicatorType = contentData.ItemIDs[1].indicatorType;
			itemTwoScrollDirection = contentData.ItemIDs[1].arrowDirection;
			itemTwoCentreScrollTypeHeight = contentData.ItemIDs[1].centreScrollTypeHeight;
			itemTwoScrollActivateSound = contentData.ItemIDs[1].activateSound;
			itemTwoIcon.animation2ClipName = contentData.ItemIDs[1].itemID;
			itemTwoCharges = 1;
			itemTwoChargeCost.Play("charge " + itemTwoCharges);
			break;
		case 1:
			itemOneID = contentData.ItemIDs[0].itemID;
			itemOneNameID = contentData.ItemIDs[0].itemNameID;
			itemOneType = contentData.ItemIDs[0].itemClass;
			itemOneSubType = 0;
			itemOnePrefab = contentData.ItemIDs[0].ItemPrefab;
			itemOnePopEffect.activate = true;
			itemOneScrollType = contentData.ItemIDs[0].scrollType;
			itemOneIndicatorType = contentData.ItemIDs[0].indicatorType;
			itemOneScrollDirection = contentData.ItemIDs[0].arrowDirection;
			itemOneCentreScrollTypeHeight = contentData.ItemIDs[0].centreScrollTypeHeight;
			itemOneScrollActivateSound = contentData.ItemIDs[0].activateSound;
			itemOneIcon.animation2ClipName = contentData.ItemIDs[0].itemID;
			itemOneCharges = 2;
			itemOneChargeCost.Play("charge " + itemOneCharges);
			break;
		}
	}

	public void ItemClear()
	{
		if (itemOnePrefab != null)
		{
			PoolManager.Pools["Item Pool"].Spawn(itemOnePrefab.transform, itemOneGameobject.transform.position, itemOneGameobject.transform.rotation);
		}
		if (itemOnePassivePrefabInst != null)
		{
			PoolManager.Pools["Item Pool"].Despawn(itemOnePassivePrefabInst);
		}
		itemOneChargeCost.Play("blank");
		itemOnePassivePrefabInst = null;
		itemOnePassivePrefab = null;
		itemOnePrefab = null;
		itemOneType = 0;
		itemOneSubType = 0;
		itemOneID = string.Empty;
		itemOneNameID = string.Empty;
		if (itemTwoPrefab != null)
		{
			PoolManager.Pools["Item Pool"].Spawn(itemTwoPrefab.transform, itemTwoGameobject.transform.position, itemTwoGameobject.transform.rotation);
		}
		if (itemTwoPassivePrefabInst != null)
		{
			PoolManager.Pools["Item Pool"].Despawn(itemTwoPassivePrefabInst);
		}
		itemTwoChargeCost.Play("blank");
		itemTwoPassivePrefabInst = null;
		itemTwoPassivePrefab = null;
		itemTwoPrefab = null;
		itemTwoType = 0;
		itemTwoSubType = 0;
		itemTwoID = string.Empty;
		itemTwoNameID = string.Empty;
	}

	private void ItemCoolDownFunction()
	{
		if (state == 1)
		{
			switch (itemOneType)
			{
			case 0:
				if (itemOneCoolDown != 0f)
				{
					TIMER_itemOneCoolDown = 0f;
					itemOneCoolDown = 0f;
					itemOneCoolDownBar.CurrentAmount = 0f;
					itemOneCoolDownBar.FullAmount = 0f;
				}
				break;
			case 1:
				if (itemOneCoolDown != 0f)
				{
					TIMER_itemOneCoolDown = 0f;
					itemOneCoolDown = 0f;
					itemOneCoolDownBar.CurrentAmount = 0f;
					itemOneCoolDownBar.FullAmount = 0f;
				}
				break;
			case 3:
				if (itemOneCoolDown != 0f)
				{
					TIMER_itemOneCoolDown = 0f;
					itemOneCoolDown = 0f;
					itemOneCoolDownBar.CurrentAmount = 0f;
					itemOneCoolDownBar.FullAmount = 0f;
				}
				break;
			case 2:
				if (TIMER_itemOneCoolDown < itemOneCoolDown)
				{
					TIMER_itemOneCoolDown += Time.deltaTime;
					itemOneCoolDownBar.CurrentAmount = TIMER_itemOneCoolDown;
				}
				else if (TIMER_itemOneCoolDown >= itemOneCoolDown)
				{
					TIMER_itemOneCoolDown = itemOneCoolDown;
					itemOneCoolDownBar.CurrentAmount = 0f;
				}
				if (itemOneCoolDownBar.FullAmount != itemOneCoolDown)
				{
					itemOneCoolDownBar.FullAmount = itemOneCoolDown;
				}
				break;
			}
			switch (itemTwoType)
			{
			case 0:
				if (itemTwoCoolDown != 0f)
				{
					TIMER_itemTwoCoolDown = 0f;
					itemTwoCoolDown = 0f;
					TIMER_itemTwoCoolDown = 0f;
					itemTwoCoolDownBar.CurrentAmount = 0f;
					itemTwoCoolDownBar.FullAmount = 0f;
				}
				break;
			case 1:
				if (itemTwoCoolDown != 0f)
				{
					TIMER_itemTwoCoolDown = 0f;
					itemTwoCoolDown = 0f;
					TIMER_itemTwoCoolDown = 0f;
					itemTwoCoolDownBar.CurrentAmount = 0f;
					itemTwoCoolDownBar.FullAmount = 0f;
				}
				break;
			case 3:
				if (itemTwoCoolDown != 0f)
				{
					TIMER_itemTwoCoolDown = 0f;
					itemTwoCoolDown = 0f;
					TIMER_itemTwoCoolDown = 0f;
					itemTwoCoolDownBar.CurrentAmount = 0f;
					itemTwoCoolDownBar.FullAmount = 0f;
				}
				break;
			case 2:
				if (TIMER_itemTwoCoolDown < itemTwoCoolDown)
				{
					TIMER_itemTwoCoolDown += Time.deltaTime;
					itemTwoCoolDownBar.CurrentAmount = TIMER_itemTwoCoolDown;
				}
				else if (TIMER_itemTwoCoolDown >= itemTwoCoolDown)
				{
					TIMER_itemTwoCoolDown = itemTwoCoolDown;
					itemTwoCoolDownBar.CurrentAmount = 0f;
				}
				if (itemTwoCoolDownBar.FullAmount != itemTwoCoolDown)
				{
					itemTwoCoolDownBar.FullAmount = itemTwoCoolDown;
				}
				break;
			}
			return;
		}
		int num = itemOneType;
		if (num == 2)
		{
			if (TIMER_itemOneCoolDown != itemOneCoolDown)
			{
				TIMER_itemOneCoolDown = itemOneCoolDown;
				itemOneCoolDownBar.CurrentAmount = 0f;
			}
			if (itemOneCoolDownBar.FullAmount != itemOneCoolDown)
			{
				itemOneCoolDownBar.FullAmount = itemOneCoolDown;
			}
		}
		num = itemOneType;
		if (num == 2)
		{
			if (TIMER_itemTwoCoolDown != itemTwoCoolDown)
			{
				TIMER_itemTwoCoolDown = itemTwoCoolDown;
				itemTwoCoolDownBar.CurrentAmount = 0f;
			}
			if (itemTwoCoolDownBar.FullAmount != itemTwoCoolDown)
			{
				itemTwoCoolDownBar.FullAmount = itemTwoCoolDown;
			}
		}
	}

	private void ItemSystemFuntion()
	{
		if (itemOneType == 0 && itemOneSubType != 0)
		{
			itemOneSubType = 0;
			itemOneChargeCost.Play("blank");
		}
		if (itemTwoType == 0 && itemTwoSubType != 0)
		{
			itemTwoSubType = 0;
			itemTwoChargeCost.Play("blank");
		}
		if (itemOneType == 0)
		{
			itemSlotAvailable = 2;
		}
		else if (itemTwoType == 0)
		{
			itemSlotAvailable = 1;
		}
		else
		{
			itemSlotAvailable = 0;
		}
		switch (itemOneType)
		{
		case 0:
			itemOneIcon.animation1 = true;
			itemOneBG.animation1 = true;
			itemOneChargeCost.Play("blank");
			if (itemOneHighlighter.GetComponent<Renderer>().enabled)
			{
				itemOneHighlighter.GetComponent<Renderer>().enabled = false;
			}
			break;
		case 1:
			itemOneIcon.animation2 = true;
			itemOneBG.animation2 = true;
			if (!itemOneHighlighter.GetComponent<Renderer>().enabled)
			{
				itemOneHighlighter.GetComponent<Renderer>().enabled = true;
			}
			break;
		case 2:
			if (TIMER_itemOneCoolDown < itemOneCoolDown)
			{
				if (itemOneHighlighter.GetComponent<Renderer>().enabled)
				{
					itemOneHighlighter.GetComponent<Renderer>().enabled = false;
				}
				itemOneIcon.animation9 = true;
			}
			else if (scriptGameStatistic.manaNumber < itemOneManaCost)
			{
				if (itemOneHighlighter.GetComponent<Renderer>().enabled)
				{
					itemOneHighlighter.GetComponent<Renderer>().enabled = false;
				}
				itemOneIcon.animation10 = true;
			}
			else
			{
				if (!itemOneHighlighter.GetComponent<Renderer>().enabled)
				{
					itemOnePopEffect.activate = true;
					itemOneHighlighter.GetComponent<Renderer>().enabled = true;
				}
				itemOneIcon.animation3 = true;
			}
			itemOneBG.animation3 = true;
			break;
		case 3:
			itemOneIcon.animation4 = true;
			itemOneBG.animation4 = true;
			if (!itemOneHighlighter.GetComponent<Renderer>().enabled)
			{
				itemOneHighlighter.GetComponent<Renderer>().enabled = true;
			}
			break;
		}
		switch (itemTwoType)
		{
		case 0:
			itemTwoIcon.animation1 = true;
			itemTwoBG.animation1 = true;
			itemTwoChargeCost.Play("blank");
			if (itemTwoHighlighter.GetComponent<Renderer>().enabled)
			{
				itemTwoHighlighter.GetComponent<Renderer>().enabled = false;
			}
			break;
		case 1:
			itemTwoIcon.animation2 = true;
			itemTwoBG.animation2 = true;
			if (!itemTwoHighlighter.GetComponent<Renderer>().enabled)
			{
				itemTwoHighlighter.GetComponent<Renderer>().enabled = true;
			}
			break;
		case 2:
			if (TIMER_itemTwoCoolDown < itemTwoCoolDown)
			{
				if (itemTwoHighlighter.GetComponent<Renderer>().enabled)
				{
					itemTwoHighlighter.GetComponent<Renderer>().enabled = false;
				}
				itemTwoIcon.animation9 = true;
			}
			else if (scriptGameStatistic.manaNumber < itemTwoManaCost)
			{
				if (itemTwoHighlighter.GetComponent<Renderer>().enabled)
				{
					itemTwoHighlighter.GetComponent<Renderer>().enabled = false;
				}
				itemTwoIcon.animation10 = true;
			}
			else
			{
				if (!itemTwoHighlighter.GetComponent<Renderer>().enabled)
				{
					itemTwoPopEffect.activate = true;
					itemTwoHighlighter.GetComponent<Renderer>().enabled = true;
				}
				itemTwoIcon.animation3 = true;
			}
			itemTwoBG.animation3 = true;
			break;
		case 3:
			itemTwoIcon.animation4 = true;
			itemTwoBG.animation4 = true;
			if (!itemTwoHighlighter.GetComponent<Renderer>().enabled)
			{
				itemTwoHighlighter.GetComponent<Renderer>().enabled = true;
			}
			break;
		}
	}

	private void HUDFunction()
	{
		switch (menuState)
		{
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		}
	}
}
