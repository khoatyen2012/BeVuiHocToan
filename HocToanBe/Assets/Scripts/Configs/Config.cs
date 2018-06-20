using UnityEngine;
using System.Collections;

public class Config  {

#if UNITY_IPHONE
	public static string appId = "ca-app-pub-2127327600096597~6853376404";
	public static string adsID = "ca-app-pub-2127327600096597/4624946117";
	public static string adsInID = "ca-app-pub-2127327600096597/8256945657";


#endif

#if UNITY_ANDROID

    public static string appId = "ca-app-pub-2577061470072962~3751790098";
	public static string adsID = "ca-app-pub-3940256099942544/6300978111";
	public static string adsInID = "ca-app-pub-3940256099942544/1033173712";


#endif

}
