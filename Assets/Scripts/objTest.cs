using UnityEngine;

public class objTest : MonoBehaviour
{
	public bool despawn;

	public KeyCode despawnKey;

	private void Start()
	{
	}

	private void OnDespawned()
	{
		base.transform.position = new Vector3(0f, 10f, 0f);
		despawn = false;
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(despawnKey))
		{
			despawn = true;
		}
		if (despawn)
		{
			PoolManager.Pools["Object Pool"].Despawn(base.transform);
		}
	}
}
