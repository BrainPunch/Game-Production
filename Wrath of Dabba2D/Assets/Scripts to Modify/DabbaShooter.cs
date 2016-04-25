using UnityEngine;
using System.Collections;

public class DabbaShooter : MonoBehaviour {

    public GameObject Power;
    public float uses;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetButtonDown("Fire1") && uses > 0) //If the fire button is pressed the ability has more than 0 uses
        {
            Instantiate(Power, (transform.position + new Vector3(2.5f, 0, 0)), Quaternion.identity); //Spawn the shot at Dabba's location and slightly ahead
            uses -= 1; //Decrease uses of Dabba's power by 1
        }

    }
}
