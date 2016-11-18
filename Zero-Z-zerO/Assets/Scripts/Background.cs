using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public float timer;
    private float savedTimer;
    public GameObject background;
    public Transform startPoint;
    private GameObject startSpot;

    // Use this for initialization
    void Awake () {
        savedTimer = timer;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            startSpot = (GameObject)Instantiate(background, startPoint.position, startPoint.rotation);
            timer = savedTimer;
        }
        
    }
}
