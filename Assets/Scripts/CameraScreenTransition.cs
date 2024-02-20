using UnityEngine;

public class CameraScreenTransition : MonoBehaviour
{
	public static CameraScreenTransition control;

	public bool completed;

	public bool startLoad;

	public GameObject screenTransitionPrefab;

	public int uniqueScreenTransition = -1;

	private int uniqueScreenTransition_TOGGLE;

	public GameObject[] UniqueScreenTransitionPrefab = new GameObject[3];

	public GameObject screenTransition;

	private Transform screenTransitionTransform;

	private string loadSceneID;

	public int transitionDirection;

	private int transitionDirectionState;

	private Camera myCamera;

	private Transform myCameraTransform;

	private float transitionDirection_Delay;

	private float offScreenPosition = 30f;

	private void Awake()
	{
		control = GetComponent<CameraScreenTransition>();
		if (startLoad)
		{
			OnLevelWasLoaded();
		}
	}

	private void OnLevelWasLoaded()
	{
		completed = false;
		if (screenTransition == null && Camera.main != null)
		{
			transitionDirection = 0;
			myCamera = Camera.main;
			myCameraTransform = Camera.main.transform;
			if (uniqueScreenTransition != -1)
			{
				screenTransition = (UnityEngine.Object.Instantiate(UniqueScreenTransitionPrefab[uniqueScreenTransition], myCameraTransform.position, myCameraTransform.rotation) as GameObject);
			}
			else
			{
				screenTransition = (UnityEngine.Object.Instantiate(screenTransitionPrefab, myCameraTransform.position, myCameraTransform.rotation) as GameObject);
			}
			screenTransitionTransform = screenTransition.transform;
			screenTransitionTransform.parent = myCameraTransform;
			screenTransitionTransform.localPosition = new Vector3(0f, 0f, 0.35f);
		}
		uniqueScreenTransition_TOGGLE = uniqueScreenTransition;
	}

	public void Clear(int direction)
	{
		switch (direction)
		{
		case -1:
			transitionDirection = direction;
			break;
		case 0:
			if (screenTransitionTransform != null)
			{
				screenTransitionTransform.localPosition = new Vector3(0f - offScreenPosition, 0f, 0.35f);
			}
			transitionDirection = -1;
			break;
		case 1:
			transitionDirection = direction;
			break;
		}
	}

	public void SceneTransition(int direction, string sceneID)
	{
		loadSceneID = sceneID;
		switch (direction)
		{
		case -3:
			if (screenTransitionTransform != null)
			{
				screenTransitionTransform.localPosition = new Vector3(0f - offScreenPosition, 0f, 0.35f);
			}
			transitionDirection = -1;
			break;
		case -2:
			if (screenTransitionTransform != null)
			{
				screenTransitionTransform.localPosition = new Vector3(0f - offScreenPosition, 0f, 0.35f);
			}
			transitionDirection = 0;
			break;
		case -1:
			transitionDirection = direction;
			break;
		case 0:
			transitionDirection = direction;
			break;
		case 1:
			transitionDirection = direction;
			break;
		case 2:
			if (screenTransitionTransform != null)
			{
				screenTransitionTransform.localPosition = new Vector3(offScreenPosition, 0f, 0.35f);
			}
			transitionDirection = 0;
			break;
		}
	}

	private void LateUpdate()
	{
		if (control == null)
		{
			control = GetComponent<CameraScreenTransition>();
		}
		if (uniqueScreenTransition_TOGGLE != uniqueScreenTransition)
		{
			Vector3 localPosition = screenTransition.transform.localPosition;
			UnityEngine.Object.Destroy(screenTransition);
			if (uniqueScreenTransition != -1)
			{
				screenTransition = (UnityEngine.Object.Instantiate(UniqueScreenTransitionPrefab[uniqueScreenTransition], new Vector3(-1000f, -1000f, 0f), myCameraTransform.rotation) as GameObject);
			}
			else
			{
				screenTransition = (UnityEngine.Object.Instantiate(screenTransitionPrefab, new Vector3(-1000f, -1000f, 0f), myCameraTransform.rotation) as GameObject);
			}
			screenTransitionTransform = screenTransition.transform;
			screenTransitionTransform.parent = myCameraTransform;
			screenTransitionTransform.localPosition = localPosition;
			uniqueScreenTransition_TOGGLE = uniqueScreenTransition;
		}
		if (screenTransition != null)
		{
			if (screenTransitionTransform != screenTransition.transform)
			{
				screenTransitionTransform = screenTransition.transform;
			}
			if (transitionDirectionState != transitionDirection)
			{
				transitionDirection_Delay = Time.time + 1f;
				switch (transitionDirection)
				{
				case -3:
					screenTransitionTransform.localPosition = new Vector3(0f - offScreenPosition, 0f, 0.35f);
					transitionDirection = -1;
					break;
				case -2:
					screenTransitionTransform.localPosition = new Vector3(0f - offScreenPosition, 0f, 0.35f);
					transitionDirection = 0;
					break;
				case 2:
					screenTransitionTransform.localPosition = new Vector3(offScreenPosition, 0f, 0.35f);
					transitionDirection = 0;
					break;
				}
				transitionDirectionState = transitionDirection;
			}
			if (transitionDirection_Delay != 0f)
			{
				if (Time.timeScale != 1f)
				{
					Time.timeScale = 1f;
				}
				switch (transitionDirectionState)
				{
				case -1:
				{
					if (!(Time.time >= transitionDirection_Delay))
					{
						break;
					}
					if (!completed)
					{
						completed = true;
					}
					Vector3 localPosition5 = screenTransitionTransform.localPosition;
					if (localPosition5.x > 0f - offScreenPosition)
					{
						Transform transform2 = screenTransitionTransform;
						Vector3 localPosition6 = screenTransitionTransform.localPosition;
						transform2.localPosition = Vector3.Lerp(new Vector3(localPosition6.x, 0f, 0.35f), new Vector3(0f - offScreenPosition - 0.1f, 0f, 0.35f), 0.1f);
						break;
					}
					Vector3 localPosition7 = screenTransitionTransform.localPosition;
					if (localPosition7.x <= 0f - offScreenPosition)
					{
						screenTransitionTransform.localPosition = new Vector3(0f - offScreenPosition, 0f, 0.35f);
						transitionDirection_Delay = 0f;
					}
					break;
				}
				case 0:
				{
					Vector3 localPosition8 = screenTransitionTransform.localPosition;
					if (localPosition8.x != 0f)
					{
						Transform transform3 = screenTransitionTransform;
						Vector3 localPosition9 = screenTransitionTransform.localPosition;
						transform3.localPosition = Vector3.Lerp(new Vector3(localPosition9.x, 0f, 0.35f), new Vector3(0f, 0f, 0.35f), 0.225f);
					}
					if (loadSceneID != string.Empty && Time.time >= transitionDirection_Delay)
					{
						UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneID);
						loadSceneID = string.Empty;
					}
					break;
				}
				case 1:
				{
					if (!(Time.time >= transitionDirection_Delay))
					{
						break;
					}
					if (!completed)
					{
						completed = true;
					}
					Vector3 localPosition2 = screenTransitionTransform.localPosition;
					if (localPosition2.x < offScreenPosition)
					{
						Transform transform = screenTransitionTransform;
						Vector3 localPosition3 = screenTransitionTransform.localPosition;
						transform.localPosition = Vector3.Lerp(new Vector3(localPosition3.x, 0f, 0.35f), new Vector3(offScreenPosition + 0.1f, 0f, 0.35f), 0.1f);
						break;
					}
					Vector3 localPosition4 = screenTransitionTransform.localPosition;
					if (localPosition4.x >= offScreenPosition)
					{
						screenTransitionTransform.localPosition = new Vector3(offScreenPosition, 0f, 0.35f);
						transitionDirection_Delay = 0f;
					}
					break;
				}
				}
			}
			if (transitionDirection != transitionDirectionState)
			{
				transitionDirection = transitionDirectionState;
			}
		}
		else
		{
			OnLevelWasLoaded();
		}
	}
}
