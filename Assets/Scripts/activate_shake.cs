using UnityEngine;

public class activate_shake : MonoBehaviour
{
	private Camera_Shake scriptCameraShake;

	public bool cameraFocus;

	private void Start()
	{
		scriptCameraShake = GameScriptsManager.cameraShakeScript;
	}

	private void OnSpawned()
	{
		scriptCameraShake = GameScriptsManager.cameraShakeScript;
		scriptCameraShake.CameraShakeActivate = true;
		if (cameraFocus)
		{
			Camera_Control cameraControlScript = GameScriptsManager.cameraControlScript;
			Vector3 position = base.transform.position;
			cameraControlScript.setPositionX = position.x;
			GameScriptsManager.cameraControlScript.setCameraPosition = 1;
		}
	}

	private void OnDespawned()
	{
	}

	private void Update()
	{
	}
}
