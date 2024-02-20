using System;
using UnityEngine;

public class itemcheck : MonoBehaviour
{
	[Serializable]
	public class itemConsumables
	{
		public string itemName;

		public string itemID;

		public int itemClass = 1;

		public int itemNumber;

		public GameObject PassivePrefab;

		public GameObject ItemPrefab;

		public int itemCharges;

		public int itemCost;

		public string itemIconID;

		public string itemDescriptionQuote;

		public string itemDescriptionInfo;

		public AudioClip activateSound;
	}

	[Serializable]
	public class itemScrolls
	{
		public string itemName;

		public string itemID;

		public int itemClass = 2;

		public int itemNumber;

		public GameObject PassivePrefab;

		public GameObject ItemPrefab;

		public int itemManaCost;

		public float itemCoolDown;

		public int itemCost;

		public string itemIconID;

		public string itemDescriptionQuote;

		public string itemDescriptionInfo;

		public int scrollType;

		public float arrowDirection;

		public float centrescrollTypeHeight;

		public int indicatorType;

		public AudioClip activateSound;
	}

	[Serializable]
	public class itemAccessories
	{
		public string itemName;

		public string itemID;

		public int itemClass = 3;

		public int itemNumber;

		public GameObject PassivePrefab;

		public GameObject ItemPrefab;

		public int itemCost;

		public string itemIconID;

		public string itemDescriptionQuote;

		public string itemDescriptionInfo;

		public AudioClip activateSound;
	}

	public itemtest testItem;

	public string itemGameID;

	public itemConsumables[] ItemConsumables;

	public itemScrolls[] ItemScrolls;

	public itemAccessories[] ItemAccessories;

	private void Start()
	{
		ItemSetupFunction();
	}

	private void ItemSetupFunction()
	{
	}

	private void Update()
	{
	}
}
