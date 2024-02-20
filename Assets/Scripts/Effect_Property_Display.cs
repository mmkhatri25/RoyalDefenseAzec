using UnityEngine;

public class Effect_Property_Display : MonoBehaviour
{
	private GameObject TARGET_unit;

	private Transform myTransform;

	public tk2dAnimatedSprite stateEffectSprite;

	private int TOGGLE_stateEffect;

	private int POPEFFECT_stateEffect;

	private float POPEFFECTEXPANDSIZE_stateEffect;

	private float POPEFFECTORIGINALSIZE_stateEffect;

	private float POPEFFECTSPEED_stateEffect = 0.1f;

	public tk2dTextMesh hitTextMesh;

	private int TOGGLE_hitText;

	private float EXPANDSPEED_hitText;

	private float FADESPEED_hitText;

	private float RISESPEED_hitText;

	private float RISERANDOMPOSITION_hitText;

	private float TIMER_hitText;

	private float ORIGINALSIZE_hitText;

	private float EXPANDSIZE_hitText;

	private int POPEFFECT_hitText;

	private int FADEEFFECT_hitText;

	private int RISEEFFECT_hitText;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	public void HitEffectState(GameObject target, int toggle, int alignment, int stateEffect, int stateEffectNumber, float effectScale)
	{
		switch (toggle)
		{
		case 0:
			TOGGLE_stateEffect = 0;
			PoolManager.Pools["HUD Pool"].Despawn(base.transform);
			break;
		case 1:
			if (target != null)
			{
				TARGET_unit = target;
			}
			else
			{
				TARGET_unit = null;
			}
			stateEffectSprite.scale = new Vector3(effectScale, effectScale, effectScale);
			stateEffectSprite.Play("se_" + stateEffect + "_" + stateEffectNumber);
			switch (alignment)
			{
			case -1:
				stateEffectSprite.transform.localPosition = new Vector3(0f, -0.05f, -2f);
				break;
			case 0:
				stateEffectSprite.transform.localPosition = new Vector3(0f, -0.05f, -1.5f);
				break;
			case 1:
				stateEffectSprite.transform.localPosition = new Vector3(0f, -0.05f, -1.5f);
				break;
			}
			POPEFFECT_stateEffect = 1;
			TOGGLE_stateEffect = 1;
			break;
		case 2:
			if (target != null)
			{
				TARGET_unit = target;
			}
			else
			{
				TARGET_unit = null;
			}
			stateEffectSprite.scale = new Vector3(effectScale, effectScale, effectScale);
			stateEffectSprite.Play("se_" + stateEffect + "_" + stateEffectNumber);
			switch (alignment)
			{
			case -1:
				stateEffectSprite.transform.localPosition = new Vector3(0f, 0.05f, -2f);
				break;
			case 0:
				stateEffectSprite.transform.localPosition = new Vector3(-0.1f, 0.05f, -2f);
				break;
			case 1:
				stateEffectSprite.transform.localPosition = new Vector3(0.1f, 0.05f, -2f);
				break;
			}
			POPEFFECT_stateEffect = 1;
			TOGGLE_stateEffect = 1;
			break;
		case 3:
			if (target != null)
			{
				TARGET_unit = target;
			}
			else
			{
				TARGET_unit = null;
			}
			stateEffectSprite.scale = new Vector3(effectScale, effectScale, effectScale);
			stateEffectSprite.Play("se_" + stateEffect + "_" + stateEffectNumber);
			switch (alignment)
			{
			case -1:
				stateEffectSprite.transform.localPosition = new Vector3(0f, 0f, -1f);
				break;
			case 0:
				stateEffectSprite.transform.localPosition = new Vector3(-0.15f, 0f, -1f);
				break;
			case 1:
				stateEffectSprite.transform.localPosition = new Vector3(0.15f, 0f, -1f);
				break;
			}
			POPEFFECT_stateEffect = 1;
			TOGGLE_stateEffect = 1;
			break;
		}
	}

	private void HitEffectState()
	{
		switch (TOGGLE_stateEffect)
		{
		case 1:
			if (TARGET_unit != null)
			{
				Transform transform = myTransform;
				Vector3 position = TARGET_unit.transform.position;
				float x = position.x;
				Vector3 position2 = TARGET_unit.transform.position;
				float y = position2.y;
				Vector3 position3 = myTransform.position;
				transform.position = new Vector3(x, y, position3.z);
			}
			TOGGLE_stateEffect++;
			break;
		case 2:
			stateEffectSprite.GetComponent<Renderer>().enabled = true;
			TOGGLE_stateEffect++;
			break;
		case 3:
			HitEffectStatePopEffect();
			if (TARGET_unit != null && (TARGET_unit == null || !TARGET_unit.active))
			{
				PoolManager.Pools["HUD Pool"].Despawn(base.transform);
			}
			break;
		}
	}

	private void HitEffectStatePopEffect()
	{
		switch (POPEFFECT_stateEffect)
		{
		case 0:
			break;
		case 1:
		{
			Vector3 scale3 = stateEffectSprite.scale;
			POPEFFECTORIGINALSIZE_stateEffect = scale3.x;
			POPEFFECTEXPANDSIZE_stateEffect = POPEFFECTORIGINALSIZE_stateEffect * 1.5f;
			POPEFFECT_stateEffect = 2;
			break;
		}
		case 2:
		{
			Vector3 scale4 = stateEffectSprite.scale;
			if (scale4.x < POPEFFECTEXPANDSIZE_stateEffect)
			{
				stateEffectSprite.scale += new Vector3(POPEFFECTSPEED_stateEffect, POPEFFECTSPEED_stateEffect, POPEFFECTSPEED_stateEffect);
				break;
			}
			Vector3 scale5 = stateEffectSprite.scale;
			if (scale5.x >= POPEFFECTEXPANDSIZE_stateEffect)
			{
				stateEffectSprite.scale = new Vector3(POPEFFECTEXPANDSIZE_stateEffect, POPEFFECTEXPANDSIZE_stateEffect, POPEFFECTEXPANDSIZE_stateEffect);
				POPEFFECT_stateEffect = 3;
			}
			break;
		}
		case 3:
		{
			Vector3 scale = stateEffectSprite.scale;
			if (scale.x > POPEFFECTORIGINALSIZE_stateEffect)
			{
				stateEffectSprite.scale += new Vector3(0f - POPEFFECTSPEED_stateEffect, 0f - POPEFFECTSPEED_stateEffect, 0f - POPEFFECTSPEED_stateEffect);
				break;
			}
			Vector3 scale2 = stateEffectSprite.scale;
			if (scale2.x <= POPEFFECTORIGINALSIZE_stateEffect)
			{
				stateEffectSprite.scale = new Vector3(POPEFFECTORIGINALSIZE_stateEffect, POPEFFECTORIGINALSIZE_stateEffect, POPEFFECTORIGINALSIZE_stateEffect);
				POPEFFECT_stateEffect = 0;
			}
			break;
		}
		}
	}

	public void HitEffectText(GameObject target, int toggle, Color color, string text, float size, float expandSpeed, float fadeSpeed, float riseSpeed, float riseRandomPosition)
	{
		if (toggle != 0 && toggle == 1)
		{
			if (target != null)
			{
				TARGET_unit = target;
			}
			else
			{
				TARGET_unit = null;
			}
			hitTextMesh.transform.localPosition = new Vector3(0f, 0f, -3f);
			EXPANDSIZE_hitText = size * 2f;
			ORIGINALSIZE_hitText = size;
			TIMER_hitText = Time.time + 5f;
			FADESPEED_hitText = fadeSpeed * 1.5f;
			RISESPEED_hitText = riseSpeed;
			EXPANDSPEED_hitText = expandSpeed * 1.5f;
			hitTextMesh.scale = new Vector3(size, size, size);
			hitTextMesh.text = text;
			hitTextMesh.color = color;
			if (expandSpeed > 0f)
			{
				POPEFFECT_hitText = 1;
			}
			if (fadeSpeed > 0f)
			{
				FADEEFFECT_hitText = 1;
			}
			if (riseSpeed > 0f)
			{
				RISEEFFECT_hitText = 1;
			}
			if (riseRandomPosition > 0f)
			{
				RISERANDOMPOSITION_hitText = UnityEngine.Random.Range(0f - riseRandomPosition, riseRandomPosition);
			}
			else
			{
				RISERANDOMPOSITION_hitText = 0f;
			}
			TOGGLE_hitText = 1;
		}
	}

	private void HitEffectText()
	{
		switch (TOGGLE_hitText)
		{
		case 0:
			break;
		case -1:
			PoolManager.Pools["HUD Pool"].Despawn(base.transform);
			break;
		case 1:
			if (POPEFFECT_hitText == 0 && FADEEFFECT_hitText == 0)
			{
				TOGGLE_hitText = -1;
			}
			HitTextPopEffect();
			HitTextFadeEffect();
			HitTextRiseEffect();
			hitTextMesh.Commit();
			break;
		}
	}

	private void HitTextPopEffect()
	{
		switch (POPEFFECT_hitText)
		{
		case 0:
			break;
		case 1:
		{
			Vector3 scale3 = hitTextMesh.scale;
			if (scale3.x < EXPANDSIZE_hitText)
			{
				hitTextMesh.scale += new Vector3(EXPANDSPEED_hitText, EXPANDSPEED_hitText, EXPANDSPEED_hitText);
				break;
			}
			Vector3 scale4 = hitTextMesh.scale;
			if (scale4.x >= EXPANDSIZE_hitText)
			{
				hitTextMesh.scale = new Vector3(EXPANDSIZE_hitText, EXPANDSIZE_hitText, EXPANDSIZE_hitText);
				POPEFFECT_hitText = 2;
			}
			break;
		}
		case 2:
		{
			Vector3 scale = hitTextMesh.scale;
			if (scale.x > ORIGINALSIZE_hitText)
			{
				hitTextMesh.scale += new Vector3(0f - EXPANDSPEED_hitText, 0f - EXPANDSPEED_hitText, 0f - EXPANDSPEED_hitText);
				break;
			}
			Vector3 scale2 = hitTextMesh.scale;
			if (scale2.x <= ORIGINALSIZE_hitText)
			{
				hitTextMesh.scale = new Vector3(ORIGINALSIZE_hitText, ORIGINALSIZE_hitText, ORIGINALSIZE_hitText);
				POPEFFECT_hitText = 0;
			}
			break;
		}
		}
	}

	private void HitTextFadeEffect()
	{
		int fADEEFFECT_hitText = FADEEFFECT_hitText;
		if (fADEEFFECT_hitText != 1 || POPEFFECT_hitText != 0)
		{
			return;
		}
		Color color = hitTextMesh.color;
		if (color.a > 0f)
		{
			hitTextMesh.color -= new Color(0f, 0f, 0f, FADESPEED_hitText);
			return;
		}
		Color color2 = hitTextMesh.color;
		if (color2.a <= 0f)
		{
			tk2dTextMesh tk2dTextMesh = hitTextMesh;
			Color color3 = hitTextMesh.color;
			float r = color3.r;
			Color color4 = hitTextMesh.color;
			float g = color4.g;
			Color color5 = hitTextMesh.color;
			tk2dTextMesh.color = new Color(r, g, color5.b, 0f);
			FADEEFFECT_hitText = 0;
		}
	}

	private void HitTextRiseEffect()
	{
		int rISEEFFECT_hitText = RISEEFFECT_hitText;
		if (rISEEFFECT_hitText != 1)
		{
			return;
		}
		if (Time.time < TIMER_hitText)
		{
			if (RISERANDOMPOSITION_hitText != 0f)
			{
				hitTextMesh.transform.Translate(myTransform.right * RISERANDOMPOSITION_hitText * Time.smoothDeltaTime, Space.World);
			}
			hitTextMesh.transform.Translate(myTransform.up * RISESPEED_hitText * Time.smoothDeltaTime, Space.World);
			hitTextMesh.transform.Translate(myTransform.forward * 0.5f * Time.smoothDeltaTime, Space.World);
		}
		else if (Time.time >= TIMER_hitText)
		{
			RISEEFFECT_hitText = 0;
		}
	}

	private void OnDespawned()
	{
		stateEffectSprite.GetComponent<Renderer>().enabled = false;
		TOGGLE_hitText = 0;
		hitTextMesh.transform.localPosition = new Vector3(0f, 0f, -3f);
	}

	private void OnSpawned()
	{
		stateEffectSprite.GetComponent<Renderer>().enabled = false;
		TOGGLE_hitText = 0;
		hitTextMesh.transform.localPosition = new Vector3(0f, 0f, -3f);
	}

	private void Update()
	{
		if (TARGET_unit != null)
		{
			Vector3 position = TARGET_unit.transform.position;
			if (position.y >= 100f)
			{
				TARGET_unit = null;
			}
			else
			{
				Transform transform = myTransform;
				Vector3 position2 = TARGET_unit.transform.position;
				float x = position2.x;
				Vector3 position3 = TARGET_unit.transform.position;
				float y = position3.y;
				Vector3 position4 = myTransform.position;
				transform.position = new Vector3(x, y, position4.z);
			}
		}
		HitEffectText();
		HitEffectState();
	}
}
