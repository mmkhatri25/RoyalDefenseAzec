using UnityEngine;

public class itemtest : MonoBehaviour
{
	public int gold;

	public int silver;

	public int bronze;

	public int levels;

	public int completion;

	public int goldx;

	public int silverx;

	public int bronzex;

	private void Start()
	{
	}

	private void Update()
	{
		goldx = gold * 3;
		silverx = silver * 2;
		bronzex = bronze * 1;
		completion = Mathf.RoundToInt((float)(gold * 3 + silver * 2 + bronze) * 100f) / levels;
	}
}
