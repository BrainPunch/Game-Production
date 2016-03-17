using UnityEngine;
using System.Collections;

public class DabbaShooter : MonoBehaviour {

    public GameObject Shot;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Shot, (transform.position + new Vector3(2.5f, 0, 0)), Quaternion.identity); //Spawn the shot at Dabba's location and slightly ahead
        }
    }
}
