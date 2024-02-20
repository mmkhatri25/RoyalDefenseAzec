using UnityEngine;

public class Effect_Anim : MonoBehaviour
{
	public tk2dAnimatedSprite anim;

	public string clip = string.Empty;

	public bool playClip;

	public bool repeat;

	public bool rotate;

	public bool expand;

	public float expandSpeed = 2f;

	public float expandTime = 10f;

	public float originalSize = 1f;

	public float rotateSpeed = 40f;

	public float clipTime = 10f;

	private float timer;

	private float expandTimer;

	private void Start()
	{
		base.useGUILayout = false;
		anim = GetComponent<tk2dAnimatedSprite>();
		if (playClip)
		{
			anim.Play(clip);
		}
	}

	private void OnSpawned()
	{
		if (playClip)
		{
			anim.Play(clip);
		}
	}

	private void Update()
	{
		if (!repeat)
		{
			if (timer < clipTime)
			{
				timer += 0.1f;
			}
			else if (timer >= clipTime)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (rotate)
		{
			base.transform.Rotate(0f, 0f, rotateSpeed);
		}
		if (!expand)
		{
			return;
		}
		if (expandTime > 0f)
		{
			if (expandTimer == 0f)
			{
				Vector3 localScale = base.transform.localScale;
				if (localScale.x < originalSize + expandTime)
				{
					base.transform.localScale += new Vector3(expandSpeed, expandSpeed, expandSpeed);
					return;
				}
				Vector3 localScale2 = base.transform.localScale;
				if (localScale2.x >= originalSize + expandTime)
				{
					expandTimer = 1f;
				}
			}
			else
			{
				if (expandTimer != 1f)
				{
					return;
				}
				Vector3 localScale3 = base.transform.localScale;
				if (localScale3.x > originalSize)
				{
					base.transform.localScale += new Vector3(0f - expandSpeed, 0f - expandSpeed, 0f - expandSpeed);
					return;
				}
				Vector3 localScale4 = base.transform.localScale;
				if (localScale4.x <= originalSize)
				{
					expandTimer = 0f;
				}
			}
		}
		else if (expandTime == 0f)
		{
			base.transform.localScale += new Vector3(expandSpeed, expandSpeed, expandSpeed);
		}
	}
}
