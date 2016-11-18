using UnityEngine;
using System.Collections;

public class ProjectileCluster : MonoBehaviour {
    public int dMG;
    public float speed;
    public GameObject[] projectile;
    private float spawnDistance = 0;
    public float clusterDelay = 2.5f;
    public Transform[] projectileSpawn;
    private GameObject[] gun;

    void Start() {
        gun = new GameObject[projectileSpawn.Length];
    }

    public void Cluster() {
        for (int i = 0; i < projectile.Length; i++) {
            for (int l = 0; l < projectileSpawn.Length; l++) {
                for (int j = 0; j < gun.Length; j++) {
                    gun[j] = (GameObject)Instantiate(projectile[i], projectileSpawn[l].position, projectileSpawn[l].rotation);
                }
            }
        }
    }
    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        clusterDelay -= Time.deltaTime;
        if (clusterDelay < 0) {
            Cluster();
            clusterDelay = 2.5f;
        }
    }
}