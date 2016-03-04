using UnityEngine;
using System.Collections;

public class Playercontrol : MonoBehaviour {

	// Rigidbody2D rb; //Rigidbody to make sure objects don't pass through each other

	public float speed = 5f; //Magnitude of Dabba's movement speed

    private Vector3 move; //Vector3 Variable will be used to define direction of movement

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        move = new Vector3(0, Input.GetAxis("Vertical"), 0); //Define a Vector3 for the movement. Only the Y should have any value since Character only moves vertically (pending adjustment to match perspective

        transform.position += move * speed * Time.deltaTime; //Adjust position based on speed and deltaTime

        
	}

	void FixedUpdate(){
		
	}
}
