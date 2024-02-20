using UnityEngine;

public class Object_Aimer : MonoBehaviour
{
	private Vector3 MousePos;

	public bool SetAim;

	public float SetAimDirection = -1000f;

	private Transform myTransform;

	private void Start()
	{
		myTransform = base.transform;
	}

	private void OnSpawned()
	{
		MousePos = new Vector3(0f, 90f, 0f);
	}

	private void Update()
	{
		if (SetAim)
		{
			myTransform.localRotation = Quaternion.Euler(SetAimDirection, 0f, 0f);
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			UnityEngine.Debug.DrawLine(ray.origin, hitInfo.point);
			Vector3 point = hitInfo.point;
			float x = point.x;
			Vector3 point2 = hitInfo.point;
			MousePos = new Vector3(x, point2.y, 0f);
			myTransform.LookAt(MousePos);
		}
	}
}
