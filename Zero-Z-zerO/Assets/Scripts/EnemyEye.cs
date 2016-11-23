using UnityEngine;
using System.Collections;

public class EnemyEye : MonoBehaviour {
    private float spawnDistance = 0f;
    public float whenToShoot = 5;
    private float saveShootTime;

    public bool canShoot;
    public GameObject projectile;
    private GameObject gun;
    public Transform projectileSpawn;
    
    // Use this for initialization
    void Start() {
        saveShootTime = whenToShoot;
    }

    public void EyeShoots() {
        gun = (GameObject)Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
    }


        // Update is called once per frame
        void Update() {
        // if player exists, and we have never hit player
        if (canShoot) {
            whenToShoot -= Time.deltaTime;
            if (whenToShoot < 0) {
                EyeShoots();
                whenToShoot = saveShootTime;
            }
        }
    }
}
