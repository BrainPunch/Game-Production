using UnityEngine;
using System.Collections;

public class ScatterProjectile : MonoBehaviour {

    Transform t;
    public Vector3 Shot_start; //Make Vector3's public so they can be adjusted on spawn by the shooter

    public float speed = 10f;
    public UIDisplay Score_Tracker;

    public Transform Dabba_Loc;

    public Vector3 Dabba_start;

    public float point_value = 0f; //Shot is worth no points, only meant to hurt Dabba

    public float damage = 5f; //Value of damage

    public Vector3 direction;

    //Vector3 ScatterOffset; //Vector to change direction of a particular scattershot when instantiated.

    // Use this for initialization
    void Start () {

        
    }

    void Awake() { //For Scattershot, initialize these values on Awake() instead of on Start(). This ensures they have these values as soon as they exist

        t = GetComponent<Transform>(); //Get Transform of this shot GameObject
        Shot_start = transform.position;

        Score_Tracker = GameObject.Find("Canvas").GetComponent<UIDisplay>();

        Dabba_Loc = GameObject.Find("Dabba").GetComponent<Transform>(); //Get the Transform of Dabba at the time the shot is spawned
        Dabba_start = Dabba_Loc.position; //Get Dabba's position when the projectile is spawned


        direction = (Dabba_start - Shot_start); //Normalize the direction towards the point in question for use in movement
        direction.Normalize();

        t.position = new Vector3(t.position.x, t.position.y, t.position.y); //Set the position of the object so its z value matches its Y value for layering purposes        
    }
	
	// Update is called once per frame
	void Update () {
        if (Dabba_Loc == null)
        {
            Debug.Log("No Dabba Loc");
        }


        float step = speed * Time.deltaTime;
        t.Translate(step * direction);

        if (t.position.x > 20f)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeDir(Vector3 offset) {
                
        direction = ( (Dabba_start + offset) - Shot_start).normalized; //Add the point of offset to the starting location and shot_start variables and renormalize
        
    }
}
