using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDisplay : MonoBehaviour {

    private float health_float = 100f;
    public Text Show_Health;
    public HealthTrack Dabba_Health_Script; //Give the UI access to Dabba's Health Script for display purposes

    private float score;
    public Text Show_Score;

    // Use this for initialization
    void Start()
    {
        health_float = Dabba_Health_Script.Health; //Get Dabba's Current Health as a float
        Show_Health.text = "Health: " + health_float.ToString(); //Give the value of Dabba's health to the Text object the UI will show

        score = 0;
        Show_Score.text = "Score: " + score.ToString() + " pts"; //Score starts at 0 and is displayed as such
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Took_Damage()
    { //Call this function from the HealthTrack Script when Dabba takes damage

        health_float = Dabba_Health_Script.Health; //Get Dabba's Current Health as a float
        Show_Health.text = "Health: " + health_float.ToString(); //Give the value of Dabba's health to the Text object the UI will show
    }

    public void Scored_Points(float Points_Earned)
    { //Use this function when the player scores points, passing in a float for the objects point value

        score += Points_Earned; //Increase score's value by the variable for points earned
        Show_Score.text = "Score: " + score.ToString() + " pts"; //Display updated score
    }
}
