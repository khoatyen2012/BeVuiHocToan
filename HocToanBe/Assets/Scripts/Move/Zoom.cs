using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

	// Use this for initialization
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

	void Start () {
        startX = this.transform.localScale.x;
        startY = this.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (curentState == State.ZOOM)
        {
            if (this.transform.localScale.x < startX || this.transform.localScale.y < startY)
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x + distance, this.transform.localScale.y + distance, 1);
            }
            else
            {
                curentState = State.IDLE;
                this.transform.localScale = new Vector3(startX, startY, 1);
            }
        }
	
	}
}
