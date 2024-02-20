using UnityEngine;

public class Unit_Health_Display : MonoBehaviour
{
	public Unit_Control scriptUnitControl;

	public tk2dAnimatedSprite spriteA;

	public pop_effect popEffectA;

	private int TOGGLE_healthValue;

	private int TOGGLE_manaValue;

	private Color COLOR_sprite;

	private Transform myTransform;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void Update()
	{
		if (!(scriptUnitControl != null))
		{
			return;
		}
		if (Time.timeScale == 0f)
		{
			myTransform.position = new Vector3(0f, 100f, 0f);
			return;
		}
		Transform transform = myTransform;
		Vector3 position = scriptUnitControl.transform.position;
		transform.position = new Vector3(position.x, -0.12f, -1.5f);
		if (scriptUnitControl.attributeHealthValue >= scriptUnitControl.attributeHealthMaximumValue)
		{
			if (TOGGLE_healthValue != scriptUnitControl.attributeHealthValue)
			{
				popEffectA.activate = true;
				TOGGLE_healthValue = scriptUnitControl.attributeHealthValue;
			}
			spriteA.scale = new Vector3(1.4f, 1.4f, 1.4f);
			COLOR_sprite = new Color(0.75f, 1f, 1f, 1f);
		}
		else if (scriptUnitControl.attributeHealthValue < scriptUnitControl.attributeHealthMaximumValue && scriptUnitControl.attributeHealthValue >= scriptUnitControl.attributeHealthMaximumValue / 2)
		{
			if (TOGGLE_healthValue != scriptUnitControl.attributeHealthValue)
			{
				popEffectA.activate = true;
				TOGGLE_healthValue = scriptUnitControl.attributeHealthValue;
			}
			spriteA.scale = new Vector3(1.25f, 1.25f, 1.25f);
			COLOR_sprite = Color.white;
		}
		else if (scriptUnitControl.attributeHealthValue < scriptUnitControl.attributeHealthMaximumValue / 2 && scriptUnitControl.attributeHealthValue >= scriptUnitControl.attributeHealthMaximumValue / 4)
		{
			if (TOGGLE_healthValue != scriptUnitControl.attributeHealthValue)
			{
				popEffectA.activate = true;
				TOGGLE_healthValue = scriptUnitControl.attributeHealthValue;
			}
			spriteA.scale = new Vector3(1.25f, 1.25f, 1.25f);
			COLOR_sprite = new Color(1f, 1f, 0.2f, 1f);
		}
		else if (scriptUnitControl.attributeHealthValue < scriptUnitControl.attributeHealthMaximumValue / 4)
		{
			if (TOGGLE_healthValue != scriptUnitControl.attributeHealthValue)
			{
				popEffectA.activate = true;
				TOGGLE_healthValue = scriptUnitControl.attributeHealthValue;
			}
			spriteA.scale = new Vector3(1.25f, 1.25f, 1.25f);
			COLOR_sprite = new Color(1f, 0.2f, 0.2f, 1f);
		}
		spriteA.color = COLOR_sprite;
		if (scriptUnitControl.state == 2)
		{
			PoolManager.Pools["HUD Pool"].Despawn(base.transform);
		}
	}
}
