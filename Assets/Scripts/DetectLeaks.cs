using System;
using UnityEngine;

public class DetectLeaks : MonoBehaviour
{
	private static DetectLeaks instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void OnGUI()
	{
		if (GUILayout.Button("Unload Unused Assets"))
		{
			Resources.UnloadUnusedAssets();
		}
		if (GUILayout.Button("Mono Garbage Collect"))
		{
			GC.Collect();
		}
		if (GUILayout.Button("List Loaded Textures"))
		{
			ListLoadedTextures();
		}
		if (GUILayout.Button("List Loaded Sounds"))
		{
			ListLoadedAudio();
		}
		if (GUILayout.Button("List Loaded GameObjects"))
		{
			ListLoadedGameObjects();
		}
	}

	private void ListLoadedTextures()
	{
		UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(Texture));
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i].name == string.Empty))
			{
				string text2 = text;
				text = text2 + i.ToString() + ". " + array[i].name + "\n";
				if (i == 500)
				{
					UnityEngine.Debug.Log(text);
					text = string.Empty;
				}
			}
		}
		UnityEngine.Debug.Log(text);
	}

	private void ListLoadedAudio()
	{
		UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(AudioClip));
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i].name == string.Empty))
			{
				string text2 = text;
				text = text2 + i.ToString() + ". " + array[i].name + "\n";
			}
		}
		UnityEngine.Debug.Log(text);
	}

	private void ListLoadedGameObjects()
	{
		UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(GameObject));
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i].name == string.Empty))
			{
				string text2 = text;
				text = text2 + i.ToString() + ". " + array[i].name + "\n";
			}
		}
		UnityEngine.Debug.Log(text);
	}
}
