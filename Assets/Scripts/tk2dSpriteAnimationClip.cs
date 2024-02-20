using System;

[Serializable]
public class tk2dSpriteAnimationClip
{
	public enum WrapMode
	{
		Loop,
		LoopSection,
		Once,
		PingPong,
		RandomFrame,
		RandomLoop,
		Single
	}

	public string name = "Default";

	public tk2dSpriteAnimationFrame[] frames;

	public float fps = 30f;

	public int loopStart;

	public WrapMode wrapMode;
}
