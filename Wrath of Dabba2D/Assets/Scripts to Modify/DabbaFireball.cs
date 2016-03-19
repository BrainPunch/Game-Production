﻿using UnityEngine;
using System.Collections;

public class DabbaFireball : MonoBehaviour {

    Transform t;
    public float speed = 10f;

    public UIDisplay Score_Tracker;


    // Use this for initialization
    void Start () {
        t = GetComponent<Transform>();

        Score_Tracker = GameObject.Find("Canvas").GetComponent<UIDisplay>();

    }

    // Update is called once per frame
    void Update () {
        t.Translate(speed * Time.deltaTime, 0f, 0f);


        if (t.position.x > 20f)
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

            Score_Tracker.Scored_Points(Enemy_Script.point_value); //Score Points according to the enemy object's point_value

            Destroy(Hazard.gameObject); //Destroy the Obstacle the shot collided with

        }

    }
}