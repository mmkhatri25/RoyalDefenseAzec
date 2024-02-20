using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("2D Toolkit/Camera/tk2dCameraAnchor")]
public class tk2dCameraAnchor : MonoBehaviour
{
	public enum Anchor
	{
		UpperLeft,
		UpperCenter,
		UpperRight,
		MiddleLeft,
		MiddleCenter,
		MiddleRight,
		LowerLeft,
		LowerCenter,
		LowerRight
	}

	public Anchor anchor;

	public Vector2 offset = Vector2.zero;

	public tk2dCamera tk2dCamera;

	public Camera mainCamera;

	private Transform _transform;

	private void Awake()
	{
		_transform = base.transform;
	}

	private void Start()
	{
		UpdateTransform();
	}

	private void UpdateTransform()
	{
		if (tk2dCamera != null && mainCamera != null)
		{
			Vector3 localPosition = _transform.localPosition;
			Vector3 a = Vector3.zero;
			switch (anchor)
			{
			case Anchor.UpperLeft:
				a = new Vector3(0f, tk2dCamera.resolution.y, localPosition.z);
				break;
			case Anchor.UpperCenter:
				a = new Vector3(tk2dCamera.resolution.x / 2f, tk2dCamera.resolution.y, localPosition.z);
				break;
			case Anchor.UpperRight:
				a = new Vector3(tk2dCamera.resolution.x, tk2dCamera.resolution.y, localPosition.z);
				break;
			case Anchor.MiddleLeft:
				a = new Vector3(0f, tk2dCamera.resolution.y / 2f, localPosition.z);
				break;
			case Anchor.MiddleCenter:
				a = new Vector3(tk2dCamera.resolution.x / 2f, tk2dCamera.resolution.y / 2f, localPosition.z);
				break;
			case Anchor.MiddleRight:
				a = new Vector3(tk2dCamera.resolution.x, tk2dCamera.resolution.y / 2f, localPosition.z);
				break;
			case Anchor.LowerLeft:
				a = new Vector3(0f, 0f, localPosition.z);
				break;
			case Anchor.LowerCenter:
				a = new Vector3(tk2dCamera.resolution.x / 2f, 0f, localPosition.z);
				break;
			case Anchor.LowerRight:
				a = new Vector3(tk2dCamera.resolution.x, 0f, localPosition.z);
				break;
			}
			_transform.localPosition = a + new Vector3(offset.x, offset.y, 0f);
		}
	}

	private void Update()
	{
		UpdateTransform();
	}
}
