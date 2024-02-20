using UnityEngine;

public class ScriptsManager : MonoBehaviour
{
	public static Music_Script gameMusicScript;

	public static Game_Data dataScript;

	public static Content_Data contentDataScript;

	public static Stage_Control stageControlScript;

	public static level_setup levelSetupScript;

	public static Item_Content_Data itemContentDataScript;

	public static Object_Logic objectLogicScript;

	public static GameObject playerCharacter;

	public GameObject gameCharacter;

	public static AudioClip[] audioClip = new AudioClip[10];

	private void Start()
	{
		base.useGUILayout = false;
	}

	private void Update()
	{
		if (playerCharacter == null)
		{
			playerCharacter = GameObject.Find("Player Character");
			return;
		}
		if (!playerCharacter.active)
		{
			playerCharacter = GameObject.Find("Player Character");
		}
		gameCharacter = playerCharacter;
	}
}
