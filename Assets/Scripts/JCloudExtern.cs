using System;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudExtern
{
	public struct JCloudDocumentVersionsInternal
	{
		public IntPtr versionsHash;

		public IntPtr versionsUniqueIdentifiers;

		public IntPtr versionsUniqueIdentifiersLengthes;

		public IntPtr versionsModificationDates;

		public IntPtr versionsIsCurrent;

		public int versionsCount;
	}
}
