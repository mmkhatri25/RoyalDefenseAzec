using UnityEngine;

public class TK2dSpriteFade : MonoBehaviour
{
	public Color originalColor;

	public tk2dAnimatedSprite animatedSprite;

	public tk2dSprite basicSprite;

	public float fadeSpeed;

	public float fadeTime;

	private float amountFade;

	private void Start()
	{
		if (animatedSprite != null)
		{
			animatedSprite.color = originalColor;
		}
		else if (basicSprite != null)
		{
			basicSprite.color = originalColor;
		}
		amountFade = fadeTime;
	}

	private void OnSpawned()
	{
		if (animatedSprite != null)
		{
			animatedSprite.color = originalColor;
		}
		else if (basicSprite != null)
		{
			basicSprite.color = originalColor;
		}
		amountFade = fadeTime;
	}

	private void Update()
	{
		if (amountFade > 1f)
		{
			amountFade -= fadeSpeed;
		}
		else if (amountFade <= 1f)
		{
			amountFade -= fadeSpeed;
			if (animatedSprite != null)
			{
				animatedSprite.color = new Color(originalColor.r, originalColor.g, originalColor.b, amountFade);
			}
			else if (basicSprite != null)
			{
				basicSprite.color = new Color(originalColor.r, originalColor.g, originalColor.b, amountFade);
			}
		}
	}
}
