using UnityEngine;
using System.Collections;

public class ProjectilePlayer : MonoBehaviour {
    GameObject player;
    PlayerStats stats;
    public float dMG;
    public float speed;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
    }

	// Update is called once per frame
	void Update () {
        dMG = stats.power;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            col.GetComponent<IDamageable>().ReceiveHit(dMG);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Boss") {
            col.GetComponent<IDamageable>().ReceiveHit(dMG);
            Destroy(gameObject);
        }
    }
}
