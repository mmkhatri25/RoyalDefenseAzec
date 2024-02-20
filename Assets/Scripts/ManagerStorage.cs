using UnityEngine;

public class ManagerStorage : MonoBehaviour
{
	public string newName;

	public string parentName;

	private void Awake()
	{
		base.name = string.Empty + newName;
	}

	private void Start()
	{
		if (parentName != string.Empty)
		{
			base.transform.parent = GameObject.Find(parentName).transform;
		}
		UnityEngine.Object.Destroy(GetComponent<ManagerStorage>());
	}

	private void Update()
	{
	}
}
