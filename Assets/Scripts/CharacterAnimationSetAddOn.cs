using UnityEngine;

public class CharacterAnimationSetAddOn : MonoBehaviour
{
	public CharacterAnimationSet scriptCharacterAnimationSet;

	public int animationNumber;

	private int TOGGLE_animationNumber;

	public int animationPlayType;

	public string clipName;

	public string elseClipName;

	private tk2dAnimatedSprite characterSprite;

	private MeshRenderer spriteRenderer;

	private void Awake()
	{
		base.useGUILayout = false;
		characterSprite = GetComponent<tk2dAnimatedSprite>();
		spriteRenderer = GetComponent<MeshRenderer>();
	}

	private void Start()
	{
		spriteRenderer.enabled = false;
	}

	private void OnSpawned()
	{
		TOGGLE_animationNumber = -999;
		spriteRenderer.enabled = false;
	}

	private void Update()
	{
		switch (animationPlayType)
		{
		case 0:
			if (scriptCharacterAnimationSet.AnimationNumber == animationNumber)
			{
				if (TOGGLE_animationNumber != animationNumber)
				{
					spriteRenderer.enabled = true;
					characterSprite.Play(clipName);
					TOGGLE_animationNumber = animationNumber;
				}
			}
			else if (TOGGLE_animationNumber != -100)
			{
				spriteRenderer.enabled = false;
				characterSprite.Play(elseClipName);
				TOGGLE_animationNumber = -100;
			}
			break;
		case 1:
			if (scriptCharacterAnimationSet.AnimationNumber == animationNumber)
			{
				if (TOGGLE_animationNumber != animationNumber)
				{
					spriteRenderer.enabled = false;
					characterSprite.Play(elseClipName);
					TOGGLE_animationNumber = animationNumber;
				}
			}
			else if (TOGGLE_animationNumber != -100)
			{
				spriteRenderer.enabled = true;
				characterSprite.Play(clipName);
				TOGGLE_animationNumber = -100;
			}
			break;
		}
	}
}
