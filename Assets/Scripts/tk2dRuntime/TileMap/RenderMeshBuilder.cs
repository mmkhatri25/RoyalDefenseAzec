using System.Collections.Generic;
using UnityEngine;

namespace tk2dRuntime.TileMap
{
	public static class RenderMeshBuilder
	{
		public static void BuildForChunk(tk2dTileMap tileMap, SpriteChunk chunk, ColorChunk colorChunk, bool useColor, bool skipPrefabs, int baseX, int baseY)
		{
			List<Vector3> list = new List<Vector3>();
			List<Color> list2 = new List<Color>();
			List<Vector2> list3 = new List<Vector2>();
			int[] spriteIds = chunk.spriteIds;
			Vector3 tileSize = tileMap.data.tileSize;
			int num = tileMap.spriteCollection.spriteDefinitions.Length;
			Object[] tilePrefabs = tileMap.data.tilePrefabs;
			Color32 c = (!useColor || tileMap.ColorChannel == null) ? Color.white : tileMap.ColorChannel.clearColor;
			if (colorChunk == null || colorChunk.colors.Length == 0)
			{
				useColor = false;
			}
			BuilderUtil.GetLoopOrder(tileMap.data.sortMethod, tileMap.partitionSizeX, tileMap.partitionSizeY, out int x, out int x2, out int dx, out int y, out int y2, out int dy);
			List<int>[] array = new List<int>[tileMap.spriteCollection.materials.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new List<int>();
			}
			int num2 = tileMap.partitionSizeX + 1;
			for (int j = y; j != y2; j += dy)
			{
				for (int k = x; k != x2; k += dx)
				{
					int num3 = spriteIds[j * tileMap.partitionSizeX + k];
					Vector3 a = new Vector3(tileSize.x * (float)k, tileSize.y * (float)j, 0f);
					if (num3 < 0 || num3 >= num || (skipPrefabs && (bool)tilePrefabs[num3]))
					{
						continue;
					}
					tk2dSpriteDefinition tk2dSpriteDefinition = tileMap.spriteCollection.spriteDefinitions[num3];
					int count = list.Count;
					for (int l = 0; l < tk2dSpriteDefinition.positions.Length; l++)
					{
						if (useColor)
						{
							Color a2 = colorChunk.colors[j * num2 + k];
							Color b = colorChunk.colors[j * num2 + k + 1];
							Color a3 = colorChunk.colors[(j + 1) * num2 + k];
							Color b2 = colorChunk.colors[(j + 1) * num2 + (k + 1)];
							Vector3 a4 = tk2dSpriteDefinition.positions[l] - tk2dSpriteDefinition.untrimmedBoundsData[0];
							Vector3 vector = a4 + tileMap.data.tileSize * 0.5f;
							float t = Mathf.Clamp01(vector.x / tileMap.data.tileSize.x);
							float t2 = Mathf.Clamp01(vector.y / tileMap.data.tileSize.y);
							Color item = Color.Lerp(Color.Lerp(a2, b, t), Color.Lerp(a3, b2, t), t2);
							list2.Add(item);
						}
						else
						{
							list2.Add(c);
						}
						list.Add(a + tk2dSpriteDefinition.positions[l]);
						list3.Add(tk2dSpriteDefinition.uvs[l]);
					}
					List<int> list4 = array[tk2dSpriteDefinition.materialId];
					for (int m = 0; m < tk2dSpriteDefinition.indices.Length; m++)
					{
						list4.Add(count + tk2dSpriteDefinition.indices[m]);
					}
				}
			}
			if (chunk.mesh == null)
			{
				chunk.mesh = tileMap.GetOrCreateMesh();
			}
			chunk.mesh.vertices = list.ToArray();
			chunk.mesh.uv = list3.ToArray();
			chunk.mesh.colors = list2.ToArray();
			List<Material> list5 = new List<Material>();
			int num4 = 0;
			int num5 = 0;
			List<int>[] array2 = array;
			foreach (List<int> list6 in array2)
			{
				if (list6.Count > 0)
				{
					list5.Add(tileMap.spriteCollection.materials[num4]);
					num5++;
				}
				num4++;
			}
			if (num5 > 0)
			{
				chunk.mesh.subMeshCount = num5;
				chunk.gameObject.GetComponent<Renderer>().materials = list5.ToArray();
				int num6 = 0;
				List<int>[] array3 = array;
				foreach (List<int> list7 in array3)
				{
					if (list7.Count > 0)
					{
						chunk.mesh.SetTriangles(list7.ToArray(), num6);
						num6++;
					}
				}
			}
			chunk.mesh.RecalculateBounds();
			if (tileMap.serializeRenderData)
			{
				chunk.mesh.RecalculateNormals();
			}
			MeshFilter component = chunk.gameObject.GetComponent<MeshFilter>();
			component.sharedMesh = chunk.mesh;
		}

		public static void Build(tk2dTileMap tileMap, bool editMode, bool forceBuild)
		{
			bool skipPrefabs = (!editMode) ? true : false;
			bool flag = !forceBuild;
			int numLayers = tileMap.data.NumLayers;
			for (int i = 0; i < numLayers; i++)
			{
				Layer layer = tileMap.Layers[i];
				if (layer.IsEmpty)
				{
					continue;
				}
				bool useColor = !tileMap.ColorChannel.IsEmpty && tileMap.data.Layers[i].useColor;
				for (int j = 0; j < layer.numRows; j++)
				{
					int baseY = j * layer.divY;
					for (int k = 0; k < layer.numColumns; k++)
					{
						int baseX = k * layer.divX;
						SpriteChunk chunk = layer.GetChunk(k, j);
						ColorChunk chunk2 = tileMap.ColorChannel.GetChunk(k, j);
						bool flag2 = chunk2?.Dirty ?? false;
						if (flag && !flag2 && !chunk.Dirty)
						{
							continue;
						}
						if (chunk.mesh != null)
						{
							chunk.mesh.Clear();
						}
						if (!chunk.IsEmpty)
						{
							BuildForChunk(tileMap, chunk, chunk2, useColor, skipPrefabs, baseX, baseY);
							if (chunk.mesh != null)
							{
								tileMap.TouchMesh(chunk.mesh);
							}
						}
					}
				}
			}
		}
	}
}
