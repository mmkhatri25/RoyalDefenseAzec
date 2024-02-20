using UnityEngine;

public class PickUp_TutorialAddon : MonoBehaviour
{
	private int state;

	private Pickup_Script pickUpScript;

	private Tutorial_Logic tutorialLogic;

	private void Start()
	{
		pickUpScript = GetComponent<Pickup_Script>();
		tutorialLogic = GameObject.Find("Tutorial Logic").GetComponent<Tutorial_Logic>();
	}

	private void OnSpawned()
	{
		pickUpScript = GetComponent<Pickup_Script>();
		tutorialLogic = GameObject.Find("Tutorial Logic").GetComponent<Tutorial_Logic>();
		state = 0;
	}

	private void OnDespawned()
	{
		if (tutorialLogic == null)
		{
			tutorialLogic = GameObject.Find("Tutorial Logic").GetComponent<Tutorial_Logic>();
		}
		if (state == 0)
		{
		}
	}

	private void Update()
	{
		if (pickUpScript.Obtain)
		{
			state = 1;
		}
	}
}
