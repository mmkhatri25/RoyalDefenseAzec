using UnityEngine;

public class Effect_Damaged : MonoBehaviour
{
	public bool test;

	public int activate;

	private int TOGGLE_activate;

	public GameObject targetObject;

	public tk2dAnimatedSprite image;

	public int effectClassID;

	public int effectSubID;

	private float imageRotationSpeed;

	private int randomRotation = 1;

	private int randomPosition = 1;

	private float imageStartSize;

	private float imageMaxSize;

	private float imageEndSize;

	private float durationMaxSize;

	private float scalingUpSpeed = 0.1f;

	private float scalingDownSpeed = 0.1f;

	private float fadeDownAmount = 1f;

	private float fadeDownSpeed = 0.1f;

	private float SIZE_imagesSize;

	private int TOGGLE_imageScaling;

	private float TIMER_durationMaxSize;

	private float ALPHA_fading;

	private Transform myTransform;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		EffectSetup();
		ResetEffect();
	}

	public void HitEffectProperies(int toggle, GameObject target, int effectClassIDx, int effectNumber)
	{
		if (toggle == 1)
		{
			targetObject = target;
			effectClassID = effectClassIDx;
			effectSubID = effectNumber;
			EffectSetup();
			ResetEffect();
			activate = 1;
		}
	}

	private void OnDespawned()
	{
		ResetEffect();
		image.Play("blank");
		TOGGLE_activate = 0;
		activate = 2;
	}

	private void OnSpawned()
	{
		EffectSetup();
	}

	private void EffectSetup()
	{
		switch (effectClassID)
		{
		case -1:
			de_heal();
			break;
		case 0:
			de_basic();
			break;
		case 1:
			de_impact();
			break;
		case 2:
			de_wound();
			break;
		case 3:
			de_fire();
			break;
		case 4:
			de_ice();
			break;
		case 5:
			de_electric();
			break;
		case 6:
			de_air();
			break;
		case 7:
			de_earth();
			break;
		case 8:
			de_curse();
			break;
		case 9:
			de_holy();
			break;
		case 10:
			de_silver();
			break;
		}
	}

	private void de_heal()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(0f, 1f, 0f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 0;
			randomPosition = 1;
			imageStartSize = 0.4f;
			imageMaxSize = 1.2f;
			imageEndSize = -1f;
			durationMaxSize = 0.1f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0f;
			fadeDownAmount = 0f;
			fadeDownSpeed = 0.01f;
		}
	}

	private void de_basic()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(1f, 1f, 1f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 1;
			randomPosition = 1;
			imageStartSize = 1.25f;
			imageMaxSize = 2.5f;
			imageEndSize = 0f;
			durationMaxSize = 0.1f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0.25f;
			fadeDownAmount = -1f;
			fadeDownSpeed = 0f;
		}
	}

	private void de_impact()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(1f, 1f, 0f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 1;
			randomPosition = 1;
			imageStartSize = 1.5f;
			imageMaxSize = 3f;
			imageEndSize = 0f;
			durationMaxSize = 0.1f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0.25f;
			fadeDownAmount = -1f;
			fadeDownSpeed = 0f;
		}
	}

	private void de_wound()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(1f, 0f, 0f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 1;
			randomPosition = 1;
			imageStartSize = 1.1f;
			imageMaxSize = 2.25f;
			imageEndSize = -1f;
			durationMaxSize = 0.2f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0f;
			fadeDownAmount = 0f;
			fadeDownSpeed = 0.02f;
		}
	}

	private void de_fire()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(1f, 0.35f, 0f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 0;
			randomPosition = 1;
			imageStartSize = 0.6f;
			imageMaxSize = 1.2f;
			imageEndSize = 0f;
			durationMaxSize = 0.1f;
			scalingUpSpeed = 0.1f;
			scalingDownSpeed = 0.0075f;
			fadeDownAmount = -1f;
			fadeDownSpeed = 0f;
		}
	}

	private void de_ice()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(0f, 1f, 1f, 0.75f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 1;
			randomPosition = 1;
			imageStartSize = 0.6f;
			imageMaxSize = 1.2f;
			imageEndSize = 0f;
			durationMaxSize = 0.5f;
			scalingUpSpeed = 0.1f;
			scalingDownSpeed = 0.01f;
			fadeDownAmount = 0f;
			fadeDownSpeed = 0.0025f;
		}
	}

	private void de_electric()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(0.35f, 1f, 1f, 0.8f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 1f;
			randomRotation = 1;
			randomPosition = 1;
			imageStartSize = 0.75f;
			imageMaxSize = 1.5f;
			imageEndSize = 0f;
			durationMaxSize = 0.5f;
			scalingUpSpeed = 0.2f;
			scalingDownSpeed = 0.2f;
			fadeDownAmount = -1f;
			fadeDownSpeed = 0f;
		}
	}

	private void de_air()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(0.8f, 1f, 1f, 0.6f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 0;
			randomPosition = 0;
			imageStartSize = 0.5f;
			imageMaxSize = 2f;
			imageEndSize = -1f;
			durationMaxSize = 0.2f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0f;
			fadeDownAmount = 0f;
			fadeDownSpeed = 0.01f;
		}
	}

	private void de_earth()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(0f, 0.9f, 0f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 1;
			randomPosition = 1;
			imageStartSize = 0.6f;
			imageMaxSize = 1.2f;
			imageEndSize = 0f;
			durationMaxSize = 2f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0.1f;
			fadeDownAmount = -1f;
			fadeDownSpeed = 0f;
		}
	}

	private void de_curse()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(0.35f, 0f, 1f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 0;
			randomPosition = 1;
			imageStartSize = 0.5f;
			imageMaxSize = 1.5f;
			imageEndSize = -1f;
			durationMaxSize = 0.3f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0f;
			fadeDownAmount = 0f;
			fadeDownSpeed = 0.01f;
		}
	}

	private void de_holy()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(1f, 1f, 0.75f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0f;
			randomRotation = 0;
			randomPosition = 1;
			imageStartSize = 0.5f;
			imageMaxSize = 2f;
			imageEndSize = -1f;
			durationMaxSize = 0.3f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0f;
			fadeDownAmount = 0f;
			fadeDownSpeed = 0.01f;
		}
	}

	private void de_silver()
	{
		int num = effectSubID;
		if (num == 1)
		{
			image.color = new Color(1f, 1f, 1f, 1f);
			image.Play("de_" + effectClassID + "_" + effectSubID);
			imageRotationSpeed = 0.1f;
			randomRotation = 1;
			randomPosition = 1;
			imageStartSize = 0.5f;
			imageMaxSize = 1.5f;
			imageEndSize = -1f;
			durationMaxSize = 0.5f;
			scalingUpSpeed = 0.25f;
			scalingDownSpeed = 0f;
			fadeDownAmount = 0f;
			fadeDownSpeed = 0.01f;
		}
	}

	private void ResetEffect()
	{
		if (randomPosition == 1)
		{
			Transform transform = image.transform;
			float x = UnityEngine.Random.Range(-0.2f, 0.2f);
			float y = UnityEngine.Random.Range(-0.2f, 0.2f);
			Vector3 localPosition = image.transform.localPosition;
			transform.localPosition = new Vector3(x, y, localPosition.z);
		}
		else
		{
			Transform transform2 = image.transform;
			Vector3 localPosition2 = image.transform.localPosition;
			transform2.localPosition = new Vector3(0f, 0f, localPosition2.z);
		}
		Transform transform3 = image.transform;
		Vector3 position = image.transform.position;
		float x2 = position.x;
		Vector3 position2 = image.transform.position;
		transform3.position = new Vector3(x2, position2.y, -0.8f);
		if (randomRotation == 1)
		{
			image.transform.localRotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, 360));
		}
		else
		{
			image.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		}
		Color color = image.color;
		if (color.a == 0f)
		{
			tk2dAnimatedSprite tk2dAnimatedSprite = image;
			Color color2 = image.color;
			float r = color2.r;
			Color color3 = image.color;
			float g = color3.g;
			Color color4 = image.color;
			tk2dAnimatedSprite.color = new Color(r, g, color4.b, 1f);
		}
		Color color5 = image.color;
		ALPHA_fading = color5.a;
		SIZE_imagesSize = imageStartSize;
		TOGGLE_imageScaling = 0;
	}

	private void Update()
	{
		if (test && activate != 0)
		{
			ResetEffect();
			activate = 0;
		}
		if (TOGGLE_activate == 0)
		{
			EffectSetup();
			ResetEffect();
			TOGGLE_activate = 1;
		}
		if (activate == 0)
		{
			if (imageRotationSpeed != 0f)
			{
				image.transform.Rotate(0f, 0f, imageRotationSpeed);
			}
			if (targetObject != null && targetObject.active)
			{
				Transform transform = myTransform;
				Vector3 position = targetObject.transform.position;
				float x = position.x;
				Vector3 position2 = targetObject.transform.position;
				float y = position2.y;
				Vector3 position3 = myTransform.position;
				transform.position = new Vector3(x, y, position3.z);
			}
			if (TOGGLE_imageScaling == 0)
			{
				if (SIZE_imagesSize < imageMaxSize)
				{
					SIZE_imagesSize += scalingUpSpeed;
					image.scale = new Vector3(SIZE_imagesSize, SIZE_imagesSize, imageMaxSize);
				}
				else if (SIZE_imagesSize >= imageMaxSize)
				{
					TIMER_durationMaxSize = Time.time + durationMaxSize;
					SIZE_imagesSize = imageMaxSize;
					image.scale = new Vector3(imageMaxSize, imageMaxSize, imageMaxSize);
					TOGGLE_imageScaling = 1;
				}
			}
			else if (TOGGLE_imageScaling == 1)
			{
				if (!(Time.time >= TIMER_durationMaxSize))
				{
					return;
				}
				if (imageEndSize != -1f)
				{
					if (SIZE_imagesSize > imageEndSize)
					{
						SIZE_imagesSize -= scalingDownSpeed;
						image.scale = new Vector3(SIZE_imagesSize, SIZE_imagesSize, imageMaxSize);
					}
					else if (SIZE_imagesSize <= imageEndSize)
					{
						SIZE_imagesSize = imageEndSize;
						image.scale = new Vector3(0f, 0f, imageMaxSize);
						TOGGLE_imageScaling = 2;
					}
				}
				if (fadeDownAmount != -1f)
				{
					Color color = image.color;
					if (color.a > fadeDownAmount)
					{
						ALPHA_fading -= fadeDownSpeed;
						tk2dAnimatedSprite tk2dAnimatedSprite = image;
						Color color2 = image.color;
						float r = color2.r;
						Color color3 = image.color;
						float g = color3.g;
						Color color4 = image.color;
						tk2dAnimatedSprite.color = new Color(r, g, color4.b, ALPHA_fading);
					}
					else
					{
						Color color5 = image.color;
						if (color5.a <= fadeDownAmount)
						{
							ALPHA_fading = fadeDownSpeed;
							tk2dAnimatedSprite tk2dAnimatedSprite2 = image;
							Color color6 = image.color;
							float r2 = color6.r;
							Color color7 = image.color;
							float g2 = color7.g;
							Color color8 = image.color;
							tk2dAnimatedSprite2.color = new Color(r2, g2, color8.b, fadeDownSpeed);
							TOGGLE_imageScaling = 2;
						}
					}
				}
				if (fadeDownAmount == -1f && imageEndSize == -1f)
				{
					TOGGLE_imageScaling = 2;
				}
			}
			else if (TOGGLE_imageScaling == 2)
			{
				SIZE_imagesSize = 0f;
				image.scale = new Vector3(0f, 0f, 0f);
				activate = 1;
			}
		}
		else if (activate == 1)
		{
			PoolManager.Pools["Effect Pool"].Despawn(base.transform);
		}
	}
}
