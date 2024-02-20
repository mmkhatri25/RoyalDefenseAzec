using System;
using UnityEngine;

public class enemy_bundle : MonoBehaviour
{
	[Serializable]
	public class bossSpeech
	{
		public string playerCharacterID;

		public string warningQuote = "A CHAMPION";

		public string introductionSpeech = "speech";

		public string championName = "name";

		public int musicTrackNumber;

		public float minSpawnRatio;

		public float maxSpawnRatio;
	}

	public string enemyID;

	public GameObject[] waveUnits;

	public GameObject[] bossUnits;

	public bossSpeech[] BossSpeech;

	public GameObject[] recurringUnits;

	public GameObject levelPreview;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
