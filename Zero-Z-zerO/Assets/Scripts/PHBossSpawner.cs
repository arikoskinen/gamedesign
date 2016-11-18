using UnityEngine;
using System.Collections;

public class PHBossSpawner : MonoBehaviour {
    public int difficulty;
    public float spawnTimer;
    private float savedTimer;
    public int spawnBoss = 0;
    public bool bossSpawned = false;

    public GameObject[] enemy;
    public int[] enemyNro;
    public Transform[] spawner;
    private GameObject[] spawnSpot;
    public GameObject boss;
    public Transform bossSpawner;
    private GameObject bossSpawnSpot;
    public bool gameHasBoss;

    // Use this for initialization
    void Start() {
        savedTimer = spawnTimer;
        spawnSpot = new GameObject[spawner.Length];
    }

    public void Spawn() {
        for (int l = 0; l < spawner.Length; l++) {
            int r = Random.Range(0, 4);
            if (r == 1) {
                spawnSpot[l] = (GameObject)Instantiate(enemy[0], spawner[l].position, spawner[l].rotation);
                Debug.Log("Spawn Eye");
            }
            if (r == 2) {
                spawnSpot[l] = (GameObject)Instantiate(enemy[1], spawner[l].position, spawner[l].rotation);
                Debug.Log("Spawn Duck");
            }
            if (r == 3) {
                spawnSpot[l] = (GameObject)Instantiate(enemy[2], spawner[l].position, spawner[l].rotation);
                Debug.Log("Spawn Heavy");
            }
        }
    }
    public void SpawnBoss() {
        bossSpawnSpot = (GameObject)Instantiate(boss, bossSpawner.position, bossSpawner.rotation);
        Debug.Log("Bpss inc");
    }
    // Update is called once per frame
    void Update() {
        if (!bossSpawned) {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0) {
                spawnBoss += 1;
                if (spawnBoss <= 14) {
                    Spawn();
                    spawnTimer = savedTimer;
                }

            }
            if (spawnBoss == 15 && gameHasBoss) {
                bossSpawned = true;
                SpawnBoss();
                spawnBoss = 0;
                spawnTimer = savedTimer;
            }
        }
    }
}