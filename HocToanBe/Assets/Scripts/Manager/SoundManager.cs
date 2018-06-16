using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


	public AudioClip[] arrAudioClip;

	#region Singleton
	private static SoundManager _instance;

	public static SoundManager Instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<SoundManager>();
			return _instance;
		}
	}
	#endregion

	public void PlayAudioCick()
	{
		tk2dUIAudioManager.Instance.Play(arrAudioClip[0]);
	}

	public void PlayAudioMath()
	{
		tk2dUIAudioManager.Instance.Play(arrAudioClip[1]);
	}

	public void PlayAudioOver()
	{
		tk2dUIAudioManager.Instance.Play(arrAudioClip[2]);
	}

	public void PlayAudioDD()
	{
		tk2dUIAudioManager.Instance.Play(arrAudioClip[3]);
	}

	public void PlayAudioWin()
	{
		tk2dUIAudioManager.Instance.Play (arrAudioClip [4]);
		tk2dUIAudioManager.Instance.Play (arrAudioClip [4]);
	}

	public void PlayAudioWinVN()
	{
		int chon = UnityEngine.Random.Range (0, 8);
		switch(chon)
		{
		case 0:
			tk2dUIAudioManager.Instance.Play (arrAudioClip [5]);
			break;
		case 1:
			tk2dUIAudioManager.Instance.Play (arrAudioClip [9]);
			break;
		case 2:
			tk2dUIAudioManager.Instance.Play (arrAudioClip [7]);
			break;
		case 3:
			tk2dUIAudioManager.Instance.Play (arrAudioClip [8]);
			break;
		default:
			tk2dUIAudioManager.Instance.Play (arrAudioClip [6]);
			break;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
