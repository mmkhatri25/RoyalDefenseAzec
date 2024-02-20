using System;
using System.Collections;
using UnityEngine;

public class LoadTransition : MonoBehaviour
{
	public int transitionNumber = 1;

	public string SceneName;

	private float LoadDelay;

	private float LoadCompleteDelay = 0.5f;

	private IEnumerator Start()
	{
		Resources.UnloadUnusedAssets();
		yield return new WaitForSeconds(LoadDelay);
		yield return new WaitForSeconds(LoadCompleteDelay);
		GC.Collect();
		UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
	}

	private void Update()
	{
		if (Time.timeScale != 1f)
		{
			Time.timeScale = 1f;
		}
	}
}
