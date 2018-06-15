using UnityEngine;
using System.Collections;

public class PopupController : MonoBehaviour {

	#region Singleton
	private static PopupController _instance;

	public static PopupController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<PopupController>();
			return _instance;
		}
	}
	#endregion

	public float showY;
	public float hideY;


	public MainOperator mainOperator;

	public MainNumber mainNumber;

    public InGame inGame;
	public GameOver gameover;
	public NextGame nextgame;

	public void ShowNextGame()
	{

		nextgame.transform.position = new Vector3(nextgame.transform.position.x, showY, nextgame.transform.position.z);
		nextgame.setZoomAdd ();
	}

	public void HideNextGame()
	{
		nextgame.setZoomSub ();
		nextgame.transform.position = new Vector3(nextgame.transform.position.x, hideY, nextgame.transform.position.z);
	}

	public void ShowGameOver()
	{
		
		gameover.transform.position = new Vector3(gameover.transform.position.x, showY, gameover.transform.position.z);
		gameover.setZoomAdd ();
	}

	public void HideGameOver()
	{
		gameover.setZoomSub ();
		gameover.transform.position = new Vector3(gameover.transform.position.x, hideY, gameover.transform.position.z);
	}


    public void ShowInGame()
    {
       
        inGame.transform.position = new Vector3(inGame.transform.position.x, showY, inGame.transform.position.z);
		inGame.setBGdata();
    }

    public void HideInGame()
    {
        inGame.transform.position = new Vector3(inGame.transform.position.x, hideY, inGame.transform.position.z);
    }

	public void ShowMainNumber()
	{

		mainNumber.transform.position = new Vector3(mainNumber.transform.position.x, showY, mainNumber.transform.position.z);
		mainNumber.setZoomAdd ();
	}

	public void HideMainNumber()
	{
		mainNumber.setZoomSub ();
		mainNumber.transform.position = new Vector3(mainNumber.transform.position.x, hideY, mainNumber.transform.position.z);
	}

	public void ShowMainOperator()
	{
		
		mainOperator.transform.position = new Vector3(mainOperator.transform.position.x, showY, mainOperator.transform.position.z);
	}

	public void HideMainOperator()
	{
		mainOperator.transform.position = new Vector3(mainOperator.transform.position.x, hideY, mainOperator.transform.position.z);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
