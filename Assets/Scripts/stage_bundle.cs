using System;
using UnityEngine;

public class stage_bundle : MonoBehaviour
{
	[Serializable]
	public class PoleObject
	{
		public GameObject Pole;

		public int PoleSpawnDurationType;
	}

	[Serializable]
	public class CellingObject
	{
		public GameObject Celling;

		public int CellingSpawnDurationType;
	}

	[Serializable]
	public class CentreObject
	{
		public GameObject Centre;

		public int CentreSpawnDurationType;
	}

	[Serializable]
	public class ThroneObject
	{
		public GameObject Throne;

		public int ThroneSpawnDurationType;
	}

	[Serializable]
	public class objectSpawner
	{
		public GameObject spawnObject;

		public int spawnDurationType;

		public int spawnSection;

		public int spawnPosition;
	}

	public PoleObject[] poleObject;

	public CellingObject[] cellingObject;

	public CentreObject[] centreObject;

	public ThroneObject[] throneObject;

	public objectSpawner[] ObjectSpawner;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
