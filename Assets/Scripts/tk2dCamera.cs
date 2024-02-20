using System;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("2D Toolkit/Camera/tk2dCamera")]
public class tk2dCamera : MonoBehaviour
{
	public tk2dCameraResolutionOverride[] resolutionOverride;

	private tk2dCameraResolutionOverride currentResolutionOverride;

	public Camera mainCamera;

	public static tk2dCamera inst;

	[NonSerialized]
	public float orthoSize = 1f;

	[NonSerialized]
	public Vector2 resolution = new Vector2(1f, 1f);

	[HideInInspector]
	public bool forceResolutionInEditor;

	[HideInInspector]
	public Vector2 forceResolution = new Vector2(960f, 640f);

	private void Awake()
	{
		mainCamera = GetComponent<Camera>();
		if (mainCamera != null)
		{
			UpdateCameraMatrix();
		}
		inst = this;
	}

	private void Update()
	{
		UpdateCameraMatrix();
	}

	public void UpdateCameraMatrix()
	{
		inst = this;
		float num = mainCamera.pixelWidth;
		float num2 = mainCamera.pixelHeight;
		if (currentResolutionOverride == null || (currentResolutionOverride != null && ((float)currentResolutionOverride.width != num || (float)currentResolutionOverride.height != num2)))
		{
			currentResolutionOverride = null;
			if (resolutionOverride != null)
			{
				tk2dCameraResolutionOverride[] array = resolutionOverride;
				foreach (tk2dCameraResolutionOverride tk2dCameraResolutionOverride in array)
				{
					if (tk2dCameraResolutionOverride.Match((int)num, (int)num2))
					{
						currentResolutionOverride = tk2dCameraResolutionOverride;
						break;
					}
				}
			}
		}
		float num3 = (currentResolutionOverride == null) ? 1f : currentResolutionOverride.scale;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = num;
		float num7 = num2;
		float farClipPlane = mainCamera.farClipPlane;
		float near = mainCamera.nearClipPlane;
		orthoSize = (num7 - num5) / 2f;
		resolution = new Vector2(num6 / num3, num7 / num3);
		bool flag = false;
		float num8 = (Application.platform != RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.WebGLPlayer && Application.platform != RuntimePlatform.WindowsEditor) ? 0f : 1f;
		float value = 2f / (num6 - num4) * num3;
		float value2 = 2f / (num7 - num5) * num3;
		float value3 = -2f / (farClipPlane - near);
		float value4 = (0f - (num6 + num4 + num8)) / (num6 - num4);
		float value5 = (0f - (num5 + num7 - num8)) / (num7 - num5);
		float value6 = (0f - 2f * farClipPlane * near) / (farClipPlane - near);
		Matrix4x4 projectionMatrix = default(Matrix4x4);
		projectionMatrix[0, 0] = value;
		projectionMatrix[0, 1] = 0f;
		projectionMatrix[0, 2] = 0f;
		projectionMatrix[0, 3] = value4;
		projectionMatrix[1, 0] = 0f;
		projectionMatrix[1, 1] = value2;
		projectionMatrix[1, 2] = 0f;
		projectionMatrix[1, 3] = value5;
		projectionMatrix[2, 0] = 0f;
		projectionMatrix[2, 1] = 0f;
		projectionMatrix[2, 2] = value3;
		projectionMatrix[2, 3] = value6;
		projectionMatrix[3, 0] = 0f;
		projectionMatrix[3, 1] = 0f;
		projectionMatrix[3, 2] = 0f;
		projectionMatrix[3, 3] = 1f;
		mainCamera.projectionMatrix = projectionMatrix;
	}
}
