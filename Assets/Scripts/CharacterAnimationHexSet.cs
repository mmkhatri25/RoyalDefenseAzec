using UnityEngine;

public class CharacterAnimationHexSet : MonoBehaviour
{
	public int hexNumber;

	public int AnimationNumber;

	private int TOGGLE_AnimationNumber = -1;

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
		if (hexNumber == 0)
		{
			if (characterSprite.GetComponent<Renderer>().enabled)
			{
				TOGGLE_AnimationNumber = -100;
				characterSprite.GetComponent<Renderer>().enabled = false;
			}
			return;
		}
		if (!characterSprite.GetComponent<Renderer>().enabled)
		{
			characterSprite.GetComponent<Renderer>().enabled = true;
		}
		if (TOGGLE_AnimationNumber != AnimationNumber)
		{
			switch (AnimationNumber)
			{
			case -1:
				characterSprite.Play("ds" + hexNumber + "_-1");
				break;
			case 0:
				characterSprite.Play("ds" + hexNumber + "_00");
				break;
			case 1:
				characterSprite.Play("ds" + hexNumber + "_01");
				break;
			case 2:
				characterSprite.Play("ds" + hexNumber + "_01");
				break;
			case 3:
				characterSprite.Play("ds" + hexNumber + "_01");
				break;
			case 4:
				characterSprite.Play("ds" + hexNumber + "_01");
				break;
			case 5:
				characterSprite.Play("ds" + hexNumber + "_01");
				break;
			case 6:
				characterSprite.Play("ds" + hexNumber + "_00");
				break;
			case 7:
				characterSprite.Play("ds" + hexNumber + "_02");
				break;
			case 8:
				characterSprite.Play("ds" + hexNumber + "_00");
				break;
			case 9:
				characterSprite.Play("ds" + hexNumber + "_02");
				break;
			case 10:
				characterSprite.Play("ds" + hexNumber + "_03");
				break;
			case 11:
				characterSprite.Play("ds" + hexNumber + "_04");
				break;
			case 12:
				characterSprite.Play("ds" + hexNumber + "_05");
				break;
			case 13:
				characterSprite.Play("ds" + hexNumber + "_06");
				break;
			}
			TOGGLE_AnimationNumber = AnimationNumber;
		}
	}
}
