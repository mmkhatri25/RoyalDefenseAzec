using UnityEngine;

public class Splash_Screen : MonoBehaviour
{
	public Game_Data data;

	public int screenNumber = -1;

	private int TOGGLE_screenNumber = -2;

	private float screenDelay;

	private float TIMER_screenDelay;

	public string sceneName;

	public GameObject soundWindow;

	public tk2dAnimatedSprite headphoneSprite;

	public AudioClip iconClip;

	public pop_effect iconPopEffect;

	public tk2dAnimatedSprite iconSprite;

	public AudioClip logoClip;

	public pop_effect logoPopEffect;

	public tk2dAnimatedSprite logoSprite;

	public MenuTransition menuTransition;

	public AudioSource thisAudioSource;

	public tk2dSprite bgSprite;

	private float alphaColor = 1f;

	private void Awake()
	{
		data = ScriptsManager.dataScript;
	}

	private void Start()
	{
       
    }

	private void FixedUpdate()
	{
		ScreenLogic();
	}

	private void SoundSelect()
	{
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			if (hitInfo.collider.transform.name == "1")
			{
				data.GameAnalytics2("main:button:soundOn", 0f);
				thisAudioSource.mute = false;
				data.SoundOption(0);
				ScriptsManager.contentDataScript.PlayMusic(0, 0);
				screenNumber = 4;
			}
			if (hitInfo.collider.transform.name == "2")
			{
				data.GameAnalytics2("main:button:soundOff", 0f);
				thisAudioSource.mute = true;
				data.SoundOption(2);
				ScriptsManager.contentDataScript.PlayMusic(0, -1);
				screenNumber = 4;
			}
		}
	}

	private void ScreenLogic()
	{
		switch (screenNumber)
		{
		case -1:
			data.GameCenter(1, -1, 0);
			screenNumber++;
			break;
		case 0:
			if (TOGGLE_screenNumber != screenNumber)
			{
				screenDelay = 1f;
				TIMER_screenDelay = Time.time + screenDelay;
				TOGGLE_screenNumber = screenNumber;
			}
			if (Time.time >= TIMER_screenDelay)
			{
				screenNumber++;
			}
			break;
		case 1:
			CameraScreenTransition.control.Clear(-1);
			screenNumber++;
			break;
		case 2:
			if (TOGGLE_screenNumber != screenNumber)
			{
				screenDelay = 2f;
				TIMER_screenDelay = Time.time + screenDelay;
				TOGGLE_screenNumber = screenNumber;
			}
			if (Time.time >= TIMER_screenDelay)
			{
				screenNumber++;
			}
			break;
		case 3:
                data.GameAnalytics2("main:button:soundOn", 0f);
                thisAudioSource.mute = false;
                data.SoundOption(0);
                ScriptsManager.contentDataScript.PlayMusic(0, 0);
                screenNumber = 4;
                //if (TOGGLE_screenNumber != screenNumber)
                //{
                //	soundWindow.SetActiveRecursively(state: true);
                //	TOGGLE_screenNumber = screenNumber;
                //}
                //SoundSelect();
                break;
		case 4:
			if (TOGGLE_screenNumber != screenNumber)
			{
				soundWindow.SetActiveRecursively(state: false);
				screenDelay = 2f;
				TIMER_screenDelay = Time.time + screenDelay;
				TOGGLE_screenNumber = screenNumber;
			}
			if (Time.time >= TIMER_screenDelay)
			{
				screenNumber++;
			}
			break;
		case 5:
			if (TOGGLE_screenNumber != screenNumber)
			{
				iconPopEffect.activate = true;
				iconSprite.color = Color.white;
				screenDelay = 0.8f;
				TIMER_screenDelay = Time.time + screenDelay;
				TOGGLE_screenNumber = screenNumber;
			}
			if (Time.time >= TIMER_screenDelay)
			{
				screenNumber++;
			}
			break;
		case 6:
			if (TOGGLE_screenNumber != screenNumber)
			{
				GetComponent<AudioSource>().PlayOneShot(iconClip);
				iconPopEffect.activate = true;
				iconSprite.Play("logo_key");
				screenDelay = 0.8f;
				TIMER_screenDelay = Time.time + screenDelay;
				TOGGLE_screenNumber = screenNumber;
			}
			if (Time.time >= TIMER_screenDelay)
			{
				screenNumber++;
			}
			break;
		case 7:
			if (TOGGLE_screenNumber != screenNumber)
			{
				GetComponent<AudioSource>().PlayOneShot(iconClip);
				iconPopEffect.activate = true;
				iconSprite.Play("logo_key");
				screenDelay = 0.8f;
				TIMER_screenDelay = Time.time + screenDelay;
				TOGGLE_screenNumber = screenNumber;
			}
			if (Time.time >= TIMER_screenDelay)
			{
				screenNumber++;
			}
			break;
		case 8:
			if (TOGGLE_screenNumber != screenNumber)
			{
				GetComponent<AudioSource>().PlayOneShot(iconClip);
				iconPopEffect.activate = true;
				iconSprite.Play("logo_key");
				screenDelay = 0.8f;
				TIMER_screenDelay = Time.time + screenDelay;
				TOGGLE_screenNumber = screenNumber;
			}
			if (Time.time >= TIMER_screenDelay)
			{
				screenNumber++;
			}
			break;
		case 9:
		{
			Color color = bgSprite.color;
			if (color.a != 0f)
			{
				Color color2 = bgSprite.color;
				if (color2.a > 0f)
				{
					tk2dSprite tk2dSprite = bgSprite;
					Color color3 = bgSprite.color;
					tk2dSprite.color = new Color(1f, 1f, 1f, color3.a - 0.1f);
				}
				else
				{
					Color color4 = bgSprite.color;
					if (color4.a <= 0f)
					{
						bgSprite.color = Color.clear;
					}
				}
			}
			if (TOGGLE_screenNumber != screenNumber)
			{
				iconSprite.Play("blank");
				GetComponent<AudioSource>().PlayOneShot(logoClip);
				logoPopEffect.activate = true;
				logoSprite.Play("Fantasync");
				tk2dAnimatedSprite tk2dAnimatedSprite = logoSprite;
				Color color5 = logoSprite.color;
				float r = color5.r;
				Color color6 = logoSprite.color;
				float g = color6.g;
				Color color7 = logoSprite.color;
				tk2dAnimatedSprite.color = new Color(r, g, color7.b, 1f);
				alphaColor = 1f;
				screenDelay = 4f;
				TIMER_screenDelay = Time.time + screenDelay;
				TOGGLE_screenNumber = screenNumber;
			}
			if (Time.time >= TIMER_screenDelay)
			{
				if (alphaColor > 0f)
				{
					alphaColor -= 0.05f;
					tk2dAnimatedSprite tk2dAnimatedSprite2 = logoSprite;
					Color color8 = logoSprite.color;
					float r2 = color8.r;
					Color color9 = logoSprite.color;
					float g2 = color9.g;
					Color color10 = logoSprite.color;
					tk2dAnimatedSprite2.color = new Color(r2, g2, color10.b, alphaColor);
				}
				else if (alphaColor <= 0f)
				{
					screenNumber++;
				}
			}
			break;
		}
		case 10:
			CameraScreenTransition.control.SceneTransition(2, sceneName);
			screenNumber++;
			break;
		}
	}
}
