using UnityEngine;
using System.Collections;

public class EnemyBomb : MonoBehaviour {
    private float spawnDistance = 0f;
    public float whenToShoot;
    private EnemyStats hp;
    float timer = 0.5f;
    float delay = 0.5f;
    SpriteRenderer sr;

    public bool canShoot;
    public GameObject projectile;
    private GameObject gun;
    public Transform projectileSpawn;

    void Awake () {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void BombExplodes() {
        for (int i = 0; i < 360; i += 10) {
            gun = (GameObject)Instantiate(projectile, projectileSpawn.position, Quaternion.Euler(0, 0, i));
        }
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update() {
        hp = GetComponent<EnemyStats>();
        timer -= Time.deltaTime;
        if (timer <= 0) {
            if (sr.color == Color.red) {
                sr.color = Color.white;
                timer = delay;
                return;
            } else {
                sr.color = Color.red;
                timer = delay;
                return;
            }
        }

        // if player exists, and we have never hit player

        if (canShoot) {
            whenToShoot -= Time.deltaTime;
            if (whenToShoot < 0) {
                BombExplodes();
            }
        }
        if (hp.currentHP <= 0) {
            BombExplodes();
        }
    }
}