using System;
using UnityEngine;

public class Level_Content : MonoBehaviour
{
	[Serializable]
	public class StageLevel
	{
		public string objectIDs;

		public string positionIDs;

		public string behaviourID;
	}

	public string levelContentID;

	public string description;

	public StageLevel[] stageLevel = new StageLevel[20];

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
