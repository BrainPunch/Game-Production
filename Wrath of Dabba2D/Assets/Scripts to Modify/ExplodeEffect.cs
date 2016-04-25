using UnityEngine;
using System.Collections;

public class ExplodeEffect : MonoBehaviour {

    public float ExplosionTime = 0.5f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, ExplosionTime); //Destroy the object after "ExplosionTime" seconds pass from its spawn
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
