using UnityEngine;
using System.Collections;

public class LimoPowerSpawn : MonoBehaviour {

    public UIDisplay Score_Tracker;

    // Randomizer for power up spawning from: http://gamedev.stackexchange.com/questions/119623/set-a-chance-to-spawn-for-each-gameobject-in-an-array
    // BE SURE TO LIST IN CREDITING

    // Define a structure for weighted objects to affect probability of spawning something
    // and flag it Serializable so it can be edited in the Inspector.
    [System.Serializable]
    public struct SpawnablePowers
    {
        public GameObject ActualItem; //Array will record the item
        public float weight; //And the percentage "weight" of it spawning. This weight is relative to all other objects
    }

    public SpawnablePowers[] PowerUpItems;

    float totalweight; //Float to record the total "weight" of all objects for percentage purposes

    void OnValidate() //Validates the information. Normally called when the script is loaded or something is changed in the inspector
    {
        totalweight = 0f;
        foreach (var spawnable in PowerUpItems) //Go throught every item in the array of Spawnables and find the total sum of their weight
            totalweight += spawnable.weight;
    }

    void Awake() //FailSafe to call OnValidate when script is loaded
    {
        OnValidate();
    }

    // Use this for initialization
    void Start () {
        if (!Score_Tracker)
        { //If ScoreTracker is not set somewhere
            Score_Tracker = GameObject.Find("Canvas").GetComponent<UIDisplay>(); //Set the score tracker to the UIDisplay script on the canvas
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy() {
        SpawnPower(); //Calls the SpawnPower script when the Limo is destroyed
    }

    void SpawnPower() { //This function will spawn the power up
        //Spawns randomly based on "weight" in the array

        float pick = Random.value * totalweight; //Get a value between 0 and 1. Multiply it by the total weight to get its relative number in that range
        int chosen = 0; //This will be the index of the item to be chosen in the Power Up array
        float cumulativeWeight = PowerUpItems[0].weight; //This will count the weight as the array is traveled through to find the chosen item

        while (pick > cumulativeWeight && chosen < PowerUpItems.Length - 1) //While the picked index "weight" exceeds the weight of the items checked so far in the array and the index has not exceeded the length of the array
        {
            chosen++; //Increment the Index by 1 to check the next item
            cumulativeWeight += PowerUpItems[chosen].weight; //Increase the cumulativeWeight, whhich records the weight of the objects checked thus far
        }

        //Once the above loop is completed, the cumululative Weight exceeds pick and thus "chosenIndex" should sit on the index of the selected item

        if (PowerUpItems[chosen].ActualItem) { //Instantiate the item if there is a valid gameObject at this Index. Allows insertion of a null Object chance so a Power Up doesn't always spawn

            Instantiate(PowerUpItems[chosen].ActualItem, transform.position, Quaternion.identity); //Instantiate the actual item chosen by the weight

        }
        //Instantiate(PowerUpItems[chosen].ActualItem, transform.position, Quaternion.identity); //Instantiate the actual item chosen by the weight

    }
}
