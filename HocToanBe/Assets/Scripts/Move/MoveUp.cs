using UnityEngine;
using System.Collections;

public class MoveUp : MonoBehaviour {



	public float moveSpeed;


	public Vector3 startPosition;
	public float stopY;

	public void setStartPosition()
	{
		this.transform.localPosition = startPosition;
	}


	public void setMove()
	{
		StartCoroutine(ieMoveUp());
	}

	IEnumerator ieMoveUp()
	{
		while (this.transform.localPosition.y < stopY)
		{
			this.transform.localPosition += Vector3.up
				* moveSpeed
				* Time.deltaTime;
			yield return 0;
		}
		this.transform.localPosition = new Vector3 (this.transform.localPosition.x, stopY, this.transform.localPosition.z);
		GameController.instance.currentState = GameController.State.INGAME;
		SoundManager.Instance.PlayAudioDD();
	}

	// Use this for initialization
	void Start () {
		startPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
