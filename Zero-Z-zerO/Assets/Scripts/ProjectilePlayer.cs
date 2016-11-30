using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectilePlayer : MonoBehaviour {
    GameObject player;
    PlayerStats stats;
    public float dMG;
    public float speed;
    public bool frameProjectile;
    public bool seeker;

    public List<Transform> enemies;
    public Transform selectedTarget;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();

        selectedTarget = null;
        enemies = new List<Transform>();
        AddEnemiesToList();
    }

    public void AddEnemiesToList() {
        GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject _Enemy in ItemsInList) {
            AddTarget(_Enemy.transform);
        }
    }

    public void AddTarget(Transform enemy) {
        enemies.Add(enemy);
    }

    public void DistanceToTarget() {
        enemies.Sort(delegate (Transform t1, Transform t2) {
            return Vector3.Distance(t1.transform.position, transform.position)
            .CompareTo(Vector3.Distance(t2.transform.position, transform.position));
        });
    }

    public void TargetedEnemy() {
        if(selectedTarget == null) {
            DistanceToTarget();
            selectedTarget = enemies[0];
        }
    }


	// Update is called once per frame
	void Update () {
        if (seeker) {
            TargetedEnemy();
            float dist = Vector3.Distance(selectedTarget.transform.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, selectedTarget.position, speed * Time.deltaTime);
        } else {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (frameProjectile) {
            dMG = 1;
        } else {
            dMG = stats.power;
        }


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
