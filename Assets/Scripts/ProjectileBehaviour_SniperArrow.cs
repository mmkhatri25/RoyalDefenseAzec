using UnityEngine;

public class ProjectileBehaviour_SniperArrow : MonoBehaviour
{
	public float distance = 100f;

	public float range;

	public float rayHeight = -1.5f;

	public int alignment;

	private float zRayAxis;

	public string thisDespawnPool;

	public bool detectTeamA;

	public bool detectTeamB;

	public bool detectAttackA;

	public bool detectAttackB;

	public bool detectSpellA;

	public bool detectSpellB;

	public string spawnPoolName;

	public GameObject spawnDectectObject;

	public AudioClip startAudioClip;

	public AudioClip endAudioClip;

	public float moveSpeedX;

	public float moveSpeedY;

	private Game_Logic gameLogic;

	private Vector3 SpawnVector;

	private Transform myTransform;

	private int TOGGLE_detected;

	private void Awake()
	{
		myTransform = base.transform;
		gameLogic = GameScriptsManager.gameLogicScript;
		Transform transform = myTransform;
		Vector3 position = myTransform.position;
		float x = position.x;
		Vector3 position2 = myTransform.position;
		transform.position = new Vector3(x, position2.y, 0f);
	}

	private void OnDespawned()
	{
		TOGGLE_detected = 0;
	}

	private void OnSpawned()
	{
		if (startAudioClip != null)
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(startAudioClip);
		}
		switch (alignment)
		{
		case 0:
			zRayAxis = 0f;
			break;
		case 1:
			zRayAxis = 1f;
			break;
		}
		TOGGLE_detected = 0;
	}

	private void Update()
	{
		if (Time.timeScale != 0f)
		{
			MoveSpeed();
			distanceRay();
			Vector3 position = myTransform.position;
			if (position.y >= 8f)
			{
				Detected();
			}
		}
		if (gameLogic.gameState != 2)
		{
			PoolManager.Pools[thisDespawnPool].Despawn(base.transform);
		}
	}

	private void MoveSpeed()
	{
		if (moveSpeedX != 0f)
		{
			myTransform.Translate(myTransform.forward * moveSpeedX * Time.deltaTime, Space.World);
		}
		if (moveSpeedY != 0f)
		{
			myTransform.Translate(myTransform.up * moveSpeedY * Time.deltaTime, Space.World);
		}
	}

	private void Detected()
	{
		if (TOGGLE_detected == 0)
		{
			if (spawnDectectObject != null)
			{
				PoolManager.Pools[spawnPoolName].Spawn(spawnDectectObject.transform, SpawnVector, spawnDectectObject.transform.rotation);
			}
			if (endAudioClip != null)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(endAudioClip);
			}
			PoolManager.Pools[thisDespawnPool].Despawn(base.transform);
			TOGGLE_detected = 1;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (detectTeamA && other.gameObject.CompareTag("TmA"))
		{
			Detected();
		}
		if (detectTeamB && other.gameObject.CompareTag("TmB"))
		{
			Detected();
		}
		if (detectAttackA && (other.gameObject.CompareTag("AtAA") || other.gameObject.CompareTag("AtAB") || other.gameObject.CompareTag("AtAAB")))
		{
			Detected();
		}
		if (detectAttackB && (other.gameObject.CompareTag("AtBB") || other.gameObject.CompareTag("AtBA") || other.gameObject.CompareTag("AtBAB")))
		{
			Detected();
		}
		if (detectSpellA && other.gameObject.CompareTag("AtAS"))
		{
			Detected();
		}
		if (detectSpellB && other.gameObject.CompareTag("AtBS"))
		{
			Detected();
		}
	}

	private void distanceRay()
	{
		if (distance > 0f)
		{
			Vector3 direction = myTransform.TransformDirection(-Vector3.up);
			Vector3 localPosition = myTransform.localPosition;
			Vector3 vector = new Vector3(localPosition.x + range, rayHeight, zRayAxis);
			if (Physics.Raycast(vector, direction, out RaycastHit hitInfo, distance))
			{
				UnityEngine.Debug.DrawLine(vector, vector - myTransform.up * hitInfo.distance, Color.magenta);
				Vector3 position = hitInfo.transform.position;
				float x = position.x;
				Vector3 position2 = myTransform.position;
				float y = position2.y;
				Vector3 position3 = myTransform.position;
				SpawnVector = new Vector3(x, y, position3.z);
			}
			else
			{
				UnityEngine.Debug.DrawLine(vector, vector - myTransform.up * distance, Color.magenta);
				Vector3 position4 = base.transform.position;
				float x2 = position4.x + distance;
				Vector3 position5 = myTransform.position;
				float y2 = position5.y;
				Vector3 position6 = myTransform.position;
				SpawnVector = new Vector3(x2, y2, position6.z);
			}
		}
		else if (distance < 0f)
		{
			Vector3 direction2 = myTransform.TransformDirection(-Vector3.up);
			Vector3 localPosition2 = myTransform.localPosition;
			Vector3 vector2 = new Vector3(localPosition2.x - range, rayHeight, zRayAxis);
			if (Physics.Raycast(vector2, direction2, out RaycastHit hitInfo2, 0f - distance))
			{
				UnityEngine.Debug.DrawLine(vector2, vector2 - myTransform.up * (0f - hitInfo2.distance), Color.magenta);
				Vector3 position7 = hitInfo2.transform.position;
				float x3 = position7.x;
				Vector3 position8 = myTransform.position;
				float y3 = position8.y;
				Vector3 position9 = myTransform.position;
				SpawnVector = new Vector3(x3, y3, position9.z);
			}
			else
			{
				UnityEngine.Debug.DrawLine(vector2, vector2 - myTransform.up * (0f - distance), Color.magenta);
				Vector3 position10 = base.transform.position;
				float x4 = position10.x - distance;
				Vector3 position11 = myTransform.position;
				float y4 = position11.y;
				Vector3 position12 = myTransform.position;
				SpawnVector = new Vector3(x4, y4, position12.z);
			}
		}
	}
}
