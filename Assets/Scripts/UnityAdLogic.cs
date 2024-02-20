using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdLogic : MonoBehaviour
{
	public bool enableAD;

	public string sceneName;

	private string UnityAdID = "1607413";

	private float timerMinute = 2f;

	public int state;

	private string adVideoID;

	private float CheckTimer;

	private TimerSystem ADTimer;

	private float showTimer;

	private void Awake()
	{
		ADTimer = GetComponent<TimerSystem>();
	}

	private void Start()
	{
		ADTimer.SetTime(0f, 1f, 0f);
		state = 0;
	}

	private void OnLevelWasLoaded()
	{
		if (enableAD)
		{
			if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Load - Game" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Load - Menu" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Load - Game Reload")
			{
				ADTimer.CheckTime();
				if (ADTimer.timerEnd)
				{
					//if (Advertisement.IsReady("defaultZone"))
					//{
					//	adVideoID = "defaultZone";
					//	sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
					//	UnityEngine.SceneManagement.SceneManager.LoadScene("AD");
					//}
					///else if (Advertisement.IsReady("rewardedVideoZone"))
				//	{
					//	adVideoID = "rewardedVideoZone";
					//	sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
					//	UnityEngine.SceneManagement.SceneManager.LoadScene("AD");
					//}
				}
			}
			else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "AD")
			{
				ShowAd();
				showTimer = Time.time + 5f;
				state = 1;
			}
		}
		else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game")
		{
			enableAD = true;
		}
	}

	private void LateUpdate()
	{
		if (state == 0)
		{
			return;
		}
		switch (state)
		{
		case 0:
			break;
		case -3:
			ADTimer.SetTime(0f, timerMinute, 0f);
			state = -2;
			break;
		case -2:
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
			state = -1;
			break;
		case -1:
			state = 0;
			break;
		case 1:
			if (Time.time >= showTimer)
			{
				state = -2;
			}
			break;
		case 2:
			state = -3;
			break;
		case 3:
			state = -3;
			break;
		case 4:
			ADTimer.SetTime(0f, 0f, 10f);
			state = -2;
			break;
		}
	}

	public void ShowAd()
	{
		//ShowOptions showOptions = new ShowOptions();
		//showOptions.resultCallback = AdCallbackhandler;
		//if (Advertisement.IsReady(adVideoID))
		//{
		//	Advertisement.Show(adVideoID, showOptions);
		//}
	}

	//private void AdCallbackhandler(ShowResult result)
	//{
	//	switch (result)
	//	{
	//	case ShowResult.Finished:
	//		UnityEngine.Debug.Log("Ad Finished");
	//		state = 2;
	//		break;
	//	case ShowResult.Skipped:
	//		UnityEngine.Debug.Log("Ad skipped");
	//		state = 3;
	//		break;
	//	case ShowResult.Failed:
	//		UnityEngine.Debug.Log("Ad Failed");
	//		state = 4;
	//		break;
	//	}
	//}

	private IEnumerator WaitForAd()
	{
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;
		//while (Advertisement.isShowing)
		//{
		//	yield return null;
		//}
		Time.timeScale = currentTimeScale;
	}
}
