using UnityEngine;

public class Unit_SoundControl : MonoBehaviour
{
	private int state;

	private int unitState;

	private float TIMER_unitState;

	private AudioSource audioSource;

	public AudioClip appearanceClip;

	public AudioClip idleClip;

	public AudioClip movingClip;

	public float movingRepeatTimer;

	public AudioClip guardClip;

	public AudioClip disabledClip;

	public AudioClip[] offenseReadyClip;

	private int offenseNumber;

	public AudioClip damagedClip;

	public AudioClip retreatClip;

	public AudioClip tauntClip;

	private int healthValue;

	private Unit_Control unitcontrol;

	private void Start()
	{
		audioSource = GameScriptsManager.audioSourceC;
		unitcontrol = GetComponent<Unit_Control>();
	}

	private void OnSpawned()
	{
		if (appearanceClip != null)
		{
			audioSource.GetComponent<AudioSource>().PlayOneShot(appearanceClip);
		}
	}

	private void Update()
	{
		if (offenseNumber != unitcontrol.unitOffenseAction)
		{
			offenseNumber = unitcontrol.unitOffenseAction;
		}
		switch (unitcontrol.state)
		{
		case 0:
			healthValue = unitcontrol.attributeHealthValue;
			break;
		case 1:
			if (state != unitcontrol.state)
			{
				state = unitcontrol.state;
			}
			if (healthValue != unitcontrol.attributeHealthValue)
			{
				if (healthValue > unitcontrol.attributeHealthValue)
				{
					audioSource.GetComponent<AudioSource>().PlayOneShot(damagedClip);
				}
				if (healthValue < unitcontrol.attributeHealthValue)
				{
				}
				healthValue = unitcontrol.attributeHealthValue;
			}
			if (unitState == unitcontrol.unitState)
			{
				break;
			}
			switch (unitcontrol.unitState)
			{
			case 0:
				if (idleClip != null)
				{
					audioSource.GetComponent<AudioSource>().PlayOneShot(idleClip);
				}
				break;
			case 1:
				if (movingClip != null)
				{
					if (movingRepeatTimer > 0f)
					{
						audioSource.GetComponent<AudioSource>().PlayOneShot(movingClip);
						TIMER_unitState = Time.time + movingRepeatTimer;
					}
					else
					{
						audioSource.GetComponent<AudioSource>().PlayOneShot(movingClip);
					}
				}
				break;
			case 2:
				if (offenseReadyClip.Length != 0)
				{
					audioSource.GetComponent<AudioSource>().PlayOneShot(offenseReadyClip[offenseNumber]);
				}
				break;
			case 3:
				if (guardClip != null)
				{
					audioSource.GetComponent<AudioSource>().PlayOneShot(guardClip);
				}
				break;
			case 4:
				if (disabledClip != null)
				{
					audioSource.GetComponent<AudioSource>().PlayOneShot(disabledClip);
				}
				break;
			}
			unitState = unitcontrol.unitState;
			break;
		case 2:
			if (state != unitcontrol.state)
			{
				if (retreatClip != null)
				{
					audioSource.GetComponent<AudioSource>().PlayOneShot(retreatClip);
				}
				state = unitcontrol.state;
			}
			break;
		}
		int num = unitState;
		if (num == 1 && movingClip != null && movingRepeatTimer > 0f && Time.time >= TIMER_unitState)
		{
			audioSource.GetComponent<AudioSource>().PlayOneShot(movingClip);
			TIMER_unitState = Time.time + movingRepeatTimer;
		}
	}
}
