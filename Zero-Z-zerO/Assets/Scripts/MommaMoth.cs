using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MommaMoth : MonoBehaviour, IDamageable {
    public float currentHP;
    public float[] maxHP;
    public float speed;
    public enum Phases {phase0, phase1, phase2, phase3, finalPhase, invis };
    public Phases phase;
    public enum Patterns { pattern1, pattern2, pattern3 }
    public Patterns pattern;
    public Transform player;
    public GameObject[] projectile;
    private float spawnDistance = 0;
    public float shootCluster;
    private float savedClusterTime;
    public Transform[] projectileSpawn;
    private GameObject[] gun;
    public float bossInc;

    public float pattern1Timer;
    private float savedPattern1Timer;
    public float pattern2Timer;
    private float savedPattern2Timer;

    void Start() {
        currentHP = maxHP[0];
        player = GameObject.Find("PlayerShip NEO").transform;
        gun = new GameObject[projectileSpawn.Length];
        savedClusterTime = shootCluster;
        savedPattern1Timer = pattern1Timer;
        savedPattern2Timer = pattern2Timer;
    }

    public void ClusterShoot() {
        for (int i = 0; i < projectile.Length; i++) {
            for (int l = 0; l < projectileSpawn.Length; l++) {
                for (int j = 0; j < gun.Length; j++) {
                    gun[j] = (GameObject)Instantiate(projectile[i], projectileSpawn[l].position, projectileSpawn[l].rotation);
                }
            }
        }
    }

    public void AimedShoot() {

    }

    public void Phase1() {
        if (pattern == Patterns.pattern1) {
            pattern2Timer = savedPattern2Timer;
            pattern1Timer -= Time.deltaTime;
            if (pattern1Timer <= 0) {
                pattern = Patterns.pattern2;

            }
            shootCluster -= Time.deltaTime;
            if (shootCluster < 0) {
                ClusterShoot();
                AimedShoot();
                shootCluster = savedClusterTime;
            }
        }
        if (pattern == Patterns.pattern2) {
            pattern1Timer = savedPattern1Timer;
            pattern2Timer -= Time.deltaTime;
            if (pattern2Timer <= 0) {
                pattern = Patterns.pattern1;
            }
        }
    }
    public void Phase2() {

    }

    public void ReceiveHit(float damage) {
        if (phase == Phases.finalPhase) {
            currentHP -= 0;
        } else {
            currentHP -= damage;
        }
    }
    // Update is called once per frame
    void Update() {
        if (currentHP <= maxHP[1]) {
            phase = Phases.phase2;
        }
        if (currentHP <= maxHP[3]) {
            phase = Phases.finalPhase;
        }
        if (phase == Phases.phase0) {
            bossInc -= Time.deltaTime;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (bossInc <= 0) {
            phase = Phases.phase1;
        }
        if (phase == Phases.phase1) {
            Phase1();
        }
        if (phase == Phases.phase2) {
            Phase2();
        }
    }
}
