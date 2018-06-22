using UnityEngine;
using System.Collections;

public class ClsLanguage  {

	public static string doBuyVip()
	{
		string vaothi = "Become a VIP and Play Game without ever seeing an Ad !";
		if (GameController.instance.tienganh==1)
		{
			vaothi = "Trở thành Thành viên Vip và Không bị làm phiền bởi quảng cáo !";
		} else if (GameController.instance.tienganh==2)
		{
			vaothi = "Werden Sie VIP und spielen Sie, ohne jemals eine Anzeige gesehen zu haben!";
		}

		return vaothi;
	}
}
