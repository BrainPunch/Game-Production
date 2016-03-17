using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 5f;
	Rigidbody2D rb;
	Transform t;

    public float point_value = 5f;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D> ();
		t = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		t.Translate (-speed *Time.deltaTime, 0f, 0f);

		if (t.position.x < -50f) {
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
