using UnityEngine;
using System.Collections;

public class InGame : MonoBehaviour {


    public Transform C1;
    public Transform C2;
    public Transform C3;
    public Transform O1;
    public Transform O2;

	public int number = 1;
	public Transform d1;


    public void setData()
    {
        C1.localScale = new Vector3(0, 0, 1);
        C2.localScale = new Vector3(0, 0, 1);
        C3.localScale = new Vector3(0, 0, 1);
        O1.localScale = new Vector3(0, 0, 1);
        O2.localScale = new Vector3(0, 0, 1);

        StartCoroutine(WaitTimeC1(1f,C1));
        StartCoroutine(WaitTimeC1(2f, O1));
        StartCoroutine(WaitTimeC1(3f, C2));
        StartCoroutine(WaitTimeC1(4f, O2));
        StartCoroutine(WaitTimeC1(5f, C3));
    }

    IEnumerator WaitTimeC1(float time,Transform pC)
    {
        yield return new WaitForSeconds(time);
        pC.GetComponent<Zoom>().setZoom();
    }

	// Use this for initialization
	void Start () {

	}

	public float speed;
	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Move object across XY plane
			d1.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
		}else if (Input.touchCount != 0 && Input.GetTouch(0).phase 
			== TouchPhase.Ended)
		{
			number++;
		
		}
	}
}
