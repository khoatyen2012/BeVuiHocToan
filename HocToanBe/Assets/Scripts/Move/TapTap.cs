using UnityEngine;
using System.Collections;

public class TapTap : MonoBehaviour {

    public Vector3 povisiEnd;
	public Vector3 povisiStart;
	private Vector3 vecH;
	public float speed;

	// Use this for initialization
	void Start () {
      
		vecH = new Vector3 (povisiEnd.x - povisiStart.x, povisiEnd.y - povisiStart.y, 0f).normalized;

	}

	public void setMove()
	{
		this.transform.position = povisiStart;
		StartCoroutine (ieMove ());
	}

	IEnumerator ieMove()
	{
		while (true) {
			
			if (this.transform.position.y > povisiEnd.y) {
				this.transform.position = povisiStart;
			}

			this.transform.position += vecH
				* speed
				* Time.deltaTime;
			yield return 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
