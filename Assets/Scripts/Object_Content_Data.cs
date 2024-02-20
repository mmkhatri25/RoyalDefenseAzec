using System;
using UnityEngine;

public class Object_Content_Data : MonoBehaviour
{
	[Serializable]
	public class objectList
	{
		public string objectID;

		public string objectName = "object";

		public GameObject objectPrefab;

		public float defaultDuration;

		public int defaultSpawnType;
	}

	public GameObject[] objectLogicPrefab = new GameObject[4];

	public objectList[] ObjectList;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
