using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
	public int defeatEffect;

	private int TOGGLE_defeatEffect;

	private float SPEED_timeScale;

	private float TIMER_defeatEffect;

	public bool CameraShakeActivate;

	private bool shake;

	private float shakeDecay = 0.001f;

	private float shakeIntensity = 0.025f;

	private float shake_decay;

	private float shake_intensity;

	private Transform myTransform;

	private Quaternion originShakeRotation;

	private Vector3 originShakePosition;

	private Quaternion originalPosition;

	private int damageEffectState;

	public int damageEffect;

	private int TOGGLE_damageEffect;

	public tk2dAnimatedSprite hitEffectTeamA;

	public tk2dAnimatedSprite hitEffectTeamB;

	private void Start()
	{
		base.useGUILayout = false;
		originalPosition = myTransform.rotation;
	}

	private void Awake()
	{
		myTransform = base.transform;
	}

	private void Update()
	{
		DefeatEffectFunction();
		CameraShakeFunction();
		DamagedEffectFunction();
	}

	private void DefeatEffectFunction()
	{
		switch (defeatEffect)
		{
		case 1:
			TIMER_defeatEffect = Time.realtimeSinceStartup + 1.5f;
			Time.timeScale = 1E-05f;
			SPEED_timeScale = 0.007f;
			TOGGLE_defeatEffect = 1;
			defeatEffect = 0;
			break;
		case 2:
			TIMER_defeatEffect = Time.realtimeSinceStartup + 1.5f;
			Time.timeScale = 1E-05f;
			TOGGLE_defeatEffect = 1;
			SPEED_timeScale = 0.005f;
			defeatEffect = 0;
			break;
		}
		switch (TOGGLE_defeatEffect)
		{
		case 0:
			break;
		case 1:
			if (Time.realtimeSinceStartup >= TIMER_defeatEffect)
			{
				Time.timeScale += SPEED_timeScale;
				if (Time.timeScale >= 1f)
				{
					TOGGLE_defeatEffect++;
				}
			}
			break;
		case 2:
			Time.timeScale = 1f;
			TOGGLE_defeatEffect = 0;
			break;
		}
	}

	private void CameraShakeFunction()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		if (CameraShakeActivate)
		{
			if (!shake)
			{
				originShakePosition = myTransform.position;
				originShakeRotation = myTransform.rotation;
				shake_intensity = shakeIntensity;
				shake_decay = shakeDecay;
				shake = true;
			}
			CameraShakeActivate = false;
		}
		if (shake)
		{
			if (shake_intensity > 0f)
			{
				Transform transform = myTransform;
				Vector3 position = myTransform.position;
				float x = position.x;
				float y = originShakePosition.y;
				Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
				float y2 = y + insideUnitSphere.y * shake_intensity;
				Vector3 position2 = myTransform.position;
				transform.position = new Vector3(x, y2, position2.z);
				myTransform.rotation = new Quaternion(originShakeRotation.x + UnityEngine.Random.Range(0f - shake_intensity, shake_intensity) * 0.2f, originShakeRotation.y + UnityEngine.Random.Range(0f - shake_intensity, shake_intensity) * 0.2f, originShakeRotation.z + UnityEngine.Random.Range(0f - shake_intensity, shake_intensity) * 0.2f, originShakeRotation.w + UnityEngine.Random.Range(0f - shake_intensity, shake_intensity) * 0.2f);
				shake_intensity -= shake_decay;
			}
			else if (shake_intensity <= 0f)
			{
				shake = false;
			}
		}
		else if (myTransform.rotation != originalPosition)
		{
			myTransform.rotation = originalPosition;
		}
	}

	private void DamagedEffectFunction()
	{
		switch (damageEffectState)
		{
		case 0:
			if (hitEffectTeamA != null && hitEffectTeamB != null)
			{
				Transform transform = hitEffectTeamA.transform;
				Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
				transform.position = new Vector3(vector.x, 1.5f, -5.5f);
				Transform transform2 = hitEffectTeamB.transform;
				Vector3 vector2 = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));
				transform2.position = new Vector3(vector2.x, 1.5f, -5.5f);
				damageEffectState++;
			}
			break;
		case 1:
		{
			switch (damageEffect)
			{
			case 1:
			{
				tk2dAnimatedSprite tk2dAnimatedSprite2 = hitEffectTeamA;
				Color color4 = hitEffectTeamA.color;
				float r2 = color4.r;
				Color color5 = hitEffectTeamA.color;
				float g2 = color5.g;
				Color color6 = hitEffectTeamA.color;
				tk2dAnimatedSprite2.color = new Color(r2, g2, color6.b, 0.3f);
				damageEffect = 0;
				break;
			}
			case 2:
			{
				tk2dAnimatedSprite tk2dAnimatedSprite = hitEffectTeamB;
				Color color = hitEffectTeamB.color;
				float r = color.r;
				Color color2 = hitEffectTeamB.color;
				float g = color2.g;
				Color color3 = hitEffectTeamB.color;
				tk2dAnimatedSprite.color = new Color(r, g, color3.b, 0.3f);
				damageEffect = 0;
				break;
			}
			}
			Color color7 = hitEffectTeamA.color;
			if (color7.a > 0f)
			{
				tk2dAnimatedSprite tk2dAnimatedSprite3 = hitEffectTeamA;
				Color color8 = hitEffectTeamA.color;
				float r3 = color8.r;
				Color color9 = hitEffectTeamA.color;
				float g3 = color9.g;
				Color color10 = hitEffectTeamA.color;
				float b = color10.b;
				Color color11 = hitEffectTeamA.color;
				tk2dAnimatedSprite3.color = new Color(r3, g3, b, color11.a - 0.01f);
			}
			else
			{
				tk2dAnimatedSprite tk2dAnimatedSprite4 = hitEffectTeamA;
				Color color12 = hitEffectTeamA.color;
				float r4 = color12.r;
				Color color13 = hitEffectTeamA.color;
				float g4 = color13.g;
				Color color14 = hitEffectTeamA.color;
				tk2dAnimatedSprite4.color = new Color(r4, g4, color14.b, 0f);
			}
			Color color15 = hitEffectTeamB.color;
			if (color15.a > 0f)
			{
				tk2dAnimatedSprite tk2dAnimatedSprite5 = hitEffectTeamB;
				Color color16 = hitEffectTeamB.color;
				float r5 = color16.r;
				Color color17 = hitEffectTeamB.color;
				float g5 = color17.g;
				Color color18 = hitEffectTeamB.color;
				float b2 = color18.b;
				Color color19 = hitEffectTeamB.color;
				tk2dAnimatedSprite5.color = new Color(r5, g5, b2, color19.a - 0.01f);
			}
			else
			{
				tk2dAnimatedSprite tk2dAnimatedSprite6 = hitEffectTeamB;
				Color color20 = hitEffectTeamB.color;
				float r6 = color20.r;
				Color color21 = hitEffectTeamB.color;
				float g6 = color21.g;
				Color color22 = hitEffectTeamB.color;
				tk2dAnimatedSprite6.color = new Color(r6, g6, color22.b, 0f);
			}
			break;
		}
		}
	}
}
