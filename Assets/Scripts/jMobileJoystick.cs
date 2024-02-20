using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("")]
[RequireComponent(typeof(Image))]
public class jMobileJoystick : MonoBehaviour
{
	protected class Boundary
	{
		public Vector2 min = Vector2.zero;

		public Vector2 max = Vector2.zero;
	}

	private static jMobileJoystick[] joysticks;

	private static bool enumeratedJoysticks;

	private static float tapTimeDelta = 0.3f;

	public bool touchPad;

	public Rect touchZone;

	public Vector2 deadZone = Vector2.zero;

	public bool normalize;

	public Vector2 position;

	public int tapCount;

	private int lastFingerId = -1;

	private float tapTimeWindow;

	private Vector2 fingerDownPos;

	private Image gui;

	private Rect defaultRect;

	private Boundary guiBoundary = new Boundary();

	private Vector2 guiTouchOffset;

	private Vector2 guiCenter;

	private void Start()
	{
		if (Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.Android)
		{
			Disable();
			return;
		}
		gui = GetComponent<Image>();
	//	defaultRect = gui.pixelInset;
		ref Rect reference = ref defaultRect;
		float x = reference.x;
		Vector3 vector = base.transform.position;
		reference.x = x + vector.x * (float)Screen.width;
		ref Rect reference2 = ref defaultRect;
		float y = reference2.y;
		Vector3 vector2 = base.transform.position;
		reference2.y = y + vector2.y * (float)Screen.height;
		base.transform.position = new Vector3(0f, 0f, 0f);
		if (touchPad)
		{
			if ((bool)gui.sprite)
			{
				touchZone = defaultRect;
			}
			return;
		}
		guiTouchOffset.x = defaultRect.width * 0.5f;
		guiTouchOffset.y = defaultRect.height * 0.5f;
		guiCenter.x = defaultRect.x + guiTouchOffset.x;
		guiCenter.y = defaultRect.y + guiTouchOffset.y;
		guiBoundary.min.x = defaultRect.x - guiTouchOffset.x;
		guiBoundary.max.x = defaultRect.x + guiTouchOffset.x;
		guiBoundary.min.y = defaultRect.y - guiTouchOffset.y;
		guiBoundary.max.y = defaultRect.y + guiTouchOffset.y;
	}

	private void Disable()
	{
		base.gameObject.SetActive(value: false);
		enumeratedJoysticks = false;
	}

	private void ResetJoystick()
	{
		//gui.pixelInset = defaultRect;
		lastFingerId = -1;
		position = Vector2.zero;
		fingerDownPos = Vector2.zero;
		if (touchPad)
		{
			Image Image = gui;
			Color color = gui.color;
			float r = color.r;
			Color color2 = gui.color;
			float g = color2.g;
			Color color3 = gui.color;
			Image.color = new Color(r, g, color3.b, 0.025f);
		}
	}

	private bool IsFingerDown()
	{
		return lastFingerId != -1;
	}

	private void LatchedFinger(int fingerId)
	{
		if (lastFingerId == fingerId)
		{
			ResetJoystick();
		}
	}

	private void Update()
	{
		if (!enumeratedJoysticks)
		{
			joysticks = (UnityEngine.Object.FindObjectsOfType(typeof(jMobileJoystick)) as jMobileJoystick[]);
			enumeratedJoysticks = true;
		}
		int touchCount = UnityEngine.Input.touchCount;
		if (tapTimeWindow > 0f)
		{
			tapTimeWindow -= Time.deltaTime;
		}
		else
		{
			tapCount = 0;
		}
		if (touchCount == 0)
		{
			ResetJoystick();
		}
		else
		{
			for (int i = 0; i < touchCount; i++)
			{
				Touch touch = UnityEngine.Input.GetTouch(i);
				Vector2 vector = touch.position - guiTouchOffset;
				bool flag = false;
				if (touchPad)
				{
					if (touchZone.Contains(touch.position))
					{
						flag = true;
					}
				}
				//else if (gui.HitTest(touch.position))
				//{
				//	flag = true;
				//}
				if (flag && (lastFingerId == -1 || lastFingerId != touch.fingerId))
				{
					if (touchPad)
					{
						Image Image = gui;
						Color color = gui.color;
						float r = color.r;
						Color color2 = gui.color;
						float g = color2.g;
						Color color3 = gui.color;
						Image.color = new Color(r, g, color3.b, 0.15f);
						lastFingerId = touch.fingerId;
						fingerDownPos = touch.position;
					}
					lastFingerId = touch.fingerId;
					if (tapTimeWindow > 0f)
					{
						tapCount++;
					}
					else
					{
						tapCount = 1;
						tapTimeWindow = tapTimeDelta;
					}
					jMobileJoystick[] array = joysticks;
					foreach (jMobileJoystick jMobileJoystick in array)
					{
						if (jMobileJoystick != this)
						{
							jMobileJoystick.LatchedFinger(touch.fingerId);
						}
					}
				}
				if (lastFingerId == touch.fingerId)
				{
					if (touch.tapCount > tapCount)
					{
						tapCount = touch.tapCount;
					}
					if (touchPad)
					{
						ref Vector2 reference = ref position;
						Vector2 vector2 = touch.position;
						reference.x = Mathf.Clamp((vector2.x - fingerDownPos.x) / (touchZone.width / 2f), -1f, 1f);
						ref Vector2 reference2 = ref position;
						Vector2 vector3 = touch.position;
						reference2.y = Mathf.Clamp((vector3.y - fingerDownPos.y) / (touchZone.height / 2f), -1f, 1f);
					}
					else
					{
						//gui.pixelInset = new Rect(Mathf.Clamp(vector.x, guiBoundary.min.x, guiBoundary.max.x), Mathf.Clamp(vector.y, guiBoundary.min.y, guiBoundary.max.y), gui.pixelInset.width, gui.pixelInset.height);
					}
					if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
					{
						ResetJoystick();
					}
				}
			}
		}
		if (!touchPad)
		{
			//position.x = (gui.pixelInset.x + guiTouchOffset.x - guiCenter.x) / guiTouchOffset.x;
			//position.y = (gui.pixelInset.y + guiTouchOffset.y - guiCenter.y) / guiTouchOffset.y;
		}
		float num = Mathf.Abs(position.x);
		float num2 = Mathf.Abs(position.y);
		if (num < deadZone.x)
		{
			position.x = 0f;
		}
		else if (normalize)
		{
			position.x = Mathf.Sign(position.x) * (num - deadZone.x) / (1f - deadZone.x);
		}
		if (num2 < deadZone.y)
		{
			position.y = 0f;
		}
		else if (normalize)
		{
			position.y = Mathf.Sign(position.y) * (num2 - deadZone.y) / (1f - deadZone.y);
		}
	}
}
