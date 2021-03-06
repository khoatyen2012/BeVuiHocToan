﻿using UnityEngine;
using System.Collections;

public class MainNumber : MonoBehaviour {


	public tk2dUIItem btnMuoi;
	public tk2dUIItem btnHaiMuoi;
	public tk2dUIItem btnNamMuoi;
	public tk2dUIItem btnTram;
	public tk2dUIItem btnClose;
	public tk2dUIItem btnNext;
	public float distance;

	public enum State
	{
		IDLE,
		ZOOM

	}

	public State curentState;

	public void setZoomAdd()
	{
		curentState = State.ZOOM;
	}

	public void setZoomSub()
	{
		this.transform.localScale = new Vector3(0f, 1f,  this.transform.localScale.z);
		curentState = State.IDLE;
	}

	public void btnClose_OnClick()
	{
		SoundManager.Instance.PlayAudioCick ();
		PopupController.instance.HideMainNumber ();
		PopupController.instance.ShowMainOperator ();
	}
	public void btnNext_OnClick()
	{
		SoundManager.Instance.PlayAudioCick ();
        PopupController.instance.HideMainNumber();
        PopupController.instance.ShowInGame();
	}


	public void btnMuoi_OnClick()
	{
		setNumber (10);
	}
	public void btnHaiMuoi_OnClick()
	{
		setNumber (20);
	}
	public void btnNamMuoi_OnClick()
	{
		setNumber (50);
	}
	public void btnTram_OnClick()
	{
		setNumber (100);
	}

	public void setNumber(int pType)
	{
		SoundManager.Instance.PlayAudioCick ();
		
		GameController.instance.mNumber = pType;
		btnMuoi.transform.GetChild (0).gameObject.SetActive (false);
		btnHaiMuoi.transform.GetChild (0).gameObject.SetActive (false);
		btnNamMuoi.transform.GetChild (0).gameObject.SetActive (false);
		btnTram.transform.GetChild (0).gameObject.SetActive (false);
		switch (pType) {
		case 10:
			btnMuoi.transform.GetChild (0).gameObject.SetActive (true);
			break;
		case 20:
			btnHaiMuoi.transform.GetChild (0).gameObject.SetActive (true);
			break;
		case 50:
			btnNamMuoi.transform.GetChild (0).gameObject.SetActive (true);
			break;
	
		default:
			btnTram.transform.GetChild (0).gameObject.SetActive (true);
			break;
		}
	}


	// Use this for initialization
	void Start () {

		btnMuoi.OnClick += btnMuoi_OnClick;
		btnHaiMuoi.OnClick += btnHaiMuoi_OnClick;
		btnNamMuoi.OnClick += btnNamMuoi_OnClick;
		btnTram.OnClick += btnTram_OnClick;
		btnClose.OnClick += btnClose_OnClick;
		btnNext.OnClick += btnNext_OnClick;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (curentState == State.ZOOM)
		{
			if (this.transform.localScale.x < 1f)
			{
				this.transform.localScale = new Vector3(this.transform.localScale.x + distance, this.transform.localScale.y,  this.transform.localScale.z);
			}
			else
			{
				curentState = State.IDLE;
				this.transform.localScale = new Vector3(1f, 1f,  this.transform.localScale.z);
			}
		}
	}
}
