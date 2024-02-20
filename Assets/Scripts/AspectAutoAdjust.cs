using UnityEngine;

public class AspectAutoAdjust : MonoBehaviour
{
	private float currentWindowAspect;

	private int TOGGLE_checkScene;

	private void Awake()
	{
		currentWindowAspect = (float)Screen.width / (float)Screen.height;
		if (currentWindowAspect >= 1.4f)
		{
			UnityEngine.Object.Destroy(GetComponent<AspectAutoAdjust>());
		}
	}

	private void Update()
	{
		if (TOGGLE_checkScene != UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex && Camera.main != null)
		{
			Camera.main.orthographicSize += 0.6f;
			TOGGLE_checkScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
		}
	}
}
