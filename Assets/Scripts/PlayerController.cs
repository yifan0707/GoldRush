using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private int kills;
	private GameScript threeSecArea;
	public float timeLeft;
	public Text timeText;
	public Text guardianWinText;

	// Use this for initialization
	void Start () {
		if (this.name == "Guardian") {
			changeBodyColour (Color.red);
			this.guardianWinText.text="";
			kills = 0;
			setTimeText();
		} else if (this.name == "thief") {
			changeBodyColour (Color.black);
		} else {
			changeBodyColour (Color.grey);
		}

	}

	// Update is called once per frame
	void Update () {
		if (this.name == "Guardian") {
			if (timeLeft <= 0) {
				setGuradianWinText ();
				timeLeft = 0;
			}else {
				timeLeft = timeLeft - Time.deltaTime;
			}
			setTimeText ();
			if (this.getKills()>=2) {
				this.setGuradianWinText ();
			} 
		}
	}

	void OnTriggerEnter(Collider other) {
		if (this.name == "Guardian" && other.gameObject.CompareTag ("threeSecArea")) {
			this.transform.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().SetMovementSpeed (0.5f);
		} else if (this.name=="Guardian"&&other.gameObject.CompareTag ("thieves")) {
			other.gameObject.SetActive (false);
			kills += 1;
		}
			
	}

	void OnTriggerExit(Collider other) {
		if(this.name=="Guardian"&&other.gameObject.CompareTag("threeSecArea")){
			this.transform.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().SetMovementSpeed (1.5f);
		}
	}
		
	public void changeBodyColour(Color colour){
		this.transform.gameObject.GetComponentInChildren<EthanBody> ().GetComponent<Renderer> ().material.color = colour;
	}

	public int getKills(){
		return kills;
	}

	void setTimeText(){
		timeText.text = ((int)timeLeft).ToString ();
	}

	public void setGuradianWinText(){
		this.guardianWinText.text="Guardian wins!";
	}
		

}
