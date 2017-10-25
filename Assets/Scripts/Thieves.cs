using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thieves : MonoBehaviour {
	bool hasCoin;
	public Text coinRemainText;
	public threeSecArea middleArea;

	// Use this for initialization
	void Start () {
		middleArea = GameObject.Find ("threeSecArea").GetComponent<threeSecArea> ();
		this.setCoinRemainText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("coins"))
        {
            if (hasCoin == false)
            {
                other.gameObject.SetActive(false);
                Debug.Log("collision");
                middleArea.coinStealing();
                hasCoin = true;
                this.setCoinRemainText();
            }
        }
        else if (other.gameObject.CompareTag("blast")) {
            GameObject.FindWithTag("thieves").GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().SetMovementSpeed(0.5f);
            Debug.Log("the movement speed is reduced");
            StartCoroutine(reduceSpeed());
        }
	}

    IEnumerator reduceSpeed() {
        yield return new WaitForSeconds(3.0f);
        GameObject.FindWithTag("thieves").GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().SetMovementSpeed(1.0f);
        Debug.Log("the movement speed is back");
    }


	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("saveRoom")) {
			hasCoin = false;
		}
	}

	public void setCoinRemainText (){
		coinRemainText.text = "CoinRemain: " + middleArea.getRemainCoin().ToString ();
	}
		
	public bool getHasCoin(){
		return hasCoin;
	}
}
