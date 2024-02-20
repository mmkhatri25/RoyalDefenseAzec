using System;
using UnityEngine;

namespace tk2dRuntime.TileMap
{
	[Serializable]
	public class ColorChannel
	{
		public Color clearColor = Color.white;

		public ColorChunk[] chunks;

		public int numColumns;

		public int numRows;

		public int divX;

		public int divY;

		public bool IsEmpty => chunks.Length == 0;

		public int NumActiveChunks
		{
			get
			{
				int num = 0;
				ColorChunk[] array = chunks;
				foreach (ColorChunk colorChunk in array)
				{
					if (colorChunk != null && colorChunk.colors != null && colorChunk.colors.Length > 0)
					{
						num++;
					}
				}
				return num;
			}
		}

		public ColorChannel(int width, int height, int divX, int divY)
		{
			Init(width, height, divX, divY);
		}

		public ColorChannel()
		{
			chunks = new ColorChunk[0];
		}

		public void Init(int width, int height, int divX, int divY)
		{
			numColumns = (width + divX - 1) / divX;
			numRows = (height + divY - 1) / divY;
			chunks = new ColorChunk[0];
			this.divX = divX;
			this.divY = divY;
		}

		public ColorChunk FindChunkAndCoordinate(int x, int y, out int offset)
		{
			int num = Mathf.Max(x - 1, 0) / divX;
			int num2 = Mathf.Max(y - 1, 0) / divY;
			int num3 = num2 * numColumns + num;
			ColorChunk result = chunks[num3];
			int num4 = x - num * divX;
			int num5 = y - num2 * divY;
			offset = num5 * (divX + 1) + num4;
			return result;
		}

		public Color GetColor(int x, int y)
		{
			if (IsEmpty)
			{
				return clearColor;
			}
			int offset;
			ColorChunk colorChunk = FindChunkAndCoordinate(x, y, out offset);
			if (colorChunk.colors.Length == 0)
			{
				return clearColor;
			}
			return colorChunk.colors[offset];
		}

		private void InitChunk(ColorChunk chunk)
		{
			if (chunk.colors.Length == 0)
			{
				chunk.colors = new Color32[(divX + 1) * (divY + 1)];
				for (int i = 0; i < chunk.colors.Length; i++)
				{
					chunk.colors[i] = clearColor;
				}
			}
		}

		public void SetColor(int x, int y, Color color)
		{
			if (IsEmpty)
			{
				Create();
			}
			int num = divX + 1;
			int num2 = Mathf.Max(x - 1, 0) / divX;
			int num3 = Mathf.Max(y - 1, 0) / divY;
			ColorChunk chunk = GetChunk(num2, num3, init: true);
			int num4 = x - num2 * divX;
			int num5 = y - num3 * divY;
			chunk.colors[num5 * num + num4] = color;
			chunk.Dirty = true;
			bool flag = false;
			bool flag2 = false;
			if (x != 0 && x % divX == 0 && num2 + 1 < numColumns)
			{
				flag = true;
			}
			if (y != 0 && y % divY == 0 && num3 + 1 < numRows)
			{
				flag2 = true;
			}
			if (flag)
			{
				int num6 = num2 + 1;
				chunk = GetChunk(num6, num3, init: true);
				num4 = x - num6 * divX;
				num5 = y - num3 * divY;
				chunk.colors[num5 * num + num4] = color;
			}
			if (flag2)
			{
				int num7 = num3 + 1;
				chunk = GetChunk(num2, num7, init: true);
				num4 = x - num2 * divX;
				num5 = y - num7 * divY;
				chunk.colors[num5 * num + num4] = color;
			}
			if (flag && flag2)
			{
				int num8 = num2 + 1;
				int num9 = num3 + 1;
				chunk = GetChunk(num8, num9, init: true);
				num4 = x - num8 * divX;
				num5 = y - num9 * divY;
				chunk.colors[num5 * num + num4] = color;
			}
		}

		public ColorChunk GetChunk(int x, int y)
		{
			if (chunks == null || chunks.Length == 0)
			{
				return null;
			}
			return chunks[y * numColumns + x];
		}

		public ColorChunk GetChunk(int x, int y, bool init)
		{
			if (chunks == null || chunks.Length == 0)
			{
				return null;
			}
			ColorChunk colorChunk = chunks[y * numColumns + x];
			InitChunk(colorChunk);
			return colorChunk;
		}

		public void ClearChunk(ColorChunk chunk)
		{
			for (int i = 0; i < chunk.colors.Length; i++)
			{
				chunk.colors[i] = clearColor;
			}
		}

		public void ClearDirtyFlag()
		{
			ColorChunk[] array = chunks;
			foreach (ColorChunk colorChunk in array)
			{
				colorChunk.Dirty = false;
			}
		}

		public void Clear(Color color)
		{
			clearColor = color;
			ColorChunk[] array = chunks;
			foreach (ColorChunk chunk in array)
			{
				ClearChunk(chunk);
			}
			Optimize();
		}

		public void Delete()
		{
			chunks = new ColorChunk[0];
		}

		public void Create()
		{
			chunks = new ColorChunk[numColumns * numRows];
			for (int i = 0; i < chunks.Length; i++)
			{
				chunks[i] = new ColorChunk();
			}
		}

		private void Optimize(ColorChunk chunk)
		{
			bool flag = true;
			Color32 color = clearColor;
			Color32[] colors = chunk.colors;
			for (int i = 0; i < colors.Length; i++)
			{
				Color32 color2 = colors[i];
				if (color2.r != color.r || color2.g != color.g || color2.b != color.b || color2.a != color.a)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				chunk.colors = new Color32[0];
			}
		}

		public void Optimize()
		{
			ColorChunk[] array = chunks;
			foreach (ColorChunk chunk in array)
			{
				Optimize(chunk);
			}
		}
	}
}
