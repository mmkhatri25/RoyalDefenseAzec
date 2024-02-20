using UnityEngine;

public class Music_Script : MonoBehaviour
{
	public float specialDuration;

	private float DELAY_specialDuration;

	private float TIMER_specialDuration;

	public float specialVolume;

	private float VELOCITY_specialVolume;

	private void OnSpawned()
	{
		ScriptsManager.gameMusicScript = GetComponent<Music_Script>();
		specialDuration = 0f;
		DELAY_specialDuration = 0f;
		specialVolume = 0f;
	}

	private void Update()
	{
		if (specialDuration != 0f)
		{
			TIMER_specialDuration = Time.time + specialDuration;
			DELAY_specialDuration = 1f;
			specialDuration = 0f;
		}
		if (DELAY_specialDuration != 0f)
		{
			if (Time.time < TIMER_specialDuration)
			{
				GetComponent<AudioSource>().volume = specialVolume;
			}
			else if (Time.time >= TIMER_specialDuration)
			{
				if (GetComponent<AudioSource>().volume < 0.4f)
				{
					GetComponent<AudioSource>().volume += 0.025f;
				}
				else if (GetComponent<AudioSource>().volume >= 0.4f)
				{
					GetComponent<AudioSource>().volume = 0.4f;
					DELAY_specialDuration = 0f;
				}
			}
		}
		else if (GetComponent<AudioSource>().volume != 0.4f)
		{
			GetComponent<AudioSource>().volume = 0.4f;
		}
	}
}
