using UnityEngine;
using System.Collections;

public class MainOperator : MonoBehaviour {

	public tk2dUIItem btnAdd;
	public tk2dUIItem btnSub;
	public tk2dUIItem btnAddSub;
    public tk2dUIItem btnShare;

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

	public void ShowNextData(int pNext)
	{
		if (GameController.instance.currentState != GameController.State.AWAKE) {

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
        this.transform.GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(4).GetComponent<MoveSun>().setMove();
    }
	// Use this for initialization
	void Start () {
	
		btnAdd.OnClick += btnAdd_OnClick;
		btnSub.OnClick += btnSub_OnClick;
		btnAddSub.OnClick += btnAddSub_OnClick;
        btnShare.OnClick += btnShare_OnClick;
        this.transform.GetChild(4).GetComponent<MoveSun>().setMove();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
