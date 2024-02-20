using UnityEngine;

public class random_spead_spawn : MonoBehaviour
{
	public float forwardSpeed = 20f;

	public float upSpeed = 20f;

	private float fs;

	private float us;

	private void Start()
	{
	}

	private void OnDespawned()
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
	}

	private void OnSpawned()
	{
		fs = UnityEngine.Random.Range(0f - forwardSpeed, forwardSpeed);
		us = UnityEngine.Random.Range(upSpeed, upSpeed * 2f);
		GetComponent<Rigidbody>().AddForce(fs, us, 0f);
	}

	private void Update()
	{
	}
}
