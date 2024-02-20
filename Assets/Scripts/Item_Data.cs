using System;
using UnityEngine;

public class Item_Data : MonoBehaviour
{
	[Serializable]
	public class itemIDs
	{
		public string itemName;

		public string itemID;

		public int itemClass;

		public int itemNumber;

		public GameObject PassivePrefab;

		public GameObject ItemPrefab;

		public int itemMaximumCharges;

		public int itemManaCost;

		public float itemCoolDown;

		public int itemCost;

		public string itemIconID;

		public int itemBG;

		public string itemDescriptionQuote;

		public string itemDescriptionInfo;

		public int scrollType;

		public float arrowDirection;

		public float centrescrollTypeHeight;

		public int indicatorType;

		public AudioClip activateSound;
	}

	public itemIDs[] ItemIDs = new itemIDs[100];

	private void Start()
	{
	}

	private void Update()
	{
	}
}
