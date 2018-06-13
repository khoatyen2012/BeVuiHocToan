using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
	public int checkKQ=0;

    public float moveSpeed;
    public bool checkOperator = true;

    public int mB1 = 0;
    public int mB2 = 0;
    public int mKq = 0;


    List<int> lstTam;
    List<int> tmg;

	public tk2dUIItem btnContinute;
	public tk2dTextMesh txtLevel;


	public int mSub=0;
	public tk2dSprite mBG;
	public TapTap tap;

	public void setBGdata()
	{
		setData ();
		int tChon = UnityEngine.Random.Range (0, 4);
		if (tChon == 0) {
			mBG.SetSprite ("bgcaydua");
		} else if (tChon == 1) {
			mBG.SetSprite ("bgdongco");
		} else {
			mBG.SetSprite ("bgdonghoa");
		}
		this.transform.GetChild (11).gameObject.SetActive (true);
		this.transform.GetChild (11).GetComponent<MoveSun> ().setMove ();

	}

    public void setData()
    {
		mSub = 0;
		GameController.instance.mLevel++;
		if (GameController.instance.mLevel < 10) {
			txtLevel.text = "0" + GameController.instance.mLevel;
		} else {
			txtLevel.text = "" + GameController.instance.mLevel;
		}

        C1.localScale = new Vector3(0, 0, 1);
        C2.localScale = new Vector3(0, 0, 1);
        C3.localScale = new Vector3(0, 0, 1);
        O1.localScale = new Vector3(0, 0, 1);
        O2.localScale = new Vector3(0, 0, 1);

        GameController.instance.currentState = GameController.State.LOADZOOM;


      
        if (GameController.instance.mOperator == 0)
        {
            checkOperator = true;
        }
        else if (GameController.instance.mOperator == 1)
        {
            checkOperator = false;
        }
        else
        {
            int chon = UnityEngine.Random.Range(0, 2);
            if (chon == 0)
            {
                checkOperator = true;
            }
            else
            {
                checkOperator = false;
            }
        }

        if (checkOperator)
        {
          
			switch (GameController.instance.mNumber) {
			case 10:
				if (GameController.instance.mLevel < 6) {
					mB1 = UnityEngine.Random.Range(1, 6);
					mB2 = UnityEngine.Random.Range(0, 7 - mB1);
				} else if (GameController.instance.mLevel < 11) {
					mB1 = UnityEngine.Random.Range(1, 7);
					mB2 = UnityEngine.Random.Range(0, 8 - mB1);
				} else {
					mB1 = UnityEngine.Random.Range(2, GameController.instance.mNumber);
					mB2 = UnityEngine.Random.Range(0, GameController.instance.mNumber - mB1);
				}
				break;
			case 20:
				if (GameController.instance.mLevel < 6) {
					mB1 = UnityEngine.Random.Range(1, 10);
					mB2 = UnityEngine.Random.Range(0, 11 - mB1);
				} else if (GameController.instance.mLevel < 11) {
					mB1 = UnityEngine.Random.Range(1, 15);
					mB2 = UnityEngine.Random.Range(0, 16 - mB1);
				} else {
					mB1 = UnityEngine.Random.Range(10, GameController.instance.mNumber);
					mB2 = UnityEngine.Random.Range(0, GameController.instance.mNumber - mB1);
				}
				break;
			case 50:
				if (GameController.instance.mLevel < 6) {
					mB1 = UnityEngine.Random.Range(1, 15);
					mB2 = UnityEngine.Random.Range(0, 16 - mB1);
				} else if (GameController.instance.mLevel < 11) {
					mB1 = UnityEngine.Random.Range(1, 25);
					mB2 = UnityEngine.Random.Range(0, 26 - mB1);
				} else {
					mB1 = UnityEngine.Random.Range(10, GameController.instance.mNumber);
					mB2 = UnityEngine.Random.Range(0, GameController.instance.mNumber - mB1);
				}
				break;
			default:
				if (GameController.instance.mLevel < 6) {
					mB1 = UnityEngine.Random.Range(1, 50);
					mB2 = UnityEngine.Random.Range(0, 51 - mB1);
				} else if (GameController.instance.mLevel < 11) {
					mB1 = UnityEngine.Random.Range(25, 50);
					mB2 = UnityEngine.Random.Range(0, 51 - mB1);
				} else {
					mB1 = UnityEngine.Random.Range(50, GameController.instance.mNumber);
					mB2 = UnityEngine.Random.Range(0, GameController.instance.mNumber - mB1);
				}
				break;
			}

            mKq = mB1 + mB2;
            O1.GetComponent<tk2dSprite>().SetSprite("cong");
        }
        else
        {
            mB1 = UnityEngine.Random.Range(2, GameController.instance.mNumber);
            mB2 = UnityEngine.Random.Range(1, mB1);
            mKq = mB1 - mB2;
            O1.GetComponent<tk2dSprite>().SetSprite("tru");
        }

        C1.GetComponent<Cloud>().setDetail(mB1);
        C2.GetComponent<Cloud>().setDetail(mB2);


        lstTam = new List<int>();
        lstTam.Add(mKq);
        if (mKq <= 1)
        {
            lstTam.Add(0);
            lstTam.Add(2);
        }
        else if (mKq >= 98)
        {
            lstTam.Add(97);
            lstTam.Add(96);
        }
        else
        {
            tmg = new List<int>();
            tmg.Add(mKq - 1);
            tmg.Add(mKq - 2);
            tmg.Add(mKq + 1);
            tmg.Add(mKq +2);

            int chon = UnityEngine.Random.Range(0, tmg.Count);
            lstTam.Add(tmg[chon]);
            tmg.RemoveAt(chon);

            chon = UnityEngine.Random.Range(0, tmg.Count);
            lstTam.Add(tmg[chon]);
            tmg.RemoveAt(chon);

            tmg.Clear();

        }

        int chonk = UnityEngine.Random.Range(0, lstTam.Count);
        d1.GetComponent<Cloud>().setDetail(lstTam[chonk]);
        lstTam.RemoveAt(chonk);

        chonk = UnityEngine.Random.Range(0, lstTam.Count);
        d2.GetComponent<Cloud>().setDetail(lstTam[chonk]);
        lstTam.RemoveAt(chonk);

        d3.GetComponent<Cloud>().setDetail(lstTam[0]);



       

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
		if (GameController.instance.mLevel < 2) {
			StartCoroutine (WaitTimeTapTap (1.3f));
		}
	}
	IEnumerator WaitTimeTapTap(float time)
	{
		yield return new WaitForSeconds (time);
		tap.gameObject.SetActive (true);
		tap.setMove ();
	}

	// Use this for initialization
	void Start () {


		btnContinute.OnClick+=btnContinute_OnClick;

	}

	public float speed;
	void Update()
	{
		

			if (Input.touchCount != 0 && Input.GetTouch (0).phase
			   == TouchPhase.Began) {
			if (GameController.instance.currentState == GameController.State.INGAME) {
				Vector3 positionTouch = Camera.main.ScreenToWorldPoint (Input.mousePosition);

				if (Mathf.Abs (positionTouch.x - d1.position.x) < (d1.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d1.position.y) < (d1.GetComponent<Collider> ().bounds.size.y / 2)) {
					if (d1.GetComponent<Cloud> ().checkState) {
						dd = d1;
						checkKQ = 1;
					}
				} else if (Mathf.Abs (positionTouch.x - d2.position.x) < (d2.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d2.position.y) < (d2.GetComponent<Collider> ().bounds.size.y / 2)) {
					if (d2.GetComponent<Cloud> ().checkState) {
						dd = d2;
						checkKQ = 2;
					}
				} else if (Mathf.Abs (positionTouch.x - d3.position.x) < (d3.GetComponent<Collider> ().bounds.size.x / 2) && Mathf.Abs (positionTouch.y - d3.position.y) < (d3.GetComponent<Collider> ().bounds.size.y / 2)) {
					if (d3.GetComponent<Cloud> ().checkState) {
						dd = d3;
						checkKQ = 3;
					}
				} else {
					dd = null;
					checkKQ = 0;
				}

				startPostionD1 = d1.position;
				startPostionD2 = d2.position;
				startPostionD3 = d3.position;

				dd.position = new Vector3 (dd.position.x,dd.position.y,dd.position.z-5);
				startPostionD = dd.position;


			}


			} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			if (GameController.instance.currentState == GameController.State.INGAME) {
				// Get movement of the finger since last frame
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

				// Move object across XY plane

				dd.Translate (touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0f);
				if (GameController.instance.mLevel < 2) {
					tap.gameObject.SetActive (false);
				}
			}

			} else if (Input.touchCount != 0 && Input.GetTouch (0).phase
			         == TouchPhase.Ended) {
			if (GameController.instance.currentState == GameController.State.INGAME) {
				if (dd != null) {
					GameController.instance.currentState = GameController.State.END;

					float kc = Mathf.Sqrt (Mathf.Pow(C3.position.x-dd.position.x,2)+Mathf.Pow(C3.position.y-dd.position.y,2));

				

					if (kc < C3.GetComponent<Collider> ().bounds.size.x / 3) {
						dd.position = C3.position;
						if (dd.GetComponent<Cloud> ().mGiaTri == mKq) {

							setZoomSub ();
							StartCoroutine (WaitTimeMoveGiftBox (0.5f));
							StartCoroutine (WaitTimeShowContinute (2.5f));

						} else {
							dd.GetChild (2).gameObject.SetActive (true);
							StartCoroutine(WaitTimeMove(0.5f,C3.position));

							//Khoa khong cho di chuyen
							dd.GetComponent<Cloud> ().checkState = false;
							mSub++;
							GameController.instance.mStar -= mSub;
						}
					} else {
						Vector3 positionTouch = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						StartCoroutine(WaitTimeMove(0f,positionTouch));
					}

				
				}
			}
		

			
		

		}
	}

	void resetCloud()
	{
		//zoom ve vi tri ban dau
		d1.GetComponent<ZoomSub> ().setDefault ();
		d2.GetComponent<ZoomSub> ().setDefault ();
		d3.GetComponent<ZoomSub> ().setDefault ();

		//an cac nut huy di
		d1.GetChild (2).gameObject.SetActive (false);
		d2.GetChild (2).gameObject.SetActive (false);
		d3.GetChild (2).gameObject.SetActive (false);

		//bat lai che do move
		d1.GetComponent<Cloud> ().checkState = true;
		d2.GetComponent<Cloud> ().checkState = true;
		d3.GetComponent<Cloud> ().checkState = true;

		//set ve vi tri ban dau item
		d1.position = startPostionD1;
		d2.position = startPostionD2;
		d3.position = startPostionD3;
		DD.setStartPosition ();
	}

    public void btnContinute_OnClick()
    {
        resetCloud();
        GameController.instance.currentState = GameController.State.START;
        btnContinute.gameObject.SetActive(false);
        setData();
    }


	IEnumerator WaitTimeShowContinute(float time)
	{
		yield return new WaitForSeconds (time);
		if (GameController.instance.mLevel > 14) {
			resetCloud ();
			GameController.instance.currentState = GameController.State.GAMEOVER;


			this.transform.GetChild (11).GetComponent<MoveSun> ().setStop ();
			this.transform.GetChild (11).gameObject.SetActive (false);

            PopupController.instance.HideInGame();
            PopupController.instance.ShowGameOver();
		} else {
			btnContinute.gameObject.SetActive (true);
		}
	}

	IEnumerator WaitTimeMoveGiftBox(float time)
	{
		yield return new WaitForSeconds (time);
		GameController.instance.setMoveGitfBox ();
	}

	public void setZoomSub()
	{
		if (checkKQ == 1) {
			d2.GetComponent<ZoomSub> ().setZoom ();
			d3.GetComponent<ZoomSub> ().setZoom ();
		} else if (checkKQ == 2) {
			d1.GetComponent<ZoomSub> ().setZoom ();
			d3.GetComponent<ZoomSub> ().setZoom ();
			
		}else if (checkKQ == 3) {
			d1.GetComponent<ZoomSub> ().setZoom ();
			d2.GetComponent<ZoomSub> ().setZoom ();			
		}
	}

	IEnumerator WaitTimeMove(float time,Vector3 positionTouch )
	{
		yield return new WaitForSeconds (time);
		// tinh khoang cach cua y de doi chieu
		float ttt=Mathf.Abs(positionTouch.y-startPostionD.y);
	
		Vector3 vecH = new Vector3 (startPostionD.x - positionTouch.x, startPostionD.y - positionTouch.y, 0f).normalized;
		//dd.position = startPostionD; ;
		StartCoroutine (ieMoveD (vecH,ttt));
	}

	IEnumerator ieMoveD(Vector3 pVecter,float pKC)
	{

		//vecterH=vecterH.normalized;
		if (pKC > 30) {
			while (dd.position.y > startPostionD.y) {
				dd.position += pVecter
				* moveSpeed
				* Time.deltaTime;
				yield return 0;
			}
		}
		dd.position = new Vector3 (startPostionD.x,startPostionD.y,startPostionD.z+5);
		dd = null;
		GameController.instance.currentState = GameController.State.INGAME;
	}
}
