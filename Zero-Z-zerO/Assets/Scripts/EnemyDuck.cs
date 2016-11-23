using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDuck : MonoBehaviour {
   
    public GameObject[] projectile;
    private float spawnDistance = 0;
    public float whenToShoot = 5;
    public Transform[] projectileSpawn;
    private GameObject[] gun;
    private float saveShootTime;
    public bool canShoot;
    private Animator DuckDie;   // Enemy Die animation


    void Start() {
        saveShootTime = whenToShoot;
        gun = new GameObject[projectileSpawn.Length];

    }

    public void DuckShoots() {
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
        whenToShoot -= Time.deltaTime;
        if (canShoot) {
            whenToShoot -= Time.deltaTime;
            if (whenToShoot < 0) {
                DuckShoots();
                whenToShoot = saveShootTime;
            }
        }
    }
}
