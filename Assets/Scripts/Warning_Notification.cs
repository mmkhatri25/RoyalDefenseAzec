using UnityEngine;

public class Warning_Notification : MonoBehaviour
{
	public AudioClip warningSound;

	public bool Warning;

	public GameObject Warning1;

	private tk2dSprite Warning1Sprite;

	public GameObject Warning2;

	private tk2dSprite Warning2Sprite;

	public GameObject Warning3;

	private tk2dSprite Warning3Sprite;

	private bool refade;

	private bool fadeIn = true;

	private bool fadeOut;

	private float fadeTimer;

	private float fadeAmount = 0.8f;

	private float fadeDelay = 1f;

	private float WarningAlpha = 1f;

	private bool removeWarning;

	private float lerpDamping = 0.1f;

	private Vector3 top;

	private Vector3 bottom;

	private Transform myTransform;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		Warning1Sprite = Warning1.GetComponent<tk2dSprite>();
		Warning2Sprite = Warning2.GetComponent<tk2dSprite>();
		Warning3Sprite = Warning3.GetComponent<tk2dSprite>();
		Vector3 position = myTransform.position;
		float x = position.x;
		Vector3 position2 = myTransform.position;
		float y = position2.y + 2.5f;
		Vector3 position3 = myTransform.position;
		top = new Vector3(x, y, position3.z);
		Vector3 position4 = myTransform.position;
		float x2 = position4.x;
		Vector3 position5 = myTransform.position;
		float y2 = position5.y - 1.5f;
		Vector3 position6 = myTransform.position;
		bottom = new Vector3(x2, y2, position6.z);
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			tk2dSprite warning1Sprite = Warning1Sprite;
			Color color = Warning1Sprite.color;
			float r = color.r;
			Color color2 = Warning1Sprite.color;
			float g = color2.g;
			Color color3 = Warning1Sprite.color;
			warning1Sprite.color = new Color(r, g, color3.b, 0f);
			tk2dSprite warning2Sprite = Warning2Sprite;
			Color color4 = Warning2Sprite.color;
			float r2 = color4.r;
			Color color5 = Warning2Sprite.color;
			float g2 = color5.g;
			Color color6 = Warning2Sprite.color;
			warning2Sprite.color = new Color(r2, g2, color6.b, 0f);
			tk2dSprite warning3Sprite = Warning3Sprite;
			Color color7 = Warning3Sprite.color;
			float r3 = color7.r;
			Color color8 = Warning3Sprite.color;
			float g3 = color8.g;
			Color color9 = Warning3Sprite.color;
			warning3Sprite.color = new Color(r3, g3, color9.b, 0f);
			return;
		}
		if (Warning)
		{
			if (!Warning1.active && !Warning2.active && !Warning3.active)
			{
				Warning1.active = true;
				Warning2.active = true;
				Warning3.active = true;
			}
			if (refade)
			{
				fadeTimer = 0f;
				if (fadeIn)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(warningSound);
					fadeIn = false;
					fadeOut = true;
				}
				else if (fadeOut)
				{
					fadeOut = false;
					fadeIn = true;
				}
				refade = false;
			}
			if (fadeIn)
			{
				if (fadeTimer < fadeAmount)
				{
					fadeTimer += 0.02f;
					WarningAlpha = fadeTimer;
				}
				else if (fadeTimer >= fadeAmount && fadeTimer < fadeDelay)
				{
					fadeTimer += 0.02f;
					WarningAlpha = fadeAmount;
				}
				else if (fadeTimer >= fadeDelay)
				{
					refade = true;
				}
			}
			else if (fadeOut)
			{
				if (fadeTimer < fadeAmount)
				{
					fadeTimer += 0.02f;
					WarningAlpha = fadeAmount - fadeTimer;
				}
				else if (fadeTimer >= fadeAmount && fadeTimer < fadeDelay)
				{
					fadeTimer += 0.02f;
					WarningAlpha = 0f;
				}
				else if (fadeTimer >= fadeDelay)
				{
					refade = true;
				}
			}
			if (removeWarning)
			{
				myTransform.position = bottom;
				removeWarning = false;
			}
			Vector3 position = myTransform.position;
			if (position.y != top.y)
			{
				myTransform.Translate(myTransform.up * lerpDamping * Time.deltaTime, Space.World);
			}
			Vector3 position2 = myTransform.position;
			if (position2.y >= top.y && WarningAlpha == 0f)
			{
				removeWarning = true;
			}
		}
		else if (WarningAlpha > 0f)
		{
			WarningAlpha -= 0.02f;
		}
		else if (WarningAlpha <= 0f)
		{
			if (Warning1.active && Warning2.active && Warning3.active)
			{
				fadeIn = true;
				fadeOut = false;
				fadeTimer = 0f;
				Warning1.active = false;
				Warning2.active = false;
				Warning3.active = false;
			}
			WarningAlpha = 0f;
		}
		Color color10 = Warning1Sprite.color;
		if (color10.a != WarningAlpha)
		{
			tk2dSprite warning1Sprite2 = Warning1Sprite;
			Color color11 = Warning1Sprite.color;
			float r4 = color11.r;
			Color color12 = Warning1Sprite.color;
			float g4 = color12.g;
			Color color13 = Warning1Sprite.color;
			warning1Sprite2.color = new Color(r4, g4, color13.b, WarningAlpha);
		}
		Color color14 = Warning2Sprite.color;
		if (color14.a != WarningAlpha)
		{
			tk2dSprite warning2Sprite2 = Warning2Sprite;
			Color color15 = Warning2Sprite.color;
			float r5 = color15.r;
			Color color16 = Warning2Sprite.color;
			float g5 = color16.g;
			Color color17 = Warning2Sprite.color;
			warning2Sprite2.color = new Color(r5, g5, color17.b, WarningAlpha);
		}
		Color color18 = Warning3Sprite.color;
		if (color18.a != WarningAlpha)
		{
			tk2dSprite warning3Sprite2 = Warning3Sprite;
			Color color19 = Warning3Sprite.color;
			float r6 = color19.r;
			Color color20 = Warning3Sprite.color;
			float g6 = color20.g;
			Color color21 = Warning3Sprite.color;
			warning3Sprite2.color = new Color(r6, g6, color21.b, WarningAlpha);
		}
	}
}
