using System;
using UnityEngine;

public class Scene_Logic : MonoBehaviour
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

		[Serializable]
		public class menuTransitions
		{
			public MenuTransition menuTransition;

			public int menuTransitionNumber;
		}

		[Serializable]
		public class spawnObjects
		{
			public GameObject spawnObject;

			public Transform spawnObjectPosition;

			public string spawnPoolName = "Scene Pool";

			public int numberOfScenes;
		}

		public int sceneState;

		public float sceneDuration;

		public character[] Character;

		public int musicNumber;

		public AudioClip sceneSound;

		public int sceneCameraPostionHorizontal;

		public int sceneCameraPostionVertical;

		public float sceneCameraPostionTransitionSpeed = 1f;

		public string speechPortraitLeft;

		public string speechPortraitRight;

		public string speechSpeakerName;

		public string speechText;

		public menuTransitions[] MenuTransitions;

		public spawnObjects[] SpawnObjects;
	}

	[Serializable]
	public class spawnObject
	{
		public Transform spawnObjectInst;

		public string spawnObjectPool;

		public int spawnObjectSceneCurrentNumber;

		public int spawnObjectSceneNumber;
	}

	public AudioClip regularClick;

	public AudioClip accessClick;

	public bool continueScene;

	public int sceneState;

	public string loadScene;

	public int sceneNumber;

	private int TOGGLE_sceneNumber = -1;

	private int TOGGLE2_sceneNumber = -1;

	public SceneCameraLogic cameraLogic;

	public SceneSpeechLogic speechLogic;

	public SceneTextIcon textIcon;

	public MenuTransition menuTransition;

	public MenuTransition menuTransitionNextScene;

	public GameObject[] music = new GameObject[5];

	private Transform INST_music;

	public scenes[] Scenes;

	public GameObject nextStoryScene;

	private float TIMER_sceneDuration;

	public spawnObject[] SpawnObject = new spawnObject[10];

	private float startDelay;

	public int independent;

	private int soundMode;

	private int firstSceneToggle;

	private float ffTIMER;

	private float TIMER_nextSceneDelay;

	private void Awake()
	{
	}

	private void Start()
	{
		base.name = "Scene Logic";
		startDelay = Time.time + 3f;
		sceneState = 2;
		if ((double)Camera.main.aspect < 1.4)
		{
			Camera.main.orthographicSize = 4f;
		}
		else
		{
			Camera.main.orthographicSize = 3f;
		}
		if (menuTransitionNextScene != null && menuTransitionNextScene.transitionNumber == 0)
		{
			startDelay = Time.time + 2f;
		}
		if (independent == 0)
		{
			soundMode = ScriptsManager.dataScript.soundMode;
		}
		CameraScreenTransition.control.Clear(-3);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.transform.name == "btn_skip")
			{
				if (soundMode != 2 && accessClick != null)
				{
					GetComponent<AudioSource>().PlayOneShot(accessClick);
				}
				sceneNumber = Scenes.Length + 1;
			}
		}
		if (sceneNumber < Scenes.Length && CameraScreenTransition.control.transitionDirection >= 0)
		{
			CameraScreenTransition.control.transitionDirection = -3;
		}
		switch (sceneState)
		{
		case -2:
			if (menuTransitionNextScene != null && Time.time >= startDelay / 2f)
			{
				menuTransitionNextScene.transitionNumber = 5;
			}
			if (Time.time >= startDelay)
			{
				textIcon.state = 1;
				sceneState = 0;
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.Z))
			{
				continueScene = true;
			}
			break;
		case 0:
			if (Input.GetMouseButtonDown(0) || UnityEngine.Input.GetKeyDown(KeyCode.Z))
			{
				continueScene = true;
			}
			if (UnityEngine.Input.GetKey(KeyCode.X) && Time.time >= ffTIMER)
			{
				continueScene = true;
				ffTIMER = Time.time + 0.05f;
			}
			break;
		case 1:
			if (UnityEngine.Input.GetKeyDown(KeyCode.Z))
			{
				TIMER_sceneDuration = Time.time;
			}
			break;
		case 2:
			if (Time.time >= TIMER_sceneDuration)
			{
				textIcon.state = 1;
				sceneState = 0;
			}
			continueScene = false;
			break;
		}
		if (continueScene)
		{
			if (soundMode != 2 && regularClick != null)
			{
				GetComponent<AudioSource>().PlayOneShot(regularClick);
			}
			sceneNumber++;
			continueScene = false;
		}
		if (sceneNumber < Scenes.Length)
		{
			if (sceneNumber >= Scenes.Length)
			{
				return;
			}
			if (sceneState != 2 && sceneState != -2 && TIMER_sceneDuration != 0f && Time.time >= TIMER_sceneDuration)
			{
				sceneNumber++;
				TIMER_sceneDuration = 0f;
			}
			if (TOGGLE_sceneNumber == sceneNumber)
			{
				return;
			}
			sceneState = Scenes[sceneNumber].sceneState;
			if (sceneState == -100)
			{
				sceneNumber++;
				sceneState = Scenes[sceneNumber].sceneState;
			}
			if (soundMode == 0)
			{
				if (Scenes[sceneNumber].musicNumber == -1)
				{
					if (INST_music != null)
					{
						PoolManager.Pools["Scene Pool"].Despawn(INST_music);
						INST_music = null;
					}
				}
				else if (Scenes[sceneNumber].musicNumber > 0)
				{
					if (INST_music != null)
					{
						PoolManager.Pools["Scene Pool"].Despawn(INST_music);
						INST_music = null;
					}
					INST_music = PoolManager.Pools["Scene Pool"].Spawn(music[Scenes[sceneNumber].musicNumber - 1].transform, Vector3.zero, base.transform.rotation);
				}
			}
			if (sceneState == -1)
			{
				return;
			}
			if (firstSceneToggle != 0)
			{
				if (Scenes[sceneNumber].sceneDuration > 0f)
				{
					textIcon.state = 2;
					TIMER_sceneDuration = Time.time + Scenes[sceneNumber].sceneDuration;
				}
				else
				{
					textIcon.state = 1;
					TIMER_sceneDuration = 0f;
				}
			}
			else
			{
				sceneState = -2;
				textIcon.state = 0;
				firstSceneToggle = 1;
			}
			for (int i = 0; i < Scenes[sceneNumber].Character.Length; i++)
			{
				if (Scenes[sceneNumber].Character[i].characterObject != null)
				{
					if (Scenes[sceneNumber].Character[i].playAnimationName != string.Empty)
					{
						Scenes[sceneNumber].Character[i].characterObject.playAnimationName = Scenes[sceneNumber].Character[i].playAnimationName;
					}
					if (Scenes[sceneNumber].Character[i].movingAnimationName != string.Empty)
					{
						Scenes[sceneNumber].Character[i].characterObject.movingAnimationName = Scenes[sceneNumber].Character[i].movingAnimationName;
					}
					Scenes[sceneNumber].Character[i].characterObject.characterDirection = Scenes[sceneNumber].Character[i].characterDirection;
					Scenes[sceneNumber].Character[i].characterObject.movementSpeed = Scenes[sceneNumber].Character[i].movementSpeed;
					Scenes[sceneNumber].Character[i].characterObject.moveForward = Scenes[sceneNumber].Character[i].moveForward;
					Scenes[sceneNumber].Character[i].characterObject.moveUp = Scenes[sceneNumber].Character[i].moveUp;
					Scenes[sceneNumber].Character[i].characterObject.characterAction = Scenes[sceneNumber].Character[i].characterAction;
				}
			}
			if (soundMode != 2)
			{
				GetComponent<AudioSource>().PlayOneShot(Scenes[sceneNumber].sceneSound);
			}
			if (cameraLogic != null && (Scenes[sceneNumber].sceneCameraPostionHorizontal != 0 || Scenes[sceneNumber].sceneCameraPostionVertical != 0))
			{
				cameraLogic.moveForward = Scenes[sceneNumber].sceneCameraPostionHorizontal;
				cameraLogic.moveUp = Scenes[sceneNumber].sceneCameraPostionVertical;
				cameraLogic.movementSpeed = Scenes[sceneNumber].sceneCameraPostionTransitionSpeed;
			}
			if (speechLogic != null)
			{
				speechLogic.speakerName = Scenes[sceneNumber].speechSpeakerName;
				speechLogic.portraitLeft = Scenes[sceneNumber].speechPortraitLeft;
				speechLogic.portraitRight = Scenes[sceneNumber].speechPortraitRight;
				speechLogic.speakerSpeech = Scenes[sceneNumber].speechText;
			}
			for (int j = 0; j < Scenes[sceneNumber].MenuTransitions.Length; j++)
			{
				if (Scenes[sceneNumber].MenuTransitions[j].menuTransition != null)
				{
					Scenes[sceneNumber].MenuTransitions[j].menuTransition.transitionNumber = Scenes[sceneNumber].MenuTransitions[j].menuTransitionNumber;
				}
			}
			TOGGLE_sceneNumber = sceneNumber;
			return;
		}
		textIcon.state = 0;
		if (nextStoryScene != null)
		{
			if (TIMER_nextSceneDelay == 0f)
			{
				TIMER_nextSceneDelay = Time.time + 2f;
			}
			if (menuTransitionNextScene != null)
			{
				menuTransitionNextScene.transitionNumber = 0;
			}
			if (!(Time.time >= TIMER_nextSceneDelay))
			{
				return;
			}
			for (int k = 0; k < SpawnObject.Length; k++)
			{
				if (SpawnObject[k].spawnObjectInst != null)
				{
					PoolManager.Pools[SpawnObject[k].spawnObjectPool].Despawn(SpawnObject[k].spawnObjectInst);
					SpawnObject[k].spawnObjectInst = null;
				}
			}
			if (INST_music != null)
			{
				PoolManager.Pools["Scene Pool"].Despawn(INST_music);
				INST_music = null;
			}
			UnityEngine.Object.Instantiate(nextStoryScene, Vector3.zero, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			if (INST_music != null)
			{
				PoolManager.Pools["Scene Pool"].Despawn(INST_music);
				INST_music = null;
			}
			if (menuTransition != null)
			{
			}
			if (loadScene != string.Empty)
			{
				CameraScreenTransition.control.SceneTransition(2, loadScene);
				loadScene = string.Empty;
			}
		}
	}

	private void LateUpdate()
	{
		if (TOGGLE2_sceneNumber == TOGGLE_sceneNumber)
		{
			return;
		}
		for (int i = 0; i < Scenes[sceneNumber].SpawnObjects.Length; i++)
		{
			if (!(Scenes[sceneNumber].SpawnObjects[i].spawnObject != null))
			{
				continue;
			}
			for (int j = 0; j < SpawnObject.Length; j++)
			{
				if (SpawnObject[j].spawnObjectInst == null)
				{
					if (Scenes[sceneNumber].SpawnObjects[i].spawnPoolName != string.Empty)
					{
						SpawnObject[j].spawnObjectPool = Scenes[sceneNumber].SpawnObjects[i].spawnPoolName;
					}
					else
					{
						SpawnObject[j].spawnObjectPool = "Scene Pool";
					}
					if (Scenes[sceneNumber].SpawnObjects[i].spawnObjectPosition != null)
					{
						SpawnObject[j].spawnObjectInst = PoolManager.Pools[SpawnObject[j].spawnObjectPool].Spawn(Scenes[sceneNumber].SpawnObjects[i].spawnObject.transform, Scenes[sceneNumber].SpawnObjects[i].spawnObjectPosition.position, Scenes[sceneNumber].SpawnObjects[i].spawnObject.transform.rotation);
					}
					else
					{
						SpawnObject[j].spawnObjectInst = PoolManager.Pools[SpawnObject[j].spawnObjectPool].Spawn(Scenes[sceneNumber].SpawnObjects[i].spawnObject.transform, Vector3.zero, Scenes[sceneNumber].SpawnObjects[i].spawnObject.transform.rotation);
					}
					SpawnObject[j].spawnObjectSceneCurrentNumber = sceneNumber;
					SpawnObject[j].spawnObjectSceneNumber = sceneNumber + Scenes[sceneNumber].SpawnObjects[i].numberOfScenes;
					j = SpawnObject.Length;
				}
			}
		}
		for (int k = 0; k < SpawnObject.Length; k++)
		{
			if (SpawnObject[k].spawnObjectInst != null)
			{
				if (SpawnObject[k].spawnObjectSceneCurrentNumber < SpawnObject[k].spawnObjectSceneNumber)
				{
					SpawnObject[k].spawnObjectSceneCurrentNumber++;
				}
				else if (SpawnObject[k].spawnObjectSceneCurrentNumber >= SpawnObject[k].spawnObjectSceneNumber)
				{
					PoolManager.Pools[SpawnObject[k].spawnObjectPool].Despawn(SpawnObject[k].spawnObjectInst);
					SpawnObject[k].spawnObjectInst = null;
				}
			}
		}
		TOGGLE2_sceneNumber = TOGGLE_sceneNumber;
	}
}
