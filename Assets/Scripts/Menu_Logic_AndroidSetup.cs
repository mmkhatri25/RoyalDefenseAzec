using UnityEngine;

public class Menu_Logic_AndroidSetup : MonoBehaviour
{
	public Transform btn_soundButton;

	public Transform btn_rateButton;

	public Transform[] btn_arenaButton = new Transform[2];

	public GameObject[] disable_Buttons;

	private void Start()
	{
		for (int i = 0; i < disable_Buttons.Length; i++)
		{
			disable_Buttons[i].SetActive(value: false);
		}
		Transform transform = btn_soundButton;
		Vector3 localPosition = btn_soundButton.localPosition;
		float y = localPosition.y;
		Vector3 localPosition2 = btn_soundButton.localPosition;
		transform.localPosition = new Vector3(0.2f, y, localPosition2.z);
		Transform transform2 = btn_rateButton;
		Vector3 localPosition3 = btn_rateButton.localPosition;
		float y2 = localPosition3.y;
		Vector3 localPosition4 = btn_rateButton.localPosition;
		transform2.localPosition = new Vector3(-1.4f, y2, localPosition4.z);
		Transform obj = btn_arenaButton[0];
		Vector3 localPosition5 = btn_arenaButton[0].localPosition;
		float y3 = localPosition5.y;
		Vector3 localPosition6 = btn_arenaButton[0].localPosition;
		obj.localPosition = new Vector3(1f, y3, localPosition6.z);
		Transform obj2 = btn_arenaButton[1];
		Vector3 localPosition7 = btn_arenaButton[1].localPosition;
		float y4 = localPosition7.y;
		Vector3 localPosition8 = btn_arenaButton[1].localPosition;
		obj2.localPosition = new Vector3(2.2f, y4, localPosition8.z);
		UnityEngine.Object.Destroy(GetComponent<Menu_Logic_AndroidSetup>());
	}
}
