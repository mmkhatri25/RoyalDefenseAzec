using UnityEngine;

public class MoveTo_ThenBack : MonoBehaviour
{
	private Vector3 backPosition;

	private Vector3 movePosition;

	public float moveX;

	public float moveY;

	public float moveSpeed;

	public float returnSpeed;

	public float delay;

	private Transform myTransform;

	public int state;

	private int Xstate;

	private int Ystate;

	private float TIMER_delay;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		backPosition = base.transform.localPosition;
		movePosition = new Vector3(backPosition.x + moveX, backPosition.y + moveY, backPosition.z + moveX);
	}

	private void OnSpawned()
	{
		state = 0;
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		switch (state)
		{
		case 0:
			if (backPosition.x > movePosition.x)
			{
				Xstate = 1;
			}
			else if (backPosition.x < movePosition.x)
			{
				Xstate = 2;
			}
			if (backPosition.y > movePosition.y)
			{
				Ystate = 1;
			}
			else if (backPosition.y < movePosition.y)
			{
				Ystate = 2;
			}
			myTransform.localPosition = backPosition;
			TIMER_delay = Time.time + delay;
			state++;
			break;
		case 1:
			switch (Xstate)
			{
			case 1:
			{
				Vector3 localPosition21 = myTransform.localPosition;
				if (localPosition21.x > movePosition.x)
				{
					myTransform.Translate(-myTransform.right * moveSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition22 = myTransform.localPosition;
				if (localPosition22.x <= movePosition.x)
				{
					Transform transform6 = myTransform;
					float x6 = movePosition.x;
					Vector3 localPosition23 = myTransform.localPosition;
					float y6 = localPosition23.y;
					Vector3 localPosition24 = myTransform.localPosition;
					transform6.localPosition = new Vector3(x6, y6, localPosition24.z);
					Xstate = -1;
				}
				break;
			}
			case 2:
			{
				Vector3 localPosition17 = myTransform.localPosition;
				if (localPosition17.x < movePosition.x)
				{
					myTransform.Translate(myTransform.right * moveSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition18 = myTransform.localPosition;
				if (localPosition18.x >= movePosition.x)
				{
					Transform transform5 = myTransform;
					float x5 = movePosition.x;
					Vector3 localPosition19 = myTransform.localPosition;
					float y5 = localPosition19.y;
					Vector3 localPosition20 = myTransform.localPosition;
					transform5.localPosition = new Vector3(x5, y5, localPosition20.z);
					Xstate = -2;
				}
				break;
			}
			}
			switch (Ystate)
			{
			case 1:
			{
				Vector3 localPosition29 = myTransform.localPosition;
				if (localPosition29.y > movePosition.y)
				{
					myTransform.Translate(-myTransform.up * moveSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition30 = myTransform.localPosition;
				if (localPosition30.y <= movePosition.y)
				{
					Transform transform8 = myTransform;
					Vector3 localPosition31 = myTransform.localPosition;
					float x8 = localPosition31.x;
					float y8 = movePosition.y;
					Vector3 localPosition32 = myTransform.localPosition;
					transform8.localPosition = new Vector3(x8, y8, localPosition32.z);
					Ystate = -1;
				}
				break;
			}
			case 2:
			{
				Vector3 localPosition25 = myTransform.localPosition;
				if (localPosition25.y < movePosition.y)
				{
					myTransform.Translate(myTransform.up * moveSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition26 = myTransform.localPosition;
				if (localPosition26.y >= movePosition.y)
				{
					Transform transform7 = myTransform;
					Vector3 localPosition27 = myTransform.localPosition;
					float x7 = localPosition27.x;
					float y7 = movePosition.y;
					Vector3 localPosition28 = myTransform.localPosition;
					transform7.localPosition = new Vector3(x7, y7, localPosition28.z);
					Ystate = -2;
				}
				break;
			}
			}
			if (Xstate <= 0 && Ystate <= 0)
			{
				state++;
			}
			break;
		case 2:
			if (delay != -1f && Time.time >= TIMER_delay)
			{
				state++;
			}
			break;
		case 3:
			switch (Xstate)
			{
			case -2:
			{
				Vector3 localPosition5 = myTransform.localPosition;
				if (localPosition5.x > backPosition.x)
				{
					myTransform.Translate(-myTransform.right * returnSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition6 = myTransform.localPosition;
				if (localPosition6.x <= backPosition.x)
				{
					Transform transform2 = myTransform;
					float x2 = backPosition.x;
					Vector3 localPosition7 = myTransform.localPosition;
					float y2 = localPosition7.y;
					Vector3 localPosition8 = myTransform.localPosition;
					transform2.localPosition = new Vector3(x2, y2, localPosition8.z);
					Xstate = 0;
				}
				break;
			}
			case -1:
			{
				Vector3 localPosition = myTransform.localPosition;
				if (localPosition.x < backPosition.x)
				{
					myTransform.Translate(myTransform.right * returnSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition2 = myTransform.localPosition;
				if (localPosition2.x >= backPosition.x)
				{
					Transform transform = myTransform;
					float x = backPosition.x;
					Vector3 localPosition3 = myTransform.localPosition;
					float y = localPosition3.y;
					Vector3 localPosition4 = myTransform.localPosition;
					transform.localPosition = new Vector3(x, y, localPosition4.z);
					Xstate = 0;
				}
				break;
			}
			}
			switch (Ystate)
			{
			case -2:
			{
				Vector3 localPosition13 = myTransform.localPosition;
				if (localPosition13.y > backPosition.y)
				{
					myTransform.Translate(-myTransform.up * returnSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition14 = myTransform.localPosition;
				if (localPosition14.x <= backPosition.y)
				{
					Transform transform4 = myTransform;
					Vector3 localPosition15 = myTransform.localPosition;
					float x4 = localPosition15.x;
					float y4 = backPosition.y;
					Vector3 localPosition16 = myTransform.localPosition;
					transform4.localPosition = new Vector3(x4, y4, localPosition16.z);
					Ystate = 0;
				}
				break;
			}
			case -1:
			{
				Vector3 localPosition9 = myTransform.localPosition;
				if (localPosition9.y < backPosition.y)
				{
					myTransform.Translate(myTransform.up * returnSpeed * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition10 = myTransform.localPosition;
				if (localPosition10.x >= backPosition.y)
				{
					Transform transform3 = myTransform;
					Vector3 localPosition11 = myTransform.localPosition;
					float x3 = localPosition11.x;
					float y3 = backPosition.y;
					Vector3 localPosition12 = myTransform.localPosition;
					transform3.localPosition = new Vector3(x3, y3, localPosition12.z);
					Ystate = 0;
				}
				break;
			}
			}
			if (Xstate == 0 && Ystate == 0)
			{
				state++;
			}
			break;
		}
	}
}
