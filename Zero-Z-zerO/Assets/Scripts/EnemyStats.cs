using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour, IDamageable {
    public float currentHP;
    public int maxHP;
    public float speed;
    public float maxRotationSpeed;
    public bool lookAt;
    public Transform player;
    public float score;

    // Use this for initialization
    void Awake() {
        currentHP = maxHP;
        player = GameObject.Find("PlayerShip").transform;
    }

    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player") {
            col.GetComponent<IDamageable>().ReceiveHit(1);
        }
    }

    // Update is called once per frame
    void Update() {
        if (currentHP > 0) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (player != null && lookAt) {
            // rotate towards player
            var to_playr = player.position - transform.position;
            var rtated_towrds_playr = Quaternion.LookRotation(Vector3.forward, to_playr);
            transform.rotation = Quaternion.Lerp(transform.rotation, rtated_towrds_playr, maxRotationSpeed * Time.deltaTime);
        }
    }
}
