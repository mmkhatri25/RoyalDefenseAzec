using System;
using UnityEngine;

public class ScoreScreen_Control : MonoBehaviour
{
	[Serializable]
	public class rankShield
	{
		public tk2dAnimatedSprite rankShieldSprite;

		public pop_effect rankShieldPopEffect;
	}

	public int state;

	private int TOGGLE_state;

	public AudioClip[] audioClips;

	public int rankMedal;

	public int numberOfGuards;

	public int numberOfGuardsRemaining;

	public int currencyGained;

	public int wavesCompleted;

	public int newBestState;

	public int objectAverageGrade;

	public int spellAverageGrade;

	public tk2dAnimatedSprite scoreTitleSprite;

	public tk2dAnimatedSprite rankSprite;

	public pop_effect rankPopEffect;

	public rankShield[] RankShield;

	public tk2dAnimatedSprite objectAverageSprite;

	public tk2dAnimatedSprite spellAverageSprite;

	public pop_effect objectAveragePopEffect;

	public pop_effect spellAveragePopEffect;

	public tk2dTextMesh currencyText;

	public pop_effect currencyTextPopEffect;

	public pop_effect wavesCompletePopEffect;

	public tk2dAnimatedSprite wavesCompleteHundredth;

	public tk2dAnimatedSprite wavesCompleteTenth;

	public tk2dAnimatedSprite wavesCompleteOneth;

	public GameObject continueButton;

	public GameObject restartButton;

	public GameObject menuButton;

	public GameObject newBestIcon;

	public pop_effect newBestPopEffect;

	public GameObject scoreSectionTop;

	public GameObject scoreSectionBottom;

	private Vector3 VECTORON_scoreSectionTop;

	private Vector3 VECTORON_scoreSectionBottom;

	private Vector3 VECTOROFF_scoreSectionTop;

	private Vector3 VECTOROFF_scoreSectionBottom;

	private int COUNT_currencyGained;

	private float TIMER_rankShield;

	private int TOGGLE_rankShieldMaximum;

	private int TOGGLE_rankShieldRemaining;

	private string STRING_wavesComplete;

	private int HUDState;

	private float TIMER_coinSFX;

	private float DELAY_coinSFX = 0.2f;

	private int TOGGLE_HUD;

	private void Awake()
	{
		TOGGLE_state = -1;
		base.useGUILayout = false;
		base.transform.localPosition = Vector3.zero;
		VECTORON_scoreSectionTop = scoreSectionTop.transform.localPosition;
		VECTORON_scoreSectionBottom = scoreSectionBottom.transform.localPosition;
		Vector3 localPosition = scoreSectionTop.transform.localPosition;
		float x = localPosition.x;
		Vector3 localPosition2 = scoreSectionTop.transform.localPosition;
		float y = localPosition2.y + 10f;
		Vector3 localPosition3 = scoreSectionTop.transform.localPosition;
		VECTOROFF_scoreSectionTop = new Vector3(x, y, localPosition3.z);
		Vector3 localPosition4 = scoreSectionBottom.transform.localPosition;
		float x2 = localPosition4.x;
		Vector3 localPosition5 = scoreSectionBottom.transform.localPosition;
		float y2 = localPosition5.y - 10f;
		Vector3 localPosition6 = scoreSectionBottom.transform.localPosition;
		VECTOROFF_scoreSectionBottom = new Vector3(x2, y2, localPosition6.z);
	}

	private void Update()
	{
		StateFunction();
		HUDControl();
	}

	public void StateFunction(int toggleState, int rank, int maxGuards, int guardsRemaining, int currencyAmount, int wavesComplete, int toggleNewRecord, int objectGrade, int spellGrade)
	{
		rankMedal = rank;
		numberOfGuards = maxGuards;
		numberOfGuardsRemaining = guardsRemaining;
		currencyGained = currencyAmount;
		wavesCompleted = wavesComplete;
		newBestState = toggleNewRecord;
		objectAverageGrade = objectGrade;
		spellAverageGrade = spellGrade;
		state = toggleState;
	}

	private void StateFunction()
	{
		switch (state)
		{
		case 0:
			if (TOGGLE_state != state)
			{
				scoreSectionBottom.SetActiveRecursively(state: false);
				scoreSectionTop.SetActiveRecursively(state: false);
				TOGGLE_HUD = 0;
				HUDState = 0;
				TOGGLE_state = state;
			}
			break;
		case 1:
			if (TOGGLE_state != state)
			{
				scoreSectionBottom.SetActiveRecursively(state: true);
				scoreSectionTop.SetActiveRecursively(state: true);
				continueButton.SetActiveRecursively(state: true);
				scoreTitleSprite.Play("gText_0");
				objectAverageSprite.Play("blank");
				spellAverageSprite.Play("blank");
				wavesCompleteHundredth.Play("blank");
				wavesCompleteTenth.Play("blank");
				wavesCompleteOneth.Play("blank");
				COUNT_currencyGained = 0;
				currencyText.text = string.Empty;
				currencyText.Commit();
				newBestIcon.SetActiveRecursively(state: false);
				TOGGLE_HUD = 1;
				HUDState = 0;
				TOGGLE_state = state;
			}
			break;
		case 2:
			if (TOGGLE_state != state)
			{
				scoreSectionBottom.SetActiveRecursively(state: true);
				scoreSectionTop.SetActiveRecursively(state: true);
				continueButton.SetActiveRecursively(state: false);
				scoreTitleSprite.Play("gText_1");
				objectAverageSprite.Play("blank");
				spellAverageSprite.Play("blank");
				wavesCompleteHundredth.Play("blank");
				wavesCompleteTenth.Play("blank");
				wavesCompleteOneth.Play("blank");
				COUNT_currencyGained = 0;
				currencyText.text = string.Empty;
				currencyText.Commit();
				newBestIcon.SetActiveRecursively(state: false);
				TOGGLE_HUD = 1;
				HUDState = 0;
				TOGGLE_state = state;
			}
			break;
		case 3:
			if (TOGGLE_state != state)
			{
				scoreSectionBottom.SetActiveRecursively(state: true);
				scoreSectionTop.SetActiveRecursively(state: true);
				continueButton.SetActiveRecursively(state: true);
				restartButton.SetActiveRecursively(state: false);
				menuButton.SetActiveRecursively(state: false);
				scoreTitleSprite.Play("gText_0");
				objectAverageSprite.Play("blank");
				spellAverageSprite.Play("blank");
				wavesCompleteHundredth.Play("blank");
				wavesCompleteTenth.Play("blank");
				wavesCompleteOneth.Play("blank");
				COUNT_currencyGained = 0;
				currencyText.text = string.Empty;
				currencyText.Commit();
				newBestIcon.SetActiveRecursively(state: false);
				TOGGLE_HUD = 1;
				HUDState = 0;
				TOGGLE_state = state;
			}
			break;
		}
		if (state == 0)
		{
			return;
		}
		switch (HUDState)
		{
		case 0:
			for (int i = 0; i < RankShield.Length; i++)
			{
				RankShield[i].rankShieldSprite.color = Color.clear;
			}
			TOGGLE_rankShieldMaximum = 0;
			TOGGLE_rankShieldRemaining = numberOfGuardsRemaining;
			rankSprite.Play("r0");
			TIMER_rankShield = Time.time + 1.5f;
			HUDState++;
			break;
		case 1:
			if (state != 2)
			{
				if (TOGGLE_rankShieldMaximum < numberOfGuards && state != 3)
				{
					if (Time.time >= TIMER_rankShield)
					{
						if (TOGGLE_rankShieldRemaining > 0)
						{
							RankShield[TOGGLE_rankShieldMaximum].rankShieldSprite.color = Color.white;
							RankShield[TOGGLE_rankShieldMaximum].rankShieldPopEffect.activate = true;
							TOGGLE_rankShieldRemaining--;
						}
						else
						{
							RankShield[TOGGLE_rankShieldMaximum].rankShieldSprite.color = new Color(0f, 0f, 0f, 0.5f);
							RankShield[TOGGLE_rankShieldMaximum].rankShieldPopEffect.activate = true;
							TOGGLE_rankShieldRemaining--;
						}
						Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
						TOGGLE_rankShieldMaximum++;
						TIMER_rankShield = Time.time + 0.5f;
					}
				}
				else if (Time.time >= TIMER_rankShield)
				{
					rankSprite.Play("r" + rankMedal);
					rankPopEffect.activate = true;
					switch (rankMedal)
					{
					case 0:
						Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
						break;
					case 1:
						Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
						break;
					case 2:
						Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
						break;
					case 3:
						Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[3]);
						break;
					}
					TIMER_rankShield = Time.time + 0.5f;
					HUDState++;
				}
			}
			else
			{
				HUDState++;
			}
			break;
		case 2:
			if (Time.time >= TIMER_rankShield)
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
				objectAverageSprite.Play("g" + objectAverageGrade);
				spellAverageSprite.Play("g" + spellAverageGrade);
				if (wavesCompleted >= 100)
				{
					STRING_wavesComplete = string.Empty + wavesCompleted;
					wavesCompleteHundredth.Play("##" + STRING_wavesComplete[0]);
					wavesCompleteTenth.Play("##" + STRING_wavesComplete[1]);
					wavesCompleteOneth.Play("##" + STRING_wavesComplete[2]);
				}
				else if (wavesCompleted < 100 && wavesCompleted >= 10)
				{
					STRING_wavesComplete = "0" + wavesCompleted;
					wavesCompleteHundredth.Play("blank");
					wavesCompleteTenth.Play("##" + STRING_wavesComplete[1]);
					wavesCompleteOneth.Play("##" + STRING_wavesComplete[2]);
				}
				else if (wavesCompleted < 10 && wavesCompleted >= 1)
				{
					STRING_wavesComplete = "00" + wavesCompleted;
					wavesCompleteHundredth.Play("blank");
					wavesCompleteTenth.Play("blank");
					wavesCompleteOneth.Play("##" + STRING_wavesComplete[2]);
				}
				else
				{
					wavesCompleteHundredth.Play("blank");
					wavesCompleteTenth.Play("blank");
					wavesCompleteOneth.Play("##0");
				}
				objectAveragePopEffect.activate = true;
				spellAveragePopEffect.activate = true;
				wavesCompletePopEffect.activate = true;
				TIMER_rankShield = Time.time + 0.5f;
				HUDState++;
			}
			break;
		case 3:
			if (Time.time >= TIMER_rankShield)
			{
				int num = newBestState;
				if (num == 1)
				{
					newBestIcon.SetActiveRecursively(state: true);
					newBestPopEffect.activate = true;
					TIMER_rankShield = Time.time + 0.5f;
				}
				TIMER_coinSFX = Time.time;
				HUDState++;
			}
			break;
		case 4:
			if (!(Time.time >= TIMER_rankShield))
			{
				break;
			}
			if (COUNT_currencyGained < currencyGained)
			{
				if (currencyGained > 500)
				{
					COUNT_currencyGained += 3;
				}
				else if (currencyGained > 250)
				{
					COUNT_currencyGained += 2;
				}
				else
				{
					COUNT_currencyGained++;
				}
				if (Time.time >= TIMER_coinSFX)
				{
					Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[4]);
					TIMER_coinSFX = Time.time + DELAY_coinSFX;
				}
				currencyText.text = string.Empty + COUNT_currencyGained;
				currencyText.Commit();
			}
			else
			{
				Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
				currencyText.text = string.Empty + currencyGained;
				currencyText.Commit();
				currencyTextPopEffect.activate = true;
				HUDState++;
			}
			break;
		}
	}

	private void HUDControl()
	{
		switch (TOGGLE_HUD)
		{
		case 0:
			if (scoreSectionTop.transform.localPosition != VECTOROFF_scoreSectionTop || scoreSectionBottom.transform.localPosition != VECTOROFF_scoreSectionBottom)
			{
				scoreSectionTop.transform.localPosition = Vector3.Lerp(scoreSectionTop.transform.localPosition, VECTOROFF_scoreSectionTop, Time.deltaTime * 5f);
				scoreSectionBottom.transform.localPosition = Vector3.Lerp(scoreSectionBottom.transform.localPosition, VECTOROFF_scoreSectionBottom, Time.deltaTime * 5f);
			}
			break;
		case 1:
			scoreSectionTop.transform.localPosition = Vector3.Lerp(scoreSectionTop.transform.localPosition, VECTORON_scoreSectionTop, Time.deltaTime * 5f);
			scoreSectionBottom.transform.localPosition = Vector3.Lerp(scoreSectionBottom.transform.localPosition, VECTORON_scoreSectionBottom, Time.deltaTime * 5f);
			break;
		case 2:
			scoreSectionTop.transform.localPosition = Vector3.Lerp(scoreSectionTop.transform.localPosition, VECTOROFF_scoreSectionTop, Time.deltaTime * 5f);
			scoreSectionBottom.transform.localPosition = Vector3.Lerp(scoreSectionBottom.transform.localPosition, VECTOROFF_scoreSectionBottom, Time.deltaTime * 5f);
			break;
		}
	}
}
