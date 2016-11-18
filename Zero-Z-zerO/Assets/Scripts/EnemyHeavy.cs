using UnityEngine;
using System.Collections;

public class EnemyHeavy : MonoBehaviour, IDamageable {
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

    public Transform heavyMover;

    // Use this for initialization
    void Start() {
        saveShootTime = whenToShoot;
        currentHP = maxHP;
        player = GameObject.Find("PlayerShip NEO").transform;
    }

    public void HeavyShoots() {
        gun = (GameObject)Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
    }
    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0) {
            // Die_animation here
            Animator HeavyDieAnim = gameObject.transform.Find("Heavy_Sprite").GetComponent<Animator>();
            HeavyDieAnim.Play("Heavy2Die");
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
        if (player != null) {
            var to_playr = player.position - transform.position;
            var rtated_towrds_playr = Quaternion.LookRotation(Vector3.forward, to_playr);
            transform.rotation = Quaternion.Lerp(transform.rotation, rtated_towrds_playr, maxRotationSpeed * Time.deltaTime);
        }
        if (currentHP >= 0) {
            heavyMover.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        whenToShoot -= Time.deltaTime;
        if (canShoot) {
            whenToShoot -= Time.deltaTime;
            if (whenToShoot < 0) {
                HeavyShoots();
                whenToShoot = saveShootTime;
            }
        }
    }
}
