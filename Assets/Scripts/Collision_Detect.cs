using UnityEngine;

public class Collision_Detect : MonoBehaviour
{
	public string thisDespawnPool;

	public bool detectStageCeiling;

	public bool detectStageGround;

	public bool detectStageBelowGround;

	public bool detectStageRight;

	public bool detectStageLeft;

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

	private Transform myTransform;

	private float stageLength;

	private int TOGGLE_detected;

	private float TIMER_delay;

	private void Start()
	{
		stageLength = GameScriptsManager.masterControlScript.stageLength;
		myTransform = base.transform;
		if (startAudioClip != null)
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(startAudioClip);
		}
	}

	private void OnSpawned()
	{
		if (startAudioClip != null)
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(startAudioClip);
		}
		base.gameObject.SetActiveRecursively(state: true);
		TOGGLE_detected = 0;
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		if (TOGGLE_detected == 0)
		{
			MoveSpeed();
			StageDetection();
		}
		Detected();
		Vector3 position = myTransform.position;
		if (position.x >= 10f + stageLength)
		{
			OffGameArea();
			return;
		}
		Vector3 position2 = myTransform.position;
		if (position2.x <= -10f)
		{
			OffGameArea();
			return;
		}
		Vector3 position3 = myTransform.position;
		if (position3.y <= -10f)
		{
			OffGameArea();
			return;
		}
		Vector3 position4 = myTransform.position;
		if (position4.y >= 10f)
		{
			OffGameArea();
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
		switch (TOGGLE_detected)
		{
		case 1:
			if (spawnDectectObject != null)
			{
				PoolManager.Pools[spawnPoolName].Spawn(spawnDectectObject.transform, base.transform.position, spawnDectectObject.transform.rotation);
			}
			if (endAudioClip != null)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(endAudioClip);
			}
			TIMER_delay = Time.time + 0.1f;
			TOGGLE_detected = 2;
			break;
		case 2:
			if (Time.time >= TIMER_delay)
			{
				TOGGLE_detected = 3;
			}
			break;
		case 3:
			if (thisDespawnPool != string.Empty)
			{
				PoolManager.Pools[thisDespawnPool].Despawn(base.transform);
			}
			else
			{
				base.gameObject.SetActiveRecursively(state: false);
			}
			TIMER_delay = 0f;
			TOGGLE_detected++;
			break;
		}
	}

	private void OffGameArea()
	{
		if (thisDespawnPool != string.Empty)
		{
			PoolManager.Pools[thisDespawnPool].Despawn(base.transform);
		}
		else
		{
			base.gameObject.SetActiveRecursively(state: false);
		}
	}

	private void StageDetection()
	{
		if (detectStageRight)
		{
			Vector3 position = myTransform.position;
			if (position.x >= 5.4f + stageLength)
			{
				TOGGLE_detected = 1;
			}
		}
		if (detectStageLeft)
		{
			Vector3 position2 = myTransform.position;
			if (position2.x <= -5.4f)
			{
				TOGGLE_detected = 1;
			}
		}
		if (detectStageGround)
		{
			Vector3 position3 = myTransform.position;
			if (position3.y <= 0.15f)
			{
				TOGGLE_detected = 1;
			}
		}
		if (detectStageBelowGround)
		{
			Vector3 position4 = myTransform.position;
			if (position4.y <= -1.15f)
			{
				TOGGLE_detected = 1;
			}
		}
		if (detectStageCeiling)
		{
			Vector3 position5 = myTransform.position;
			if (position5.y >= 3.9f)
			{
				TOGGLE_detected = 1;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (detectTeamA && other.gameObject.CompareTag("TmA"))
		{
			TOGGLE_detected = 1;
		}
		if (detectTeamB && other.gameObject.CompareTag("TmB"))
		{
			TOGGLE_detected = 1;
		}
		if (detectAttackA && (other.gameObject.CompareTag("AtAA") || other.gameObject.CompareTag("AtAB") || other.gameObject.CompareTag("AtAAB")))
		{
			TOGGLE_detected = 1;
		}
		if (detectAttackB && (other.gameObject.CompareTag("AtBB") || other.gameObject.CompareTag("AtBA") || other.gameObject.CompareTag("AtBAB")))
		{
			TOGGLE_detected = 1;
		}
		if (detectSpellA && (other.gameObject.CompareTag("AtSB") || other.gameObject.CompareTag("AtSAB")))
		{
			TOGGLE_detected = 1;
		}
		if (detectSpellB && (other.gameObject.CompareTag("AtSA") || other.gameObject.CompareTag("AtSAB")))
		{
			TOGGLE_detected = 1;
		}
	}
}
