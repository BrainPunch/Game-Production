using UnityEngine;
using System.Collections;

public class DabbaFireball : MonoBehaviour {

    Transform t;
    public float speed = 10f;
    public UIDisplay Score_Tracker;


    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>();
        t.position = new Vector3(t.position.x, t.position.y, t.position.y); //Set the position of the object so its z value matches its Y value for layering purposes

        Score_Tracker = GameObject.Find("Canvas").GetComponent<UIDisplay>();
    }

    // Update is called once per frame
    void Update () {
        t.Translate(speed * Time.deltaTime, -0.1f * speed * Time.deltaTime, 0f);

        if (t.position.x >= 20f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D Hazard)
    {

        if (Hazard.gameObject.tag == "Obstacles" || Hazard.gameObject.tag == "Enemy")
        {
            //Debug.Log("Shot hit enemy");

            Enemy Enemy_Script = Hazard.gameObject.GetComponent<Enemy>(); //Get the Enemy Script so the point value can be accessed

            Score_Tracker.Scored_Points(Enemy_Script.point_value, Hazard.gameObject.name); //Score Points according to the enemy object's point_value and feed the name for multiplier

            Destroy(Hazard.gameObject); //Destroy the Obstacle the shot collided with

        }

        if (Hazard.gameObject.tag == "Victim") { //Scripting for Victims
            float PointsScored = Hazard.gameObject.GetComponent<VictimScript>().point_value; //Get the point value of the object being checked
            Score_Tracker.Scored_Points(PointsScored, Hazard.gameObject.name); //Score Points according to the enemy object's point_value and give the name for the multiplier

            Destroy(Hazard.gameObject); //Destroy the obstacle game object
        }

    }
}
