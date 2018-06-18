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

    void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = -1;
		tienganh = CheckNgonNgu();
    }

	public int mNumber=10;
	public int mOperator=0;
	public MoveGitfBox gitfBox;
	public int mLevel=0;
	public int mStar=45;
	public int tienganh = 0;




	public enum State
	{    
		AWAKE,
		START,
		LOADZOOM,
		END,
		INGAME,
		WAIT,
		GAMEOVER
	}
	public State currentState;



	public int CheckNgonNgu()
	{

		string ngonngu = Application.systemLanguage.ToString().ToLower().Trim();
		if (ngonngu.Equals ("vietnamese")) {
			return 1;
		} else if (ngonngu.Equals ("german")) {
			return 2;
		} else {
			return 0;
		}

	}

	public void setMoveGitfBox()
	{
		gitfBox.setMove ();
	}

	IEnumerator WaitTimeSHA(float time)
	{
		yield return new WaitForSeconds (time);
		PopupController.instance.HideSha ();
		//currentState = State.START;
	}

	// Use this for initialization
	void Start () {
		mLevel=0;
		StartCoroutine (WaitTimeSHA (3f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
