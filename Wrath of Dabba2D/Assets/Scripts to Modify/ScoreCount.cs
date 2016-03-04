using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {

	public float Health = 100f;
	float Damage;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D Obstacle){

        Damage = 5; //Flat 5 damage for testing purposes 

		Health -= Damage; //Subtract the damage from the player's health

		Destroy(Obstacle.gameObject); //Destroy the Obstacle after dealing damage

        print ("Remaining Health: " + Health);

			
	

	}
}
