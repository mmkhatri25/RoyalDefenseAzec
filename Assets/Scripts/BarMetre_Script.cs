using UnityEngine;

public class BarMetre_Script : MonoBehaviour
{
	public float CurrentAmount = 100f;

	public float FullAmount = 100f;

	public float BarLength = 10f;

	private float amount;

	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		BarLength = localScale.x;
	}

	private void Update()
	{
		if (CurrentAmount != FullAmount)
		{
			if (FullAmount != 1f)
			{
				amount = BarLength * (CurrentAmount / (FullAmount - 1f));
			}
			else if (FullAmount == 1f)
			{
				amount = BarLength * CurrentAmount;
			}
		}
		if (CurrentAmount >= FullAmount)
		{
			CurrentAmount = FullAmount;
		}
		else if (CurrentAmount <= 0f)
		{
			CurrentAmount = 0f;
		}
		if (CurrentAmount <= 0f)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
		else if (CurrentAmount < FullAmount)
		{
			Vector3 localScale = base.transform.localScale;
			if (localScale.x <= BarLength)
			{
				base.transform.localScale = new Vector3(amount, 1f, 1f);
			}
		}
		else if (CurrentAmount >= FullAmount)
		{
			base.transform.localScale = new Vector3(BarLength, 1f, 1f);
		}
	}
}
