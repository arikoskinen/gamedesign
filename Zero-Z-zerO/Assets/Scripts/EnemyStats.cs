using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EnemyStats : MonoBehaviour, IDamageable {
    public float currentHP;
    public int maxHP;
    public float speed;
    public float maxRotationSpeed;
    public bool destroyable;
    public bool lookAt;
    public Transform player;
    SpriteRenderer sr;
    float timer = 0.1f;
    float delay = 0.1f;
    public int score;
    public int scoring;
    public Text scoreText;



    // Use this for initialization
    void Awake() {
        currentHP = maxHP;
        player = GameObject.Find("PlayerShip").transform;
        sr = GetComponentInChildren<SpriteRenderer>();
    }

public void ScoreCounter() {
        scoring += score;
        scoreText.text = "SCORE: "+ scoring;
        print("Hit "+scoring);
    }



    public void ReceiveHit(float damage) {
        currentHP -= damage;
        ScoreCounter();
        sr.color = Color.black;
        if (currentHP == 0 && destroyable) {
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
        if (sr.color == Color.black) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                sr.color = Color.white;
                timer = delay;
                return;
            }
        }
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
