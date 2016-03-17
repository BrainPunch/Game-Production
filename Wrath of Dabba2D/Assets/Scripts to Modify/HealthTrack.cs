﻿using UnityEngine;
using System.Collections;

public class HealthTrack: MonoBehaviour {

	public float Health = 100f;
	float Damage;

	// Use this for initialization
	void Start () {
        Debug.Log("Health = " + Health);

    }

    // Update is called once per frame
    void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D Hazard){
        //Debug.Log("Touched Something");

        if (Hazard.gameObject.tag == "Obstacles" || Hazard.gameObject.tag == "Enemy" )
        {
            //Debug.Log("Took Damage");

            Damage = 5; //Flat 5 damage for testing purposes 

            Health -= Damage; //Subtract the damage from the player's health

            Destroy(Hazard.gameObject); //Destroy the Obstacle after dealing damage

            //print("Remaining Health: " + Health);
        }

			
	

	}
}