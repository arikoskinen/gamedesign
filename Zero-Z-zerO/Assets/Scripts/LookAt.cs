using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
    private Transform target;
    public int rotationSpeed;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("PlayerShip NEO").transform;
        target = GameObject.Find("PlayerShip NEO 1").transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (target != null) {
            var to_playr = target.position - transform.position;
            var rtated_towrds_playr = Quaternion.LookRotation(Vector3.forward, to_playr);
            transform.rotation = Quaternion.Lerp(transform.rotation, rtated_towrds_playr, rotationSpeed * Time.deltaTime);
        }
    }
}
