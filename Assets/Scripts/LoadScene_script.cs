using System;
using System.Collections;
using UnityEngine;

public class LoadScene_script : MonoBehaviour
{
	public int loadType;

	public string SceneName;

	private float LoadDelay = 1f;

	private IEnumerator Start()
	{
		Resources.UnloadUnusedAssets();
		yield return new WaitForSeconds(LoadDelay);
		GC.Collect();
		if (loadType == 0)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
		}
		else
		{
			AutoFade.LoadLevel(SceneName, 1f, 1.5f, Color.black);
		}
	}

	private void Update()
	{
		if (Time.timeScale != 1f)
		{
			Time.timeScale = 1f;
		}
	}
}
