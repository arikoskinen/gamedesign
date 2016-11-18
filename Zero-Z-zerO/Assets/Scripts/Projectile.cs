using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public int dMG;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
