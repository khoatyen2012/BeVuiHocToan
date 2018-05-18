using UnityEngine;
using System.Collections;

public class MainOperator : MonoBehaviour {

	public tk2dUIItem btnAdd;
	public tk2dUIItem btnSub;
	public tk2dUIItem btnAddSub;

	public void btnAdd_OnClick()
	{
		ShowNextData (0);
	}
	public void btnSub_OnClick()
	{
		ShowNextData (1);
	}
	public void btnAddSub_OnClick()
	{
		ShowNextData (2);
	}

	public void ShowNextData(int pNext)
	{
		PopupController.instance.HideMainOperator ();
		PopupController.instance.ShowMainNumber ();
	}
	// Use this for initialization
	void Start () {
	
		btnAdd.OnClick += btnAdd_OnClick;
		btnSub.OnClick += btnSub_OnClick;
		btnAddSub.OnClick += btnAddSub_OnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
