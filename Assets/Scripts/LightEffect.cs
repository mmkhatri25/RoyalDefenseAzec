using UnityEngine;

public class LightEffect : MonoBehaviour
{
	public tk2dAnimatedSprite sprite;

	private int state;

	private float TIMER_delay;

	private float flickerSpeed;

	private float shrinkSize = 2f;

	private float originalSize;

	private float spriteSize;

	private void Start()
	{
		sprite = GetComponent<tk2dAnimatedSprite>();
		Vector3 scale = sprite.scale;
		originalSize = scale.x;
		TIMER_delay = Time.time + (float)UnityEngine.Random.Range(1, 10);
		shrinkSize = UnityEngine.Random.Range(originalSize / 4f, originalSize);
		flickerSpeed = UnityEngine.Random.Range(0.1f, 1f);
	}

	private void OnSpawned()
	{
		if (sprite == null)
		{
			sprite = GetComponent<tk2dAnimatedSprite>();
			Vector3 scale = sprite.scale;
			originalSize = scale.x;
		}
		sprite.scale = new Vector3(originalSize, originalSize, originalSize);
		spriteSize = originalSize;
		state = 0;
		TIMER_delay = Time.time + (float)UnityEngine.Random.Range(1, 10);
		shrinkSize = UnityEngine.Random.Range(originalSize / 4f, originalSize);
		flickerSpeed = UnityEngine.Random.Range(0.1f, 1f);
	}

	private void Update()
	{
		if (Time.timeScale != 1f)
		{
			return;
		}
		switch (state)
		{
		case 0:
			if (Time.time >= TIMER_delay)
			{
				state = 1;
			}
			break;
		case 1:
		{
			Vector3 scale3 = sprite.scale;
			if (scale3.x > shrinkSize)
			{
				spriteSize -= flickerSpeed;
				sprite.scale = new Vector3(spriteSize, spriteSize, spriteSize);
				break;
			}
			Vector3 scale4 = sprite.scale;
			if (scale4.x <= shrinkSize)
			{
				sprite.scale = new Vector3(shrinkSize, shrinkSize, shrinkSize);
				state = 2;
			}
			break;
		}
		case 2:
		{
			Vector3 scale = sprite.scale;
			if (scale.x < originalSize)
			{
				spriteSize += flickerSpeed;
				sprite.scale = new Vector3(spriteSize, spriteSize, spriteSize);
				break;
			}
			Vector3 scale2 = sprite.scale;
			if (scale2.x >= originalSize)
			{
				sprite.scale = new Vector3(originalSize, originalSize, originalSize);
				TIMER_delay = Time.time + (float)UnityEngine.Random.Range(1, 10);
				shrinkSize = UnityEngine.Random.Range(originalSize / 4f, originalSize);
				flickerSpeed = UnityEngine.Random.Range(0.1f, 1f);
				state = 0;
			}
			break;
		}
		}
	}
}
