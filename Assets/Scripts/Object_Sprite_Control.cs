using UnityEngine;

public class Object_Sprite_Control : MonoBehaviour
{
	public Object_Attributes scriptObjectAttribute;

	public int objectIdleType;

	public int AnimationNumber;

	private int TOGGLE_AnimationNumber = -1;

	public Color originalColor = Color.white;

	public Color spriteColor = Color.white;

	private Color TOGGLE_spriteColor;

	public string OffClipName = string.Empty;

	public string OnClipName = string.Empty;

	public string SpecialOffClipName = string.Empty;

	public string SpecialOnClipName = string.Empty;

	public string MovingClipName = string.Empty;

	public int tweenIdleType = 1;

	public int tweenPickUpType;

	public int tweenReleaseType;

	private MeshRenderer render;

	private float zAxis;

	private tk2dAnimatedSprite TK2DSprite;

	private float spriteScale;

	public GameObject objectRemain;

	private Transform INST_objectRemain;

	private Transform myTransform;

	private int popState;

	private int direction;

	public Transform rotationPoint;

	private Quaternion originalVector;

	private Vector3 VECTOR_touchPos;

	private void Awake()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
	}

	private void Start()
	{
		spriteColor = Color.white;
		TK2DSprite = GetComponent<tk2dAnimatedSprite>();
		render = GetComponent<MeshRenderer>();
		Vector3 scale = TK2DSprite.scale;
		spriteScale = scale.x;
		originalVector = new Quaternion(0f, 0f, 0f, 0f);
		myTransform.rotation = originalVector;
		objectIdleType = scriptObjectAttribute.objectIdleType;
	}

	private void OnSpawned()
	{
		if (rotationPoint != null)
		{
			rotationPoint.rotation = Quaternion.Euler(0f, 90f, 0f);
			myTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
			myTransform.rotation = originalVector;
		}
		else
		{
			myTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
			myTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);
		}
		direction = 0;
		myTransform.localScale = new Vector3(1f, 1f, 1f);
		if (AnimationNumber != 0)
		{
			TK2DSprite.Play(OffClipName);
			AnimationNumber = 0;
			TOGGLE_AnimationNumber = 0;
		}
		popState = 0;
	}

	private void PopEffect()
	{
		switch (popState)
		{
		case 2:
			break;
		case 0:
		{
			Vector3 scale3 = TK2DSprite.scale;
			if (scale3.x < spriteScale * 1.6f)
			{
				TK2DSprite.scale += new Vector3(0.2f, 0.2f, 0.2f);
				break;
			}
			Vector3 scale4 = TK2DSprite.scale;
			if (scale4.x >= spriteScale * 1.6f)
			{
				popState++;
			}
			break;
		}
		case 1:
		{
			Vector3 scale = TK2DSprite.scale;
			if (scale.x > spriteScale)
			{
				TK2DSprite.scale += new Vector3(-0.2f, -0.2f, -0.2f);
				break;
			}
			Vector3 scale2 = TK2DSprite.scale;
			if (scale2.x <= spriteScale)
			{
				TOGGLE_AnimationNumber = -5;
				popState++;
			}
			break;
		}
		}
	}

	private void LateUpdate()
	{
		if (spriteColor != Color.white)
		{
			if (TOGGLE_spriteColor != spriteColor)
			{
				TK2DSprite.color = spriteColor;
				TOGGLE_spriteColor = spriteColor;
			}
		}
		else if (spriteColor == Color.white && TOGGLE_spriteColor != originalColor)
		{
			TK2DSprite.color = originalColor;
			TOGGLE_spriteColor = originalColor;
		}
	}

	private void AnimationFunction()
	{
		if (scriptObjectAttribute.objectState == 2)
		{
			AnimationNumber = 1;
		}
		if (TOGGLE_AnimationNumber == AnimationNumber)
		{
			return;
		}
		switch (AnimationNumber)
		{
		case -3:
			if (MovingClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			switch (objectIdleType)
			{
			case 2:
				TK2DSprite.scale = new Vector3(spriteScale, spriteScale, spriteScale);
				break;
			case 5:
				TK2DSprite.scale = new Vector3(spriteScale, spriteScale, spriteScale);
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(MovingClipName);
			break;
		case -2:
			switch (objectIdleType)
			{
			case 2:
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
				break;
			case 5:
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
				break;
			}
			if (SpecialOnClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(SpecialOnClipName);
			break;
		case 0:
			if (OffClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(OffClipName);
			break;
		case 1:
			switch (objectIdleType)
			{
			case 2:
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
				break;
			case 5:
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
				break;
			}
			if (OnClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(OnClipName);
			break;
		case 2:
			switch (objectIdleType)
			{
			case 2:
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
				break;
			case 5:
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
				break;
			}
			if (SpecialOffClipName == string.Empty)
			{
				render.enabled = false;
				break;
			}
			render.enabled = true;
			TK2DSprite.Play(SpecialOffClipName);
			break;
		case 3:
			switch (objectIdleType)
			{
			case 2:
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
				break;
			case 5:
				TK2DSprite.scale = new Vector3(0f - spriteScale, spriteScale, spriteScale);
				break;
			}
			if (MovingClipName == string.Empty)
			{
				render.enabled = false;
			}
			else
			{
				render.enabled = true;
				TK2DSprite.Play(MovingClipName);
			}
			TK2DSprite.Play(MovingClipName);
			break;
		case 4:
			TK2DSprite.Play("blank");
			if (objectRemain != null && TK2DSprite != null)
			{
				INST_objectRemain = PoolManager.Pools["VFX Pool"].Spawn(objectRemain.transform, myTransform.position, objectRemain.transform.rotation);
				if (INST_objectRemain.GetComponent<Object_Remain_Effect>() != null)
				{
					INST_objectRemain.GetComponent<Object_Remain_Effect>().objectClip = OnClipName;
					INST_objectRemain.GetComponent<Object_Remain_Effect>().size = TK2DSprite.scale;
				}
			}
			break;
		}
		TOGGLE_AnimationNumber = AnimationNumber;
	}

	private void Adjustment()
	{
		if (rotationPoint != null)
		{
			Quaternion rotation = rotationPoint.rotation;
			if (rotation.y != 0f)
			{
				Transform transform = rotationPoint;
				Quaternion localRotation = rotationPoint.localRotation;
				float x = localRotation.x;
				Quaternion localRotation2 = rotationPoint.localRotation;
				transform.rotation = Quaternion.Euler(x, 0f, localRotation2.z);
			}
			Quaternion rotation2 = myTransform.rotation;
			if (rotation2.y != 0f)
			{
				Transform transform2 = myTransform;
				Quaternion localRotation3 = myTransform.localRotation;
				float x2 = localRotation3.x;
				Quaternion localRotation4 = myTransform.localRotation;
				transform2.rotation = Quaternion.Euler(x2, 0f, localRotation4.z);
			}
		}
		else
		{
			Quaternion rotation3 = myTransform.rotation;
			if (rotation3.y != 0f)
			{
				Transform transform3 = myTransform;
				Quaternion localRotation5 = myTransform.localRotation;
				float x3 = localRotation5.x;
				Quaternion localRotation6 = myTransform.localRotation;
				transform3.rotation = Quaternion.Euler(x3, 0f, localRotation6.z);
			}
		}
	}

	private void Update()
	{
		AnimationFunction();
		if (!(scriptObjectAttribute != null) || Time.timeScale == 0f)
		{
			return;
		}
		if (objectIdleType != 2 && objectIdleType != 5)
		{
			PopEffect();
		}
		switch (scriptObjectAttribute.objectState)
		{
		case 1:
		case 3:
			break;
		case 0:
		{
			Adjustment();
			int num = tweenIdleType;
			if (num != 1)
			{
				break;
			}
			if (rotationPoint != null)
			{
				if (direction == 0)
				{
					Quaternion localRotation = rotationPoint.localRotation;
					if (localRotation.z > -0.02f)
					{
						rotationPoint.Rotate(0f, 0f, -0.1f);
						break;
					}
					Quaternion localRotation2 = rotationPoint.localRotation;
					if (localRotation2.z <= -0.02f)
					{
						direction = 1;
					}
				}
				else
				{
					if (direction != 1)
					{
						break;
					}
					Quaternion localRotation3 = rotationPoint.localRotation;
					if (localRotation3.z < 0.02f)
					{
						rotationPoint.Rotate(0f, 0f, 0.1f);
						break;
					}
					Quaternion localRotation4 = rotationPoint.localRotation;
					if (localRotation4.z >= 0.02f)
					{
						direction = 0;
					}
				}
			}
			else if (direction == 0)
			{
				Quaternion localRotation5 = myTransform.localRotation;
				if (localRotation5.z > -0.03f)
				{
					myTransform.Rotate(0f, 0f, -0.2f);
					break;
				}
				Quaternion localRotation6 = myTransform.localRotation;
				if (localRotation6.z <= -0.03f)
				{
					direction = 1;
				}
			}
			else
			{
				if (direction != 1)
				{
					break;
				}
				Quaternion localRotation7 = myTransform.localRotation;
				if (localRotation7.z < 0.03f)
				{
					myTransform.Rotate(0f, 0f, 0.2f);
					break;
				}
				Quaternion localRotation8 = myTransform.localRotation;
				if (localRotation8.z >= 0.03f)
				{
					direction = 0;
				}
			}
			break;
		}
		case 2:
			myTransform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
			PickUpAnimation();
			break;
		case 4:
			myTransform.localScale = new Vector3(1f, 1f, 1f);
			UnleasedAnimation();
			break;
		case 5:
			AnimationNumber = 4;
			break;
		}
	}

	private void PickUpAnimation()
	{
		switch (tweenPickUpType)
		{
		case 3:
			break;
		case 0:
			myTransform.Rotate(0f, 0f, 5f);
			break;
		case 1:
			myTransform.Rotate(0f, 0f, 2f);
			break;
		case 2:
			if (direction == 0)
			{
				Quaternion localRotation = myTransform.localRotation;
				if (localRotation.z > -0.05f)
				{
					myTransform.Rotate(0f, 0f, -0.4f);
					break;
				}
				Quaternion localRotation2 = myTransform.localRotation;
				if (localRotation2.z <= -0.03f)
				{
					direction = 1;
				}
			}
			else
			{
				if (direction != 1)
				{
					break;
				}
				Quaternion localRotation3 = myTransform.localRotation;
				if (localRotation3.z < 0.05f)
				{
					myTransform.Rotate(0f, 0f, 0.4f);
					break;
				}
				Quaternion localRotation4 = myTransform.localRotation;
				if (localRotation4.z >= 0.03f)
				{
					direction = 0;
				}
			}
			break;
		case 4:
			AimFunction();
			if (myTransform.localRotation != Quaternion.Euler(0f, 90f, -90f))
			{
				myTransform.localRotation = Quaternion.Euler(0f, 90f, -90f);
			}
			scriptObjectAttribute.transform.LookAt(VECTOR_touchPos);
			break;
		case 5:
			AimFunction();
			if (myTransform.localRotation != Quaternion.Euler(0f, 90f, 90f))
			{
				myTransform.localRotation = Quaternion.Euler(0f, 90f, 90f);
			}
			scriptObjectAttribute.transform.LookAt(VECTOR_touchPos);
			break;
		}
	}

	private void UnleasedAnimation()
	{
		switch (tweenReleaseType)
		{
		case 3:
			break;
		case 0:
			myTransform.Rotate(0f, 0f, -30f);
			break;
		case 1:
			myTransform.Rotate(0f, 0f, -5f);
			break;
		case 2:
			if (direction == 0)
			{
				Quaternion localRotation = myTransform.localRotation;
				if (localRotation.z > -0.05f)
				{
					myTransform.Rotate(0f, 0f, -0.4f);
					break;
				}
				Quaternion localRotation2 = myTransform.localRotation;
				if (localRotation2.z <= -0.03f)
				{
					direction = 1;
				}
			}
			else
			{
				if (direction != 1)
				{
					break;
				}
				Quaternion localRotation3 = myTransform.localRotation;
				if (localRotation3.z < 0.05f)
				{
					myTransform.Rotate(0f, 0f, 0.4f);
					break;
				}
				Quaternion localRotation4 = myTransform.localRotation;
				if (localRotation4.z >= 0.03f)
				{
					direction = 0;
				}
			}
			break;
		case 4:
			if (myTransform.localRotation != Quaternion.Euler(0f, 90f, -90f))
			{
				myTransform.localRotation = Quaternion.Euler(0f, 90f, -90f);
			}
			break;
		case 5:
			if (myTransform.localRotation != Quaternion.Euler(0f, 90f, 90f))
			{
				myTransform.localRotation = Quaternion.Euler(0f, 90f, 90f);
			}
			break;
		}
	}

	private void AimFunction()
	{
		Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hitInfo))
		{
			Vector3 point = hitInfo.point;
			float x = point.x;
			Vector3 point2 = hitInfo.point;
			float y = point2.y;
			Vector3 position = myTransform.position;
			VECTOR_touchPos = new Vector3(x, y, position.z);
		}
	}
}
