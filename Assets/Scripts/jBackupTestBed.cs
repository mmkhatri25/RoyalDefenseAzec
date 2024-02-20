using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;

[AddComponentMenu("")]
public class jBackupTestBed : MonoBehaviour
{
	private string documentResultString = string.Empty;

	private bool localToCloudPolicy = true;

	private void OnGUI()
	{
		float num = Screen.width;
		float num2 = Screen.height / 19;
		if (GUI.Button(new Rect(0f, 0f, num * 0.5f, num2), "Write All Bytes To Test File"))
		{
			StartCoroutine(FileWriteAllBytes());
		}
		if (GUI.Button(new Rect(0f, num2, num * 0.5f, num2), "Read All Bytes From Test File"))
		{
			StartCoroutine(FileReadAllBytes());
		}
		if (GUI.Button(new Rect(0f, num2 * 2f, num * 0.5f, num2), "Delete Test File"))
		{
			StartCoroutine(FileDelete());
		}
		if (GUI.Button(new Rect(0f, num2 * 3f, num * 0.5f, num2), "Get Test File Modification Date"))
		{
			StartCoroutine(FileModificationDate());
		}
		if (GUI.Button(new Rect(0f, num2 * 4f, num * 0.5f, num2), "Check Test File Exists"))
		{
			StartCoroutine(FileExists());
		}
		if (GUI.Button(new Rect(0f, num2 * 5f, num * 0.5f, num2), "Copy Test File"))
		{
			StartCoroutine(FileCopy());
		}
		if (GUI.Button(new Rect(0f, num2 * 6f, num * 0.5f, num2), "Write All Bytes To Test File (Conflict)"))
		{
			StartCoroutine(FileWriteAllBytesConflict());
		}
		if (GUI.Button(new Rect(0f, num2 * 7f, num * 0.5f, num2), "Check Test File Has Conflict Versions"))
		{
			StartCoroutine(FileHasConflictVersions());
		}
		if (GUI.Button(new Rect(0f, num2 * 8f, num * 0.5f, num2), "Fetch File Fetch All Versions"))
		{
			StartCoroutine(FileFetchAllVersions());
		}
		if (GUI.Button(new Rect(0f, num2 * 9f, num * 0.5f, num2), "Read Conflict Version Bytes From Test File"))
		{
			StartCoroutine(FileReadConflictVersionBytes());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 9f, num * 0.5f, num2), "Pick Conflict Version From Test File"))
		{
			StartCoroutine(FilePickConflictVersion());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 8f, num * 0.5f, num2), "Pick Current Version From Test File"))
		{
			StartCoroutine(FilePickCurrentVersion());
		}
		if (GUI.Button(new Rect(0f, num2 * 10f, num * 0.5f, num2), "Poll Cloud Document Availability"))
		{
			documentResultString = "cloud document " + ((!JCloudDocument.PollCloudDocumentAvailability()) ? "unavailable" : "available");
		}
		if (GUI.Button(new Rect(num * 0.5f, 0f, num * 0.5f, num2), "Create Test Directory"))
		{
			StartCoroutine(DirectoryCreate());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2, num * 0.5f, num2), "Check Test Directory Exists"))
		{
			StartCoroutine(DirectoryExists());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 2f, num * 0.5f, num2), "Delete Test Directory"))
		{
			StartCoroutine(DirectoryDelete());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 3f, num * 0.5f, num2), "Get Test Directory Modification Date"))
		{
			StartCoroutine(DirectoryModificationDate());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 4f, num * 0.5f, num2), "List Top Directory Files"))
		{
			StartCoroutine(DirectoryGetFiles());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 5f, num * 0.5f, num2), "List Top Directory Folders"))
		{
			StartCoroutine(DirectoryGetDirectories());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 6f, num * 0.5f, num2), "Copy Test Directory"))
		{
			StartCoroutine(DirectoryCopy());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 7f, num * 0.5f, num2), "Register Cloud Document changes"))
		{
			documentResultString = "now watching cloud document changes";
			JCloudDocument.ExternalChanges = (JCloudDocument.CloudDocumentExternalChangesCallbackFunction)Delegate.Combine(JCloudDocument.ExternalChanges, new JCloudDocument.CloudDocumentExternalChangesCallbackFunction(JCloudDocumentDidChangeExternally));
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 10f, num * 0.5f, num2), "Clear Resultats"))
		{
			documentResultString = string.Empty;
		}
		if (GUI.Button(new Rect(0f, num2 * 11f, num * 0.5f, num2), "Write All Bytes to Local Test File"))
		{
			File.WriteAllText(JCloudDocument.GetLocalFallbackPath() + "testfile.txt", "this is a local test file");
			documentResultString = "created local file";
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 11f, num * 0.5f, num2), "Read All Bytes from Local Test File"))
		{
			if (File.Exists(JCloudDocument.GetLocalFallbackPath() + "testfile.txt"))
			{
				documentResultString = "local document did read bytes ; read this : " + File.ReadAllText(JCloudDocument.GetLocalFallbackPath() + "testfile.txt");
			}
			else
			{
				documentResultString = "file not found";
			}
		}
		if (GUI.Button(new Rect(0f, num2 * 12f, num * 0.5f, num2), "Delete Local Test File"))
		{
			if (File.Exists(JCloudDocument.GetLocalFallbackPath() + "testfile.txt"))
			{
				File.Delete(JCloudDocument.GetLocalFallbackPath() + "testfile.txt");
				documentResultString = "deleted local file";
			}
			else
			{
				documentResultString = "file not found";
			}
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 12f, num * 0.5f, num2), "Check Local Test File Exists"))
		{
			documentResultString = "local file exists: " + ((!File.Exists(JCloudDocument.GetLocalFallbackPath() + "testfile.txt")) ? "no" : "yes");
		}
		if (GUI.Button(new Rect(0f, num2 * 13f, num * 0.5f, num2), "Toggle Local To Cloud Policy"))
		{
			localToCloudPolicy = !localToCloudPolicy;
			JCloudDocument.SetLocalToCloudPolicy(localToCloudPolicy);
			documentResultString = "local to cloud policy " + ((!localToCloudPolicy) ? "disabled" : "enabled");
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 13f, num * 0.5f, num2), "Get Local Test File Modification Date"))
		{
			if (File.Exists(JCloudDocument.GetLocalFallbackPath() + "testfile.txt"))
			{
				documentResultString = "local file modification date: " + File.GetLastWriteTime(JCloudDocument.GetLocalFallbackPath() + "testfile.txt").ToString("MM-dd-yyyy HH:mm:ss");
			}
			else
			{
				documentResultString = "file not found";
			}
		}
		if (GUI.Button(new Rect(0f, num2 * 14f, num * 0.5f, num2), "Get Local Directory Path"))
		{
			documentResultString = JCloudDocument.GetLocalFallbackPath();
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 14f, num * 0.5f, num2), "Get Persistent Data Path"))
		{
			documentResultString = Application.persistentDataPath + "/";
		}
		if (GUI.Button(new Rect(0f, num2 * 15f, num * 0.5f, num2), "Copy Local Test File To Cloud"))
		{
			StartCoroutine(CopyLocalToCloud());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 15f, num * 0.5f, num2), "Copy Cloud Test File To Local"))
		{
			StartCoroutine(CopyCloudToLocal());
		}
		if (GUI.Button(new Rect(0f, num2 * 16f, num * 0.5f, num2), "Copy Local Test File To Cloud (no overwrite)"))
		{
			StartCoroutine(CopyLocalToCloudNoOverwrite());
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 16f, num * 0.5f, num2), "Copy Cloud Test File To Local (no overwrite)"))
		{
			StartCoroutine(CopyCloudToLocalNoOverwrite());
		}
		if (GUI.Button(new Rect(0f, num2 * 17f, num * 0.5f, num2), "Set Fallback Path To Persitent Data Path"))
		{
			JCloudDocument.SetLocalFallbackPath(Application.persistentDataPath);
			documentResultString = "did set fallback path to: " + Application.persistentDataPath + "/";
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 17f, num * 0.5f, num2), "Attempt write local->read iCloud->delete"))
		{
			StartCoroutine(WRDOperation());
		}
		GUI.Label(new Rect(0f, num2 * 18f, num, num2 * 1.5f), "Document Result : " + documentResultString);
	}

	private IEnumerator WRDOperation()
	{
		File.WriteAllText(JCloudDocument.GetLocalFallbackPath() + "testfile.txt", "this is a local test file");
		JCloudDocumentOperation operation2 = JCloudDocument.FileReadAllBytes("testfile.txt");
		while (!operation2.finished)
		{
			documentResultString = "cloud document read bytes progress : " + operation2.progress;
			yield return null;
		}
		UTF8Encoding encoder = new UTF8Encoding();
		if (operation2.success)
		{
			string str = (operation2.result != null) ? encoder.GetString(operation2.result as byte[]) : "(null)";
			JCloudDocumentError? error = operation2.error;
			documentResultString = "cloud document did read bytes ; read this : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation2.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation2.error;
			documentResultString = "cloud document read bytes : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation2.error));
		}
		documentResultString += " ; ";
		operation2 = JCloudDocument.FileDelete("testfile.txt");
		while (!operation2.finished)
		{
			yield return null;
		}
		if (operation2.success && (bool)operation2.result)
		{
			string str2 = documentResultString;
			JCloudDocumentError? error3 = operation2.error;
			documentResultString = str2 + "cloud document did delete" + ((!error3.HasValue) ? string.Empty : (" ; error : " + operation2.error));
		}
		else
		{
			string str3 = documentResultString;
			JCloudDocumentError? error4 = operation2.error;
			documentResultString = str3 + "cloud document did not delete (may not exist?)" + ((!error4.HasValue) ? string.Empty : (" ; error : " + operation2.error));
		}
	}

	private IEnumerator CopyLocalToCloud()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileCopyLocalToCloud("testfile.txt", overwrite: true);
		while (!operation.finished)
		{
			documentResultString = "copy local to cloud progress : " + operation.progress;
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "copy local to cloud : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "copy local to cloud : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator CopyCloudToLocal()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileCopyCloudToLocal("testfile.txt", overwrite: true);
		while (!operation.finished)
		{
			documentResultString = "copy cloud to local progress : " + operation.progress;
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "copy cloud to local : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "copy cloud to local : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator CopyLocalToCloudNoOverwrite()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileCopyLocalToCloud("testfile.txt", overwrite: false);
		while (!operation.finished)
		{
			documentResultString = "copy local to cloud progress : " + operation.progress;
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "copy local to cloud : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "copy local to cloud : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator CopyCloudToLocalNoOverwrite()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileCopyCloudToLocal("testfile.txt", overwrite: false);
		while (!operation.finished)
		{
			documentResultString = "copy cloud to local progress : " + operation.progress;
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "copy cloud to local : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "copy cloud to local : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FileWriteAllBytes()
	{
		UTF8Encoding encoder = new UTF8Encoding();
		JCloudDocumentOperation operation = JCloudDocument.FileWriteAllBytes("testfile.txt", encoder.GetBytes("this is a cloud test file"));
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "cloud document did write bytes with : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document write all bytes failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FileReadAllBytes()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileReadAllBytes("testfile.txt");
		while (!operation.finished)
		{
			documentResultString = "cloud document read bytes progress : " + operation.progress;
			yield return null;
		}
		UTF8Encoding encoder = new UTF8Encoding();
		if (operation.success)
		{
			string str = (operation.result != null) ? encoder.GetString(operation.result as byte[]) : "(null)";
			JCloudDocumentError? error = operation.error;
			documentResultString = "cloud document did read bytes ; read this : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document read bytes : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FileDelete()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileDelete("testfile.txt");
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success && (bool)operation.result)
		{
			JCloudDocumentError? error = operation.error;
			documentResultString = "cloud document did delete" + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document did not delete (may not exist?)" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FileModificationDate()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileModificationDate("testfile.txt");
		while (!operation.finished)
		{
			yield return null;
		}
		string str = (!operation.success) ? "failure" : ((DateTime)operation.result).ToString("MM-dd-yyyy HH:mm:ss");
		JCloudDocumentError? error = operation.error;
		documentResultString = "cloud document test file modification date : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
	}

	private IEnumerator FileExists()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileExists("testfile.txt");
		while (!operation.finished)
		{
			yield return null;
		}
		string str = (!(bool)operation.result) ? "does not exist" : "exists";
		JCloudDocumentError? error = operation.error;
		documentResultString = "cloud document test file exists : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
	}

	private IEnumerator FileCopy()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileCopy("testfile.txt", "testfile copy.txt", overwrite: true);
		while (!operation.finished)
		{
			documentResultString = "cloud document test file copy progress : " + operation.progress;
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "cloud document test file copy : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document test file copy : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FileWriteAllBytesConflict()
	{
		UTF8Encoding encoder = new UTF8Encoding();
		JCloudDocumentOperation operation = JCloudDocument.FileWriteAllBytes("testfile.txt", encoder.GetBytes("this is a conflict test content"));
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "cloud document did write bytes with : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document write all bytes failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FileHasConflictVersions()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileHasConflictVersions("testfile.txt");
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "no" : "yes";
			JCloudDocumentError? error = operation.error;
			documentResultString = "cloud document test file has conflict versions : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document test file has conflict versions : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FileFetchAllVersions()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileFetchAllVersions("testfile.txt");
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success && operation.result != null)
		{
			JCloudDocumentVersions versions = (JCloudDocumentVersions)operation.result;
			documentResultString = "cloud document test file versions :";
			int offset = 1;
			JCloudDocumentVersionMetadata[] versionsMetadata = versions.versionsMetadata;
			string text;
			for (int i = 0; i < versionsMetadata.Length; i++)
			{
				JCloudDocumentVersionMetadata metadata = versionsMetadata[i];
				text = documentResultString;
				documentResultString = text + " " + offset + ". " + metadata.modificationDate + ((!metadata.isCurrent) ? string.Empty : " (current)");
				offset++;
			}
			text = documentResultString;
			string[] obj = new string[5]
			{
				text,
				" (hash : ",
				versions.versionsHash,
				")",
				null
			};
			JCloudDocumentError? error = operation.error;
			obj[4] = ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
			documentResultString = string.Concat(obj);
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document test file versions : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FileReadConflictVersionBytes()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileFetchAllVersions("testfile.txt");
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success && operation.result != null)
		{
			JCloudDocumentVersions versions = (JCloudDocumentVersions)operation.result;
			JCloudDocumentVersionMetadata? conflictVersionMetadata = null;
			JCloudDocumentVersionMetadata[] versionsMetadata = versions.versionsMetadata;
			for (int i = 0; i < versionsMetadata.Length; i++)
			{
				JCloudDocumentVersionMetadata metadata = versionsMetadata[i];
				if (!metadata.isCurrent)
				{
					conflictVersionMetadata = metadata;
					break;
				}
			}
			if (conflictVersionMetadata.HasValue)
			{
				JCloudDocumentVersionMetadata value = conflictVersionMetadata.Value;
				operation = JCloudDocument.FileReadVersionBytes("testfile.txt", value.uniqueIdentifier);
				while (!operation.finished)
				{
					documentResultString = "cloud document read conflict version bytes progress : " + operation.progress;
					yield return null;
				}
				UTF8Encoding encoder = new UTF8Encoding();
				if (operation.success)
				{
					string str = (operation.result != null) ? encoder.GetString(operation.result as byte[]) : "(null)";
					JCloudDocumentError? error = operation.error;
					documentResultString = "cloud document did read conflict version bytes ; read this : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
				}
				else
				{
					JCloudDocumentError? error2 = operation.error;
					documentResultString = "cloud document read conflict version bytes : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
				}
			}
			else
			{
				JCloudDocumentError? error3 = operation.error;
				documentResultString = "cloud document read conflict version bytes : failure" + ((!error3.HasValue) ? string.Empty : (" ; error : " + operation.error)) + " (found no conflict version)";
			}
		}
		else
		{
			JCloudDocumentError? error4 = operation.error;
			documentResultString = "cloud document read conflict version bytes : failure" + ((!error4.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FilePickConflictVersion()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileFetchAllVersions("testfile.txt");
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success && operation.result != null)
		{
			JCloudDocumentVersions versions = (JCloudDocumentVersions)operation.result;
			JCloudDocumentVersionMetadata? conflictVersionMetadata = null;
			JCloudDocumentVersionMetadata[] versionsMetadata = versions.versionsMetadata;
			for (int i = 0; i < versionsMetadata.Length; i++)
			{
				JCloudDocumentVersionMetadata metadata = versionsMetadata[i];
				if (!metadata.isCurrent)
				{
					conflictVersionMetadata = metadata;
					break;
				}
			}
			if (conflictVersionMetadata.HasValue)
			{
				JCloudDocumentVersionMetadata value = conflictVersionMetadata.Value;
				operation = JCloudDocument.FilePickVersion("testfile.txt", value.uniqueIdentifier, versions.versionsHash);
				while (!operation.finished)
				{
					yield return null;
				}
				if (operation.success)
				{
					string str = (!(bool)operation.result) ? "failure" : "success";
					JCloudDocumentError? error = operation.error;
					documentResultString = "cloud document did pick conflict version : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
				}
				else
				{
					JCloudDocumentError? error2 = operation.error;
					documentResultString = "cloud document did pick conflict version : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
				}
			}
			else
			{
				JCloudDocumentError? error3 = operation.error;
				documentResultString = "cloud document did pick conflict version : failure" + ((!error3.HasValue) ? string.Empty : (" ; error : " + operation.error)) + " (found no conflict version)";
			}
		}
		else
		{
			JCloudDocumentError? error4 = operation.error;
			documentResultString = "cloud document did pick conflict version : failure" + ((!error4.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator FilePickCurrentVersion()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileFetchAllVersions("testfile.txt");
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success && operation.result != null)
		{
			JCloudDocumentVersions versions = (JCloudDocumentVersions)operation.result;
			JCloudDocumentVersionMetadata? currentVersionMetadata = null;
			JCloudDocumentVersionMetadata[] versionsMetadata = versions.versionsMetadata;
			for (int i = 0; i < versionsMetadata.Length; i++)
			{
				JCloudDocumentVersionMetadata metadata = versionsMetadata[i];
				if (metadata.isCurrent)
				{
					currentVersionMetadata = metadata;
					break;
				}
			}
			if (currentVersionMetadata.HasValue)
			{
				JCloudDocumentVersionMetadata value = currentVersionMetadata.Value;
				operation = JCloudDocument.FilePickVersion("testfile.txt", value.uniqueIdentifier, versions.versionsHash);
				while (!operation.finished)
				{
					yield return null;
				}
				if (operation.success)
				{
					string str = (!(bool)operation.result) ? "failure" : "success";
					JCloudDocumentError? error = operation.error;
					documentResultString = "cloud document did pick current version : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
				}
				else
				{
					JCloudDocumentError? error2 = operation.error;
					documentResultString = "cloud document did pick current version : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
				}
			}
			else
			{
				JCloudDocumentError? error3 = operation.error;
				documentResultString = "cloud document did pick current version : failure" + ((!error3.HasValue) ? string.Empty : (" ; error : " + operation.error)) + " (found no current version)";
			}
		}
		else
		{
			JCloudDocumentError? error4 = operation.error;
			documentResultString = "cloud document did pick current version : failure" + ((!error4.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator DirectoryCreate()
	{
		JCloudDocumentOperation operation = JCloudDocument.DirectoryCreate("Test");
		while (!operation.finished)
		{
			yield return null;
		}
		string str = (!(bool)operation.result) ? "failure" : "success";
		JCloudDocumentError? error = operation.error;
		documentResultString = "cloud document did create test directory with " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
	}

	private IEnumerator DirectoryExists()
	{
		JCloudDocumentOperation operation = JCloudDocument.DirectoryExists("Test");
		while (!operation.finished)
		{
			yield return null;
		}
		string str = (!(bool)operation.result) ? "does not exist" : "exists";
		JCloudDocumentError? error = operation.error;
		documentResultString = "cloud document test directory exists : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
	}

	private IEnumerator DirectoryDelete()
	{
		JCloudDocumentOperation operation = JCloudDocument.DirectoryDelete("Test");
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "cloud document test directory deleted : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document test directory deleted : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator DirectoryModificationDate()
	{
		JCloudDocumentOperation operation = JCloudDocument.DirectoryModificationDate("Test");
		while (!operation.finished)
		{
			yield return null;
		}
		string str = (!operation.success) ? "failure" : ((DateTime)operation.result).ToString("MM-dd-yyyy HH:mm:ss");
		JCloudDocumentError? error = operation.error;
		documentResultString = "cloud document test directory modification date : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
	}

	private IEnumerator DirectoryGetFiles()
	{
		JCloudDocumentOperation operation = JCloudDocument.DirectoryGetFiles(string.Empty);
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success)
		{
			documentResultString = "cloud directory files list : " + (operation.result as string[]).Length;
			for (int i = 0; i < (operation.result as string[]).Length; i++)
			{
				documentResultString = documentResultString + " ; " + (operation.result as string[])[i];
			}
			string str = documentResultString;
			JCloudDocumentError? error = operation.error;
			documentResultString = str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud directory files list : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator DirectoryGetDirectories()
	{
		JCloudDocumentOperation operation = JCloudDocument.DirectoryGetDirectories(string.Empty);
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.success)
		{
			documentResultString = "cloud directory directories list : " + (operation.result as string[]).Length;
			for (int i = 0; i < (operation.result as string[]).Length; i++)
			{
				documentResultString = documentResultString + " ; " + (operation.result as string[])[i];
			}
			string str = documentResultString;
			JCloudDocumentError? error = operation.error;
			documentResultString = str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud directory directories list : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	private IEnumerator DirectoryCopy()
	{
		JCloudDocumentOperation operation = JCloudDocument.DirectoryCopy("Test", "Test Copy", overwrite: true);
		while (!operation.finished)
		{
			documentResultString = "cloud document test directory copy progress : " + operation.progress;
			yield return null;
		}
		if (operation.success)
		{
			string str = (!(bool)operation.result) ? "failure" : "success";
			JCloudDocumentError? error = operation.error;
			documentResultString = "cloud document test directory copy : " + str + ((!error.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
		else
		{
			JCloudDocumentError? error2 = operation.error;
			documentResultString = "cloud document test directory copy : failure" + ((!error2.HasValue) ? string.Empty : (" ; error : " + operation.error));
		}
	}

	public void JCloudDocumentDidChangeExternally(JCloudDocumentExternalChange[] changes)
	{
		documentResultString = "cloud document did change externally :";
		for (int i = 0; i < changes.Length; i++)
		{
			string text = documentResultString;
			documentResultString = text + " " + i + ". " + changes[i].path;
			switch (changes[i].change)
			{
			case JCloudDocumentChangeType.Added:
				documentResultString += " (Added)";
				break;
			case JCloudDocumentChangeType.Changed:
				documentResultString += " (Changed)";
				break;
			case JCloudDocumentChangeType.Removed:
				documentResultString += " (Removed)";
				break;
			default:
				documentResultString += " (Unknown)";
				break;
			}
		}
	}
}
