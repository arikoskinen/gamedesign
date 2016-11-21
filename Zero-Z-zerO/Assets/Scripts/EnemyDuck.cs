using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDuck : MonoBehaviour, IDamageable {
    public float currentHP;
    public int maxHP;
    public float speed;
    public float maxRotationSpeed;
    public Transform player;
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
        currentHP = maxHP;
        player = GameObject.Find("PlayerShip").transform;
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

    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0) {
            // Die_animation here
            Animator DuckAnim = gameObject.transform.Find("Duck_Sprite").GetComponent<Animator>();
            DuckAnim.Play("Duck_die2");
            Destroy(gameObject, 0.7f);

        }
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update() {
        if (currentHP >= 0) {
        transform.Translate(Vector3.down* speed * Time.deltaTime);
        }
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
