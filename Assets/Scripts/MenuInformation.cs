using UnityEngine;

public class MenuInformation : MonoBehaviour
{
	public int informationType;

	public int informationNumber;

	private int TOGGLE_informationType = -1;

	private int TOGGLE_informationNumber = -1;

	public GameObject background;

	public GameObject informationPopUp;

	public tk2dTextMesh informationTitle;

	public tk2dTextMesh informationText;

	public pop_effect informationPopEffect;

	public tk2dAnimatedSprite informationImageSprite;

	public GameObject unlockPopUp;

	public tk2dTextMesh unlockTitle;

	public tk2dTextMesh unlockText;

	public pop_effect unlockPopEffect;

	public tk2dAnimatedSprite unlockImageSprite;

	public AudioClip soundNormalClip;

	public AudioClip soundUnlockClip;

	private void Start()
	{
	}

	private void Update()
	{
		if (TOGGLE_informationType != informationType)
		{
			switch (informationType)
			{
			case 0:
				unlockPopUp.SetActiveRecursively(state: false);
				informationPopUp.SetActiveRecursively(state: false);
				background.SetActiveRecursively(state: false);
				break;
			case 1:
				unlockPopUp.SetActiveRecursively(state: false);
				informationPopUp.SetActiveRecursively(state: true);
				background.SetActiveRecursively(state: true);
				informationPopEffect.activate = true;
				break;
			case 2:
				unlockPopUp.SetActiveRecursively(state: true);
				informationPopUp.SetActiveRecursively(state: false);
				background.SetActiveRecursively(state: true);
				unlockPopEffect.activate = true;
				break;
			}
			switch (informationType)
			{
			case 1:
				Camera.main.GetComponent<AudioSource>().PlayOneShot(soundNormalClip);
				InformationText();
				informationImageSprite.Play("ii_1_" + informationNumber);
				informationTitle.Commit();
				informationText.Commit();
				informationPopEffect.activate = true;
				break;
			case 2:
				Camera.main.GetComponent<AudioSource>().PlayOneShot(soundUnlockClip);
				UnlockText();
				unlockImageSprite.Play("ii_2_" + informationNumber);
				unlockTitle.Commit();
				unlockText.Commit();
				unlockPopEffect.activate = true;
				break;
			}
			TOGGLE_informationNumber = informationNumber;
			TOGGLE_informationType = informationType;
		}
		if (TOGGLE_informationNumber != informationNumber)
		{
			switch (informationType)
			{
			case 1:
				InformationText();
				informationImageSprite.Play("ii_1_" + informationNumber);
				informationTitle.Commit();
				informationText.Commit();
				informationPopEffect.activate = true;
				break;
			case 2:
				UnlockText();
				unlockImageSprite.Play("ii_2_" + informationNumber);
				unlockTitle.Commit();
				unlockText.Commit();
				unlockPopEffect.activate = true;
				break;
			}
			TOGGLE_informationNumber = informationNumber;
		}
	}

	private void InformationText()
	{
		switch (informationNumber)
		{
		case 0:
			informationImageSprite.scale = new Vector3(1.2f, 1.2f, 1.2f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 320f));
			informationTitle.text = "\n\n\nwelcome to the library";
			informationText.text = "here, you will be able to view and play \ndifferent books once unlocked.";
			break;
		case 1:
			informationImageSprite.scale = new Vector3(2.2f, 2.2f, 2.2f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 320f));
			informationTitle.text = "\n\njinx keys";
			informationText.text = "jinx key are used to unlock books.\na jinx key can be obtained by completing a book's story.";
			break;
		case 2:
			informationImageSprite.scale = new Vector3(2.2f, 2.2f, 2.2f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			informationTitle.text = "tutorial turned on";
			informationText.text = "tutorial applies to all characters.\n\n- tips turned on.\n- first stage handicap turned on.\n- limited shop availability.";
			break;
		case 3:
			informationImageSprite.scale = new Vector3(2.6f, 2.6f, 2.6f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			informationTitle.text = "philosophy of magic:\nbalance";
			informationText.text = "magic users that study under balance believe\nmagic is to help balance society. magic users \nstudying this trait are verstilite with their\nmagics with decent draw backs like mana cost or \ncool downs but they excel at no focused area.";
			break;
		case 4:
			informationImageSprite.scale = new Vector3(2.6f, 2.6f, 2.6f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			informationTitle.text = "philosophy of magic:\nwild";
			informationText.text = "magic users that follow wild think nothing of\nmagic. these magic users are wild and untamed\nin use of magic making their magic abilities\nweak and uneffectient but costing very\nlittle mana and almost no cool down.";
			break;
		case 5:
			informationImageSprite.scale = new Vector3(2.6f, 2.6f, 2.6f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			informationTitle.text = "philosophy of magic:\nguardian";
			informationText.text = "magic users that follow guardians believe magic\nis gifted to them to protect others. these magic\nusers have strong defensive magic but very\nlittle to almost none when it comes damages\nwith their magic.";
			break;
		case 6:
			informationImageSprite.scale = new Vector3(2.6f, 2.6f, 2.6f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			informationTitle.text = "philosophy of magic:\npower";
			informationText.text = "magic users that follow power believes magic\nusers are superior beings to others. power\nfollowers focus their magic to be very high on \ndamage but lack efficenty when it comes to \nother areas like defense or draw backs.";
			break;
		case 7:
			informationImageSprite.scale = new Vector3(2.6f, 2.6f, 2.6f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			informationTitle.text = "philosophy of magic:\nefficiency";
			informationText.text = "magic users that follow efficiency believes magic\nis a gifted talent. these users focus their\nmagic solely as life long art and craftsmanship.\nusers that understand this trait have very effective\nmagic effects and area control.";
			break;
		case 8:
			informationImageSprite.scale = new Vector3(2.6f, 2.6f, 2.6f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			informationTitle.text = "philosophy of magic:\nutility";
			informationText.text = "magic users that study utility use magic as a\nway of connecting with others. either charming,\nenchanting, or controlling, these users focus\nhighly on summons, buffers, and aura effects \nas their main magic.";
			break;
		case 9:
			informationImageSprite.scale = new Vector3(2.6f, 2.6f, 2.6f);
			informationImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			informationTitle.text = "congratulations!";
			informationText.text = "magic users that study utility use magic as a\nway of connecting with others. either charming,\nenchanting, or controlling, these users focuses\nhighly on summons, buffers, and aura effects \nas their main magic.";
			break;
		}
	}

	private void UnlockText()
	{
		switch (informationNumber)
		{
		case 0:
			unlockImageSprite.scale = new Vector3(2.2f, 2.2f, 2.2f);
			unlockImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			unlockTitle.text = "arena mode unlock";
			unlockText.text = "congratulation!\narena mode is now available for this book";
			break;
		case 1:
			unlockImageSprite.scale = new Vector3(2.2f, 2.2f, 2.2f);
			unlockImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 320f));
			unlockTitle.text = "jinx key";
			unlockText.text = "congratulations!\nyou have obtained a jinx key";
			break;
		case 2:
			unlockImageSprite.scale = new Vector3(1.2f, 1.2f, 1.2f);
			unlockImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 45f));
			unlockTitle.text = "new book";
			unlockText.text = "congratulations!\nthe next book can be now unlocked";
			break;
		case 3:
			unlockImageSprite.scale = new Vector3(2.2f, 2.2f, 2.2f);
			unlockImageSprite.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			unlockTitle.text = "congratulations!";
			unlockText.text = "all books are complete!\n";
			break;
		}
	}
}
