using UnityEngine;

public class Unit_VectorColliderToggle : MonoBehaviour
{
	public float xVectorMinimum;

	public float xVectorMaximum;

	public float yVectorMinimum;

	public float yVectorMaximum;

	private int state;

	private Transform myTransform;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void OnSpawned()
	{
		if (yVectorMinimum != 0f || yVectorMaximum != 0f || xVectorMinimum != 0f || xVectorMaximum != 0f)
		{
			if (xVectorMinimum != 0f && xVectorMaximum != 0f)
			{
				state = 1;
			}
			else if (yVectorMinimum != 0f && yVectorMaximum != 0f)
			{
				state = 2;
			}
			else if (yVectorMinimum != 0f && yVectorMinimum != 0f && xVectorMinimum != 0f && xVectorMaximum != 0f)
			{
				state = 3;
			}
		}
		else if (yVectorMinimum == 0f && yVectorMinimum == 0f && xVectorMinimum == 0f && xVectorMaximum == 0f)
		{
			state = 0;
		}
	}

	private void Update()
	{
		switch (state)
		{
		case 1:
		{
			Vector3 position13 = myTransform.position;
			if (position13.x > xVectorMinimum)
			{
				Vector3 position14 = myTransform.position;
				if (position14.x <= xVectorMaximum)
				{
					if (!GetComponent<Collider>().enabled)
					{
						GetComponent<Collider>().enabled = true;
					}
					break;
				}
			}
			Vector3 position15 = myTransform.position;
			if (!(position15.x < xVectorMinimum))
			{
				Vector3 position16 = myTransform.position;
				if (!(position16.x > xVectorMaximum))
				{
					break;
				}
			}
			if (GetComponent<Collider>().enabled)
			{
				GetComponent<Collider>().enabled = false;
			}
			break;
		}
		case 2:
		{
			Vector3 position9 = myTransform.position;
			if (position9.y > yVectorMinimum)
			{
				Vector3 position10 = myTransform.position;
				if (position10.y <= yVectorMaximum)
				{
					if (!GetComponent<Collider>().enabled)
					{
						GetComponent<Collider>().enabled = true;
					}
					break;
				}
			}
			Vector3 position11 = myTransform.position;
			if (!(position11.y < yVectorMinimum))
			{
				Vector3 position12 = myTransform.position;
				if (!(position12.y > yVectorMaximum))
				{
					break;
				}
			}
			if (GetComponent<Collider>().enabled)
			{
				GetComponent<Collider>().enabled = false;
			}
			break;
		}
		case 3:
		{
			Vector3 position = myTransform.position;
			if (position.x > xVectorMinimum)
			{
				Vector3 position2 = myTransform.position;
				if (position2.x <= xVectorMaximum)
				{
					Vector3 position3 = myTransform.position;
					if (position3.y > yVectorMinimum)
					{
						Vector3 position4 = myTransform.position;
						if (position4.y <= yVectorMaximum)
						{
							if (!GetComponent<Collider>().enabled)
							{
								GetComponent<Collider>().enabled = true;
							}
							break;
						}
					}
				}
			}
			Vector3 position5 = myTransform.position;
			if (!(position5.y < yVectorMinimum))
			{
				Vector3 position6 = myTransform.position;
				if (!(position6.y > yVectorMaximum))
				{
					Vector3 position7 = myTransform.position;
					if (!(position7.x < xVectorMinimum))
					{
						Vector3 position8 = myTransform.position;
						if (!(position8.x > xVectorMaximum))
						{
							break;
						}
					}
				}
			}
			if (GetComponent<Collider>().enabled)
			{
				GetComponent<Collider>().enabled = false;
			}
			break;
		}
		}
	}
}
