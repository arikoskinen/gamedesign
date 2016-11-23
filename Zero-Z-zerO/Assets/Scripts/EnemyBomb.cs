using UnityEngine;
using System.Collections;

public class EnemyBomb : MonoBehaviour, IDamageable {
    public float currentHP;
    public int maxHP;
    public float speed;
    public float maxRotationSpeed;
    public Transform player;
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
        currentHP = maxHP;
    }

    public void BombShoots() {
        for (int i = 0; i < 360; i += 10) {
            gun = (GameObject)Instantiate(projectile, projectileSpawn.position, Quaternion.Euler(0, 0, i));
        }
    }

    public void BombExplodes() {
        gun = (GameObject)Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
    }

    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0) {
            // Die_animation here
            Animator EyeDieAnim = gameObject.transform.Find("Eye_Sprite").GetComponent<Animator>();
            EyeDieAnim.Play("EyeDie2");
            BombExplodes();
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
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        // if player exists, and we have never hit player

        if (canShoot) {
            whenToShoot -= Time.deltaTime;
            if (whenToShoot < 0) {
                BombShoots();
                whenToShoot = saveShootTime;
            }
        }
    }
}