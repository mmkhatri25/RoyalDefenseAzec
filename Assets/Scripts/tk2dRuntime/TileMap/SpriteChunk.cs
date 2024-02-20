using System;
using UnityEngine;

namespace tk2dRuntime.TileMap
{
	[Serializable]
	public class SpriteChunk
	{
		private bool dirty;

		public int[] spriteIds;

		public GameObject gameObject;

		public Mesh mesh;

		public MeshCollider meshCollider;

		public Mesh colliderMesh;

		public bool Dirty
		{
			get
			{
				return dirty;
			}
			set
			{
				dirty = value;
			}
		}

		public bool IsEmpty => spriteIds.Length == 0;

		public bool HasGameData => gameObject != null || mesh != null || meshCollider != null || colliderMesh != null;

		public SpriteChunk()
		{
			spriteIds = new int[0];
		}

		public void DestroyGameData(tk2dTileMap tileMap)
		{
			if (mesh != null)
			{
				tileMap.DestroyMesh(mesh);
			}
			if (gameObject != null)
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
			gameObject = null;
			mesh = null;
			DestroyColliderData(tileMap);
		}

		public void DestroyColliderData(tk2dTileMap tileMap)
		{
			if (colliderMesh != null)
			{
				tileMap.DestroyMesh(colliderMesh);
			}
			if (meshCollider != null && meshCollider.sharedMesh != null && meshCollider.sharedMesh != colliderMesh)
			{
				tileMap.DestroyMesh(meshCollider.sharedMesh);
			}
			if (meshCollider != null)
			{
				UnityEngine.Object.DestroyImmediate(meshCollider);
			}
			meshCollider = null;
			colliderMesh = null;
		}
	}
}
