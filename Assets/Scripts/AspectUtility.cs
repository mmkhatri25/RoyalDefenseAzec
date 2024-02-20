using UnityEngine;

public class AspectUtility : MonoBehaviour
{
	private Camera myCamera;

	private void Awake()
	{
		if (Camera.main != null)
		{
			myCamera = Camera.main;
			if ((double)myCamera.aspect < 1.4)
			{
				myCamera.orthographicSize = 4f;
			}
			else
			{
				myCamera.orthographicSize = 3f;
			}
		}
	}

	private void OnLevelWasLoaded()
	{
		if (Camera.main != null)
		{
			myCamera = Camera.main;
			if ((double)myCamera.aspect < 1.4)
			{
				myCamera.orthographicSize = 4f;
			}
			else
			{
				myCamera.orthographicSize = 3f;
			}
		}
	}
}
