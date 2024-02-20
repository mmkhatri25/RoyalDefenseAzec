using UnityEngine;

public class Unit_SummonerType : MonoBehaviour
{
	public int summonThreshold;

	public int unitSummonOffensiveNumber;

	public int unitOtherOffensiveNumber;

	private Game_Statistics scriptGameStatistic;

	private Unit_Attributes scriptUnitAttribute;

	private void Start()
	{
		base.useGUILayout = false;
		scriptGameStatistic = GameScriptsManager.gameStatisticScript;
		scriptUnitAttribute = GetComponent<Unit_Attributes>();
	}

	private void Update()
	{
		if (scriptUnitAttribute.state != 1)
		{
			return;
		}
		if (scriptGameStatistic.gameStatusUnitSpawnNumberTeamB < summonThreshold)
		{
			if (scriptUnitAttribute.unitOffenseNumber != unitSummonOffensiveNumber)
			{
				scriptUnitAttribute.unitOffenseNumber = unitSummonOffensiveNumber;
			}
		}
		else if (scriptGameStatistic.gameStatusUnitSpawnNumberTeamB >= summonThreshold && scriptUnitAttribute.unitOffenseNumber != unitOtherOffensiveNumber)
		{
			scriptUnitAttribute.unitOffenseNumber = unitOtherOffensiveNumber;
		}
	}
}
