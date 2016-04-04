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
    }
	
	// Update is called once per frame
	void Update () {


        t.Translate(-speed * Time.deltaTime, 0f, 0f);

        if (t.position.x < -50f)
        {
            Destroy(gameObject);
        }
    }
}
