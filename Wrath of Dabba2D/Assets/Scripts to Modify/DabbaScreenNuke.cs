using UnityEngine;
using System.Collections;

public class DabbaScreenNuke : MonoBehaviour {

    Transform t;
    public UIDisplay Score_Tracker;

    public float rad = 50f; //Use a huge radius with Shockwave Programming to envelop screen

    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>(); //Get transform of the object, used to represent its position and "center" of shockwave
        Score_Tracker = GameObject.Find("Canvas").GetComponent<UIDisplay>(); //Get the script that tracks the score on the Canvas for UI display

        ScreenNukeAttack(rad); //As soon as the shockwave is "spawned", use the function for its attack
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void ScreenNukeAttack(float rad)
    { //Shockwave function takes in a radius

        Collider2D[] ObjectsInWave = Physics2D.OverlapCircleAll(t.position, rad); //Get colliders for every object within "radius" with the shockwave's position at the center

        int a = 0;
        while (a < ObjectsInWave.Length) //Iterate through the array of colliders 
        {

            if (ObjectsInWave[a].gameObject.tag == "Obstacles" || ObjectsInWave[a].gameObject.tag == "Enemy") //If the collider's game object has the "Obstacles" or "Enemy" tag
            {
                float PointsScored = ObjectsInWave[a].gameObject.GetComponent<Enemy>().point_value; //Get the point value of the object being checked
                Score_Tracker.Scored_Points(PointsScored, ObjectsInWave[a].gameObject.name); //Score Points according to the enemy object's point_value and give hte name for the multiplier

                Destroy(ObjectsInWave[a].gameObject); //Destroy the obstacle game object
            }

            a++; //Increment a to advance in the array
        }

        Destroy(gameObject); //Destroy the ShockWave once it has destroyed everything in radius.
    }
}
