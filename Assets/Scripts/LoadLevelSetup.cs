using System;
using UnityEngine;

public class LoadLevelSetup : MonoBehaviour
{
	public int loadFunction;

	public level_setup levelSetup;

	private void Start()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
		levelSetup = ScriptsManager.levelSetupScript;
		if (levelSetup != null)
		{
			switch (loadFunction)
			{
			case 6:
				break;
			case -1:
				levelSetup.activate = 20;
				break;
			case 0:
				levelSetup.activate = -1;
				break;
			case 1:
				levelSetup.activate = 50;
				break;
			case 2:
				levelSetup.activate = 51;
				break;
			case 3:
				levelSetup.activate = 52;
				break;
			case 4:
				levelSetup.activate = 53;
				break;
			case 5:
				levelSetup.activate = 54;
				break;
			}
		}
	}

	private void Update()
	{
	}
}
