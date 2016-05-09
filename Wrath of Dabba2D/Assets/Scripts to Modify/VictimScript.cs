using UnityEngine;
using System.Collections;

public class VictimScript : MonoBehaviour {

    public float speed = 4f;
    Rigidbody2D rb;
    Transform t;

    public float point_value = 5f;

    public float damage = 0f; //Most Victims won't damage Dabba, maintain variable for function consistency

    public int direction = 1;

    public GameObject Explosive;
    public AudioSource scream = null;

    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>();
        scream.pitch = Random.Range(0.5f, 1f);
        scream.Play();
        t.position = new Vector3(t.position.x, t.position.y, t.position.y); //Set the position of the object so its z value matches its Y value for layering purposes
    }

    // Update is called once per frame
    void Update () {

        //Need to add way to do up and down running and change Translate's Y-component
        //Can move between -4.5 and 0.5 on Y-axis in this scene
        if (transform.position.y >= 0.5)
        { //If it goes to 0.5 or more
            direction = -1; //Change direction to be negative
        }
        if (transform.position.y <= -4.5)
        { //If it goes to -4.5 or below
            direction = 1; //Change direction back to positive
        }

        t.Translate(-speed * Time.deltaTime, speed*direction*Time.deltaTime, speed*direction*Time.deltaTime);

        if (t.position.x < -30f) //Safety measure to destroy object if it strays from the focused scene
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

    void OnDestroy()
    {
        if (Explosive != null)
        { //If there is a gameobject for the explosion
            Instantiate(Explosive, transform.position, Quaternion.identity); //Instantiate the explosion
        }
    }
}
