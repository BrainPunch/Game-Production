using UnityEngine;
using System.Collections;

public class HealthTrack: MonoBehaviour {

	public float Health = 100f;
	float Damage;

    public UIDisplay Score_Tracker;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        if (Health <= 0) { //If Dabba's Health drops to 0 or below
            Time.timeScale = 0; //Set time scale to 0 to effectively pause the game.
        }
	
	}

	void OnCollisionEnter2D(Collision2D Hazard){
        //Debug.Log("Touched Something");

        if (Hazard.gameObject.tag == "Obstacles")
        {
            Enemy Enemy_Script = Hazard.gameObject.GetComponent<Enemy>(); //Get the Enemy Script so the point value can be accessed
            Health -= Enemy_Script.damage; //Subtract the enemy's damage value from Dabba's health
            Score_Tracker.Took_Damage(); //Calls UI Script's function for damage to change display text.
            Score_Tracker.Scored_Points(Enemy_Script.point_value, Hazard.gameObject.name); //Score Points according to the enemy object's point_value
            Destroy(Hazard.gameObject); //Destroy the Obstacle after dealing damage
        }

        if (Hazard.gameObject.tag == "Victim")
        {
            VictimScript VictimNumbers = Hazard.gameObject.GetComponent<VictimScript>(); //Get the Victim Script so the point value can be accessed
            Score_Tracker.Scored_Points(VictimNumbers.point_value, Hazard.gameObject.name); //Score Points according to the object's point_value
            Destroy(Hazard.gameObject); //Destroy the Obstacle after dealing damage
        }

        else if (Hazard.gameObject.tag == "PowerUp") //If the thing Dabba touched is a PowerUp
        {
            DabbaShooter ShooterScript = gameObject.GetComponentInChildren<DabbaShooter>(); //Get the script Dabba uses for power up abilities
            PowerUpScript PowerScript = Hazard.gameObject.GetComponent<PowerUpScript>(); //Get the script attached to the Power Up object
            ShooterScript.Power = PowerScript.Ability;
            ShooterScript.uses = PowerScript.Uses;
            Destroy(Hazard.gameObject); //Destroy the Power Up after setting numbers
        }

        else if (Hazard.gameObject.tag == "Health") { //For the health restoring power up
            RestoreHealth HealthScript = Hazard.gameObject.GetComponent<RestoreHealth>(); //Get the script for restoring health
            Health += HealthScript.Restores; //Restore the amount of health for the power up

            Score_Tracker.Took_Damage(); //Calls UI Script's function for damage to change display text. Same script despite health being gained
            Destroy(Hazard.gameObject); //Destroy the Power Up after setting numbers
        }

    }
}
