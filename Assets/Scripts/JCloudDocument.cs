using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudDocument : MonoBehaviour
{
	public delegate void CloudDocumentExternalChangesCallbackFunction(JCloudDocumentExternalChange[] changes);

	private static CloudDocumentExternalChangesCallbackFunction externalChanges;

	public static bool AcceptJailbrokenDevices = true;

	public static CloudDocumentExternalChangesCallbackFunction ExternalChanges
	{
		get
		{
			JCloudManager.CheckManagerStatus();
			return externalChanges;
		}
		set
		{
			JCloudManager.CheckManagerStatus();
			externalChanges = value;
		}
	}

	public static JCloudDocumentOperation FileExists(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileExistsOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileDelete(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileDeleteOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileWriteAllBytes(string path, byte[] bytes)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileWriteAllBytesOperation(path, bytes, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileReadAllBytes(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileReadAllBytesOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileModificationDate(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileModificationDateOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileCopy(string sourcePath, string destinationPath, bool overwrite)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileCopyOperation(sourcePath, destinationPath, overwrite, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileMove(string sourcePath, string destinationPath, bool overwrite)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileMoveOperation(sourcePath, destinationPath, overwrite, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileHasConflictVersions(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileHasConflictVersionsOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileFetchAllVersions(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileFetchAllVersionsOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileReadVersionBytes(string path, byte[] uniqueIdentifier)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileReadVersionBytesOperation(path, uniqueIdentifier, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FilePickVersion(string path, byte[] uniqueIdentifier, string versionsHash)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FilePickVersionOperation(path, uniqueIdentifier, versionsHash, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation DirectoryCreate(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(DirectoryCreateOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation DirectoryExists(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(DirectoryExistsOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation DirectoryDelete(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(DirectoryDeleteOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation DirectoryGetFiles(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(DirectoryGetFilesOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation DirectoryGetDirectories(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(DirectoryGetDirectoriesOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation DirectoryModificationDate(string path)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(DirectoryModificationDateOperation(path, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation DirectoryCopy(string sourcePath, string destinationPath, bool overwrite)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(DirectoryCopyOperation(sourcePath, destinationPath, overwrite, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation DirectoryMove(string sourcePath, string destinationPath, bool overwrite)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(DirectoryMoveOperation(sourcePath, destinationPath, overwrite, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileCopyLocalToCloud(string path, bool overwrite)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileCopyLocalToCloudOperation(path, overwrite, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	public static JCloudDocumentOperation FileCopyCloudToLocal(string path, bool overwrite)
	{
		JCloudManager.CheckManagerStatus();
		JCloudDocumentOperation jCloudDocumentOperation = new JCloudDocumentOperation();
		JCloudManager.GetSharedManager().StartCoroutine(FileCopyCloudToLocalOperation(path, overwrite, jCloudDocumentOperation));
		return jCloudDocumentOperation;
	}

	protected static IEnumerator FileExistsOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			try
			{
				operation.result = File.Exists(JCloudManager.JCloudDocumentFallbackPath + path);
			}
			catch
			{
				operation.error = JCloudDocumentError.PluginError;
				operation.finished = true;
				yield break;
			}
			operation.success = true;
			operation.finished = true;
		}
	}

	protected static IEnumerator FileDeleteOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			if (!File.Exists(JCloudManager.JCloudDocumentFallbackPath + path))
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
				operation.finished = true;
				yield break;
			}
			File.Delete(JCloudManager.JCloudDocumentFallbackPath + path);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is DirectoryNotFoundException || e is FileNotFoundException)
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
			}
			else if (e is UnauthorizedAccessException || e is IOException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		operation.success = true;
		operation.result = true;
		operation.finished = true;
	}

	protected static IEnumerator FileWriteAllBytesOperation(string path, byte[] bytes, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			File.WriteAllBytes(JCloudManager.JCloudDocumentFallbackPath + path, bytes);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is UnauthorizedAccessException || e is IOException || e.GetType().FullName.Equals("System.Security.SecurityException") || e is DirectoryNotFoundException || e is FileNotFoundException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		operation.success = true;
		operation.result = true;
		operation.finished = true;
	}

	protected static IEnumerator FileReadAllBytesOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			try
			{
				operation.result = File.ReadAllBytes(JCloudManager.JCloudDocumentFallbackPath + path);
			}
			catch (Exception ex)
			{
				Exception e = ex;
				if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
				{
					operation.error = JCloudDocumentError.InvalidArguments;
				}
				else if (e is DirectoryNotFoundException || e is FileNotFoundException)
				{
					operation.error = JCloudDocumentError.DocumentNotFound;
				}
				else if (e is UnauthorizedAccessException || e is IOException || e.GetType().FullName.Equals("System.Security.SecurityException"))
				{
					operation.error = JCloudDocumentError.NativeError;
				}
				else
				{
					operation.error = JCloudDocumentError.PluginError;
				}
				operation.finished = true;
				yield break;
			}
			operation.success = true;
			operation.finished = true;
		}
	}

	protected static IEnumerator FileModificationDateOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			try
			{
				if (!File.Exists(JCloudManager.JCloudDocumentFallbackPath + path))
				{
					operation.error = JCloudDocumentError.DocumentNotFound;
					operation.finished = true;
					yield break;
				}
				operation.result = File.GetLastWriteTime(JCloudManager.JCloudDocumentFallbackPath + path);
			}
			catch (Exception ex)
			{
				Exception e = ex;
				if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
				{
					operation.error = JCloudDocumentError.InvalidArguments;
				}
				else if (e is IOException)
				{
					operation.error = JCloudDocumentError.DocumentNotFound;
				}
				else if (e is UnauthorizedAccessException)
				{
					operation.error = JCloudDocumentError.NativeError;
				}
				else
				{
					operation.error = JCloudDocumentError.PluginError;
				}
				operation.finished = true;
				yield break;
			}
			operation.success = true;
			operation.finished = true;
		}
	}

	protected static IEnumerator FileCopyOperation(string sourcePath, string destinationPath, bool overwrite, JCloudDocumentOperation operation)
	{
		if (sourcePath == null || sourcePath == string.Empty || destinationPath == null || destinationPath == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			if (File.Exists(JCloudManager.JCloudDocumentFallbackPath + destinationPath))
			{
				if (!overwrite)
				{
					operation.error = JCloudDocumentError.OverwriteError;
					operation.finished = true;
					yield break;
				}
				File.Copy(JCloudManager.JCloudDocumentFallbackPath + sourcePath, JCloudManager.JCloudDocumentFallbackPath + destinationPath, overwrite);
			}
			else
			{
				File.Copy(JCloudManager.JCloudDocumentFallbackPath + sourcePath, JCloudManager.JCloudDocumentFallbackPath + destinationPath, overwrite);
			}
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is FileNotFoundException)
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
			}
			else if (e is UnauthorizedAccessException || e is DirectoryNotFoundException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		operation.success = true;
		operation.result = true;
		operation.finished = true;
	}

	protected static IEnumerator FileMoveOperation(string sourcePath, string destinationPath, bool overwrite, JCloudDocumentOperation operation)
	{
		if (sourcePath == null || sourcePath == string.Empty || destinationPath == null || destinationPath == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			if (File.Exists(JCloudManager.JCloudDocumentFallbackPath + destinationPath))
			{
				if (!overwrite)
				{
					operation.finished = true;
					yield break;
				}
				File.Delete(JCloudManager.JCloudDocumentFallbackPath + destinationPath);
			}
			File.Move(JCloudManager.JCloudDocumentFallbackPath + sourcePath, JCloudManager.JCloudDocumentFallbackPath + destinationPath);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is FileNotFoundException)
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
			}
			else if (e is UnauthorizedAccessException || e is DirectoryNotFoundException || e is IOException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		operation.success = true;
		operation.result = true;
		operation.finished = true;
	}

	protected static IEnumerator FileHasConflictVersionsOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			operation.error = JCloudDocumentError.CloudUnavailable;
			operation.finished = true;
		}
		yield break;
	}

	protected static IEnumerator FileFetchAllVersionsOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			operation.error = JCloudDocumentError.CloudUnavailable;
			operation.finished = true;
		}
		yield break;
	}

	protected static IEnumerator FileReadVersionBytesOperation(string path, byte[] uniqueIdentifier, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty || uniqueIdentifier == null || uniqueIdentifier.Length == 0)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			operation.error = JCloudDocumentError.CloudUnavailable;
			operation.finished = true;
		}
		yield break;
	}

	protected static IEnumerator FilePickVersionOperation(string path, byte[] uniqueIdentifier, string versionsHash, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty || uniqueIdentifier == null || uniqueIdentifier.Length == 0 || versionsHash == null || versionsHash.Length == 0)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			operation.error = JCloudDocumentError.CloudUnavailable;
			operation.finished = true;
		}
		yield break;
	}

	protected static IEnumerator DirectoryCreateOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			Directory.CreateDirectory(JCloudManager.JCloudDocumentFallbackPath + path);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is UnauthorizedAccessException || e is IOException || e.GetType().FullName.Equals("System.Security.SecurityException") || e is DirectoryNotFoundException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		operation.success = true;
		operation.result = true;
		operation.finished = true;
	}

	protected static IEnumerator DirectoryExistsOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			try
			{
				operation.result = Directory.Exists(JCloudManager.JCloudDocumentFallbackPath + path);
			}
			catch
			{
				operation.error = JCloudDocumentError.PluginError;
				operation.finished = true;
				yield break;
			}
			operation.success = true;
			operation.finished = true;
		}
	}

	protected static IEnumerator DirectoryDeleteOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			if (!Directory.Exists(JCloudManager.JCloudDocumentFallbackPath + path))
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
				operation.finished = true;
				yield break;
			}
			Directory.Delete(JCloudManager.JCloudDocumentFallbackPath + path, recursive: true);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is DirectoryNotFoundException)
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
			}
			else if (e is UnauthorizedAccessException || e is IOException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		operation.success = true;
		operation.result = true;
		operation.finished = true;
	}

	protected static IEnumerator DirectoryGetFilesOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			operation.result = Directory.GetFiles(JCloudManager.JCloudDocumentFallbackPath + path);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is DirectoryNotFoundException)
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
			}
			else if (e is UnauthorizedAccessException || e is IOException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		List<string> trimmedFiles = new List<string>();
		string[] filenames = operation.result as string[];
		for (int i = 0; i < filenames.Length; i++)
		{
			trimmedFiles.Add(filenames[i].Remove(0, (JCloudManager.JCloudDocumentFallbackPath + path).Length));
		}
		operation.success = true;
		operation.result = trimmedFiles.ToArray();
		operation.finished = true;
	}

	protected static IEnumerator DirectoryGetDirectoriesOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			operation.result = Directory.GetDirectories(JCloudManager.JCloudDocumentFallbackPath + path);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is DirectoryNotFoundException)
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
			}
			else if (e is UnauthorizedAccessException || e is IOException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		List<string> trimmedDirectories = new List<string>();
		string[] directories = operation.result as string[];
		for (int i = 0; i < directories.Length; i++)
		{
			trimmedDirectories.Add(directories[i].Remove(0, (JCloudManager.JCloudDocumentFallbackPath + path).Length));
		}
		operation.success = true;
		operation.result = trimmedDirectories.ToArray();
		operation.finished = true;
	}

	protected static IEnumerator DirectoryModificationDateOperation(string path, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			try
			{
				if (!Directory.Exists(JCloudManager.JCloudDocumentFallbackPath + path))
				{
					operation.error = JCloudDocumentError.DocumentNotFound;
					operation.finished = true;
					yield break;
				}
				operation.result = Directory.GetLastWriteTime(JCloudManager.JCloudDocumentFallbackPath + path);
			}
			catch (Exception ex)
			{
				Exception e = ex;
				if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
				{
					operation.error = JCloudDocumentError.InvalidArguments;
				}
				else if (e is IOException)
				{
					operation.error = JCloudDocumentError.DocumentNotFound;
				}
				else if (e is UnauthorizedAccessException)
				{
					operation.error = JCloudDocumentError.NativeError;
				}
				else
				{
					operation.error = JCloudDocumentError.PluginError;
				}
				operation.finished = true;
				yield break;
			}
			operation.success = true;
			operation.finished = true;
		}
	}

	protected static IEnumerator DirectoryCopyOperation(string sourcePath, string destinationPath, bool overwrite, JCloudDocumentOperation operation)
	{
		if (sourcePath == null || sourcePath == string.Empty || destinationPath == null || destinationPath == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			if (!Directory.Exists(JCloudManager.JCloudDocumentFallbackPath + sourcePath))
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
				operation.finished = true;
				yield break;
			}
			if (Directory.Exists(JCloudManager.JCloudDocumentFallbackPath + destinationPath))
			{
				if (!overwrite)
				{
					operation.error = JCloudDocumentError.OverwriteError;
					operation.finished = true;
					yield break;
				}
				Directory.Delete(JCloudManager.JCloudDocumentFallbackPath + destinationPath);
			}
			JCloudManager.CopyDirectory(JCloudManager.JCloudDocumentFallbackPath + sourcePath, JCloudManager.JCloudDocumentFallbackPath + destinationPath);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is UnauthorizedAccessException || e is DirectoryNotFoundException || e is FileNotFoundException || e is IOException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		operation.success = true;
		operation.result = true;
		operation.finished = true;
	}

	protected static IEnumerator DirectoryMoveOperation(string sourcePath, string destinationPath, bool overwrite, JCloudDocumentOperation operation)
	{
		if (sourcePath == null || sourcePath == string.Empty || destinationPath == null || destinationPath == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
			yield break;
		}
		try
		{
			if (Directory.Exists(JCloudManager.JCloudDocumentFallbackPath + destinationPath))
			{
				if (!overwrite)
				{
					operation.error = JCloudDocumentError.OverwriteError;
					operation.finished = true;
					yield break;
				}
				Directory.Delete(JCloudManager.JCloudDocumentFallbackPath + destinationPath);
			}
			Directory.Move(JCloudManager.JCloudDocumentFallbackPath + sourcePath, JCloudManager.JCloudDocumentFallbackPath + destinationPath);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			if (e is ArgumentException || e is ArgumentNullException || e is NotSupportedException || e is PathTooLongException)
			{
				operation.error = JCloudDocumentError.InvalidArguments;
			}
			else if (e is DirectoryNotFoundException)
			{
				operation.error = JCloudDocumentError.DocumentNotFound;
			}
			else if (e is UnauthorizedAccessException || e is IOException)
			{
				operation.error = JCloudDocumentError.NativeError;
			}
			else
			{
				operation.error = JCloudDocumentError.PluginError;
			}
			operation.finished = true;
			yield break;
		}
		operation.success = true;
		operation.result = true;
		operation.finished = true;
	}

	protected static IEnumerator FileCopyCloudToLocalOperation(string path, bool overwrite, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			operation.error = JCloudDocumentError.InvalidPlatform;
			operation.finished = true;
		}
		yield break;
	}

	protected static IEnumerator FileCopyLocalToCloudOperation(string path, bool overwrite, JCloudDocumentOperation operation)
	{
		if (path == null || path == string.Empty)
		{
			operation.error = JCloudDocumentError.InvalidArguments;
			operation.finished = true;
		}
		else
		{
			operation.error = JCloudDocumentError.InvalidPlatform;
			operation.finished = true;
		}
		yield break;
	}

	public static void SetLocalToCloudPolicy(bool enabled)
	{
	}

	public static string GetLocalFallbackPath()
	{
		JCloudManager.CheckManagerStatus();
		return JCloudManager.JCloudDocumentFallbackPath;
	}

	public static bool SetLocalFallbackPath(string path)
	{
		if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
		{
			return false;
		}
		path = path.TrimEnd('/') + "/";
		JCloudManager.CheckManagerStatus();
		JCloudManager.JCloudDocumentFallbackPath = path;
		return true;
	}

	public static void UseCloudRootPath(bool enabled)
	{
		JCloudManager.CheckManagerStatus();
	}

	public static void IgnoreHiddenFiles(bool enabled)
	{
		JCloudManager.CheckManagerStatus();
	}

	public static bool PollCloudDocumentAvailability()
	{
		return false;
	}

	public static bool RegisterCloudDocumentExternalChanges(Component componentOrGameObject)
	{
		return false;
	}

	public static bool UnregisterCloudDocumentExternalChanges(Component componentOrGameObject)
	{
		return false;
	}
}
