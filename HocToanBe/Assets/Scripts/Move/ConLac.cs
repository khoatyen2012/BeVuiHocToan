using UnityEngine;
using System.Collections;

public class ConLac : MonoBehaviour {

	public enum State
	{


		LEFT,
		RIGHT
	}
	public State currentState;
	public float speedVangCan;
	public Vector3 tamquay;

	void MoveLeftRight()
	{
		if (currentState == State.LEFT)
		{
			this.transform.RotateAround(tamquay, Vector3.back, speedVangCan * Time.deltaTime);
			// Debug.Log("llll:" + this.transform.GetChild(0).eulerAngles.z);
			if (this.transform.eulerAngles.z <= 350f && this.transform.eulerAngles.z > 20f)
			{

				currentState = State.RIGHT;
				this.transform.RotateAround(tamquay, Vector3.forward, speedVangCan * Time.deltaTime);
			}
		}

		if (currentState == State.RIGHT)
		{
			this.transform.RotateAround(tamquay, Vector3.forward, speedVangCan * Time.deltaTime);
			// Debug.Log("rrrr:" + this.transform.GetChild(0).eulerAngles.z);
			if (this.transform.eulerAngles.z >= 20f && this.transform.eulerAngles.z < 350f)
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

	// Use this for initialization
	void Start () {
		tamquay = new Vector3 (this.transform.position.x, this.transform.position.y + 50, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		MoveLeftRight ();
	}
}
