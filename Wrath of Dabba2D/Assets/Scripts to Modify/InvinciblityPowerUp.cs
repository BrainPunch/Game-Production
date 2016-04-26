using UnityEngine;
using System.Collections;

public class InvinciblityPowerUp : MonoBehaviour {

    float speed = 5f;

    public float duration = 20f;
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y); //Set the position of the object so its z value matches its Y value for layering purposes
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(-speed * Time.deltaTime, 0f, 0f);

        if (transform.position.x <= -30f)
        {
            Destroy(gameObject);
        }
    }
}
