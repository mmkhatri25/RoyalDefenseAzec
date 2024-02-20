using UnityEngine;

public class Enemy_AnimationSet : MonoBehaviour
{
	private tk2dAnimatedSprite anim;

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

	public bool AnimationTaunt;

	private bool AnimationTauntX;

	public bool AnimationIdle;

	private bool AnimationIdleX;

	public bool AnimationRunForward;

	private bool AnimationRunForwardX;

	public bool AnimationRunBackward;

	private bool AnimationRunBackwardX;

	public bool AnimationWalking;

	private bool AnimationWalkingX;

	public bool AnimationDashForward;

	private bool AnimationDashForwardX;

	public bool AnimationDashBackward;

	private bool AnimationDashBackwardX;

	public bool AnimationReadyMeleeAttack;

	private bool AnimationReadyMeleeAttackX;

	public bool AnimationMeleeAttack;

	private bool AnimationMeleeAttackX;

	public bool AnimationReadyRangeAttack;

	private bool AnimationReadyRangeAttackX;

	public bool AnimationRangeAttack;

	private bool AnimationRangeAttackX;

	public bool AnimationDisabled;

	private bool AnimationDisabledX;

	public bool AnimationRetreat;

	private bool AnimationRetreatX;

	public bool AnimationKnockAway;

	private bool AnimationKnockAwayX;

	private void Awake()
	{
		anim = GetComponent<tk2dAnimatedSprite>();
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

	private void Update()
	{
		if (AnimationTaunt)
		{
			if (!AnimationTauntX)
			{
				anim.Play(tauntClipName);
				AnimationTauntX = true;
			}
			AnimationTaunt = false;
		}
		else
		{
			AnimationTauntX = false;
		}
		if (AnimationIdle)
		{
			if (!AnimationIdleX)
			{
				anim.Play(idleClipName);
				AnimationIdleX = true;
			}
			AnimationIdle = false;
		}
		else
		{
			AnimationIdleX = false;
		}
		if (AnimationRunForward)
		{
			if (!AnimationRunForwardX)
			{
				anim.Play(runForwardClipName);
				AnimationRunForwardX = true;
			}
			AnimationRunForward = false;
		}
		else
		{
			AnimationRunForwardX = false;
		}
		if (AnimationRunBackward)
		{
			if (!AnimationRunBackwardX)
			{
				anim.Play(runBackwardClipName);
				AnimationRunBackwardX = true;
			}
			AnimationRunBackward = false;
		}
		else
		{
			AnimationRunBackwardX = false;
		}
		if (AnimationWalking)
		{
			if (!AnimationWalkingX)
			{
				anim.Play(walkingClipName);
				AnimationWalkingX = true;
			}
			AnimationWalking = false;
		}
		else
		{
			AnimationWalkingX = false;
		}
		if (AnimationReadyMeleeAttack)
		{
			if (!AnimationReadyMeleeAttackX)
			{
				anim.Play(readyMeleeAttackClipName);
				AnimationReadyMeleeAttackX = true;
			}
			AnimationReadyMeleeAttack = false;
		}
		else
		{
			AnimationReadyMeleeAttackX = false;
		}
		if (AnimationReadyRangeAttack)
		{
			if (!AnimationReadyRangeAttackX)
			{
				anim.Play(readyRangeAttackClipName);
				AnimationReadyRangeAttackX = true;
			}
			AnimationReadyRangeAttack = false;
		}
		else
		{
			AnimationReadyRangeAttackX = false;
		}
		if (AnimationMeleeAttack)
		{
			if (!AnimationMeleeAttackX)
			{
				anim.Play(meleeAttackClipName);
				AnimationMeleeAttackX = true;
			}
			AnimationMeleeAttack = false;
		}
		else
		{
			AnimationMeleeAttackX = false;
		}
		if (AnimationRangeAttack)
		{
			if (!AnimationRangeAttackX)
			{
				anim.Play(rangeAttackClipName);
				AnimationRangeAttackX = true;
				AnimationRangeAttack = false;
			}
			AnimationRangeAttack = false;
		}
		else
		{
			AnimationRangeAttackX = false;
		}
		if (AnimationDashForward)
		{
			if (!AnimationDashForwardX)
			{
				anim.Play(dashForwardClipName);
				AnimationDashForwardX = true;
			}
			AnimationDashForward = false;
		}
		else
		{
			AnimationDashForwardX = false;
		}
		if (AnimationDashBackward)
		{
			if (!AnimationDashBackwardX)
			{
				anim.Play(dashBackwardClipName);
				AnimationDashBackwardX = true;
			}
			AnimationDashBackward = false;
		}
		else
		{
			AnimationDashBackwardX = false;
		}
		if (AnimationDisabled)
		{
			if (!AnimationDisabledX)
			{
				anim.Play(disabledClipName);
				AnimationDisabledX = true;
			}
			AnimationDisabled = false;
		}
		else
		{
			AnimationDisabledX = false;
		}
		if (AnimationRetreat)
		{
			if (!AnimationRetreatX)
			{
				anim.Play(retreatClipName);
				AnimationRetreatX = true;
			}
			AnimationRetreat = false;
		}
		else
		{
			AnimationRetreatX = false;
		}
		if (AnimationKnockAway)
		{
			if (!AnimationKnockAwayX)
			{
				anim.Play(knockAwayClipName);
				AnimationKnockAwayX = true;
			}
			AnimationKnockAway = false;
		}
		else
		{
			AnimationKnockAwayX = false;
		}
	}
}
