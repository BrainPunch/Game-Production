using UnityEngine;
using System.Collections;

public class TankShooter : MonoBehaviour {


    public float StartOffset = 0f;
    public float SpawnTime = 3f;

    public GameObject Tank_Shot;

    // Use this for initialization
    void Start () {

        InvokeRepeating("Shoot", StartOffset, SpawnTime);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shoot() {
        Instantiate(Tank_Shot, transform.position, Quaternion.identity);
    }
}
