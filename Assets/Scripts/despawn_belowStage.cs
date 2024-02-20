using UnityEngine;

public class despawn_belowStage : MonoBehaviour
{
	public string despawnPool;

	private Transform myTransform;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void Update()
	{
		Vector3 position = myTransform.position;
		if (position.y <= -2f)
		{
			PoolManager.Pools[despawnPool].Despawn(base.transform);
		}
	}
}
