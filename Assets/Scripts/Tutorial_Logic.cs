using System;
using UnityEngine;

public class Tutorial_Logic : MonoBehaviour
{
	[Serializable]
	public class actObject
	{
		[Serializable]
		public class act
		{
			public GameObject actSpawn;

			public Transform actSpawnLocation;

			public Transform Inst;
		}

		public act[] Act;
	}

	[Serializable]
	public class actScenes
	{
		[Serializable]
		public class scenes
		{
			[Serializable]
			public class character
			{
				public SceneCharacterLogic characterObject;

				public string playAnimationName;

				public string movingAnimationName;

				public int characterDirection;

				public float movementSpeed = 0.5f;

				public int moveForward;

				public int moveUp;

				public int characterAction;
			}

			public int act;

			public float sceneDelay;

			public character[] Character;

			public AudioClip sceneSound;

			public string speechPortraitLeft;

			public string speechPortraitRight;

			public string speechSpeakerName;

			public string speechText;
		}

		public scenes[] Scenes;
	}

	public AudioClip regularClick;

	public AudioClip actCompleteClick;

	public bool continueScene;

	public bool actComplete;

	public int state;

	public int act;

	public int actSceneNumber;

	public int sceneNumber;

	private int TOGGLE_sceneNumber = -1;

	public actObject[] ActObject;

	private float TIMER_shardDrop;

	public GameObject shardDrop;

	public Transform shardDropPosition;

	public actScenes[] ActScenes;

	public SceneSpeechLogic sceneSpeechLogic;

	public SceneTextIcon sceneTextIcon;

	private Game_Logic gameLogic;

	private Game_Statistics gameStatistic;

	private GameMasterScriptsControl gameMasterControl;

	public static Tutorial_Logic tutorialLogic;

	public GameObject storySpeechObject;

	public int tutorialInfoTrigger;

	private float startDelay;

	private float TIMER_sceneDelay;

	private int tutorialMode;

	private float TIMER_delay;

	private int TOGGLE_act;

	private int TOGGLE_tutorialInfoTrigger;

	private void Awake()
	{
		base.name = "Tutorial Logic";
		tutorialLogic = GetComponent<Tutorial_Logic>();
	}

	private void Start()
	{
		base.name = "Tutorial Logic";
		startDelay = Time.time + 10f;
		gameLogic = GameScriptsManager.gameLogicScript;
		gameStatistic = GameScriptsManager.gameStatisticScript;
		tutorialMode = GameScriptsManager.masterControlScript.tutorialMode;
		if (gameLogic == null && gameStatistic == null)
		{
			startDelay = Time.time + 1f;
		}
	}

	private void LateUpdate()
	{
		if (Time.timeScale == 0f)
		{
			if (state == 0)
			{
				TIMER_delay = Time.time + 2f;
				state = -3;
			}
		}
		else if (Time.timeScale == 1f)
		{
			if (sceneNumber == 0)
			{
				if (Time.time >= startDelay)
				{
					sceneNumber = 1;
				}
			}
			else
			{
				StateFunction();
				if (gameLogic != null && gameLogic != null)
				{
					ActFunction();
				}
				SceneFunction();
			}
			ButtonFunction();
		}
		TutorialPopUp();
	}

	private void SceneFunction()
	{
		if (actSceneNumber < ActScenes.Length)
		{
			if (sceneNumber < ActScenes[actSceneNumber].Scenes.Length)
			{
				if (ActScenes[actSceneNumber].Scenes[sceneNumber].sceneDelay > 0f)
				{
					if (Time.time >= TIMER_sceneDelay && act == 0)
					{
						sceneNumber++;
					}
				}
				else if (continueScene && act == 0)
				{
					if (regularClick != null)
					{
						Camera.main.GetComponent<AudioSource>().PlayOneShot(regularClick);
					}
					sceneNumber++;
					continueScene = false;
				}
				if (sceneNumber == ActScenes[actSceneNumber].Scenes.Length || TOGGLE_sceneNumber == sceneNumber)
				{
					return;
				}
				if (ActScenes[actSceneNumber].Scenes[sceneNumber].sceneDelay > 0f)
				{
					TIMER_sceneDelay = Time.time + ActScenes[actSceneNumber].Scenes[sceneNumber].sceneDelay;
					state = 1;
					sceneTextIcon.state = 2;
				}
				else
				{
					state = 0;
					sceneTextIcon.state = 1;
				}
				if (gameLogic != null && gameLogic != null)
				{
					act = ActScenes[actSceneNumber].Scenes[sceneNumber].act;
				}
				else
				{
					act = 0;
				}
				for (int i = 0; i < ActScenes[actSceneNumber].Scenes[sceneNumber].Character.Length; i++)
				{
					if (ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterObject != null)
					{
						if (ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].playAnimationName != string.Empty)
						{
							ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterObject.playAnimationName = ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].playAnimationName;
						}
						if (ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].movingAnimationName != string.Empty)
						{
							ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterObject.movingAnimationName = ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].movingAnimationName;
						}
						ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterObject.characterDirection = ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterDirection;
						ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterObject.movementSpeed = ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].movementSpeed;
						ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterObject.moveForward = ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].moveForward;
						ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterObject.moveUp = ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].moveUp;
						ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterObject.characterAction = ActScenes[actSceneNumber].Scenes[sceneNumber].Character[i].characterAction;
					}
				}
				if (ActScenes[actSceneNumber].Scenes[sceneNumber].sceneSound != null)
				{
					GetComponent<AudioSource>().PlayOneShot(ActScenes[actSceneNumber].Scenes[sceneNumber].sceneSound);
				}
				if (sceneSpeechLogic != null)
				{
					sceneSpeechLogic.portraitLeft = ActScenes[actSceneNumber].Scenes[sceneNumber].speechPortraitLeft;
					sceneSpeechLogic.portraitRight = ActScenes[actSceneNumber].Scenes[sceneNumber].speechPortraitRight;
					sceneSpeechLogic.speakerName = ActScenes[actSceneNumber].Scenes[sceneNumber].speechSpeakerName;
					sceneSpeechLogic.speakerSpeech = ActScenes[actSceneNumber].Scenes[sceneNumber].speechText;
				}
				TOGGLE_sceneNumber = sceneNumber;
				return;
			}
			sceneTextIcon.state = 0;
			if (tutorialMode == 1)
			{
				if (actSceneNumber == 2)
				{
					actSceneNumber = 4;
				}
				else if (actSceneNumber == 0)
				{
					actSceneNumber = 2;
				}
				else if (actSceneNumber != 0 && actSceneNumber != 2)
				{
					actSceneNumber++;
				}
			}
			else
			{
				actSceneNumber++;
			}
			sceneNumber = 0;
		}
		else if (gameLogic == null && gameStatistic == null)
		{
			AutoFade.LoadLevel("Story Development 3", 2f, 1f, Color.clear);
		}
	}

	private void StateFunction()
	{
		switch (state)
		{
		case 1:
			break;
		case 2:
			break;
		case -3:
			if (Time.time >= TIMER_delay)
			{
				state = 0;
			}
			break;
		case -2:
			GameScriptsManager.guardLogicScript.state = 3;
			gameLogic.gameState = 1;
			state++;
			break;
		case -1:
			if (Time.time >= TIMER_delay)
			{
				continueScene = true;
				state++;
			}
			break;
		case 0:
			if (Input.GetMouseButtonDown(0))
			{
				continueScene = true;
			}
			break;
		}
	}

	private void ActFunction()
	{
		if (actComplete)
		{
			if (actCompleteClick != null)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(actCompleteClick);
			}
			gameStatistic.characterAnimationNumber = 0;
			gameStatistic.scoreUnitDefeated = 0;
			TOGGLE_act = 0;
			act = 0;
			state = -2;
			actComplete = false;
		}
		else if (act == -4)
		{
			for (int i = 0; i < ActObject[1].Act.Length; i++)
			{
				ActObject[1].Act[i].Inst = PoolManager.Pools["Pickup Pool"].Spawn(ActObject[1].Act[i].actSpawn.transform, ActObject[1].Act[i].actSpawnLocation.position, ActObject[1].Act[i].actSpawn.transform.rotation);
			}
			act = 0;
		}
		else if (act == 0)
		{
			if (gameLogic.gameState != 1)
			{
				gameLogic.gameState = 1;
			}
		}
		else if (act > 0)
		{
			switch (act)
			{
			case 1:
				if (TOGGLE_act != act)
				{
					GameScriptsManager.hudControlcScript.hintNumber = 1;
					gameStatistic.scoreUnitDefeated = 0;
					state = 1;
					gameLogic.gameWaveNumber = act;
					gameLogic.gameState = 2;
					for (int k = 0; k < ActObject[act - 1].Act.Length; k++)
					{
						ActObject[act - 1].Act[k].Inst = PoolManager.Pools["Scene Pool"].Spawn(ActObject[act - 1].Act[k].actSpawn.transform, ActObject[act - 1].Act[k].actSpawnLocation.position, ActObject[act - 1].Act[k].actSpawn.transform.rotation);
					}
					TOGGLE_act = act;
				}
				if (gameStatistic.scoreUnitDefeated >= 1)
				{
					for (int l = 0; l < ActObject[act - 1].Act.Length; l++)
					{
						PoolManager.Pools["Scene Pool"].Despawn(ActObject[act - 1].Act[l].Inst);
					}
					actComplete = true;
				}
				break;
			case 2:
				if (TOGGLE_act != act)
				{
					GameScriptsManager.hudControlcScript.hintNumber = 2;
					gameStatistic.scoreShardsCollected = 0;
					state = 1;
					gameLogic.gameWaveNumber = act;
					gameLogic.gameState = 2;
					TOGGLE_act = act;
				}
				if (gameStatistic.scoreShardsCollected >= 3)
				{
					actComplete = true;
				}
				break;
			case 3:
				if (TOGGLE_act != act)
				{
					GameScriptsManager.hudControlcScript.hintNumber = 3;
					gameStatistic.scoreUnitDefeated = 0;
					state = 1;
					gameLogic.gameWaveNumber = act;
					gameLogic.gameState = 2;
					for (int m = 0; m < ActObject[act - 1].Act.Length; m++)
					{
						ActObject[act - 1].Act[m].Inst = PoolManager.Pools["Scene Pool"].Spawn(ActObject[act - 1].Act[m].actSpawn.transform, ActObject[act - 1].Act[m].actSpawnLocation.position, ActObject[act - 1].Act[m].actSpawn.transform.rotation);
					}
					TOGGLE_act = act;
				}
				if (gameStatistic.manaNumber < 60 && Time.time >= TIMER_shardDrop)
				{
					PoolManager.Pools["Scene Pool"].Spawn(shardDrop.transform, shardDropPosition.position, shardDrop.transform.rotation);
					TIMER_shardDrop = Time.time + 10f;
				}
				if (gameStatistic.scoreUnitDefeated >= 3)
				{
					for (int n = 0; n < ActObject[act - 1].Act.Length; n++)
					{
						PoolManager.Pools["Scene Pool"].Despawn(ActObject[act - 1].Act[n].Inst);
					}
					GameScriptsManager.guardLogicScript.effectHP = GameScriptsManager.guardLogicScript.guardHealthPoint;
					GameScriptsManager.guardLogicScript.effectToggle = 1;
					actComplete = true;
				}
				break;
			case 4:
				if (TOGGLE_act != act + 2)
				{
					if (TOGGLE_act < act)
					{
						GameScriptsManager.hudControlcScript.hintNumber = 4;
						gameStatistic.scoreItemsUsed = 0;
						state = 1;
						gameLogic.gameWaveNumber = act;
						gameLogic.gameState = 2;
						for (int j = 0; j < ActObject[act - 1].Act.Length; j++)
						{
							ActObject[act - 1].Act[j].Inst = PoolManager.Pools["Scene Pool"].Spawn(ActObject[act - 1].Act[j].actSpawn.transform, ActObject[act - 1].Act[j].actSpawnLocation.position, ActObject[act - 1].Act[j].actSpawn.transform.rotation);
						}
						TOGGLE_act = act;
					}
					else if (TOGGLE_act < act + 1)
					{
						GameScriptsManager.guardLogicScript.effectHP = Mathf.RoundToInt(0f - (float)GameScriptsManager.guardLogicScript.guardHealthPoint * 0.75f - 1f);
						GameScriptsManager.guardLogicScript.effectToggle = 1;
						TOGGLE_act = act + 1;
					}
					else if (TOGGLE_act < act + 2)
					{
						GameScriptsManager.itemControlScript.ItemTutorialEquipFunction(0);
						gameStatistic.manaNumber = 0;
						TOGGLE_act = act + 2;
					}
				}
				if (gameStatistic.scoreItemsUsed >= 2 && gameStatistic.manaNumber > 30)
				{
					TIMER_delay = Time.time + 1f;
					actComplete = true;
				}
				break;
			case 5:
				if (TOGGLE_act != act)
				{
					GameScriptsManager.hudControlcScript.hintNumber = 5;
					GameScriptsManager.guardLogicScript.state = 0;
					state = 1;
					gameLogic.gameWaveNumber = act;
					gameLogic.gameState = 2;
					TOGGLE_act = act;
				}
				if (gameLogic.gameWaveTier == 1)
				{
					act = 6;
				}
				break;
			case 6:
				if (TOGGLE_act != act)
				{
					GameScriptsManager.hudControlcScript.hintNumber = 6;
					GameScriptsManager.hudControlcScript.state = 9;
					TOGGLE_act = act;
				}
				break;
			}
		}
		if (gameLogic.gameState == 4)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void TutorialPopUp()
	{
		if (act == 0)
		{
			return;
		}
		switch (tutorialInfoTrigger)
		{
		case 0:
			if (TOGGLE_tutorialInfoTrigger != tutorialInfoTrigger)
			{
				TOGGLE_tutorialInfoTrigger = tutorialInfoTrigger;
			}
			break;
		case 1:
			if (TOGGLE_tutorialInfoTrigger != tutorialInfoTrigger)
			{
				TOGGLE_tutorialInfoTrigger = tutorialInfoTrigger;
			}
			break;
		}
	}

	private void ButtonFunction()
	{
		storySpeechObject.transform.localPosition = Camera.main.transform.localPosition;
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			if (hitInfo.collider.transform.name == "TUTORIAL_continue")
			{
				tutorialInfoTrigger = 0;
			}
			if (hitInfo.collider.transform.name == "BTN_HINT")
			{
				tutorialInfoTrigger = 1;
			}
		}
	}
}
