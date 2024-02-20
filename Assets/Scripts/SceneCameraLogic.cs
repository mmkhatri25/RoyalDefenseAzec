using UnityEngine;

public class SceneCameraLogic : MonoBehaviour
{
	public Scene_Logic sceneLogic;

	private int sceneNumber;

	public float movementSpeed;

	public int moveForward;

	public int moveUp;

	private Vector3 newPosition;

	private int moveDirectionX;

	private int moveDirectionY;

	private void Start()
	{
		if (sceneLogic == null)
		{
			sceneLogic = GameObject.Find("Scene Logic").GetComponent<Scene_Logic>();
		}
		newPosition = base.transform.localPosition;
	}

	private void Update()
	{
		Movement();
	}

	private void Movement()
	{
		if (sceneNumber != sceneLogic.sceneNumber)
		{
			base.transform.localPosition = newPosition;
			sceneNumber = sceneLogic.sceneNumber;
		}
		if (moveForward != 0 || moveUp != 0)
		{
			Vector3 localPosition = base.transform.localPosition;
			float x = localPosition.x - 0.5f * (float)moveForward;
			Vector3 localPosition2 = base.transform.localPosition;
			float y = localPosition2.y + 0.5f * (float)moveUp;
			Vector3 localPosition3 = base.transform.localPosition;
			newPosition = new Vector3(x, y, localPosition3.z);
			if (moveForward < 0)
			{
				moveDirectionX = 0;
			}
			else if (moveForward > 0)
			{
				moveDirectionX = 1;
			}
			if (moveUp < 0)
			{
				moveDirectionY = 1;
			}
			else if (moveUp > 0)
			{
				moveDirectionY = 0;
			}
			moveForward = 0;
			moveUp = 0;
		}
		if (!(base.transform.localPosition != newPosition))
		{
			return;
		}
		if (moveDirectionX == 1)
		{
			Vector3 localPosition4 = base.transform.localPosition;
			if (localPosition4.x > newPosition.x)
			{
				base.transform.Translate(base.transform.right * (0f - movementSpeed) * Time.smoothDeltaTime, Space.World);
			}
			else
			{
				Vector3 localPosition5 = base.transform.localPosition;
				if (localPosition5.x <= newPosition.x)
				{
					Transform transform = base.transform;
					float x2 = newPosition.x;
					Vector3 localPosition6 = base.transform.localPosition;
					float y2 = localPosition6.y;
					Vector3 localPosition7 = base.transform.localPosition;
					transform.localPosition = new Vector3(x2, y2, localPosition7.z);
				}
			}
		}
		else
		{
			Vector3 localPosition8 = base.transform.localPosition;
			if (localPosition8.x < newPosition.x)
			{
				base.transform.Translate(base.transform.right * movementSpeed * Time.smoothDeltaTime, Space.World);
			}
			else
			{
				Vector3 localPosition9 = base.transform.localPosition;
				if (localPosition9.x >= newPosition.x)
				{
					Transform transform2 = base.transform;
					float x3 = newPosition.x;
					Vector3 localPosition10 = base.transform.localPosition;
					float y3 = localPosition10.y;
					Vector3 localPosition11 = base.transform.localPosition;
					transform2.localPosition = new Vector3(x3, y3, localPosition11.z);
				}
			}
		}
		if (moveDirectionY == 1)
		{
			Vector3 localPosition12 = base.transform.localPosition;
			if (localPosition12.y > newPosition.y)
			{
				base.transform.Translate(base.transform.up * (0f - movementSpeed) * Time.smoothDeltaTime, Space.World);
				return;
			}
			Vector3 localPosition13 = base.transform.localPosition;
			if (localPosition13.y <= newPosition.y)
			{
				Transform transform3 = base.transform;
				Vector3 localPosition14 = base.transform.localPosition;
				float x4 = localPosition14.x;
				float y4 = newPosition.y;
				Vector3 localPosition15 = base.transform.localPosition;
				transform3.localPosition = new Vector3(x4, y4, localPosition15.z);
			}
			return;
		}
		Vector3 localPosition16 = base.transform.localPosition;
		if (localPosition16.y < newPosition.y)
		{
			base.transform.Translate(base.transform.up * movementSpeed * Time.smoothDeltaTime, Space.World);
			return;
		}
		Vector3 localPosition17 = base.transform.localPosition;
		if (localPosition17.y >= newPosition.y)
		{
			Transform transform4 = base.transform;
			Vector3 localPosition18 = base.transform.localPosition;
			float x5 = localPosition18.x;
			float y5 = newPosition.y;
			Vector3 localPosition19 = base.transform.localPosition;
			transform4.localPosition = new Vector3(x5, y5, localPosition19.z);
		}
	}
}
