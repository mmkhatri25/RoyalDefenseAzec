using UnityEngine;

public class Menu_Description : MonoBehaviour
{
	public int biographyType;

	public int state;

	private int TOGGLE_state;

	private float scrollSpeed = 0.08f;

	public GameObject descriptionObject;

	public float descriptionLength = 1f;

	public GameObject philosophyObject;

	public float philosophyLength = 1f;

	public MenuTransition menuTransition;

	private Transform myTransform;

	private float TIMER_mouse;

	private float TIMER_delay;

	private float startSpace = -1f;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void LateUpdate()
	{
		if (biographyType == 1)
		{
			if (TOGGLE_state != state)
			{
				Transform transform = myTransform;
				Vector3 position = myTransform.position;
				float x = position.x;
				Vector3 position2 = myTransform.position;
				transform.position = new Vector3(x, -11f, position2.z);
				descriptionObject.transform.localPosition = new Vector3(1.58f, 0f, 0f);
				philosophyObject.transform.localPosition = new Vector3(0f, 0f - descriptionLength, 0f);
				TIMER_delay = Time.time + 1f;
				TOGGLE_state = state;
				return;
			}
			if (Input.GetMouseButton(0))
			{
				if (scrollSpeed < 0.09f)
				{
					TIMER_mouse = Time.time;
					scrollSpeed = 0.09f;
				}
				else if (scrollSpeed >= 0.09f && Time.time >= TIMER_mouse + 0.2f)
				{
					scrollSpeed = 0.8f;
				}
			}
			else if (scrollSpeed != 0.08f)
			{
				scrollSpeed = 0.08f;
			}
			Vector3 position3 = myTransform.position;
			if (position3.y < startSpace)
			{
				if (Time.time >= TIMER_delay)
				{
					Transform transform2 = myTransform;
					Vector3 position4 = myTransform.position;
					float x2 = position4.x;
					float y = startSpace + 0.1f;
					Vector3 position5 = myTransform.position;
					transform2.position = new Vector3(x2, y, position5.z);
				}
			}
			else
			{
				if (!(Time.time >= TIMER_delay))
				{
					return;
				}
				Vector3 position6 = myTransform.position;
				if (!(position6.y >= startSpace))
				{
					return;
				}
				Vector3 position7 = myTransform.position;
				if (position7.y < startSpace + descriptionLength + philosophyLength + 6f)
				{
					myTransform.Translate(myTransform.up * scrollSpeed * Time.deltaTime, Space.World);
					return;
				}
				Vector3 position8 = myTransform.position;
				if (position8.y >= startSpace + descriptionLength + philosophyLength + 6f)
				{
					Transform transform3 = myTransform;
					Vector3 position9 = myTransform.position;
					float x3 = position9.x;
					float y2 = startSpace;
					Vector3 position10 = myTransform.position;
					transform3.position = new Vector3(x3, y2, position10.z);
				}
			}
		}
		else if (biographyType == 0 && TOGGLE_state != state)
		{
			Transform transform4 = myTransform;
			Vector3 position11 = myTransform.position;
			float x4 = position11.x;
			Vector3 position12 = myTransform.position;
			transform4.position = new Vector3(x4, -100f, position12.z);
			descriptionObject.transform.localPosition = new Vector3(1.58f, 0f, 0f);
			philosophyObject.transform.localPosition = new Vector3(0f, 0f - descriptionLength, 0f);
			TOGGLE_state = state;
		}
	}
}
