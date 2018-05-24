using UnityEngine;
using System.Collections;

public class InGame : MonoBehaviour {


    public Transform C1;
    public Transform C2;
    public Transform C3;
    public Transform O1;
    public Transform O2;
	public MoveUp DD;

	
	public Transform d1;
	public Transform d2;
	public Transform d3;
	Transform dd;
	Vector3 startPostionD;
	Vector3 startPostionD1;
	Vector3 startPostionD2;
	Vector3 startPostionD3;

    public float moveSpeed;



    public void setData()
    {
        C1.localScale = new Vector3(0, 0, 1);
        C2.localScale = new Vector3(0, 0, 1);
        C3.localScale = new Vector3(0, 0, 1);
        O1.localScale = new Vector3(0, 0, 1);
        O2.localScale = new Vector3(0, 0, 1);

		GameController.instance.currentState = GameController.State.LOADZOOM;

        StartCoroutine(WaitTimeC1(0.3f,C1));
        StartCoroutine(WaitTimeC1(1f, O1));
        StartCoroutine(WaitTimeC1(1.5f, C2));
        StartCoroutine(WaitTimeC1(2f, O2));
        StartCoroutine(WaitTimeC1(3f, C3));
		StartCoroutine(WaitTimeDD(4.2f));
    }

    IEnumerator WaitTimeC1(float time,Transform pC)
    {
        yield return new WaitForSeconds(time);
        pC.GetComponent<Zoom>().setZoom();
    }

	IEnumerator WaitTimeDD(float time)
	{
		yield return new WaitForSeconds (time);
		DD.setMove ();

	}

	// Use this for initialization
	void Start () {

		startPostionD1 = d1.position;
		startPostionD2 = d2.position;
		startPostionD3 = d3.position;

	}

	public float speed;
	void Update()
	{
		

			if (Input.touchCount != 0 && Input.GetTouch (0).phase
			   == TouchPhase.Began) {
			if (GameController.instance.currentState == GameController.State.INGAME) {
				Vector3 positionTouch = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				if (Mathf.Abs (positionTouch.x - d1.position.x) < (d1.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d1.position.y) < (d1.GetComponent<Collider> ().bounds.size.y / 2)) {
					dd = d1;
				} else if (Mathf.Abs (positionTouch.x - d2.position.x) < (d2.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d2.position.y) < (d2.GetComponent<Collider> ().bounds.size.y / 2)) {
					dd = d2;
				} else if (Mathf.Abs (positionTouch.x - d3.position.x) < (d3.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d3.position.y) < (d3.GetComponent<Collider> ().bounds.size.y / 2)) {
					dd = d3;
				} else {
					dd = null;
				}

				dd.position = new Vector3 (dd.position.x,dd.position.y,dd.position.z-5);
				startPostionD = dd.position;
			}


			} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			if (GameController.instance.currentState == GameController.State.INGAME) {
				// Get movement of the finger since last frame
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

				// Move object across XY plane

				dd.Translate (touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0f);
			}

			} else if (Input.touchCount != 0 && Input.GetTouch (0).phase
			         == TouchPhase.Ended) {
			if (GameController.instance.currentState == GameController.State.INGAME) {
				GameController.instance.currentState = GameController.State.END;
				Vector3 positionTouch = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 vecH = new Vector3 (startPostionD.x - positionTouch.x, startPostionD.y - positionTouch.y, 0f).normalized;
				//dd.position = startPostionD; ;
				StartCoroutine (ieMoveD (vecH));
			}
		

			
		

		}
	}

	IEnumerator ieMoveD(Vector3 pVecter)
	{

		//vecterH=vecterH.normalized;
		while (dd.position.y > startPostionD.y)
		{
			dd.position += pVecter
				* moveSpeed
				* Time.deltaTime;
			yield return 0;
		}
		dd.position = new Vector3 (startPostionD.x,startPostionD.y,startPostionD.z+5);
	
		GameController.instance.currentState = GameController.State.INGAME;
	}
}
