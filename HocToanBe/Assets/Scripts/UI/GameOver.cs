using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	public tk2dUIItem btnHome;
	public tk2dUIItem btnResul;
	public tk2dSprite start;

	public void btnHome_OnClick()
	{
	}
	public void btnResul_OnClick()
	{
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
