using UnityEngine;
using System.Collections;

public class DataManager  {

	private static string TAG_VIP = "vipprof";


	public static int GetVip()
	{
		if (PlayerPrefs.HasKey(TAG_VIP))
		{
			return PlayerPrefs.GetInt(TAG_VIP);
		}
		else
		{
			return 0;
		}
	}

	public static void SaveVip(int newHightScore)
	{
		PlayerPrefs.SetInt(TAG_VIP, newHightScore);
	}
}
