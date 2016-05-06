using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class ButtonScript : MonoBehaviour {

    public int index = 1; //Index of the scene the game is trying to load in the build

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeScene() {

        //Debug.Log("Trying to Start game");

        SceneManager.LoadScene(index, LoadSceneMode.Single); //Load the scene at this index, Closes the loaded scene for the title screen

    }

    public void QuitGame() {
        //Debug.Log("Quitting Game");

        Application.Quit();
    }
}
