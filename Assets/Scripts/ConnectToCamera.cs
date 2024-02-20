using UnityEngine;

public class ConnectToCamera : MonoBehaviour
{
	public GameObject currentCamera;

	private Transform myTransform;

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.transform.gameObject);
		myTransform = base.transform;
		if (myTransform.parent == null)
		{
			currentCamera = Camera.main.gameObject;
			myTransform.parent = currentCamera.transform;
		}
	}

	private void Update()
	{
		if (myTransform.parent == null)
		{
			currentCamera = Camera.main.gameObject;
			myTransform.parent = currentCamera.transform;
		}
		Vector3 localPosition = myTransform.localPosition;
		if (localPosition.x != 0f)
		{
			Transform transform = myTransform;
			Vector3 position = myTransform.position;
			transform.localPosition = new Vector3(0f, 0f, position.z);
		}
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 4)
		{
			Vector3 localScale = myTransform.localScale;
			if (localScale.x != 1.25f)
			{
				myTransform.localScale = new Vector3(1.25f, 1.25f, 1f);
			}
		}
		else
		{
			Vector3 localScale2 = myTransform.localScale;
			if (localScale2.x != 1f)
			{
				myTransform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
	}
}
