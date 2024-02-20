using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
	private static float load_fadeSpeed = 1.5f;

	private static float load_fadeSpeedIn = 1.5f;

	private static Color load_fadeColor;

	private static bool load_sceneEnding;

	private static string load_sceneName;

	private static float load_delayDuration;

	public Color fadeColor;

	private bool sceneStarting = true;

	private bool sceneEnding;

	private string sceneLoadName;

	//private Image myImage;

	private float fadeTIMER;

	private float fadeDelayTIMER;

	public static void LoadLevel(string aLevelName, float aFadeOutTime, float aFadeInTime, Color aColor)
	{
		if (aColor == Color.clear)
		{
			CameraScreenTransition.control.SceneTransition(2, aLevelName);
			return;
		}
		load_fadeSpeed = aFadeOutTime;
		load_fadeSpeedIn = 1f;
		load_fadeColor = aColor;
		load_sceneName = aLevelName;
		load_sceneEnding = true;
	}

	private void Awake()
	{
		Object.DontDestroyOnLoad(this);
		//myImage = GetComponent<Image>();
		//myImage.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	private void Update()
	{
		if (load_sceneEnding && !sceneEnding)
		{
			if (load_fadeSpeed >= 3f)
			{
				fadeDelayTIMER = Time.time + 1f;
			}
			else
			{
				fadeDelayTIMER = 0f;
			}
		//	myImage.enabled = true;
			//myImage.color = Color.clear;
			fadeColor = load_fadeColor;
			sceneLoadName = load_sceneName;
			fadeTIMER = Time.time + 2.4f;
			sceneEnding = true;
			load_sceneEnding = false;
		}
		if (sceneEnding)
		{
			EndScene(sceneLoadName);
		}
		if (sceneStarting)
		{
			StartScene();
		}
	}

	//private void FadeToClear()
	//{
		//myImage.color = Color.Lerp(myImage.color, Color.clear, 1f * Time.deltaTime);
	//}

	//private void FadeToBlack()
	//{
		//myImage.color = Color.Lerp(myImage.color, fadeColor, 1f * Time.deltaTime);
	//}

	private void StartScene()
	{
		//FadeToClear();
		//Color color = myImage.color;
		//if (color.a <= 0.05f)
		//{
			//myImage.color = Color.clear;
			//myImage.enabled = false;
			sceneStarting = false;
		//}
	}

	private void EndScene(string sceneName)
	{
		if (Time.timeScale != 1f)
		{
			Time.timeScale = 1f;
		}
		if (Time.time >= fadeDelayTIMER)
		{
			//FadeToBlack();
			//Color color = myImage.color;
			//if (color.a >= fadeColor.a - 0.05f && Time.time >= fadeTIMER)
			//{
				//myImage.color = fadeColor;
				UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
				sceneStarting = true;
				load_sceneEnding = false;
				sceneEnding = false;
			//}
		}
	}
}
