using UnityEngine;

public class SceneTextIcon : MonoBehaviour
{
	public int state;

	private int TOGGLE_state = -1;

	private tk2dAnimatedSprite sprite;

	private float bounceSpeed;

	private float upHeight;

	private Vector3 origVector;

	private Transform myTransform;

	private int TOGGLE_iconState;

	private float TIMER_iconState;

	private void Start()
	{
		myTransform = base.transform;
		sprite = GetComponent<tk2dAnimatedSprite>();
		origVector = base.transform.localPosition;
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			if (TOGGLE_state != state)
			{
				myTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				myTransform.localPosition = new Vector3(origVector.x, origVector.y, origVector.z);
				sprite.Play("blank");
				TOGGLE_state = state;
			}
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				TOGGLE_iconState = 0;
				TIMER_iconState = Time.time + 1f;
				myTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				myTransform.localPosition = new Vector3(origVector.x, origVector.y, origVector.z);
				sprite.Play("textIcon_0");
				TOGGLE_state = state;
			}
			switch (TOGGLE_iconState)
			{
			case 0:
				bounceSpeed = 1f;
				TOGGLE_iconState++;
				break;
			case 1:
			{
				if (bounceSpeed > 0.05f)
				{
					bounceSpeed -= 0.05f;
				}
				Vector3 localPosition3 = myTransform.localPosition;
				if (localPosition3.y < origVector.y + 0.1f)
				{
					myTransform.Translate(myTransform.up * bounceSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition4 = myTransform.localPosition;
				if (localPosition4.y >= origVector.y + 0.1f)
				{
					myTransform.localPosition = new Vector3(origVector.x, origVector.y + 0.1f, origVector.z);
					TOGGLE_iconState++;
				}
				break;
			}
			case 2:
				bounceSpeed = 0f;
				TOGGLE_iconState++;
				break;
			case 3:
			{
				if (bounceSpeed < 1f)
				{
					bounceSpeed += 0.05f;
				}
				Vector3 localPosition = myTransform.localPosition;
				if (localPosition.y > origVector.y)
				{
					myTransform.Translate(-myTransform.up * bounceSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition2 = myTransform.localPosition;
				if (localPosition2.y <= origVector.y)
				{
					myTransform.localPosition = new Vector3(origVector.x, origVector.y, origVector.z);
					TOGGLE_iconState = 0;
				}
				break;
			}
			}
			break;
		case 2:
			if (TOGGLE_state != state)
			{
				TOGGLE_iconState = 0;
				TIMER_iconState = Time.time + 0.5f;
				myTransform.localPosition = new Vector3(origVector.x, origVector.y, origVector.z);
				myTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				sprite.Play("textIcon_1");
				TOGGLE_state = state;
			}
			switch (TOGGLE_iconState)
			{
			case 0:
				if (Time.time >= TIMER_iconState)
				{
					TOGGLE_iconState++;
				}
				break;
			case 1:
			{
				Quaternion localRotation3 = myTransform.localRotation;
				if (localRotation3.z < 1f)
				{
					myTransform.Rotate(0f, 0f, 4f);
					break;
				}
				Quaternion localRotation4 = myTransform.localRotation;
				if (localRotation4.z >= 1f)
				{
					myTransform.localRotation = Quaternion.Euler(0f, 0f, 180f);
					TIMER_iconState = Time.time + 0.5f;
					TOGGLE_iconState++;
				}
				break;
			}
			case 2:
				if (Time.time >= TIMER_iconState)
				{
					TOGGLE_iconState++;
				}
				break;
			case 3:
			{
				Quaternion localRotation = myTransform.localRotation;
				if (localRotation.z > 0f)
				{
					myTransform.Rotate(0f, 0f, 4f);
					break;
				}
				Quaternion localRotation2 = myTransform.localRotation;
				if (localRotation2.z <= 0f)
				{
					myTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
					TIMER_iconState = Time.time + 0.5f;
					TOGGLE_iconState = 0;
				}
				break;
			}
			}
			break;
		}
	}
}
