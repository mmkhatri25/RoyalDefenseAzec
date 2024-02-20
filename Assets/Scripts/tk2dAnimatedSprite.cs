using UnityEngine;

[AddComponentMenu("2D Toolkit/Sprite/tk2dAnimatedSprite")]
public class tk2dAnimatedSprite : tk2dSprite
{
	public delegate void AnimationCompleteDelegate(tk2dAnimatedSprite sprite, int clipId);

	public delegate void AnimationEventDelegate(tk2dAnimatedSprite sprite, tk2dSpriteAnimationClip clip, tk2dSpriteAnimationFrame frame, int frameNum);

	public tk2dSpriteAnimation anim;

	public int clipId;

	public bool playAutomatically;

	public static bool g_paused;

	public bool paused;

	public bool createCollider;

	private tk2dSpriteAnimationClip currentClip;

	private float clipTime;

	private int previousFrame = -1;

	public AnimationCompleteDelegate animationCompleteDelegate;

	public AnimationEventDelegate animationEventDelegate;

	public tk2dSpriteAnimationClip CurrentClip => currentClip;

	public float ClipTimeSeconds => clipTime / currentClip.fps;

	private new void Start()
	{
		base.Start();
		if (playAutomatically)
		{
			Play(clipId);
		}
	}

	public void Play()
	{
		Play(clipId);
	}

	public void Play(float clipStartTime)
	{
		Play(clipId, clipStartTime);
	}

	public void PlayFromFrame(int frame)
	{
		PlayFromFrame(clipId, frame);
	}

	public void Play(string name)
	{
		int id = (!anim) ? (-1) : anim.GetClipIdByName(name);
		Play(id);
	}

	public void PlayFromFrame(string name, int frame)
	{
		int id = (!anim) ? (-1) : anim.GetClipIdByName(name);
		PlayFromFrame(id, frame);
	}

	public void Play(string name, float clipStartTime)
	{
		int id = (!anim) ? (-1) : anim.GetClipIdByName(name);
		Play(id, clipStartTime);
	}

	public void Stop()
	{
		currentClip = null;
	}

	public bool isPlaying()
	{
		return currentClip != null;
	}

	protected override bool NeedBoxCollider()
	{
		return createCollider;
	}

	public int GetClipIdByName(string name)
	{
		return (!anim) ? (-1) : anim.GetClipIdByName(name);
	}

	public void Play(int id)
	{
		Play(id, 0f);
	}

	public void PlayFromFrame(int id, int frame)
	{
		tk2dSpriteAnimationClip tk2dSpriteAnimationClip = anim.clips[id];
		Play(id, (float)frame / tk2dSpriteAnimationClip.fps);
	}

	public void Play(int id, float clipStartTime)
	{
		clipId = id;
		if (id >= 0 && (bool)anim && id < anim.clips.Length)
		{
			currentClip = anim.clips[id];
			if (currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.Single || currentClip.frames == null)
			{
				SwitchCollectionAndSprite(currentClip.frames[0].spriteCollection, currentClip.frames[0].spriteId);
				if (currentClip.frames[0].triggerEvent && animationEventDelegate != null)
				{
					animationEventDelegate(this, currentClip, currentClip.frames[0], 0);
				}
				currentClip = null;
			}
			else if (currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.RandomFrame || currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.RandomLoop)
			{
				int num = Random.Range(0, currentClip.frames.Length - 1);
				tk2dSpriteAnimationFrame tk2dSpriteAnimationFrame = currentClip.frames[num];
				clipTime = (float)num * currentClip.fps;
				SwitchCollectionAndSprite(tk2dSpriteAnimationFrame.spriteCollection, tk2dSpriteAnimationFrame.spriteId);
				if (tk2dSpriteAnimationFrame.triggerEvent && animationEventDelegate != null)
				{
					animationEventDelegate(this, currentClip, tk2dSpriteAnimationFrame, 0);
				}
				if (currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.RandomFrame)
				{
					currentClip = null;
					previousFrame = -1;
				}
			}
			else
			{
				clipTime = clipStartTime * currentClip.fps;
				previousFrame = -1;
				if (currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.Once && clipTime >= currentClip.fps * (float)currentClip.frames.Length)
				{
					clipTime = currentClip.fps * ((float)currentClip.frames.Length - 0.1f);
				}
			}
		}
		else
		{
			OnCompleteAnimation();
			currentClip = null;
		}
	}

	public void Pause()
	{
		paused = true;
	}

	public void Resume()
	{
		paused = false;
	}

	private void OnCompleteAnimation()
	{
		previousFrame = -1;
		if (animationCompleteDelegate != null)
		{
			animationCompleteDelegate(this, clipId);
		}
	}

	public void SetFrame(int currFrame)
	{
		if (currentClip != null && currentClip.frames.Length > 0 && currFrame >= 0)
		{
			SetFrameInternal(currFrame % currentClip.frames.Length);
		}
	}

	private void SetFrameInternal(int currFrame)
	{
		if (previousFrame != currFrame)
		{
			SwitchCollectionAndSprite(currentClip.frames[currFrame].spriteCollection, currentClip.frames[currFrame].spriteId);
			if (currentClip.frames[currFrame].triggerEvent && animationEventDelegate != null)
			{
				animationEventDelegate(this, currentClip, currentClip.frames[currFrame], currFrame);
			}
			previousFrame = currFrame;
		}
	}

	private void Update()
	{
		if (g_paused || paused || currentClip == null || currentClip.frames == null)
		{
			return;
		}
		clipTime += Time.deltaTime * currentClip.fps;
		if (currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.Loop || currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.RandomLoop)
		{
			int frameInternal = (int)clipTime % currentClip.frames.Length;
			SetFrameInternal(frameInternal);
		}
		else if (currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.LoopSection)
		{
			int num = (int)clipTime;
			if (num >= currentClip.loopStart)
			{
				num = currentClip.loopStart + (num - currentClip.loopStart) % (currentClip.frames.Length - currentClip.loopStart);
			}
			SetFrameInternal(num);
		}
		else if (currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.PingPong)
		{
			int num2 = (int)clipTime % (currentClip.frames.Length + currentClip.frames.Length - 2);
			if (num2 >= currentClip.frames.Length)
			{
				int num3 = num2 - currentClip.frames.Length;
				num2 = currentClip.frames.Length - 2 - num3;
			}
			SetFrameInternal(num2);
		}
		else if (currentClip.wrapMode == tk2dSpriteAnimationClip.WrapMode.Once)
		{
			int num4 = (int)clipTime;
			if (num4 >= currentClip.frames.Length)
			{
				currentClip = null;
				OnCompleteAnimation();
			}
			else
			{
				SetFrameInternal(num4);
			}
		}
	}
}
