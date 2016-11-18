using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
