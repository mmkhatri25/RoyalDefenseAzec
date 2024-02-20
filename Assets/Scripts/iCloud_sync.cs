using UnityEngine;

public class iCloud_sync : MonoBehaviour
{
	public int iCloundSyncType;

	private void Start()
	{
		switch (iCloundSyncType)
		{
		case 0:
			ScriptsManager.dataScript.iCloudData(3, "null", 0);
			break;
		case 1:
			ScriptsManager.dataScript.iCloudData(1, "null", 0);
			break;
		case 2:
			ScriptsManager.dataScript.iCloudData(4, "null", 0);
			break;
		}
	}

	private void Update()
	{
		switch (iCloundSyncType)
		{
		case 3:
			if (PlayerPrefs.GetInt("iCloudUpdateNumber") < JCloudData.GetInt("iCloudUpdateNumber"))
			{
				ScriptsManager.dataScript.iCloudData(1, "null", 0);
				AutoFade.LoadLevel("Load - AfterSync", 1f, 1f, Color.black);
			}
			else if (PlayerPrefs.GetInt("iCloudUpdateNumber") > JCloudData.GetInt("iCloudUpdateNumber"))
			{
				ScriptsManager.dataScript.iCloudData(4, "null", 0);
			}
			break;
		case 4:
			if (PlayerPrefs.GetInt("iCloudUpdateNumber") < JCloudData.GetInt("iCloudUpdateNumber"))
			{
				ScriptsManager.dataScript.iCloudData(1, "null", 0);
			}
			else if (PlayerPrefs.GetInt("iCloudUpdateNumber") > JCloudData.GetInt("iCloudUpdateNumber"))
			{
				ScriptsManager.dataScript.iCloudData(4, "null", 0);
			}
			break;
		}
	}
}
