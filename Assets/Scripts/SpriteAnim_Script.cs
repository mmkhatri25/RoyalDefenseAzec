using UnityEngine;

public class SpriteAnim_Script : MonoBehaviour
{
	private tk2dAnimatedSprite anim;

	public string animation1ClipName = string.Empty;

	public bool animation1;

	private bool animationx1;

	public string animation2ClipName = string.Empty;

	public bool animation2;

	private bool animationx2;

	public string animation3ClipName = string.Empty;

	public bool animation3;

	private bool animationx3;

	public string animation4ClipName = string.Empty;

	public bool animation4;

	private bool animationx4;

	public string animation5ClipName = string.Empty;

	public bool animation5;

	private bool animationx5;

	public string animation6ClipName = string.Empty;

	public bool animation6;

	private bool animationx6;

	public string animation7ClipName = string.Empty;

	public bool animation7;

	private bool animationx7;

	public string animation8ClipName = string.Empty;

	public bool animation8;

	private bool animationx8;

	public string animation9ClipName = string.Empty;

	public bool animation9;

	private bool animationx9;

	public string animation10ClipName = string.Empty;

	public bool animation10;

	private bool animationx10;

	private void Awake()
	{
		anim = GetComponent<tk2dAnimatedSprite>();
	}

	private void Update()
	{
		if (animation1)
		{
			if (!animationx1)
			{
				anim.Play(animation1ClipName);
				animationx1 = true;
			}
			animation1 = false;
		}
		else
		{
			animationx1 = false;
		}
		if (animation2)
		{
			if (!animationx2)
			{
				anim.Play(animation2ClipName);
				animationx2 = true;
			}
			animation2 = false;
		}
		else
		{
			animationx2 = false;
		}
		if (animation3)
		{
			if (!animationx3)
			{
				anim.Play(animation3ClipName);
				animationx3 = true;
			}
			animation3 = false;
		}
		else
		{
			animationx3 = false;
		}
		if (animation4)
		{
			if (!animationx4)
			{
				anim.Play(animation4ClipName);
				animationx4 = true;
			}
			animation4 = false;
		}
		else
		{
			animationx4 = false;
		}
		if (animation5)
		{
			if (!animationx5)
			{
				anim.Play(animation5ClipName);
				animationx5 = true;
			}
			animation5 = false;
		}
		else
		{
			animationx5 = false;
		}
		if (animation6)
		{
			if (!animationx6)
			{
				anim.Play(animation6ClipName);
				animationx6 = true;
				animation6 = false;
			}
			animation6 = false;
		}
		else
		{
			animationx6 = false;
		}
		if (animation7)
		{
			if (!animationx7)
			{
				anim.Play(animation7ClipName);
				animationx7 = true;
			}
			animation7 = false;
		}
		else
		{
			animationx7 = false;
		}
		if (animation8)
		{
			if (!animationx8)
			{
				anim.Play(animation8ClipName);
				animationx8 = true;
			}
			animation8 = false;
		}
		else
		{
			animationx8 = false;
		}
		if (animation9)
		{
			if (!animationx9)
			{
				anim.Play(animation9ClipName);
				animationx9 = true;
			}
			animation9 = false;
		}
		else
		{
			animationx9 = false;
		}
		if (animation10)
		{
			if (!animationx10)
			{
				anim.Play(animation10ClipName);
				animationx10 = true;
			}
			animation10 = false;
		}
		else
		{
			animationx10 = false;
		}
	}
}
