using System;
using UnityEngine;

public class Menu_StatisticScreen : MonoBehaviour
{
	[Serializable]
	public class spellSprite
	{
		public tk2dTextMesh textMeshSpell;

		public tk2dAnimatedSprite spriteIcon;

		public tk2dAnimatedSprite spriteBG;
	}

	[Serializable]
	public class itemSprite
	{
		public tk2dAnimatedSprite spriteIcon;

		public tk2dAnimatedSprite spriteBG;
	}

	public int state;

	private int TOGGLE_state = -1;

	public string characterID;

	public int storyGameAttempts;

	public int storyGameVictories;

	public int storyGameDefeats;

	public int storyGameVictoryRate;

	public int challengeGameAttempts;

	public int challengeGameBestWave;

	public int challengeGameMostRetreats;

	public int challengeGameStreak;

	public int[] statSpellCasted = new int[4];

	public string[] statItemRank = new string[3];

	public tk2dTextMesh[] textMeshStory = new tk2dTextMesh[5];

	public tk2dTextMesh[] textMeshChallenge = new tk2dTextMesh[5];

	public spellSprite[] SpellSprite = new spellSprite[4];

	public itemSprite[] ItemSprite = new itemSprite[3];

	private Game_Data scriptGameData;

	private int STAT_spellTotalAmount;

	private void Start()
	{
		base.useGUILayout = false;
		scriptGameData = ScriptsManager.dataScript;
	}

	private void Update()
	{
		if (TOGGLE_state == state || !(characterID != string.Empty))
		{
			return;
		}
		storyGameAttempts = PlayerPrefs.GetInt(characterID + "statStoryAttempts");
		textMeshStory[1].text = string.Empty + storyGameAttempts;
		textMeshStory[1].Commit();
		storyGameVictories = PlayerPrefs.GetInt(characterID + "statStoryVictories");
		textMeshStory[2].text = string.Empty + storyGameVictories;
		textMeshStory[2].Commit();
		storyGameDefeats = PlayerPrefs.GetInt(characterID + "statStoryDefeats");
		textMeshStory[3].text = string.Empty + storyGameDefeats;
		textMeshStory[3].Commit();
		storyGameVictoryRate = PlayerPrefs.GetInt(characterID + "statStoryVictoryRate");
		textMeshStory[4].text = string.Empty + storyGameVictoryRate + "%";
		textMeshStory[4].Commit();
		challengeGameAttempts = PlayerPrefs.GetInt(characterID + "statChallengeAttempts");
		textMeshChallenge[1].text = string.Empty + challengeGameAttempts;
		textMeshChallenge[1].Commit();
		challengeGameBestWave = PlayerPrefs.GetInt(characterID + "bestWaveRecord0");
		textMeshChallenge[2].text = string.Empty + challengeGameBestWave;
		textMeshChallenge[2].Commit();
		challengeGameMostRetreats = PlayerPrefs.GetInt(characterID + "bestUnitRecord0");
		textMeshChallenge[3].text = string.Empty + challengeGameMostRetreats;
		textMeshChallenge[3].Commit();
		challengeGameStreak = PlayerPrefs.GetInt(characterID + "statChallengeStreak");
		textMeshChallenge[4].text = string.Empty + challengeGameStreak;
		textMeshChallenge[4].Commit();
		STAT_spellTotalAmount = PlayerPrefs.GetInt(characterID + "statSpellCasted0") + PlayerPrefs.GetInt(characterID + "statSpellCasted1") + PlayerPrefs.GetInt(characterID + "statSpellCasted2") + PlayerPrefs.GetInt(characterID + "statSpellCasted3");
		for (int i = 0; i < 4; i++)
		{
			if (STAT_spellTotalAmount > 0)
			{
				statSpellCasted[i] = Mathf.RoundToInt(PlayerPrefs.GetInt(characterID + "statSpellCasted" + i) * 100 / STAT_spellTotalAmount);
			}
			else if (STAT_spellTotalAmount == 0)
			{
				statSpellCasted[i] = 25;
			}
			SpellSprite[i].textMeshSpell.text = string.Empty + statSpellCasted[i] + "%";
			SpellSprite[i].textMeshSpell.Commit();
			switch (i)
			{
			case 0:
				SpellSprite[i].spriteIcon.Play(string.Empty + characterID + "_R_0");
				break;
			case 1:
				SpellSprite[i].spriteIcon.Play(string.Empty + characterID + "_B_0");
				break;
			case 2:
				SpellSprite[i].spriteIcon.Play(string.Empty + characterID + "_Y_0");
				break;
			case 3:
				SpellSprite[i].spriteIcon.Play(string.Empty + characterID + "_G_0");
				break;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			statItemRank[j] = PlayerPrefs.GetString(characterID + "ItemRank" + j);
			if (statItemRank[j] != "GI_none")
			{
				ItemSprite[j].spriteIcon.Play(string.Empty + statItemRank[j]);
				ItemSprite[j].spriteBG.Play("Item Icon " + statItemRank[j][3]);
			}
			else
			{
				ItemSprite[j].spriteIcon.Play("blank");
				ItemSprite[j].spriteBG.Play("Item Icon 0");
			}
		}
		if (scriptGameData.selectedCharacterLevelProgress >= 18)
		{
			textMeshStory[0].text = "complete";
			textMeshChallenge[0].text = "available";
		}
		else
		{
			textMeshStory[0].text = "incomplete";
			textMeshChallenge[0].text = "unavailable";
		}
		textMeshStory[0].Commit();
		textMeshChallenge[0].Commit();
		TOGGLE_state = state;
	}
}
