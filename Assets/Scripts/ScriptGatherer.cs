using UnityEngine;

public class ScriptGatherer : MonoBehaviour
{
	public GameObject character;

	private PlayerCharacterInfo scriptPlayerCharacterInfo;

	public GameObject storyBeginningScene;

	private Scene_Logic scriptSceneLogic1;

	public GameObject storyTutorialScene;

	private Tutorial_Logic scriptTutorialLogic;

	public GameObject storyEndingScene;

	private Scene_Logic scriptSceneLogic2;

	public string characterSpellDescription;

	public string storyBeginningLines;

	public string storyTutorialLines;

	public string storyEndingLines;

	private int state;

	private void Start()
	{
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			state++;
			break;
		case 1:
			if (character != null)
			{
				scriptPlayerCharacterInfo = character.GetComponent<PlayerCharacterInfo>();
				characterSpellDescription = "RED:\n" + scriptPlayerCharacterInfo.redSpellDescription + "\n\nBLUE:\n" + scriptPlayerCharacterInfo.blueSpellDescription + "\n\nYELLOW:\n" + scriptPlayerCharacterInfo.yellowSpellDescription + "\n\nGREEN:\n" + scriptPlayerCharacterInfo.greenSpellDescription;
			}
			state++;
			break;
		case 2:
			if (storyBeginningScene != null)
			{
				scriptSceneLogic1 = storyBeginningScene.GetComponent<Scene_Logic>();
				storyBeginningLines = "Scene : Beginning \n";
				for (int j = 0; j < scriptSceneLogic1.Scenes.Length; j++)
				{
					if (scriptSceneLogic1.Scenes[j].speechText != string.Empty)
					{
						string text = storyBeginningLines;
						storyBeginningLines = text + "SCENE#:" + j + "\n";
						if (scriptSceneLogic1.Scenes[j].speechSpeakerName != string.Empty)
						{
							storyBeginningLines = storyBeginningLines + scriptSceneLogic1.Scenes[j].speechSpeakerName + ":\n";
						}
						else
						{
							storyBeginningLines += "EMPTY:\n";
						}
						storyBeginningLines = storyBeginningLines + scriptSceneLogic1.Scenes[j].speechText + "\n\n";
					}
				}
			}
			state++;
			break;
		case 3:
			if (storyTutorialScene != null)
			{
				scriptTutorialLogic = storyTutorialScene.GetComponent<Tutorial_Logic>();
				storyTutorialLines = "Scene : Tutorial \n";
				for (int k = 0; k < scriptTutorialLogic.ActScenes.Length; k++)
				{
					for (int l = 0; l < scriptTutorialLogic.ActScenes[k].Scenes.Length; l++)
					{
						if (scriptTutorialLogic.ActScenes[k].Scenes[l].speechText != string.Empty)
						{
							string text = storyTutorialLines;
							storyTutorialLines = text + "ACT#:" + k + " SCENE#:" + l + "\n";
							if (scriptTutorialLogic.ActScenes[k].Scenes[l].speechSpeakerName != string.Empty)
							{
								storyTutorialLines = storyTutorialLines + scriptTutorialLogic.ActScenes[k].Scenes[l].speechSpeakerName + ":\n";
							}
							else
							{
								storyTutorialLines += "EMPTY:\n";
							}
							storyTutorialLines = storyTutorialLines + scriptTutorialLogic.ActScenes[k].Scenes[l].speechText + "\n\n";
						}
					}
				}
			}
			state++;
			break;
		case 4:
			if (storyEndingScene != null)
			{
				scriptSceneLogic2 = storyEndingScene.GetComponent<Scene_Logic>();
				storyEndingLines = "Scene : End \n";
				for (int i = 0; i < scriptSceneLogic2.Scenes.Length; i++)
				{
					if (scriptSceneLogic2.Scenes[i].speechText != string.Empty)
					{
						string text = storyEndingLines;
						storyEndingLines = text + "SCENE#:" + i + "\n";
						if (scriptSceneLogic2.Scenes[i].speechSpeakerName != string.Empty)
						{
							storyEndingLines = storyEndingLines + scriptSceneLogic2.Scenes[i].speechSpeakerName + ":\n";
						}
						else
						{
							storyEndingLines += "EMPTY:\n";
						}
						storyEndingLines = storyEndingLines + scriptSceneLogic2.Scenes[i].speechText + "\n\n";
					}
				}
			}
			state++;
			break;
		case 5:
			state++;
			break;
		}
	}
}
