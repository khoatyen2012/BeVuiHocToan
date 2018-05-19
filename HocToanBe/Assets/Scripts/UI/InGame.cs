using UnityEngine;
using System.Collections;

public class InGame : MonoBehaviour {


	public int number = 1;

	public Transform d1;

	void Awake()
	{
		Application.targetFrameRate = 30;
		QualitySettings.vSyncCount = -1;
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
