using UnityEngine;

[AddComponentMenu("")]
public class JCloudData : MonoBehaviour
{
	public delegate void CloudDataExternalChangesCallbackFunction(JCloudDataExternalChange change);

	private static CloudDataExternalChangesCallbackFunction externalChanges;

	public static bool AcceptJailbrokenDevices = true;

	public static CloudDataExternalChangesCallbackFunction ExternalChanges
	{
		get
		{
			JCloudManager.CheckManagerStatus();
			return externalChanges;
		}
		set
		{
			JCloudManager.CheckManagerStatus();
			externalChanges = value;
		}
	}

	public static void SetInt(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	public static int GetInt(string key, int defaultValue)
	{
		return PlayerPrefs.GetInt(key, defaultValue);
	}

	public static int GetInt(string key)
	{
		return GetInt(key, 0);
	}

	public static void SetFloat(string key, float value)
	{
		PlayerPrefs.SetFloat(key, value);
	}

	public static float GetFloat(string key, float defaultValue)
	{
		return PlayerPrefs.GetFloat(key, defaultValue);
	}

	public static float GetFloat(string key)
	{
		return GetFloat(key, 0f);
	}

	public static void SetString(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	public static string GetString(string key, string defaultValue)
	{
		return PlayerPrefs.GetString(key, defaultValue);
	}

	public static string GetString(string key)
	{
		return GetString(key, string.Empty);
	}

	public static bool HasKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public static void DeleteKey(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public static void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}

	public static void Save()
	{
		PlayerPrefs.Save();
	}

	public static bool PollCloudDataAvailability()
	{
		return false;
	}

	public static bool RegisterCloudDataExternalChanges(Component componentOrGameObject)
	{
		return false;
	}

	public static bool UnregisterCloudDataExternalChanges(Component componentOrGameObject)
	{
		return false;
	}
}
