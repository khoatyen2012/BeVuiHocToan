using UnityEngine;
using System.Collections;

public class MoveGitfBox : MonoBehaviour {


	public float moveSpeed;


	public Vector3 startPosition;
	public float stopY;

	public void setStartPosition()
	{
		this.gameObject.SetActive (false);
		this.transform.localPosition = startPosition;
		foreach (Transform child in this.transform) {
			child.GetComponent<ConLac> ().setStartPosition ();
		}
	}


	public void setMove()
	{
		this.gameObject.SetActive (true);
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
		setStartPosition ();

	}

	// Use this for initialization
	void Start () {
		startPosition = this.transform.localPosition;
	}

	// Update is called once per frame
	void Update () {

	}
}
