using UnityEngine;
using System.Collections;

public class ZoomSub : MonoBehaviour {

	public float startX;
	public float startY;
	public float distance;

	public enum State
	{
		IDLE,
		ZOOM

	}

	public State curentState;
	public void setZoom()
	{
		curentState = State.ZOOM;
	}
	public void setDefault()
	{
		this.transform.localScale = new Vector3(startX, startY, this.transform.localScale.z);
	}

	void Start () {
		startX = this.transform.localScale.x;
		startY = this.transform.localScale.y;
	}

	// Update is called once per frame
	void Update () {
		if (curentState == State.ZOOM)
		{
			if (this.transform.localScale.x > 0f || this.transform.localScale.y > 0f)
			{
				this.transform.localScale = new Vector3(this.transform.localScale.x - distance, this.transform.localScale.y - distance, this.transform.localScale.z);
			}
			else
			{
				curentState = State.IDLE;
				this.transform.localScale = new Vector3(0f, 0f, this.transform.localScale.z);
			}
		}

	}
}
