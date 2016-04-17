using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

    public GameObject Ability;
    public float Uses;

    public float speed = 5f;
    Transform t;

    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>();

        t.position = new Vector3(t.position.x, t.position.y, t.position.y); //Set the position of the object so its z value matches its Y value for layering purposes
    }
	
	// Update is called once per frame
	void Update () {

        t.Translate(-speed * Time.deltaTime, 0f, 0f);

        if (t.position.x < -30f)
        {
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
