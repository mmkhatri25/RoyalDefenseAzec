using UnityEngine;

public class Object_PickUp_Trigger : MonoBehaviour
{
	public Object_Control scriptObject;

	public Color shineColour;

	public float shineScale = 3f;

	public GameObject gameobjectShine;

	private tk2dSprite spriteShine;

	private Game_Logic scriptGamelogic;

	private Transform myTransform;

	private Vector3 triggerVector;

	public float xTriggerPosition;

	public float yTriggerPosition;

	public float xTriggerScale = 0.4f;

	public float yTriggerScale = 0.4f;

	private Game_Statistics scriptGameStatistics;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		spriteShine = gameobjectShine.GetComponent<tk2dSprite>();
		spriteShine.color = shineColour;
		spriteShine.scale = new Vector3(shineScale, shineScale, shineScale);
		scriptGameStatistics = GameScriptsManager.gameStatisticScript;
		scriptGamelogic = GameScriptsManager.gameLogicScript;
		Vector3 position = myTransform.position;
		float x = position.x + xTriggerPosition;
		Vector3 position2 = myTransform.position;
		float y = position2.y + yTriggerPosition;
		Vector3 position3 = myTransform.position;
		triggerVector = new Vector3(x, y, position3.z);
	}

	private void OnSpawned()
	{
		gameobjectShine.active = true;
	}

	private void OnDespawned()
	{
		gameobjectShine.active = true;
	}

	private void Update()
	{
		if (scriptObject.objectState == 0)
		{
			Vector3 lhs = triggerVector;
			Vector3 position = myTransform.position;
			float x = position.x + xTriggerPosition;
			Vector3 position2 = myTransform.position;
			float y = position2.y + yTriggerPosition;
			Vector3 position3 = myTransform.position;
			if (lhs != new Vector3(x, y, position3.z))
			{
				Vector3 position4 = myTransform.position;
				float x2 = position4.x + xTriggerPosition;
				Vector3 position5 = myTransform.position;
				float y2 = position5.y + yTriggerPosition;
				Vector3 position6 = myTransform.position;
				triggerVector = new Vector3(x2, y2, position6.z);
			}
			PickUpFunction();
		}
	}

	private void PickUpFunction()
	{
		if (Input.GetMouseButton(0) && scriptGameStatistics.objectLevitating > 0 && Time.timeScale != 0f && scriptGamelogic.gameState == 2)
		{
			Vector3 vector = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
			if (vector.x < triggerVector.x + xTriggerScale)
			{
				Vector3 vector2 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				if (vector2.x > triggerVector.x - xTriggerScale)
				{
					Vector3 vector3 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
					if (vector3.y < triggerVector.y + yTriggerScale)
					{
						Vector3 vector4 = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
						if (vector4.y > triggerVector.y - yTriggerScale)
						{
							scriptGameStatistics.characterAnimationNumber = 5;
							scriptGameStatistics.manaNumber -= scriptGameStatistics.objectManaCost;
							scriptGameStatistics.objectLevitating -= scriptObject.attributeObjectLevitationValue;
							gameobjectShine.active = false;
							scriptObject.objectState = 1;
							return;
						}
					}
				}
			}
		}
		if (!gameobjectShine.active)
		{
			gameobjectShine.active = true;
		}
	}
}
