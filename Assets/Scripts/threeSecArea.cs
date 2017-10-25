using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class threeSecArea : MonoBehaviour {
	public int coinRemain;
	public Thieves thief;
	public Thieves thief1;
	public Text thievesWinText;
	// Use this for initialization
	void Start () {
		thief = GameObject.Find ("thief").GetComponent<Thieves> ();
		thief1 = GameObject.Find ("thief1").GetComponent<Thieves> ();
		thievesWinText.text = "";
	}

	// Update is called once per frame
	void Update () {
		if (this.coinRemain==0&&thief.getHasCoin () == false && thief1.getHasCoin () == false) {
			setThievesWinText ();
		}
	}

	public void coinStealing(){
		this.coinRemain -= 1;
	}
	public int getRemainCoin(){
		return coinRemain;
	}

	public void setThievesWinText (){
		this.thievesWinText.text = "Thieves win!";
	}
}
