using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class DabbaControl: MonoBehaviour {


	public float speed = 5f; //Magnitude of Dabba's movement speed
    private Vector3 move; //Vector3 Variable will be used to define direction of movement
    public int mod = 1;
    private int timetracker = 0;
    public AudioSource foot = null;


    float Xspeed = 1; //Variable to control x-axis movement

    public UIDisplay Score_Tracker;

    // Use this for initialization
    void Start () {
        if (!Score_Tracker)
        { //If ScoreTracker is not set somewhere
            Score_Tracker = GameObject.Find("Canvas").GetComponent<UIDisplay>(); //Set the score tracker to the UIDisplay script on the canvas
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) //If escape key is pressed, quit the application.
        {
            //Debug.Log("Hit Escape key");
            SceneManager.LoadScene(3, LoadSceneMode.Single); //Go to the 3rd scene in the index, the game over screen
            Score_Tracker.Set_High_Score();
            

        }
        timetracker += 1;
        //print(timetracker);
        if (timetracker % mod == 0) {
            foot.Play();
            print("step");
        }
        move = new Vector3( ((Input.GetAxis("Vertical"))/2) * Xspeed, Input.GetAxis("Vertical"), 0); //Define a Vector3 for the movement. X changes half as much as Y for perspective, and uses Xspeed to limit movement at border

        transform.position += move * speed * Time.deltaTime; //Adjust position based on speed and deltaTime
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y); //Adjust Z position to match y position

        
	}

	void FixedUpdate(){
		
	}

    void OnCollisionEnter2D (Collision2D Wall) //On collision with a Wall
    {
        if (Wall.gameObject.tag == "Border") //If the object is a screen border
        {
            Xspeed = 0; //Set Xspeed to 0 so Dabba does not move on X
        }
    }

    void OnCollisionExit2D(Collision2D Wall) //When exiting collision with the Wall
    {
        if (Wall.gameObject.tag == "Border") //If the object is a screen border
        {
            Xspeed = 1; //Set Xspeed to 1 so Dabba can move on X-axis again
        }
    }
}
