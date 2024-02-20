using UnityEngine;

public class Object_Animation_Set : MonoBehaviour
{
	public int ObjectType;

	public int AnimationNumber;

	private int TOGGLE_AnimationNumber = -1;

	public Color originalColor = Color.white;

	public Color spriteColor = Color.white;

	private Color TOGGLE_spriteColor;

	private float zAxis;

	private tk2dAnimatedSprite TK2DSprite;

	private float spriteScale;

	private MeshRenderer render;

	public string OffClipName = string.Empty;

	public string OnClipName = string.Empty;

	public string SpecialOffClipName = string.Empty;

	public string SpecialOnClipName = string.Empty;

	public string MovingClipName = string.Empty;

	private void Awake()
	{
	}

	private void Start()
	{
		spriteColor = Color.white;
		TK2DSprite = GetComponent<tk2dAnimatedSprite>();
		render = GetComponent<MeshRenderer>();
		Vector3 scale = TK2DSprite.scale;
		spriteScale = scale.x;
	}

	private void OnSpawned()
	{
	}

	private void LateUpdate()
	{
		if (spriteColor != Color.white)
		{
			if (TOGGLE_spriteColor != spriteColor)
			{
				TK2DSprite.color = spriteColor;
				TOGGLE_spriteColor = spriteColor;
			}
		}
		else if (spriteColor == Color.white && TOGGLE_spriteColor != originalColor)
		{
			TK2DSprite.color = originalColor;
			TOGGLE_spriteColor = originalColor;
		}
	}

	private void FixedUpdate()
	{
		if (TOGGLE_AnimationNumber == AnimationNumber)
		{
			return;
		}
		switch (AnimationNumber)
		{
		case -3:
			if (MovingClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			if (ObjectType == 1)
			{
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
			}
			render.enabled = true;
			TK2DSprite.Play(MovingClipName);
			break;
		case -2:
			if (ObjectType == 1)
			{
				TK2DSprite.scale = new Vector3(spriteScale, spriteScale, spriteScale);
			}
			if (SpecialOnClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(SpecialOnClipName);
			break;
		case 0:
			if (ObjectType == 1)
			{
			}
			if (OffClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(OffClipName);
			break;
		case 1:
			if (ObjectType == 1)
			{
				TK2DSprite.scale = new Vector3(spriteScale, spriteScale, spriteScale);
			}
			if (OnClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(OnClipName);
			break;
		case 2:
			if (ObjectType == 1)
			{
				TK2DSprite.scale = new Vector3(spriteScale, spriteScale, spriteScale);
			}
			if (SpecialOffClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(SpecialOffClipName);
			break;
		case 3:
			if (ObjectType == 1)
			{
				TK2DSprite.scale = new Vector3(spriteScale, spriteScale, spriteScale);
			}
			if (MovingClipName == string.Empty)
			{
				render.enabled = false;
			}
			else
			{
				render.enabled = true;
				TK2DSprite.Play(MovingClipName);
			}
			TK2DSprite.Play(MovingClipName);
			break;
		}
		TOGGLE_AnimationNumber = AnimationNumber;
	}
}
