using UnityEngine;
using System.Collections;

public class EnemyEye : MonoBehaviour, IDamageable {
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
        player = GameObject.Find("PlayerShip NEO").transform;
    }

    public void EyeShoots() {
        gun = (GameObject)Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
    }
    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0) {
            // Die_animation here
            Animator EyeDieAnim = gameObject.transform.Find("Eye_Sprite").GetComponent<Animator>();
            EyeDieAnim.Play("EyeDie2");
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
        if (player != null) {
            // rotate towards player
            var to_playr = player.position - transform.position;
            var rtated_towrds_playr = Quaternion.LookRotation(Vector3.forward, to_playr);
            transform.rotation = Quaternion.Lerp(transform.rotation, rtated_towrds_playr, maxRotationSpeed * Time.deltaTime);
        }
        if (canShoot) {
            whenToShoot -= Time.deltaTime;
            if (whenToShoot < 0) {
                EyeShoots();
                whenToShoot = saveShootTime;
            }
        }
    }
}
