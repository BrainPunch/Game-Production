using UnityEngine;
using System.Collections;

public class DabbaControl: MonoBehaviour {


	public float speed = 5f; //Magnitude of Dabba's movement speed
    private Vector3 move; //Vector3 Variable will be used to define direction of movement

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        move = new Vector3( (Input.GetAxis("Vertical"))/2, Input.GetAxis("Vertical"), 0); //Define a Vector3 for the movement. X changes half as much as Y for perspective

        transform.position += move * speed * Time.deltaTime; //Adjust position based on speed and deltaTime

        
	}

	void FixedUpdate(){
		
	}
}
