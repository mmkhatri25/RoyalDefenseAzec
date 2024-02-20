using UnityEngine;

public class game_intro_script : MonoBehaviour
{
	public bool activate;

	public Door_Guard_Script[] objectScript;

	public DoorPiece_Script[] doorPieceScript;

	private void Start()
	{
	}

	private void Update()
	{
		if (activate)
		{
			for (int i = 0; i < objectScript.Length; i++)
			{
				objectScript[i].activate = true;
			}
			for (int j = 0; j < doorPieceScript.Length; j++)
			{
				doorPieceScript[j].activate = true;
			}
		}
	}
}
