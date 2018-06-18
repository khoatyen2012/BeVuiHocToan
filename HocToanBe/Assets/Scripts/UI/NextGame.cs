using UnityEngine;
using System.Collections;

public class NextGame : MonoBehaviour {


	public tk2dUIItem btnHome;
	public tk2dUIItem btnResul;
	public tk2dUIItem btnMath;

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

	// Use this for initialization
	void Start () {
		btnHome.OnClick += btnHome_OnClick;
		btnResul.OnClick += btnResul_OnClick;
		btnMath.OnClick += btnMath_OnClick;
	}

	public void btnMath_OnClick()
	{
		ShareRate.RateMath ();
	}

	public void btnHome_OnClick()
	{
		GameController.instance.mLevel = 0;
		GameController.instance.mStar = 45;
		PopupController.instance.HideNextGame();
		PopupController.instance.ShowMainOperator();
		SoundManager.Instance.PlayAudioCick ();
	}
	public void btnResul_OnClick()
	{
		GameController.instance.mLevel = 0;
		GameController.instance.mStar = 45;
		PopupController.instance.HideNextGame();
		PopupController.instance.ShowInGame();
		SoundManager.Instance.PlayAudioCick ();


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
