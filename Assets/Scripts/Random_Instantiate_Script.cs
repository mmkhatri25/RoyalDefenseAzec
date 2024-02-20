using UnityEngine;

public class Random_Instantiate_Script : MonoBehaviour
{
	public int activateType;

	public int activate;

	public float RandomValue;

	public float chanceValue;

	private float chanceValue_Common;

	private float chanceValue_Uncommon;

	private float chanceValue_Rear;

	private int TOGGLE_chanceValue;

	public GameObject[] commonDrops;

	public GameObject[] uncommonDrops;

	public GameObject[] rearDrops;

	private int randomPickUp;

	private Game_Statistics scriptGameStatistic;

	private void Start()
	{
		scriptGameStatistic = GameScriptsManager.gameStatisticScript;
	}

	private void OnDespawned()
	{
		switch (activateType)
		{
		case 0:
			RandomValue = 0f;
			activate = 0;
			break;
		case 1:
			RandomValue = 0f;
			activate = 1;
			break;
		}
	}

	private void OnSpawned()
	{
		switch (activateType)
		{
		case 0:
			RandomValue = 0f;
			activate = 0;
			break;
		case 1:
			RandomValue = 0f;
			activate = 1;
			break;
		}
	}

	public void DropSetup(int Toggle, float dropChance)
	{
		switch (Toggle)
		{
		case 0:
			PoolManager.Pools["Pickup Pool"].Despawn(base.transform);
			break;
		case 1:
			chanceValue = dropChance;
			activate = 1;
			break;
		}
	}

	private void LateUpdate()
	{
		switch (activate)
		{
		case 0:
			break;
		case 1:
			if (scriptGameStatistic.manaNumber <= 10)
			{
				chanceValue += 40f;
			}
			else if (scriptGameStatistic.manaNumber > 10 && scriptGameStatistic.manaNumber <= 40)
			{
				chanceValue += 30f;
			}
			else if (scriptGameStatistic.manaNumber > 40 && scriptGameStatistic.manaNumber <= 60)
			{
				chanceValue += 15f;
			}
			else if (scriptGameStatistic.manaNumber > 60 && scriptGameStatistic.manaNumber <= 80)
			{
				chanceValue += 10f;
			}
			chanceValue_Common = chanceValue;
			chanceValue_Uncommon = chanceValue / 2f;
			chanceValue_Rear = chanceValue / 2f / 4f;
			RandomValue = UnityEngine.Random.Range(0, 100);
			activate = 2;
			break;
		case 2:
			if (RandomValue <= chanceValue_Common && RandomValue > chanceValue_Uncommon)
			{
				TOGGLE_chanceValue = 1;
				randomPickUp = UnityEngine.Random.Range(0, commonDrops.Length);
			}
			else if (RandomValue <= chanceValue_Uncommon && RandomValue > chanceValue_Rear)
			{
				TOGGLE_chanceValue = 2;
				randomPickUp = UnityEngine.Random.Range(0, uncommonDrops.Length);
			}
			else if (RandomValue <= chanceValue_Rear)
			{
				TOGGLE_chanceValue = 3;
				randomPickUp = UnityEngine.Random.Range(0, rearDrops.Length);
			}
			else if (RandomValue > chanceValue_Common)
			{
				TOGGLE_chanceValue = 0;
			}
			activate = 3;
			break;
		case 3:
			switch (TOGGLE_chanceValue)
			{
			case 1:
				if (commonDrops[randomPickUp] != null)
				{
					PoolManager.Pools["Pickup Pool"].Spawn(commonDrops[randomPickUp].transform, base.transform.position, base.transform.rotation);
				}
				break;
			case 2:
				if (uncommonDrops[randomPickUp] != null)
				{
					PoolManager.Pools["Pickup Pool"].Spawn(uncommonDrops[randomPickUp].transform, base.transform.position, base.transform.rotation);
				}
				break;
			case 3:
				if (rearDrops[randomPickUp] != null)
				{
					PoolManager.Pools["Pickup Pool"].Spawn(rearDrops[randomPickUp].transform, base.transform.position, base.transform.rotation);
				}
				break;
			}
			activate = 4;
			break;
		case 4:
			PoolManager.Pools["Pickup Pool"].Despawn(base.transform);
			break;
		}
	}
}
