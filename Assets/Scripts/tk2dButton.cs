using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("2D Toolkit/GUI/tk2dButton")]
public class tk2dButton : MonoBehaviour
{
	public delegate void ButtonHandlerDelegate(tk2dButton source);

	public Camera viewCamera;

	public string buttonDownSprite = "button_down";

	public string buttonUpSprite = "button_up";

	public string buttonPressedSprite = "button_up";

	private int buttonDownSpriteId = -1;

	private int buttonUpSpriteId = -1;

	private int buttonPressedSpriteId = -1;

	public AudioClip buttonDownSound;

	public AudioClip buttonUpSound;

	public AudioClip buttonPressedSound;

	public GameObject targetObject;

	public string messageName = string.Empty;

	private tk2dBaseSprite sprite;

	private bool buttonDown;

	public float targetScale = 1.1f;

	public float scaleTime = 0.05f;

	public float pressedWaitTime = 0.3f;

	[method: MethodImpl(32)]
	public event ButtonHandlerDelegate ButtonPressedEvent;

	[method: MethodImpl(32)]
	public event ButtonHandlerDelegate ButtonAutoFireEvent;

	[method: MethodImpl(32)]
	public event ButtonHandlerDelegate ButtonDownEvent;

	[method: MethodImpl(32)]
	public event ButtonHandlerDelegate ButtonUpEvent;

	private void OnEnable()
	{
		buttonDown = false;
	}

	private void Start()
	{
		if (viewCamera == null)
		{
			Transform transform = base.transform;
			while ((bool)transform && transform.GetComponent<Camera>() == null)
			{
				transform = transform.parent;
			}
			if ((bool)transform && transform.GetComponent<Camera>() != null)
			{
				viewCamera = transform.GetComponent<Camera>();
			}
			if (viewCamera == null && (bool)tk2dCamera.inst)
			{
				viewCamera = tk2dCamera.inst.mainCamera;
			}
			if (viewCamera == null)
			{
				viewCamera = Camera.main;
			}
		}
		sprite = GetComponent<tk2dBaseSprite>();
		if ((bool)sprite)
		{
			UpdateSpriteIds();
		}
		if (GetComponent<Collider>() == null)
		{
			BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
			Vector3 extents = boxCollider.extents;
			extents.z = 0.2f;
			boxCollider.extents = extents;
		}
		if ((buttonDownSound != null || buttonPressedSound != null || buttonUpSound != null) && GetComponent<AudioSource>() == null)
		{
			AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.playOnAwake = false;
		}
	}

	public void UpdateSpriteIds()
	{
		buttonDownSpriteId = ((buttonDownSprite.Length <= 0) ? (-1) : sprite.GetSpriteIdByName(buttonDownSprite));
		buttonUpSpriteId = ((buttonUpSprite.Length <= 0) ? (-1) : sprite.GetSpriteIdByName(buttonUpSprite));
		buttonPressedSpriteId = ((buttonPressedSprite.Length <= 0) ? (-1) : sprite.GetSpriteIdByName(buttonPressedSprite));
	}

	private void PlaySound(AudioClip source)
	{
		if ((bool)GetComponent<AudioSource>() && (bool)source)
		{
			GetComponent<AudioSource>().PlayOneShot(source);
		}
	}

	private IEnumerator coScale(Vector3 defaultScale, float startScale, float endScale)
	{
		float t2 = Time.realtimeSinceStartup;
		for (float s = 0f; s < scaleTime; s = Time.realtimeSinceStartup - t2)
		{
			float t = Mathf.Clamp01(s / scaleTime);
			float scl = Mathf.Lerp(startScale, endScale, t);
			Vector3 scale = defaultScale * scl;
			base.transform.localScale = scale;
			yield return 0;
		}
		base.transform.localScale = defaultScale * endScale;
	}

	private IEnumerator LocalWaitForSeconds(float seconds)
	{
		float t0 = Time.realtimeSinceStartup;
		for (float s = 0f; s < seconds; s = Time.realtimeSinceStartup - t0)
		{
			yield return 0;
		}
	}

	private IEnumerator coHandleButtonPress()
	{
		buttonDown = true;
		bool buttonPressed = true;
		Vector3 defaultScale = base.transform.localScale;
		if (targetScale != 1f)
		{
			yield return StartCoroutine(coScale(defaultScale, 1f, targetScale));
		}
		PlaySound(buttonDownSound);
		if (buttonDownSpriteId != -1)
		{
			sprite.spriteId = buttonDownSpriteId;
		}
		if (this.ButtonDownEvent != null)
		{
			this.ButtonDownEvent(this);
		}
		while (Input.GetMouseButton(0))
		{
			Ray ray = viewCamera.ScreenPointToRay(UnityEngine.Input.mousePosition);
			RaycastHit hitInfo;
			bool colliderHit = GetComponent<Collider>().Raycast(ray, out hitInfo, 1E+08f);
			if (buttonPressed && !colliderHit)
			{
				if (targetScale != 1f)
				{
					yield return StartCoroutine(coScale(defaultScale, targetScale, 1f));
				}
				PlaySound(buttonUpSound);
				if (buttonUpSpriteId != -1)
				{
					sprite.spriteId = buttonUpSpriteId;
				}
				if (this.ButtonUpEvent != null)
				{
					this.ButtonUpEvent(this);
				}
				buttonPressed = false;
			}
			else if (!buttonPressed && colliderHit)
			{
				if (targetScale != 1f)
				{
					yield return StartCoroutine(coScale(defaultScale, 1f, targetScale));
				}
				PlaySound(buttonDownSound);
				if (buttonDownSpriteId != -1)
				{
					sprite.spriteId = buttonDownSpriteId;
				}
				if (this.ButtonDownEvent != null)
				{
					this.ButtonDownEvent(this);
				}
				buttonPressed = true;
			}
			if (buttonPressed && this.ButtonAutoFireEvent != null)
			{
				this.ButtonAutoFireEvent(this);
			}
			yield return 0;
		}
		if (buttonPressed)
		{
			if (targetScale != 1f)
			{
				yield return StartCoroutine(coScale(defaultScale, targetScale, 1f));
			}
			PlaySound(buttonPressedSound);
			if (buttonPressedSpriteId != -1)
			{
				sprite.spriteId = buttonPressedSpriteId;
			}
			if ((bool)targetObject)
			{
				targetObject.SendMessage(messageName);
			}
			if (this.ButtonUpEvent != null)
			{
				this.ButtonUpEvent(this);
			}
			if (this.ButtonPressedEvent != null)
			{
				this.ButtonPressedEvent(this);
			}
			if (base.gameObject.active)
			{
				yield return StartCoroutine(LocalWaitForSeconds(pressedWaitTime));
			}
			if (buttonUpSpriteId != -1)
			{
				sprite.spriteId = buttonUpSpriteId;
			}
		}
		buttonDown = false;
	}

	private void Update()
	{
		if (!buttonDown && Input.GetMouseButtonDown(0))
		{
			Ray ray = viewCamera.ScreenPointToRay(UnityEngine.Input.mousePosition);
			if (GetComponent<Collider>().Raycast(ray, out RaycastHit hitInfo, 1E+08f) && !Physics.Raycast(ray, hitInfo.distance - 0.01f))
			{
				StartCoroutine(coHandleButtonPress());
			}
		}
	}
}
