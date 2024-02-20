using UnityEngine;

public class spawn_localPosition : MonoBehaviour
{
	public float x;

	public float y;

	public float z;

	private void Start()
	{
	}

	private void OnSpawned()
	{
		base.transform.localPosition = new Vector3(x, y, z);
	}

	private void Update()
	{
	}
}
