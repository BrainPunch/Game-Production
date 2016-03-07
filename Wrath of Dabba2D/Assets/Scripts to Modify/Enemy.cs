using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 5f;
	Rigidbody2D rb;
	Transform t;
    Object GObject;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D> ();
		t = GetComponent<Transform> ();
        GObject = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		t.Translate (-speed *Time.deltaTime, 0f, 0f);

		if (t.position.x < -50f) {
			Destroy(gameObject);
		}
	}

}
