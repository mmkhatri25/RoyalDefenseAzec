using UnityEngine;

public class SceneCharacterLogic : MonoBehaviour
{
	private int sceneNumber;

	public tk2dAnimatedSprite sprite;

	public string playAnimationName;

	public string movingAnimationName;

	public int characterDirection;

	public float movementSpeed;

	public int moveForward;

	public int moveUp;

	private Vector3 newPosition;

	public int characterAction;

	public Scene_Logic sceneLogic;

	public Tutorial_Logic tutorialLogic;

	private int moveDirectionX;

	private int moveDirectionY;

	private Vector3 spritePosition;

	private string TOGGLE_playAnimationName;

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

	private void Start()
	{
		if (characterAction == -1 && sceneLogic == null)
		{
			sceneLogic = GameObject.Find("Scene Logic").GetComponent<Scene_Logic>();
		}
		if (characterAction == -2 && tutorialLogic == null)
		{
			tutorialLogic = GameObject.Find("Tutorial Logic").GetComponent<Tutorial_Logic>();
		}
		newPosition = base.transform.localPosition;
		spritePosition = sprite.transform.localPosition;
	}

	private void Update()
	{
		SpriteAnimation();
		Movement();
		Action();
	}

	private void SpriteAnimation()
	{
		if (base.transform.localPosition != newPosition)
		{
			if (TOGGLE_playAnimationName != movingAnimationName)
			{
				sprite.Play(string.Empty + movingAnimationName);
				TOGGLE_playAnimationName = movingAnimationName;
			}
		}
		else if (base.transform.localPosition == newPosition && TOGGLE_playAnimationName != playAnimationName)
		{
			sprite.Play(string.Empty + playAnimationName);
			TOGGLE_playAnimationName = playAnimationName;
		}
	}

	private void PositionReset()
	{
		if (sceneLogic != null)
		{
			if (sceneNumber != sceneLogic.sceneNumber)
			{
				base.transform.localPosition = newPosition;
				sceneNumber = sceneLogic.sceneNumber;
			}
		}
		else if (tutorialLogic != null && sceneNumber != tutorialLogic.sceneNumber)
		{
			base.transform.localPosition = newPosition;
			sceneNumber = tutorialLogic.sceneNumber;
		}
	}

	private void Movement()
	{
		switch (characterDirection)
		{
		case 0:
		{
			PositionReset();
			if (base.transform.localRotation != Quaternion.Euler(0f, -90f, 0f))
			{
				base.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
			}
			if (moveForward != 0 || moveUp != 0)
			{
				PositionReset();
				Vector3 localPosition20 = base.transform.localPosition;
				float x6 = localPosition20.x - 0.5f * (float)moveForward;
				Vector3 localPosition21 = base.transform.localPosition;
				float y6 = localPosition21.y + 0.5f * (float)moveUp;
				Vector3 localPosition22 = base.transform.localPosition;
				newPosition = new Vector3(x6, y6, localPosition22.z);
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
				break;
			}
			if (movementSpeed == 100f)
			{
				base.transform.localPosition = newPosition;
				break;
			}
			if (moveDirectionX == 1)
			{
				Vector3 localPosition23 = base.transform.localPosition;
				if (localPosition23.x > newPosition.x)
				{
					base.transform.Translate(base.transform.forward * movementSpeed * Time.smoothDeltaTime, Space.World);
				}
				else
				{
					Vector3 localPosition24 = base.transform.localPosition;
					if (localPosition24.x <= newPosition.x)
					{
						Transform transform5 = base.transform;
						float x7 = newPosition.x;
						Vector3 localPosition25 = base.transform.localPosition;
						float y7 = localPosition25.y;
						Vector3 localPosition26 = base.transform.localPosition;
						transform5.localPosition = new Vector3(x7, y7, localPosition26.z);
					}
				}
			}
			else
			{
				Vector3 localPosition27 = base.transform.localPosition;
				if (localPosition27.x < newPosition.x)
				{
					base.transform.Translate(base.transform.forward * (0f - movementSpeed) * Time.smoothDeltaTime, Space.World);
				}
				else
				{
					Vector3 localPosition28 = base.transform.localPosition;
					if (localPosition28.x >= newPosition.x)
					{
						Transform transform6 = base.transform;
						float x8 = newPosition.x;
						Vector3 localPosition29 = base.transform.localPosition;
						float y8 = localPosition29.y;
						Vector3 localPosition30 = base.transform.localPosition;
						transform6.localPosition = new Vector3(x8, y8, localPosition30.z);
					}
				}
			}
			if (moveDirectionY == 1)
			{
				Vector3 localPosition31 = base.transform.localPosition;
				if (localPosition31.y > newPosition.y)
				{
					base.transform.Translate(base.transform.up * (0f - movementSpeed) * Time.smoothDeltaTime, Space.World);
					break;
				}
				Vector3 localPosition32 = base.transform.localPosition;
				if (localPosition32.y <= newPosition.y)
				{
					Transform transform7 = base.transform;
					Vector3 localPosition33 = base.transform.localPosition;
					float x9 = localPosition33.x;
					float y9 = newPosition.y;
					Vector3 localPosition34 = base.transform.localPosition;
					transform7.localPosition = new Vector3(x9, y9, localPosition34.z);
				}
				break;
			}
			Vector3 localPosition35 = base.transform.localPosition;
			if (localPosition35.y < newPosition.y)
			{
				base.transform.Translate(base.transform.up * movementSpeed * Time.smoothDeltaTime, Space.World);
				break;
			}
			Vector3 localPosition36 = base.transform.localPosition;
			if (localPosition36.y >= newPosition.y)
			{
				Transform transform8 = base.transform;
				Vector3 localPosition37 = base.transform.localPosition;
				float x10 = localPosition37.x;
				float y10 = newPosition.y;
				Vector3 localPosition38 = base.transform.localPosition;
				transform8.localPosition = new Vector3(x10, y10, localPosition38.z);
			}
			break;
		}
		case 1:
		{
			PositionReset();
			if (base.transform.localRotation != Quaternion.Euler(0f, 90f, 0f))
			{
				base.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			}
			if (moveForward != 0 || moveUp != 0)
			{
				PositionReset();
				Vector3 localPosition = base.transform.localPosition;
				float x = localPosition.x + 0.5f * (float)moveForward;
				Vector3 localPosition2 = base.transform.localPosition;
				float y = localPosition2.y + 0.5f * (float)moveUp;
				Vector3 localPosition3 = base.transform.localPosition;
				newPosition = new Vector3(x, y, localPosition3.z);
				if (moveForward < 0)
				{
					moveDirectionX = 1;
				}
				else if (moveForward > 0)
				{
					moveDirectionX = 0;
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
				break;
			}
			if (movementSpeed == 100f)
			{
				base.transform.localPosition = newPosition;
				break;
			}
			if (moveDirectionX == 1)
			{
				Vector3 localPosition4 = base.transform.localPosition;
				if (localPosition4.x > newPosition.x)
				{
					base.transform.Translate(base.transform.forward * (0f - movementSpeed) * Time.smoothDeltaTime, Space.World);
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
					base.transform.Translate(base.transform.forward * movementSpeed * Time.smoothDeltaTime, Space.World);
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
					break;
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
				break;
			}
			Vector3 localPosition16 = base.transform.localPosition;
			if (localPosition16.y < newPosition.y)
			{
				base.transform.Translate(base.transform.up * movementSpeed * Time.smoothDeltaTime, Space.World);
				break;
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
			break;
		}
		}
	}

	private void Action()
	{
		if (base.transform.localPosition == newPosition)
		{
			if (TOGGLE_characterAction != characterAction)
			{
				ACTION_2TIMER = 0f;
				ACTION_position = 0f;
				ACTION_direction = 0f;
				ACTION_3TIMER = 0f;
				sprite.transform.localPosition = spritePosition;
				sprite.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
				TOGGLE_characterAction = characterAction;
			}
			switch (TOGGLE_characterAction)
			{
			case 0:
				if (sprite.transform.localPosition != spritePosition)
				{
					sprite.transform.localPosition = spritePosition;
				}
				if (sprite.transform.localRotation != Quaternion.Euler(0f, 90f, 0f))
				{
					sprite.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
				}
				break;
			case 1:
				if (ACTION_direction == 0f)
				{
					Vector3 localPosition9 = sprite.transform.localPosition;
					if (localPosition9.z < spritePosition.z + ACTION_1ShakeThreshold)
					{
						ACTION_position += ACTION_1ShakeSpeed;
					}
					else
					{
						Vector3 localPosition10 = sprite.transform.localPosition;
						if (localPosition10.z >= spritePosition.z + ACTION_1ShakeThreshold)
						{
							ACTION_position = ACTION_1ShakeThreshold;
							ACTION_direction = 1f;
						}
					}
				}
				else if (ACTION_direction == 1f)
				{
					Vector3 localPosition11 = sprite.transform.localPosition;
					if (localPosition11.z > spritePosition.z + (0f - ACTION_1ShakeThreshold))
					{
						ACTION_position -= ACTION_1ShakeSpeed;
					}
					else
					{
						Vector3 localPosition12 = sprite.transform.localPosition;
						if (localPosition12.z <= spritePosition.z + (0f - ACTION_1ShakeThreshold))
						{
							ACTION_position = 0f - ACTION_1ShakeThreshold;
							ACTION_direction = 0f;
						}
					}
				}
				sprite.transform.localPosition = new Vector3(spritePosition.x, spritePosition.y, spritePosition.z + ACTION_position);
				break;
			case 2:
				if (ACTION_direction == 0f)
				{
					if (ACTION_2TIMER == 0f)
					{
						ACTION_2TIMER = Time.time + ACTION_2WorryDuration;
						break;
					}
					sprite.transform.localPosition = new Vector3(spritePosition.x, spritePosition.y, 0f - spritePosition.z);
					sprite.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
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
					sprite.transform.localPosition = new Vector3(spritePosition.x, spritePosition.y, spritePosition.z);
					sprite.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
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
					sprite.transform.localPosition = spritePosition;
					if (Time.time >= ACTION_3TIMER)
					{
						ACTION_direction = 1f;
					}
				}
				else if (ACTION_direction == 1f)
				{
					Vector3 localPosition5 = sprite.transform.localPosition;
					if (localPosition5.y < spritePosition.y + ACTION_3JumpThreshold)
					{
						sprite.transform.Translate(base.transform.up * 1f * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 localPosition6 = sprite.transform.localPosition;
					if (localPosition6.y >= spritePosition.y + ACTION_3JumpThreshold)
					{
						sprite.transform.localPosition = new Vector3(spritePosition.x, spritePosition.y + ACTION_3JumpThreshold, spritePosition.z);
						ACTION_direction = 2f;
					}
				}
				else
				{
					if (ACTION_direction != 2f)
					{
						break;
					}
					Vector3 localPosition7 = sprite.transform.localPosition;
					if (localPosition7.y > spritePosition.y)
					{
						sprite.transform.Translate(base.transform.up * -1f * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 localPosition8 = sprite.transform.localPosition;
					if (localPosition8.z <= spritePosition.y)
					{
						sprite.transform.localPosition = spritePosition;
						ACTION_3TIMER = 0f;
						ACTION_direction = 0f;
					}
				}
				break;
			case 4:
				if (ACTION_direction == 0f)
				{
					Vector3 localPosition = sprite.transform.localPosition;
					if (localPosition.y < spritePosition.y + ACTION_4JumpThreshold)
					{
						sprite.transform.Translate(base.transform.up * 1f * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 localPosition2 = sprite.transform.localPosition;
					if (localPosition2.y >= spritePosition.y + ACTION_4JumpThreshold)
					{
						sprite.transform.localPosition = new Vector3(spritePosition.x, spritePosition.y + ACTION_4JumpThreshold, spritePosition.z);
						ACTION_direction = 1f;
					}
				}
				else
				{
					if (ACTION_direction != 1f)
					{
						break;
					}
					Vector3 localPosition3 = sprite.transform.localPosition;
					if (localPosition3.y > spritePosition.y)
					{
						sprite.transform.Translate(base.transform.up * -1f * Time.smoothDeltaTime, Space.World);
						break;
					}
					Vector3 localPosition4 = sprite.transform.localPosition;
					if (localPosition4.z <= spritePosition.y)
					{
						sprite.transform.localPosition = spritePosition;
						ACTION_direction = 2f;
					}
				}
				break;
			}
		}
		else
		{
			if (sprite.transform.localPosition != spritePosition)
			{
				sprite.transform.localPosition = spritePosition;
			}
			if (sprite.transform.localRotation != Quaternion.Euler(0f, 90f, 0f))
			{
				sprite.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			}
		}
	}
}
