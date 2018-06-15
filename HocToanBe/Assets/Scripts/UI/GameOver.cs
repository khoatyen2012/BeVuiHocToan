using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	public tk2dUIItem btnHome;

	public tk2dSprite star;

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
		if (GameController.instance.mStar > 30) {
			star.SetSprite ("saoba");
		} else if (GameController.instance.mStar > 15) {
			star.SetSprite ("saohai");
		} else {
			star.SetSprite ("saomot");
		}
	}

	public void setZoomSub()
	{
		this.transform.localScale = new Vector3(0f, 1f,  this.transform.localScale.z);
		curentState = State.IDLE;
	}

	public void btnHome_OnClick()
	{
    
        PopupController.instance.HideGameOver();
		PopupController.instance.ShowNextGame ();
	}




	// Use this for initialization
	void Start () {
		btnHome.OnClick += btnHome_OnClick;
	
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
