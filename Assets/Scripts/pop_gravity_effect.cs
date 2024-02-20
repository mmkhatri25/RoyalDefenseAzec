using UnityEngine;

public class pop_gravity_effect : MonoBehaviour
{
	public string despawnPool;

	public float mass = 1f;

	public float popUpVelocityMin;

	public float popUpVelocityMax;

	public float popSideVelocityMin;

	public float popSideVelocityMax;

	public GameObject rotatingObject;

	public float popRotationVelocityMin;

	public float popRotationVelocityMax;

	public bool detectGround;

	public float groundDuration = 12f;

	private Transform myTransform;

	private float TIMER_delayDuration;

	private float TIMER_rigid;

	private float RANDOM_rotate;

	private int dropFunctionState;

	private float dropFunctionVelocityX;

	private float dropFunctionVelocityY;

	private int state;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void OnSpawned()
	{
		state = 0;
		dropFunctionState = 0;
		RANDOM_rotate = UnityEngine.Random.Range(popRotationVelocityMin, popRotationVelocityMax);
		TIMER_delayDuration = Time.time + groundDuration;
	}

	private void DropFunction()
	{
		switch (dropFunctionState)
		{
		case 0:
			dropFunctionVelocityX = UnityEngine.Random.Range(popSideVelocityMin, popSideVelocityMax);
			dropFunctionVelocityY = UnityEngine.Random.Range(popUpVelocityMin, popUpVelocityMax);
			dropFunctionState++;
			break;
		case 1:
			myTransform.Translate(myTransform.forward * dropFunctionVelocityX * Time.smoothDeltaTime, Space.World);
			if (dropFunctionVelocityY > 0f - mass)
			{
				dropFunctionVelocityY -= mass * 0.015f;
				myTransform.Translate(myTransform.up * dropFunctionVelocityY * Time.smoothDeltaTime, Space.World);
			}
			else if (dropFunctionVelocityY <= 0f - mass)
			{
				dropFunctionVelocityY = 0f - mass;
				myTransform.Translate(myTransform.up * dropFunctionVelocityY * Time.smoothDeltaTime, Space.World);
			}
			break;
		}
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			state++;
			break;
		case 1:
			if (rotatingObject != null)
			{
				rotatingObject.transform.Rotate(0f, 0f, RANDOM_rotate * Time.timeScale);
			}
			if (detectGround)
			{
				Vector3 position5 = myTransform.position;
				if (position5.y <= 0.15f)
				{
					Transform transform2 = myTransform;
					Vector3 position6 = myTransform.position;
					transform2.position = new Vector3(position6.x, 0.15f, 0f);
					state++;
				}
				else
				{
					Vector3 position7 = myTransform.position;
					if (position7.y > 0.15f)
					{
						DropFunction();
					}
				}
			}
			else
			{
				DropFunction();
				Vector3 position8 = myTransform.position;
				if (position8.y <= -2f)
				{
					state = 4;
				}
			}
			break;
		case 2:
		{
			Vector3 position3 = myTransform.position;
			if (position3.y <= 0.15f)
			{
				Transform transform = myTransform;
				Vector3 position4 = myTransform.position;
				transform.position = new Vector3(position4.x, 0.15f, 0f);
			}
			if (groundDuration != 0f && Time.time >= TIMER_delayDuration)
			{
				state++;
			}
			break;
		}
		case 3:
		{
			Vector3 position = myTransform.position;
			if (position.y > -2f)
			{
				myTransform.Translate(-myTransform.up * 0.2f * Time.smoothDeltaTime, Space.World);
				break;
			}
			Vector3 position2 = myTransform.position;
			if (position2.y <= -2f)
			{
				state++;
			}
			break;
		}
		case 4:
			PoolManager.Pools[despawnPool].Despawn(base.transform);
			break;
		}
	}
}
