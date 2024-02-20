using System;
using UnityEngine;

[Serializable]
public class tk2dSpriteDefinition
{
	public enum ColliderType
	{
		Unset,
		None,
		Box,
		Mesh
	}

	public string name;

	public Vector3[] boundsData;

	public Vector3[] untrimmedBoundsData;

	public Vector2 texelSize;

	public Vector3[] positions;

	public Vector3[] normals;

	public Vector4[] tangents;

	public Vector2[] uvs;

	public int[] indices = new int[6]
	{
		0,
		3,
		1,
		2,
		3,
		0
	};

	public Material material;

	public int materialId;

	public string sourceTextureGUID;

	public bool extractRegion;

	public int regionX;

	public int regionY;

	public int regionW;

	public int regionH;

	public bool flipped;

	public bool complexGeometry;

	public ColliderType colliderType = ColliderType.None;

	public Vector3[] colliderVertices;

	public int[] colliderIndicesFwd;

	public int[] colliderIndicesBack;

	public bool colliderConvex;

	public bool colliderSmoothSphereCollisions;

	public bool Valid => name.Length != 0;
}
