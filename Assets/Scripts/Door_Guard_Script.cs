using UnityEngine;

public class Door_Guard_Script : MonoBehaviour
{
	public Game_Logic gameLogic;

	public bool activate;

	public SpriteAnim_Script Model;

	public float retreatSpeed = 2f;

	public float zPosition;

	public float delay = 10f;

	private bool retreat;

	private bool Out;

	private float timer;

	private Vector3 pastPosition;

	private Transform myTransform;

	private void Start()
	{
		myTransform = base.transform;
		Vector3 localPosition = base.transform.localPosition;
		float x = localPosition.x + GameScriptsManager.masterControlScript.stageLength;
		Vector3 localPosition2 = base.transform.localPosition;
		float y = localPosition2.y;
		Vector3 localPosition3 = base.transform.localPosition;
		pastPosition = new Vector3(x, y, localPosition3.z);
		myTransform.position = pastPosition;
	}

	private void Update()
	{
		Vector3 localPosition = myTransform.localPosition;
		if (localPosition.z != zPosition)
		{
			Transform transform = myTransform;
			Vector3 position = myTransform.position;
			float x = position.x;
			Vector3 position2 = myTransform.position;
			transform.localPosition = new Vector3(x, position2.y, zPosition);
		}
		if (Time.timeScale != 0f)
		{
			Duration();
		}
	}

	private void Duration()
	{
		if (gameLogic.gameState == 2)
		{
			if (activate)
			{
				if (timer == 0f)
				{
					timer = Time.time;
				}
				else if (Time.time < timer + delay)
				{
					Model.animation2 = true;
				}
				else if (Time.time >= timer + delay)
				{
					retreat = true;
					activate = false;
				}
			}
			if (!Out)
			{
				Retreat();
			}
		}
		else if (gameLogic.gameState == 4)
		{
			activate = false;
			Model.animation2 = true;
			myTransform.position = pastPosition;
			timer = 0f;
			retreat = false;
			Out = false;
		}
	}

	private void Retreat()
	{
		if (retreat)
		{
			Model.animation3 = true;
			if (!Out)
			{
				myTransform.Translate(-myTransform.forward * retreatSpeed * Time.deltaTime, Space.World);
			}
		}
		Vector3 position = myTransform.position;
		if (position.x < -7f)
		{
			Out = true;
			Model.animation1 = true;
		}
	}
}
