using UnityEngine;

public class StartGameLoad : MonoBehaviour
{
	public string loadScene;

	public GameObject[] loadObject;

	public float loadDelay;

	private float TIMER_loadDelay;

	private int loadNumber;

	private int loadLength;

	private void Start()
	{
		loadLength = loadObject.Length;
		loadNumber = 0;
		TIMER_loadDelay = Time.time;
	}

	private void Update()
	{
		if (loadNumber < loadLength)
		{
			if (Time.time >= TIMER_loadDelay + loadDelay)
			{
				Object.Instantiate(loadObject[loadNumber], Vector3.zero, Quaternion.identity);
				loadNumber++;
				TIMER_loadDelay = Time.time;
			}
		}
		else if (loadNumber >= loadLength && Time.time >= TIMER_loadDelay + loadDelay && loadScene != string.Empty)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(loadScene);
		}
	}
}
