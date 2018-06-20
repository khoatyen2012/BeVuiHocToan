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

    public void btnShare_OnClick()
    {
        ShareRate.Share();
    }

	public void btnRate_OnClick()
	{
		ShareRate.Rate ();
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
		if (GameController.instance.checkvip != 10) {
			AdmobManger.Instance.RequestBanner ();
			AdmobManger.Instance.ShowBanner ();
		}
		
        this.transform.GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(4).GetComponent<MoveSun>().setMove();
    }
	// Use this for initialization
	void Start () {
	
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
