using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

    public int mGiaTri = 0;

    public void setDetail(int pGiaTri)
    {
        mGiaTri = pGiaTri;
        if (pGiaTri < 10)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);

            switch (pGiaTri)
            {
                case 0:
                    this.transform.GetChild(0).GetComponent<tk2dSprite>().SetSprite("ngayle_0");
                    break;
                default:
                    this.transform.GetChild(0).GetComponent<tk2dSprite>().SetSprite("ngayle_" + pGiaTri);
                    break;
            }

        }
        else
        {

            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);

            this.transform.GetChild(1).GetChild(0).GetComponent<tk2dSprite>().SetSprite("ngayle_" + ("" + pGiaTri).Substring(0, 1));
            this.transform.GetChild(1).GetChild(1).GetComponent<tk2dSprite>().SetSprite("ngayle_" + ("" + pGiaTri).Substring(1, 1));
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
