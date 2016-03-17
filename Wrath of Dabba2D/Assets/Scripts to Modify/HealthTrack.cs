using UnityEngine;
using System.Collections;

public class HealthTrack: MonoBehaviour {

	public float Health = 100f;
	float Damage;

    public UIDisplay Score_Tracker;
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

            Damage = 5; //Flat 5 damage for testing purposes 

            Health -= Damage; //Subtract the damage from the player's health

            Score_Tracker.Took_Damage(); //Calls UI Script's function for damage to change display text.

            Enemy Enemy_Script = Hazard.gameObject.GetComponent<Enemy>(); //Get the Enemy Script so the point value can be accessed

            Score_Tracker.Scored_Points(Enemy_Script.point_value); //Score Points according to the enemy object's point_value

            Destroy(Hazard.gameObject); //Destroy the Obstacle after dealing damage

        }

        

    }
}
