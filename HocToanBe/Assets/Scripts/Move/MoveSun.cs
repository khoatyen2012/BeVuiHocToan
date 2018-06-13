using UnityEngine;
using System.Collections;

public class MoveSun : MonoBehaviour {



	public enum State
	{

		IDE,
		LEFT,
		RIGHT
	}
	public State currentState;
	private State currentStateTMG;
	public float speedVangCan;
	public Vector3 tamquay;
	public bool checkPos = true;

	void MoveLeftRight()
	{
		if (currentState == State.LEFT)
		{
			this.transform.RotateAround(tamquay, Vector3.back, speedVangCan * Time.deltaTime);
			// Debug.Log("llll:" + this.transform.GetChild(0).eulerAngles.z);
			if (this.transform.eulerAngles.z <= 350f && this.transform.eulerAngles.z > 30f)
			{

				currentState = State.RIGHT;
				this.transform.RotateAround(tamquay, Vector3.forward, speedVangCan * Time.deltaTime);
			}
		}

		if (currentState == State.RIGHT)
		{
			this.transform.RotateAround(tamquay, Vector3.forward, speedVangCan * Time.deltaTime);
			// Debug.Log("rrrr:" + this.transform.GetChild(0).eulerAngles.z);
			if (this.transform.eulerAngles.z >= 30f && this.transform.eulerAngles.z < 350f)
			{

				currentState = State.LEFT;
				this.transform.RotateAround(tamquay, Vector3.back, speedVangCan * Time.deltaTime);

			}
		}

		//if (currentState == State.LEFTRIGHT)
		//{
		//    this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * 1f) * 75);
		//}
	}

	public void setMove()
	{
		if (checkPos) {
			checkPos = false;
			tamquay = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y - 50, this.transform.localPosition.z);
			currentState = State.LEFT;
		} else {
			currentState = currentStateTMG;
		}

	}

	public void setStop()
	{
		currentStateTMG = currentState;
		currentState = State.IDE;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveLeftRight ();
	}
}
