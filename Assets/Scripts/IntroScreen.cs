using System.Collections;
using UnityEngine;

public class IntroScreen : MonoBehaviour
{
	public int state;

	private int TOGGLE_state = -1;

	private float TIMER_state;

	public AudioClip[] audioClip;

	public GameObject door;

	private tk2dAnimatedSprite doorSprite;

	public GameObject bg;

	public GameObject ground;

	public GameObject guardObjects;

	public GameObject characterObjects;

	public MenuTransition titleTransition;

	public tk2dAnimatedSprite flash;

	public tk2dTextMesh gameVersionText;

	private int loading;

	private float amountFade;

	public int bgEffectToggle;

	public float bgEffectSpeed;

	public int groundEffectToggle;

	public float groundEffectSpeed;

	public int wobbleToggle;

	private int TOGGLE_wobbleToggle;

	public float rotationSpeed = 0.2f;

	public float rotationThreshold = 0.05f;

	public float expandSpeed = 0.1f;

	public float expandScale = 0.25f;
	GameScriptsManager scriptMasterControl;
    public static GameMasterScriptsControl masterControlScript;
    private void Start()
	{
		doorSprite = door.GetComponent<tk2dAnimatedSprite>();
		if (ScriptsManager.contentDataScript.musicPlaying != 1)
		{
			ScriptsManager.contentDataScript.PlayMusic(0, 0);
		}
		if (ScriptsManager.dataScript.soundMode == 2)
		{
			GetComponent<AudioSource>().mute = true;
		}
		gameVersionText.text = "V" + ScriptsManager.dataScript.gameVersion;
		gameVersionText.Commit();
		titleTransition.transitionNumber = 2;
		CameraScreenTransition.control.Clear(-1);
        //scriptMasterControl = GameScriptsManager.masterControlScript;
    }

	private void Update()
	{
		//if (Input.GetMouseButtonDown(0))
		//{
			//if (state < 10)
			//{
			//	state = 10;
			//	if (Input.GetMouseButtonDown(0))
			//	{
			//		state = 10;
			//	}
			//}
			//else if (state >= 12 && loading == 0)
			//{
			//	GetComponent<AudioSource>().PlayOneShot(audioClip[2]);
			//	CameraScreenTransition.control.SceneTransition(2, "Menu");
			//	loading = 1;
			//}
		//}
		switch (state)
		{
		case 0:
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 1f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				bgEffectToggle = 1;
				groundEffectToggle = 1;
				state = 1;
			}
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				TOGGLE_state = state;
			}
			if (bgEffectToggle == 2 && groundEffectToggle == 2)
			{
				state = 2;
			}
			break;
		case 2:
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 1f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				state = 3;
			}
			break;
		case 3:
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 0.1f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				GetComponent<AudioSource>().PlayOneShot(audioClip[0]);
				wobbleToggle = 1;
				state = 4;
			}
			break;
		case 4:
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 0.8f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				GetComponent<AudioSource>().PlayOneShot(audioClip[0]);
				wobbleToggle = 1;
				state = 5;
			}
			break;
		case 5:
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 0.8f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				GetComponent<AudioSource>().PlayOneShot(audioClip[0]);
				wobbleToggle = 1;
				state = 6;
			}
			break;
		case 6:
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 0.8f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				GetComponent<AudioSource>().PlayOneShot(audioClip[0]);
				if (wobbleToggle == 0)
				{
					wobbleToggle = 6;
				}
				state = 7;
			}
			break;
		case 7:
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 0.2f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				GetComponent<AudioSource>().PlayOneShot(audioClip[1]);
				amountFade = 1f;
				flash.color = Color.white;
				state = 8;
			}
			break;
		case 8:
			if (TOGGLE_state != state)
			{
				guardObjects.SetActiveRecursively(state: false);
				characterObjects.SetActiveRecursively(state: true);
				doorSprite.Play("1");
				TIMER_state = Time.time + 1f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				state = 9;
			}
			break;
		case 9:
		{
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 0.4f;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state && wobbleToggle == 6)
			{
				wobbleToggle = 1;
			}
			Color color6 = flash.color;
			if (color6.a > 0f)
			{
				amountFade -= 0.005f;
				tk2dAnimatedSprite tk2dAnimatedSprite2 = flash;
				Color color7 = flash.color;
				float r2 = color7.r;
				Color color8 = flash.color;
				float g2 = color8.g;
				Color color9 = flash.color;
				tk2dAnimatedSprite2.color = new Color(r2, g2, color9.b, amountFade);
			}
			else
			{
				Color color10 = flash.color;
				if (color10.a <= 0f)
				{
					wobbleToggle = 1;
					state = 10;
				}
			}
			break;
		}
		case 10:
		{
			if (TOGGLE_state != state)
			{
				amountFade = 0f;
				TOGGLE_state = state;
			}
			Color color11 = flash.color;
			if (color11.a < 1f)
			{
				amountFade += 0.01f;
				tk2dAnimatedSprite tk2dAnimatedSprite3 = flash;
				Color color12 = flash.color;
				float r3 = color12.r;
				Color color13 = flash.color;
				float g3 = color13.g;
				Color color14 = flash.color;
				tk2dAnimatedSprite3.color = new Color(r3, g3, color14.b, amountFade);
			}
			else
			{
				Color color15 = flash.color;
				if (color15.a >= 1f)
				{
					flash.color = Color.white;
					state = 11;
				}
			}
			break;
		}
		case 11:
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 1.5f;
				titleTransition.transitionNumber = 3;
				TOGGLE_state = state;
			}
			if (Time.time >= TIMER_state)
			{
				state = 12;
			}
			break;
		case 12:
		{
			if (TOGGLE_state != state)
			{
				TIMER_state = Time.time + 0.4f;
				TOGGLE_state = state;
			}
			Color color = flash.color;
			if (color.a > 0f)
			{
				amountFade -= 0.005f;
				tk2dAnimatedSprite tk2dAnimatedSprite = flash;
				Color color2 = flash.color;
				float r = color2.r;
				Color color3 = flash.color;
				float g = color3.g;
				Color color4 = flash.color;
				tk2dAnimatedSprite.color = new Color(r, g, color4.b, amountFade);
			}
			else
			{
				Color color5 = flash.color;
				if (color5.a <= 0f)
				{
					state = 13;
				}
			}
			break;
		}
		case 13:
			if (TOGGLE_state == state)
			{
			}
			break;
		}
		DoorWobble();
		GroundEffect();
		BackgroundEffect();
	}

	private void BackgroundEffect()
	{
		int num = bgEffectToggle;
		if (num == 0 || num != 1)
		{
			return;
		}
		Vector3 position = bg.transform.position;
		if (position.y > 0.75f)
		{
			bg.transform.Translate(-bg.transform.up * bgEffectSpeed * Time.smoothDeltaTime, Space.World);
			return;
		}
		Vector3 position2 = bg.transform.position;
		if (position2.y <= 0.75f)
		{
			Transform transform = bg.transform;
			Vector3 position3 = bg.transform.position;
			float x = position3.x;
			Vector3 position4 = bg.transform.position;
			transform.position = new Vector3(x, 0.75f, position4.z);
			bgEffectToggle = 2;
		}

		StartCoroutine(waitAndplay());
       
    }
	IEnumerator waitAndplay()
	{
		yield return new WaitForSeconds(10f);
        GetComponent<AudioSource>().PlayOneShot(audioClip[2]);
        CameraScreenTransition.control.SceneTransition(2, "Menu");
        loading = 1;
        print("this is finall step....");
        //scriptMasterControl.Currency(1000);
	}

    private void GroundEffect()
	{
		int num = groundEffectToggle;
		if (num == 0 || num != 1)
		{
			return;
		}
		Vector3 position = ground.transform.position;
		if (position.y > -1.47f)
		{
			ground.transform.Translate(-ground.transform.up * groundEffectSpeed * Time.smoothDeltaTime, Space.World);
			return;
		}
		Vector3 position2 = ground.transform.position;
		if (position2.y <= -1.47f)
		{
			Transform transform = ground.transform;
			Vector3 position3 = ground.transform.position;
			float x = position3.x;
			Vector3 position4 = ground.transform.position;
			transform.position = new Vector3(x, -1.47f, position4.z);
			groundEffectToggle = 2;
		}
	}

	private void DoorWobble()
	{
		switch (wobbleToggle)
		{
		case 1:
			door.transform.Rotate(0f, 0f, 0f);
			TOGGLE_wobbleToggle = 1;
			wobbleToggle = 2;
			break;
		case 2:
		{
			Quaternion localRotation3 = door.transform.localRotation;
			if (localRotation3.z > 0f - rotationThreshold)
			{
				door.transform.Rotate(0f, 0f, 0f - rotationSpeed);
				break;
			}
			Quaternion localRotation4 = door.transform.localRotation;
			if (localRotation4.z <= 0f - rotationThreshold)
			{
				wobbleToggle = 3;
			}
			break;
		}
		case 3:
		{
			Quaternion localRotation9 = door.transform.localRotation;
			if (localRotation9.z < rotationThreshold)
			{
				door.transform.Rotate(0f, 0f, rotationSpeed);
				break;
			}
			Quaternion localRotation10 = door.transform.localRotation;
			if (localRotation10.z >= rotationThreshold)
			{
				wobbleToggle = 4;
			}
			break;
		}
		case 4:
		{
			Quaternion localRotation5 = door.transform.localRotation;
			if (localRotation5.z > 0f)
			{
				door.transform.Rotate(0f, 0f, 0f - rotationSpeed);
				break;
			}
			Quaternion localRotation6 = door.transform.localRotation;
			if (localRotation6.z <= 0f)
			{
				wobbleToggle = 5;
			}
			break;
		}
		case 5:
			base.transform.Rotate(0f, 0f, 0f);
			wobbleToggle = 0;
			break;
		case 6:
		{
			Quaternion localRotation7 = door.transform.localRotation;
			if (localRotation7.z > 0f - rotationThreshold)
			{
				door.transform.Rotate(0f, 0f, (0f - rotationSpeed) * 2f);
				break;
			}
			Quaternion localRotation8 = door.transform.localRotation;
			if (localRotation8.z <= 0f - rotationThreshold)
			{
				TOGGLE_wobbleToggle = 3;
				wobbleToggle = 7;
			}
			break;
		}
		case 7:
		{
			Quaternion localRotation = door.transform.localRotation;
			if (localRotation.z < rotationThreshold)
			{
				door.transform.Rotate(0f, 0f, rotationSpeed * 2f);
				break;
			}
			Quaternion localRotation2 = door.transform.localRotation;
			if (localRotation2.z >= rotationThreshold)
			{
				wobbleToggle = 6;
			}
			break;
		}
		}
		switch (TOGGLE_wobbleToggle)
		{
		case 1:
		{
			Vector3 localScale5 = door.transform.localScale;
			if (localScale5.x < 1f * expandScale)
			{
				door.transform.localScale += new Vector3(expandSpeed * Time.timeScale, expandSpeed * Time.timeScale, expandSpeed * Time.timeScale);
				break;
			}
			Vector3 localScale6 = door.transform.localScale;
			if (localScale6.x >= 1f * expandScale)
			{
				TOGGLE_wobbleToggle = 2;
			}
			break;
		}
		case 2:
		{
			Vector3 localScale7 = door.transform.localScale;
			if (localScale7.x > 1f)
			{
				door.transform.localScale += new Vector3((0f - expandSpeed) * Time.timeScale, (0f - expandSpeed) * Time.timeScale, (0f - expandSpeed) * Time.timeScale);
				break;
			}
			Vector3 localScale8 = door.transform.localScale;
			if (localScale8.x <= 1f)
			{
				door.transform.localScale = new Vector3(1f, 1f, 1f);
				TOGGLE_wobbleToggle = 0;
			}
			break;
		}
		case 3:
		{
			Vector3 localScale3 = door.transform.localScale;
			if (localScale3.x < 1f * expandScale)
			{
				door.transform.localScale += new Vector3(expandSpeed * Time.timeScale, expandSpeed * 2f * Time.timeScale, expandSpeed * Time.timeScale);
				break;
			}
			Vector3 localScale4 = door.transform.localScale;
			if (localScale4.x >= 1f * expandScale)
			{
				TOGGLE_wobbleToggle = 4;
			}
			break;
		}
		case 4:
		{
			Vector3 localScale = door.transform.localScale;
			if (localScale.x > 1f)
			{
				door.transform.localScale += new Vector3((0f - expandSpeed) * Time.timeScale, (0f - expandSpeed) * 2f * Time.timeScale, (0f - expandSpeed) * Time.timeScale);
				break;
			}
			Vector3 localScale2 = door.transform.localScale;
			if (localScale2.x <= 1f)
			{
				door.transform.localScale = new Vector3(1f, 1f, 1f);
				TOGGLE_wobbleToggle = 5;
			}

			break;
		}
		}
	}
}
