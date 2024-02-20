using UnityEngine;

public class Object_Control : MonoBehaviour
{
	private Object_Attributes scriptObjectAttributes;

	private Game_Statistics scriptGameStatistic;

	public int objectAlignment;

	public int objectIdleType;

	public float objectIdleTypeAmountA;

	public float objectIdleTypeAmountB;

	public float objectIdleTypeAmountC;

	public float objectIdleTypeAmountD;

	public float objectIdleTypeAmountE;

	public int objectType;

	public int state;

	public int objectState;

	public tk2dAnimatedSprite objectSprite;

	public Object_Sprite_Control objectSpriteControl;

	private Rigidbody RIGIDBODY_objectControl;

	private Collider COLLIDER_objectControl;

	private Transform myTransform;

	private float stageLength;

	public int attributeObjectLevitationValue;

	public int attributeHealthMaximumValue;

	public int attributeHealthValue;

	public float attributeSpeedValue;

	public float attributeDamageMultiplier;

	public float attributeCriticalValue;

	public float attributeKnockResistance;

	private float attributeChargeUpDuration;

	private Vector3 VECTOR_spawnPosition;

	public GameObject effectUniqueBreakPosition;

	private float VELOCITY_dropSpeed;

	private float TIMER_objectIdleType;

	private int TOGGLE_objectIdleType;

	private float TIMER_rayFPS;

	private float VECTOR_pickUpPositionZ;

	private int objectPickUpType;

	private Vector3 VECTOR_touchPos;

	public GameObject objectHUD;

	private Transform INST_objectHUD;

	public GameObject objectSelectGlow;

	private Transform INST_objectSelectGlow;

	private Vector3 VECTOR_objectSelectGlow;

	private float ROLL_triggerCritical;

	private int TOGGLE_triggerCritical;

	private float VECTORX_objectBlockDropPosition;

	private int TOGGLE_velocityStagger;

	private float TIMER_velocityStagger;

	private float VELOCITY_attributeSpeedValue;

	public GameObject effectBreakPosition;

	public int objectChargeState;

	private int LEVEL_chargeLevel;

	private float TIMER_chargeLevel;

	public GameObject objectTrigger;

	private Transform INST_objectTrigger;

	private Transform INST_objectBreakTrigger;

	public GameObject objectBlockDetector;

	private Transform INST_objectBlockDetector;

	private Vector3 VECTOR_objectBlockDetector;

	private int TOGGLE_objectBlockState;

	private float TIMER_selfDamage;

	private int TOGGLE_selfDamage;

	public int objectColorState;

	private Color COLOR_unitColorDamaged = Color.red;

	private Color COLOR_unitColorHeal = Color.green;

	private Color COLOR_unitColorDefault = Color.white;

	private float TIMER_objectColorState;

	public GameObject effectPosition;

	public GameObject effectPropertyDisplay;

	private Transform INST_effectTextDisplay;

	private float SIZE_effectTextDisplay;

	private Color COLOR_effectTextDisplay;

	private float FADE_effectTextDisplay;

	private int AMOUNT_attributeEffectHP;

	private int TOGGLE_attributeEffectHP;

	private int AMOUNT_attributeOverTimeEffectHP;

	private int NUMBER_attributeOverTimeEffectHP;

	private float DELAY_attributeOverTimeEffectHP;

	private float TIMER_attributeOverTimeEffectHP;

	private int TOGGLE_attributeOverTimeEffectHP;

	private int EFFECTCLASS_attributeOverTimeEffectHP;

	private int EFFECTNUMBER_attributeOverTimeEffectHP;

	private int AMOUNT_attributeEffectAP;

	private int TOGGLE_attributeEffectAP;

	private float TIMER_attributeEffectAP;

	private int AMOUNT_attributeEffectANP;

	private int TOGGLE_attributeEffectANP;

	private float TIMER_attributeEffectANP;

	private float TIMER_unitEffectKnock;

	private Vector3 VECTOR_unitEffectKnock;

	private float DAMPING_unitEffectKnock;

	private int TOGGLE_unitEffectKnock;

	private float TIMER_unitEffectRise;

	private Vector3 VECTOR_unitEffectRise;

	private float DAMPING_unitEffectRise;

	private int TOGGLE_unitEffectRise;

	private Transform INST_effectArmorState;

	private int TOGGLE_unitAttributeArmorPoint;

	public GameObject effectHitDisplay;

	private Transform INST_effectHitDisplay;

	public string ID_triggerName;

	private float TIMER_triggerDelay;

	private _Trigger scriptTrigger;

	private int DAMAGE_setToggle;

	private int DAMAGE_setAmount;

	private int DAMAGE_pureEffect;

	private void Start()
	{
		myTransform = base.transform;
		base.useGUILayout = false;
		stageLength = GameScriptsManager.masterControlScript.stageLength;
		scriptGameStatistic = GameScriptsManager.gameStatisticScript;
		scriptObjectAttributes = GetComponent<Object_Attributes>();
		RIGIDBODY_objectControl = GetComponent<Rigidbody>();
		COLLIDER_objectControl = GetComponent<Collider>();
	}

	private void OnSpawned()
	{
		state = -1;
		objectState = 0;
	}

	private void OnDespawned()
	{
		if (INST_objectBlockDetector != null)
		{
			INST_objectBlockDetector.GetComponent<Unit_Detection>().targetObject = null;
			INST_objectBlockDetector = null;
		}
		if (INST_objectSelectGlow != null)
		{
			PoolManager.Pools["HUD Pool"].Despawn(INST_objectSelectGlow);
			INST_objectSelectGlow = null;
		}
		if (INST_objectTrigger != null)
		{
			PoolManager.Pools["HUD Pool"].Despawn(INST_objectTrigger);
			INST_objectTrigger = null;
		}
	}

	private void AttributeSetup()
	{
		scriptObjectAttributes.objectState = objectState;
		switch (state)
		{
		case -1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 0:
			attributeObjectLevitationValue = scriptObjectAttributes.objectLevitationValue;
			objectAlignment = scriptObjectAttributes.objectAlignment;
			objectIdleType = scriptObjectAttributes.objectIdleType;
			objectType = scriptObjectAttributes.objectType;
			attributeHealthMaximumValue = scriptObjectAttributes.healthValue;
			attributeHealthValue = scriptObjectAttributes.healthValue;
			break;
		case 1:
			if (attributeHealthValue <= 0)
			{
				objectState = 5;
			}
			attributeSpeedValue = scriptObjectAttributes.speedValue;
			attributeDamageMultiplier = scriptObjectAttributes.damageMultiplier;
			attributeCriticalValue = scriptObjectAttributes.criticalValue;
			attributeKnockResistance = scriptObjectAttributes.knockResistanceValue;
			attributeChargeUpDuration = scriptObjectAttributes.chargeUpDuration;
			break;
		}
	}

	private void LateUpdate()
	{
		AttributeSetup();
	}

	private void Test()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.F2))
		{
			state = 2;
		}
	}

	private void Update()
	{
		Test();
		if (Time.timeScale == 0f)
		{
			return;
		}
		switch (state)
		{
		case -1:
			TOGGLE_attributeOverTimeEffectHP = -1;
			TOGGLE_attributeEffectAP = -1;
			TOGGLE_unitEffectKnock = -1;
			TOGGLE_unitEffectRise = -1;
			objectColorState = -1;
			TOGGLE_attributeEffectHP = -1;
			objectSprite.color = Color.white;
			state++;
			break;
		case 0:
			StateSetup();
			state++;
			break;
		case 1:
			if (objectState >= 2)
			{
				ObjectHUDFunction();
			}
			switch (objectState)
			{
			case 0:
				StateNormalIdle();
				break;
			case 1:
				StateNormalPickUp();
				break;
			case 2:
				StateNormalPickUpControl();
				break;
			case 3:
				StateNormalRelease();
				break;
			case 4:
				if (objectType == 2)
				{
					if (TOGGLE_attributeOverTimeEffectHP != 0)
					{
						AttributeOverTimeEffectHP();
					}
					if (TOGGLE_attributeEffectAP != 0)
					{
						AttributeEffectAP();
					}
					if (TOGGLE_unitEffectKnock != 0)
					{
						UnitEffectKnock();
					}
					if (TOGGLE_unitEffectRise != 0)
					{
						UnitEffectRise();
					}
				}
				if (objectColorState != 0)
				{
					UnitColorFunction();
				}
				if (TOGGLE_attributeEffectHP != 0)
				{
					AttributeEffectHP();
				}
				AttributePropDisplay();
				StateNormalUnleased();
				break;
			case 5:
				AttributePropDisplay();
				StateNormalBreak();
				break;
			}
			break;
		case 2:
			StateBreak();
			break;
		case 3:
			StateDespawn();
			break;
		}
		if (scriptTrigger != null)
		{
			TriggerFunction();
		}
	}

	private void StateSetup()
	{
		scriptObjectAttributes = GetComponent<Object_Attributes>();
		RIGIDBODY_objectControl = GetComponent<Rigidbody>();
		COLLIDER_objectControl = GetComponent<Collider>();
		VECTOR_spawnPosition = myTransform.position;
		myTransform.localRotation = Quaternion.Euler(0f, 90f, 0f);
		switch (objectAlignment)
		{
		case 0:
		{
			base.tag = "Untagged";
			Vector3 position2 = myTransform.position;
			VECTOR_objectBlockDetector = new Vector3(position2.x, -1.5f, 1f);
			break;
		}
		case 1:
		{
			base.tag = "Untagged";
			Vector3 position = myTransform.position;
			VECTOR_objectBlockDetector = new Vector3(position.x, -1.5f, 0f);
			break;
		}
		}
		COLLIDER_objectControl.enabled = true;
		objectAlignment = scriptObjectAttributes.objectAlignment;
		objectIdleType = scriptObjectAttributes.objectIdleType;
		attributeHealthMaximumValue = scriptObjectAttributes.healthValue;
		attributeHealthValue = scriptObjectAttributes.healthValue;
		VELOCITY_dropSpeed = 10f;
	}

	private void StateBreak()
	{
		if (objectSpriteControl != null)
		{
			objectSpriteControl.AnimationNumber = 4;
		}
		if (scriptObjectAttributes.breakUniqueEffect.Length > 0)
		{
			for (int i = 0; i < scriptObjectAttributes.breakUniqueEffect.Length; i++)
			{
				PoolManager.Pools["Effect Pool"].Spawn(scriptObjectAttributes.breakUniqueEffect[i].transform, effectUniqueBreakPosition.transform.position, scriptObjectAttributes.breakUniqueEffect[i].transform.rotation);
			}
		}
		state++;
	}

	private void StateDespawn()
	{
		objectState = 0;
		myTransform.position = new Vector3(0f, 100f, 0f);
		PoolManager.Pools["Object Pool"].Despawn(base.transform);
	}

	private void StateNormal()
	{
		switch (objectState)
		{
		case 0:
			StateNormalIdle();
			break;
		case 1:
			StateNormalPickUp();
			break;
		case 2:
			StateNormalPickUpControl();
			break;
		case 3:
			StateNormalRelease();
			break;
		case 4:
			StateNormalUnleased();
			break;
		case 5:
			StateNormalBreak();
			break;
		}
	}

	private void StateNormalIdle()
	{
		switch (objectIdleType)
		{
		case 0:
		{
			Vector3 position19 = myTransform.position;
			if (position19.x != VECTOR_spawnPosition.x)
			{
				Transform transform3 = myTransform;
				float x3 = VECTOR_spawnPosition.x;
				Vector3 position20 = myTransform.position;
				float y3 = position20.y;
				Vector3 position21 = myTransform.position;
				transform3.position = new Vector3(x3, y3, position21.z);
			}
			if (RIGIDBODY_objectControl.isKinematic)
			{
				RIGIDBODY_objectControl.isKinematic = false;
				GetComponent<Rigidbody>().velocity = new Vector3(0f, 1f, 0f);
			}
			break;
		}
		case 1:
			if (!RIGIDBODY_objectControl.isKinematic)
			{
				RIGIDBODY_objectControl.isKinematic = true;
			}
			break;
		case 2:
		{
			if (Time.time >= TIMER_rayFPS)
			{
				Vector3 direction = myTransform.TransformDirection(-Vector3.up);
				Vector3 position24 = myTransform.position;
				if (Physics.Raycast(position24, direction, out RaycastHit hitInfo, objectIdleTypeAmountC))
				{
					UnityEngine.Debug.DrawLine(position24, position24 + -myTransform.up * hitInfo.distance, Color.green);
					Transform transform4 = myTransform;
					Vector3 position25 = myTransform.position;
					float x4 = position25.x;
					Vector3 point = hitInfo.point;
					float y4 = point.y + (objectIdleTypeAmountC - 0.001f);
					Vector3 position26 = myTransform.position;
					transform4.position = new Vector3(x4, y4, position26.z);
					if (VELOCITY_dropSpeed != 0.5f)
					{
						VELOCITY_dropSpeed = 0.5f;
					}
				}
				else
				{
					UnityEngine.Debug.DrawLine(position24, position24 + -myTransform.up * objectIdleTypeAmountC, Color.red);
					myTransform.Translate(-myTransform.up * VELOCITY_dropSpeed * Time.smoothDeltaTime, Space.World);
				}
				if (VELOCITY_dropSpeed != 0.5f)
				{
					TIMER_rayFPS = Time.time + 0.001f;
				}
				else
				{
					TIMER_rayFPS = Time.time + 0.1f;
				}
			}
			Vector3 position27 = myTransform.position;
			if (position27.x <= -6f)
			{
				TOGGLE_objectIdleType = 0;
			}
			else
			{
				Vector3 position28 = myTransform.position;
				if (position28.x >= 6f + stageLength)
				{
					TOGGLE_objectIdleType = 2;
				}
			}
			switch (TOGGLE_objectIdleType)
			{
			case 0:
				if (objectSpriteControl.AnimationNumber != 3)
				{
					TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(objectIdleTypeAmountB, objectIdleTypeAmountB * 2f);
					objectSpriteControl.AnimationNumber = 3;
				}
				if (objectIdleTypeAmountB != 0f && Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType = 1;
				}
				myTransform.Translate(myTransform.forward * objectIdleTypeAmountA * Time.smoothDeltaTime, Space.World);
				break;
			case 1:
				if (objectSpriteControl.AnimationNumber != 0)
				{
					TIMER_objectIdleType = Time.time + (float)UnityEngine.Random.Range(2, 6);
					objectSpriteControl.AnimationNumber = 0;
				}
				if (Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType = 0;
				}
				break;
			case 2:
				if (objectSpriteControl.AnimationNumber != -3)
				{
					TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(objectIdleTypeAmountB, objectIdleTypeAmountB * 2f);
					objectSpriteControl.AnimationNumber = -3;
				}
				if (objectIdleTypeAmountB != 0f && Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType = 3;
				}
				myTransform.Translate(-myTransform.forward * objectIdleTypeAmountA * Time.smoothDeltaTime, Space.World);
				break;
			case 3:
				if (objectSpriteControl.AnimationNumber != 0)
				{
					TIMER_objectIdleType = Time.time + (float)UnityEngine.Random.Range(2, 6);
					objectSpriteControl.AnimationNumber = 0;
				}
				if (Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType = 2;
				}
				break;
			}
			break;
		}
		case 3:
		{
			Vector3 position22 = myTransform.position;
			if (position22.y <= -1.5f)
			{
				TOGGLE_objectIdleType = 0;
			}
			else
			{
				Vector3 position23 = myTransform.position;
				if (position23.y >= 5.5f + stageLength)
				{
					TOGGLE_objectIdleType = 2;
				}
			}
			switch (TOGGLE_objectIdleType)
			{
			case 0:
				if (objectSpriteControl.AnimationNumber != 3)
				{
					TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(objectIdleTypeAmountB, objectIdleTypeAmountB * 2f);
					objectSpriteControl.AnimationNumber = 3;
				}
				if (objectIdleTypeAmountB != 0f && Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType = 1;
				}
				myTransform.Translate(myTransform.up * objectIdleTypeAmountA * Time.smoothDeltaTime, Space.World);
				myTransform.Translate(myTransform.forward * objectIdleTypeAmountC * Time.smoothDeltaTime, Space.World);
				break;
			case 1:
				if (objectSpriteControl.AnimationNumber != 0)
				{
					TIMER_objectIdleType = Time.time + (float)UnityEngine.Random.Range(2, 6);
					objectSpriteControl.AnimationNumber = 0;
				}
				if (Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType = 0;
				}
				break;
			case 2:
				if (objectSpriteControl.AnimationNumber != -3)
				{
					TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(objectIdleTypeAmountB, objectIdleTypeAmountB * 2f);
					objectSpriteControl.AnimationNumber = -3;
				}
				if (objectIdleTypeAmountB != 0f && Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType = 3;
				}
				myTransform.Translate(-myTransform.up * objectIdleTypeAmountA * Time.smoothDeltaTime, Space.World);
				myTransform.Translate(-myTransform.forward * objectIdleTypeAmountC * Time.smoothDeltaTime, Space.World);
				break;
			case 3:
				if (objectSpriteControl.AnimationNumber != 0)
				{
					TIMER_objectIdleType = Time.time + (float)UnityEngine.Random.Range(2, 6);
					objectSpriteControl.AnimationNumber = 0;
				}
				if (Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType = 2;
				}
				break;
			}
			break;
		}
		case 4:
			if (objectIdleTypeAmountA == 0f)
			{
				switch (TOGGLE_objectIdleType)
				{
				case 0:
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					break;
				case 1:
				{
					Transform transform = myTransform;
					Vector3 position9 = myTransform.position;
					float x = position9.x;
					float y = VECTOR_spawnPosition.y;
					Vector3 position10 = myTransform.position;
					transform.position = new Vector3(x, y, position10.z);
					TOGGLE_objectIdleType++;
					break;
				}
				case 2:
				{
					Vector3 position11 = myTransform.position;
					if (position11.y <= -1.5f)
					{
						if (objectIdleTypeAmountC >= 1f)
						{
							TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(objectIdleTypeAmountC - 1f, objectIdleTypeAmountC + 1f);
						}
						else
						{
							TIMER_objectIdleType = 0f;
						}
						TOGGLE_objectIdleType = 0;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						TIMER_objectIdleType = Time.time + objectIdleTypeAmountD;
						objectSpriteControl.AnimationNumber = 3;
					}
					if (objectIdleTypeAmountD != 0f && Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType = 3;
					}
					myTransform.Translate(-myTransform.up * objectIdleTypeAmountB * Time.smoothDeltaTime, Space.World);
					break;
				}
				case 3:
					if (objectSpriteControl.AnimationNumber != 0)
					{
						TIMER_objectIdleType = Time.time + 5f;
						objectSpriteControl.AnimationNumber = 0;
					}
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType = 2;
					}
					break;
				}
			}
			else
			{
				if (objectIdleTypeAmountA != 1f)
				{
					break;
				}
				switch (TOGGLE_objectIdleType)
				{
				case 0:
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					break;
				case 1:
				{
					Transform transform2 = myTransform;
					Vector3 position12 = myTransform.position;
					float x2 = position12.x;
					float y2 = VECTOR_spawnPosition.y;
					Vector3 position13 = myTransform.position;
					transform2.position = new Vector3(x2, y2, position13.z);
					TOGGLE_objectIdleType++;
					break;
				}
				case 2:
				{
					Vector3 position14 = myTransform.position;
					if (position14.y >= 5.5f + stageLength)
					{
						if (objectIdleTypeAmountC >= 1f)
						{
							TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(objectIdleTypeAmountC - 1f, objectIdleTypeAmountC + 1f);
						}
						else
						{
							TIMER_objectIdleType = 0f;
						}
						TOGGLE_objectIdleType = 0;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						TIMER_objectIdleType = Time.time + objectIdleTypeAmountD;
						objectSpriteControl.AnimationNumber = 3;
					}
					if (objectIdleTypeAmountD != 0f && Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType = 3;
					}
					myTransform.Translate(myTransform.up * objectIdleTypeAmountB * Time.smoothDeltaTime, Space.World);
					break;
				}
				case 3:
					if (objectSpriteControl.AnimationNumber != 0)
					{
						TIMER_objectIdleType = Time.time + 5f;
						objectSpriteControl.AnimationNumber = 0;
					}
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType = 2;
					}
					break;
				}
			}
			break;
		case 5:
		{
			Vector3 position15 = myTransform.position;
			if (position15.x <= -5f)
			{
				TOGGLE_objectIdleType = 3;
			}
			else
			{
				Vector3 position16 = myTransform.position;
				if (position16.x >= 5f + stageLength)
				{
					TOGGLE_objectIdleType = 0;
				}
			}
			switch (TOGGLE_objectIdleType)
			{
			case 0:
			{
				Vector3 position18 = myTransform.position;
				if (position18.x <= 6f + stageLength - objectIdleTypeAmountA)
				{
					TIMER_objectIdleType = Time.time + objectIdleTypeAmountB;
					TOGGLE_objectIdleType++;
				}
				if (objectSpriteControl.AnimationNumber != -3)
				{
					TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(2f, objectIdleTypeAmountC + 2f);
					objectSpriteControl.AnimationNumber = -3;
				}
				if (Time.time >= TIMER_objectIdleType)
				{
					myTransform.Translate(-myTransform.forward * objectIdleTypeAmountC * Time.smoothDeltaTime, Space.World);
				}
				break;
			}
			case 1:
				if (Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType++;
				}
				if (objectSpriteControl.AnimationNumber != 0)
				{
					objectSpriteControl.AnimationNumber = 0;
				}
				break;
			case 2:
				if (objectSpriteControl.AnimationNumber != 3)
				{
					objectSpriteControl.AnimationNumber = 3;
				}
				myTransform.Translate(myTransform.forward * objectIdleTypeAmountD * Time.smoothDeltaTime, Space.World);
				break;
			case 3:
			{
				Vector3 position17 = myTransform.position;
				if (position17.x >= -6f + objectIdleTypeAmountA)
				{
					TIMER_objectIdleType = Time.time + objectIdleTypeAmountB;
					TOGGLE_objectIdleType++;
				}
				if (objectSpriteControl.AnimationNumber != 3)
				{
					TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(2f, objectIdleTypeAmountC + 2f);
					objectSpriteControl.AnimationNumber = 3;
				}
				if (Time.time >= TIMER_objectIdleType)
				{
					myTransform.Translate(myTransform.forward * objectIdleTypeAmountC * Time.smoothDeltaTime, Space.World);
				}
				break;
			}
			case 4:
				if (Time.time >= TIMER_objectIdleType)
				{
					TOGGLE_objectIdleType++;
				}
				if (objectSpriteControl.AnimationNumber != 0)
				{
					objectSpriteControl.AnimationNumber = 0;
				}
				break;
			case 5:
				if (objectSpriteControl.AnimationNumber != -3)
				{
					objectSpriteControl.AnimationNumber = -3;
				}
				myTransform.Translate(-myTransform.forward * objectIdleTypeAmountD * Time.smoothDeltaTime, Space.World);
				break;
			}
			break;
		}
		case 6:
			if (objectIdleTypeAmountA == 0f)
			{
				switch (TOGGLE_objectIdleType)
				{
				case 0:
					if (objectSpriteControl.AnimationNumber != 0)
					{
						objectSpriteControl.AnimationNumber = 0;
					}
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					break;
				case 1:
				{
					Vector3 position2 = myTransform.position;
					if (position2.x <= VECTOR_spawnPosition.x - objectIdleTypeAmountB)
					{
						TIMER_objectIdleType = Time.time + objectIdleTypeAmountC;
						TOGGLE_objectIdleType++;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						objectSpriteControl.AnimationNumber = 3;
					}
					myTransform.Translate(-myTransform.forward * objectIdleTypeAmountD * Time.smoothDeltaTime, Space.World);
					break;
				}
				case 2:
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					if (objectSpriteControl.AnimationNumber != 0)
					{
						objectSpriteControl.AnimationNumber = 0;
					}
					break;
				case 3:
				{
					Vector3 position = myTransform.position;
					if (position.x >= VECTOR_spawnPosition.x)
					{
						TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(2f, objectIdleTypeAmountC + 2f);
						TOGGLE_objectIdleType = 0;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						objectSpriteControl.AnimationNumber = 3;
					}
					myTransform.Translate(myTransform.forward * objectIdleTypeAmountE * Time.smoothDeltaTime, Space.World);
					break;
				}
				}
			}
			else if (objectIdleTypeAmountA == 1f)
			{
				switch (TOGGLE_objectIdleType)
				{
				case 0:
					if (objectSpriteControl.AnimationNumber != 0)
					{
						objectSpriteControl.AnimationNumber = 0;
					}
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					break;
				case 1:
				{
					Vector3 position4 = myTransform.position;
					if (position4.x >= VECTOR_spawnPosition.x + objectIdleTypeAmountB)
					{
						TIMER_objectIdleType = Time.time + objectIdleTypeAmountC;
						TOGGLE_objectIdleType++;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						objectSpriteControl.AnimationNumber = 3;
					}
					myTransform.Translate(myTransform.forward * objectIdleTypeAmountD * Time.smoothDeltaTime, Space.World);
					break;
				}
				case 2:
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					if (objectSpriteControl.AnimationNumber != 0)
					{
						objectSpriteControl.AnimationNumber = 0;
					}
					break;
				case 3:
				{
					Vector3 position3 = myTransform.position;
					if (position3.x <= VECTOR_spawnPosition.x)
					{
						TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(2f, objectIdleTypeAmountC + 2f);
						TOGGLE_objectIdleType = 0;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						objectSpriteControl.AnimationNumber = 3;
					}
					myTransform.Translate(-myTransform.forward * objectIdleTypeAmountE * Time.smoothDeltaTime, Space.World);
					break;
				}
				}
			}
			else if (objectIdleTypeAmountA == 2f)
			{
				switch (TOGGLE_objectIdleType)
				{
				case 0:
					if (objectSpriteControl.AnimationNumber != 0)
					{
						objectSpriteControl.AnimationNumber = 0;
					}
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					break;
				case 1:
				{
					Vector3 position6 = myTransform.position;
					if (position6.y >= VECTOR_spawnPosition.y + objectIdleTypeAmountB)
					{
						TIMER_objectIdleType = Time.time + objectIdleTypeAmountC;
						TOGGLE_objectIdleType++;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						objectSpriteControl.AnimationNumber = 3;
					}
					myTransform.Translate(myTransform.up * objectIdleTypeAmountD * Time.smoothDeltaTime, Space.World);
					break;
				}
				case 2:
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					if (objectSpriteControl.AnimationNumber != 0)
					{
						objectSpriteControl.AnimationNumber = 0;
					}
					break;
				case 3:
				{
					Vector3 position5 = myTransform.position;
					if (position5.y <= VECTOR_spawnPosition.y)
					{
						TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(2f, objectIdleTypeAmountC + 2f);
						TOGGLE_objectIdleType = 0;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						objectSpriteControl.AnimationNumber = 3;
					}
					myTransform.Translate(-myTransform.up * objectIdleTypeAmountE * Time.smoothDeltaTime, Space.World);
					break;
				}
				}
			}
			else
			{
				if (objectIdleTypeAmountA != 3f)
				{
					break;
				}
				switch (TOGGLE_objectIdleType)
				{
				case 0:
					if (objectSpriteControl.AnimationNumber != 0)
					{
						objectSpriteControl.AnimationNumber = 0;
					}
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					break;
				case 1:
				{
					Vector3 position8 = myTransform.position;
					if (position8.y <= VECTOR_spawnPosition.y - objectIdleTypeAmountB)
					{
						TIMER_objectIdleType = Time.time + objectIdleTypeAmountC;
						TOGGLE_objectIdleType++;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						objectSpriteControl.AnimationNumber = 3;
					}
					myTransform.Translate(-myTransform.up * objectIdleTypeAmountD * Time.smoothDeltaTime, Space.World);
					break;
				}
				case 2:
					if (Time.time >= TIMER_objectIdleType)
					{
						TOGGLE_objectIdleType++;
					}
					if (objectSpriteControl.AnimationNumber != 0)
					{
						objectSpriteControl.AnimationNumber = 0;
					}
					break;
				case 3:
				{
					Vector3 position7 = myTransform.position;
					if (position7.y >= VECTOR_spawnPosition.y)
					{
						TIMER_objectIdleType = Time.time + UnityEngine.Random.Range(2f, objectIdleTypeAmountC + 2f);
						TOGGLE_objectIdleType = 0;
					}
					if (objectSpriteControl.AnimationNumber != 3)
					{
						objectSpriteControl.AnimationNumber = 3;
					}
					myTransform.Translate(myTransform.up * objectIdleTypeAmountE * Time.smoothDeltaTime, Space.World);
					break;
				}
				}
			}
			break;
		}
	}

	private void StateNormalPickUp()
	{
		Camera_Control.instance.isObjectClciked = true;
		scriptGameStatistic.scoreObjectPoints--;
		RIGIDBODY_objectControl.isKinematic = true;
		COLLIDER_objectControl.enabled = false;
		VECTOR_touchPos = myTransform.position;
		LEVEL_chargeLevel = 0;
		switch (objectType)
		{
		case 0:
			VECTOR_pickUpPositionZ = -0.2f;
			TIMER_chargeLevel = Time.time;
			break;
		case 1:
			VECTOR_pickUpPositionZ = -0.2f;
			TIMER_chargeLevel = Time.time;
			break;
		case 2:
			VECTOR_pickUpPositionZ = -0.8f;
			break;
		case 3:
			VECTOR_pickUpPositionZ = -0.8f;
			break;
		}
		Transform transform = myTransform;
		Vector3 position = myTransform.position;
		float x = position.x;
		Vector3 position2 = myTransform.position;
		transform.position = new Vector3(x, position2.y, VECTOR_pickUpPositionZ);
		objectState++;
	}

	private void StateNormalPickUpControl()
	{
		switch (objectType)
		{
		case 0:
			ObjectPickUpAimFunction();
			ObjectPickUpAimChargeFunction();
			break;
		case 1:
			ObjectPickUpAimFunction();
			ObjectPickUpAimChargeFunction();
			break;
		case 2:
			ObjectPickUpFollowFunction();
			ObjectPickUpFollowChargeFunction();
			break;
		case 3:
			ObjectPickUpFollowFunction();
			ObjectPickUpFollowChargeFunction();
			break;
		}
		if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
		{
			objectState++;
		}
	}

	private void ObjectHUDFunction()
	{
		switch (state)
		{
		case 1:
			switch (objectState)
			{
			case 2:
				switch (objectType)
				{
				case 0:
					if (INST_objectHUD == null)
					{
						INST_objectHUD = PoolManager.Pools["HUD Pool"].Spawn(objectHUD.transform, myTransform.position, myTransform.rotation);
						INST_objectHUD.GetComponent<Object_HUD_Control>().gameobjectObject = base.gameObject;
					}
					if (INST_objectSelectGlow == null)
					{
						SpawnPool spawnPool4 = PoolManager.Pools["HUD Pool"];
						Transform transform7 = objectSelectGlow.transform;
						Vector3 position13 = myTransform.position;
						float x7 = position13.x;
						Vector3 position14 = myTransform.position;
						INST_objectSelectGlow = spawnPool4.Spawn(transform7, new Vector3(x7, position14.y, -5f), objectSelectGlow.transform.rotation);
						INST_objectSelectGlow.transform.localScale = new Vector3(scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize);
					}
					if (INST_objectSelectGlow != null)
					{
						Transform transform8 = INST_objectSelectGlow.transform;
						Vector3 position15 = myTransform.position;
						float x8 = position15.x;
						Vector3 position16 = myTransform.position;
						transform8.position = new Vector3(x8, position16.y, -5f);
						INST_objectSelectGlow.transform.Rotate(0f, 0f, 40f);
						switch (LEVEL_chargeLevel)
						{
						case 2:
							break;
						case 0:
							INST_objectSelectGlow.transform.localScale += new Vector3(0.005f, 0.005f, 0f);
							break;
						case 1:
							INST_objectSelectGlow.transform.localScale += new Vector3(0.01f, 0.01f, 0f);
							break;
						}
					}
					break;
				case 1:
					if (INST_objectHUD == null)
					{
						INST_objectHUD = PoolManager.Pools["HUD Pool"].Spawn(objectHUD.transform, myTransform.position, myTransform.rotation);
						INST_objectHUD.GetComponent<Object_HUD_Control>().gameobjectObject = base.gameObject;
					}
					if (INST_objectSelectGlow == null)
					{
						SpawnPool spawnPool2 = PoolManager.Pools["HUD Pool"];
						Transform transform3 = objectSelectGlow.transform;
						Vector3 position5 = myTransform.position;
						float x3 = position5.x;
						Vector3 position6 = myTransform.position;
						INST_objectSelectGlow = spawnPool2.Spawn(transform3, new Vector3(x3, position6.y, -5f), objectSelectGlow.transform.rotation);
						INST_objectSelectGlow.transform.localScale = new Vector3(scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize);
					}
					if (INST_objectSelectGlow != null)
					{
						Transform transform4 = INST_objectSelectGlow.transform;
						Vector3 position7 = myTransform.position;
						float x4 = position7.x;
						Vector3 position8 = myTransform.position;
						transform4.position = new Vector3(x4, position8.y, -5f);
						INST_objectSelectGlow.transform.Rotate(0f, 0f, 40f);
						switch (LEVEL_chargeLevel)
						{
						case 2:
							break;
						case 0:
							INST_objectSelectGlow.transform.localScale += new Vector3(0.005f, 0.005f, 0f);
							break;
						case 1:
							INST_objectSelectGlow.transform.localScale += new Vector3(0.01f, 0.01f, 0f);
							break;
						}
					}
					break;
				case 2:
					if (INST_objectHUD == null)
					{
						INST_objectHUD = PoolManager.Pools["HUD Pool"].Spawn(objectHUD.transform, effectPosition.transform.position, myTransform.rotation);
						INST_objectHUD.GetComponent<Object_HUD_Control>().scriptObjectControl = GetComponent<Object_Control>();
						INST_objectHUD.GetComponent<Object_HUD_Control>().gameobjectObject = effectPosition.gameObject;
					}
					if (INST_objectSelectGlow == null)
					{
						SpawnPool spawnPool3 = PoolManager.Pools["HUD Pool"];
						Transform transform5 = objectSelectGlow.transform;
						Vector3 position9 = effectPosition.transform.position;
						float x5 = position9.x;
						Vector3 position10 = effectPosition.transform.position;
						INST_objectSelectGlow = spawnPool3.Spawn(transform5, new Vector3(x5, position10.y, -5f), objectSelectGlow.transform.rotation);
						INST_objectSelectGlow.transform.localScale = new Vector3(scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize);
					}
					if (INST_objectSelectGlow != null)
					{
						Transform transform6 = INST_objectSelectGlow.transform;
						Vector3 position11 = effectPosition.transform.position;
						float x6 = position11.x;
						Vector3 position12 = effectPosition.transform.position;
						transform6.position = new Vector3(x6, position12.y, -5f);
						INST_objectSelectGlow.transform.Rotate(0f, 0f, 40f);
						switch (LEVEL_chargeLevel)
						{
						case 0:
							INST_objectSelectGlow.transform.localScale = new Vector3(2f, 2f, 1f);
							break;
						case 1:
							INST_objectSelectGlow.transform.localScale = new Vector3(2.25f, 2.25f, 1f);
							break;
						case 2:
							INST_objectSelectGlow.transform.localScale = new Vector3(2.5f, 2.5f, 1f);
							break;
						}
					}
					break;
				case 3:
					if (INST_objectHUD == null)
					{
						INST_objectHUD = PoolManager.Pools["HUD Pool"].Spawn(objectHUD.transform, effectPosition.transform.position, myTransform.rotation);
						INST_objectHUD.GetComponent<Object_HUD_Control>().scriptObjectControl = GetComponent<Object_Control>();
						INST_objectHUD.GetComponent<Object_HUD_Control>().gameobjectObject = effectPosition.gameObject;
					}
					if (INST_objectSelectGlow == null)
					{
						SpawnPool spawnPool = PoolManager.Pools["HUD Pool"];
						Transform transform = objectSelectGlow.transform;
						Vector3 position = effectPosition.transform.position;
						float x = position.x;
						Vector3 position2 = effectPosition.transform.position;
						INST_objectSelectGlow = spawnPool.Spawn(transform, new Vector3(x, position2.y, -5f), objectSelectGlow.transform.rotation);
						INST_objectSelectGlow.transform.localScale = new Vector3(scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize);
					}
					if (INST_objectSelectGlow != null)
					{
						Transform transform2 = INST_objectSelectGlow.transform;
						Vector3 position3 = effectPosition.transform.position;
						float x2 = position3.x;
						Vector3 position4 = effectPosition.transform.position;
						transform2.position = new Vector3(x2, position4.y, -5f);
						INST_objectSelectGlow.transform.Rotate(0f, 0f, 40f);
						INST_objectSelectGlow.transform.localScale = new Vector3(scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize, scriptObjectAttributes.chargeSize);
					}
					break;
				}
				break;
			case 3:
				if (INST_objectHUD != null)
				{
					if (INST_objectHUD.gameObject.active)
					{
						PoolManager.Pools["HUD Pool"].Despawn(INST_objectHUD);
					}
					INST_objectHUD = null;
				}
				switch (objectType)
				{
				case 0:
					break;
				case 1:
					break;
				case 2:
					if (INST_objectSelectGlow != null)
					{
						PoolManager.Pools["HUD Pool"].Despawn(INST_objectSelectGlow);
						INST_objectSelectGlow = null;
					}
					break;
				case 3:
					if (INST_objectSelectGlow != null)
					{
						PoolManager.Pools["HUD Pool"].Despawn(INST_objectSelectGlow);
						INST_objectSelectGlow = null;
					}
					break;
				}
				break;
			case 4:
				switch (objectType)
				{
				case 2:
					break;
				case 3:
					break;
				case 0:
				{
					if (Time.timeScale != 0f)
					{
						INST_objectSelectGlow.transform.Rotate(0f, 0f, 40f);
					}
					Transform transform10 = INST_objectSelectGlow.transform;
					Vector3 position19 = myTransform.position;
					float x10 = position19.x;
					Vector3 position20 = myTransform.position;
					transform10.position = new Vector3(x10, position20.y, -5f);
					break;
				}
				case 1:
				{
					if (Time.timeScale != 0f)
					{
						INST_objectSelectGlow.transform.Rotate(0f, 0f, 40f);
					}
					Transform transform9 = INST_objectSelectGlow.transform;
					Vector3 position17 = myTransform.position;
					float x9 = position17.x;
					Vector3 position18 = myTransform.position;
					transform9.position = new Vector3(x9, position18.y, -5f);
					break;
				}
				}
				break;
			case 5:
				if (INST_objectSelectGlow != null)
				{
					PoolManager.Pools["HUD Pool"].Despawn(INST_objectSelectGlow);
					INST_objectSelectGlow = null;
				}
				break;
			}
			break;
		case 2:
			if (INST_objectSelectGlow != null)
			{
				if (INST_objectSelectGlow.gameObject.active)
				{
					PoolManager.Pools["HUD Pool"].Despawn(INST_objectSelectGlow);
				}
				INST_objectSelectGlow = null;
			}
			if (INST_objectHUD != null)
			{
				if (INST_objectHUD.gameObject.active)
				{
					PoolManager.Pools["HUD Pool"].Despawn(INST_objectHUD);
				}
				INST_objectHUD = null;
			}
			break;
		}
	}

	private void StateNormalRelease()
	{

        switch (objectAlignment)
		{
		case 0:
			base.tag = "TmA";
			break;
		case 1:
			base.tag = "TmB";
			break;
		}
		GameScriptsManager.gameStatisticScript.characterAnimationNumber = 6;
		VELOCITY_attributeSpeedValue = 0f;
		ROLL_triggerCritical = UnityEngine.Random.Range(0, 100);
		if (attributeCriticalValue >= ROLL_triggerCritical)
		{
			TOGGLE_triggerCritical = 3;
		}
		else
		{
			TOGGLE_triggerCritical = 0;
		}
		switch (objectType)
		{
		case 0:
			TOGGLE_velocityStagger = 0;
			COLLIDER_objectControl.enabled = true;
			myTransform.LookAt(VECTOR_touchPos);
			break;
		case 1:
			TOGGLE_velocityStagger = 0;
			myTransform.LookAt(VECTOR_touchPos);
			break;
		case 2:
		{
			COLLIDER_objectControl.enabled = true;
			Vector3 position2 = myTransform.position;
			VECTORX_objectBlockDropPosition = position2.x;
			RIGIDBODY_objectControl.isKinematic = false;
			myTransform.Translate(-myTransform.up * 0.01f * Time.smoothDeltaTime, Space.World);
			TOGGLE_selfDamage = 0;
			break;
		}
		case 3:
		{
			COLLIDER_objectControl.enabled = true;
			Vector3 position = myTransform.position;
			VECTORX_objectBlockDropPosition = position.x;
			RIGIDBODY_objectControl.isKinematic = false;
			myTransform.Translate(-myTransform.up * 0.01f * Time.smoothDeltaTime, Space.World);
			break;
		}
		}
		objectState++;
        Camera_Control.instance.isObjectClciked = false;

    }

    private void StateNormalUnleased()
	{
		switch (objectType)
		{
		case 0:
			ObjectUnleasedFlyingFunction();
			break;
		case 1:
			ObjectUnleasedFlyingFunction();
			ObjectUnleasedWeaponTriggerFunction();
			break;
		case 2:
			ObjectUnleasedBlockDropFunction();
			ObjectUnleasedBlockTriggerFunction();
			break;
		case 3:
			ObjectUnleasedDropFunction();
			break;
		}
	}

	private void ObjectEffect()
	{
	}

	private void ObjectUnleasedDropFunction()
	{
		Vector3 position = myTransform.position;
		if (position.y < 0.1f)
		{
			objectState = 5;
		}
		Vector3 position2 = myTransform.position;
		if (position2.x != VECTORX_objectBlockDropPosition)
		{
			Transform transform = myTransform;
			float vECTORX_objectBlockDropPosition = VECTORX_objectBlockDropPosition;
			Vector3 position3 = myTransform.position;
			transform.position = new Vector3(vECTORX_objectBlockDropPosition, position3.y, VECTOR_pickUpPositionZ);
		}
	}

	private void ObjectUnleasedFlyingFunction()
	{
		myTransform.Translate(myTransform.forward * VELOCITY_attributeSpeedValue * Time.smoothDeltaTime, Space.World);
		switch (TOGGLE_velocityStagger)
		{
		case 0:
			switch (LEVEL_chargeLevel)
			{
			case 0:
				if (VELOCITY_attributeSpeedValue < attributeSpeedValue)
				{
					VELOCITY_attributeSpeedValue += attributeSpeedValue * 0.5f;
				}
				else if (VELOCITY_attributeSpeedValue >= attributeSpeedValue)
				{
					VELOCITY_attributeSpeedValue = attributeSpeedValue;
				}
				break;
			case 1:
				if (VELOCITY_attributeSpeedValue < attributeSpeedValue * 1.5f)
				{
					VELOCITY_attributeSpeedValue += attributeSpeedValue * 1.5f * 0.5f;
				}
				else if (VELOCITY_attributeSpeedValue >= attributeSpeedValue * 1.5f)
				{
					VELOCITY_attributeSpeedValue = attributeSpeedValue * 1.5f;
				}
				break;
			case 2:
				if (VELOCITY_attributeSpeedValue < attributeSpeedValue * 2f)
				{
					VELOCITY_attributeSpeedValue += attributeSpeedValue * 2f * 0.5f;
				}
				else if (VELOCITY_attributeSpeedValue >= attributeSpeedValue * 2f)
				{
					VELOCITY_attributeSpeedValue = attributeSpeedValue * 2f;
				}
				break;
			}
			break;
		case 1:
			TIMER_velocityStagger = Time.time + 0.1f;
			VELOCITY_attributeSpeedValue *= -0.25f;
			TOGGLE_velocityStagger++;
			break;
		case 2:
			if (Time.time >= TIMER_velocityStagger)
			{
				TOGGLE_velocityStagger = 0;
			}
			break;
		}
		Vector3 position = myTransform.position;
		if (position.y < 0.1f)
		{
			objectState = 5;
		}
		Vector3 position2 = myTransform.position;
		if (position2.y > 3.8f)
		{
			objectState = 5;
		}
		Vector3 position3 = myTransform.position;
		if (position3.x > 5f + stageLength)
		{
			objectState = 5;
		}
		Vector3 position4 = myTransform.position;
		if (position4.x < -5.4f)
		{
			objectState = 5;
		}
	}

	private void StateNormalBreak()
	{
		objectSprite.color = Color.white;
		if (INST_objectTrigger != null)
		{
			PoolManager.Pools["Effect Pool"].Despawn(INST_objectTrigger);
			INST_objectTrigger = null;
		}
		if (INST_objectBlockDetector != null)
		{
			INST_objectBlockDetector.GetComponent<Unit_Detection>().targetObject = null;
			INST_objectBlockDetector = null;
		}
		if (objectType == 1 || objectType == 2)
		{
			if (scriptObjectAttributes.Offense.Length > 3 && scriptObjectAttributes.Offense[3].spawnObject != null)
			{
				if (effectBreakPosition == null)
				{
					effectBreakPosition = base.gameObject;
				}
				INST_objectBreakTrigger = PoolManager.Pools["Effect Pool"].Spawn(scriptObjectAttributes.Offense[3].spawnObject.transform, effectBreakPosition.transform.position, scriptObjectAttributes.Offense[3].spawnObject.transform.rotation);
				scriptObjectAttributes.offenseNumber = 3;
				if (INST_objectBreakTrigger.GetComponent<_Trigger>() != null)
				{
					scriptObjectAttributes.TriggerTransfer(INST_objectBreakTrigger.GetComponent<_Trigger>(), TOGGLE_triggerCritical);
				}
			}
		}
		else if (scriptObjectAttributes.Offense[LEVEL_chargeLevel].spawnObject != null)
		{
			if (effectBreakPosition == null)
			{
				effectBreakPosition = base.gameObject;
			}
			INST_objectBreakTrigger = PoolManager.Pools["Effect Pool"].Spawn(scriptObjectAttributes.Offense[LEVEL_chargeLevel].spawnObject.transform, effectBreakPosition.transform.position, scriptObjectAttributes.Offense[LEVEL_chargeLevel].spawnObject.transform.rotation);
			scriptObjectAttributes.offenseNumber = LEVEL_chargeLevel;
			if (INST_objectBreakTrigger.GetComponent<_Trigger>() != null)
			{
				scriptObjectAttributes.TriggerTransfer(INST_objectBreakTrigger.GetComponent<_Trigger>(), TOGGLE_triggerCritical);
			}
		}
		state = 2;
	}

	private void ObjectPickUpAimChargeFunction()
	{
		objectChargeState = LEVEL_chargeLevel;
		if (LEVEL_chargeLevel < 2 && Time.time >= TIMER_chargeLevel + attributeChargeUpDuration)
		{
			LEVEL_chargeLevel++;
			TIMER_chargeLevel = Time.time;
		}
	}

	private void ObjectPickUpFollowChargeFunction()
	{
		objectChargeState = LEVEL_chargeLevel;
		Vector3 position = myTransform.position;
		if (position.y < 2f)
		{
			LEVEL_chargeLevel = 0;
			return;
		}
		Vector3 position2 = myTransform.position;
		if (position2.y >= 2f)
		{
			Vector3 position3 = myTransform.position;
			if (position3.y < 3f)
			{
				LEVEL_chargeLevel = 1;
				return;
			}
		}
		Vector3 position4 = myTransform.position;
		if (position4.y >= 3f)
		{
			LEVEL_chargeLevel = 2;
		}
	}

	private void ObjectPickUpAimFunction()
	{
		Vector3 vector = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		float x = vector.x;
		Vector3 vector2 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		VECTOR_touchPos = new Vector3(x, vector2.y, VECTOR_pickUpPositionZ);
	}

	private void ObjectUnleasedWeaponTriggerFunction()
	{
		if (INST_objectTrigger == null)
		{
			INST_objectTrigger = PoolManager.Pools["Effect Pool"].Spawn(objectTrigger.transform, myTransform.position, myTransform.rotation);
			INST_objectTrigger.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.4f, 0.4f);
			scriptObjectAttributes.offenseNumber = LEVEL_chargeLevel;
			scriptObjectAttributes.TriggerTransfer(INST_objectTrigger.GetComponent<_Trigger>(), TOGGLE_triggerCritical);
		}
		if (INST_objectTrigger != null)
		{
			INST_objectTrigger.transform.position = myTransform.position;
		}
	}

	private void ObjectUnleasedBlockTriggerFunction()
	{
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		if (velocity.y <= -0.5f)
		{
			Vector3 velocity2 = GetComponent<Rigidbody>().velocity;
			if (velocity2.y > -2f)
			{
				if (INST_objectTrigger == null)
				{
					INST_objectTrigger = PoolManager.Pools["Effect Pool"].Spawn(objectTrigger.transform, myTransform.position, myTransform.rotation);
					BoxCollider component = INST_objectTrigger.GetComponent<BoxCollider>();
					Vector3 size = GetComponent<BoxCollider>().size;
					component.size = new Vector3(0.1f, 0.3f, size.z + 0.2f);
					scriptObjectAttributes.offenseNumber = 0;
					scriptObjectAttributes.TriggerTransfer(INST_objectTrigger.GetComponent<_Trigger>(), TOGGLE_triggerCritical);
				}
				if (INST_objectTrigger != null)
				{
					INST_objectTrigger.transform.position = myTransform.position;
					if (scriptObjectAttributes.offenseNumber != 0)
					{
						scriptObjectAttributes.offenseNumber = 0;
						scriptObjectAttributes.TriggerTransfer(INST_objectTrigger.GetComponent<_Trigger>(), TOGGLE_triggerCritical);
					}
				}
				return;
			}
		}
		Vector3 velocity3 = GetComponent<Rigidbody>().velocity;
		if (velocity3.y <= -2f)
		{
			if (INST_objectTrigger == null)
			{
				INST_objectTrigger = PoolManager.Pools["Effect Pool"].Spawn(objectTrigger.transform, myTransform.position, myTransform.rotation);
				BoxCollider component2 = INST_objectTrigger.GetComponent<BoxCollider>();
				Vector3 size2 = GetComponent<BoxCollider>().size;
				component2.size = new Vector3(0.1f, 0.3f, size2.z + 0.2f);
				scriptObjectAttributes.offenseNumber = LEVEL_chargeLevel;
				scriptObjectAttributes.TriggerTransfer(INST_objectTrigger.GetComponent<_Trigger>(), TOGGLE_triggerCritical);
			}
			if (INST_objectTrigger != null)
			{
				INST_objectTrigger.transform.position = myTransform.position;
				if (scriptObjectAttributes.offenseNumber != LEVEL_chargeLevel)
				{
					scriptObjectAttributes.offenseNumber = LEVEL_chargeLevel;
					scriptObjectAttributes.TriggerTransfer(INST_objectTrigger.GetComponent<_Trigger>(), TOGGLE_triggerCritical);
				}
			}
			return;
		}
		Vector3 velocity4 = GetComponent<Rigidbody>().velocity;
		if (velocity4.y > -0.5f && INST_objectTrigger != null)
		{
			if (scriptObjectAttributes.dropEffect != null)
			{
				SpawnPool spawnPool = PoolManager.Pools["VFX Pool"];
				Transform transform = scriptObjectAttributes.dropEffect.transform;
				Vector3 position = myTransform.position;
				float x = position.x;
				Vector3 position2 = myTransform.position;
				float y = position2.y;
				Vector3 position3 = myTransform.position;
				spawnPool.Spawn(transform, new Vector3(x, y, position3.z - 0.01f), scriptObjectAttributes.dropEffect.transform.rotation);
			}
			PoolManager.Pools["Effect Pool"].Despawn(INST_objectTrigger);
			INST_objectTrigger = null;
		}
	}

	private void ObjectUnleasedBlockDropFunction()
	{
		Vector3 position = myTransform.position;
		if (position.x < -2.5f)
		{
			objectState = 5;
		}
		Vector3 position2 = myTransform.position;
		if (position2.y <= 0.1f)
		{
			switch (objectAlignment)
			{
			case 0:
			{
				Vector3 position4 = myTransform.position;
				VECTOR_objectBlockDetector = new Vector3(position4.x, -1.5f, 1f);
				break;
			}
			case 1:
			{
				Vector3 position3 = myTransform.position;
				VECTOR_objectBlockDetector = new Vector3(position3.x, -1.5f, 0f);
				break;
			}
			}
			Vector3 position5 = myTransform.position;
			VECTORX_objectBlockDropPosition = position5.x;
			if (INST_objectBlockDetector == null)
			{
				INST_objectBlockDetector = PoolManager.Pools["HUD Pool"].Spawn(objectBlockDetector.transform, VECTOR_objectBlockDetector, myTransform.rotation);
				INST_objectBlockDetector.GetComponent<Unit_Detection>().targetObject = base.gameObject;
				BoxCollider component = INST_objectBlockDetector.GetComponent<BoxCollider>();
				Vector3 size = GetComponent<BoxCollider>().size;
				component.size = new Vector3(0.5f, 0.5f, size.z);
			}
			if (INST_objectBlockDetector != null)
			{
				Vector3 position6 = INST_objectBlockDetector.transform.position;
				float x = position6.x;
				Vector3 position7 = myTransform.position;
				if (x != position7.x)
				{
					INST_objectBlockDetector.transform.position = VECTOR_objectBlockDetector;
				}
			}
			if (!RIGIDBODY_objectControl.isKinematic)
			{
				RIGIDBODY_objectControl.isKinematic = true;
			}
			Transform transform = myTransform;
			Vector3 position8 = myTransform.position;
			transform.position = new Vector3(position8.x, 0.1f, VECTOR_pickUpPositionZ - 0.1f);
			Vector3 position9 = myTransform.position;
			if (!(position9.x >= 4.6f + stageLength))
			{
				return;
			}
			switch (TOGGLE_selfDamage)
			{
			case 0:
				TIMER_selfDamage = Time.time + UnityEngine.Random.Range(0.1f, 3f);
				TOGGLE_selfDamage = 1;
				break;
			case 1:
				if (Time.time >= TIMER_selfDamage)
				{
					AttributeEffectHP(1, UnityEngine.Random.Range(1, 5), 0);
					TOGGLE_selfDamage = 0;
				}
				break;
			}
			return;
		}
		Vector3 position10 = myTransform.position;
		if (position10.y > 0.1f)
		{
			Vector3 position11 = myTransform.position;
			if (position11.x != VECTORX_objectBlockDropPosition)
			{
				Transform transform2 = myTransform;
				float vECTORX_objectBlockDropPosition = VECTORX_objectBlockDropPosition;
				Vector3 position12 = myTransform.position;
				transform2.position = new Vector3(vECTORX_objectBlockDropPosition, position12.y, VECTOR_pickUpPositionZ);
			}
		}
	}

	private void ObjectPickUpFollowFunction()
	{
		Vector3 position = myTransform.position;
		if (position.y < 1.5f)
		{
			myTransform.position = new Vector3(VECTOR_touchPos.x, 1.525f, VECTOR_pickUpPositionZ);
		}
		Vector3 vector = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		if (vector.y >= 3.5f)
		{
			VECTOR_touchPos = new Vector3(VECTOR_touchPos.x, 3.5f, VECTOR_pickUpPositionZ);
		}
		else
		{
			Vector3 vector2 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
			if (vector2.y <= 1.5f)
			{
				VECTOR_touchPos = new Vector3(VECTOR_touchPos.x, 1.5f, VECTOR_pickUpPositionZ);
			}
			else
			{
				Vector3 vector3 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				if (vector3.y < 3.5f)
				{
					Vector3 vector4 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
					if (vector4.y > 1.5f)
					{
						float x = VECTOR_touchPos.x;
						Vector3 vector5 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
						VECTOR_touchPos = new Vector3(x, vector5.y, VECTOR_pickUpPositionZ);
					}
				}
			}
		}
		Vector3 vector6 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		if (vector6.x <= -2.25f)
		{
			VECTOR_touchPos = new Vector3(-2.25f, VECTOR_touchPos.y, VECTOR_pickUpPositionZ);
		}
		else
		{
			Vector3 vector7 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
			if (vector7.x >= 5f + stageLength)
			{
				VECTOR_touchPos = new Vector3(5f + stageLength, VECTOR_touchPos.y, VECTOR_pickUpPositionZ);
			}
			else
			{
				Vector3 vector8 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				if (vector8.x > -2.25f)
				{
					Vector3 vector9 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
					if (vector9.x < 5f + stageLength)
					{
						Vector3 vector10 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
						VECTOR_touchPos = new Vector3(vector10.x, VECTOR_touchPos.y, VECTOR_pickUpPositionZ);
					}
				}
			}
		}
		myTransform.position = Vector3.Lerp(myTransform.position, VECTOR_touchPos, Time.smoothDeltaTime * 8f);
	}

	private void UnitToggleColorFunction(int colorState)
	{
		if (colorState > 0)
		{
			switch (colorState)
			{
			case 1:
				objectColorState = colorState;
				TIMER_objectColorState = Time.time + 0.5f;
				break;
			case 2:
				objectColorState = colorState;
				TIMER_objectColorState = Time.time + 1f;
				break;
			case 3:
				objectColorState = 1;
				TIMER_objectColorState = Time.time + 0.25f;
				break;
			case 4:
				objectColorState = 2;
				TIMER_objectColorState = Time.time + 0.25f;
				break;
			}
			colorState = 0;
		}
	}

	private void UnitColorFunction()
	{
		switch (objectColorState)
		{
		case 0:
			break;
		case -1:
			objectSprite.color = COLOR_unitColorDefault;
			TIMER_objectColorState = 0f;
			objectColorState = 0;
			break;
		case 1:
			if (Time.time < TIMER_objectColorState)
			{
				objectSprite.color = COLOR_unitColorDamaged;
			}
			else if (Time.time >= TIMER_objectColorState)
			{
				objectSprite.color = Color.white;
				objectColorState = 0;
			}
			break;
		case 2:
			if (Time.time < TIMER_objectColorState)
			{
				objectSprite.color = COLOR_unitColorHeal;
			}
			else if (Time.time >= TIMER_objectColorState)
			{
				objectSprite.color = Color.white;
				objectColorState = 0;
			}
			break;
		}
	}

	public void UnitEffectPropDisplay(int toggle, string text, int amount)
	{
		switch (toggle)
		{
		case 1:
			if (amount <= 0)
			{
				SIZE_effectTextDisplay = 2.5f;
				COLOR_effectTextDisplay = new Color(1f, 1f, 1f, 1f);
				FADE_effectTextDisplay = 0.05f;
			}
			else if (amount > 0 && amount <= 5)
			{
				SIZE_effectTextDisplay = 2.5f;
				COLOR_effectTextDisplay = new Color(1f, 0f, 0f, 1f);
				FADE_effectTextDisplay = 0.04f;
			}
			else if (amount > 5 && amount <= 10)
			{
				SIZE_effectTextDisplay = 3f;
				COLOR_effectTextDisplay = new Color(1f, 0.2f, 0f, 1f);
				FADE_effectTextDisplay = 0.03f;
			}
			else if (amount > 10 && amount <= 20)
			{
				SIZE_effectTextDisplay = 3.5f;
				COLOR_effectTextDisplay = new Color(1f, 0.4f, 0f, 1f);
				FADE_effectTextDisplay = 0.02f;
			}
			else if (amount > 20 && amount <= 30)
			{
				SIZE_effectTextDisplay = 4.5f;
				COLOR_effectTextDisplay = new Color(1f, 0.6f, 0f, 1f);
				FADE_effectTextDisplay = 0.01f;
			}
			else if (amount > 30)
			{
				SIZE_effectTextDisplay = 5.5f;
				COLOR_effectTextDisplay = new Color(1f, 0.8f, 0f, 1f);
				FADE_effectTextDisplay = 0.01f;
			}
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, effectPosition.transform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(effectPosition, 1, COLOR_effectTextDisplay, text, SIZE_effectTextDisplay, 0.1f, FADE_effectTextDisplay, 0.5f, 0.35f);
			toggle = 0;
			break;
		case 3:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, effectPosition.transform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(effectPosition, 1, new Color(1f, 0.6f, 0f, 1f), "critical", 3f, 0.1f, 0.05f, -0.1f, 0f);
			toggle = 0;
			break;
		case 12:
			INST_effectTextDisplay = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, myTransform.position, effectPropertyDisplay.transform.rotation);
			INST_effectTextDisplay.GetComponent<Effect_Property_Display>().HitEffectText(base.gameObject, 1, new Color(1f, 0.6f, 0f, 1f), "instant", 3f, 0.1f, 0.05f, -0.1f, 0f);
			toggle = 0;
			break;
		}
	}

	public void AttributeEffectHP(int Toggle, int amount, int pureEffect)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				switch (pureEffect)
				{
				case 0:
					AMOUNT_attributeEffectHP = Mathf.RoundToInt((float)amount + attributeDamageMultiplier);
					break;
				case 1:
					if (attributeDamageMultiplier > 1f)
					{
						AMOUNT_attributeEffectHP = Mathf.RoundToInt((float)amount + attributeDamageMultiplier);
					}
					else
					{
						AMOUNT_attributeEffectHP = Mathf.RoundToInt(amount);
					}
					break;
				case 2:
					AMOUNT_attributeEffectHP = Mathf.RoundToInt(amount);
					break;
				case 3:
					AMOUNT_attributeEffectHP = attributeHealthMaximumValue + 1;
					break;
				}
				if (AMOUNT_attributeEffectHP <= 0 && amount != 0)
				{
					AMOUNT_attributeEffectHP = 1;
				}
				TOGGLE_attributeEffectHP = Toggle;
				Toggle = 0;
				break;
			case 2:
				AMOUNT_attributeEffectHP = amount;
				if (AMOUNT_attributeEffectHP <= 0 && amount != 0)
				{
					AMOUNT_attributeEffectHP = 1;
				}
				TOGGLE_attributeEffectHP = Toggle;
				Toggle = 0;
				break;
			case 3:
				AMOUNT_attributeEffectHP = Mathf.RoundToInt(amount);
				if (AMOUNT_attributeEffectHP <= 0 && amount != 0)
				{
					AMOUNT_attributeEffectHP = 1;
				}
				TOGGLE_attributeEffectHP = Toggle;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectHP()
	{
		switch (TOGGLE_attributeEffectHP)
		{
		case 0:
			break;
		case -1:
			AMOUNT_attributeEffectHP = 0;
			TOGGLE_attributeEffectHP = 0;
			break;
		case 1:
			UnitToggleColorFunction(1);
			UnitEffectPropDisplay(1, string.Empty + AMOUNT_attributeEffectHP, AMOUNT_attributeEffectHP);
			TOGGLE_velocityStagger = 1;
			attributeHealthValue -= AMOUNT_attributeEffectHP;
			TOGGLE_attributeEffectHP = 0;
			break;
		case 2:
			UnitToggleColorFunction(2);
			if (AMOUNT_attributeEffectHP + attributeHealthValue <= attributeHealthMaximumValue)
			{
				UnitEffectPropDisplay(6, "+" + AMOUNT_attributeEffectHP, 0);
				attributeHealthValue += AMOUNT_attributeEffectHP;
			}
			else if (attributeHealthMaximumValue - attributeHealthValue <= attributeHealthMaximumValue)
			{
				AMOUNT_attributeEffectHP = attributeHealthMaximumValue - attributeHealthValue;
				UnitEffectPropDisplay(6, "+" + AMOUNT_attributeEffectHP, 0);
				attributeHealthValue += AMOUNT_attributeEffectHP;
			}
			else
			{
				UnitEffectPropDisplay(6, "0", 0);
			}
			TOGGLE_attributeEffectHP = 0;
			break;
		case 3:
			UnitToggleColorFunction(1);
			UnitEffectPropDisplay(8, "-" + AMOUNT_attributeEffectHP, AMOUNT_attributeEffectHP);
			attributeHealthValue -= AMOUNT_attributeEffectHP;
			TOGGLE_attributeEffectHP = 0;
			break;
		}
	}

	public void AttributeOverTimeEffectHP(int Toggle, int amount, int number, float delay, int effectClass, int effectNumber)
	{
		if (state == 1)
		{
			switch (Toggle)
			{
			case 1:
				EFFECTCLASS_attributeOverTimeEffectHP = effectClass;
				EFFECTNUMBER_attributeOverTimeEffectHP = effectNumber;
				DELAY_attributeOverTimeEffectHP = delay;
				TIMER_attributeOverTimeEffectHP = Time.time + delay;
				NUMBER_attributeOverTimeEffectHP = number;
				AMOUNT_attributeOverTimeEffectHP = amount;
				TOGGLE_attributeOverTimeEffectHP = Toggle;
				Toggle = 0;
				break;
			case 2:
				EFFECTCLASS_attributeOverTimeEffectHP = effectClass;
				EFFECTNUMBER_attributeOverTimeEffectHP = effectNumber;
				DELAY_attributeOverTimeEffectHP = delay;
				TIMER_attributeOverTimeEffectHP = Time.time + delay;
				NUMBER_attributeOverTimeEffectHP = number;
				AMOUNT_attributeOverTimeEffectHP = amount;
				TOGGLE_attributeOverTimeEffectHP = Toggle;
				Toggle = 0;
				break;
			case 3:
				EFFECTCLASS_attributeOverTimeEffectHP = effectClass;
				EFFECTNUMBER_attributeOverTimeEffectHP = effectNumber;
				DELAY_attributeOverTimeEffectHP = delay;
				TIMER_attributeOverTimeEffectHP = Time.time + delay;
				NUMBER_attributeOverTimeEffectHP = number;
				AMOUNT_attributeOverTimeEffectHP = amount;
				TOGGLE_attributeOverTimeEffectHP = Toggle;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeOverTimeEffectHP()
	{
		switch (TOGGLE_attributeOverTimeEffectHP)
		{
		case 0:
			break;
		case -1:
			NUMBER_attributeOverTimeEffectHP = 0;
			DELAY_attributeOverTimeEffectHP = 0f;
			TIMER_attributeOverTimeEffectHP = 0f;
			AMOUNT_attributeOverTimeEffectHP = 0;
			TOGGLE_attributeOverTimeEffectHP = 0;
			break;
		case 1:
			if (NUMBER_attributeOverTimeEffectHP > 0)
			{
				if (Time.time >= TIMER_attributeOverTimeEffectHP)
				{
					if (EFFECTNUMBER_attributeOverTimeEffectHP != 0)
					{
						INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, effectPosition.transform.position, effectHitDisplay.transform.rotation);
						INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, effectPosition, EFFECTCLASS_attributeOverTimeEffectHP, EFFECTNUMBER_attributeOverTimeEffectHP);
					}
					UnitToggleColorFunction(3);
					AttributeEffectHP(1, Mathf.RoundToInt((float)AMOUNT_attributeOverTimeEffectHP * attributeDamageMultiplier), 0);
					NUMBER_attributeOverTimeEffectHP--;
					TOGGLE_velocityStagger = 1;
					TIMER_attributeOverTimeEffectHP = Time.time + DELAY_attributeOverTimeEffectHP;
				}
			}
			else
			{
				TOGGLE_attributeOverTimeEffectHP = 0;
			}
			break;
		case 2:
			if (NUMBER_attributeOverTimeEffectHP > 0)
			{
				if (Time.time >= TIMER_attributeOverTimeEffectHP)
				{
					if (EFFECTNUMBER_attributeOverTimeEffectHP != 0)
					{
						INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, effectPosition.transform.position, effectHitDisplay.transform.rotation);
						INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, effectPosition, EFFECTCLASS_attributeOverTimeEffectHP, EFFECTNUMBER_attributeOverTimeEffectHP);
					}
					UnitToggleColorFunction(4);
					AttributeEffectHP(2, AMOUNT_attributeOverTimeEffectHP, 0);
					NUMBER_attributeOverTimeEffectHP--;
					TIMER_attributeOverTimeEffectHP = Time.time + DELAY_attributeOverTimeEffectHP;
				}
			}
			else
			{
				TOGGLE_attributeOverTimeEffectHP = 0;
			}
			break;
		case 3:
			if (TOGGLE_attributeEffectHP == 1)
			{
				NUMBER_attributeOverTimeEffectHP = 0;
			}
			if (NUMBER_attributeOverTimeEffectHP > 0)
			{
				if (Time.time >= TIMER_attributeOverTimeEffectHP)
				{
					if (EFFECTNUMBER_attributeOverTimeEffectHP != 0)
					{
						INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, effectPosition.transform.position, effectHitDisplay.transform.rotation);
						INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, effectPosition, EFFECTCLASS_attributeOverTimeEffectHP, EFFECTNUMBER_attributeOverTimeEffectHP);
					}
					UnitToggleColorFunction(4);
					AttributeEffectHP(2, AMOUNT_attributeOverTimeEffectHP, 0);
					NUMBER_attributeOverTimeEffectHP--;
					TIMER_attributeOverTimeEffectHP = Time.time + DELAY_attributeOverTimeEffectHP;
				}
			}
			else
			{
				TOGGLE_attributeOverTimeEffectHP = 0;
			}
			break;
		}
	}

	public void AttributeEffectAP(int Toggle, int amount, float duration)
	{
		if (state == 1 && objectType == 2)
		{
			switch (Toggle)
			{
			case 1:
				TIMER_attributeEffectAP = Time.time + duration;
				AMOUNT_attributeEffectAP = amount;
				TOGGLE_attributeEffectAP = 1;
				Toggle = 0;
				break;
			case 2:
				if (TOGGLE_attributeEffectAP == 0)
				{
					TIMER_attributeEffectAP = Time.time + duration;
					AMOUNT_attributeEffectAP = amount;
				}
				else
				{
					TIMER_attributeEffectAP += duration;
					AMOUNT_attributeEffectAP += amount;
				}
				TOGGLE_attributeEffectAP = 1;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectAP()
	{
		switch (TOGGLE_attributeEffectAP)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectAP = 0f;
			AMOUNT_attributeEffectAP = 0;
			TOGGLE_attributeEffectAP = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectAP)
			{
				scriptObjectAttributes.plusArmorPoint = AMOUNT_attributeEffectAP;
			}
			else if (Time.time >= TIMER_attributeEffectAP)
			{
				scriptObjectAttributes.plusArmorPoint = 0;
				AMOUNT_attributeEffectAP = 0;
				TOGGLE_attributeEffectAP = 0;
			}
			break;
		}
	}

	public void AttributeEffectANP(int Toggle, int amount, float duration)
	{
		if (state == 1 && objectType == 2)
		{
			switch (Toggle)
			{
			case 1:
				TIMER_attributeEffectANP = Time.time + duration;
				AMOUNT_attributeEffectANP = amount;
				TOGGLE_attributeEffectANP = 1;
				Toggle = 0;
				break;
			case 2:
				if (TOGGLE_attributeEffectANP == 0)
				{
					TIMER_attributeEffectANP = Time.time + duration;
					AMOUNT_attributeEffectANP = amount;
				}
				else
				{
					TIMER_attributeEffectANP += duration;
					AMOUNT_attributeEffectANP += amount;
				}
				TOGGLE_attributeEffectANP = 1;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void AttributeEffectANP()
	{
		switch (TOGGLE_attributeEffectANP)
		{
		case 0:
			break;
		case -1:
			TIMER_attributeEffectANP = 0f;
			AMOUNT_attributeEffectANP = 0;
			TOGGLE_attributeEffectANP = 0;
			break;
		case 1:
			if (Time.time < TIMER_attributeEffectANP)
			{
				scriptObjectAttributes.plusAnchorPoint = AMOUNT_attributeEffectANP;
			}
			else if (Time.time >= TIMER_attributeEffectANP)
			{
				scriptObjectAttributes.plusAnchorPoint = 0;
				AMOUNT_attributeEffectANP = 0;
				TOGGLE_attributeEffectANP = 0;
			}
			break;
		}
	}

	public void UnitEffectKnock(int Toggle, float Duration, float Distance, float Damping)
	{
		if (state == 1 && objectType == 2)
		{
			if (Toggle != 1)
			{
				return;
			}
			if (TOGGLE_unitEffectKnock == 0)
			{
				TIMER_unitEffectKnock = Time.time + Duration;
				switch (objectAlignment)
				{
				case 0:
				{
					Vector3 position3 = myTransform.position;
					float x2 = position3.x - Distance;
					Vector3 position4 = myTransform.position;
					VECTOR_unitEffectKnock = new Vector3(x2, position4.y, 0f);
					break;
				}
				case 1:
				{
					Vector3 position = myTransform.position;
					float x = position.x + Distance;
					Vector3 position2 = myTransform.position;
					VECTOR_unitEffectKnock = new Vector3(x, position2.y, 0f);
					break;
				}
				}
				DAMPING_unitEffectKnock = Damping;
			}
			else
			{
				switch (objectAlignment)
				{
				case 0:
				{
					float x4 = VECTOR_unitEffectKnock.x - Distance;
					Vector3 position6 = myTransform.position;
					VECTOR_unitEffectKnock = new Vector3(x4, position6.y, 0f);
					break;
				}
				case 1:
				{
					float x3 = VECTOR_unitEffectKnock.x + Distance;
					Vector3 position5 = myTransform.position;
					VECTOR_unitEffectKnock = new Vector3(x3, position5.y, 0f);
					break;
				}
				}
				TIMER_unitEffectKnock += Duration / 2f;
				if (Damping > DAMPING_unitEffectKnock)
				{
					DAMPING_unitEffectKnock = Damping;
				}
			}
			TOGGLE_unitEffectKnock = Toggle;
			Toggle = 0;
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitEffectKnock()
	{
		switch (TOGGLE_unitEffectKnock)
		{
		case 0:
			break;
		case -1:
			if (TOGGLE_unitEffectKnock != 0)
			{
				TIMER_unitEffectKnock = 0f;
				DAMPING_unitEffectKnock = 0f;
				TOGGLE_unitEffectKnock = 0;
			}
			break;
		case 1:
			if (Time.time < TIMER_unitEffectKnock)
			{
				Transform transform = myTransform;
				Vector3 position = myTransform.position;
				float x = VECTOR_unitEffectKnock.x;
				Vector3 position2 = myTransform.position;
				float y = position2.y;
				Vector3 position3 = myTransform.position;
				transform.position = Vector3.Lerp(position, new Vector3(x, y, position3.z), Time.deltaTime * DAMPING_unitEffectKnock);
			}
			else if (Time.time >= TIMER_unitEffectKnock)
			{
				TOGGLE_unitEffectKnock = 0;
			}
			break;
		}
	}

	public void UnitEffectRise(int Toggle, float Duration, float Height, float Damping)
	{
		if (state == 1 && objectType == 2)
		{
			switch (Toggle)
			{
			case 1:
				if (TOGGLE_unitEffectRise == 0)
				{
					TIMER_unitEffectRise = Time.time + Duration;
					Vector3 localPosition3 = myTransform.localPosition;
					VECTOR_unitEffectRise = new Vector3(localPosition3.x, Height, 0f);
					DAMPING_unitEffectRise = Damping;
				}
				else
				{
					if (VECTOR_unitEffectRise.y < Height)
					{
						Vector3 position2 = myTransform.position;
						VECTOR_unitEffectRise = new Vector3(position2.x, Height, 0f);
					}
					if (Time.time + Duration > TIMER_unitEffectRise)
					{
						TIMER_unitEffectRise = Time.time + Duration;
					}
					if (Damping > DAMPING_unitEffectRise)
					{
						DAMPING_unitEffectRise = Damping;
					}
				}
				TOGGLE_unitEffectRise = Toggle;
				Toggle = 0;
				break;
			case 2:
				if (TOGGLE_unitEffectRise == 0)
				{
					TIMER_unitEffectRise = Time.time + Duration;
					Vector3 localPosition = myTransform.localPosition;
					float x = localPosition.x;
					Vector3 localPosition2 = myTransform.localPosition;
					VECTOR_unitEffectRise = new Vector3(x, localPosition2.y + Height, 0f);
					DAMPING_unitEffectRise = Damping;
				}
				else
				{
					Vector3 position = myTransform.position;
					VECTOR_unitEffectRise = new Vector3(position.x, VECTOR_unitEffectRise.y + Height, 0f);
					TIMER_unitEffectRise += Duration;
					if (Damping > DAMPING_unitEffectRise)
					{
						DAMPING_unitEffectRise = Damping;
					}
				}
				TOGGLE_unitEffectRise = 1;
				Toggle = 0;
				break;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitEffectRise()
	{
		switch (TOGGLE_unitEffectRise)
		{
		case 0:
			break;
		case -1:
			if (TOGGLE_unitEffectRise != 0)
			{
				TIMER_unitEffectRise = 0f;
				DAMPING_unitEffectRise = 0f;
				TOGGLE_unitEffectRise = 0;
			}
			TOGGLE_unitEffectRise = 0;
			break;
		case 1:
			if (Time.time < TIMER_unitEffectRise)
			{
				Transform transform = myTransform;
				Vector3 position = myTransform.position;
				Vector3 position2 = myTransform.position;
				float x = position2.x;
				float y = VECTOR_unitEffectRise.y;
				Vector3 position3 = myTransform.position;
				transform.position = Vector3.Lerp(position, new Vector3(x, y, position3.z), Time.deltaTime * DAMPING_unitEffectRise);
			}
			else if (Time.time >= TIMER_unitEffectRise)
			{
				if (INST_objectBlockDetector != null)
				{
					INST_objectBlockDetector.GetComponent<Unit_Detection>().targetObject = null;
					INST_objectBlockDetector = null;
				}
				RIGIDBODY_objectControl.isKinematic = false;
				myTransform.Translate(-myTransform.up * 0.01f * Time.smoothDeltaTime, Space.World);
				TOGGLE_unitEffectRise = 0;
			}
			break;
		}
	}

	private void AttributePropDisplay()
	{
		if (objectState == 4)
		{
			if (TOGGLE_unitAttributeArmorPoint == AMOUNT_attributeEffectAP)
			{
				return;
			}
			if (AMOUNT_attributeEffectAP != 0)
			{
				if (INST_effectArmorState == null)
				{
					INST_effectArmorState = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, effectPosition.transform.position, effectPropertyDisplay.transform.rotation);
				}
				if (AMOUNT_attributeEffectAP > 0)
				{
					INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, -1, 1, 2, 0f);
				}
				else if (AMOUNT_attributeEffectAP < 0)
				{
					INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 1, -1, 1, 1, 0f);
				}
			}
			else if (INST_effectArmorState != null)
			{
				INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
				INST_effectArmorState = null;
			}
			TOGGLE_unitAttributeArmorPoint = AMOUNT_attributeEffectAP;
		}
		else if (INST_effectArmorState != null)
		{
			INST_effectArmorState.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
			INST_effectArmorState = null;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		int num = state;
		if (num != 1 || objectState != 4 || !(scriptTrigger == null) || !(Time.time >= TIMER_triggerDelay) || other.gameObject.name == ID_triggerName || !(other.gameObject.name != ID_triggerName))
		{
			return;
		}
		switch (objectAlignment)
		{
		case 0:
			switch (objectType)
			{
			case 0:
				if (other.gameObject.CompareTag("TmB"))
				{
					objectState = 5;
				}
				break;
			case 2:
				if (other.gameObject.CompareTag("AtSA") || other.gameObject.CompareTag("AtSAB"))
				{
					TriggerDetectFunction(other.GetComponent<_Trigger>());
				}
				break;
			case 3:
				if (other.gameObject.CompareTag("TmB"))
				{
					objectState = 5;
				}
				break;
			}
			if (other.gameObject.CompareTag("AtAA") || other.gameObject.CompareTag("AtAAB"))
			{
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			if (other.gameObject.CompareTag("AtBA") || other.gameObject.CompareTag("AtBAB"))
			{
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			break;
		case 1:
			switch (objectType)
			{
			case 0:
				if (other.gameObject.CompareTag("TmA"))
				{
					objectState = 5;
				}
				break;
			case 2:
				if (other.gameObject.CompareTag("AtSB") || other.gameObject.CompareTag("AtSAB"))
				{
					TriggerDetectFunction(other.GetComponent<_Trigger>());
				}
				break;
			case 3:
				if (other.gameObject.CompareTag("TmA"))
				{
					objectState = 5;
				}
				break;
			}
			if (other.gameObject.CompareTag("AtAB") || other.gameObject.CompareTag("AtAAB"))
			{
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			if (other.gameObject.CompareTag("AtBB") || other.gameObject.CompareTag("AtBAB"))
			{
				TriggerDetectFunction(other.GetComponent<_Trigger>());
			}
			break;
		}
	}

	private void TriggerDetectFunction(_Trigger detectTrigger)
	{
		if (scriptTrigger == null)
		{
			scriptTrigger = detectTrigger;
			TIMER_triggerDelay = Time.time + 0.1f;
		}
	}

	private void TriggerFunction()
	{
		if (!(scriptTrigger != null))
		{
			return;
		}
		if (objectState == 4)
		{
			if (scriptTrigger.hpAttributeToggle > 0 && scriptTrigger.hpAttributeAmount > 0)
			{
				if (scriptTrigger.hpAttributeToggle == 1)
				{
					DAMAGE_setToggle = scriptTrigger.hpAttributeToggle;
					DAMAGE_setAmount = scriptTrigger.hpAttributeAmount;
					DAMAGE_pureEffect = scriptTrigger.pureEffect;
					if (scriptObjectAttributes.effectTypeDefense[scriptTrigger.effectType] != 0)
					{
						if (scriptObjectAttributes.effectTypeDefense[scriptTrigger.effectType] > 0)
						{
							if (scriptObjectAttributes.effectTypeDefense[scriptTrigger.effectType] >= 100)
							{
								DAMAGE_setToggle = 2;
							}
							else
							{
								DAMAGE_setAmount -= scriptObjectAttributes.effectTypeDefense[scriptTrigger.effectType];
								if (DAMAGE_setAmount < 1)
								{
									DAMAGE_setAmount = 1;
								}
							}
						}
						else if (scriptObjectAttributes.effectTypeDefense[scriptTrigger.effectType] < 0)
						{
							if (scriptObjectAttributes.effectTypeDefense[scriptTrigger.effectType] <= -100)
							{
								DAMAGE_setAmount = attributeHealthValue + 1;
								DAMAGE_pureEffect = 3;
								UnitEffectPropDisplay(12, string.Empty, 0);
							}
							else
							{
								DAMAGE_setAmount -= scriptObjectAttributes.effectTypeDefense[scriptTrigger.effectType];
							}
						}
					}
					if (scriptTrigger.effectClass >= 0 && scriptObjectAttributes.effectClassDefense[scriptTrigger.effectClass] != 0)
					{
						if (scriptObjectAttributes.effectClassDefense[scriptTrigger.effectClass] > 0)
						{
							if (scriptObjectAttributes.effectClassDefense[scriptTrigger.effectClass] >= 100)
							{
								DAMAGE_setToggle = 2;
							}
							else
							{
								DAMAGE_setAmount -= scriptObjectAttributes.effectClassDefense[scriptTrigger.effectType];
								if (DAMAGE_setAmount < 1)
								{
									DAMAGE_setAmount = 1;
								}
							}
						}
						else if (scriptObjectAttributes.effectClassDefense[scriptTrigger.effectClass] < 0)
						{
							if (scriptObjectAttributes.effectClassDefense[scriptTrigger.effectClass] <= -100)
							{
								DAMAGE_setAmount = attributeHealthValue + 1;
								DAMAGE_pureEffect = 3;
								UnitEffectPropDisplay(12, string.Empty, 0);
							}
							else
							{
								DAMAGE_setAmount -= scriptObjectAttributes.effectClassDefense[scriptTrigger.effectClass];
							}
						}
					}
					if (scriptTrigger.hpAttributeCriticalMultiplier > 1)
					{
						AttributeEffectHP(DAMAGE_setToggle, DAMAGE_setAmount * scriptTrigger.hpAttributeCriticalMultiplier, DAMAGE_pureEffect);
						UnitEffectPropDisplay(3, string.Empty, 0);
					}
					else
					{
						AttributeEffectHP(DAMAGE_setToggle, DAMAGE_setAmount, DAMAGE_pureEffect);
					}
				}
				else if (scriptTrigger.hpAttributeToggle == 2)
				{
					if (scriptTrigger.hpAttributeCriticalMultiplier > 1)
					{
						AttributeEffectHP(scriptTrigger.hpAttributeToggle, scriptTrigger.hpAttributeAmount * scriptTrigger.hpAttributeCriticalMultiplier, DAMAGE_pureEffect);
						UnitEffectPropDisplay(3, string.Empty, 0);
					}
					else
					{
						AttributeEffectHP(scriptTrigger.hpAttributeToggle, scriptTrigger.hpAttributeAmount, DAMAGE_pureEffect);
					}
				}
			}
			if (scriptTrigger.hpOverTimeAttributeToggle > 0)
			{
				AttributeOverTimeEffectHP(scriptTrigger.hpOverTimeAttributeToggle, scriptTrigger.hpOverTimeAttributeAmount, scriptTrigger.hpOverTimeAttributeNumber, scriptTrigger.hpOverTimeAttributeDelay, scriptTrigger.hpOverTimeAttributeEffectClass, scriptTrigger.hpOverTimeAttributeEffectNumber);
			}
			if (scriptTrigger.apAttributeToggle > 0)
			{
				AttributeEffectAP(scriptTrigger.apAttributeToggle, scriptTrigger.apAttributeAmount, scriptTrigger.apAttributeDuration);
			}
			switch (scriptTrigger.triggerType)
			{
			case 0:
				if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * scriptObjectAttributes.knockResistanceValue, scriptTrigger.knockEffectDamping);
				}
				break;
			case 1:
				if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance, scriptTrigger.knockEffectDamping);
				}
				break;
			case 2:
				if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * scriptObjectAttributes.knockResistanceValue, scriptTrigger.knockEffectDamping);
				}
				break;
			case 3:
				if (scriptTrigger.knockEffectToggle > 0)
				{
					UnitEffectKnock(scriptTrigger.knockEffectToggle, scriptTrigger.knockEffectDuration, scriptTrigger.knockEffectDistance * scriptObjectAttributes.knockResistanceValue, scriptTrigger.knockEffectDamping);
				}
				break;
			}
			if (scriptTrigger.riseEffectToggle > 0)
			{
			}
			if (scriptTrigger.effectSubID != 0)
			{
				INST_effectHitDisplay = PoolManager.Pools["VFX Pool"].Spawn(effectHitDisplay.transform, effectPosition.transform.position, effectHitDisplay.transform.rotation);
				INST_effectHitDisplay.GetComponent<Effect_Hit_Display>().HitEffectProperies(1, effectPosition, scriptTrigger.effectClass, scriptTrigger.effectSubID);
			}
			ID_triggerName = scriptTrigger.name;
			scriptTrigger = null;
		}
		else
		{
			UnitEffectPropDisplay(5, string.Empty, 0);
			ID_triggerName = scriptTrigger.name;
			scriptTrigger = null;
		}
	}
}
