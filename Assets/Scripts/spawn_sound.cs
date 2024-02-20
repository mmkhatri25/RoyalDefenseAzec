using UnityEngine;

public class spawn_sound : MonoBehaviour
{
	public int audioSource;

	public AudioClip spawnSoundClip;

	public AudioClip idleSoundClip;

	public float idleRepeatTimer;

	private float TIMER_idleRepeatTimer;

	public AudioClip despawnSoundClip;

	private AudioSource _audioSource;

	private int despawnToggle;

	private void Start()
	{
		switch (audioSource)
		{
		case 0:
			_audioSource = Camera.main.GetComponent<AudioSource>();
			break;
		case 1:
			_audioSource = GameScriptsManager.audioSourceA;
			break;
		case 2:
			_audioSource = GameScriptsManager.audioSourceB;
			break;
		case 3:
			_audioSource = GameScriptsManager.audioSourceC;
			break;
		}
	}

	private void OnSpawned()
	{
		if (_audioSource == null)
		{
			switch (audioSource)
			{
			case 0:
				_audioSource = Camera.main.GetComponent<AudioSource>();
				break;
			case 1:
				_audioSource = GameScriptsManager.audioSourceA;
				break;
			case 2:
				_audioSource = GameScriptsManager.audioSourceB;
				break;
			case 3:
				_audioSource = GameScriptsManager.audioSourceC;
				break;
			}
		}
		if (spawnSoundClip != null)
		{
			_audioSource.GetComponent<AudioSource>().PlayOneShot(spawnSoundClip);
		}
		if (idleRepeatTimer > 0f)
		{
			TIMER_idleRepeatTimer = Time.time + idleRepeatTimer;
		}
	}

	private void OnDespawned()
	{
		if (despawnToggle == 1)
		{
			if (despawnSoundClip != null)
			{
				_audioSource.GetComponent<AudioSource>().PlayOneShot(despawnSoundClip);
			}
		}
		else
		{
			despawnToggle = 1;
		}
	}

	private void Update()
	{
		if (idleRepeatTimer > 0f && Time.time >= TIMER_idleRepeatTimer)
		{
			if (idleSoundClip != null)
			{
				_audioSource.GetComponent<AudioSource>().PlayOneShot(idleSoundClip);
			}
			TIMER_idleRepeatTimer = Time.time + idleRepeatTimer;
		}
	}
}
