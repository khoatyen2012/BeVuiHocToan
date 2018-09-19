using UnityEngine;
using System.Collections;

public class MainOperator : MonoBehaviour {

	public tk2dUIItem btnAdd;
	public tk2dUIItem btnSub;
	public tk2dUIItem btnAddSub;
    public tk2dUIItem btnShare;
	public tk2dUIItem btnRate;

	public void btnAdd_OnClick()
	{
		try
		{
		ShowNextData (0);
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	public void btnSub_OnClick()
	{
		try
		{
		ShowNextData (1);
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	public void btnAddSub_OnClick()
	{
		try
		{
		ShowNextData (2);
		}
		catch (System.Exception)
		{

			throw;
		}
	}

    public void btnShare_OnClick()
    {
		try
		{
        ShareRate.Share();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

	public void btnRate_OnClick()
	{
		try
		{
		ShareRate.Rate ();
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public void ShowNextData(int pNext)
	{
		if (GameController.instance.currentState != GameController.State.AWAKE) {
			if (GameController.instance.checkvip != 10) {
				AdmobManger.Instance.HidewBanner ();
			}

            this.transform.GetChild(4).GetComponent<MoveSun>().setStop();
            this.transform.GetChild(4).gameObject.SetActive(false);

			SoundManager.Instance.PlayAudioCick ();
			GameController.instance.mOperator = pNext;
			PopupController.instance.HideMainOperator ();
			PopupController.instance.ShowMainNumber ();
		}

	}

    public void setData()
    {
		try
		{
		if (GameController.instance.checkvip != 10) {
			AdmobManger.Instance.RequestBanner ();
			AdmobManger.Instance.ShowBanner ();
		}
		
        this.transform.GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(4).GetComponent<MoveSun>().setMove();
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
		btnAdd.OnClick += btnAdd_OnClick;
		btnSub.OnClick += btnSub_OnClick;
		btnAddSub.OnClick += btnAddSub_OnClick;
        btnShare.OnClick += btnShare_OnClick;
		btnRate.OnClick += btnRate_OnClick;
        this.transform.GetChild(4).GetComponent<MoveSun>().setMove();
		if (GameController.instance.checkvip != 10) {
			AdmobManger.Instance.RequestBanner ();
		}
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
