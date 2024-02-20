using UnityEngine;

public class SpellType_Targeting : MonoBehaviour
{
	public string spawnPoolName = "Spell Pool";

	public string prefabPoolName = "Spell Pool";

	public GameObject spawnPrefab;

	public int spellThrowType;

	public bool breakUponDistance;

	public float setAngle = 90f;

	private bool archMovement;

	public float movementSpeed = 5f;

	private float riseHeight = 2f;

	private float TIMER_riseHeight;

	private float VELOCITY_riseHeight;

	public float breakRatioDistance;

	public AudioClip appearSound;

	public AudioClip effectSound;

	public Transform spawnLocation;

	public Transform despawnDestination;

	private Vector3 VECTOR_despawnDestination;

	private Transform myTransform;

	private Game_Statistics scriptGameStatistic;

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		scriptGameStatistic = GameScriptsManager.gameStatisticScript;
	}

	private void OnSpawned()
	{
		TIMER_riseHeight = 0f;
		VELOCITY_riseHeight = 0f;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(appearSound);
		Vector3 position = myTransform.position;
		float x = position.x;
		Vector3 position2 = myTransform.position;
		VECTOR_despawnDestination = new Vector3(x, position2.y, 0f);
		myTransform.position = new Vector3(-3.4f, 1.25f, 0f);
		switch (spellThrowType)
		{
		case 0:
			myTransform.localRotation = Quaternion.Euler(0f, setAngle, 0f);
			break;
		case 1:
			archMovement = true;
			myTransform.LookAt(VECTOR_despawnDestination);
			break;
		case 2:
			myTransform.LookAt(VECTOR_despawnDestination);
			break;
		case 3:
			if (scriptGameStatistic.closesIntruder != null)
			{
				Transform transform = myTransform;
				Vector3 position3 = scriptGameStatistic.closesIntruder.transform.position;
				float x2 = position3.x;
				Vector3 position4 = scriptGameStatistic.closesIntruder.transform.position;
				transform.LookAt(new Vector3(x2, position4.y, 0f));
			}
			else
			{
				myTransform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			}
			break;
		case 4:
			breakUponDistance = true;
			myTransform.LookAt(VECTOR_despawnDestination);
			break;
		}
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		if (breakUponDistance)
		{
			Vector3 position = myTransform.position;
			if (position.x < VECTOR_despawnDestination.x - breakRatioDistance)
			{
				myTransform.Translate(myTransform.forward * movementSpeed * Time.deltaTime, Space.World);
				myTransform.Translate(myTransform.up * VELOCITY_riseHeight * Time.deltaTime, Space.World);
			}
			else
			{
				Vector3 position2 = myTransform.position;
				if (position2.x >= VECTOR_despawnDestination.x - breakRatioDistance)
				{
					HitEffect();
				}
			}
		}
		else
		{
			myTransform.Translate(myTransform.forward * movementSpeed * Time.deltaTime, Space.World);
			myTransform.Translate(myTransform.up * VELOCITY_riseHeight * Time.deltaTime, Space.World);
		}
		if (archMovement)
		{
			riseHeight = (VECTOR_despawnDestination.x - breakRatioDistance) / 2f;
			if (TIMER_riseHeight < riseHeight)
			{
				TIMER_riseHeight += 0.1f;
				VELOCITY_riseHeight += 0.2f;
			}
			else if (TIMER_riseHeight >= riseHeight)
			{
				VELOCITY_riseHeight -= 0.2f;
			}
		}
		else
		{
			VELOCITY_riseHeight = 0f;
		}
	}

	private void HitEffect()
	{
		Camera.main.GetComponent<AudioSource>().PlayOneShot(effectSound);
		if (spawnPrefab != null)
		{
			SpawnPool spawnPool = PoolManager.Pools[prefabPoolName];
			Transform transform = spawnPrefab.transform;
			Vector3 position = myTransform.position;
			float x = position.x;
			Vector3 position2 = myTransform.position;
			spawnPool.Spawn(transform, new Vector3(x, position2.y, 0f), myTransform.rotation);
		}
		PoolManager.Pools[spawnPoolName].Despawn(base.transform);
	}
}
