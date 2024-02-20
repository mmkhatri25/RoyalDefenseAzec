using UnityEngine;

public class pop_effect : MonoBehaviour
{
	public int activateType;

	public bool activate;

	private bool activating;

	private bool pop;

	public float regularScale = 1f;

	public float expandScale = 2f;

	public float expandSpeed = 0.1f;

	private Transform myTransfrom;

	private int state;

	private void Start()
	{
		myTransfrom = base.transform;
		if (activateType == 1)
		{
			expandSpeed *= 2f;
		}
	}

	private void OnDespawned()
	{
		activate = false;
		activating = false;
	}

	private void OnSpawned()
	{
		activate = true;
		activating = false;
	}

	private void LateUpdate()
	{
		if (activateType != 1)
		{
			return;
		}
		if (activate)
		{
			if (!activating)
			{
				myTransfrom.localScale = new Vector3(regularScale, regularScale, regularScale);
				pop = true;
				state = 1;
				activating = true;
			}
			activate = false;
		}
		else if (activating)
		{
			activating = false;
		}
		int num = state;
		if (num != 1)
		{
			return;
		}
		if (pop)
		{
			Vector3 localScale = myTransfrom.localScale;
			if (localScale.x < regularScale * expandScale)
			{
				myTransfrom.localScale += new Vector3(expandSpeed, expandSpeed, expandSpeed);
				return;
			}
			Vector3 localScale2 = myTransfrom.localScale;
			if (localScale2.x >= regularScale * expandScale)
			{
				pop = false;
			}
		}
		else
		{
			if (pop)
			{
				return;
			}
			Vector3 localScale3 = myTransfrom.localScale;
			if (localScale3.x > regularScale)
			{
				myTransfrom.localScale += new Vector3(0f - expandSpeed, 0f - expandSpeed, 0f - expandSpeed);
				return;
			}
			Vector3 localScale4 = myTransfrom.localScale;
			if (localScale4.x <= regularScale)
			{
				myTransfrom.localScale = new Vector3(regularScale, regularScale, regularScale);
				state = 0;
			}
		}
	}

	private void Update()
	{
		if (activateType != 0)
		{
			return;
		}
		if (activate)
		{
			if (!activating)
			{
				myTransfrom.localScale = new Vector3(regularScale, regularScale, regularScale);
				pop = true;
				state = 1;
				activating = true;
			}
			activate = false;
		}
		else if (activating)
		{
			activating = false;
		}
		int num = state;
		if (num != 1)
		{
			return;
		}
		if (pop)
		{
			Vector3 localScale = myTransfrom.localScale;
			if (localScale.x < regularScale * expandScale)
			{
				myTransfrom.localScale += new Vector3(expandSpeed * Time.timeScale, expandSpeed * Time.timeScale, expandSpeed * Time.timeScale);
				return;
			}
			Vector3 localScale2 = myTransfrom.localScale;
			if (localScale2.x >= regularScale * expandScale)
			{
				pop = false;
			}
		}
		else
		{
			if (pop)
			{
				return;
			}
			Vector3 localScale3 = myTransfrom.localScale;
			if (localScale3.x > regularScale)
			{
				myTransfrom.localScale += new Vector3((0f - expandSpeed) * Time.timeScale, (0f - expandSpeed) * Time.timeScale, (0f - expandSpeed) * Time.timeScale);
				return;
			}
			Vector3 localScale4 = myTransfrom.localScale;
			if (localScale4.x <= regularScale)
			{
				myTransfrom.localScale = new Vector3(regularScale, regularScale, regularScale);
				state = 0;
			}
		}
	}
}
