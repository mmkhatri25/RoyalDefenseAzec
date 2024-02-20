using System.Collections.Generic;
using tk2dRuntime;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[AddComponentMenu("2D Toolkit/Sprite/tk2dStaticSpriteBatcher")]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class tk2dStaticSpriteBatcher : MonoBehaviour, ISpriteCollectionForceBuild
{
	public static int CURRENT_VERSION = 1;

	public int version;

	public tk2dBatchedSprite[] batchedSprites;

	public tk2dSpriteCollectionData spriteCollection;

	private Mesh mesh;

	private Mesh colliderMesh;

	[SerializeField]
	private Vector3 _scale = new Vector3(1f, 1f, 1f);

	private void Awake()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		Build();
	}

	private bool UpgradeData()
	{
		if (version == CURRENT_VERSION)
		{
			return false;
		}
		if (_scale == Vector3.zero)
		{
			_scale = Vector3.one;
		}
		version = CURRENT_VERSION;
		return true;
	}

	public void Build()
	{
		UpgradeData();
		if ((bool)mesh)
		{
			mesh.Clear();
		}
		if ((bool)colliderMesh)
		{
			UnityEngine.Object.Destroy(colliderMesh);
			colliderMesh = null;
		}
		if ((bool)spriteCollection && batchedSprites != null && batchedSprites.Length != 0)
		{
			BuildRenderMesh();
			BuildPhysicsMesh();
		}
	}

	private void SortBatchedSprites()
	{
		List<tk2dBatchedSprite> list = new List<tk2dBatchedSprite>();
		List<tk2dBatchedSprite> list2 = new List<tk2dBatchedSprite>();
		tk2dBatchedSprite[] array = batchedSprites;
		foreach (tk2dBatchedSprite tk2dBatchedSprite in array)
		{
			tk2dSpriteDefinition tk2dSpriteDefinition = spriteCollection.spriteDefinitions[tk2dBatchedSprite.spriteId];
			if (tk2dSpriteDefinition.material.renderQueue == 2000)
			{
				list.Add(tk2dBatchedSprite);
			}
			else
			{
				list2.Add(tk2dBatchedSprite);
			}
		}
		List<tk2dBatchedSprite> list3 = new List<tk2dBatchedSprite>(list.Count + list2.Count);
		list3.AddRange(list);
		list3.AddRange(list2);
		batchedSprites = list3.ToArray();
	}

	private void BuildRenderMesh()
	{
		List<Material> list = new List<Material>();
		List<List<int>> list2 = new List<List<int>>();
		int num = 0;
		tk2dBatchedSprite[] array = batchedSprites;
		foreach (tk2dBatchedSprite tk2dBatchedSprite in array)
		{
			tk2dSpriteDefinition tk2dSpriteDefinition = spriteCollection.spriteDefinitions[tk2dBatchedSprite.spriteId];
			num += tk2dSpriteDefinition.positions.Length;
		}
		Vector3[] array2 = new Vector3[num];
		Color[] array3 = new Color[num];
		Vector2[] array4 = new Vector2[num];
		int num2 = 0;
		int num3 = 0;
		Material material = null;
		List<int> list3 = null;
		SortBatchedSprites();
		tk2dBatchedSprite[] array5 = batchedSprites;
		foreach (tk2dBatchedSprite tk2dBatchedSprite2 in array5)
		{
			tk2dSpriteDefinition tk2dSpriteDefinition2 = spriteCollection.spriteDefinitions[tk2dBatchedSprite2.spriteId];
			if (tk2dSpriteDefinition2.material != material)
			{
				if (material != null)
				{
					list.Add(material);
					list2.Add(list3);
				}
				material = tk2dSpriteDefinition2.material;
				list3 = new List<int>();
			}
			Color color = tk2dBatchedSprite2.color;
			if (spriteCollection.premultipliedAlpha)
			{
				color.r *= color.a;
				color.g *= color.a;
				color.b *= color.a;
			}
			for (int k = 0; k < tk2dSpriteDefinition2.indices.Length; k++)
			{
				list3.Add(num2 + tk2dSpriteDefinition2.indices[k]);
			}
			for (int l = 0; l < tk2dSpriteDefinition2.positions.Length; l++)
			{
				Vector3 point = new Vector3(tk2dSpriteDefinition2.positions[l].x * tk2dBatchedSprite2.localScale.x, tk2dSpriteDefinition2.positions[l].y * tk2dBatchedSprite2.localScale.y, tk2dSpriteDefinition2.positions[l].z * tk2dBatchedSprite2.localScale.z);
				point = tk2dBatchedSprite2.rotation * point;
				point += tk2dBatchedSprite2.position;
				point = new Vector3(point.x * _scale.x, point.y * _scale.y, point.z * _scale.z);
				array2[num2 + l] = point;
				array4[num2 + l] = tk2dSpriteDefinition2.uvs[l];
				array3[num2 + l] = color;
			}
			num3 += tk2dSpriteDefinition2.indices.Length;
			num2 += tk2dSpriteDefinition2.positions.Length;
		}
		if (list3 != null)
		{
			list.Add(material);
			list2.Add(list3);
		}
		if ((bool)mesh)
		{
			mesh.vertices = array2;
			mesh.uv = array4;
			mesh.colors = array3;
			mesh.subMeshCount = list2.Count;
			for (int m = 0; m < list2.Count; m++)
			{
				mesh.SetTriangles(list2[m].ToArray(), m);
			}
			mesh.RecalculateBounds();
		}
		GetComponent<Renderer>().sharedMaterials = list.ToArray();
	}

	private void BuildPhysicsMesh()
	{
		MeshCollider meshCollider = GetComponent<MeshCollider>();
		if (meshCollider != null && GetComponent<Collider>() != meshCollider)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		tk2dBatchedSprite[] array = batchedSprites;
		foreach (tk2dBatchedSprite tk2dBatchedSprite in array)
		{
			tk2dSpriteDefinition tk2dSpriteDefinition = spriteCollection.spriteDefinitions[tk2dBatchedSprite.spriteId];
			if (tk2dSpriteDefinition.colliderType == tk2dSpriteDefinition.ColliderType.Box)
			{
				num += 24;
				num2 += 8;
			}
			else if (tk2dSpriteDefinition.colliderType == tk2dSpriteDefinition.ColliderType.Mesh)
			{
				num += tk2dSpriteDefinition.colliderIndicesFwd.Length;
				num2 += tk2dSpriteDefinition.colliderVertices.Length;
			}
		}
		if (num == 0)
		{
			if ((bool)colliderMesh)
			{
				UnityEngine.Object.Destroy(colliderMesh);
			}
			return;
		}
		if (meshCollider == null)
		{
			meshCollider = base.gameObject.AddComponent<MeshCollider>();
		}
		if (colliderMesh == null)
		{
			colliderMesh = new Mesh();
		}
		colliderMesh.Clear();
		int num3 = 0;
		Vector3[] array2 = new Vector3[num2];
		int num4 = 0;
		int[] array3 = new int[num];
		tk2dBatchedSprite[] array4 = batchedSprites;
		foreach (tk2dBatchedSprite tk2dBatchedSprite2 in array4)
		{
			tk2dSpriteDefinition tk2dSpriteDefinition2 = spriteCollection.spriteDefinitions[tk2dBatchedSprite2.spriteId];
			if (tk2dSpriteDefinition2.colliderType == tk2dSpriteDefinition.ColliderType.Box)
			{
				Vector3 a = new Vector3(tk2dSpriteDefinition2.colliderVertices[0].x * tk2dBatchedSprite2.localScale.x, tk2dSpriteDefinition2.colliderVertices[0].y * tk2dBatchedSprite2.localScale.y, tk2dSpriteDefinition2.colliderVertices[0].z * tk2dBatchedSprite2.localScale.z);
				Vector3 b = new Vector3(tk2dSpriteDefinition2.colliderVertices[1].x * tk2dBatchedSprite2.localScale.x, tk2dSpriteDefinition2.colliderVertices[1].y * tk2dBatchedSprite2.localScale.y, tk2dSpriteDefinition2.colliderVertices[1].z * tk2dBatchedSprite2.localScale.z);
				Vector3 vector = a - b;
				Vector3 vector2 = a + b;
				array2[num3] = tk2dBatchedSprite2.rotation * new Vector3(vector.x, vector.y, vector.z) + tk2dBatchedSprite2.position;
				array2[num3 + 1] = tk2dBatchedSprite2.rotation * new Vector3(vector.x, vector.y, vector2.z) + tk2dBatchedSprite2.position;
				array2[num3 + 2] = tk2dBatchedSprite2.rotation * new Vector3(vector2.x, vector.y, vector.z) + tk2dBatchedSprite2.position;
				array2[num3 + 3] = tk2dBatchedSprite2.rotation * new Vector3(vector2.x, vector.y, vector2.z) + tk2dBatchedSprite2.position;
				array2[num3 + 4] = tk2dBatchedSprite2.rotation * new Vector3(vector.x, vector2.y, vector.z) + tk2dBatchedSprite2.position;
				array2[num3 + 5] = tk2dBatchedSprite2.rotation * new Vector3(vector.x, vector2.y, vector2.z) + tk2dBatchedSprite2.position;
				array2[num3 + 6] = tk2dBatchedSprite2.rotation * new Vector3(vector2.x, vector2.y, vector.z) + tk2dBatchedSprite2.position;
				array2[num3 + 7] = tk2dBatchedSprite2.rotation * new Vector3(vector2.x, vector2.y, vector2.z) + tk2dBatchedSprite2.position;
				for (int k = 0; k < 8; k++)
				{
					Vector3 vector3 = array2[num3 + k];
					vector3 = new Vector3(vector3.x * _scale.x, vector3.y * _scale.y, vector3.z * _scale.z);
					array2[num3 + k] = vector3;
				}
				int[] array5 = new int[24]
				{
					0,
					1,
					2,
					2,
					1,
					3,
					6,
					5,
					4,
					7,
					5,
					6,
					3,
					7,
					6,
					2,
					3,
					6,
					4,
					5,
					1,
					4,
					1,
					0
				};
				int[] array6 = new int[24]
				{
					2,
					1,
					0,
					3,
					1,
					2,
					4,
					5,
					6,
					6,
					5,
					7,
					6,
					7,
					3,
					6,
					3,
					2,
					1,
					5,
					4,
					0,
					1,
					4
				};
				float num5 = tk2dBatchedSprite2.localScale.x * tk2dBatchedSprite2.localScale.y * tk2dBatchedSprite2.localScale.z;
				int[] array7 = (!(num5 >= 0f)) ? array5 : array6;
				for (int l = 0; l < array7.Length; l++)
				{
					array3[num4 + l] = num3 + array7[l];
				}
				num4 += 24;
				num3 += 8;
			}
			else if (tk2dSpriteDefinition2.colliderType == tk2dSpriteDefinition.ColliderType.Mesh)
			{
				for (int m = 0; m < tk2dSpriteDefinition2.colliderVertices.Length; m++)
				{
					Vector3 point = new Vector3(tk2dSpriteDefinition2.colliderVertices[m].x * tk2dBatchedSprite2.localScale.x, tk2dSpriteDefinition2.colliderVertices[m].y * tk2dBatchedSprite2.localScale.y, tk2dSpriteDefinition2.colliderVertices[m].z * tk2dBatchedSprite2.localScale.z);
					point = tk2dBatchedSprite2.rotation * point;
					point += tk2dBatchedSprite2.position;
					point = new Vector3(point.x * _scale.x, point.y * _scale.y, point.z * _scale.z);
					array2[num3 + m] = point;
				}
				float num6 = tk2dBatchedSprite2.localScale.x * tk2dBatchedSprite2.localScale.y * tk2dBatchedSprite2.localScale.z;
				int[] array8 = (!(num6 >= 0f)) ? tk2dSpriteDefinition2.colliderIndicesBack : tk2dSpriteDefinition2.colliderIndicesFwd;
				for (int n = 0; n < array8.Length; n++)
				{
					array3[num4 + n] = num3 + array8[n];
				}
				num4 += tk2dSpriteDefinition2.colliderIndicesFwd.Length;
				num3 += tk2dSpriteDefinition2.colliderVertices.Length;
			}
		}
		colliderMesh.vertices = array2;
		colliderMesh.triangles = array3;
		meshCollider.sharedMesh = colliderMesh;
	}

	public bool UsesSpriteCollection(tk2dSpriteCollectionData spriteCollection)
	{
		return this.spriteCollection == spriteCollection;
	}

	public void ForceBuild()
	{
		Build();
	}
}
