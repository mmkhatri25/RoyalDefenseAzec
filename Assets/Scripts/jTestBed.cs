using System;
using System.Collections;
using System.Text;
using UnityEngine;

[AddComponentMenu("")]
public class jTestBed : MonoBehaviour
{
	private string documentResultString = string.Empty;

	private string dataResultString = string.Empty;

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
		GUI.Label(new Rect(0f, num2 * 11f, num, num2 * 1.5f), "Document Result : " + documentResultString);
		if (GUI.Button(new Rect(0f, num2 * 11.5f, num * 0.5f, num2), "Data Set \"TestKey\" Int"))
		{
			JCloudData.SetInt("TestKey", 15);
			dataResultString = "data set int return is void";
		}
		if (GUI.Button(new Rect(0f, num2 * 12.5f, num * 0.5f, num2), "Data Get \"TestKey\" Int"))
		{
			int @int = JCloudData.GetInt("TestKey");
			dataResultString = "data get int return is : " + @int;
		}
		if (GUI.Button(new Rect(0f, num2 * 13.5f, num * 0.5f, num2), "Data Set \"TestKey\" Float"))
		{
			JCloudData.SetFloat("TestKey", 13.37f);
			dataResultString = "data set float return is void";
		}
		if (GUI.Button(new Rect(0f, num2 * 14.5f, num * 0.5f, num2), "Data Get \"TestKey\" Float"))
		{
			float @float = JCloudData.GetFloat("TestKey");
			dataResultString = "data get float return is : " + @float;
		}
		if (GUI.Button(new Rect(0f, num2 * 15.5f, num * 0.5f, num2), "Register Cloud Data Changes"))
		{
			dataResultString = "now watching cloud data changes";
			JCloudData.ExternalChanges = (JCloudData.CloudDataExternalChangesCallbackFunction)Delegate.Combine(JCloudData.ExternalChanges, new JCloudData.CloudDataExternalChangesCallbackFunction(JCloudDataDidChangeExternally));
		}
		if (GUI.Button(new Rect(0f, num2 * 16.5f, num * 0.5f, num2), "Poll Cloud Data Availability"))
		{
			dataResultString = "cloud data " + ((!JCloudData.PollCloudDataAvailability()) ? "unavailable" : "available");
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 11.5f, num * 0.5f, num2), "Data Set \"TestKey\" String"))
		{
			JCloudData.SetString("TestKey", "this is a test string");
			dataResultString = "data set string return is void";
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 12.5f, num * 0.5f, num2), "Data Get \"TestKey\" String"))
		{
			string @string = JCloudData.GetString("TestKey");
			dataResultString = "data get string return is : " + @string;
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 13.5f, num * 0.5f, num2), "Data Has \"TestKey\" Key"))
		{
			dataResultString = "data has TestKey key return is : " + ((!JCloudData.HasKey("TestKey")) ? "no" : "yes");
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 14.5f, num * 0.5f, num2), "Data Delete \"TestKey\" Key"))
		{
			JCloudData.DeleteKey("TestKey");
			dataResultString = "data delete TestKey key return is void";
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 15.5f, num * 0.5f, num2), "Data Delete All Keys"))
		{
			JCloudData.DeleteAll();
			dataResultString = "data delete all keys return is void";
		}
		if (GUI.Button(new Rect(num * 0.5f, num2 * 16.5f, num * 0.5f, num2), "Data Save"))
		{
			JCloudData.Save();
			dataResultString = "data save return is ok";
		}
		if (GUI.Button(new Rect(0f, num2 * 17.5f, num, num2), "Clear Resultats"))
		{
			dataResultString = string.Empty;
		}
		GUI.Label(new Rect(0f, num2 * 18.5f, num, num2 * 1.5f), "Dict/Data Result : " + dataResultString);
	}

	private void JCloudDataDidChangeExternally(JCloudDataExternalChange change)
	{
		dataResultString = "cloud data changed ; reason : ";
		switch (change.Reason)
		{
		case JCloudDataChangeReason.JCloudDataAccountChange:
			dataResultString += "account change";
			break;
		case JCloudDataChangeReason.JCloudDataInitialSyncChange:
			dataResultString += "initial sync";
			break;
		case JCloudDataChangeReason.JCloudDataQuotaViolationChange:
			dataResultString += "quota violation";
			break;
		case JCloudDataChangeReason.JCloudDataServerChange:
			dataResultString += "server change";
			break;
		default:
			dataResultString += "nope";
			break;
		}
		JCloudKeyValueChange[] changedKeyValues = change.ChangedKeyValues;
		for (int i = 0; i < changedKeyValues.Length; i++)
		{
			JCloudKeyValueChange jCloudKeyValueChange = changedKeyValues[i];
			string text = dataResultString;
			dataResultString = text + " ; " + jCloudKeyValueChange.Key + " (old : " + ((jCloudKeyValueChange.OldValue != null) ? jCloudKeyValueChange.OldValue : "(null)") + " ; new : " + ((jCloudKeyValueChange.NewValue != null) ? jCloudKeyValueChange.NewValue : "(null)") + ")";
		}
	}

	private IEnumerator FileWriteAllBytes()
	{
		UTF8Encoding encoder = new UTF8Encoding();
		JCloudDocumentOperation operation = JCloudDocument.FileWriteAllBytes("testfile.txt", encoder.GetBytes("this is a test content"));
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
