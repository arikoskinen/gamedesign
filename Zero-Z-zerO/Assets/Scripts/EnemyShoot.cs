using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    public GameObject projectile;
    private float spawnDistance = 0f;
    public float whenToShoot = 5;
    private GameObject gun1;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        whenToShoot -= Time.deltaTime;
        if (whenToShoot < 0) {
            GameObject go = Instantiate(projectile);
            Transform otherT = go.transform;
            otherT.position = transform.position + (transform.forward * spawnDistance);
            otherT.rotation = transform.rotation;
            whenToShoot = 5;
        }
    }
}
