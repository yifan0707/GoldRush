using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cast : MonoBehaviour {
    private float force;
    public Rigidbody blast;
    public Rigidbody blast2;
    public Transform tf;
    public float forceLevel;
    public float forceLevel2;

    public float cooldown;
    public float cooldown2;
    private float currentCooldown;
    private float currentCooldown2;
    public Text cooldownText;
    public Text cooldownText2;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("left ctrl") && currentCooldown == 0f)
        {
            Rigidbody newBlast = Instantiate(blast, tf.transform.position, tf.transform.rotation);
            newBlast.AddForce(transform.forward * forceLevel);
            currentCooldown = cooldown;
        }
        else if (Input.GetKeyDown("q") && currentCooldown2 == 0f) {
            Debug.Log("engergy blast 2 casted");
            Rigidbody newBlast2 = Instantiate(blast2, tf.transform.position, tf.transform.rotation);
            newBlast2.AddForce(transform.forward * forceLevel);
            currentCooldown2 = cooldown2;
        }

        setcooldownText();


        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
        else {
            currentCooldown = 0;
        }


        if (currentCooldown2 > 0f)
        {
            currentCooldown2 -= Time.deltaTime;
        }
        else
        {
            currentCooldown2 = 0;
        }
    }

    public void setcooldownText()
    {
        this.cooldownText.text = "Ability one Cooldown: "+Mathf.Round(currentCooldown).ToString();
        this.cooldownText2.text = "Ability two Cooldown: " + Mathf.Round(currentCooldown2).ToString();
    }
}
