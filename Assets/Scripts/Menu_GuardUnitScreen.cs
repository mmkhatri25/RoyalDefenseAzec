using UnityEngine;

public class Menu_GuardUnitScreen : MonoBehaviour
{
	public int state;

	private int TOGGLE_state;

	public Unit_Attributes unitInfo;

	public string characterID;

	public string guardName;

	public int guardNumber;

	public float[] statisticNumber = new float[6];

	public tk2dTextMesh nameTextMesh;

	public tk2dAnimatedSprite guardSprite;

	public tk2dTextMesh[] statisticTextMesh = new tk2dTextMesh[6];

	private void Start()
	{
	}

	private void Update()
	{
		if (TOGGLE_state == state)
		{
			return;
		}
		if (unitInfo != null)
		{
			guardSprite.Play(characterID);
			nameTextMesh.text = guardName;
			nameTextMesh.Commit();
			statisticNumber[0] = guardNumber;
			statisticNumber[1] = unitInfo.healthPoint;
			statisticNumber[2] = unitInfo.healthRegenPoint;
			statisticNumber[3] = unitInfo.armorPoint;
			statisticNumber[4] = unitInfo.anchorPoint;
			statisticNumber[5] = unitInfo.movementSpeedPoint;
			for (int i = 0; i < statisticTextMesh.Length; i++)
			{
				statisticTextMesh[i].text = string.Empty + statisticNumber[i];
				statisticTextMesh[i].Commit();
			}
		}
		TOGGLE_state = state;
	}
}
