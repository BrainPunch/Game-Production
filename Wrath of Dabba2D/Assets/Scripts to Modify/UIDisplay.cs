using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDisplay : MonoBehaviour {

    private float health_float = 100f;
    public Text Show_Health;
    public HealthTrack Dabba_Health_Script; //Give the UI access to Dabba's Health Script for display purposes

    private float score;
    public Text Show_Score;

    public DabbaShooter Shooter_Script;
    public Text Show_Ability;

    public Text Show_Uses;

    // Use this for initialization
    void Start()
    {
        health_float = Dabba_Health_Script.Health; //Get Dabba's Current Health as a float
        Show_Health.text = "HP   " + health_float.ToString(); //Give the value of Dabba's health to the Text object the UI will show

        score = 0;
        Show_Score.text = "SCORE   " + score.ToString(); //Score starts at 0 and is displayed as such

        Shooter_Script = GameObject.Find("Dabba's Shooter").GetComponent<DabbaShooter>(); //Get the Shooter Script from Dabba to access the power and number of uses

        Show_Ability.text = "Ability: None"; //No ability initially
    }

    // Update is called once per frame
    void Update()
    {
        if (Shooter_Script.Power != null) //If Dabba has acquired an ability (so Power is not null)
        {
            Show_Ability.text = "Ability: " + Shooter_Script.Power.name; //Ability displayed is the name of the power on the Shooter Script
        }
        Show_Uses.text = "Uses: " + Shooter_Script.uses.ToString(); //Convert the number of uses to a String for display
    }

    public void Took_Damage()
    { //Call this function from the HealthTrack Script when Dabba takes damage

        health_float = Dabba_Health_Script.Health; //Get Dabba's Current Health as a float
        Show_Health.text = "HP   " + health_float.ToString(); //Give the value of Dabba's health to the Text object the UI will show
    }

    public void Scored_Points(float Points_Earned)
    { //Use this function when the player scores points, passing in a float for the objects point value

        score += Points_Earned; //Increase score's value by the variable for points earned
        Show_Score.text = "SCORE   " + score.ToString(); //Display updated score
    }
}
