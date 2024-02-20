using System;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
	public string PlayerPrefsString;

	public string currentTimer;

	public string TimerInfo;

	public string TimerInfoStart;

	public bool timerEnd;

	public bool timerEndClose;

	private DateTime TimestampEnd;

	private void Awake()
	{
		TimestampEnd = ReadTimestamp(PlayerPrefsString, UnbiasedTime.Instance.Now().AddSeconds(60.0));
	}

	private void OnApplicationPause(bool paused)
	{
		if (paused)
		{
			WriteTimestamp(PlayerPrefsString, TimestampEnd);
		}
		else
		{
			TimestampEnd = ReadTimestamp(PlayerPrefsString, UnbiasedTime.Instance.Now().AddSeconds(60.0));
		}
	}

	private void OnApplicationQuit()
	{
		WriteTimestamp(PlayerPrefsString, TimestampEnd);
	}

	public void CheckTime()
	{
		TimeSpan timeSpan = TimestampEnd - UnbiasedTime.Instance.Now();
		if (timeSpan.TotalSeconds > 0.0)
		{
			timerEnd = false;
			if (timeSpan.Hours > 0)
			{
				TimerInfo = timeSpan.Hours + "h " + timeSpan.Minutes + "m";
				timerEndClose = false;
			}
			else
			{
				if (timeSpan.Minutes > 0)
				{
					TimerInfo = "0h " + timeSpan.Minutes + "m";
				}
				else
				{
					TimerInfo = "0h 1m";
				}
				if (timeSpan.Minutes <= 5)
				{
					timerEndClose = true;
				}
				else
				{
					timerEndClose = false;
				}
			}
			currentTimer = $"{timeSpan.Hours}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
		}
		else
		{
			timerEndClose = true;
			timerEnd = true;
			TimerInfo = "END";
			currentTimer = $"{0}:{0:D2}:{0:D2}";
		}
	}

	public void SetTime(float hour, float minute, float second)
	{
		TimestampEnd = UnbiasedTime.Instance.Now().AddSeconds(10.0);
		if (hour > 0f)
		{
			TimestampEnd = TimestampEnd.AddHours(hour);
		}
		if (minute > 0f)
		{
			TimestampEnd = TimestampEnd.AddMinutes(minute);
		}
		if (second > 0f)
		{
			TimestampEnd = TimestampEnd.AddSeconds(second);
		}
		WriteTimestamp(PlayerPrefsString, TimestampEnd);
		timerEnd = false;
		SetStartTimeInfo();
		CheckTime();
	}

	public void AddTime(float hour, float minute, float second)
	{
		if ((TimestampEnd - UnbiasedTime.Instance.Now()).TotalSeconds <= 0.0)
		{
			TimestampEnd = UnbiasedTime.Instance.Now().AddSeconds(10.0);
		}
		if (hour > 0f)
		{
			TimestampEnd = TimestampEnd.AddHours(hour);
		}
		if (minute > 0f)
		{
			TimestampEnd = TimestampEnd.AddMinutes(minute);
		}
		if (second > 0f)
		{
			TimestampEnd = TimestampEnd.AddSeconds(second);
		}
		WriteTimestamp(PlayerPrefsString, TimestampEnd);
		timerEnd = false;
		SetStartTimeInfo();
		CheckTime();
	}

	private void SetStartTimeInfo()
	{
		TimeSpan timeSpan = TimestampEnd - UnbiasedTime.Instance.Now();
		if (timeSpan.TotalSeconds > 0.0)
		{
			if (timeSpan.Hours > 0)
			{
				TimerInfoStart = timeSpan.Hours + "h " + timeSpan.Minutes + "m";
			}
			else if (timeSpan.Minutes > 0)
			{
				TimerInfoStart = "0h " + timeSpan.Minutes + "m";
			}
			else
			{
				TimerInfoStart = "0h 1m";
			}
		}
	}

	private DateTime ReadTimestamp(string key, DateTime defaultValue)
	{
		long num = Convert.ToInt64(PlayerPrefs.GetString(key, "0"));
		if (num == 0L)
		{
			return defaultValue;
		}
		return DateTime.FromBinary(num);
	}

	private void WriteTimestamp(string key, DateTime time)
	{
		PlayerPrefs.SetString(key, time.ToBinary().ToString());
	}
}
