using UnityEngine;

public class HUD_Extra : MonoBehaviour
{
	private Game_Logic scriptGameLogic;

	private Game_Statistics scriptGameStatistics;

	public AudioClip[] audioClip;

	public int readyState = -2;

	private int TOGGLE_readyState = -2;

	public bool wowActivate;

	private int TOGGLE_gameLogicWave;

	private bool wowActivated;

	public int wowAmount;

	private int TOGGLE_wowAmount;

	public GameObject wowHUD;

	public SpriteAnim_Script wowAnim;

	public pop_effect wowPopEffect;

	private float wowAmountDuration = 6f;

	private float wowTimer;

	private float wowDelay = 2f;

	private Vector3 wowOn;

	private Vector3 wowOff;

	private AudioClip wowClip;

	private int TOGGLE_gameStatisticUnit;

	public int comboAmount;

	private int TOGGLE_comboAmount;

	private float comboMetreDelay = 2f;

	private float comboMetreTimer;

	public GameObject comboMetre;

	public tk2dTextMesh comboMetreTextSprite;

	public pop_effect comboMetreTextPopUp;

	private bool comboMetreActivated;

	private Vector3 comboMetreOn;

	private Vector3 comboMetreOff;

	private void Start()
	{
		base.useGUILayout = false;
		scriptGameLogic = GameScriptsManager.gameLogicScript;
		scriptGameStatistics = GameScriptsManager.gameStatisticScript;
		comboMetreOn = comboMetre.transform.localPosition;
		comboMetreOff = new Vector3(comboMetreOn.x + 20f, comboMetreOn.y, comboMetreOn.z);
		comboMetre.transform.localPosition = comboMetreOff;
		wowOn = wowHUD.transform.localPosition;
		wowOff = new Vector3(wowOn.x - 20f, wowOn.y, wowOn.z);
		wowHUD.transform.localPosition = wowOff;
	}

	private void Update()
	{
		if (Time.timeScale != 0f && scriptGameLogic.gameMode != 1)
		{
			UnitCount();
			Combo();
			if (scriptGameLogic.gameState == 1)
			{
				Ready();
			}
			else
			{
				WOW();
			}
			return;
		}
		if (comboMetre.transform.localPosition != comboMetreOff)
		{
			comboMetre.transform.localPosition = comboMetreOff;
		}
		if (wowHUD.transform.localPosition != wowOff)
		{
			wowHUD.transform.localPosition = wowOff;
		}
	}

	private void UnitCount()
	{
		if (TOGGLE_gameStatisticUnit < scriptGameStatistics.scoreUnitDefeated)
		{
			wowAmount++;
			comboAmount++;
			TOGGLE_gameStatisticUnit++;
		}
		else if (TOGGLE_gameStatisticUnit > scriptGameStatistics.scoreUnitDefeated)
		{
			TOGGLE_gameStatisticUnit = scriptGameStatistics.gameStatusUnitSpawnNumberTeamB;
		}
	}

	private void Ready()
	{
		switch (readyState)
		{
		case -1:
			if (TOGGLE_readyState != readyState)
			{
				wowAnim.animation10 = true;
				TOGGLE_readyState = readyState;
			}
			break;
		case 0:
			if (TOGGLE_readyState != readyState)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip[0]);
				wowAnim.animation10 = true;
				wowTimer = Time.time + wowDelay;
				wowHUD.transform.localPosition = wowOn;
				wowPopEffect.activate = true;
				wowActivate = true;
				TOGGLE_readyState = readyState;
			}
			break;
		case 1:
			if (TOGGLE_readyState != readyState)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip[1]);
				wowAnim.animation9 = true;
				wowTimer = Time.time + wowDelay;
				wowHUD.transform.localPosition = wowOn;
				wowPopEffect.activate = true;
				wowActivate = true;
				TOGGLE_readyState = readyState;
			}
			break;
		case 2:
			if (TOGGLE_readyState != readyState)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip[2]);
				wowAnim.animation8 = true;
				wowTimer = Time.time + wowDelay;
				wowHUD.transform.localPosition = wowOn;
				wowPopEffect.activate = true;
				wowActivate = true;
				TOGGLE_readyState = readyState;
			}
			break;
		case 3:
			if (TOGGLE_readyState != readyState)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip[3]);
				wowAnim.animation7 = true;
				wowTimer = Time.time + wowDelay;
				wowHUD.transform.localPosition = wowOn;
				wowPopEffect.activate = true;
				wowActivate = true;
				TOGGLE_readyState = readyState;
			}
			break;
		}
		if (Time.time < wowTimer)
		{
			if (wowHUD.transform.localPosition != wowOn)
			{
				wowHUD.transform.localPosition = wowOn;
			}
		}
		else if (Time.time >= wowTimer && Time.time < wowTimer + 1f)
		{
			wowHUD.transform.localPosition = Vector3.Lerp(wowHUD.transform.localPosition, wowOff, Time.deltaTime * 5f);
		}
		else if (Time.time >= wowTimer + 1f)
		{
			wowAmount = 0;
			wowActivated = false;
			wowActivate = false;
		}
	}

	private void WOW()
	{
		if (scriptGameLogic.gameState == 2)
		{
			if (TOGGLE_gameLogicWave > scriptGameLogic.gameWaveNumber)
			{
				if (scriptGameStatistics.gameStatusUnitSpawnNumberTeamB == 0 && wowAmount >= 4)
				{
					wowActivate = true;
				}
				TOGGLE_gameLogicWave = scriptGameLogic.gameWaveNumber;
			}
			else if (TOGGLE_gameLogicWave < scriptGameLogic.gameWaveNumber)
			{
				TOGGLE_gameLogicWave = scriptGameLogic.gameWaveNumber;
			}
			if (TOGGLE_wowAmount != wowAmount && !wowActivated)
			{
				wowTimer = Time.time + wowAmountDuration;
				if (wowAmount >= 2)
				{
					if (wowAmount >= 2 && wowAmount < 4)
					{
						wowClip = audioClip[4];
						wowAnim.animation1 = true;
					}
					else if (wowAmount >= 4 && wowAmount < 6)
					{
						wowClip = audioClip[5];
						wowAnim.animation2 = true;
					}
					else if (wowAmount >= 6 && wowAmount < 8)
					{
						wowClip = audioClip[6];
						wowAnim.animation3 = true;
					}
					else if (wowAmount == 8)
					{
						wowClip = audioClip[7];
						wowAnim.animation4 = true;
					}
					else if (wowAmount == 9)
					{
						wowClip = audioClip[8];
						wowAnim.animation5 = true;
					}
					else if (wowAmount >= 10)
					{
						wowClip = audioClip[9];
						wowAnim.animation6 = true;
					}
				}
				TOGGLE_wowAmount = wowAmount;
			}
			if (wowActivate)
			{
				if (!wowActivated)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(wowClip);
					wowTimer = Time.time + wowDelay;
					wowHUD.transform.localPosition = wowOn;
					wowPopEffect.activate = true;
					wowActivated = true;
				}
				if (Time.time < wowTimer)
				{
					if (wowHUD.transform.localPosition != wowOn)
					{
						wowHUD.transform.localPosition = wowOn;
					}
				}
				else if (Time.time >= wowTimer && Time.time < wowTimer + 1f)
				{
					wowHUD.transform.localPosition = Vector3.Lerp(wowHUD.transform.localPosition, wowOff, Time.deltaTime * 5f);
				}
				else if (Time.time >= wowTimer + 1f)
				{
					wowAmount = 0;
					wowActivated = false;
					wowActivate = false;
				}
			}
			else
			{
				if (wowActivate)
				{
					wowActivate = false;
				}
				if (wowAmount > 0 && Time.time >= wowTimer)
				{
					wowAmount--;
				}
			}
		}
		else
		{
			wowAmount = 0;
			wowActivated = false;
			wowActivate = false;
			wowClip = null;
			TOGGLE_gameLogicWave = 0;
			TOGGLE_wowAmount = 0;
			Vector3 localPosition = wowHUD.transform.localPosition;
			if (localPosition.x != wowOff.x)
			{
				wowHUD.transform.localPosition = wowOff;
			}
		}
	}

	private void Combo()
	{
		if (comboAmount >= 2)
		{
			if (TOGGLE_comboAmount != comboAmount)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip[10]);
				comboMetreTimer = Time.time + comboMetreDelay;
				comboMetreTextPopUp.activate = true;
				comboMetreTextSprite.text = string.Empty + comboAmount;
				comboMetreTextSprite.Commit();
				comboMetreActivated = true;
				TOGGLE_comboAmount = comboAmount;
			}
		}
		else
		{
			if (TOGGLE_comboAmount != comboAmount)
			{
				comboMetreTimer = Time.time + 2f;
				TOGGLE_comboAmount = comboAmount;
			}
			if (Time.time >= comboMetreTimer)
			{
				comboAmount = 0;
			}
		}
		if (!comboMetreActivated)
		{
			return;
		}
		if (Time.time < comboMetreTimer)
		{
			if (comboAmount > 1)
			{
				comboMetre.transform.localPosition = Vector3.Lerp(comboMetre.transform.localPosition, comboMetreOn, Time.deltaTime * 4f);
			}
		}
		else if (Time.time >= comboMetreTimer && Time.time < comboMetreTimer + 1f)
		{
			comboMetre.transform.localPosition = Vector3.Lerp(comboMetre.transform.localPosition, comboMetreOff, Time.deltaTime * 4f);
		}
		else if (Time.time >= comboMetreTimer + 1f)
		{
			if (comboAmount <= 1 || scriptGameLogic.gameWaveTier != 1)
			{
			}
			comboMetre.transform.localPosition = comboMetreOff;
			comboAmount = 0;
			TOGGLE_comboAmount = 0;
			comboMetreActivated = false;
		}
	}
}
