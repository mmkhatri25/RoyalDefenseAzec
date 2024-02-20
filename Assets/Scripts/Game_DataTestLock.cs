using UnityEngine;

public class Game_DataTestLock : MonoBehaviour
{
	public string lockID;

	public int lockToggle;

	public string resetID;

	public int resetToggle;

	public int currencyAmount;

	public Game_Data data;

	private void Start()
	{
	}

	private void Update()
	{
		switch (lockToggle)
		{
		case 1:
			data.characterUnlock(lockID);
			lockToggle = 0;
			break;
		case 2:
			data.characterLock(lockID);
			lockToggle = 0;
			break;
		}
		int num = resetToggle;
		if (num == 1)
		{
			data.CharacterDataErase(resetID, 1);
			resetToggle = 0;
		}
		if (currencyAmount != 0)
		{
			data.PlayerCurrency(currencyAmount);
			currencyAmount = 0;
		}
	}
}
