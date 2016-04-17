using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 5f;
    Transform t;
    //Rigidbody2D rb;
    
    public float point_value = 5f;

    public float damage = 5f; //Value of the enemies damage for when implementing later

	// Use this for initialization
	void Start () {
		t = GetComponent<Transform> ();

        t.position = new Vector3 (t.position.x, t.position.y, t.position.y); //Set the position of the object so its z value matches its Y value for layering purposes
	}
	
	// Update is called once per frame
	void Update () {
		t.Translate (-speed *Time.deltaTime, 0f, 0f);

		if (t.position.x < -30f) {
			Destroy(gameObject);
		}
	}

    void OnCollisionEnter2D(Collision2D Edge)
    {

        if (Edge.gameObject.tag == "Border")
        {
            
            Destroy(gameObject);

        }

    }

}
