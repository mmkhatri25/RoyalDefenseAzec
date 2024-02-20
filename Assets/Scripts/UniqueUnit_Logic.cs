using UnityEngine;

public class UniqueUnit_Logic : MonoBehaviour
{
	private Vector3 spawnPosition = new Vector3(6.5f, 0f, 0f);

	public GameObject unitObject;

	public float minimumTime = 50f;

	public float maximumTime = 800f;

	private float stageLength;

	private Game_Logic gameLogicScript;

	private Game_Statistics gameStatisticScript;

	private HUD_Control hudControlScript;

	public int state;

	public int TOGGLE_state;

	private float spawnTime;

	private float TIMER_spawnTimer;

	private int hintState;

	private void Start()
	{
		base.useGUILayout = false;
		stageLength = GameScriptsManager.masterControlScript.stageLength;
		spawnPosition = new Vector3(6.5f + stageLength, 0f, 0f);
		gameLogicScript = GameScriptsManager.gameLogicScript;
		gameStatisticScript = GameScriptsManager.gameStatisticScript;
		hudControlScript = GameScriptsManager.hudControlcScript;
	}

	private void Update()
	{
		if (gameLogicScript.gameState == 2 && gameStatisticScript.scoreWavesCompleted > 1 && gameLogicScript.gameLevel > 2)
		{
			state = 1;
		}
		else
		{
			state = 0;
		}
		if (gameLogicScript.gameStage >= 1 && hintState != 1 && GameScriptsManager.masterControlScript.tutorialMode == 0)
		{
			hintState = 1;
		}
		switch (state)
		{
		case 0:
			TOGGLE_state = 0;
			break;
		case 1:
			switch (TOGGLE_state)
			{
			case 0:
				TOGGLE_state++;
				break;
			case 1:
				spawnTime = UnityEngine.Random.Range(minimumTime, maximumTime) - (float)(gameLogicScript.gameLevel * 10);
				TIMER_spawnTimer = Time.time + spawnTime;
				TOGGLE_state++;
				break;
			case 2:
				if (hintState == 0 && gameLogicScript.gameStage == 0 && gameLogicScript.gameLevel == 5 && gameLogicScript.gameWaveNumber == 4)
				{
					TOGGLE_state++;
				}
				if (Time.time >= TIMER_spawnTimer)
				{
					TOGGLE_state++;
				}
				break;
			case 3:
				PoolManager.Pools["Unit Pool"].Spawn(unitObject.transform, spawnPosition, unitObject.transform.rotation);
				spawnTime = UnityEngine.Random.Range(10, 30);
				TIMER_spawnTimer = Time.time + spawnTime;
				TOGGLE_state++;
				break;
			case 4:
				if (hintState == 0)
				{
					if (gameLogicScript.gameStage == 0)
					{
						hudControlScript.hintNumber = 11;
						hudControlScript.state = 9;
					}
					hintState = 1;
				}
				if (Time.time >= TIMER_spawnTimer)
				{
					TOGGLE_state = 1;
				}
				break;
			}
			break;
		}
	}
}
