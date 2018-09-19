using UnityEngine;
using System.Collections;

public class MainNumber : MonoBehaviour {


	public tk2dUIItem btnMuoi;
	public tk2dUIItem btnHaiMuoi;
	public tk2dUIItem btnNamMuoi;
	public tk2dUIItem btnTram;
	public tk2dUIItem btnClose;
	public tk2dUIItem btnNext;
	public float distance;
	public tk2dTextMesh txtTitle;

	public enum State
	{
		IDLE,
		ZOOM

	}

	public State curentState;

	public void setZoomAdd()
	{
		curentState = State.ZOOM;
		if (GameController.instance.mOperator == 0) {
			txtTitle.text = "Addition Game";
		} else if (GameController.instance.mOperator == 1) {
			txtTitle.text = "Subtraction Games";
		} else {
			txtTitle.text = "Addition/Subtraction";
		}

	}

	public void setZoomSub()
	{
		this.transform.localScale = new Vector3(0f, 1f,  this.transform.localScale.z);
		curentState = State.IDLE;
	}

	public void btnClose_OnClick()
	{
		try
		{
		SoundManager.Instance.PlayAudioCick ();
		PopupController.instance.HideMainNumber ();
		PopupController.instance.ShowMainOperator ();
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	public void btnNext_OnClick()
	{
		try
		{
		SoundManager.Instance.PlayAudioCick ();
        PopupController.instance.HideMainNumber();
        PopupController.instance.ShowInGame();
		}
		catch (System.Exception)
		{

			throw;
		}
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
		try
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
		catch (System.Exception)
		{

			throw;
		}
	}


	// Use this for initialization
	void Start () {

		try
		{
		btnMuoi.OnClick += btnMuoi_OnClick;
		btnHaiMuoi.OnClick += btnHaiMuoi_OnClick;
		btnNamMuoi.OnClick += btnNamMuoi_OnClick;
		btnTram.OnClick += btnTram_OnClick;
		btnClose.OnClick += btnClose_OnClick;
		btnNext.OnClick += btnNext_OnClick;
		}
		catch (System.Exception)
		{

			throw;
		}
	
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
