using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[AddComponentMenu("2D Toolkit/Sprite/tk2dSprite")]
[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class tk2dSprite : tk2dBaseSprite
{
	private Mesh mesh;

	private Vector3[] meshVertices;

	private Vector3[] meshNormals;

	private Vector4[] meshTangents;

	private Color[] meshColors;

	private void Awake()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		if ((bool)collection)
		{
			if (_spriteId < 0 || _spriteId >= collection.Count)
			{
				_spriteId = 0;
			}
			Build();
		}
	}

	protected void OnDestroy()
	{
		if ((bool)mesh)
		{
			UnityEngine.Object.Destroy(mesh);
		}
		if ((bool)meshColliderMesh)
		{
			UnityEngine.Object.Destroy(meshColliderMesh);
		}
	}

	public override void Build()
	{
		tk2dSpriteDefinition tk2dSpriteDefinition = collection.spriteDefinitions[base.spriteId];
		meshVertices = new Vector3[tk2dSpriteDefinition.positions.Length];
		meshColors = new Color[tk2dSpriteDefinition.positions.Length];
		meshNormals = new Vector3[0];
		meshTangents = new Vector4[0];
		if (tk2dSpriteDefinition.normals != null && tk2dSpriteDefinition.normals.Length > 0)
		{
			meshNormals = new Vector3[tk2dSpriteDefinition.normals.Length];
		}
		if (tk2dSpriteDefinition.tangents != null && tk2dSpriteDefinition.tangents.Length > 0)
		{
			meshTangents = new Vector4[tk2dSpriteDefinition.tangents.Length];
		}
		SetPositions(meshVertices, meshNormals, meshTangents);
		SetColors(meshColors);
		if (mesh == null)
		{
			mesh = new Mesh();
			GetComponent<MeshFilter>().mesh = mesh;
		}
		mesh.Clear();
		mesh.vertices = meshVertices;
		mesh.normals = meshNormals;
		mesh.tangents = meshTangents;
		mesh.colors = meshColors;
		mesh.uv = tk2dSpriteDefinition.uvs;
		mesh.triangles = tk2dSpriteDefinition.indices;
		UpdateMaterial();
		CreateCollider();
	}

	protected override void UpdateGeometry()
	{
		UpdateGeometryImpl();
	}

	protected override void UpdateColors()
	{
		UpdateColorsImpl();
	}

	protected override void UpdateVertices()
	{
		UpdateVerticesImpl();
	}

	protected void UpdateColorsImpl()
	{
		SetColors(meshColors);
		mesh.colors = meshColors;
	}

	protected void UpdateVerticesImpl()
	{
		tk2dSpriteDefinition tk2dSpriteDefinition = collection.spriteDefinitions[base.spriteId];
		if (tk2dSpriteDefinition.normals.Length != meshNormals.Length)
		{
			meshNormals = ((tk2dSpriteDefinition.normals == null || tk2dSpriteDefinition.normals.Length <= 0) ? new Vector3[0] : new Vector3[tk2dSpriteDefinition.normals.Length]);
		}
		if (tk2dSpriteDefinition.tangents.Length != meshTangents.Length)
		{
			meshTangents = ((tk2dSpriteDefinition.tangents == null || tk2dSpriteDefinition.tangents.Length <= 0) ? new Vector4[0] : new Vector4[tk2dSpriteDefinition.tangents.Length]);
		}
		SetPositions(meshVertices, meshNormals, meshTangents);
		mesh.vertices = meshVertices;
		mesh.normals = meshNormals;
		mesh.tangents = meshTangents;
		mesh.uv = tk2dSpriteDefinition.uvs;
		mesh.bounds = GetBounds();
	}

	protected void UpdateGeometryImpl()
	{
		if (mesh == null)
		{
			Build();
		}
		tk2dSpriteDefinition tk2dSpriteDefinition = collection.spriteDefinitions[base.spriteId];
		if (meshVertices.Length != tk2dSpriteDefinition.positions.Length)
		{
			meshVertices = new Vector3[tk2dSpriteDefinition.positions.Length];
			meshNormals = ((tk2dSpriteDefinition.normals == null || tk2dSpriteDefinition.normals.Length <= 0) ? new Vector3[0] : new Vector3[tk2dSpriteDefinition.normals.Length]);
			meshTangents = ((tk2dSpriteDefinition.tangents == null || tk2dSpriteDefinition.tangents.Length <= 0) ? new Vector4[0] : new Vector4[tk2dSpriteDefinition.tangents.Length]);
			meshColors = new Color[tk2dSpriteDefinition.positions.Length];
		}
		SetPositions(meshVertices, meshNormals, meshTangents);
		SetColors(meshColors);
		mesh.Clear();
		mesh.vertices = meshVertices;
		mesh.normals = meshNormals;
		mesh.tangents = meshTangents;
		mesh.colors = meshColors;
		mesh.uv = tk2dSpriteDefinition.uvs;
		mesh.bounds = GetBounds();
		mesh.triangles = tk2dSpriteDefinition.indices;
	}

	protected override void UpdateMaterial()
	{
		if (GetComponent<Renderer>().sharedMaterial != collection.spriteDefinitions[base.spriteId].material)
		{
			GetComponent<Renderer>().material = collection.spriteDefinitions[base.spriteId].material;
		}
	}

	protected override int GetCurrentVertexCount()
	{
		if (meshVertices == null)
		{
			Build();
		}
		return meshVertices.Length;
	}
}
