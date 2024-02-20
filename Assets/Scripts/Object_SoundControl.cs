using UnityEngine;

public class Object_SoundControl : MonoBehaviour
{
	public AudioClip appearanceClip;

	public AudioClip idleClip;

	public float idleClipRepeatTimer;

	private float TIMER_idleClipRepeatTimer;

	public AudioClip pickUpClip;

	public AudioClip pickUpIdleClip;

	public float pickUpIdleClipRepeatTimer;

	private float TIMER_pickUpIdleClipRepeatTimer;

	public AudioClip releaseClip;

	public AudioClip damagedClip;

	private int healthValue;

	public AudioClip breakClipA;

	public AudioClip breakClipB;

	public AudioClip breakClipC;

	private int breakClipNumber;

	private int RANDOM_breakClipNumber;

	private int PLAY_breakClipNumber;

	public AudioClip disappeanceClip;

	private Object_Control objectControl;

	private AudioSource audioSource;

	private int state = -1;

	private int despawnToggle;

	private void Start()
	{
		objectControl = GetComponent<Object_Control>();
		audioSource = GameScriptsManager.audioSourceB;
		if (breakClipA != null)
		{
			breakClipNumber += 30;
		}
		if (breakClipB != null)
		{
			breakClipNumber += 30;
		}
		if (breakClipC != null)
		{
			breakClipNumber += 30;
		}
	}

	private void OnSpawned()
	{
		if (appearanceClip != null)
		{
			audioSource.GetComponent<AudioSource>().PlayOneShot(appearanceClip);
		}
		if (idleClip != null && idleClipRepeatTimer > 0f)
		{
			TIMER_idleClipRepeatTimer = Time.time + idleClipRepeatTimer;
		}
	}

	private void OnDespawned()
	{
		if (despawnToggle == 1)
		{
			if (disappeanceClip != null)
			{
				audioSource.GetComponent<AudioSource>().PlayOneShot(disappeanceClip);
			}
		}
		else
		{
			despawnToggle = 1;
		}
	}

	private void Update()
	{
		if (state != objectControl.objectState)
		{
			switch (objectControl.objectState)
			{
			case 0:
				if (breakClipNumber <= 0)
				{
					break;
				}
				if (breakClipNumber > 30)
				{
					RANDOM_breakClipNumber = UnityEngine.Random.Range(1, breakClipNumber);
					if (RANDOM_breakClipNumber <= 30)
					{
						PLAY_breakClipNumber = 1;
					}
					else if (RANDOM_breakClipNumber > 30 && RANDOM_breakClipNumber <= 60)
					{
						PLAY_breakClipNumber = 2;
					}
					else if (RANDOM_breakClipNumber > 60)
					{
						PLAY_breakClipNumber = 3;
					}
				}
				else
				{
					PLAY_breakClipNumber = 1;
				}
				break;
			case 2:
				if (pickUpClip != null)
				{
					audioSource.GetComponent<AudioSource>().PlayOneShot(pickUpClip);
				}
				if (pickUpIdleClip != null && pickUpIdleClipRepeatTimer > 0f)
				{
					TIMER_pickUpIdleClipRepeatTimer = Time.time + pickUpIdleClipRepeatTimer;
				}
				break;
			case 4:
				healthValue = objectControl.attributeHealthValue;
				if (releaseClip != null)
				{
					audioSource.GetComponent<AudioSource>().PlayOneShot(releaseClip);
				}
				break;
			case 5:
				switch (PLAY_breakClipNumber)
				{
				case 1:
					audioSource.GetComponent<AudioSource>().PlayOneShot(breakClipA);
					break;
				case 2:
					audioSource.GetComponent<AudioSource>().PlayOneShot(breakClipB);
					break;
				case 3:
					audioSource.GetComponent<AudioSource>().PlayOneShot(breakClipC);
					break;
				}
				break;
			}
			state = objectControl.objectState;
		}
		switch (state)
		{
		case 1:
		case 3:
			break;
		case 0:
			if (idleClip != null && idleClipRepeatTimer > 0f && Time.time >= TIMER_idleClipRepeatTimer)
			{
				audioSource.GetComponent<AudioSource>().PlayOneShot(idleClip);
				TIMER_idleClipRepeatTimer = Time.time + idleClipRepeatTimer;
			}
			break;
		case 2:
			if (pickUpIdleClip != null && pickUpIdleClipRepeatTimer > 0f && Time.time >= TIMER_pickUpIdleClipRepeatTimer)
			{
				audioSource.GetComponent<AudioSource>().PlayOneShot(pickUpIdleClip);
				TIMER_pickUpIdleClipRepeatTimer = Time.time + pickUpIdleClipRepeatTimer;
			}
			break;
		case 4:
			if (damagedClip != null && healthValue != objectControl.attributeHealthValue)
			{
				audioSource.GetComponent<AudioSource>().PlayOneShot(damagedClip);
				healthValue = objectControl.attributeHealthValue;
			}
			break;
		}
	}
}
