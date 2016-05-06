using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScoreShow : MonoBehaviour {

    public Text Show_HighScore;
    public float HighScore;

	// Use this for initialization
	void Start () {
        HighScore = PlayerPrefs.GetFloat("High Score");
        Show_HighScore.text = "The High Score is: " + HighScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
