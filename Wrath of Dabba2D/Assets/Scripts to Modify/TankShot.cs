using UnityEngine;
using System.Collections;

public class TankShot : MonoBehaviour {

    Transform t;

    Vector3 Shot_start;
    public float speed = 10f;
    public UIDisplay Score_Tracker;

    Transform Dabba_Loc;
    Vector3 Dabba_start;

    public float point_value = 0f; //Shot is worth no points, only meant to hurt Dabba

    public float damage = 5f; //Value of damage for when implementing later

    Vector3 direction;


    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>(); //Get Transform of this shot GameObject
        Shot_start = transform.position;

        Score_Tracker = GameObject.Find("Canvas").GetComponent<UIDisplay>();

        Dabba_Loc = GameObject.Find("Dabba").GetComponent<Transform>(); //Get the Transform of Dabba at the time the shot is spawned
        Dabba_start = Dabba_Loc.position; //Get Dabba's position when the projectile is spawned

        direction = (Dabba_start - Shot_start).normalized;

        t.position = new Vector3(t.position.x, t.position.y, t.position.y); //Set the position of the object so its z value matches its Y value for layering purposes
    }
	
	// Update is called once per frame
	void Update () {
        if (Dabba_Loc == null) {
            Debug.Log("No Dabba Loc");
        }


        float step = speed * Time.deltaTime;
        t.Translate(step * direction);

        if (t.position.x > 20f)
        {
            Destroy(gameObject);
        }
    }
}
