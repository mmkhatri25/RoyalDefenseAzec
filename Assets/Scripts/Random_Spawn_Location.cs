using UnityEngine;

public class Random_Spawn_Location : MonoBehaviour
{
	public int randomLocationType;

	public float minAxisX = 1f;

	public float maxAxisX = 2f;

	public float minAxisY = 1f;

	public float maxAxisY = 2f;

	private float stageLength;

	private Vector3 VECTOR_original;

	private void Start()
	{
		switch (randomLocationType)
		{
		case -1:
		{
			stageLength = GameScriptsManager.masterControlScript.stageLength;
			Transform transform3 = base.transform;
			float x3 = UnityEngine.Random.Range(minAxisX, maxAxisX + stageLength);
			float y3 = UnityEngine.Random.Range(minAxisY, maxAxisY);
			Vector3 position5 = base.transform.position;
			transform3.position = new Vector3(x3, y3, position5.z);
			break;
		}
		case 0:
		{
			Transform transform2 = base.transform;
			float x2 = UnityEngine.Random.Range(minAxisX, maxAxisX);
			float y2 = UnityEngine.Random.Range(minAxisY, maxAxisY);
			Vector3 position4 = base.transform.position;
			transform2.position = new Vector3(x2, y2, position4.z);
			break;
		}
		case 1:
		{
			VECTOR_original = base.transform.position;
			Transform transform = base.transform;
			Vector3 position = base.transform.position;
			float x = position.x + UnityEngine.Random.Range(minAxisX, maxAxisX);
			Vector3 position2 = base.transform.position;
			float y = position2.y + UnityEngine.Random.Range(minAxisY, maxAxisY);
			Vector3 position3 = base.transform.position;
			transform.position = new Vector3(x, y, position3.z);
			break;
		}
		}
	}

	private void OnSpawned()
	{
		switch (randomLocationType)
		{
		case -1:
		{
			Transform transform5 = base.transform;
			float x5 = UnityEngine.Random.Range(minAxisX, maxAxisX + stageLength);
			float y5 = UnityEngine.Random.Range(minAxisY, maxAxisY);
			Vector3 position11 = base.transform.position;
			transform5.position = new Vector3(x5, y5, position11.z);
			break;
		}
		case 0:
		{
			Transform transform6 = base.transform;
			float x6 = UnityEngine.Random.Range(minAxisX, maxAxisX);
			float y6 = UnityEngine.Random.Range(minAxisY, maxAxisY);
			Vector3 position12 = base.transform.position;
			transform6.position = new Vector3(x6, y6, position12.z);
			break;
		}
		case 1:
		{
			VECTOR_original = base.transform.position;
			Transform transform7 = base.transform;
			Vector3 position13 = base.transform.position;
			float x7 = position13.x + UnityEngine.Random.Range(minAxisX, maxAxisX);
			Vector3 position14 = base.transform.position;
			float y7 = position14.y + UnityEngine.Random.Range(minAxisY, maxAxisY);
			Vector3 position15 = base.transform.position;
			transform7.position = new Vector3(x7, y7, position15.z);
			break;
		}
		case 2:
			if (minAxisX != 0f && maxAxisX != 0f)
			{
				Transform transform3 = base.transform;
				float x3 = UnityEngine.Random.Range(minAxisX, maxAxisX);
				Vector3 position7 = base.transform.position;
				float y3 = position7.y;
				Vector3 position8 = base.transform.position;
				transform3.position = new Vector3(x3, y3, position8.z);
			}
			if (minAxisY != 0f && maxAxisY != 0f)
			{
				Transform transform4 = base.transform;
				Vector3 position9 = base.transform.position;
				float x4 = position9.x;
				float y4 = UnityEngine.Random.Range(minAxisY, maxAxisY);
				Vector3 position10 = base.transform.position;
				transform4.position = new Vector3(x4, y4, position10.z);
			}
			break;
		case 3:
			VECTOR_original = base.transform.position;
			if (minAxisX != 0f && maxAxisX != 0f)
			{
				Transform transform = base.transform;
				Vector3 position = base.transform.position;
				float x = position.x + UnityEngine.Random.Range(minAxisX, maxAxisX);
				Vector3 position2 = base.transform.position;
				float y = position2.y;
				Vector3 position3 = base.transform.position;
				transform.position = new Vector3(x, y, position3.z);
			}
			if (minAxisY != 0f && maxAxisY != 0f)
			{
				Transform transform2 = base.transform;
				Vector3 position4 = base.transform.position;
				float x2 = position4.x;
				Vector3 position5 = base.transform.position;
				float y2 = position5.y + UnityEngine.Random.Range(minAxisY, maxAxisY);
				Vector3 position6 = base.transform.position;
				transform2.position = new Vector3(x2, y2, position6.z);
			}
			break;
		}
	}

	private void OnDespawned()
	{
		switch (randomLocationType)
		{
		case 2:
			break;
		case 1:
			base.transform.position = VECTOR_original;
			break;
		case 3:
			base.transform.position = VECTOR_original;
			break;
		}
	}

	private void Update()
	{
	}
}
