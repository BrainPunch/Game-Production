using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Item;
    public float StartOffset = 0f;
	public float SpawnTime = 5f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", StartOffset, SpawnTime);	
	}
	
	// Update is called once per frame
	void Spawn () {
		Instantiate (Item, transform.position, Quaternion.identity);
	}
}
