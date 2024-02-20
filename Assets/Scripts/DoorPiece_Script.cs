using UnityEngine;

public class DoorPiece_Script : MonoBehaviour
{
	public AudioClip BreakSound;

	public Game_Logic gameLogic;

	public bool activate;

	public GameObject Image;

	public GameObject Burst;

	public BoxCollider boxcollider;

	public float rotateSpeed;

	public float forwardSpeed = 4f;

	public float upSpeed = 1f;

	private float Delay = 0.2f;

	private float disableDelay = 1.25f;

	private float dropDelay = 1.75f;

	private float deactivateDelay = 1.8f;

	public float timer;

	private bool Active;

	private bool fallActive;

	private bool Break;

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
		if (Time.timeScale != 0f && (gameLogic.gameState == 2 || gameLogic.gameState == 4))
		{
			Duration();
		}
	}

	private void Duration()
	{
		if (gameLogic.gameState == 2)
		{
			if (!activate)
			{
				return;
			}
			if (timer == 0f)
			{
				timer = Time.time;
			}
			else if (Time.time >= timer + Delay && Time.time < timer + disableDelay)
			{
				Active = true;
			}
			else if (Time.time >= timer + disableDelay && Time.time < timer + dropDelay)
			{
				Active = false;
				fallActive = true;
			}
			else if (Time.time >= timer + dropDelay && Time.time < timer + deactivateDelay)
			{
				fallActive = false;
			}
			else if (Time.time >= timer + deactivateDelay)
			{
				Vector3 position = myTransform.position;
				if (position.y <= 0.1f)
				{
					GetComponent<Rigidbody>().isKinematic = true;
					boxcollider.enabled = false;
					activate = false;
				}
			}
			Vector3 position2 = myTransform.position;
			if (position2.y < 0.1f)
			{
				Transform transform = myTransform;
				Vector3 position3 = myTransform.position;
				float x = position3.x;
				Vector3 position4 = myTransform.position;
				transform.position = new Vector3(x, 0.1f, position4.z);
			}
			Vector3 localPosition = myTransform.localPosition;
			if (localPosition.z != 0.2f)
			{
				Transform transform2 = myTransform;
				Vector3 position5 = myTransform.position;
				float x2 = position5.x;
				Vector3 position6 = myTransform.position;
				transform2.localPosition = new Vector3(x2, position6.y, 0.2f);
			}
			if (myTransform.localRotation != Quaternion.Euler(0f, -90f, 0f))
			{
				myTransform.localRotation = Quaternion.Euler(0f, -90f, 0f);
			}
			Activated();
		}
		else if (gameLogic.gameState == 4 && myTransform.position != pastPosition)
		{
			activate = false;
			GetComponent<Rigidbody>().isKinematic = true;
			boxcollider.enabled = true;
			timer = 0f;
			Break = false;
			Active = false;
			fallActive = false;
			myTransform.position = pastPosition;
		}
	}

	private void Activated()
	{
		if (Active)
		{
			if (!Break)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(BreakSound);
				PoolManager.Pools["Effect Pool"].Spawn(Burst.transform, myTransform.position, Burst.transform.rotation);
				Break = true;
			}
			GetComponent<Rigidbody>().isKinematic = false;
			myTransform.Translate(myTransform.forward * forwardSpeed * Time.smoothDeltaTime, Space.World);
			myTransform.Translate(myTransform.up * (upSpeed + 2f) * Time.smoothDeltaTime, Space.World);
			Image.transform.Rotate(0f, 0f, rotateSpeed);
		}
		else if (fallActive)
		{
			myTransform.Translate(myTransform.forward * forwardSpeed / 2f * Time.smoothDeltaTime, Space.World);
			Image.transform.Rotate(0f, 0f, rotateSpeed / 2f);
		}
	}
}
