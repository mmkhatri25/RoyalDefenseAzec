using UnityEngine;

public class instantiate_Break_Effect : MonoBehaviour
{
	public GameObject[] inst;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
		Break();
	}

	private void Break()
	{
		for (int i = 0; i < inst.Length; i++)
		{
			if (i >= inst.Length)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			Object.Instantiate(inst[i], base.transform.position, inst[i].transform.rotation);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
