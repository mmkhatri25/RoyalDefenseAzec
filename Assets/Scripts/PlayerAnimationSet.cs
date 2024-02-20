using UnityEngine;

public class PlayerAnimationSet : MonoBehaviour
{
	public string characterID = string.Empty;

	public int animationNumber;

	private int TOGGLE_animationNumber;

	public bool panicMark;

	public GameObject panicMarkObject;

	public tk2dAnimatedSprite characterSprite;

	private string blank = "blank";

	public string idleClipName = string.Empty;

	public string shockedClipName = string.Empty;

	public string defeatClipName = string.Empty;

	public string victoryClipName = string.Empty;

	public string tauntClipName = string.Empty;

	public string objectControlClipName = string.Empty;

	public string objectUnleashClipName = string.Empty;

	public string redSpellCastingClipName = string.Empty;

	public string redSpellUnleashClipName = string.Empty;

	public string blueSpellCastingClipName = string.Empty;

	public string blueSpellUnleashClipName = string.Empty;

	public string yellowSpellCastingClipName = string.Empty;

	public string yellowSpellUnleashClipName = string.Empty;

	public string greenSpellCastingClipName = string.Empty;

	public string greenSpellUnleashClipName = string.Empty;

	public string itemUseClipName = string.Empty;

	public string scrollCastingClipName = string.Empty;

	public string scrollUnleashClipName = string.Empty;

	public string movingClipName;

	public string disableClipName;

	public GameObject effectPropertyDisplay;

	public GameObject effectPosition;

	public int characterState;

	public float movementSpeed = 1f;

	private int TOGGLE_characterState;

	private int TOGGLE_positionLock;

	private float TIMER_unitEffectKnock;

	private Vector3 VECTOR_unitEffectKnock;

	private float DAMPING_unitEffectKnock;

	private int TOGGLE_unitEffectKnock;

	private Transform INST_effectStateDisable;

	private float TIMER_unitEffectDisable;

	private int TOGGLE_unitEffectDisable;

	public int characterAction;

	public float characterActionWorryAdjustmentX;

	private Vector3 spritePosition;

	private int TOGGLE_characterAction;

	private float ACTION_1ShakeThreshold = 0.01f;

	private float ACTION_1ShakeSpeed = 0.01f;

	private float ACTION_2WorryDuration = 0.5f;

	private float ACTION_3JumpThreshold = 0.1f;

	private float ACTION_4JumpThreshold = 0.3f;

	private float ACTION_2TIMER;

	private float ACTION_3TIMER;

	private float ACTION_3Duration = 0.5f;

	private float ACTION_position;

	private float ACTION_direction;

	private void Awake()
	{
		if (idleClipName == string.Empty)
		{
			idleClipName = "null";
		}
		if (shockedClipName == string.Empty)
		{
			shockedClipName = idleClipName;
		}
		if (defeatClipName == string.Empty)
		{
			defeatClipName = idleClipName;
		}
		if (victoryClipName == string.Empty)
		{
			victoryClipName = idleClipName;
		}
		if (tauntClipName == string.Empty)
		{
			tauntClipName = idleClipName;
		}
		if (objectControlClipName == string.Empty)
		{
			objectControlClipName = idleClipName;
		}
		if (objectUnleashClipName == string.Empty)
		{
			objectUnleashClipName = idleClipName;
		}
		if (redSpellCastingClipName == string.Empty)
		{
			redSpellCastingClipName = objectControlClipName;
		}
		if (redSpellUnleashClipName == string.Empty)
		{
			redSpellUnleashClipName = objectUnleashClipName;
		}
		if (blueSpellCastingClipName == string.Empty)
		{
			blueSpellCastingClipName = redSpellCastingClipName;
		}
		if (blueSpellUnleashClipName == string.Empty)
		{
			blueSpellUnleashClipName = redSpellUnleashClipName;
		}
		if (yellowSpellCastingClipName == string.Empty)
		{
			yellowSpellCastingClipName = redSpellCastingClipName;
		}
		if (yellowSpellUnleashClipName == string.Empty)
		{
			yellowSpellUnleashClipName = redSpellUnleashClipName;
		}
		if (greenSpellCastingClipName == string.Empty)
		{
			greenSpellCastingClipName = redSpellCastingClipName;
		}
		if (greenSpellUnleashClipName == string.Empty)
		{
			greenSpellUnleashClipName = redSpellUnleashClipName;
		}
		if (itemUseClipName == string.Empty)
		{
			itemUseClipName = objectUnleashClipName;
		}
		if (scrollCastingClipName == string.Empty)
		{
			scrollCastingClipName = objectControlClipName;
		}
		if (scrollUnleashClipName == string.Empty)
		{
			scrollUnleashClipName = objectUnleashClipName;
		}
		if (movingClipName == string.Empty)
		{
			movingClipName = idleClipName;
		}
		if (disableClipName == string.Empty)
		{
			disableClipName = idleClipName;
		}
		spritePosition = characterSprite.transform.localPosition;
	}

	private void Start()
	{
		animationNumber = -2;
	}

	private void OnSpawned()
	{
		animationNumber = -2;
	}

	private void OnDespawned()
	{
		animationNumber = -2;
	}

	private void Update()
	{
		AnimationFunction();
		CharacterStateFunction();
	}

	private void AnimationFunction()
	{
		if (panicMark)
		{
			if (!panicMarkObject.GetComponent<Renderer>().enabled)
			{
				panicMarkObject.GetComponent<Renderer>().enabled = true;
			}
		}
		else if (panicMarkObject.GetComponent<Renderer>().enabled)
		{
			panicMarkObject.GetComponent<Renderer>().enabled = false;
		}
		if (animationNumber < -1 && panicMark)
		{
			panicMark = false;
		}
		if (TOGGLE_animationNumber != animationNumber)
		{
			switch (animationNumber)
			{
			case -3:
				characterSprite.Play(blank);
				break;
			case -2:
				characterSprite.Play(characterID + "_" + idleClipName);
				break;
			case 0:
				characterSprite.Play(characterID + "_" + idleClipName);
				break;
			case 1:
				characterSprite.Play(characterID + "_" + shockedClipName);
				break;
			case 2:
				characterSprite.Play(characterID + "_" + defeatClipName);
				break;
			case 3:
				characterSprite.Play(characterID + "_" + victoryClipName);
				break;
			case 4:
				characterSprite.Play(characterID + "_" + tauntClipName);
				break;
			case 5:
				characterSprite.Play(characterID + "_" + objectControlClipName);
				TOGGLE_positionLock = 1;
				break;
			case 6:
				characterSprite.Play(characterID + "_" + objectUnleashClipName);
				animationNumber = -1;
				TOGGLE_positionLock = 0;
				UnitEffectKnock(1, 1f, 0f);
				break;
			case 7:
				characterSprite.Play(characterID + "_" + redSpellCastingClipName);
				TOGGLE_positionLock = 1;
				break;
			case 8:
				characterSprite.Play(characterID + "_" + redSpellUnleashClipName);
				animationNumber = -1;
				TOGGLE_positionLock = 0;
				UnitEffectKnock(1, 1f, 0.5f);
				break;
			case 9:
				characterSprite.Play(characterID + "_" + blueSpellCastingClipName);
				TOGGLE_positionLock = 1;
				break;
			case 10:
				characterSprite.Play(characterID + "_" + blueSpellUnleashClipName);
				animationNumber = -1;
				TOGGLE_positionLock = 0;
				UnitEffectKnock(1, 1f, 0.5f);
				break;
			case 11:
				characterSprite.Play(characterID + "_" + yellowSpellCastingClipName);
				TOGGLE_positionLock = 1;
				break;
			case 12:
				characterSprite.Play(characterID + "_" + yellowSpellUnleashClipName);
				animationNumber = -1;
				TOGGLE_positionLock = 0;
				UnitEffectKnock(1, 1f, 0.5f);
				break;
			case 13:
				characterSprite.Play(characterID + "_" + greenSpellCastingClipName);
				TOGGLE_positionLock = 1;
				break;
			case 14:
				characterSprite.Play(characterID + "_" + greenSpellUnleashClipName);
				animationNumber = -1;
				TOGGLE_positionLock = 0;
				UnitEffectKnock(1, 1f, 0.5f);
				break;
			case 15:
				characterSprite.Play(characterID + "_" + itemUseClipName);
				animationNumber = -1;
				TOGGLE_positionLock = 0;
				UnitEffectKnock(1, 1f, 0f);
				break;
			case 16:
				characterSprite.Play(characterID + "_" + scrollCastingClipName);
				TOGGLE_positionLock = 1;
				break;
			case 17:
				characterSprite.Play(characterID + "_" + scrollUnleashClipName);
				animationNumber = -1;
				TOGGLE_positionLock = 0;
				UnitEffectKnock(1, 1f, 0.25f);
				break;
			case 18:
				characterSprite.Play(characterID + "_" + movingClipName);
				break;
			case 19:
				characterSprite.Play(characterID + "_" + disableClipName);
				break;
			}
			TOGGLE_animationNumber = animationNumber;
		}
	}

	private void CharacterStateFunction()
	{
		UnitEffectKnock();
		UnitEffectDisable();
		switch (characterState)
		{
		case 0:
			if (TOGGLE_characterState != characterState)
			{
				panicMark = false;
				TOGGLE_characterState = characterState;
			}
			Action();
			break;
		case 1:
		{
			if (TOGGLE_characterState != characterState)
			{
				TOGGLE_characterState = characterState;
			}
			if (TOGGLE_unitEffectKnock != 0 || TOGGLE_positionLock != 0 || !(characterSprite.transform.position != spritePosition))
			{
				break;
			}
			Vector3 position = characterSprite.transform.position;
			if (position.x < spritePosition.x)
			{
				animationNumber = 18;
				characterSprite.transform.Translate(characterSprite.transform.right * movementSpeed * Time.smoothDeltaTime, Space.World);
				break;
			}
			Vector3 position2 = characterSprite.transform.position;
			if (position2.x >= spritePosition.x)
			{
				if (animationNumber == 18 || animationNumber == 19)
				{
					animationNumber = 0;
				}
				characterSprite.transform.position = spritePosition;
			}
			break;
		}
		case 2:
			if (TOGGLE_characterState != characterState)
			{
				UnitEffectDisable(1, 2f);
				UnitEffectKnock(1, 1f, 0.25f);
				animationNumber = 19;
				TOGGLE_characterState = characterState;
			}
			break;
		}
	}

	public void UnitEffectKnock(int Toggle, float Duration, float Distance)
	{
		if (characterState != 0)
		{
			if (Toggle == 1)
			{
				if (TOGGLE_unitEffectKnock == 0)
				{
					TIMER_unitEffectKnock = Time.time + Duration;
					Vector3 position = characterSprite.transform.position;
					float x = position.x - Distance;
					Vector3 position2 = characterSprite.transform.position;
					VECTOR_unitEffectKnock = new Vector3(x, position2.y, 0f);
					DAMPING_unitEffectKnock = 5f;
				}
				else
				{
					float x2 = VECTOR_unitEffectKnock.x - Distance;
					Vector3 position3 = characterSprite.transform.position;
					VECTOR_unitEffectKnock = new Vector3(x2, position3.y, 0f);
					TIMER_unitEffectKnock += Duration / 2f;
					DAMPING_unitEffectKnock = 5f;
				}
				TOGGLE_unitEffectKnock = 1;
				Toggle = 0;
			}
		}
		else
		{
			Toggle = 0;
		}
	}

	private void UnitEffectKnock()
	{
		if (characterState != 0)
		{
			int tOGGLE_unitEffectKnock = TOGGLE_unitEffectKnock;
			if (tOGGLE_unitEffectKnock == 0 || tOGGLE_unitEffectKnock != 1)
			{
				return;
			}
			if (Time.time < TIMER_unitEffectKnock)
			{
				Vector3 position = characterSprite.transform.position;
				if (position.x > -5f)
				{
					Transform transform = characterSprite.transform;
					Vector3 position2 = characterSprite.transform.position;
					float x = VECTOR_unitEffectKnock.x;
					Vector3 position3 = characterSprite.transform.position;
					float y = position3.y;
					Vector3 position4 = characterSprite.transform.position;
					transform.position = Vector3.Lerp(position2, new Vector3(x, y, position4.z), Time.deltaTime * DAMPING_unitEffectKnock);
				}
				else
				{
					Transform transform2 = characterSprite.transform;
					Vector3 position5 = characterSprite.transform.position;
					Vector3 position6 = characterSprite.transform.position;
					float y2 = position6.y;
					Vector3 position7 = characterSprite.transform.position;
					transform2.position = Vector3.Lerp(position5, new Vector3(-5f, y2, position7.z), Time.deltaTime * DAMPING_unitEffectKnock);
				}
			}
			else if (Time.time >= TIMER_unitEffectKnock)
			{
				TOGGLE_unitEffectKnock = 0;
			}
		}
		else if (TOGGLE_unitEffectKnock != 0)
		{
			TIMER_unitEffectKnock = 0f;
			DAMPING_unitEffectKnock = 0f;
			TOGGLE_unitEffectKnock = 0;
		}
	}

	public void UnitEffectDisable(int Toggle, float Duration)
	{
		if (characterState == 0)
		{
			return;
		}
		switch (Toggle)
		{
		case 1:
			TIMER_unitEffectDisable = Time.time + Duration;
			if (INST_effectStateDisable == null)
			{
				INST_effectStateDisable = PoolManager.Pools["HUD Pool"].Spawn(effectPropertyDisplay.transform, effectPosition.transform.position, effectPropertyDisplay.transform.rotation);
				INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 2, 0, 0, Toggle, 1.5f);
			}
			TOGGLE_unitEffectDisable = Toggle;
			characterState = 2;
			Toggle = 0;
			break;
		case 2:
			TIMER_unitEffectDisable = Time.time + Duration;
			TOGGLE_unitEffectDisable = Toggle;
			characterState = 2;
			Toggle = 0;
			break;
		}
	}

	private void UnitEffectDisable()
	{
		if (characterState != 0)
		{
			switch (TOGGLE_unitEffectDisable)
			{
			case 0:
				if (INST_effectStateDisable != null)
				{
					INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
					INST_effectStateDisable = null;
				}
				if (TIMER_unitEffectDisable != 0f)
				{
					TIMER_unitEffectDisable = 0f;
				}
				break;
			case 1:
				if (!(Time.time < TIMER_unitEffectDisable) && Time.time >= TIMER_unitEffectDisable)
				{
					TOGGLE_positionLock = 0;
					characterState = 1;
					TOGGLE_unitEffectDisable = 0;
				}
				break;
			case 2:
				if (!(Time.time < TIMER_unitEffectDisable) && Time.time >= TIMER_unitEffectDisable)
				{
					TOGGLE_positionLock = 0;
					characterState = 1;
					TOGGLE_unitEffectDisable = 0;
				}
				break;
			}
		}
		else if (characterState != 2)
		{
			if (INST_effectStateDisable != null)
			{
				INST_effectStateDisable.GetComponent<Effect_Property_Display>().HitEffectState(effectPosition, 0, 0, 0, 0, 0f);
				INST_effectStateDisable = null;
			}
			if (TIMER_unitEffectDisable != 0f)
			{
				TIMER_unitEffectDisable = 0f;
			}
			if (TOGGLE_unitEffectDisable != 0)
			{
				TIMER_unitEffectDisable = 0f;
				TOGGLE_unitEffectDisable = 0;
			}
		}
	}

	private void Action()
	{
		if (TOGGLE_characterAction != characterAction)
		{
			ACTION_2TIMER = 0f;
			ACTION_position = 0f;
			ACTION_direction = 0f;
			ACTION_3TIMER = 0f;
			characterSprite.transform.localPosition = spritePosition;
			characterSprite.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			TOGGLE_characterAction = characterAction;
		}
		switch (TOGGLE_characterAction)
		{
		case 0:
			if (characterSprite.transform.localPosition != spritePosition)
			{
				characterSprite.transform.localPosition = spritePosition;
			}
			if (characterSprite.transform.localRotation != Quaternion.Euler(0f, 0f, 0f))
			{
				characterSprite.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}
			break;
		case 1:
			if (ACTION_direction == 0f)
			{
				Vector3 localPosition9 = characterSprite.transform.localPosition;
				if (localPosition9.x < spritePosition.x + ACTION_1ShakeThreshold)
				{
					ACTION_position += ACTION_1ShakeSpeed;
				}
				else
				{
					Vector3 localPosition10 = characterSprite.transform.localPosition;
					if (localPosition10.x >= spritePosition.x + ACTION_1ShakeThreshold)
					{
						ACTION_position = ACTION_1ShakeThreshold;
						ACTION_direction = 1f;
					}
				}
			}
			else if (ACTION_direction == 1f)
			{
				Vector3 localPosition11 = characterSprite.transform.localPosition;
				if (localPosition11.x > spritePosition.x + (0f - ACTION_1ShakeThreshold))
				{
					ACTION_position -= ACTION_1ShakeSpeed;
				}
				else
				{
					Vector3 localPosition12 = characterSprite.transform.localPosition;
					if (localPosition12.x <= spritePosition.x + (0f - ACTION_1ShakeThreshold))
					{
						ACTION_position = 0f - ACTION_1ShakeThreshold;
						ACTION_direction = 0f;
					}
				}
			}
			characterSprite.transform.localPosition = new Vector3(spritePosition.x + ACTION_position, spritePosition.y, spritePosition.z);
			break;
		case 2:
			if (ACTION_direction == 0f)
			{
				if (ACTION_2TIMER == 0f)
				{
					ACTION_2TIMER = Time.time + ACTION_2WorryDuration;
					break;
				}
				characterSprite.transform.localPosition = new Vector3(spritePosition.x + characterActionWorryAdjustmentX, spritePosition.y, spritePosition.z);
				characterSprite.transform.localRotation = Quaternion.Euler(0f, -180f, 0f);
				if (Time.time >= ACTION_2TIMER)
				{
					ACTION_2TIMER = 0f;
					ACTION_direction = 1f;
				}
			}
			else
			{
				if (ACTION_direction != 1f)
				{
					break;
				}
				if (ACTION_2TIMER == 0f)
				{
					ACTION_2TIMER = Time.time + ACTION_2WorryDuration;
					break;
				}
				characterSprite.transform.localPosition = new Vector3(spritePosition.x, spritePosition.y, spritePosition.z);
				characterSprite.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				if (Time.time >= ACTION_2TIMER)
				{
					ACTION_2TIMER = 0f;
					ACTION_direction = 0f;
				}
			}
			break;
		case 3:
			if (ACTION_direction == 0f)
			{
				if (ACTION_3TIMER == 0f)
				{
					ACTION_3TIMER = Time.time + ACTION_3Duration;
					break;
				}
				characterSprite.transform.localPosition = spritePosition;
				if (Time.time >= ACTION_3TIMER)
				{
					ACTION_direction = 1f;
				}
			}
			else if (ACTION_direction == 1f)
			{
				Vector3 localPosition5 = characterSprite.transform.localPosition;
				if (localPosition5.y < spritePosition.y + ACTION_3JumpThreshold)
				{
					characterSprite.transform.Translate(base.transform.up * 1f * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition6 = characterSprite.transform.localPosition;
				if (localPosition6.y >= spritePosition.y + ACTION_3JumpThreshold)
				{
					characterSprite.transform.localPosition = new Vector3(spritePosition.x, spritePosition.y + ACTION_3JumpThreshold, spritePosition.z);
					ACTION_direction = 2f;
				}
			}
			else
			{
				if (ACTION_direction != 2f)
				{
					break;
				}
				Vector3 localPosition7 = characterSprite.transform.localPosition;
				if (localPosition7.y > spritePosition.y)
				{
					characterSprite.transform.Translate(base.transform.up * -1f * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition8 = characterSprite.transform.localPosition;
				if (localPosition8.z <= spritePosition.y)
				{
					characterSprite.transform.localPosition = spritePosition;
					ACTION_3TIMER = 0f;
					ACTION_direction = 0f;
				}
			}
			break;
		case 4:
			if (ACTION_direction == 0f)
			{
				Vector3 localPosition = characterSprite.transform.localPosition;
				if (localPosition.y < spritePosition.y + ACTION_4JumpThreshold)
				{
					characterSprite.transform.Translate(base.transform.up * 1f * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition2 = characterSprite.transform.localPosition;
				if (localPosition2.y >= spritePosition.y + ACTION_4JumpThreshold)
				{
					characterSprite.transform.localPosition = new Vector3(spritePosition.x, spritePosition.y + ACTION_4JumpThreshold, spritePosition.z);
					ACTION_direction = 1f;
				}
			}
			else
			{
				if (ACTION_direction != 1f)
				{
					break;
				}
				Vector3 localPosition3 = characterSprite.transform.localPosition;
				if (localPosition3.y > spritePosition.y)
				{
					characterSprite.transform.Translate(base.transform.up * -1f * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition4 = characterSprite.transform.localPosition;
				if (localPosition4.z <= spritePosition.y)
				{
					characterSprite.transform.localPosition = spritePosition;
					ACTION_direction = 2f;
				}
			}
			break;
		}
	}
}
