using UnityEngine;
using System.Collections;

public class PowerSpawnScript : MonoBehaviour {

    public GameObject[] Item;
    public float StartOffset = 0f;
    public float SpawnTime = 5f;

    int a = 0;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", StartOffset, SpawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(Item[a%3], transform.position, Quaternion.identity);

        a++;
    }
}
