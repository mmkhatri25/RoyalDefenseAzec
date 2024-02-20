using System;
using UnityEngine;

public class LoadGameSetup : MonoBehaviour
{
	private int state;

	public Object_Content_Data OC;

	private Game_Data data;

	private Stage_Control stageControl;

	private level_setup levelSetup;

	private Object_Logic objectLogic;

	public LoadTransition loadTransition;

	private void Start()
	{
		data = ScriptsManager.dataScript;
		stageControl = ScriptsManager.stageControlScript;
		levelSetup = ScriptsManager.levelSetupScript;
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			levelSetup.activate = 10;
			state++;
			break;
		case 1:
			if (levelSetup.activate == 60)
			{
				state++;
			}
			break;
		case 2:
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(OC.objectLogicPrefab[stageControl.StageInfo[data.gameStage].stageObjectLogic], Vector3.zero, Quaternion.identity) as GameObject;
			objectLogic = gameObject.GetComponent<Object_Logic>();
			state++;
			break;
		}
		case 3:
			if (objectLogic.state == -2)
			{
				state++;
			}
			break;
		case 4:
			loadTransition.enabled = true;
			state++;
			break;
		}
	}
}
