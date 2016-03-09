using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_Script : MonoBehaviour {

	private int target_count;
	public Text Count_Text;

	float Timer;
	public Text timer_text;
	float Time_Limit;
	public Text limit_text;

	public Text Win_Text;
	public Text Time_Up_Text;
	Target_Countdown EnderScript;
	// Use this for initialization
	void Start () {
		EnderScript = GameObject.Find ("GameEnder").GetComponent<Target_Countdown> ();
		target_count = EnderScript.num_targets; //Get the num_targets variable from the GameEnder object's Target_Countdown script
		Timer = EnderScript.timer;

		Time_Limit = EnderScript.time_limit;
		limit_text.text = "Time Limit: " + Time_Limit.ToString();

		Win_Text.text = "";
		Time_Up_Text.text = "";

		setText ();
	}
	
	// Update is called once per frame
	void Update () {
		Timer = EnderScript.timer;//Updates timer on each frame
		setText ();
	}

	public void HitTarget() {
		target_count = target_count - 1;
		setText ();

	}

	void setText () {
		Count_Text.text = "Targets Remaining: " + target_count.ToString ();
		timer_text.text = "Time Elapsed: " + Timer.ToString();

		if (target_count <= 0) {
			//Once all the targets have been hit
			Win_Text.text = "Finished!";
		}
		if (Timer >= Time_Limit) {
			//If the timer reaches the time limit
			Time_Up_Text.text = "Time's Up!!!";
		}
	}
}
