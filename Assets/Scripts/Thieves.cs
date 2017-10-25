using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thieves : MonoBehaviour {
	bool hasCoin;
	public Text coinRemainText;
	public threeSecArea middleArea;
    public float cooldown;  //skill cooldown
    public GameObject thief1;
    public GameObject thief2;
    private float currentCooldown1;     //cooldown for theive1
    private float currentCooldown2;     //cooldown for theive2

    public Image skill1;
    public Image skill2;

	// Use this for initialization
	void Start () {
		middleArea = GameObject.Find ("threeSecArea").GetComponent<threeSecArea> ();
		this.setCoinRemainText();
        currentCooldown1 = 0f;
        currentCooldown2 = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("right ctrl") && currentCooldown1 == 0f)
        {
            boostSpeed(thief1);
            StartCoroutine(resetSpeed(thief1));
            currentCooldown1 = cooldown;
        }
        else if (Input.GetKeyDown("u") && currentCooldown2 == 0f) {
            boostSpeed(thief2);
            StartCoroutine(resetSpeed(thief2));
            currentCooldown2=cooldown;
        }
        updateTime();


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
            StartCoroutine(recoverSpeed());
        }
	}

    private void updateTime() {
        if (currentCooldown1 > 0f)
        {
            currentCooldown1 -= Time.deltaTime;
            skill1.fillAmount = 1-currentCooldown1 / cooldown;
        }
        if (currentCooldown2 > 0f)
        {
            currentCooldown2 -= Time.deltaTime;
            skill2.fillAmount = 1-currentCooldown2 / cooldown;

        }
        if (currentCooldown1 <= 0f)
        {
            currentCooldown1 = 0f;
        }
        if (currentCooldown2 <= 0f) {
            currentCooldown2 = 0f;
        }
    }



    //set the speed back to normal
    IEnumerator recoverSpeed() {
        yield return new WaitForSeconds(3.0f);
        GameObject.FindWithTag("thieves").GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().SetMovementSpeed(1.0f);
        Debug.Log("the movement speed is back to normal");
    }

    //reset the speed back to normal after short delay
    IEnumerator resetSpeed(GameObject thief) { 
        yield return new WaitForSeconds(0.1f);
        thief.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().SetMovementSpeed(1.0f);
        Debug.Log("the movement speed is back to normal");
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

    /**
     * this method will return the original speed multiplier
     * if the current thieve has been reduced speed then it wont being boosted
     */
    public void boostSpeed(GameObject thief) {
        if (thief.CompareTag("thieves")) {
            if (0.5f != thief.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().getMovementSpeed())
            {
                thief.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().SetMovementSpeed(3.0f);
            }
        }
    }



}
