using UnityEngine;

public class Object_Animation_SubSet : MonoBehaviour
{
	public Object_Animation_Set animationSet;

	public int animationNumber;

	private int TOGGLE_animationNumber;

	public int animationPlayType;

	public string clipName;

	private tk2dAnimatedSprite characterSprite;

	private MeshRenderer spriteRenderer;

	private void Awake()
	{
		characterSprite = GetComponent<tk2dAnimatedSprite>();
		spriteRenderer = GetComponent<MeshRenderer>();
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
			if (animationSet.AnimationNumber == animationNumber)
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
				TOGGLE_animationNumber = -100;
			}
			break;
		case 1:
			if (animationSet.AnimationNumber == animationNumber)
			{
				if (TOGGLE_animationNumber != animationNumber)
				{
					spriteRenderer.enabled = false;
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
