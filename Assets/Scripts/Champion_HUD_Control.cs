using UnityEngine;

public class Champion_HUD_Control : MonoBehaviour
{
	public int quotesOn;

	public int speechType;

	public string portraitID;

	public string warningQuote;

	public string introductionSpeech;

	public string championName;

	public int state;

	private int HUDState;

	public GameObject Background;

	public GameObject Warning;

	public GameObject Portrait;

	public tk2dAnimatedSprite championPortrait;

	public tk2dTextMesh enterText;

	public tk2dTextMesh speechText;

	public tk2dTextMesh nameText;

	private float damping = 5f;

	private Vector3 BackgroundOn;

	private Vector3 BackgroundOff;

	private Vector3 WarningOn;

	private Vector3 WarningOff;

	private Vector3 WarningOff2;

	private Vector3 ChampionPortraitOn;

	private Vector3 ChampionPortraitOff;

	private float TIMER_display;

	private int championHUDstate;

	private float TIMER_championHUDstate;

	public Unit_Control scriptUnitControl;

	public tk2dTextMesh healthHudText;

	private Color COLOR_sprite;

	private int TOGGLE_healthValue;

	public GameObject healthHud;

	public Transform hudPosition;

	public pop_effect healthHudPopEffect;

	private int TOGGLE_state;

	private int TOGGLE_background;

	private int TOGGLE_warning;

	private int TOGGLE_portrait;

	private void Awake()
	{
		base.useGUILayout = false;
		base.transform.localPosition = Vector3.zero;
		BackgroundOn = Background.transform.localPosition;
		BackgroundOff = new Vector3(BackgroundOn.x - 18.5f, BackgroundOn.y, BackgroundOn.z);
		WarningOn = Warning.transform.localPosition;
		WarningOff = new Vector3(WarningOn.x - 16.4f, WarningOn.y, WarningOn.z);
		WarningOff2 = new Vector3(WarningOn.x + 16.4f, WarningOn.y, WarningOn.z);
		Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));
		float num = vector.x - 0.5f;
		Vector3 position = Camera.main.transform.position;
		ChampionPortraitOn = new Vector3(num - position.x, 1.9f, 4.4f);
		ChampionPortraitOff = new Vector3(ChampionPortraitOn.x + 11f, ChampionPortraitOn.y, ChampionPortraitOn.z);
		Portrait.transform.localPosition = ChampionPortraitOff;
		championHUDstate = -1;
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			base.transform.localPosition = new Vector3(0f, 100f, 0f);
			return;
		}
		if (base.transform.localPosition != Vector3.zero)
		{
			base.transform.localPosition = Vector3.zero;
		}
		championHUD();
		ActivationFunction();
		HUDControlFunction();
	}

	private void championHUD()
	{
		switch (championHUDstate)
		{
		case -1:
			healthHud.transform.localPosition = new Vector3(0f, 100f, 4.2f);
			scriptUnitControl = null;
			championHUDstate = -1;
			break;
		case 1:
			if (scriptUnitControl != null)
			{
				TOGGLE_portrait = 1;
				healthHud.transform.localPosition = new Vector3(0f, 0f, 4.2f);
				healthHudPopEffect.activate = true;
				TIMER_championHUDstate = Time.time + 2f;
				championHUDstate++;
			}
			break;
		case 2:
			if (Time.time >= TIMER_championHUDstate)
			{
				TIMER_championHUDstate = Time.time + 2f;
				championHUDstate++;
			}
			break;
		case 3:
			if (Time.time >= TIMER_championHUDstate)
			{
				championHUDstate++;
			}
			if (healthHud.transform.position != hudPosition.position)
			{
				healthHud.transform.position = Vector3.Lerp(healthHud.transform.position, hudPosition.position, 0.2f);
			}
			else
			{
				championHUDstate++;
			}
			break;
		case 4:
			healthHud.transform.position = hudPosition.position;
			championHUDstate++;
			break;
		}
		if (!(scriptUnitControl != null))
		{
			return;
		}
		if (scriptUnitControl.attributeHealthValue >= scriptUnitControl.attributeHealthMaximumValue)
		{
			COLOR_sprite = new Color(0f, 1f, 0f, 1f);
		}
		else if (scriptUnitControl.attributeHealthValue < scriptUnitControl.attributeHealthMaximumValue && scriptUnitControl.attributeHealthValue >= scriptUnitControl.attributeHealthMaximumValue / 2)
		{
			COLOR_sprite = new Color(0.5f, 1f, 0.5f, 1f);
		}
		else if (scriptUnitControl.attributeHealthValue < scriptUnitControl.attributeHealthMaximumValue / 2 && scriptUnitControl.attributeHealthValue >= scriptUnitControl.attributeHealthMaximumValue / 4)
		{
			COLOR_sprite = new Color(1f, 1f, 0.5f, 1f);
		}
		else if (scriptUnitControl.attributeHealthValue < scriptUnitControl.attributeHealthMaximumValue / 4)
		{
			COLOR_sprite = new Color(1f, 0.5f, 0.5f, 1f);
		}
		if (TOGGLE_healthValue != scriptUnitControl.attributeHealthValue)
		{
			if (scriptUnitControl.attributeHealthValue > 0)
			{
				healthHudPopEffect.activate = true;
				healthHudText.color = COLOR_sprite;
				healthHudText.text = string.Empty + scriptUnitControl.attributeHealthValue;
			}
			else if (scriptUnitControl.attributeHealthValue <= 0)
			{
				healthHudPopEffect.activate = true;
				healthHudText.color = Color.red;
				healthHudText.text = "0";
			}
			healthHudText.Commit();
			TOGGLE_healthValue = scriptUnitControl.attributeHealthValue;
		}
	}

	public void ActivationFunction(int toggle, int speechClass, string championID, string warning, string introduction, string name)
	{
		speechType = speechClass;
		portraitID = championID;
		warningQuote = warning;
		introductionSpeech = introduction;
		championName = name;
		state = toggle;
	}

	private void ActivationFunction()
	{
		switch (state)
		{
		case 0:
			if (TOGGLE_state != state)
			{
				HUDState = 0;
				TOGGLE_background = 0;
				TOGGLE_warning = 0;
				TOGGLE_portrait = 2;
				championHUDstate = -1;
				TOGGLE_state = state;
			}
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				switch (speechType)
				{
				case 0:
					enterText.color = Color.white;
					speechText.color = Color.white;
					nameText.color = Color.white;
					break;
				case 1:
					enterText.color = new Color(0.5f, 1f, 0.5f, 1f);
					speechText.color = new Color(0.5f, 1f, 0.5f, 1f);
					nameText.color = new Color(0.5f, 1f, 0.5f, 1f);
					break;
				}
				championPortrait.Play("bi_" + portraitID);
				enterText.text = string.Empty + warningQuote + " THE CASTLE!!!";
				enterText.Commit();
				if (quotesOn == 1)
				{
					speechText.text = "'" + introductionSpeech + "'";
					nameText.text = "- " + championName;
					speechText.Commit();
					nameText.Commit();
				}
				HUDState = 0;
				TOGGLE_state = state;
				break;
			}
			switch (HUDState)
			{
			case 0:
				championHUDstate = 1;
				TOGGLE_background = 0;
				TOGGLE_warning = 0;
				HUDState = 1;
				break;
			case 1:
				TOGGLE_warning = 1;
				if (quotesOn == 1)
				{
					TIMER_display = Time.time + 4f;
				}
				else
				{
					TIMER_display = Time.time + 8f;
				}
				HUDState = 2;
				break;
			case 2:
				if (Time.time >= TIMER_display)
				{
					TOGGLE_warning = 2;
					TOGGLE_portrait = 1;
					if (quotesOn == 1)
					{
						TOGGLE_background = 1;
						TIMER_display = Time.time + 6f;
						HUDState = 3;
					}
					else
					{
						HUDState = 4;
					}
				}
				break;
			case 3:
				if (Time.time >= TIMER_display)
				{
					TOGGLE_background = 2;
					HUDState = 4;
				}
				break;
			}
			break;
		}
	}

	private void HUDControlFunction()
	{
		switch (TOGGLE_background)
		{
		case 0:
			if (Background.transform.localPosition != BackgroundOff)
			{
				Background.transform.localPosition = BackgroundOff;
			}
			break;
		case 1:
			Background.transform.localPosition = Vector3.Lerp(Background.transform.localPosition, BackgroundOn, Time.deltaTime * damping);
			break;
		case 2:
			Background.transform.localPosition = Vector3.Lerp(Background.transform.localPosition, BackgroundOff, Time.deltaTime * damping);
			break;
		}
		switch (TOGGLE_warning)
		{
		case 0:
			if (Warning.transform.localPosition != WarningOff)
			{
				Warning.transform.localPosition = WarningOff;
			}
			break;
		case 1:
			Warning.transform.localPosition = Vector3.Lerp(Warning.transform.localPosition, WarningOn, Time.deltaTime * damping);
			break;
		case 2:
			Warning.transform.localPosition = Vector3.Lerp(Warning.transform.localPosition, WarningOff2, Time.deltaTime * damping);
			break;
		}
		switch (TOGGLE_portrait)
		{
		case 0:
			if (Portrait.transform.localPosition != ChampionPortraitOff)
			{
				Portrait.transform.localPosition = ChampionPortraitOff;
			}
			break;
		case 1:
			Portrait.transform.localPosition = Vector3.Lerp(Portrait.transform.localPosition, ChampionPortraitOn, Time.deltaTime * damping);
			break;
		case 2:
			Portrait.transform.localPosition = Vector3.Lerp(Portrait.transform.localPosition, ChampionPortraitOff, Time.deltaTime * 2f);
			break;
		}
	}
}
