using UnityEngine;

public class Spell_Caster_Control : MonoBehaviour
{
	private Vector3 rightPosition;

	private Vector3 leftPosition;

	private string characterSpellID;

	public int spellColor;

	public int spellType;

	public int indicatorType;

	public float spellDirection;

	public float centreSpellTypeHeight;

	public AudioClip spellActivateSound;

	public GameObject spellEffect;

	public GameObject magicCicle;

	public GameObject magicShine;

	public GameObject indicator;

	public GameObject arrowTop;

	public GameObject arrowBottom;

	public GameObject highlightSquare;

	public GameObject highlightCircle;

	public tk2dSprite[] sprite;

	private float duration = 20f;

	private float pickUpDamping = 0.15f;

	private float durTimer;

	private Vector3 screenPosition;

	public Vector3 MousePos;

	private int state;

	private string poolName;

	private float stageLength;

	private Transform myTransform;

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void OnSpawned()
	{
		stageLength = GameScriptsManager.masterControlScript.stageLength;
		durTimer = Time.time;
		GetComponent<Rigidbody>().isKinematic = true;
	}

	private void OnDespawned()
	{
		state = 0;
		sprite[0].color = new Color(0f, 0f, 0f, 0f);
		sprite[1].color = new Color(0f, 0f, 0f, 0f);
		sprite[2].color = new Color(0f, 0f, 0f, 0f);
		sprite[3].color = new Color(0f, 0f, 0f, 0f);
		sprite[4].color = new Color(0f, 0f, 0f, 0f);
		sprite[5].color = new Color(0f, 0f, 0f, 0f);
	}

	private void HUDSetup()
	{
		indicator.transform.localPosition = new Vector3(6.5f, 0f, 0f);
		magicCicle.transform.localPosition = new Vector3(7.1f, 0f, 0f);
		magicShine.transform.localPosition = new Vector3(7f, 0f, 0f);
		indicator.transform.localRotation = Quaternion.Euler(0f, 90f, spellDirection);
		switch (indicatorType)
		{
		case -1:
			arrowTop.GetComponent<Renderer>().enabled = false;
			arrowBottom.GetComponent<Renderer>().enabled = false;
			highlightSquare.GetComponent<Renderer>().enabled = false;
			highlightCircle.GetComponent<Renderer>().enabled = false;
			break;
		case 0:
			arrowTop.GetComponent<Renderer>().enabled = false;
			arrowBottom.GetComponent<Renderer>().enabled = false;
			highlightSquare.GetComponent<Renderer>().enabled = false;
			highlightCircle.GetComponent<Renderer>().enabled = true;
			break;
		case 1:
			arrowTop.GetComponent<Renderer>().enabled = false;
			arrowBottom.GetComponent<Renderer>().enabled = true;
			highlightSquare.GetComponent<Renderer>().enabled = false;
			highlightCircle.GetComponent<Renderer>().enabled = true;
			break;
		case 2:
			arrowTop.GetComponent<Renderer>().enabled = true;
			arrowBottom.GetComponent<Renderer>().enabled = false;
			highlightSquare.GetComponent<Renderer>().enabled = false;
			highlightCircle.GetComponent<Renderer>().enabled = true;
			break;
		case 3:
			arrowTop.GetComponent<Renderer>().enabled = false;
			arrowBottom.GetComponent<Renderer>().enabled = true;
			highlightSquare.GetComponent<Renderer>().enabled = true;
			highlightCircle.GetComponent<Renderer>().enabled = false;
			break;
		case 4:
			arrowTop.GetComponent<Renderer>().enabled = true;
			arrowBottom.GetComponent<Renderer>().enabled = false;
			highlightSquare.GetComponent<Renderer>().enabled = true;
			highlightCircle.GetComponent<Renderer>().enabled = false;
			break;
		}
	}

	private void SpellData()
	{
		switch (spellColor)
		{
		case 0:
			poolName = "Spell Pool";
			break;
		case 1:
			poolName = "Spell Pool";
			break;
		case 2:
			poolName = "Spell Pool";
			break;
		case 3:
			poolName = "Spell Pool";
			break;
		case 4:
			poolName = "Item Pool";
			break;
		case 5:
			poolName = "Item Pool";
			break;
		}
		switch (spellColor)
		{
		case 0:
			sprite[0].color = new Color(1f, 0.5f, 0.5f, 0.85f);
			sprite[1].color = new Color(1f, 0f, 0f, 0.4f);
			sprite[2].color = new Color(1f, 0f, 0f, 0.4f);
			sprite[3].color = new Color(1f, 0f, 0f, 1f);
			sprite[4].color = new Color(1f, 0f, 0f, 1f);
			sprite[5].color = new Color(1f, 0f, 0f, 1f);
			break;
		case 1:
			sprite[0].color = new Color(0.5f, 0.85f, 1f, 0.85f);
			sprite[1].color = new Color(0f, 1f, 1f, 0.4f);
			sprite[2].color = new Color(0f, 1f, 1f, 0.4f);
			sprite[3].color = new Color(0f, 0.45f, 1f, 1f);
			sprite[4].color = new Color(0f, 0.45f, 1f, 1f);
			sprite[5].color = new Color(0f, 0.45f, 1f, 1f);
			break;
		case 2:
			sprite[0].color = new Color(1f, 1f, 0.5f, 0.85f);
			sprite[1].color = new Color(1f, 1f, 0f, 0.4f);
			sprite[2].color = new Color(1f, 1f, 0f, 0.4f);
			sprite[3].color = new Color(1f, 1f, 0f, 1f);
			sprite[4].color = new Color(1f, 1f, 0f, 1f);
			sprite[5].color = new Color(1f, 1f, 0f, 1f);
			break;
		case 3:
			sprite[0].color = new Color(0.5f, 1f, 0.5f, 0.85f);
			sprite[1].color = new Color(0f, 1f, 0f, 0.4f);
			sprite[2].color = new Color(0f, 1f, 0f, 0.4f);
			sprite[3].color = new Color(0f, 1f, 0f, 1f);
			sprite[4].color = new Color(0f, 1f, 0f, 1f);
			sprite[5].color = new Color(0f, 1f, 0f, 1f);
			break;
		case 4:
			sprite[0].color = new Color(1f, 1f, 0.55f, 0.85f);
			sprite[1].color = new Color(1f, 1f, 0.55f, 0.4f);
			sprite[2].color = new Color(1f, 1f, 0.55f, 0.4f);
			sprite[3].color = new Color(1f, 0.5f, 0f, 1f);
			sprite[4].color = new Color(1f, 0.5f, 0f, 1f);
			sprite[5].color = new Color(1f, 0.5f, 0f, 1f);
			break;
		case 5:
			sprite[0].color = new Color(0.25f, 0.25f, 0.75f, 0.5f);
			sprite[1].color = new Color(0.5f, 0.5f, 0.75f, 0.4f);
			sprite[2].color = new Color(0.5f, 0.5f, 0.75f, 0.4f);
			sprite[3].color = new Color(0.5f, 0.5f, 0.75f, 1f);
			sprite[4].color = new Color(0.5f, 0.5f, 0.75f, 1f);
			sprite[5].color = new Color(0.5f, 0.5f, 0.75f, 1f);
			break;
		}
	}

	public void SpellActivate(int toggle, int typeColor, int typeSpellControl, int typeIndicator, float arrowDirection, float centreHeight, AudioClip audio, GameObject effect)
	{
		if (toggle == 1)
		{
			spellColor = typeColor;
			spellType = typeSpellControl;
			indicatorType = typeIndicator;
			spellDirection = arrowDirection;
			centreSpellTypeHeight = centreHeight;
			spellActivateSound = audio;
			spellEffect = effect;
			state = 1;
		}
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			break;
		case 1:
			HUDSetup();
			state++;
			break;
		case 2:
			SpellData();
			state++;
			break;
		case 3:
			SpellControl();
			Duration();
			break;
		}
	}

	private void SpellControl()
	{
		screenPosition = Camera.main.WorldToScreenPoint(myTransform.position);
		screenPosition.y = (float)Screen.height - screenPosition.y;
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			switch (spellType)
			{
			case -1:
			{
				Vector3 point7 = hitInfo.point;
				if (point7.y <= 0.25f)
				{
					Vector3 point8 = hitInfo.point;
					float x3 = point8.x;
					Vector3 position5 = myTransform.position;
					MousePos = new Vector3(x3, 0.25f, position5.z);
				}
				else
				{
					Vector3 point9 = hitInfo.point;
					if (point9.y >= 3.75f)
					{
						Vector3 point10 = hitInfo.point;
						float x4 = point10.x;
						Vector3 position6 = myTransform.position;
						MousePos = new Vector3(x4, 3.75f, position6.z);
					}
					else
					{
						Vector3 point11 = hitInfo.point;
						if (point11.y >= 0.25f)
						{
							Vector3 point12 = hitInfo.point;
							if (point12.y <= 3.75f)
							{
								Vector3 point13 = hitInfo.point;
								float x5 = point13.x;
								Vector3 point14 = hitInfo.point;
								MousePos = new Vector3(x5, point14.y, 0f);
							}
						}
					}
				}
				Vector3 point15 = hitInfo.point;
				if (point15.x <= -2.25f)
				{
					MousePos = new Vector3(-2.25f, MousePos.y, 0f);
					break;
				}
				Vector3 point16 = hitInfo.point;
				if (point16.x >= 5f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point17 = hitInfo.point;
				if (point17.x > -2.25f)
				{
					Vector3 point18 = hitInfo.point;
					if (point18.x < 5f + stageLength)
					{
						Vector3 point19 = hitInfo.point;
						MousePos = new Vector3(point19.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 0:
			{
				Transform transform3 = myTransform;
				Vector3 position11 = myTransform.position;
				transform3.position = new Vector3(position11.x, centreSpellTypeHeight, -0.5f);
				Vector3 point33 = hitInfo.point;
				float x10 = point33.x;
				Vector3 position12 = myTransform.position;
				MousePos = new Vector3(x10, position12.y, 0f);
				Vector3 point34 = hitInfo.point;
				if (point34.x <= -2.25f)
				{
					MousePos = new Vector3(-2.25f, MousePos.y, 0f);
					break;
				}
				Vector3 point35 = hitInfo.point;
				if (point35.x >= 5f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point36 = hitInfo.point;
				if (point36.x > -2.25f)
				{
					Vector3 point37 = hitInfo.point;
					if (point37.x < 5f + stageLength)
					{
						Vector3 point38 = hitInfo.point;
						MousePos = new Vector3(point38.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 1:
			{
				Transform transform4 = myTransform;
				Vector3 position13 = myTransform.position;
				transform4.position = new Vector3(position13.x, 0.1f, 0f);
				Vector3 point39 = hitInfo.point;
				float x11 = point39.x;
				Vector3 position14 = myTransform.position;
				MousePos = new Vector3(x11, position14.y, 0f);
				Vector3 point40 = hitInfo.point;
				if (point40.x <= -2.25f)
				{
					MousePos = new Vector3(-2.25f, MousePos.y, 0f);
					break;
				}
				Vector3 point41 = hitInfo.point;
				if (point41.x >= 5f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point42 = hitInfo.point;
				if (point42.x > -2.25f)
				{
					Vector3 point43 = hitInfo.point;
					if (point43.x < 5f + stageLength)
					{
						Vector3 point44 = hitInfo.point;
						MousePos = new Vector3(point44.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 2:
			{
				Transform transform2 = myTransform;
				Vector3 position3 = myTransform.position;
				transform2.position = new Vector3(position3.x, 4f, -0.5f);
				Vector3 point = hitInfo.point;
				float x2 = point.x;
				Vector3 position4 = myTransform.position;
				MousePos = new Vector3(x2, position4.y, 0f);
				Vector3 point2 = hitInfo.point;
				if (point2.x <= -2.25f)
				{
					MousePos = new Vector3(-2.25f, MousePos.y, 0f);
					break;
				}
				Vector3 point3 = hitInfo.point;
				if (point3.x >= 5f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point4 = hitInfo.point;
				if (point4.x > -2.25f)
				{
					Vector3 point5 = hitInfo.point;
					if (point5.x < 5f + stageLength)
					{
						Vector3 point6 = hitInfo.point;
						MousePos = new Vector3(point6.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 3:
			{
				Vector3 vector2 = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));
				float x19 = vector2.x - 0.75f;
				Vector3 position25 = myTransform.position;
				float y2 = position25.y;
				Vector3 position26 = myTransform.position;
				rightPosition = new Vector3(x19, y2, position26.z);
				Vector3 point50 = hitInfo.point;
				if (point50.y <= 0.25f)
				{
					Transform transform8 = myTransform;
					float x20 = rightPosition.x + 0.5f;
					Vector3 position27 = myTransform.position;
					transform8.position = new Vector3(x20, position27.y, 0f);
					Vector3 position28 = myTransform.position;
					float x21 = position28.x;
					Vector3 position29 = myTransform.position;
					MousePos = new Vector3(x21, 0.25f, position29.z);
				}
				else
				{
					Vector3 point51 = hitInfo.point;
					if (point51.y >= 3.75f)
					{
						Transform transform9 = myTransform;
						float x22 = rightPosition.x + 0.5f;
						Vector3 position30 = myTransform.position;
						transform9.position = new Vector3(x22, position30.y, 0f);
						Vector3 position31 = myTransform.position;
						float x23 = position31.x;
						Vector3 position32 = myTransform.position;
						MousePos = new Vector3(x23, 3.75f, position32.z);
					}
				}
				Vector3 point52 = hitInfo.point;
				if (point52.y >= 0.25f)
				{
					Vector3 point53 = hitInfo.point;
					if (point53.y <= 3.75f)
					{
						Transform transform10 = myTransform;
						float x24 = rightPosition.x + 0.5f;
						Vector3 position33 = myTransform.position;
						transform10.position = new Vector3(x24, position33.y, 0f);
						Vector3 position34 = myTransform.position;
						float x25 = position34.x;
						Vector3 point54 = hitInfo.point;
						MousePos = new Vector3(x25, point54.y, 0f);
					}
				}
				break;
			}
			case 4:
			{
				Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
				float x12 = vector.x + 0.75f;
				Vector3 position15 = myTransform.position;
				float y = position15.y;
				Vector3 position16 = myTransform.position;
				leftPosition = new Vector3(x12, y, position16.z);
				Vector3 point45 = hitInfo.point;
				if (point45.y <= 0.25f)
				{
					Transform transform5 = myTransform;
					float x13 = leftPosition.x - 0.5f;
					Vector3 position17 = myTransform.position;
					transform5.position = new Vector3(x13, position17.y, 0f);
					Vector3 position18 = myTransform.position;
					float x14 = position18.x;
					Vector3 position19 = myTransform.position;
					MousePos = new Vector3(x14, 0.25f, position19.z);
				}
				else
				{
					Vector3 point46 = hitInfo.point;
					if (point46.y >= 3.75f)
					{
						Transform transform6 = myTransform;
						float x15 = leftPosition.x - 0.5f;
						Vector3 position20 = myTransform.position;
						transform6.position = new Vector3(x15, position20.y, 0f);
						Vector3 position21 = myTransform.position;
						float x16 = position21.x;
						Vector3 position22 = myTransform.position;
						MousePos = new Vector3(x16, 3.75f, position22.z);
					}
				}
				Vector3 point47 = hitInfo.point;
				if (point47.y >= 0.25f)
				{
					Vector3 point48 = hitInfo.point;
					if (point48.y <= 3.75f)
					{
						Transform transform7 = myTransform;
						float x17 = leftPosition.x - 0.5f;
						Vector3 position23 = myTransform.position;
						transform7.position = new Vector3(x17, position23.y, 0f);
						Vector3 position24 = myTransform.position;
						float x18 = position24.x;
						Vector3 point49 = hitInfo.point;
						MousePos = new Vector3(x18, point49.y, 0f);
					}
				}
				break;
			}
			case 5:
			{
				if (GameScriptsManager.gameStatisticScript.closesIntruder != null)
				{
					Vector3 position7 = GameScriptsManager.gameStatisticScript.closesIntruder.transform.position;
					float x6 = position7.x;
					Vector3 position8 = GameScriptsManager.gameStatisticScript.closesIntruder.transform.position;
					MousePos = new Vector3(x6, position8.y, 0f);
					break;
				}
				Vector3 point20 = hitInfo.point;
				if (point20.y <= 0.25f)
				{
					Vector3 point21 = hitInfo.point;
					float x7 = point21.x;
					Vector3 position9 = myTransform.position;
					MousePos = new Vector3(x7, 0.25f, position9.z);
				}
				else
				{
					Vector3 point22 = hitInfo.point;
					if (point22.y >= 3.75f)
					{
						Vector3 point23 = hitInfo.point;
						float x8 = point23.x;
						Vector3 position10 = myTransform.position;
						MousePos = new Vector3(x8, 3.75f, position10.z);
					}
					else
					{
						Vector3 point24 = hitInfo.point;
						if (point24.y >= 0.25f)
						{
							Vector3 point25 = hitInfo.point;
							if (point25.y <= 3.75f)
							{
								Vector3 point26 = hitInfo.point;
								float x9 = point26.x;
								Vector3 point27 = hitInfo.point;
								MousePos = new Vector3(x9, point27.y, 0f);
							}
						}
					}
				}
				Vector3 point28 = hitInfo.point;
				if (point28.x <= -2.25f)
				{
					MousePos = new Vector3(-2.25f, MousePos.y, 0f);
					break;
				}
				Vector3 point29 = hitInfo.point;
				if (point29.x >= 5f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point30 = hitInfo.point;
				if (point30.x > -2.25f)
				{
					Vector3 point31 = hitInfo.point;
					if (point31.x < 5f + stageLength)
					{
						Vector3 point32 = hitInfo.point;
						MousePos = new Vector3(point32.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 6:
				if (GameScriptsManager.gameStatisticScript.closesIntruder != null)
				{
					Transform transform = myTransform;
					Vector3 position = GameScriptsManager.gameStatisticScript.closesIntruder.transform.position;
					float x = position.x;
					Vector3 position2 = GameScriptsManager.gameStatisticScript.closesIntruder.transform.position;
					transform.position = new Vector3(x, position2.y, 0f);
				}
				Break();
				break;
			case 7:
				Break();
				break;
			}
		}
		if (spellType >= 6)
		{
			return;
		}
		if (GameScriptsManager.gameLogicScript.gameState == 2)
		{
			myTransform.position = Vector3.Lerp(myTransform.position, MousePos, pickUpDamping);
			if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
			{
				Break();
			}
		}
		else
		{
			PoolManager.Pools[poolName].Despawn(myTransform);
		}
	}

	private void Duration()
	{
		if (Time.time >= durTimer + duration)
		{
			Break();
		}
	}

	private void Break()
	{
		GameScriptsManager.audioSourceA.GetComponent<AudioSource>().PlayOneShot(spellActivateSound);
		switch (spellColor)
		{
		case 0:
			GameScriptsManager.gameStatisticScript.characterAnimationNumber = 8;
			break;
		case 1:
			GameScriptsManager.gameStatisticScript.characterAnimationNumber = 10;
			break;
		case 2:
			GameScriptsManager.gameStatisticScript.characterAnimationNumber = 12;
			break;
		case 3:
			GameScriptsManager.gameStatisticScript.characterAnimationNumber = 14;
			break;
		case 4:
			GameScriptsManager.gameStatisticScript.characterAnimationNumber = 17;
			break;
		case 5:
			GameScriptsManager.gameStatisticScript.characterAnimationNumber = 15;
			break;
		}
		if (spellEffect != null)
		{
			PoolManager.Pools[poolName].Spawn(spellEffect.transform, myTransform.position, spellEffect.transform.rotation);
		}
		PoolManager.Pools[poolName].Despawn(myTransform);
	}
}
