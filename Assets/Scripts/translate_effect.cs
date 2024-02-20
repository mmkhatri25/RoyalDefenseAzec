using UnityEngine;

public class translate_effect : MonoBehaviour
{
	public int direction;

	public float translateSpeed;

	private void Start()
	{
	}

	private void Update()
	{
		switch (direction)
		{
		case 0:
			base.transform.Translate(base.transform.forward * translateSpeed * Time.deltaTime, Space.World);
			break;
		case 1:
			base.transform.Translate(base.transform.up * translateSpeed * Time.deltaTime, Space.World);
			break;
		case 2:
			base.transform.Translate(base.transform.right * translateSpeed * Time.deltaTime, Space.World);
			break;
		}
	}
}
