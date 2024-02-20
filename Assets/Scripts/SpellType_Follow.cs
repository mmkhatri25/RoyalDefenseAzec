using UnityEngine;

public class SpellType_Follow : MonoBehaviour
{
	private Game_Logic gameLogic;

	private Vector3 rightPosition;

	private Vector3 leftPosition;

	public int spellFollowType;

	public float centreSpellTypeHeight;

	public float duration = 20f;

	public float followDamping = 0.15f;

	public Vector3 spellSize;

	private float durTimer;

	private Vector3 screenPosition;

	public Vector3 MousePos;

	private int state;

	public string poolName;

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
		gameLogic = GameScriptsManager.gameLogicScript;
		durTimer = Time.time;
		GetComponent<Rigidbody>().isKinematic = true;
		GameScriptsManager.gameStatisticScript.objectLevitating = -1;
	}

	private void OnDespawned()
	{
		state = 0;
		GameScriptsManager.gameStatisticScript.objectLevitating = 0;
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			state++;
			break;
		case 1:
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
			switch (spellFollowType)
			{
			case -1:
			{
				Vector3 point36 = hitInfo.point;
				if (point36.y <= 0.25f + spellSize.y / 2f)
				{
					Vector3 point37 = hitInfo.point;
					float x21 = point37.x;
					float y5 = 0.25f + spellSize.y / 2f;
					Vector3 position29 = myTransform.position;
					MousePos = new Vector3(x21, y5, position29.z);
				}
				else
				{
					Vector3 point38 = hitInfo.point;
					if (point38.y >= 3.75f - spellSize.y / 2f)
					{
						Vector3 point39 = hitInfo.point;
						float x22 = point39.x;
						float y6 = 3.75f - spellSize.y / 2f;
						Vector3 position30 = myTransform.position;
						MousePos = new Vector3(x22, y6, position30.z);
					}
					else
					{
						Vector3 point40 = hitInfo.point;
						if (point40.y >= 0.25f + spellSize.y / 2f)
						{
							Vector3 point41 = hitInfo.point;
							if (point41.y <= 3.75f - spellSize.y / 2f)
							{
								Vector3 point42 = hitInfo.point;
								float x23 = point42.x;
								Vector3 point43 = hitInfo.point;
								MousePos = new Vector3(x23, point43.y, 0f);
							}
						}
					}
				}
				Vector3 point44 = hitInfo.point;
				if (point44.x <= -2.25f + spellSize.x / 2f)
				{
					MousePos = new Vector3(-2.25f + spellSize.x / 2f, MousePos.y, 0f);
					break;
				}
				Vector3 point45 = hitInfo.point;
				if (point45.x >= 5f - spellSize.x / 2f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point46 = hitInfo.point;
				if (point46.x > -2.25f + spellSize.x / 2f)
				{
					Vector3 point47 = hitInfo.point;
					if (point47.x < 5f - spellSize.x / 2f + stageLength)
					{
						Vector3 point48 = hitInfo.point;
						MousePos = new Vector3(point48.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 0:
			{
				Transform transform = myTransform;
				Vector3 position5 = myTransform.position;
				transform.position = new Vector3(position5.x, centreSpellTypeHeight, -0.5f);
				Vector3 point14 = hitInfo.point;
				float x5 = point14.x;
				Vector3 position6 = myTransform.position;
				MousePos = new Vector3(x5, position6.y, 0f);
				Vector3 point15 = hitInfo.point;
				if (point15.x <= -2.25f + spellSize.x / 2f)
				{
					MousePos = new Vector3(-2.25f + spellSize.x / 2f, MousePos.y, 0f);
					break;
				}
				Vector3 point16 = hitInfo.point;
				if (point16.x >= 5f - spellSize.x / 2f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point17 = hitInfo.point;
				if (point17.x > -2.25f + spellSize.x / 2f)
				{
					Vector3 point18 = hitInfo.point;
					if (point18.x < 5f - spellSize.x / 2f + stageLength)
					{
						Vector3 point19 = hitInfo.point;
						MousePos = new Vector3(point19.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 1:
			{
				Transform transform2 = myTransform;
				Vector3 position7 = myTransform.position;
				transform2.position = new Vector3(position7.x, 0.1f + spellSize.y / 2f, 0f);
				Vector3 point20 = hitInfo.point;
				float x6 = point20.x;
				Vector3 position8 = myTransform.position;
				MousePos = new Vector3(x6, position8.y, 0f);
				Vector3 point21 = hitInfo.point;
				if (point21.x <= -2.25f + spellSize.x / 2f)
				{
					MousePos = new Vector3(-2.25f + spellSize.x / 2f, MousePos.y, 0f);
					break;
				}
				Vector3 point22 = hitInfo.point;
				if (point22.x >= 5f - spellSize.x / 2f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point23 = hitInfo.point;
				if (point23.x > -2.25f + spellSize.x / 2f)
				{
					Vector3 point24 = hitInfo.point;
					if (point24.x < 5f - spellSize.x / 2f + stageLength)
					{
						Vector3 point25 = hitInfo.point;
						MousePos = new Vector3(point25.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 2:
			{
				Transform transform9 = myTransform;
				Vector3 position31 = myTransform.position;
				transform9.position = new Vector3(position31.x, 4f - spellSize.y / 2f, -0.5f);
				Vector3 point49 = hitInfo.point;
				float x24 = point49.x;
				Vector3 position32 = myTransform.position;
				MousePos = new Vector3(x24, position32.y, 0f);
				Vector3 point50 = hitInfo.point;
				if (point50.x <= -2.25f + spellSize.x / 2f)
				{
					MousePos = new Vector3(-2.25f + spellSize.x / 2f, MousePos.y, 0f);
					break;
				}
				Vector3 point51 = hitInfo.point;
				if (point51.x >= 5f - spellSize.x / 2f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point52 = hitInfo.point;
				if (point52.x > -2.25f + spellSize.x / 2f)
				{
					Vector3 point53 = hitInfo.point;
					if (point53.x < 5f - spellSize.x / 2f + stageLength)
					{
						Vector3 point54 = hitInfo.point;
						MousePos = new Vector3(point54.x, MousePos.y, 0f);
					}
				}
				break;
			}
			case 3:
			{
				Vector3 vector2 = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));
				float x14 = vector2.x - 0.75f - spellSize.x / 2f;
				Vector3 position19 = myTransform.position;
				float y4 = position19.y;
				Vector3 position20 = myTransform.position;
				rightPosition = new Vector3(x14, y4, position20.z);
				Vector3 point31 = hitInfo.point;
				if (point31.y <= 0.25f + spellSize.y / 2f)
				{
					Transform transform6 = myTransform;
					float x15 = rightPosition.x + 0.5f;
					Vector3 position21 = myTransform.position;
					transform6.position = new Vector3(x15, position21.y, 0f);
					Vector3 position22 = myTransform.position;
					float x16 = position22.x;
					Vector3 position23 = myTransform.position;
					MousePos = new Vector3(x16, 0.25f, position23.z);
				}
				else
				{
					Vector3 point32 = hitInfo.point;
					if (point32.y >= 3.75f - spellSize.y / 2f)
					{
						Transform transform7 = myTransform;
						float x17 = rightPosition.x + 0.5f;
						Vector3 position24 = myTransform.position;
						transform7.position = new Vector3(x17, position24.y, 0f);
						Vector3 position25 = myTransform.position;
						float x18 = position25.x;
						Vector3 position26 = myTransform.position;
						MousePos = new Vector3(x18, 3.75f, position26.z);
					}
				}
				Vector3 point33 = hitInfo.point;
				if (point33.y >= 0.25f + spellSize.y / 2f)
				{
					Vector3 point34 = hitInfo.point;
					if (point34.y <= 3.75f - spellSize.y / 2f)
					{
						Transform transform8 = myTransform;
						float x19 = rightPosition.x + 0.5f;
						Vector3 position27 = myTransform.position;
						transform8.position = new Vector3(x19, position27.y, 0f);
						Vector3 position28 = myTransform.position;
						float x20 = position28.x;
						Vector3 point35 = hitInfo.point;
						MousePos = new Vector3(x20, point35.y, 0f);
					}
				}
				break;
			}
			case 4:
			{
				Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
				float x7 = vector.x + 0.75f + spellSize.x / 2f;
				Vector3 position9 = myTransform.position;
				float y3 = position9.y;
				Vector3 position10 = myTransform.position;
				leftPosition = new Vector3(x7, y3, position10.z);
				Vector3 point26 = hitInfo.point;
				if (point26.y <= 0.25f + spellSize.y / 2f)
				{
					Transform transform3 = myTransform;
					float x8 = leftPosition.x - 0.5f;
					Vector3 position11 = myTransform.position;
					transform3.position = new Vector3(x8, position11.y, 0f);
					Vector3 position12 = myTransform.position;
					float x9 = position12.x;
					Vector3 position13 = myTransform.position;
					MousePos = new Vector3(x9, 0.25f, position13.z);
				}
				else
				{
					Vector3 point27 = hitInfo.point;
					if (point27.y >= 3.75f - spellSize.y / 2f)
					{
						Transform transform4 = myTransform;
						float x10 = leftPosition.x - 0.5f;
						Vector3 position14 = myTransform.position;
						transform4.position = new Vector3(x10, position14.y, 0f);
						Vector3 position15 = myTransform.position;
						float x11 = position15.x;
						Vector3 position16 = myTransform.position;
						MousePos = new Vector3(x11, 3.75f, position16.z);
					}
				}
				Vector3 point28 = hitInfo.point;
				if (point28.y >= 0.25f + spellSize.y / 2f)
				{
					Vector3 point29 = hitInfo.point;
					if (point29.y <= 3.75f - spellSize.y / 2f)
					{
						Transform transform5 = myTransform;
						float x12 = leftPosition.x - 0.5f;
						Vector3 position17 = myTransform.position;
						transform5.position = new Vector3(x12, position17.y, 0f);
						Vector3 position18 = myTransform.position;
						float x13 = position18.x;
						Vector3 point30 = hitInfo.point;
						MousePos = new Vector3(x13, point30.y, 0f);
					}
				}
				break;
			}
			case 5:
			{
				if (GameScriptsManager.gameStatisticScript.closesIntruder != null)
				{
					Vector3 position = GameScriptsManager.gameStatisticScript.closesIntruder.transform.position;
					float x = position.x;
					Vector3 position2 = GameScriptsManager.gameStatisticScript.closesIntruder.transform.position;
					MousePos = new Vector3(x, position2.y, 0f);
					break;
				}
				Vector3 point = hitInfo.point;
				if (point.y <= 0.25f + spellSize.y / 2f)
				{
					Vector3 point2 = hitInfo.point;
					float x2 = point2.x;
					float y = 0.25f + spellSize.y / 2f;
					Vector3 position3 = myTransform.position;
					MousePos = new Vector3(x2, y, position3.z);
				}
				else
				{
					Vector3 point3 = hitInfo.point;
					if (point3.y >= 3.75f - spellSize.y / 2f)
					{
						Vector3 point4 = hitInfo.point;
						float x3 = point4.x;
						float y2 = 3.75f - spellSize.y / 2f;
						Vector3 position4 = myTransform.position;
						MousePos = new Vector3(x3, y2, position4.z);
					}
					else
					{
						Vector3 point5 = hitInfo.point;
						if (point5.y >= 0.25f + spellSize.y / 2f)
						{
							Vector3 point6 = hitInfo.point;
							if (point6.y <= 3.75f - spellSize.y / 2f)
							{
								Vector3 point7 = hitInfo.point;
								float x4 = point7.x;
								Vector3 point8 = hitInfo.point;
								MousePos = new Vector3(x4, point8.y, 0f);
							}
						}
					}
				}
				Vector3 point9 = hitInfo.point;
				if (point9.x <= -2.25f + spellSize.x / 2f)
				{
					MousePos = new Vector3(-2.25f + spellSize.x / 2f, MousePos.y, 0f);
					break;
				}
				Vector3 point10 = hitInfo.point;
				if (point10.x >= 5f - spellSize.x / 2f + stageLength)
				{
					MousePos = new Vector3(5f + stageLength, MousePos.y, 0f);
					break;
				}
				Vector3 point11 = hitInfo.point;
				if (point11.x > -2.25f + spellSize.x / 2f)
				{
					Vector3 point12 = hitInfo.point;
					if (point12.x < 5f - spellSize.x / 2f + stageLength)
					{
						Vector3 point13 = hitInfo.point;
						MousePos = new Vector3(point13.x, MousePos.y, 0f);
					}
				}
				break;
			}
			}
		}
		if (spellFollowType < 6)
		{
			myTransform.position = Vector3.Lerp(myTransform.position, MousePos, followDamping);
			if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
			{
				Break();
			}
		}
	}

	private void Duration()
	{
		if (Time.time >= durTimer + duration || gameLogic.gameState != 2)
		{
			Break();
		}
	}

	private void Break()
	{
		PoolManager.Pools[poolName].Despawn(myTransform);
	}
}
