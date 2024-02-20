using System;
using UnityEngine;

public class Unit_Content_Data : MonoBehaviour
{
	[Serializable]
	public class enemyIDs
	{
		public string enemyID;

		public GameObject enemyBundle;
	}

	public enemyIDs[] EnemyIDs = new enemyIDs[100];

	private void Start()
	{
	}

	private void Update()
	{
	}
}
