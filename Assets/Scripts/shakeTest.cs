using UnityEngine;

public class shakeTest : MonoBehaviour
{
	public bool collapse;

	public float collapseDelay = 10f;

	public bool TOGGLE_collapse;

	public float TIMER_collapseDelay;

	public GameObject unitSprite;

	public Vector3 VECTOR_originalPosition;

	public int shakeDirection;

	public float shakeSpeed;

	private void Start()
	{
		VECTOR_originalPosition = unitSprite.transform.localPosition;
	}

	private void Update()
	{
		if (collapse)
		{
			unitSprite.transform.localPosition = VECTOR_originalPosition;
			TIMER_collapseDelay = Time.time + collapseDelay;
			shakeSpeed = 0f;
			shakeDirection = 0;
			TOGGLE_collapse = true;
			collapse = false;
		}
		if (TOGGLE_collapse)
		{
			if (Time.time < TIMER_collapseDelay)
			{
				shakeFunction();
			}
			else if (Time.time >= TIMER_collapseDelay)
			{
				unitSprite.transform.localPosition = VECTOR_originalPosition;
				TOGGLE_collapse = false;
			}
		}
	}

	private void shakeFunction()
	{
		if (Time.time > TIMER_collapseDelay - collapseDelay / 2f && Time.time < TIMER_collapseDelay - collapseDelay / 4f)
		{
			shakeSpeed = 0.5f;
		}
		else if (Time.time > TIMER_collapseDelay - collapseDelay / 4f && Time.time < TIMER_collapseDelay - collapseDelay / 8f)
		{
			shakeSpeed = 1f;
		}
		else if (Time.time > TIMER_collapseDelay - collapseDelay / 8f)
		{
			shakeSpeed = 2f;
		}
		if (!(shakeSpeed > 0f))
		{
			return;
		}
		if (shakeDirection == 0)
		{
			Vector3 localPosition = unitSprite.transform.localPosition;
			if (localPosition.x < 0.01f)
			{
				unitSprite.transform.Translate(unitSprite.transform.right * shakeSpeed * Time.smoothDeltaTime, Space.World);
				return;
			}
			Vector3 localPosition2 = unitSprite.transform.localPosition;
			if (localPosition2.x >= 0.01f)
			{
				Transform transform = unitSprite.transform;
				float x = VECTOR_originalPosition.x + 0.05f;
				Vector3 localPosition3 = unitSprite.transform.localPosition;
				float y = localPosition3.y;
				Vector3 localPosition4 = unitSprite.transform.localPosition;
				transform.localPosition = new Vector3(x, y, localPosition4.z);
				shakeDirection = 1;
			}
		}
		else
		{
			if (shakeDirection != 1)
			{
				return;
			}
			Vector3 localPosition5 = unitSprite.transform.localPosition;
			if (localPosition5.x > -0.01f)
			{
				unitSprite.transform.Translate(-unitSprite.transform.right * shakeSpeed * Time.smoothDeltaTime, Space.World);
				return;
			}
			Vector3 localPosition6 = unitSprite.transform.localPosition;
			if (localPosition6.x <= -0.01f)
			{
				Transform transform2 = unitSprite.transform;
				float x2 = VECTOR_originalPosition.x - 0.05f;
				Vector3 localPosition7 = unitSprite.transform.localPosition;
				float y2 = localPosition7.y;
				Vector3 localPosition8 = unitSprite.transform.localPosition;
				transform2.localPosition = new Vector3(x2, y2, localPosition8.z);
				shakeDirection = 0;
			}
		}
	}
}
