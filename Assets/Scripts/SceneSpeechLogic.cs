using UnityEngine;

public class SceneSpeechLogic : MonoBehaviour
{
	public string portraitLeft;

	public string portraitRight;

	public string speakerName;

	private string TOGGLE_speakerName;

	public string speakerSpeech;

	private string TOGGLE_speakerSpeech;

	public tk2dAnimatedSprite portraitLeftSprite;

	public pop_effect portraitLeftSpritePopEffet;

	private Vector3 portraitLeftSpritePosition;

	public tk2dAnimatedSprite portraitRightSprite;

	public pop_effect portraitRightSpritePopEffet;

	private Vector3 portraitRightSpritePosition;

	public GameObject speechObject;

	public tk2dTextMesh speakerNameText;

	public pop_effect speakerNamePopEffet;

	public tk2dTextMesh speakerSpeechText;

	public pop_effect speakerTextPopEffet;

	private Vector3 speechPosition;

	private Vector3 origPosition;

	private string speakerPortraitID;

	private string TOGGLE_speakerPortraitID;

	private void Start()
	{
		origPosition = base.transform.position;
		speechPosition = speechObject.transform.localPosition;
		portraitLeftSpritePosition = portraitLeftSprite.transform.localPosition;
		portraitRightSpritePosition = portraitRightSprite.transform.localPosition;
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			Vector3 position = base.transform.position;
			if (position.y < 100f)
			{
				Transform transform = base.transform;
				Vector3 position2 = base.transform.position;
				float x = position2.x;
				Vector3 position3 = base.transform.position;
				transform.position = new Vector3(x, 100f, position3.z);
			}
		}
		else
		{
			Vector3 position4 = base.transform.position;
			if (position4.y != origPosition.y)
			{
				Transform transform2 = base.transform;
				Vector3 position5 = base.transform.position;
				float x2 = position5.x;
				float y = origPosition.y;
				Vector3 position6 = base.transform.position;
				transform2.position = new Vector3(x2, y, position6.z);
			}
		}
		if (TOGGLE_speakerName != speakerName)
		{
			if (speakerName != string.Empty)
			{
				speechObject.transform.localPosition = speechPosition;
				speakerNameText.text = string.Empty + speakerName + ":";
				speakerNameText.Commit();
				speakerNamePopEffet.activate = true;
			}
			else
			{
				speakerNameText.text = string.Empty;
				speakerNameText.Commit();
				speechObject.transform.localPosition = new Vector3(-100f, -100f, -100f);
			}
			if (speakerName == "wink")
			{
				speakerPortraitID = "pp_WZ";
			}
			else if (speakerName == "king")
			{
				speakerPortraitID = "sp_king";
			}
			else if (speakerName == "blink")
			{
				speakerPortraitID = "pp_WL";
			}
			else if (speakerName == "candy")
			{
				speakerPortraitID = "pp_WT";
			}
			else if (speakerName == "sugar")
			{
				speakerPortraitID = "bi_WT_SG";
			}
			else if (speakerName == "duke")
			{
				speakerPortraitID = "bi_WZ_DK";
			}
			else
			{
				speakerPortraitID = string.Empty;
			}
			TOGGLE_speakerName = speakerName;
		}
		if (TOGGLE_speakerPortraitID != speakerPortraitID)
		{
			if (portraitLeft != string.Empty && speakerPortraitID != string.Empty)
			{
				portraitLeftSprite.transform.localPosition = portraitLeftSpritePosition;
				portraitLeftSprite.Play(string.Empty + speakerPortraitID);
				portraitLeftSpritePopEffet.activate = true;
			}
			else
			{
				portraitLeftSprite.transform.localPosition = new Vector3(-100f, -100f, -100f);
			}
			if (portraitRight != string.Empty && speakerPortraitID != string.Empty)
			{
				portraitRightSprite.transform.localPosition = portraitRightSpritePosition;
				portraitRightSprite.Play(string.Empty + speakerPortraitID);
				portraitRightSpritePopEffet.activate = true;
			}
			else
			{
				portraitRightSprite.transform.localPosition = new Vector3(-100f, -100f, -100f);
			}
			TOGGLE_speakerPortraitID = speakerPortraitID;
		}
		if (TOGGLE_speakerSpeech != speakerSpeech)
		{
			if (speakerSpeech != string.Empty)
			{
				speechObject.transform.localPosition = speechPosition;
				speakerSpeechText.text = string.Empty + speakerSpeech;
				speakerSpeechText.Commit();
				speakerTextPopEffet.activate = true;
			}
			else
			{
				speakerSpeechText.text = string.Empty;
				speakerSpeechText.Commit();
				speechObject.transform.localPosition = new Vector3(-100f, -100f, -100f);
			}
			TOGGLE_speakerSpeech = speakerSpeech;
		}
	}
}
