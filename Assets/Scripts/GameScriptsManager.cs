using UnityEngine;

public class GameScriptsManager : MonoBehaviour
{
	public static int loading;

	public GameMasterScriptsControl scriptMasterControl;

	public Game_Logic scriptGameLogic;

	public HUD_Control scriptHudControl;

	public Camera_Control scriptCameraControl;

	public Guard_Logic scriptGuardLogic;

	public Game_Statistics scriptGameStatistic;

	public Statistic_Logic scriptStatisticLogic;

	public Camera_Shake scriptCameraShake;

	public Item_Control scriptItemControl;

	public Spell_Logic scriptSpellLogic;

	public AudioSource AudioSourceA;

	public AudioSource AudioSourceB;

	public AudioSource AudioSourceC;

	public static GameMasterScriptsControl masterControlScript;

	public static Game_Logic gameLogicScript;

	public static HUD_Control hudControlcScript;

	public static Camera_Control cameraControlScript;

	public static Guard_Logic guardLogicScript;

	public static Game_Statistics gameStatisticScript;

	public static Statistic_Logic statisticLogicScript;

	public static Camera_Shake cameraShakeScript;

	public static Item_Control itemControlScript;

	public static Spell_Logic spellLogicScript;

	public static AudioSource audioSourceA;

	public static AudioSource audioSourceB;

	public static AudioSource audioSourceC;

	private void Awake()
	{
		base.useGUILayout = false;
		loading = 0;
		masterControlScript = scriptMasterControl;
		gameLogicScript = scriptGameLogic;
		hudControlcScript = scriptHudControl;
		cameraControlScript = scriptCameraControl;
		guardLogicScript = scriptGuardLogic;
		gameStatisticScript = scriptGameStatistic;
		statisticLogicScript = scriptStatisticLogic;
		cameraShakeScript = scriptCameraShake;
		itemControlScript = scriptItemControl;
		spellLogicScript = scriptSpellLogic;
		audioSourceA = AudioSourceA;
		audioSourceB = AudioSourceB;
		audioSourceC = AudioSourceC;
	}

	private void Update()
	{
		if (scriptGuardLogic == null && guardLogicScript != null)
		{
			scriptGuardLogic = guardLogicScript;
		}
	}
}
