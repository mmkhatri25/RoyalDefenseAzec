using System;
using UnityEngine;

public class CharacterAnimationSubSet : MonoBehaviour
{
	[Serializable]
	public class offensiveClip
	{
		public string offensiveReadyClipName;

		public string offensiveActionClipName;
	}

	public int state;

	public int AnimationNumber;

	private int TOGGLE_AnimationNumber = -1;

	public int OffenseNumber;

	private int TOGGLE_OffenseNumber = -1;

	public offensiveClip[] OffensiveClip;

	private tk2dAnimatedSprite characterSprite;

	public string idleClipName = string.Empty;

	public string runForwardClipName = string.Empty;

	public string runBackwardClipName = string.Empty;

	public string walkingClipName = string.Empty;

	public string dashForwardClipName = string.Empty;

	public string dashBackwardClipName = string.Empty;

	private string offensiveReadyClipName = string.Empty;

	private string offensiveActionClipName = string.Empty;

	private string readyRangeAttackClipName = string.Empty;

	private string rangeAttackClipName = string.Empty;

	public string disabledClipName = string.Empty;

	public string retreatClipName = string.Empty;

	public string knockAwayClipName = string.Empty;

	public string tauntClipName = string.Empty;

	public string guardClipName = string.Empty;

	private void Awake()
	{
		base.useGUILayout = false;
		characterSprite = GetComponent<tk2dAnimatedSprite>();
	}

	private void Start()
	{
		if (runForwardClipName == string.Empty)
		{
			runForwardClipName = idleClipName;
		}
		if (runBackwardClipName == string.Empty)
		{
			runBackwardClipName = runForwardClipName;
		}
		if (walkingClipName == string.Empty)
		{
			walkingClipName = runForwardClipName;
		}
		if (dashForwardClipName == string.Empty)
		{
			dashForwardClipName = idleClipName;
		}
		if (dashBackwardClipName == string.Empty)
		{
			dashBackwardClipName = idleClipName;
		}
		if (offensiveReadyClipName == string.Empty)
		{
			offensiveReadyClipName = idleClipName;
		}
		if (offensiveActionClipName == string.Empty)
		{
			offensiveActionClipName = idleClipName;
		}
		if (readyRangeAttackClipName == string.Empty)
		{
			readyRangeAttackClipName = idleClipName;
		}
		if (rangeAttackClipName == string.Empty)
		{
			rangeAttackClipName = idleClipName;
		}
		if (disabledClipName == string.Empty)
		{
			disabledClipName = idleClipName;
		}
		if (retreatClipName == string.Empty)
		{
			retreatClipName = idleClipName;
		}
		if (knockAwayClipName == string.Empty)
		{
			knockAwayClipName = retreatClipName;
		}
		if (tauntClipName == string.Empty)
		{
			tauntClipName = idleClipName;
		}
		if (guardClipName == string.Empty)
		{
			guardClipName = idleClipName;
		}
	}

	private void Update()
	{
		if (state == 0)
		{
			if (!characterSprite.GetComponent<Renderer>().enabled)
			{
				characterSprite.GetComponent<Renderer>().enabled = true;
			}
			if (TOGGLE_AnimationNumber != AnimationNumber)
			{
				switch (AnimationNumber)
				{
				case -1:
					characterSprite.Play(tauntClipName);
					break;
				case 0:
					characterSprite.Play(idleClipName);
					break;
				case 1:
					characterSprite.Play(runForwardClipName);
					break;
				case 2:
					characterSprite.Play(runBackwardClipName);
					break;
				case 3:
					characterSprite.Play(walkingClipName);
					break;
				case 4:
					characterSprite.Play(dashForwardClipName);
					break;
				case 5:
					characterSprite.Play(dashBackwardClipName);
					break;
				case 6:
					characterSprite.Play(offensiveReadyClipName);
					break;
				case 7:
					characterSprite.Play(offensiveActionClipName);
					break;
				case 8:
					characterSprite.Play(readyRangeAttackClipName);
					break;
				case 9:
					characterSprite.Play(rangeAttackClipName);
					break;
				case 10:
					characterSprite.Play(disabledClipName);
					break;
				case 11:
					characterSprite.Play(retreatClipName);
					break;
				case 12:
					characterSprite.Play(knockAwayClipName);
					break;
				case 13:
					characterSprite.Play(guardClipName);
					break;
				}
				TOGGLE_AnimationNumber = AnimationNumber;
			}
			if (TOGGLE_OffenseNumber == OffenseNumber)
			{
				return;
			}
			if (OffensiveClip.Length > 0)
			{
				if (OffensiveClip.Length - 1 >= OffenseNumber)
				{
					if (OffensiveClip[OffenseNumber].offensiveReadyClipName != string.Empty)
					{
						offensiveReadyClipName = OffensiveClip[OffenseNumber].offensiveReadyClipName;
					}
					else
					{
						offensiveReadyClipName = idleClipName;
					}
					if (OffensiveClip[OffenseNumber].offensiveActionClipName != string.Empty)
					{
						offensiveActionClipName = OffensiveClip[OffenseNumber].offensiveActionClipName;
					}
					else
					{
						offensiveActionClipName = idleClipName;
					}
				}
			}
			else
			{
				offensiveReadyClipName = "blank";
				offensiveActionClipName = "blank";
			}
			TOGGLE_OffenseNumber = OffenseNumber;
		}
		else if (state == 1 && characterSprite.GetComponent<Renderer>().enabled)
		{
			TOGGLE_AnimationNumber = -100;
			TOGGLE_OffenseNumber = -100;
			characterSprite.GetComponent<Renderer>().enabled = false;
		}
	}
}
