using UnityEngine;
using System.Collections;

public class DabbaControl: MonoBehaviour {


	public float speed = 5f; //Magnitude of Dabba's movement speed
    private Vector3 move; //Vector3 Variable will be used to define direction of movement


    float Xspeed = 1; //Variable to control x-axis movement

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) //If escape key is pressed, quit the application.
        {
            //Debug.Log("Hit Escape key");
            Application.Quit();
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
