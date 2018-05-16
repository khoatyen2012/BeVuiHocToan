using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	#region Singleton
	private static GameController _instance;

	public static GameController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<GameController>();
			return _instance;
		}
	}
	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
