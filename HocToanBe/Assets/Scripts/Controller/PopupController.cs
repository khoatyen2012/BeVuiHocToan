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

    public void ShowInGame()
    {
        inGame.setData();
        inGame.transform.position = new Vector3(inGame.transform.position.x, showY, inGame.transform.position.z);
    }

    public void HideInGame()
    {
        inGame.transform.position = new Vector3(inGame.transform.position.x, hideY, inGame.transform.position.z);
    }

	public void ShowMainNumber()
	{

		mainNumber.transform.position = new Vector3(mainNumber.transform.position.x, showY, mainNumber.transform.position.z);
	}

	public void HideMainNumber()
	{
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
