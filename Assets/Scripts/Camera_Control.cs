using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public Vector3 lastMousePosition;

    [SerializeField]
    private float sensitivity = 0.1f;
    [SerializeField]
    private float minXLimit = -10f; // Replace with your minimum x-position limit

    [SerializeField]
    private float maxXLimit = 10f;
    private bool isDragging = false;

    public int state;

	private Vector3 rayPosition = new Vector3(-5.4f, -1.55f, 0f);

	public GameObject enemyDetected;

	public GameObject locater;

	public Warning_Notification scriptWarningNotification;

	private Vector3 cameraPosition_TRACK;

	public float distance = 15f;

	public float CameraDistance = 10f;

	public float DefaultDistance = 100f;

	public float OutsideCamera = 100f;

	public RaycastHit hit;

	private Transform myTransform;

	public HUD_Extra scriptHudAddon;

	private int stageIntroductionState;

	private int TOGGLE_stageIntroductionState;

	private float TIMER_stageIntroduction;

	private Vector3 CAMERA_stageIntroduction;

	private float stageLength;

	private int TOGGLE_state;

	public int setCameraPosition;

	public float setPositionX;

	private float TIMER_setCameraPosition;

	private float DELAY_enemyDetected;
	public static Camera_Control instance;
    private void Awake()
    {
		instance = this;
    }

    private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		stageLength = GameScriptsManager.masterControlScript.stageLength;
	}

	private void stageIntroduction()
	{
		myTransform.position = Vector3.Lerp(myTransform.position, CAMERA_stageIntroduction, Time.smoothDeltaTime * 1.25f);
		switch (stageIntroductionState)
		{
		case 0:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				scriptHudAddon.readyState = -1;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			stageIntroductionState = 1;
			break;
		case 1:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				CAMERA_stageIntroduction = new Vector3(-0.8f, 1.5f, -10f);
				TIMER_stageIntroduction = Time.time + 3f;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			if (Time.time >= TIMER_stageIntroduction)
			{
				stageIntroductionState = 2;
			}
			break;
		case 2:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				CAMERA_stageIntroduction = new Vector3(OutsideCamera + stageLength, 1.5f, -10f);
				TIMER_stageIntroduction = Time.time + 4f;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			if (Time.time >= TIMER_stageIntroduction)
			{
				stageIntroductionState = 3;
			}
			break;
		case 3:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				CAMERA_stageIntroduction = new Vector3(0f - DefaultDistance + stageLength, 1.5f, -10f);
				TIMER_stageIntroduction = Time.time + 1f;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			if (Time.time >= TIMER_stageIntroduction)
			{
				stageIntroductionState = 4;
			}
			break;
		case 4:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				CAMERA_stageIntroduction = new Vector3(0f - DefaultDistance + stageLength, 1.5f, -10f);
				TIMER_stageIntroduction = Time.time + 1f;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			if (Time.time >= TIMER_stageIntroduction)
			{
				scriptHudAddon.readyState = 0;
				stageIntroductionState = 5;
			}
			break;
		case 5:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				CAMERA_stageIntroduction = new Vector3(0f - DefaultDistance + stageLength, 1.5f, -10f);
				TIMER_stageIntroduction = Time.time + 1f;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			if (Time.time >= TIMER_stageIntroduction)
			{
				scriptHudAddon.readyState = 1;
				stageIntroductionState = 6;
			}
			break;
		case 6:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				CAMERA_stageIntroduction = new Vector3(0f - DefaultDistance + stageLength, 1.5f, -10f);
				TIMER_stageIntroduction = Time.time + 1f;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			if (Time.time >= TIMER_stageIntroduction)
			{
				scriptHudAddon.readyState = 2;
				stageIntroductionState = 7;
			}
			break;
		case 7:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				CAMERA_stageIntroduction = new Vector3(0f - DefaultDistance + stageLength, 1.5f, -10f);
				TIMER_stageIntroduction = Time.time + 1f;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			if (Time.time >= TIMER_stageIntroduction)
			{
				scriptHudAddon.readyState = 3;
				stageIntroductionState = 8;
			}
			break;
		case 8:
			if (TOGGLE_stageIntroductionState != stageIntroductionState)
			{
				GameScriptsManager.gameLogicScript.gameState = 2;
				TOGGLE_stageIntroductionState = stageIntroductionState;
			}
			break;
		}
	}

	private void LateUpdate()
	{
		switch (state)
		{
		case 0:
		{
			if (TOGGLE_state != state)
			{
				locater.active = false;
				scriptWarningNotification.Warning = false;
				setCameraPosition = 0;
				TOGGLE_state = state;
			}
			Vector3 position = myTransform.position;
			if (position.x != DefaultDistance)
			{
				myTransform.position = Vector3.Lerp(myTransform.position, new Vector3(DefaultDistance, 1.5f, -10f), Time.smoothDeltaTime * 4f);
			}
			break;
		}
		case 1:
			if (TOGGLE_state != state)
			{
				stageIntroductionState = 0;
				locater.active = false;
				scriptWarningNotification.Warning = false;
				TOGGLE_state = state;
			}
			stageIntroduction();
			break;
		case 2:
		{
			if (TOGGLE_state != state)
			{
				setCameraPosition = 0;
				TOGGLE_state = state;
			}
			int num = setCameraPosition;
			if (num == 1)
			{
				TIMER_setCameraPosition = Time.time + 1f;
				state = 5;
				setCameraPosition = 0;
			}
			if (Time.timeScale == 0f)
			{
				if (locater.active)
				{
					locater.active = false;
				}
				break;
			}
			RayAimer();
			if (myTransform.position != cameraPosition_TRACK)
			{
				//myTransform.position = Vector3.Lerp(myTransform.position, cameraPosition_TRACK, Time.smoothDeltaTime * 2f);
			}
			Vector3 localPosition4 = locater.transform.localPosition;
			float x3 = hit.distance - 5.3f;
			Vector3 localPosition5 = locater.transform.localPosition;
			if (localPosition4 != new Vector3(x3, localPosition5.y, -2f))
			{
				Transform transform2 = locater.transform;
				float x4 = hit.distance - 5.3f;
				Vector3 localPosition6 = locater.transform.localPosition;
				transform2.localPosition = new Vector3(x4, localPosition6.y, -2f);
			}
			if (cameraPosition_TRACK.x < -1.7f)
			{
				if (!scriptWarningNotification.Warning)
				{
					scriptWarningNotification.Warning = true;
				}
			}
			else if (scriptWarningNotification.Warning)
			{
				scriptWarningNotification.Warning = false;
			}
			break;
		}
		case 3:
		{
			if (TOGGLE_state != state)
			{
				TOGGLE_state = state;
			}
			Vector3 localPosition7 = locater.transform.localPosition;
			float x5 = hit.distance - 5.3f;
			Vector3 localPosition8 = locater.transform.localPosition;
			if (localPosition7 != new Vector3(x5, localPosition8.y, -2f))
			{
				Transform transform3 = locater.transform;
				float x6 = hit.distance - 5.3f;
				Vector3 localPosition9 = locater.transform.localPosition;
				transform3.localPosition = new Vector3(x6, localPosition9.y, -2f);
			}
			break;
		}
		case 4:
		{
			if (TOGGLE_state != state)
			{
				setCameraPosition = 0;
				locater.active = false;
				scriptWarningNotification.Warning = false;
				TOGGLE_state = state;
			}
			Vector3 position2 = myTransform.position;
			if (position2.x < -1f)
			{
				myTransform.Translate(myTransform.right * 2f * Time.deltaTime, Space.World);
				break;
			}
			Vector3 position3 = myTransform.position;
			if (position3.x >= -1f)
			{
				Vector3 position4 = myTransform.position;
				if (position4.x < -0.8f)
				{
					myTransform.position = Vector3.Lerp(myTransform.position, new Vector3(-0.8f, 1.5f, -10f), Time.smoothDeltaTime * 4f);
					break;
				}
			}
			Vector3 position5 = myTransform.position;
			if (position5.x >= -0.8f)
			{
				//myTransform.position = Vector3.Lerp(myTransform.position, new Vector3(-0.8f, 1.5f, -10f), Time.smoothDeltaTime * 4f);
			}
			break;
		}
		case 5:
			switch (setCameraPosition)
			{
			case 0:
				if (Time.time >= TIMER_setCameraPosition)
				{
					state = 2;
				}
				break;
			case 1:
				TIMER_setCameraPosition = Time.time + 2f;
				state = 5;
				setCameraPosition = 0;
				break;
			}
			if (cameraPosition_TRACK != new Vector3(setPositionX, 1.5f, -10f))
			{
				cameraPosition_TRACK = new Vector3(setPositionX, 1.5f, -10f);
			}
			if (Time.timeScale != 0f && myTransform.position != cameraPosition_TRACK)
			{
				//myTransform.position = Vector3.Lerp(myTransform.position, cameraPosition_TRACK, 0.15f);
			}
			if (Time.timeScale == 0f)
			{
				if (locater.active)
				{
					locater.active = false;
				}
			}
			else if (Time.timeScale == 1f)
			{
				RayAimer();
				if (myTransform.position != cameraPosition_TRACK)
				{
					//myTransform.position = Vector3.Lerp(myTransform.position, cameraPosition_TRACK, Time.smoothDeltaTime * 2f);
				}
				Vector3 localPosition = locater.transform.localPosition;
				float x = hit.distance - 5.3f;
				Vector3 localPosition2 = locater.transform.localPosition;
				if (localPosition != new Vector3(x, localPosition2.y, -2f))
				{
					Transform transform = locater.transform;
					float x2 = hit.distance - 5.3f;
					Vector3 localPosition3 = locater.transform.localPosition;
					transform.localPosition = new Vector3(x2, localPosition3.y, -2f);
				}
				if (cameraPosition_TRACK.x < -1.7f)
				{
					if (!scriptWarningNotification.Warning)
					{
						scriptWarningNotification.Warning = true;
					}
				}
				else if (scriptWarningNotification.Warning)
				{
					scriptWarningNotification.Warning = false;
				}
			}
			else if (myTransform.position != cameraPosition_TRACK)
			{
				//myTransform.position = Vector3.Lerp(myTransform.position, cameraPosition_TRACK, 0.15f);
			}
			break;
		}
	}
	public bool isObjectClciked;
    void Update()
    {

		//if (isObjectClciked)
			return;
        // Check for mouse drag start
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        // Check for mouse drag
        if (isDragging)
        {
            // Calculate the mouse movement since the last frame
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;

            // Update the camera position based on the mouse movement
            float newX = Mathf.Clamp(transform.position.x + deltaMousePosition.x * sensitivity*Time.deltaTime, minXLimit, maxXLimit);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            // Store the current mouse position for the next frame
            lastMousePosition = Input.mousePosition;
        }

        // Check for mouse drag end
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private void RayAimer()
	{
		Vector3 direction = base.transform.TransformDirection(Vector3.right);
		if (Physics.Raycast(rayPosition, direction, out hit, distance + stageLength))
		{
			if (!locater.active)
			{
				locater.active = true;
			}
			cameraPosition_TRACK = new Vector3(hit.distance - CameraDistance, 1.5f, -10f);
			if (Time.time >= DELAY_enemyDetected)
			{
				if (hit.collider.transform.name == "Unit Detector" && enemyDetected != hit.collider.transform.GetComponent<Unit_Detection>().targetObject)
				{
					enemyDetected = hit.collider.transform.GetComponent<Unit_Detection>().targetObject;
				}
				DELAY_enemyDetected = Time.time + 0.1f;
			}
		}
		else
		{
			if (locater.active)
			{
				enemyDetected = null;
				locater.active = false;
			}
			cameraPosition_TRACK = new Vector3(0f - DefaultDistance + stageLength, 1.5f, -10f);
		}
	}
}
