using UnityEngine;

[AddComponentMenu("")]
public class jMouseLook : MonoBehaviour
{
	public float sensitivityY = 5f;

	public jMobileJoystick rightJoystick;

	private float rotationY;

	private bool desktopPlatform;

	private void Start()
	{
		desktopPlatform = (Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.Android);
	}

	private void Update()
	{
		float num = (!desktopPlatform) ? ((0f - rightJoystick.position.y) * sensitivityY) : ((0f - UnityEngine.Input.GetAxis("Mouse Y")) * sensitivityY);
		float num2 = rotationY;
		Vector3 localEulerAngles = base.transform.localEulerAngles;
		rotationY = localEulerAngles.x + num;
		if (num2 <= 60f && num > 0f)
		{
			if (rotationY > 60f)
			{
				rotationY = 60f;
			}
		}
		else if (num2 <= 60f && num < 0f)
		{
			if (rotationY < 0f)
			{
				rotationY += 360f;
				if (rotationY < 300f)
				{
					rotationY = 300f;
				}
			}
		}
		else if (num2 >= 300f && num < 0f)
		{
			if (rotationY < 300f)
			{
				rotationY = 300f;
			}
		}
		else if (num2 >= 300f && num > 0f && rotationY > 360f)
		{
			rotationY -= 360f;
			if (rotationY > 60f)
			{
				rotationY = 60f;
			}
		}
		Transform transform = base.transform;
		float x = rotationY;
		Vector3 localEulerAngles2 = base.transform.localEulerAngles;
		transform.localEulerAngles = new Vector3(x, localEulerAngles2.y, 0f);
	}
}
