using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudManager : MonoBehaviour
{
	public struct DocumentStatus
	{
		public bool success;

		public JCloudDocumentError? error;
	}

	private struct DocumentLock
	{
		public int index;

		public int count;

		public DocumentLock(int index, int count)
		{
			this.index = index;
			this.count = count;
		}
	}

	public static string JCloudDocumentFallbackPath;

	public static bool persistentDataPathIsSet = false;

	public static Dictionary<int, JCloudDocumentState> documentState = new Dictionary<int, JCloudDocumentState>();

	public static Dictionary<int, DocumentStatus> documentStatus = new Dictionary<int, DocumentStatus>();

	public static Dictionary<int, float> documentProgress = new Dictionary<int, float>();

	public static Dictionary<int, int> documentAccess = new Dictionary<int, int>();

	private static Dictionary<int, DocumentLock> documentLock = new Dictionary<int, DocumentLock>();

	protected static JCloudManager sharedManager = null;

	protected static object checkLock = new object();

	public JCloudManager()
	{
		if (!persistentDataPathIsSet)
		{
			JCloudDocumentFallbackPath = Application.persistentDataPath + "/";
			persistentDataPathIsSet = true;
		}
	}

	public static bool PlatformIsCloudCompatible()
	{
		return false;
	}

	public static void CheckManagerStatus()
	{
		if (sharedManager == null)
		{
			lock (checkLock)
			{
				if (sharedManager == null)
				{
					GameObject gameObject = new GameObject("JCloudManager", typeof(JCloudManager));
					sharedManager = gameObject.GetComponent<JCloudManager>();
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
			}
		}
	}

	public static JCloudManager GetSharedManager()
	{
		if (sharedManager == null)
		{
			CheckManagerStatus();
		}
		return sharedManager;
	}

	public static void WatchDocument(int uid)
	{
		lock (documentState)
		{
			if (!documentAccess.ContainsKey(uid))
			{
				documentAccess.Add(uid, 1);
			}
			else
			{
				Dictionary<int, int> dictionary;
				Dictionary<int, int> dictionary2 = dictionary = documentAccess;
				int key;
				int key2 = key = uid;
				key = dictionary[key];
				dictionary2[key2] = key + 1;
			}
			if (!documentState.ContainsKey(uid))
			{
				documentState.Add(uid, JCloudDocumentState.JCloudDocumentStateOpening);
			}
		}
	}

	public static JCloudDocumentState GetDocumentState(int uid)
	{
		lock (documentState)
		{
			if (documentState.ContainsKey(uid))
			{
				return documentState[uid];
			}
			return JCloudDocumentState.JCloudDocumentStateClosed;
			IL_0034:
			JCloudDocumentState result;
			return result;
		}
	}

	public static void UnwatchDocument(int uid)
	{
		lock (documentState)
		{
			if (documentAccess.ContainsKey(uid))
			{
				Dictionary<int, int> dictionary;
				Dictionary<int, int> dictionary2 = dictionary = documentAccess;
				int key;
				int key2 = key = uid;
				key = dictionary[key];
				dictionary2[key2] = key - 1;
				if (documentStatus.ContainsKey(uid))
				{
					documentStatus.Remove(uid);
				}
				if (documentProgress.ContainsKey(uid))
				{
					documentProgress.Remove(uid);
				}
				if (documentAccess[uid] == 0)
				{
					if (documentState.ContainsKey(uid))
					{
						documentState.Remove(uid);
					}
					documentAccess.Remove(uid);
				}
			}
			else
			{
				if (documentState.ContainsKey(uid))
				{
					documentState.Remove(uid);
				}
				if (documentStatus.ContainsKey(uid))
				{
					documentStatus.Remove(uid);
				}
				if (documentProgress.ContainsKey(uid))
				{
					documentProgress.Remove(uid);
				}
			}
		}
	}

	public static bool GetDocumentStatus(int uid, out DocumentStatus? status)
	{
		lock (documentState)
		{
			if (documentStatus.ContainsKey(uid))
			{
				status = documentStatus[uid];
				return true;
			}
		}
		status = null;
		return false;
	}

	public static bool GetDocumentProgress(int uid, out float progress)
	{
		lock (documentState)
		{
			if (documentProgress.ContainsKey(uid))
			{
				progress = documentProgress[uid];
				return true;
			}
		}
		progress = 0f;
		return false;
	}

	public static int GetDocumentLock(int uid)
	{
		lock (documentLock)
		{
			if (documentLock.ContainsKey(uid))
			{
				DocumentLock value = documentLock[uid];
				int result = value.count++;
				documentLock[uid] = value;
				return result;
			}
			documentLock.Add(uid, new DocumentLock(0, 1));
			return 0;
			IL_0069:
			int result2;
			return result2;
		}
	}

	public static bool CheckDocumentLock(int uid, int lockId)
	{
		lock (JCloudManager.documentLock)
		{
			if (JCloudManager.documentLock.ContainsKey(uid))
			{
				DocumentLock documentLock = JCloudManager.documentLock[uid];
				return lockId == documentLock.index;
			}
			return false;
			IL_003f:
			bool result;
			return result;
		}
	}

	public static void ReleaseDocumentLock(int uid)
	{
		lock (documentLock)
		{
			if (documentLock.ContainsKey(uid))
			{
				DocumentLock value = documentLock[uid];
				value.index++;
				if (value.index == value.count)
				{
					documentLock.Remove(uid);
				}
				else
				{
					documentLock[uid] = value;
				}
			}
		}
	}

	public static string[] PathListFromBytes(byte[] bytes, bool directories)
	{
		if (bytes == null)
		{
			return null;
		}
		uint num = BitConverter.ToUInt32(bytes, 0);
		List<string> list = new List<string>();
		uint num2 = 4u;
		for (uint num3 = 0u; num3 < num; num3++)
		{
			bool flag = BitConverter.ToBoolean(bytes, (int)num2);
			num2++;
			uint num4 = BitConverter.ToUInt32(bytes, (int)num2);
			num2 += 4;
			if (flag == directories)
			{
				UTF8Encoding uTF8Encoding = new UTF8Encoding();
				list.Add(uTF8Encoding.GetString(bytes, (int)num2, (int)num4));
			}
			num2 += num4;
		}
		return list.ToArray();
	}

	public static void CopyDirectory(string src, string dst)
	{
		if (dst[dst.Length - 1] != Path.DirectorySeparatorChar)
		{
			dst += Path.DirectorySeparatorChar;
		}
		if (!Directory.Exists(dst))
		{
			Directory.CreateDirectory(dst);
		}
		string[] fileSystemEntries = Directory.GetFileSystemEntries(src);
		for (int i = 0; i < fileSystemEntries.Length; i++)
		{
			if (Directory.Exists(fileSystemEntries[i]))
			{
				CopyDirectory(fileSystemEntries[i], dst + Path.GetFileName(fileSystemEntries[i]));
			}
			else
			{
				File.Copy(fileSystemEntries[i], dst + Path.GetFileName(fileSystemEntries[i]), overwrite: true);
			}
		}
	}
}
