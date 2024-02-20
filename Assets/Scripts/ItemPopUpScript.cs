using UnityEngine;

public class ItemPopUpScript : MonoBehaviour
{
	public string spawnPoolName = "Item Pool";

	public string prefabSpawnName = "Item Pool";

	public AudioClip appearSound;

	public AudioClip effectSound;

	public GameObject prefabSpawn;

	private float itemDamping = 16f;

	private float itemDisplayDuration = 3f;

	private float TIMER_itemDisplayDuration;

	private Vector3 VECTOR_itemDestination;

	private Vector3 VECTOR_itemDestinationY;

	public string itemID;

	public tk2dAnimatedSprite sprite;

	private Transform myTransform;

	private int playAnimation;

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void OnDespawned()
	{
		TIMER_itemDisplayDuration = 0f;
		itemID = string.Empty;
	}

	private void OnSpawned()
	{
		TIMER_itemDisplayDuration = 0f;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(appearSound);
		if (sprite != null && itemID != string.Empty)
		{
			sprite.Play(itemID);
		}
	}

	private void Update()
	{
		if (Time.timeScale != 0f)
		{
			if (sprite != null && itemID != string.Empty)
			{
				sprite.Play(itemID);
				itemID = string.Empty;
			}
			Vector3 position = Camera.main.transform.position;
			float x = position.x;
			Vector3 position2 = Camera.main.transform.position;
			VECTOR_itemDestination = new Vector3(x, position2.y, -5f);
			if (TIMER_itemDisplayDuration < itemDisplayDuration)
			{
				myTransform.position = Vector3.Lerp(myTransform.position, VECTOR_itemDestination, Time.deltaTime * itemDamping);
				TIMER_itemDisplayDuration += 0.1f;
			}
			else if (TIMER_itemDisplayDuration >= itemDisplayDuration)
			{
				ItemEffect();
				PoolManager.Pools[spawnPoolName].Despawn(base.transform);
			}
		}
	}

	private void ItemEffect()
	{
		Camera.main.GetComponent<AudioSource>().PlayOneShot(effectSound);
		if (prefabSpawn != null)
		{
			SpawnPool spawnPool = PoolManager.Pools[prefabSpawnName];
			Transform transform = prefabSpawn.transform;
			Vector3 position = myTransform.position;
			float x = position.x;
			Vector3 position2 = myTransform.position;
			spawnPool.Spawn(transform, new Vector3(x, position2.y, 0f), myTransform.rotation);
		}
	}
}
