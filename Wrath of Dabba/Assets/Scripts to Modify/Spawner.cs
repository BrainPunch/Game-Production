using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Item;
	public float SpawnTime = 15f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 0f, SpawnTime);	
	}
	
	// Update is called once per frame
	void Spawn () {
		Instantiate (Item, transform.position, Quaternion.identity);
	}
}
