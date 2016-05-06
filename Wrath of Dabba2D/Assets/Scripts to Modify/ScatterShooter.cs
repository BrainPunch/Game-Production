using UnityEngine;
using System.Collections;

public class ScatterShooter : MonoBehaviour {

    public float StartOffset = 0f;

    public GameObject ScatteredShot;

    GameObject Shot1;
    GameObject Shot2;

    // Use this for initialization
    void Start () {

        Invoke("ScatterShoot", StartOffset); //Waits through StartOffset and invokes Shoot once
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void ScatterShoot()
    {
        float randomTime = Random.Range(3, 6); //Determine an amount of time within the range (exclusive) to invoke the function again

        Shot1 = (GameObject)Instantiate(ScatteredShot, transform.position, Quaternion.identity); //Spawn 3 shots, need to make them scatter
        
        Shot2 = (GameObject)Instantiate(ScatteredShot, transform.position, Quaternion.identity); //Capture reference to the instantiated shot so their directions can be adjusted
        
        Instantiate(ScatteredShot, transform.position, Quaternion.identity); //Shot 3 should fly as normal

        //Anything done to these instantiated shots in this function occurs before their own Start()
        
        ScatterProjectile Shot1Script = Shot1.GetComponent<ScatterProjectile>(); //Get the Scattershot's script
        Shot1Script.ChangeDir(new Vector3(0f, 2f, 0f) ); //Change the direction by this particular offset using a function on the script

        ScatterProjectile Shot2Script = Shot2.GetComponent<ScatterProjectile>();
        Shot2Script.ChangeDir(new Vector3(0f, -2f, 0f)); //Change the direction by this particular offset

        //Can change the Spread's width by adjusting the y value in the above Vector3's

        Invoke("ScatterShoot", randomTime); //Invoke the shoot function again 
    }
}
