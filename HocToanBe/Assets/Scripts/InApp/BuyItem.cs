﻿using UnityEngine;
using System.Collections;

public class BuyItem : MonoBehaviour {
	
	public tk2dUIItem btnBuy;
	public tk2dUIItem btnCancel;
	public tk2dTextMesh txtContent;
	// Use this for initialization

	public void btnBuy_OnClick()
	{
		IAPManager.instance.BuyVipLevel();
		SoundManager.Instance.PlayAudioCick ();
	}
	public void btnCancel_OnClick()
	{
		PopupController.instance.HideBuyItem ();
		GameController.instance.currentState = GameController.State.END;
	}
	void Start () {
		btnBuy.OnClick += btnBuy_OnClick;
		btnCancel.OnClick += btnCancel_OnClick;
		txtContent.text = "" + ClsLanguage.doBuyVip ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}