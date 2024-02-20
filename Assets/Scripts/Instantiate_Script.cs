using UnityEngine;

public class Instantiate_Script : MonoBehaviour
{
	public string poolName;

	public GameObject instantiate;

	private GameObject instantiate2;

	public bool Repeat;

	public bool random;

	public float randomMaxTime = 80f;

	private float randomTime;

	private bool randomed;

	public float instantiateTime = 1000f;

	private float timer;

	private void Start()
	{
	}

	private void Update()
	{
		if (!random)
		{
			return;
		}
		if (!randomed)
		{
			randomTime = UnityEngine.Random.Range(0f, randomMaxTime);
			randomed = true;
		}
		else
		{
			if (!randomed)
			{
				return;
			}
			if (timer < randomTime)
			{
				timer += 0.1f;
			}
			else if (timer >= randomTime)
			{
				PoolManager.Pools[poolName].Spawn(instantiate.transform, base.transform.position, base.transform.rotation);
				if (Repeat)
				{
					timer = 0f;
					randomed = false;
				}
				else
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}
}
