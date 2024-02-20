using UnityEngine;

public class state_effect : MonoBehaviour
{
	public int unitType;

	public GameObject targetObject;

	public tk2dAnimatedSprite sprite;

	public string spriteAnimation;

	public float xAxis;

	public float yAxis;

	public Color spriteColor;

	private Transform myTransform;

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		if (sprite != null && spriteColor.a == 0f)
		{
			spriteColor = Color.white;
		}
	}

	private void OnSpawned()
	{
		base.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		if (sprite != null && spriteAnimation != string.Empty)
		{
			sprite.Play(spriteAnimation);
		}
	}

	private void OnDespawned()
	{
		if (sprite != null)
		{
			spriteColor = Color.white;
			sprite.color = spriteColor;
		}
	}

	private void Update()
	{
		if (sprite != null && sprite.color != spriteColor)
		{
			sprite.color = spriteColor;
		}
		switch (unitType)
		{
		case 0:
		{
			Transform transform2 = myTransform;
			Vector3 position3 = targetObject.transform.position;
			float x2 = position3.x + xAxis;
			Vector3 position4 = targetObject.transform.position;
			transform2.position = new Vector3(x2, position4.y + yAxis, -2f);
			break;
		}
		case 1:
		{
			Transform transform = myTransform;
			Vector3 position = targetObject.transform.position;
			float x = position.x - xAxis;
			Vector3 position2 = targetObject.transform.position;
			transform.position = new Vector3(x, position2.y + yAxis, -2f);
			break;
		}
		}
	}
}
