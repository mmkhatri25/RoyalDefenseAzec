using UnityEngine;

public class characterUnlockIndicator : MonoBehaviour
{
	public tk2dAnimatedSprite[] indicator = new tk2dAnimatedSprite[2];

	private void Start()
	{
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("WZnextBookUnlock") == 1 && PlayerPrefs.GetInt("WLLOCK") == 0)
		{
			if (!indicator[0].GetComponent<Renderer>().enabled)
			{
				indicator[0].GetComponent<Renderer>().enabled = true;
			}
		}
		else if (indicator[0].GetComponent<Renderer>().enabled)
		{
			indicator[0].GetComponent<Renderer>().enabled = false;
		}
		if (PlayerPrefs.GetInt("WLnextBookUnlock") == 1 && PlayerPrefs.GetInt("WTLOCK") == 0)
		{
			if (!indicator[1].GetComponent<Renderer>().enabled)
			{
				indicator[1].GetComponent<Renderer>().enabled = true;
			}
		}
		else if (indicator[1].GetComponent<Renderer>().enabled)
		{
			indicator[1].GetComponent<Renderer>().enabled = false;
		}
	}
}
