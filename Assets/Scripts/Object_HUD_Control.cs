using UnityEngine;

public class Object_HUD_Control : MonoBehaviour
{
	public GameObject gameobjectObject;

	public Object_Control scriptObjectControl;

	public GameObject gameobjectMagicArrow;

	public tk2dSprite spriteMagicArrow;

	public tk2dSprite spriteMagicCircle;

	public float origSize = 1f;

	private float SIZE_spriteMagicCircle;

	private float VELOCITY_spriteMagicCircle = 0.0025f;

	private Vector3 MousePos;

	public bool SetAim;

	public float SetAimDirection = -1000f;

	private Transform myTransform;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void OnSpawned()
	{
		base.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		SIZE_spriteMagicCircle = origSize;
		spriteMagicCircle.scale = new Vector3(origSize, origSize, origSize);
		spriteMagicCircle.transform.localPosition = new Vector3(0f, 0f, -0.5f);
		spriteMagicArrow.transform.localPosition = new Vector3(-1.5f, 0f, 0f);
		gameobjectMagicArrow.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
		spriteMagicArrow.gameObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
		spriteMagicCircle.color = Color.white;
		spriteMagicArrow.color = Color.white;
		gameobjectObject = null;
		scriptObjectControl = null;
	}

	private void OnDespawned()
	{
		SIZE_spriteMagicCircle = origSize;
		spriteMagicCircle.scale = new Vector3(origSize, origSize, origSize);
		gameobjectMagicArrow.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
		spriteMagicArrow.gameObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
		spriteMagicCircle.color = Color.white;
		spriteMagicArrow.color = Color.white;
		gameobjectObject = null;
		scriptObjectControl = null;
	}

	private void Update()
	{
		if (!(gameobjectObject != null))
		{
			return;
		}
		if (scriptObjectControl == null)
		{
			scriptObjectControl = gameobjectObject.GetComponent<Object_Control>();
		}
		else
		{
			switch (scriptObjectControl.objectType)
			{
			case 0:
				HUDEffectObjectFlyer();
				break;
			case 1:
				HUDEffectObjectFlyer();
				break;
			case 2:
				HUDEffectObjectBlock();
				break;
			case 3:
				HUDEffectObjectBlock();
				break;
			}
		}
		if (Input.GetMouseButton(0))
		{
			spriteMagicCircle.transform.Rotate(0f, 0f, 1f);
			if (SetAim)
			{
				gameobjectMagicArrow.transform.localRotation = Quaternion.Euler(SetAimDirection, 90f, 0f);
			}
			else
			{
				Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hitInfo))
				{
					UnityEngine.Debug.DrawLine(ray.origin, hitInfo.point);
					Vector3 point = hitInfo.point;
					float x = point.x;
					Vector3 point2 = hitInfo.point;
					MousePos = new Vector3(x, point2.y, -5f);
					gameobjectMagicArrow.transform.LookAt(new Vector3(MousePos.x, MousePos.y, -5f));
					spriteMagicArrow.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
				}
			}
		}
		if (Input.GetMouseButtonUp(0) || scriptObjectControl.objectState != 2)
		{
			PoolManager.Pools["HUD Pool"].Despawn(base.transform);
		}
	}

	private void HUDEffectObjectFlyer()
	{
		SetAim = false;
		Transform transform = myTransform;
		Vector3 position = myTransform.position;
		float x = position.x;
		Vector3 position2 = myTransform.position;
		transform.position = new Vector3(x, position2.y, -5f);
		spriteMagicCircle.scale = new Vector3(SIZE_spriteMagicCircle, SIZE_spriteMagicCircle, SIZE_spriteMagicCircle);
		switch (scriptObjectControl.objectChargeState)
		{
		case 0:
			SIZE_spriteMagicCircle += VELOCITY_spriteMagicCircle;
			spriteMagicCircle.color = Color.white;
			spriteMagicArrow.color = Color.white;
			break;
		case 1:
			SIZE_spriteMagicCircle += VELOCITY_spriteMagicCircle / 1.5f;
			spriteMagicCircle.color = Color.yellow;
			spriteMagicArrow.color = Color.yellow;
			break;
		case 2:
			spriteMagicCircle.color = Color.green;
			spriteMagicArrow.color = Color.green;
			break;
		}
	}

	private void HUDEffectObjectBlock()
	{
		SetAim = true;
		SetAimDirection = 90f;
		Transform transform = myTransform;
		Vector3 position = gameobjectObject.transform.position;
		float x = position.x;
		Vector3 position2 = gameobjectObject.transform.position;
		transform.position = new Vector3(x, position2.y, -5f);
		spriteMagicCircle.scale = new Vector3(SIZE_spriteMagicCircle, SIZE_spriteMagicCircle, SIZE_spriteMagicCircle);
		switch (scriptObjectControl.objectChargeState)
		{
		case 0:
			SIZE_spriteMagicCircle = 1.25f;
			spriteMagicCircle.color = Color.white;
			spriteMagicArrow.color = Color.white;
			break;
		case 1:
			SIZE_spriteMagicCircle = 1.5f;
			spriteMagicCircle.color = Color.yellow;
			spriteMagicArrow.color = Color.yellow;
			break;
		case 2:
			SIZE_spriteMagicCircle = 1.75f;
			spriteMagicCircle.color = Color.green;
			spriteMagicArrow.color = Color.green;
			break;
		}
	}
}
