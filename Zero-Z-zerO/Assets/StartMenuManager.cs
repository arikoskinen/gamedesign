using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public void StartGame() {

        // Start Game here
        SceneManager.LoadScene("Scenes/1st_Stage");  // remember to add this scene to build settings!
        Debug.Log("StartGame button pressed");

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire")) {
            SceneManager.LoadScene("Scenes/1st_Stage");
        }
    }
}
