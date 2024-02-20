using UnityEngine;

public class Pickup_Script : MonoBehaviour
{
	public AudioClip AppearSound;

	public AudioClip ClickSound;

	private Game_Logic gameLogic;

	private Game_Statistics gameStatistic;

	public SpriteAnim_Script sprite;

	private string spawnPoolName = "Pickup Pool";

	public float disappearTime = 100f;

	private float pickupTimer;

	private float warningTime = 50f;

	public float ManaValue;

	private Transform destination;

	public float speed;

	public bool Obtain;

	private Transform myTransform;

	private int popState;

	private int dropFunctionState;

	private float dropFunctionVelocityX;

	private float dropFunctionVelocityY;

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		gameLogic = GameScriptsManager.gameLogicScript;
		gameStatistic = GameScriptsManager.gameStatisticScript;
		destination = GameObject.Find("ManaPool").transform;
		warningTime = disappearTime / 3f * 2f;
	}

	private void OnSpawned()
	{
		if (gameLogic == null)
		{
			gameLogic = GameScriptsManager.gameLogicScript;
		}
		pickupTimer = Time.time;
		sprite.animation1 = true;
		Obtain = false;
		dropFunctionState = 0;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(AppearSound);
		popState = 0;
	}

	private void OnDespawned()
	{
		pickupTimer = 0f;
	}

	private void PopEffect()
	{
		switch (popState)
		{
		case 2:
			break;
		case 0:
		{
			Vector3 localScale3 = myTransform.localScale;
			if (localScale3.x < 2f)
			{
				myTransform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
				break;
			}
			Vector3 localScale4 = myTransform.localScale;
			if (localScale4.x >= 2f)
			{
				popState++;
			}
			break;
		}
		case 1:
		{
			Vector3 localScale = myTransform.localScale;
			if (localScale.x > 1f)
			{
				myTransform.localScale += new Vector3(-0.2f, -0.2f, -0.2f);
				break;
			}
			Vector3 localScale2 = myTransform.localScale;
			if (localScale2.x <= 1f)
			{
				myTransform.localScale = new Vector3(1f, 1f, 1f);
				popState++;
			}
			break;
		}
		}
	}

	private void Update()
	{
		if (myTransform.localRotation != Quaternion.Euler(0f, -180f, 0f))
		{
			myTransform.localRotation = Quaternion.Euler(0f, -180f, 0f);
		}
		PopEffect();
		Grab();
		if (gameLogic.gameState == 2 && Time.timeScale != 0f && !Obtain)
		{
			if (gameStatistic.shardPickUp == 0)
			{
				mouseclick();
			}
			if (disappearTime != 0f)
			{
				if (Time.time < pickupTimer + disappearTime)
				{
					if (Time.time > pickupTimer + warningTime)
					{
						sprite.animation2 = true;
					}
				}
				else if (Time.time >= pickupTimer + disappearTime)
				{
					PoolManager.Pools[spawnPoolName].Despawn(base.transform);
				}
			}
		}
		if (!Obtain)
		{
			Vector3 position = myTransform.position;
			if ((double)position.y <= 0.25)
			{
				Transform transform = myTransform;
				Vector3 position2 = base.transform.position;
				transform.position = new Vector3(position2.x, 0.25f, -1f);
			}
			else
			{
				Vector3 position3 = myTransform.position;
				if ((double)position3.y > 0.25)
				{
					DropFunction();
				}
			}
		}
		if (gameLogic.gameState == 4)
		{
			PoolManager.Pools[spawnPoolName].Despawn(base.transform);
		}
	}

	private void Grab()
	{
		if (!Obtain)
		{
			return;
		}
		sprite.animation1 = true;
		Vector3 position = myTransform.position;
		float x = position.x;
		Vector3 position2 = destination.position;
		if (x < position2.x + 0.2f)
		{
			Vector3 position3 = myTransform.position;
			float x2 = position3.x;
			Vector3 position4 = destination.position;
			if (x2 > position4.x - 0.2f)
			{
				Vector3 position5 = myTransform.position;
				float y = position5.y;
				Vector3 position6 = destination.position;
				if (y < position6.y + 0.2f)
				{
					Vector3 position7 = myTransform.position;
					float y2 = position7.y;
					Vector3 position8 = destination.position;
					if (y2 > position8.y - 0.2f)
					{
						gameStatistic.scoreShardsCollected++;
						gameStatistic.manaNumber += Mathf.RoundToInt(ManaValue);
						PoolManager.Pools[spawnPoolName].Despawn(base.transform);
						return;
					}
				}
			}
		}
		myTransform.position = Vector3.Lerp(myTransform.position, destination.position, Time.deltaTime * speed);
	}

	private void DropFunction()
	{
		switch (dropFunctionState)
		{
		case 0:
			dropFunctionVelocityX = UnityEngine.Random.Range(-2, 2);
			dropFunctionVelocityY = UnityEngine.Random.Range(6, 8);
			dropFunctionState++;
			break;
		case 1:
			myTransform.Translate(myTransform.right * dropFunctionVelocityX * Time.smoothDeltaTime, Space.World);
			if (dropFunctionVelocityY > -40f)
			{
				dropFunctionVelocityY -= 0.6f;
				myTransform.Translate(myTransform.up * dropFunctionVelocityY * Time.smoothDeltaTime, Space.World);
			}
			else if (dropFunctionVelocityY <= -40f)
			{
				dropFunctionVelocityY = -40f;
				myTransform.Translate(myTransform.up * dropFunctionVelocityY * Time.smoothDeltaTime, Space.World);
			}
			break;
		}
	}

	private void mouseclick()
	{
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		Vector3 vector = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float x = vector.x;
		Vector3 position = myTransform.position;
		if (!(x < position.x + 0.4f))
		{
			return;
		}
		Vector3 vector2 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float x2 = vector2.x;
		Vector3 position2 = myTransform.position;
		if (!(x2 > position2.x - 0.4f))
		{
			return;
		}
		Vector3 vector3 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float y = vector3.y;
		Vector3 position3 = myTransform.position;
		if (y < position3.y + 0.8f)
		{
			Vector3 vector4 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
			float y2 = vector4.y;
			Vector3 position4 = myTransform.position;
			if (y2 > position4.y - 0.4f)
			{
				gameStatistic.shardPickUp++;
				Camera.main.GetComponent<AudioSource>().PlayOneShot(ClickSound);
				Obtain = true;
			}
		}
	}
}
