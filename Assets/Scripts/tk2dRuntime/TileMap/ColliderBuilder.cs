using System;
using System.Collections.Generic;
using UnityEngine;

namespace tk2dRuntime.TileMap
{
	public static class ColliderBuilder
	{
		public static void Build(tk2dTileMap tileMap)
		{
			int num = tileMap.Layers.Length;
			for (int i = 0; i < num; i++)
			{
				Layer layer = tileMap.Layers[i];
				if (layer.IsEmpty || !tileMap.data.Layers[i].generateCollider)
				{
					continue;
				}
				for (int j = 0; j < layer.numRows; j++)
				{
					for (int k = 0; k < layer.numColumns; k++)
					{
						SpriteChunk chunk = layer.GetChunk(k, j);
						if (!chunk.IsEmpty)
						{
							BuildForChunk(tileMap, chunk);
						}
					}
				}
			}
		}

		public static void BuildForChunk(tk2dTileMap tileMap, SpriteChunk chunk)
		{
			Vector3[] vertices = new Vector3[0];
			int[] indices = new int[0];
			BuildLocalMeshForChunk(tileMap, chunk, ref vertices, ref indices);
			if (indices.Length > 6)
			{
				vertices = WeldVertices(vertices, ref indices);
				indices = RemoveDuplicateFaces(indices);
			}
			if (vertices.Length > 0)
			{
				if (chunk.colliderMesh != null)
				{
					UnityEngine.Object.DestroyImmediate(chunk.colliderMesh);
					chunk.colliderMesh = null;
				}
				if (chunk.meshCollider == null)
				{
					chunk.meshCollider = chunk.gameObject.GetComponent<MeshCollider>();
					if (chunk.meshCollider == null)
					{
						chunk.meshCollider = chunk.gameObject.AddComponent<MeshCollider>();
					}
				}
				chunk.colliderMesh = tileMap.GetOrCreateMesh();
				chunk.colliderMesh.vertices = vertices;
				chunk.colliderMesh.triangles = indices;
				chunk.colliderMesh.RecalculateBounds();
				if (tileMap.serializeRenderData)
				{
					chunk.mesh.RecalculateNormals();
				}
				chunk.meshCollider.sharedMesh = chunk.colliderMesh;
			}
			else
			{
				chunk.DestroyColliderData(tileMap);
			}
		}

		private static void BuildLocalMeshForChunk(tk2dTileMap tileMap, SpriteChunk chunk, ref Vector3[] vertices, ref int[] indices)
		{
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			int num = tileMap.spriteCollection.spriteDefinitions.Length;
			Vector3 tileSize = tileMap.data.tileSize;
			UnityEngine.Object[] tilePrefabs = tileMap.data.tilePrefabs;
			int[] spriteIds = chunk.spriteIds;
			for (int i = 0; i < tileMap.partitionSizeY; i++)
			{
				for (int j = 0; j < tileMap.partitionSizeX; j++)
				{
					int num2 = spriteIds[i * tileMap.partitionSizeX + j];
					Vector3 b = new Vector3(tileSize.x * (float)j, tileSize.y * (float)i, 0f);
					if (num2 < 0 || num2 >= num || (bool)tilePrefabs[num2])
					{
						continue;
					}
					tk2dSpriteDefinition tk2dSpriteDefinition = tileMap.spriteCollection.spriteDefinitions[num2];
					int count = list.Count;
					if (tk2dSpriteDefinition.colliderType == tk2dSpriteDefinition.ColliderType.Box)
					{
						Vector3 a = tk2dSpriteDefinition.colliderVertices[0] + b;
						Vector3 b2 = tk2dSpriteDefinition.colliderVertices[1];
						Vector3 vector = a - b2;
						Vector3 vector2 = a + b2;
						list.Add(new Vector3(vector.x, vector.y, vector.z));
						list.Add(new Vector3(vector.x, vector.y, vector2.z));
						list.Add(new Vector3(vector2.x, vector.y, vector.z));
						list.Add(new Vector3(vector2.x, vector.y, vector2.z));
						list.Add(new Vector3(vector.x, vector2.y, vector.z));
						list.Add(new Vector3(vector.x, vector2.y, vector2.z));
						list.Add(new Vector3(vector2.x, vector2.y, vector.z));
						list.Add(new Vector3(vector2.x, vector2.y, vector2.z));
						int[] array = new int[24]
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
						int[] array2 = array;
						for (int k = 0; k < array2.Length; k++)
						{
							list2.Add(count + array2[k]);
						}
					}
					else if (tk2dSpriteDefinition.colliderType == tk2dSpriteDefinition.ColliderType.Mesh)
					{
						for (int l = 0; l < tk2dSpriteDefinition.colliderVertices.Length; l++)
						{
							Vector3 item = tk2dSpriteDefinition.colliderVertices[l] + b;
							list.Add(item);
						}
						int[] colliderIndicesFwd = tk2dSpriteDefinition.colliderIndicesFwd;
						for (int m = 0; m < colliderIndicesFwd.Length; m++)
						{
							list2.Add(count + colliderIndicesFwd[m]);
						}
					}
				}
			}
			vertices = list.ToArray();
			indices = list2.ToArray();
		}

		private static int CompareWeldVertices(Vector3 a, Vector3 b)
		{
			float num = 0.01f;
			float f = a.x - b.x;
			if (Mathf.Abs(f) > num)
			{
				return (int)Mathf.Sign(f);
			}
			float f2 = a.y - b.y;
			if (Mathf.Abs(f2) > num)
			{
				return (int)Mathf.Sign(f2);
			}
			float f3 = a.z - b.z;
			if (Mathf.Abs(f3) > num)
			{
				return (int)Mathf.Sign(f3);
			}
			return 0;
		}

		private static Vector3[] WeldVertices(Vector3[] vertices, ref int[] indices)
		{
			int[] array = new int[vertices.Length];
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = i;
			}
			Array.Sort(array, (int a, int b) => CompareWeldVertices(vertices[a], vertices[b]));
			List<Vector3> list = new List<Vector3>();
			int[] array2 = new int[vertices.Length];
			Vector3 vector = vertices[array[0]];
			list.Add(vector);
			array2[array[0]] = list.Count - 1;
			for (int j = 1; j < array.Length; j++)
			{
				Vector3 vector2 = vertices[array[j]];
				if (CompareWeldVertices(vector2, vector) != 0)
				{
					vector = vector2;
					list.Add(vector);
					array2[array[j]] = list.Count - 1;
				}
				array2[array[j]] = list.Count - 1;
			}
			for (int k = 0; k < indices.Length; k++)
			{
				indices[k] = array2[indices[k]];
			}
			return list.ToArray();
		}

		private static int CompareDuplicateFaces(int[] indices, int face0index, int face1index)
		{
			for (int i = 0; i < 3; i++)
			{
				int num = indices[face0index + i] - indices[face1index + i];
				if (num != 0)
				{
					return num;
				}
			}
			return 0;
		}

		private static int[] RemoveDuplicateFaces(int[] indices)
		{
			int[] sortedFaceIndices = new int[indices.Length];
			for (int i = 0; i < indices.Length; i += 3)
			{
				int[] array = new int[3]
				{
					indices[i],
					indices[i + 1],
					indices[i + 2]
				};
				Array.Sort(array);
				sortedFaceIndices[i] = array[0];
				sortedFaceIndices[i + 1] = array[1];
				sortedFaceIndices[i + 2] = array[2];
			}
			int[] array2 = new int[indices.Length / 3];
			for (int j = 0; j < indices.Length; j += 3)
			{
				array2[j / 3] = j;
			}
			Array.Sort(array2, (int a, int b) => CompareDuplicateFaces(sortedFaceIndices, a, b));
			List<int> list = new List<int>();
			for (int k = 0; k < array2.Length; k++)
			{
				if (k != array2.Length - 1 && CompareDuplicateFaces(sortedFaceIndices, array2[k], array2[k + 1]) == 0)
				{
					k++;
					continue;
				}
				for (int l = 0; l < 3; l++)
				{
					list.Add(indices[array2[k] + l]);
				}
			}
			return list.ToArray();
		}
	}
}
