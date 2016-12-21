using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public int difficulty;
    public float spawnTimer;
    private float savedTimer;
    public int spawnBoss = 0;
    public bool bossSpawned = false;
    public bool random;

    public GameObject[] enemy;
    public int[] enemyNro;
    public Transform[] spawner;
    private GameObject[] spawnSpot;
    public GameObject boss;
    public Transform bossSpawner;
    private GameObject bossSpawnSpot;
    public bool gameHasBoss;
    public bool spawned = false;
    public float gameTime;

    float timer = 0.5f;
    float delay = 0.5f;

    public enum EnemyWave { wave1, wave2, wave3 };
    public EnemyWave currentWave;

    // Use this for initialization
    void Start() {
        currentWave = EnemyWave.wave1;
        savedTimer = spawnTimer;
        spawnSpot = new GameObject[spawner.Length];

        //spawnSpot[0] = (GameObject)Instantiate(enemy[0], spawner[0].position, spawner[0].rotation);
        //Debug.Log("Spawn Eye");
        //spawnSpot[2] = (GameObject)Instantiate(enemy[1], spawner[2].position, spawner[2].rotation);
        //Debug.Log("Spawn Duck");
        //spawnSpot[4] = (GameObject)Instantiate(enemy[2], spawner[4].position, spawner[4].rotation);
        //Debug.Log("Spawn Heavy");
    }
    public void Spawn() {
        if (random) {
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
        } else {
            if (currentWave == EnemyWave.wave1) {
                spawnSpot[0] = (GameObject)Instantiate(enemy[0], spawner[0].position, spawner[0].rotation);
                spawnSpot[1] = (GameObject)Instantiate(enemy[0], spawner[1].position, spawner[1].rotation);
                spawnSpot[2] = (GameObject)Instantiate(enemy[0], spawner[2].position, spawner[2].rotation);
                spawnSpot[3] = (GameObject)Instantiate(enemy[0], spawner[3].position, spawner[3].rotation);
                spawnSpot[4] = (GameObject)Instantiate(enemy[0], spawner[4].position, spawner[4].rotation);
            }
            if (currentWave == EnemyWave.wave2) {
                spawnSpot[1] = (GameObject)Instantiate(enemy[1], spawner[1].position, spawner[1].rotation);
                spawnSpot[3] = (GameObject)Instantiate(enemy[1], spawner[3].position, spawner[3].rotation);
            }
            if (currentWave == EnemyWave.wave3) {
                spawnSpot[0] = (GameObject)Instantiate(enemy[2], spawner[0].position, spawner[0].rotation);
                spawnSpot[2] = (GameObject)Instantiate(enemy[2], spawner[2].position, spawner[2].rotation);
                spawnSpot[4] = (GameObject)Instantiate(enemy[2], spawner[4].position, spawner[4].rotation);
            }
        }
    }
    public void SpawnBoss() {
        bossSpawnSpot = (GameObject)Instantiate(boss, bossSpawner.position, bossSpawner.rotation);
        Debug.Log("Bpss inc");
    }
    // Update is called once per frame
    void Update() {
        gameTime += Time.deltaTime;
        if (gameTime >= 10) {
            savedTimer -= 0.2f;
            gameTime = 0;
        }
            if (random) {
            if (!bossSpawned) {
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
                }
            }
        } else {
            if (currentWave == EnemyWave.wave1) {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0) {

                        Spawn();
                    spawnTimer = savedTimer;
                    currentWave = EnemyWave.wave2;
                }
            }
            if (currentWave == EnemyWave.wave2) {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0) {
                        Spawn();
                    spawnTimer = savedTimer;
                    currentWave = EnemyWave.wave3;
                }
            }
            if (currentWave == EnemyWave.wave3) {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0) {
                        Spawn();
                    spawnTimer = savedTimer;
                    currentWave = EnemyWave.wave1;
                }
            }
        }
    }
}

