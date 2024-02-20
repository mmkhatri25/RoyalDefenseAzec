using UnityEngine;

public class TweenEffects : MonoBehaviour
{
	public int state;

	private int TOGGLE_state = -1;

	public float a;

	public float b;

	public float c;

	private Vector3 origVector;

	private Transform myTransform;

	private float bounceSpeed;

	private int TOGGLE_iconState;

	private float TIMER_iconState;

	private void Start()
	{
		myTransform = base.transform;
		origVector = base.transform.localPosition;
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			if (TOGGLE_state != state)
			{
				TOGGLE_iconState = 0;
				myTransform.localPosition = new Vector3(origVector.x, origVector.y, origVector.z);
				TOGGLE_state = state;
			}
			switch (TOGGLE_iconState)
			{
			case 0:
				bounceSpeed = a;
				TOGGLE_iconState++;
				break;
			case 1:
			{
				if (bounceSpeed > b)
				{
					bounceSpeed -= b;
				}
				Vector3 localPosition3 = myTransform.localPosition;
				if (localPosition3.y < origVector.y + c)
				{
					myTransform.Translate(myTransform.up * bounceSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition4 = myTransform.localPosition;
				if (localPosition4.y >= origVector.y + c)
				{
					myTransform.localPosition = new Vector3(origVector.x, origVector.y + c, origVector.z);
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
				if (bounceSpeed < a)
				{
					bounceSpeed += b;
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
		case 1:
			if (TOGGLE_state != state)
			{
				TOGGLE_iconState = 0;
				TIMER_iconState = Time.time + b;
				myTransform.localPosition = new Vector3(origVector.x, origVector.y, origVector.z);
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
				Quaternion localRotation7 = myTransform.localRotation;
				if (localRotation7.z < 1f)
				{
					myTransform.Rotate(0f, 0f, a);
					break;
				}
				Quaternion localRotation8 = myTransform.localRotation;
				if (localRotation8.z >= 1f)
				{
					myTransform.localRotation = Quaternion.Euler(0f, 0f, 180f);
					TIMER_iconState = Time.time + b;
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
				Quaternion localRotation5 = myTransform.localRotation;
				if (localRotation5.z > 0f)
				{
					myTransform.Rotate(0f, 0f, a);
					break;
				}
				Quaternion localRotation6 = myTransform.localRotation;
				if (localRotation6.z <= 0f)
				{
					myTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
					TIMER_iconState = Time.time + b;
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
				myTransform.localPosition = new Vector3(origVector.x, origVector.y, origVector.z);
				TOGGLE_state = state;
			}
			switch (TOGGLE_iconState)
			{
			case 0:
			{
				Quaternion localRotation3 = base.transform.localRotation;
				if (localRotation3.z > 0f - a)
				{
					base.transform.Rotate(0f, 0f, 0f - b);
					break;
				}
				Quaternion localRotation4 = base.transform.localRotation;
				if (localRotation4.z <= 0f - a)
				{
					TOGGLE_iconState = 1;
				}
				break;
			}
			case 1:
			{
				Quaternion localRotation = base.transform.localRotation;
				if (localRotation.z < a)
				{
					base.transform.Rotate(0f, 0f, b);
					break;
				}
				Quaternion localRotation2 = base.transform.localRotation;
				if (localRotation2.z >= a)
				{
					TOGGLE_iconState = 0;
				}
				break;
			}
			}
			break;
		}
	}
}
