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
    }
	
	// Update is called once per frame
	void Update () {
        //t.Translate(-speed * Time.deltaTime, 0f, 0f);
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
