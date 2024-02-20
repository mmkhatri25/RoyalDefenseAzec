using UnityEngine;

public class UnitAddon : MonoBehaviour
{
	public GameObject targetObject;

	private void Start()
	{
		base.useGUILayout = false;
	}

	private void Update()
	{
		if (targetObject == null || !targetObject.active)
		{
			PoolManager.Pools["HUD Pool"].Despawn(base.transform);
		}
	}
}
