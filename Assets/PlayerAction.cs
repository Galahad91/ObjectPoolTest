using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    public float strength;
    public GameObject currentBullet;
    public GameObject bullet;
     
	
	void Start ()
    {
        strength = 0;
       
		
	}
	
	
	void Update ()
    {
		if (Input.GetMouseButton(0))
        {
            strength += Time.deltaTime * 10;
            
        }

        if (Input.GetMouseButtonUp(0))
        {
           StartCoroutine(currentBullet.GetComponent<ItemPool>().recharge(strength,this.transform));
            strength = 0;

        }
	}
}
