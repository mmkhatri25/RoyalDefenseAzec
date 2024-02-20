using System;
using UnityEngine;

public class Item_Content_Data : MonoBehaviour
{
	[Serializable]
	public class itemIDs
	{
		public string itemName;

		public int itemLock;

		public string itemID;

		public string itemNameID;

		public int itemClass;

		public int itemNumber;

		public GameObject PassivePrefab;

		public GameObject ItemPrefab;

		public int itemMaximumCharges;

		public int itemManaCost;

		public float itemCoolDown;

		public int itemShopAmount;

		public int itemCost;

		public string itemIconID;

		public int itemBG;

		public string itemDescriptionQuote;

		public string itemDescriptionInfo;

		public int scrollType;

		public float arrowDirection;

		public float centreScrollTypeHeight;

		public int indicatorType;

		public AudioClip activateSound;
	}

	[Serializable]
	public class itemIDsOrganize
	{
		public ItemBundle[] itemBundle = new ItemBundle[30];
	}

	public int state;

	public int itemDebug;

	public itemIDs[] ItemIDs = new itemIDs[40];

	public itemIDsOrganize[] ItemIDsOrganize = new itemIDsOrganize[3];

	private int NUMBER_item;

	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
		ScriptsManager.itemContentDataScript = GetComponent<Item_Content_Data>();
		state = 0;
	}

	private void Update()
	{
		switch (state)
		{
		case 3:
			break;
		case 0:
			ItemOrganization();
			state++;
			break;
		case 1:
			for (int i = 0; i < ItemIDs.Length; i++)
			{
				if (itemDebug == 0)
				{
					if (ItemIDs[i].itemLock == 2)
					{
						ItemIDs[i].itemLock = 1;
					}
				}
				else
				{
					ItemIDs[i].itemLock = 1;
				}
			}
			state++;
			break;
		case 2:
			ItemUpdate();
			state++;
			break;
		case 4:
			UnityEngine.Object.Destroy(base.gameObject);
			break;
		}
	}

	private void ItemOrganization()
	{
		for (int i = 0; i < ItemIDsOrganize.Length; i++)
		{
			NUMBER_item = 1;
			for (int j = 0; j < ItemIDsOrganize[i].itemBundle.Length; j++)
			{
				if (!(ItemIDsOrganize[i].itemBundle[j] != null))
				{
					continue;
				}
				for (int k = 0; k < ItemIDs.Length; k++)
				{
					if (ItemIDs[k].itemName == string.Empty)
					{
						ItemIDs[k].itemName = ItemIDsOrganize[i].itemBundle[j].itemName;
						ItemIDs[k].itemLock = ItemIDsOrganize[i].itemBundle[j].itemLock;
						ItemIDs[k].itemID = ItemIDsOrganize[i].itemBundle[j].itemID;
						ItemIDs[k].itemNameID = ItemIDsOrganize[i].itemBundle[j].itemNameID;
						ItemIDs[k].itemClass = i + 1;
						ItemIDs[k].itemNumber = NUMBER_item;
						ItemIDs[k].PassivePrefab = ItemIDsOrganize[i].itemBundle[j].PassivePrefab;
						ItemIDs[k].ItemPrefab = ItemIDsOrganize[i].itemBundle[j].ItemPrefab;
						ItemIDs[k].itemMaximumCharges = ItemIDsOrganize[i].itemBundle[j].itemMaximumCharges;
						ItemIDs[k].itemManaCost = ItemIDsOrganize[i].itemBundle[j].itemManaCost;
						ItemIDs[k].itemCoolDown = ItemIDsOrganize[i].itemBundle[j].itemCoolDown;
						ItemIDs[k].itemShopAmount = ItemIDsOrganize[i].itemBundle[j].itemShopAmount;
						ItemIDs[k].itemCost = ItemIDsOrganize[i].itemBundle[j].itemCost;
						ItemIDs[k].itemIconID = ItemIDsOrganize[i].itemBundle[j].itemIconID;
						ItemIDs[k].itemBG = ItemIDsOrganize[i].itemBundle[j].itemBG;
						ItemIDs[k].itemDescriptionQuote = ItemIDsOrganize[i].itemBundle[j].itemDescriptionQuote;
						ItemIDs[k].itemDescriptionInfo = ItemIDsOrganize[i].itemBundle[j].itemDescriptionInfo;
						ItemIDs[k].scrollType = ItemIDsOrganize[i].itemBundle[j].scrollType;
						ItemIDs[k].arrowDirection = ItemIDsOrganize[i].itemBundle[j].arrowDirection;
						ItemIDs[k].centreScrollTypeHeight = ItemIDsOrganize[i].itemBundle[j].centreScrollTypeHeight;
						ItemIDs[k].indicatorType = ItemIDsOrganize[i].itemBundle[j].indicatorType;
						ItemIDs[k].activateSound = ItemIDsOrganize[i].itemBundle[j].activateSound;
						NUMBER_item++;
						k = ItemIDs.Length;
					}
				}
			}
		}
	}

	public void ItemUpdate()
	{
		for (int i = 0; i < ItemIDs.Length; i++)
		{
			if (ItemIDs[i].itemLock != 1)
			{
				ItemIDs[i].itemLock = PlayerPrefs.GetInt(ItemIDs[i].itemID + "itemLock");
			}
		}
	}
}
