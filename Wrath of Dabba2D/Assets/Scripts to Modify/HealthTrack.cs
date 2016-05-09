using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class HealthTrack: MonoBehaviour {

	public float Health = 100f;
	float Damage;
    public AudioSource agh = null;
    public AudioSource invin = null;
    public AudioSource bgm = null;
    public AudioSource bing = null;
    public AudioSource health = null;

    public UIDisplay Score_Tracker;

    public bool Invinciblity = false; //Boolean to decide if Dabba is Invincible
    float InvinceTime = 0f; //Time Dabba will be invincible for.
    Animator anim;

    // Use this for initialization
    void Start () {
        if (!Score_Tracker) { //If ScoreTracker is not set somewhere
            Score_Tracker = GameObject.Find("Canvas").GetComponent<UIDisplay>(); //Set the score tracker to the UIDisplay script on the canvas
        }
        Time.timeScale = 1;//Set Timescale to 1 to undo stop from previous games
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        if (Health <= 0 && Time.timeScale != 0) { //If Dabba's Health drops to 0 or below and the game is not already stopped with a 0 Timescale

            Score_Tracker.Set_High_Score(); //Call the function to set the high score
            Time.timeScale = 0; //Set time scale to 0 to effectively pause the game.
            StopGame(); //Call the function that stops the game
        }
        if (Invinciblity == true) {
            GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            
        }
        else {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            
        }
        InvinceTime -= Time.deltaTime; //Reduce the Invincibility time every frame
        if (InvinceTime <= 0 && Invinciblity == true) { //If the duration drops to 0
            //Debug.Log("Not Invincible");
            invin.Stop();
            bgm.Play();
            Invinciblity = false; //Set invincible to false
        }
	}

	void OnCollisionEnter2D(Collision2D Hazard){
        //Debug.Log("Touched Something");

        if (Hazard.gameObject.tag == "Obstacles")
        {
            Enemy Enemy_Script = Hazard.gameObject.GetComponent<Enemy>(); //Get the Enemy Script so the point value can be accessed

            if (Invinciblity == false)
            { //Only deduct health is Dabba is not invincible. Check if Invincibility is true

                Health -= Enemy_Script.damage; //Subtract the enemy's damage value from Dabba's health
                Score_Tracker.Took_Damage(); //Calls UI Script's function for damage to change display text.
                if (Enemy_Script.damage > 0) {
                    anim.SetTrigger("hurt");
                    agh.Play();
                }
                print("hit");
            }
            else { Debug.Log("Invincible, no damage"); }
            
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
            bing.Play();
        }

        else if (Hazard.gameObject.tag == "Health") { //For the health restoring power up
            RestoreHealth HealthScript = Hazard.gameObject.GetComponent<RestoreHealth>(); //Get the script for restoring health
            Health += HealthScript.Restores; //Restore the amount of health for the power up
            health.Play();
            Score_Tracker.Took_Damage(); //Calls UI Script's function for damage to change display text. Same script despite health being gained
            Destroy(Hazard.gameObject); //Destroy the Power Up after setting numbers
        }

        else if (Hazard.gameObject.tag == "Invincibility") { //For the invincibility power up.

            Invinciblity = true;
            InvinceTime = Hazard.gameObject.GetComponent<InvinciblityPowerUp>().duration; //Make Dabba Invincible and set its duration to the one given by the powerup
            bgm.Stop();
            invin.Play();
            Destroy(Hazard.gameObject); //Destroy the Power Up after setting numbers
        }

    }

    public void StopGame() { //Change the scene since the game is over.
        
        SceneManager.LoadScene(3, LoadSceneMode.Single); //Go to the 3rd scene in the index, the game over screen
        Score_Tracker.Set_High_Score();

    }
}
