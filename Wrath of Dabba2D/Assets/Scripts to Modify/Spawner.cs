using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] Spawnables;
    public float StartOffset = 0f;
    public int MinWaitTime = 1;
    public int MaxWaitTime = 2;

    //int SpawnInd = 0; //Int to randomly spawn something from the array of objects in Spawnables

    public float speed = 1.5f;
    public int direction = 1;
    
    // Use this for initialization
    void Start () {
        //InvokeRepeating ("Spawn", StartOffset, SpawnTime);

        Invoke("Spawn", StartOffset); //Waits through StartOffset and invokes Spawn once
	}

    // Update is called once per frame

    void Update()
    {
        //Can move between -4.2 and 0.5 on Y-axis in this scene
        if (transform.position.y >= 0.5) { //If it goes to 0.5 or more
            direction = -1; //Change direction to be negative
        }
        if (transform.position.y <= -4.2) { //If it goes to -4.2 or below
            direction = 1; //Change direction back to positive
        }

        transform.Translate(0f, speed*direction*Time.deltaTime, speed * direction * Time.deltaTime); //Changes position along the y and z-axis, the latter for layering purposes
    }

    void Spawn () {
        //SpawnInd = Random.Range(0, Spawnables.Length ) ;

        float randomTime = Random.Range(MinWaitTime, MaxWaitTime); //Determine an amount of time between 3 and 8 seconds (exclusive) to invoke the function again



        Instantiate (Spawnables[Random.Range(0, Spawnables.Length)], transform.position, Quaternion.identity);

        Invoke("Spawn", randomTime); //Invoke the function again after the random amount of time has passed.
    }
}
