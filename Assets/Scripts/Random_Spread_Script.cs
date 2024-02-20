using UnityEngine;

public class Random_Spread_Script : MonoBehaviour
{
	public float forwardSpeed = 20f;

	public float upSpeed = 20f;

	private float fallDelay = 0.1f;

	public bool ground;

	private float timer;

	private float fs;

	private float us;

	private void Start()
	{
		fs = UnityEngine.Random.Range(0f - forwardSpeed, forwardSpeed);
		us = UnityEngine.Random.Range(upSpeed, upSpeed + 15f);
		GetComponent<Rigidbody>().AddForce(fs, us, 0f);
	}

	private void OnDespawned()
	{
		timer = 0f;
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
	}

	private void OnSpawned()
	{
		timer = Time.time;
		fs = UnityEngine.Random.Range(0f - forwardSpeed, forwardSpeed);
		us = UnityEngine.Random.Range(upSpeed, upSpeed + 15f);
		GetComponent<Rigidbody>().AddForce(fs, us, 0f);
	}

	private void Update()
	{
		Transform transform = base.transform;
		Vector3 localPosition = base.transform.localPosition;
		float x = localPosition.x - 1000f;
		Vector3 localPosition2 = base.transform.localPosition;
		transform.LookAt(new Vector3(x, localPosition2.y, 0f));
		Transform transform2 = base.transform;
		Vector3 position = base.transform.position;
		float x2 = position.x;
		Vector3 position2 = base.transform.position;
		transform2.localPosition = new Vector3(x2, position2.y, 0f);
		if (Time.time == 0f)
		{
			return;
		}
		if (Time.time < timer + fallDelay)
		{
			GetComponent<Rigidbody>().AddForce(fs, us, 0f);
		}
		if (ground)
		{
			Vector3 position3 = base.transform.position;
			if ((double)position3.y <= 0.25)
			{
				GetComponent<Rigidbody>().isKinematic = true;
				Transform transform3 = base.transform;
				Vector3 position4 = base.transform.position;
				transform3.position = new Vector3(position4.x, 0.25f, 0f);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
