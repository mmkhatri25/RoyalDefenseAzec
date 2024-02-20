using UnityEngine;

public class AmpSword_Script : MonoBehaviour
{
	public string spawnPool = "Spell Pool";

	public string effectPool = "Effect Pool";

	public GameObject sword;

	public GameObject disappearEffect;

	public float xPosition;

	public float yPosition;

	public float damp = 10f;

	public bool Activate;

	public float ActivateDelay;

	private float timer;

	private bool destroy;

	private float desTime = 3f;

	private float desTimer;

	private Vector3 FixedLocation;

	private Vector3 originalPos;

	private void Awake()
	{
		Vector3 position = base.transform.position;
		float x = position.x;
		Vector3 position2 = sword.transform.position;
		originalPos = new Vector3(x, position2.y, 0f);
	}

	private void OnDespawned()
	{
		Transform transform = sword.transform;
		Vector3 position = base.transform.position;
		transform.position = new Vector3(position.x, originalPos.y, 0f);
		Activate = true;
		timer = Time.time;
		desTimer = Time.time;
		destroy = false;
	}

	private void OnSpawned()
	{
		Transform transform = sword.transform;
		Vector3 position = base.transform.position;
		transform.position = new Vector3(position.x, originalPos.y, 0f);
		Activate = true;
		timer = Time.time;
		desTimer = Time.time;
		destroy = false;
	}

	private void FixedUpdate()
	{
		if (Time.timeScale == 0f || !Activate)
		{
			return;
		}
		if (sword != null)
		{
			Transform transform = sword.transform;
			Vector3 position = sword.transform.position;
			Vector3 position2 = base.transform.position;
			float x = position2.x + xPosition;
			Vector3 position3 = base.transform.position;
			transform.position = Vector3.Lerp(position, new Vector3(x, position3.y + yPosition, 0.9f), damp);
		}
		if (Time.time < timer + ActivateDelay)
		{
			return;
		}
		if (Time.time >= timer + ActivateDelay)
		{
			destroy = true;
		}
		if (destroy && !(Time.time < desTimer + desTime) && Time.time >= desTimer + desTime)
		{
			if (disappearEffect != null)
			{
				SpawnPool obj = PoolManager.Pools[effectPool];
				Transform transform2 = disappearEffect.transform;
				Vector3 position4 = base.transform.position;
				float x2 = position4.x + xPosition;
				Vector3 position5 = base.transform.position;
				float y = position5.y + yPosition;
				Vector3 position6 = base.transform.position;
				obj.Spawn(transform2, new Vector3(x2, y, position6.z + 0.2f), disappearEffect.transform.rotation);
			}
			PoolManager.Pools[spawnPool].Despawn(base.transform);
		}
	}
}
