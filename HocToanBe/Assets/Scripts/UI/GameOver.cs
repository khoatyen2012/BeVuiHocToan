using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	public tk2dUIItem btnHome;
	public tk2dUIItem btnResul;
	public tk2dSprite start;

	public void btnHome_OnClick()
	{
        GameController.instance.mLevel = 0;
        PopupController.instance.HideGameOver();
        PopupController.instance.ShowMainOperator();
	}
	public void btnResul_OnClick()
	{
        GameController.instance.mLevel = 0;
        PopupController.instance.HideGameOver();
        PopupController.instance.ShowInGame();
      

	}

	public void setData()
	{
	}

	// Use this for initialization
	void Start () {
		btnHome.OnClick += btnHome_OnClick;
		btnResul.OnClick += btnResul_OnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
