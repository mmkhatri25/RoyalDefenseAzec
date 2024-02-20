using System;
using UnityEngine;

public class Stage_Control : MonoBehaviour
{
	[Serializable]
	public class stageInfo
	{
		public string stageName;

		public GameObject stageObject;

		public int stageObjectLogic;

		public float additionStageLength;

		public int stageMusicTrackA;

		public int stageMusicTrackB;
	}

	public PlayerCharacterData characterData;

	private Content_Data contentData;

	private level_setup levelSetupScript;

	public int state;

	private int TOGGLE_stageNumber;

	public int stageNumber;

	public stageInfo[] StageInfo = new stageInfo[3];

	private int TOGGLE_previewSwitch;

	public int previewNumber;

	public int randomSigns;

	private void Start()
	{
		base.useGUILayout = false;
		ScriptsManager.stageControlScript = GetComponent<Stage_Control>();
	}

	private void Update()
	{
		InfoSetup();
		if (TOGGLE_stageNumber != stageNumber)
		{
			StageFuntion();
		}
		if (TOGGLE_previewSwitch != previewNumber)
		{
			PreviewFuntion();
		}
	}

	private void InfoSetup()
	{
		switch (state)
		{
		case 2:
			break;
		case 0:
			characterData = ScriptsManager.playerCharacter.GetComponent<PlayerCharacterData>();
			contentData = ScriptsManager.contentDataScript;
			state++;
			break;
		case 1:
			for (int i = 0; i < characterData.StageIDs.Length; i++)
			{
				for (int j = 0; j < contentData.StageList.Length; j++)
				{
					if (characterData.StageIDs[i].stageID == contentData.StageList[j].stageID)
					{
						StageInfo[i].stageObject = contentData.StageList[j].environmentPrefab;
						if (i != 3)
						{
							StageInfo[i].stageName = "STAGE " + (i + 1) + " : " + contentData.StageList[j].stageName;
						}
						else
						{
							StageInfo[i].stageName = contentData.StageList[j].stageName;
						}
						StageInfo[i].stageObjectLogic = contentData.StageList[j].objectLogicPrefab;
						StageInfo[i].additionStageLength = contentData.StageList[j].additionStageLength;
						StageInfo[i].stageMusicTrackA = contentData.StageList[j].stageMusicTrackA;
						StageInfo[i].stageMusicTrackB = contentData.StageList[j].stageMusicTrackB;
					}
				}
			}
			TOGGLE_stageNumber = -1;
			state++;
			break;
		}
	}

	private void StageFuntion()
	{
		PoolManager.Pools["Stage Pool"].DespawnAll();
		if (stageNumber != -1)
		{
			PoolManager.Pools["Stage Pool"].Spawn(StageInfo[stageNumber].stageObject.transform, Vector3.zero, base.transform.rotation);
		}
		else if (stageNumber == -1)
		{
			PoolManager.Pools["Stage Pool"].Spawn(StageInfo[UnityEngine.Random.Range(0, StageInfo.Length)].stageObject.transform, Vector3.zero, base.transform.rotation);
		}
		TOGGLE_stageNumber = stageNumber;
	}

	private void PreviewFuntion()
	{
		if (previewNumber > 0)
		{
			levelSetupScript = ScriptsManager.levelSetupScript;
			PoolManager.Pools["Preview Pool"].Spawn(levelSetupScript.levelPreview[0].transform, new Vector3(StageInfo[stageNumber].additionStageLength, 0f, 0f), levelSetupScript.levelPreview[0].transform.rotation);
			randomSigns = UnityEngine.Random.Range(0, levelSetupScript.objectPreviewSigns.Length);
			PoolManager.Pools["Preview Pool"].Spawn(levelSetupScript.objectPreviewSigns[randomSigns].transform, new Vector3(StageInfo[stageNumber].additionStageLength, 0f, 0f), levelSetupScript.objectPreviewSigns[randomSigns].transform.rotation);
			PoolManager.Pools["Preview Pool"].Spawn(levelSetupScript.levelPreview[previewNumber].transform, new Vector3(StageInfo[stageNumber].additionStageLength, 0f, 0f), base.transform.rotation);
			for (int i = 1; i < previewNumber; i++)
			{
				PoolManager.Pools["Preview Pool"].Spawn(levelSetupScript.levelPreview[i].transform, new Vector3(StageInfo[stageNumber].additionStageLength, 0f, (float)i * 0.01f), base.transform.rotation);
			}
		}
		else if (previewNumber == 0)
		{
			PoolManager.Pools["Preview Pool"].DespawnAll();
		}
		TOGGLE_previewSwitch = previewNumber;
	}
}
