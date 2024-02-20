using UnityEngine;

public class CharacterAnimationSet : MonoBehaviour
{
	public float SetAxisZ;

	public int AnimationNumber;

	public int OffenseNumber;

	private int TOGGLE_OffenseNumber;

	private int TOGGLE_AnimationNumber = -1;

	public Color originalColor = Color.white;

	public Color spriteColor = Color.white;

	private Color TOGGLE_spriteColor;

	private float zAxis;

	public CharacterAnimationSubSet[] characterSprite = new CharacterAnimationSubSet[6];

	private tk2dAnimatedSprite[] TK2DSprite = new tk2dAnimatedSprite[6];

	public int hexNumber;

	private int TOGGLE_hexNumber;

	public CharacterAnimationHexSet characterHexSprite;

	private tk2dAnimatedSprite TK2DHexSprite;

	public Renderer[] additionalSprites = new Renderer[6];

	private Transform myTransform;

	private int popEffectState;

	private float popEffectExpandScale = 1.4f;

	private float popEffectExpandSpeed = 0.1f;

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void Start()
	{
		spriteColor = Color.white;
		for (int i = 0; i < characterSprite.Length; i++)
		{
			if (characterSprite[i] != null)
			{
				TK2DSprite[i] = characterSprite[i].GetComponent<tk2dAnimatedSprite>();
				Transform transform = characterSprite[i].transform;
				Vector3 localPosition = characterSprite[i].transform.localPosition;
				float x = localPosition.x;
				Vector3 localPosition2 = characterSprite[i].transform.localPosition;
				transform.localPosition = new Vector3(x, localPosition2.y, (float)i * -0.001f + 0.005f);
			}
		}
		if (characterHexSprite != null)
		{
			TK2DHexSprite = characterHexSprite.GetComponent<tk2dAnimatedSprite>();
		}
		OnSpawned();
	}

	private void OnSpawned()
	{
		popEffectState = 0;
		if (SetAxisZ == 0f)
		{
			zAxis = (float)UnityEngine.Random.Range(0, 100) * 0.01f;
			zAxis = Mathf.Round(zAxis * 100f) / 100f;
			Transform transform = myTransform;
			Vector3 position = myTransform.position;
			float x = position.x;
			Vector3 position2 = myTransform.position;
			transform.position = new Vector3(x, position2.y, zAxis);
		}
		else
		{
			Transform transform2 = myTransform;
			Vector3 position3 = myTransform.position;
			float x2 = position3.x;
			Vector3 position4 = myTransform.position;
			transform2.position = new Vector3(x2, position4.y, SetAxisZ);
		}
		if (TK2DHexSprite == null && characterHexSprite != null)
		{
			TK2DHexSprite = characterHexSprite.GetComponent<tk2dAnimatedSprite>();
		}
	}

	private void Update()
	{
		if (TOGGLE_OffenseNumber != OffenseNumber)
		{
			for (int i = 0; i < characterSprite.Length; i++)
			{
				if (characterSprite[i] != null)
				{
					characterSprite[i].OffenseNumber = OffenseNumber;
				}
			}
			TOGGLE_OffenseNumber = OffenseNumber;
		}
		if (characterHexSprite == null)
		{
			CharacterSpriteFunction();
		}
		else if (hexNumber == 0)
		{
			if (TOGGLE_hexNumber != hexNumber)
			{
				for (int j = 0; j < characterSprite.Length; j++)
				{
					if (characterSprite[j] != null)
					{
						characterSprite[j].state = 0;
					}
				}
				for (int k = 0; k < additionalSprites.Length; k++)
				{
					if (additionalSprites[k] != null)
					{
						additionalSprites[k].enabled = true;
					}
				}
				TOGGLE_AnimationNumber = -100;
				TK2DHexSprite.color = originalColor;
				popEffectState = 1;
				TOGGLE_hexNumber = hexNumber;
			}
			if (characterHexSprite.hexNumber != 0)
			{
				characterHexSprite.hexNumber = 0;
			}
			CharacterSpriteFunction();
		}
		else if (hexNumber > 0)
		{
			if (TOGGLE_hexNumber != hexNumber)
			{
				for (int l = 0; l < characterSprite.Length; l++)
				{
					if (characterSprite[l] != null)
					{
						TK2DSprite[l].color = originalColor;
						characterSprite[l].AnimationNumber = -100;
						characterSprite[l].state = 1;
					}
				}
				for (int m = 0; m < additionalSprites.Length; m++)
				{
					if (additionalSprites[m] != null)
					{
						additionalSprites[m].enabled = false;
					}
				}
				popEffectState = 1;
				TOGGLE_AnimationNumber = -100;
				characterHexSprite.hexNumber = hexNumber;
				TOGGLE_hexNumber = hexNumber;
			}
			CharacterHexSpriteFunction();
		}
		PopEffect();
	}

	private void CharacterSpriteFunction()
	{
		if (spriteColor != Color.white)
		{
			if (TOGGLE_spriteColor != spriteColor)
			{
				for (int i = 0; i < characterSprite.Length; i++)
				{
					if (characterSprite[i] != null)
					{
						TK2DSprite[i].color = spriteColor;
					}
				}
				TOGGLE_spriteColor = spriteColor;
			}
		}
		else if (spriteColor == Color.white && TOGGLE_spriteColor != originalColor)
		{
			for (int j = 0; j < characterSprite.Length; j++)
			{
				if (characterSprite[j] != null)
				{
					TK2DSprite[j].color = originalColor;
				}
			}
			TOGGLE_spriteColor = originalColor;
		}
		if (TOGGLE_AnimationNumber == AnimationNumber)
		{
			return;
		}
		for (int k = 0; k < characterSprite.Length; k++)
		{
			if (characterSprite[k] != null)
			{
				characterSprite[k].AnimationNumber = AnimationNumber;
			}
		}
		TOGGLE_AnimationNumber = AnimationNumber;
		ToggleFunction();
	}

	private void CharacterHexSpriteFunction()
	{
		if (spriteColor != Color.white)
		{
			if (TOGGLE_spriteColor != spriteColor)
			{
				TK2DHexSprite.color = spriteColor;
				TOGGLE_spriteColor = spriteColor;
			}
		}
		else if (spriteColor == Color.white && TOGGLE_spriteColor != Color.white)
		{
			TK2DHexSprite.color = Color.white;
			TOGGLE_spriteColor = Color.white;
		}
		if (TOGGLE_AnimationNumber != AnimationNumber)
		{
			characterHexSprite.AnimationNumber = AnimationNumber;
			TOGGLE_AnimationNumber = AnimationNumber;
			ToggleFunction();
		}
	}

	private void PopEffect()
	{
		switch (popEffectState)
		{
		case 1:
			myTransform.localScale = new Vector3(1f, 1f, 1f);
			popEffectState = 2;
			break;
		case 2:
		{
			Vector3 localScale3 = myTransform.localScale;
			if (localScale3.x < 1f * popEffectExpandScale)
			{
				myTransform.localScale += new Vector3(popEffectExpandSpeed * Time.timeScale, popEffectExpandSpeed * Time.timeScale, popEffectExpandSpeed * Time.timeScale);
				break;
			}
			Vector3 localScale4 = myTransform.localScale;
			if (localScale4.x >= 1f * popEffectExpandScale)
			{
				popEffectState = 3;
			}
			break;
		}
		case 3:
		{
			Vector3 localScale = myTransform.localScale;
			if (localScale.x > 1f)
			{
				myTransform.localScale += new Vector3((0f - popEffectExpandSpeed) * Time.timeScale, (0f - popEffectExpandSpeed) * Time.timeScale, (0f - popEffectExpandSpeed) * Time.timeScale);
				break;
			}
			Vector3 localScale2 = myTransform.localScale;
			if (localScale2.x <= 1f)
			{
				myTransform.localScale = new Vector3(1f, 1f, 1f);
				popEffectState = 0;
			}
			break;
		}
		}
	}

	private void ToggleFunction()
	{
		switch (AnimationNumber)
		{
		case 8:
			break;
		case 7:
			AnimationNumber = -100;
			break;
		case 9:
			AnimationNumber = -100;
			break;
		}
	}
}
