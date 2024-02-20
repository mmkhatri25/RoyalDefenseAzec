using UnityEngine;

public class screen_effect : MonoBehaviour
{
	private Camera_Shake scriptCameraShake;

	public bool CameraShakeActivate;

	public int defeatEffect;

	private Camera_Control scriptCameraControl;

	public bool cameraFocus;

	private Transform myTransform;

	private void Start()
	{
		myTransform = base.transform;
		if ((CameraShakeActivate || defeatEffect == 1) && scriptCameraShake == null)
		{
			scriptCameraShake = GameScriptsManager.cameraShakeScript;
		}
		if (cameraFocus && scriptCameraControl == null)
		{
			scriptCameraControl = GameScriptsManager.cameraControlScript;
		}
	}

	private void OnSpawned()
	{
		if (CameraShakeActivate || defeatEffect != 0)
		{
			if (scriptCameraShake == null)
			{
				scriptCameraShake = GameScriptsManager.cameraShakeScript;
			}
			scriptCameraShake.CameraShakeActivate = CameraShakeActivate;
			scriptCameraShake.defeatEffect = defeatEffect;
		}
		if (cameraFocus)
		{
			myTransform = base.transform;
			if (scriptCameraControl == null)
			{
				scriptCameraControl = GameScriptsManager.cameraControlScript;
			}
			Camera_Control camera_Control = scriptCameraControl;
			Vector3 position = myTransform.position;
			camera_Control.setPositionX = position.x;
			scriptCameraControl.setCameraPosition = 1;
		}
	}

	private void OnDespawned()
	{
	}

	private void Update()
	{
	}
}
