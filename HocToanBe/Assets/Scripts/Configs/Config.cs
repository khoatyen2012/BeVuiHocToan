using UnityEngine;
using System.Collections;

public class Config  {

#if UNITY_IPHONE
	public static string appId = "ca-app-pub-2127327600096597~6853376404";
	public static string adsID = "ca-app-pub-2127327600096597/4624946117";
	public static string adsInID = "ca-app-pub-2127327600096597/8256945657";


#endif

#if UNITY_ANDROID

	public static string appId = "ca-app-pub-5148482490300491~5817397141";
	public static string adsID = "ca-app-pub-5148482490300491/1766471495";
	public static string adsInID = "ca-app-pub-5148482490300491/3820013096";


#endif

}
