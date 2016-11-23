using UnityEngine;
using System.Collections;

public class PlayerStartPos : MonoBehaviour {
    public int lives;
    public GameObject player;
    public Transform playerSpawn;
    private GameObject playerStartPos;

    // Use this for initialization
    void Awake() {
    }

    public void SpawnPlayer() {
        if (lives >= 1) {
            lives -= 1;
            playerStartPos = (GameObject)Instantiate(player, playerSpawn.position, playerSpawn.rotation);
        }
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Q)) {
            SpawnPlayer();
            lives -= 1;
        }

        if (lives < 0) {
            Debug.Log("Game Over");
        }
    }
}