using UnityEngine;

public class CharacterAnimationSetFollow : MonoBehaviour
{
	public CharacterAnimationSet characterAnimationSet;

	private int TOGGLE_AnimationNumber = -1;

	private tk2dAnimatedSprite characterSprite;

	public string idleClipName = string.Empty;

	public string runForwardClipName = string.Empty;

	public string runBackwardClipName = string.Empty;

	public string walkingClipName = string.Empty;

	public string dashForwardClipName = string.Empty;

	public string dashBackwardClipName = string.Empty;

	public string readyMeleeAttackClipName = string.Empty;

	public string meleeAttackClipName = string.Empty;

	public string readyRangeAttackClipName = string.Empty;

	public string rangeAttackClipName = string.Empty;

	public string disabledClipName = string.Empty;

	public string retreatClipName = string.Empty;

	public string knockAwayClipName = string.Empty;

	public string tauntClipName = string.Empty;

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
		if (readyMeleeAttackClipName == string.Empty)
		{
			readyMeleeAttackClipName = idleClipName;
		}
		if (meleeAttackClipName == string.Empty)
		{
			meleeAttackClipName = idleClipName;
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
	}

	private void LateUpdate()
	{
		if (TOGGLE_AnimationNumber != characterAnimationSet.AnimationNumber)
		{
			switch (characterAnimationSet.AnimationNumber)
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
				characterSprite.Play(readyMeleeAttackClipName);
				break;
			case 7:
				characterSprite.Play(meleeAttackClipName);
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
			}
			TOGGLE_AnimationNumber = characterAnimationSet.AnimationNumber;
		}
	}
}
