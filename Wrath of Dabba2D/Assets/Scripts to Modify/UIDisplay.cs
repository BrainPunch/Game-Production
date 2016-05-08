using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDisplay : MonoBehaviour {

    private float health_float = 100f;
    public Text Show_Health;
    public HealthTrack Dabba_Health_Script; //Give the UI access to Dabba's Health Script for display purposes

    public float score;
    float highscore; //float to hold the high score value
    float multiplier = 1;
    string prev_object = "";

    public Text Show_Score;
    //public Text High_Score; 

    public DabbaShooter Shooter_Script;
    public Text Show_Ability;

    public Text Show_Uses;

    // Use this for initialization
    void Start()
    {
        health_float = Dabba_Health_Script.Health; //Get Dabba's Current Health as a float
        Show_Health.text = "HP   " + health_float.ToString(); //Give the value of Dabba's health to the Text object the UI will show

        score = 0;
        highscore = PlayerPrefs.GetFloat("High Score");

        Show_Score.text = "SCORE   " + score.ToString() + "\n Multiplier:    x" + multiplier.ToString() + "\n High Score:    " + highscore.ToString(); //Score starts at 0 and is displayed as such


        Shooter_Script = GameObject.Find("Dabba's Shooter").GetComponent<DabbaShooter>(); //Get the Shooter Script from Dabba to access the power and number of uses

        Show_Ability.text = "Ability"; //No ability initially
    }

    // Update is called once per frame
    void Update()
    {
        if (Shooter_Script.Power != null) //If Dabba has acquired an ability (so Power is not null)
        {
            Show_Ability.text = Shooter_Script.Power.name; //Ability displayed is the name of the power on the Shooter Script
        }
        Show_Uses.text = "x" + Shooter_Script.uses.ToString(); //Convert the number of uses to a String for display

    }

    public void Took_Damage()
    { //Call this function from the HealthTrack Script when Dabba takes damage

        health_float = Dabba_Health_Script.Health; //Get Dabba's Current Health as a float
        Show_Health.text = "HP   " + health_float.ToString(); //Give the value of Dabba's health to the Text object the UI will show
    }

    public void Scored_Points(float Points_Earned, string enemy_name)
    { //Use this function when the player scores points, passing in a float for the objects point value

        score += Points_Earned * multiplier; //Increase score's value by the variable for points earned
        Show_Score.text = "SCORE   " + score.ToString() + "\n Multiplier:    x" +multiplier.ToString() + "\n High Score:    " + highscore.ToString(); //Display in game score, multiplier, and highscore

        if (enemy_name == prev_object)
        { //If the enemy_name matches that of the previous object
            multiplier += 1; //Increase the multiplier by 1
        }
        else
        {
            prev_object = enemy_name; //Remember this name as the most recent object to reset the multiplier check
            multiplier = 1; //Set the multiplier back to 1
        }
    }

    public void Set_High_Score() {

        if (score > highscore) //Set highscore to equal the current score only if the current score > saved highscore
        {
            highscore = score;
            PlayerPrefs.SetFloat("High Score", highscore);

            Debug.Log("High Score is " + highscore);

        }
    }
}
