﻿using UnityEngine;
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

    void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = -1;
    }

	public int mNumber=10;
	public int mOperator=0;
	public MoveGitfBox gitfBox;



	public enum State
	{
		START,
		LOADZOOM,
		END,
		INGAME,
		GAMEOVER
	}
	public State currentState;


	public void setMoveGitfBox()
	{
		gitfBox.setMove ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
