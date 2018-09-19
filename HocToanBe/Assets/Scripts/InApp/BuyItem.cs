using UnityEngine;
using System.Collections;

public class BuyItem : MonoBehaviour {
	
	public tk2dUIItem btnBuy;
	public tk2dUIItem btnCancel;
	public tk2dTextMesh txtContent;
	// Use this for initialization

	public void btnBuy_OnClick()
	{
		try
		{
		IAPManager.instance.BuyVipLevel();
		SoundManager.Instance.PlayAudioCick ();
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	public void btnCancel_OnClick()
	{
		try
		{
		PopupController.instance.HideBuyItem ();
		GameController.instance.currentState = GameController.State.END;
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	void Start () {
		try
		{
		btnBuy.OnClick += btnBuy_OnClick;
		btnCancel.OnClick += btnCancel_OnClick;
		txtContent.text = "" + ClsLanguage.doBuyVip ();
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
