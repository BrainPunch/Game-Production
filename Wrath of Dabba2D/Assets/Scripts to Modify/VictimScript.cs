using UnityEngine;
using System.Collections;

public class VictimScript : MonoBehaviour {

    public float speed = 4f;
    Rigidbody2D rb;
    Transform t;

    public float point_value = 5f;

    public float damage = 0f; //Most Victims won't damage Dabba, maintain variable for function consistency

    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update () {

        //Need to add way to do up and down running
        t.Translate(-speed * Time.deltaTime, 0f, 0f);

        if (t.position.x < -50f)
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
