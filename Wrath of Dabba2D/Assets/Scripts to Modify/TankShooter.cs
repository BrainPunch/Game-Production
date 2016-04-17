using UnityEngine;
using System.Collections;

public class TankShooter : MonoBehaviour {


    public float StartOffset = 0f;

    public GameObject Tank_Shot;

    // Use this for initialization
    void Start () {

        //InvokeRepeating("Shoot", StartOffset, SpawnTime);

        Invoke("Shoot", StartOffset); //Waits through StartOffset and invokes Shoot once
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shoot() {
        float randomTime = Random.Range(3, 6); //Determine an amount of time within the range (exclusive) to invoke the function again

        Instantiate(Tank_Shot, transform.position, Quaternion.identity);

        Invoke("Shoot", randomTime);
    }
}
