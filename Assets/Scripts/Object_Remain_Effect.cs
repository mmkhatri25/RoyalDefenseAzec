using UnityEngine;

public class Object_Remain_Effect : MonoBehaviour
{
	public string objectClip;

	public Vector3 size;

	public tk2dAnimatedSprite sprite;

	private Transform myTransform;

	private float delayDuration = 12f;

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
		RANDOM_rotate = UnityEngine.Random.Range(0.5f, 5f);
		sprite.transform.localPosition = new Vector3(UnityEngine.Random.Range(0.5f, 1f), 0f, 0f);
		sprite.color = new Color(0.6f, 0.6f, 0.6f, 1f);
		TIMER_delayDuration = Time.time + delayDuration;
	}

	private void DropFunction()
	{
		switch (dropFunctionState)
		{
		case 0:
			dropFunctionVelocityX = UnityEngine.Random.Range(-2, 2);
			dropFunctionVelocityY = UnityEngine.Random.Range(2, 6);
			dropFunctionState++;
			break;
		case 1:
			myTransform.Translate(myTransform.forward * dropFunctionVelocityX * Time.smoothDeltaTime, Space.World);
			if (dropFunctionVelocityY > -40f)
			{
				dropFunctionVelocityY -= 0.6f;
				myTransform.Translate(myTransform.up * dropFunctionVelocityY * Time.smoothDeltaTime, Space.World);
			}
			else if (dropFunctionVelocityY <= -40f)
			{
				dropFunctionVelocityY = -40f;
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
			sprite.Play(objectClip);
			sprite.scale = size;
			sprite.color = new Color(0.6f, 0.6f, 0.6f, 1f);
			state++;
			break;
		case 1:
		{
			Vector3 position5 = myTransform.position;
			if (position5.y <= 0.15f)
			{
				Transform transform2 = myTransform;
				Vector3 position6 = myTransform.position;
				transform2.position = new Vector3(position6.x, 0.15f, 0f);
				state++;
				break;
			}
			Vector3 position7 = myTransform.position;
			if (position7.y > 0.15f)
			{
				DropFunction();
				sprite.transform.Rotate(0f, 0f, RANDOM_rotate * Time.timeScale);
			}
			break;
		}
		case 2:
		{
			Vector3 position3 = myTransform.position;
			if (position3.y <= 0.15f)
			{
				Transform transform = myTransform;
				Vector3 position4 = myTransform.position;
				transform.position = new Vector3(position4.x, 0.15f, 0f);
			}
			if (delayDuration != 0f && Time.time >= TIMER_delayDuration)
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
			PoolManager.Pools["VFX Pool"].Despawn(base.transform);
			break;
		}
	}
}
