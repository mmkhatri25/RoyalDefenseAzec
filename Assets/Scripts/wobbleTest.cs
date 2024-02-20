using UnityEngine;

public class wobbleTest : MonoBehaviour
{
	private int direction;

	public float rotationSpeed = 0.2f;

	public float rotationThreshold = 0.05f;

	private void Start()
	{
	}

	private void Update()
	{
		if (direction == 0)
		{
			Quaternion localRotation = base.transform.localRotation;
			if (localRotation.z > 0f - rotationThreshold)
			{
				base.transform.Rotate(0f, 0f, 0f - rotationSpeed);
				return;
			}
			Quaternion localRotation2 = base.transform.localRotation;
			if (localRotation2.z <= 0f - rotationThreshold)
			{
				direction = 1;
			}
		}
		else
		{
			if (direction != 1)
			{
				return;
			}
			Quaternion localRotation3 = base.transform.localRotation;
			if (localRotation3.z < rotationThreshold)
			{
				base.transform.Rotate(0f, 0f, rotationSpeed);
				return;
			}
			Quaternion localRotation4 = base.transform.localRotation;
			if (localRotation4.z >= rotationThreshold)
			{
				direction = 0;
			}
		}
	}
}
