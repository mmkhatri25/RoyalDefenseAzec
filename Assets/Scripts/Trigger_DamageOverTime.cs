using UnityEngine;

public class Trigger_DamageOverTime : MonoBehaviour
{
	public GameObject triggerBox;

	public float delayPerEnable;

	private float TIMER_delayPerEneble;

	private int state;

	private void Start()
	{
		base.useGUILayout = false;
	}

	private void OnSpawned()
	{
		state = 0;
		triggerBox.active = false;
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		switch (state)
		{
		case 0:
			triggerBox.active = false;
			TIMER_delayPerEneble = Time.time + delayPerEnable;
			state++;
			break;
		case 1:
			triggerBox.active = false;
			if (Time.time >= TIMER_delayPerEneble)
			{
				triggerBox.name = "DOT" + UnityEngine.Random.Range(100, 999);
				TIMER_delayPerEneble = Time.time + 0.1f;
				state = 2;
			}
			break;
		case 2:
			triggerBox.active = true;
			if (Time.time >= TIMER_delayPerEneble)
			{
				TIMER_delayPerEneble = Time.time + delayPerEnable;
				state = 1;
			}
			break;
		}
	}
}
