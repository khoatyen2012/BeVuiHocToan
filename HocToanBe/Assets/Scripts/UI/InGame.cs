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

    public float moveSpeed;



    public void setData()
    {
        C1.localScale = new Vector3(0, 0, 1);
        C2.localScale = new Vector3(0, 0, 1);
        C3.localScale = new Vector3(0, 0, 1);
        O1.localScale = new Vector3(0, 0, 1);
        O2.localScale = new Vector3(0, 0, 1);

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


	

	}

	public float speed;
	void Update()
	{
		if (Input.touchCount != 0 && Input.GetTouch(0).phase 
			== TouchPhase.Began)
		{
			Vector3 positionTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Mathf.Abs (positionTouch.x - d1.position.x) < (d1.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d1.position.y) < (d1.GetComponent<Collider> ().bounds.size.y / 2)) {
				dd = d1;
			} else if (Mathf.Abs (positionTouch.x - d2.position.x) < (d2.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d2.position.y) < (d2.GetComponent<Collider> ().bounds.size.y / 2)) {
				dd = d2;
			} else if (Mathf.Abs (positionTouch.x - d3.position.x) < (d3.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d3.position.y) < (d3.GetComponent<Collider> ().bounds.size.y / 2)) {
				dd = d3;
			} else {
				dd = null;
			}
			startPostionD = dd.position;

		}else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Move object across XY plane
			dd.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
		}else if (Input.touchCount != 0 && Input.GetTouch(0).phase 
			== TouchPhase.Ended)
		{
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
		

			dd.position = startPostionD; ;
			//StartCoroutine(ieMoveD(touchDeltaPosition));

			
		
		}
	}

    IEnumerator ieMoveD(Vector2 pVecter)
    {
		Vector3 vecterH = new Vector3(startPostionD.x - pVecter.x, startPostionD.y - pVecter.y,0f);
		//vecterH=vecterH.normalized;
        while (dd.position.y > startPostionD.y)
        {
			dd.position += vecterH
                * moveSpeed
                * Time.deltaTime;
            yield return 0;
        }
       // dd.position = startPostionD; ;
        dd = null;
    }
}
