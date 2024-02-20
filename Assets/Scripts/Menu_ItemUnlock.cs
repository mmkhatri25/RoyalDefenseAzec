using System;
using UnityEngine;

public class Menu_ItemUnlock : MonoBehaviour
{
	[Serializable]
	public class itemSet
	{
		public tk2dAnimatedSprite itemIcon;

		public tk2dAnimatedSprite itemIconBG;

		public tk2dAnimatedSprite itemTypeIcon;

		public tk2dAnimatedSprite itemCheck;

		public tk2dTextMesh itemName;

		public tk2dTextMesh itemCategory;

		public tk2dTextMesh itemDesciption;
	}

	public string characterID;

	public int state;

	private int TOGGLE_state;

	public string[] itemID = new string[4];

	public string[] itemDescription = new string[4];

	public itemSet[] ItemSet = new itemSet[4];

	private Content_Data contentData;

	private void Start()
	{
		contentData = ScriptsManager.contentDataScript;
	}
}
