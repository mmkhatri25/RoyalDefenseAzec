using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class jLoadSaveUI : MonoBehaviour
{
	public GameObject player;

	public GameObject playerCamera;

	public GameObject redCube;

	public GameObject greenCube;

	public GameObject blueCube;

	private string lastPlayedPlatform;

	private string lastPlayedTime;

	private int playCount;

	private string error;

	private void OnEnable()
	{
		lastPlayedPlatform = JCloudData.GetString("Last Played Platform", Application.platform.ToString());
		JCloudData.SetString("Last Played Platform", Application.platform.ToString());
		lastPlayedTime = JCloudData.GetString("Last Played Time", DateTime.Now.ToString());
		JCloudData.SetString("Last Played Time", DateTime.Now.ToString());
		playCount = JCloudData.GetInt("Play Count");
		playCount++;
		JCloudData.SetInt("Play Count", playCount);
		JCloudData.Save();
	}

	private void OnApplicationPause(bool pause)
	{
		if (!pause)
		{
			lastPlayedPlatform = JCloudData.GetString("Last Played Platform", Application.platform.ToString());
			JCloudData.SetString("Last Played Platform", Application.platform.ToString());
			lastPlayedTime = JCloudData.GetString("Last Played Time", DateTime.Now.ToString());
			JCloudData.SetString("Last Played Time", DateTime.Now.ToString());
			playCount = JCloudData.GetInt("Play Count");
			playCount++;
			JCloudData.SetInt("Play Count", playCount);
			JCloudData.Save();
		}
	}

	private void OnGUI()
	{
		if (GUILayout.Button("Load Game", GUILayout.Width(320f), GUILayout.Height(40f)))
		{
			StartCoroutine(LoadGame());
		}
		if (GUILayout.Button("Save Game", GUILayout.Width(320f), GUILayout.Height(40f)))
		{
			StartCoroutine(SaveGame());
		}
		if (error != null)
		{
			GUILayout.Label("Error: " + error);
		}
		GUILayout.Label("Last Played Platform: " + lastPlayedPlatform);
		GUILayout.Label("Last Played Time: " + lastPlayedTime);
		GUILayout.Label("Play Count: " + playCount);
	}

	private IEnumerator LoadGame()
	{
		JCloudDocumentOperation operation = JCloudDocument.FileReadAllBytes("Savegames/My saved game.sav");
		while (!operation.finished)
		{
			yield return null;
		}
		if (operation.error.HasValue)
		{
			HandleDocumentError(operation.error.Value);
			yield break;
		}
		error = null;
		byte[] gameBytes = operation.result as byte[];
		if (gameBytes != null)
		{
			MemoryStream dataStream = new MemoryStream(gameBytes);
			BinaryReader reader = new BinaryReader(dataStream);
			DeserializeTransformFromReader(player.transform, reader);
			DeserializeRigidbodyFromReader(player.GetComponent<Rigidbody>(), reader);
			DeserializeTransformFromReader(playerCamera.transform, reader);
			DeserializeTransformFromReader(redCube.transform, reader);
			DeserializeRigidbodyFromReader(redCube.GetComponent<Rigidbody>(), reader);
			DeserializeTransformFromReader(greenCube.transform, reader);
			DeserializeRigidbodyFromReader(greenCube.GetComponent<Rigidbody>(), reader);
			DeserializeTransformFromReader(blueCube.transform, reader);
			DeserializeRigidbodyFromReader(blueCube.GetComponent<Rigidbody>(), reader);
		}
	}

	private IEnumerator SaveGame()
	{
		if (!player || !playerCamera || !redCube || !greenCube || !blueCube)
		{
			yield break;
		}
		MemoryStream dataStream = new MemoryStream();
		BinaryWriter writer = new BinaryWriter(dataStream);
		SerializeTransformToWriter(player.transform, writer);
		SerializeRigidbodyToWriter(player.GetComponent<Rigidbody>(), writer);
		SerializeTransformToWriter(playerCamera.transform, writer);
		SerializeTransformToWriter(redCube.transform, writer);
		SerializeRigidbodyToWriter(redCube.GetComponent<Rigidbody>(), writer);
		SerializeTransformToWriter(greenCube.transform, writer);
		SerializeRigidbodyToWriter(greenCube.GetComponent<Rigidbody>(), writer);
		SerializeTransformToWriter(blueCube.transform, writer);
		SerializeRigidbodyToWriter(blueCube.GetComponent<Rigidbody>(), writer);
		JCloudDocumentOperation operation3 = JCloudDocument.DirectoryExists("Savegames");
		while (!operation3.finished)
		{
			yield return null;
		}
		if (operation3.error.HasValue)
		{
			HandleDocumentError(operation3.error.Value);
			yield break;
		}
		if (!(bool)operation3.result)
		{
			operation3 = JCloudDocument.DirectoryCreate("Savegames");
			while (!operation3.finished)
			{
				yield return null;
			}
			if (operation3.error.HasValue)
			{
				HandleDocumentError(operation3.error.Value);
				yield break;
			}
		}
		operation3 = JCloudDocument.FileWriteAllBytes("Savegames/My saved game.sav", dataStream.GetBuffer());
		while (!operation3.finished)
		{
			yield return null;
		}
		if (operation3.error.HasValue)
		{
			HandleDocumentError(operation3.error.Value);
		}
	}

	private void SerializeTransformToWriter(Transform tr, BinaryWriter writer)
	{
		Vector3 localPosition = tr.localPosition;
		writer.Write(localPosition.x);
		Vector3 localPosition2 = tr.localPosition;
		writer.Write(localPosition2.y);
		Vector3 localPosition3 = tr.localPosition;
		writer.Write(localPosition3.z);
		Vector3 localEulerAngles = tr.localEulerAngles;
		writer.Write(localEulerAngles.x);
		Vector3 localEulerAngles2 = tr.localEulerAngles;
		writer.Write(localEulerAngles2.y);
		Vector3 localEulerAngles3 = tr.localEulerAngles;
		writer.Write(localEulerAngles3.z);
		Vector3 localScale = tr.localScale;
		writer.Write(localScale.x);
		Vector3 localScale2 = tr.localScale;
		writer.Write(localScale2.y);
		Vector3 localScale3 = tr.localScale;
		writer.Write(localScale3.z);
	}

	private void DeserializeTransformFromReader(Transform tr, BinaryReader reader)
	{
		tr.localPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		tr.localEulerAngles = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		tr.localScale = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	private void SerializeRigidbodyToWriter(Rigidbody body, BinaryWriter writer)
	{
		Vector3 velocity = body.velocity;
		writer.Write(velocity.x);
		Vector3 velocity2 = body.velocity;
		writer.Write(velocity2.y);
		Vector3 velocity3 = body.velocity;
		writer.Write(velocity3.z);
		Vector3 angularVelocity = body.angularVelocity;
		writer.Write(angularVelocity.x);
		Vector3 angularVelocity2 = body.angularVelocity;
		writer.Write(angularVelocity2.y);
		Vector3 angularVelocity3 = body.angularVelocity;
		writer.Write(angularVelocity3.z);
	}

	private void DeserializeRigidbodyFromReader(Rigidbody body, BinaryReader reader)
	{
		body.velocity = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		body.angularVelocity = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	private void HandleDocumentError(JCloudDocumentError documentError)
	{
		switch (documentError)
		{
		case JCloudDocumentError.OverwriteError:
		case JCloudDocumentError.CloudUnavailable:
			break;
		case JCloudDocumentError.InvalidPlatform:
			error = "No file access allowed on this platform.";
			break;
		case JCloudDocumentError.PluginError:
		case JCloudDocumentError.InvalidArguments:
		case JCloudDocumentError.NativeError:
			error = "An error ocurred while loading game data. Please retry. Error: " + documentError.ToString();
			break;
		case JCloudDocumentError.DocumentNotFound:
			error = "There is no saved game present on this device. Start a new game.";
			break;
		case JCloudDocumentError.DownloadTimeout:
			error = "Could not download the save game data. Please retry.";
			break;
		case JCloudDocumentError.InvalidVersionIdentifier:
		case JCloudDocumentError.InvalidVersionsHash:
			error = "An error occured while handling conflict versions of your save game data. Please retry.";
			break;
		}
	}
}
