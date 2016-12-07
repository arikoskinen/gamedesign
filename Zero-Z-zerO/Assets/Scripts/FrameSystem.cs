using UnityEngine;
using System.Collections;

public class FrameSystem : MonoBehaviour {
    public GameObject normal;
    public GameObject gun;
    public GameObject frame;
    //public GameObject frameEnemy;
    //public bool enemyFrame;
    public float cooldown;
    private float savedCooldown;
    public float duration;
    private float savedDuration;
    public bool frameInUse = false;
    public bool frameEnemyInUse = false;
    private bool onCooldown = false;
    float timer = 1f;
    float delay = 1f;

    float powerCharger;
    public string powerCharge;

	// Use this for initialization
	void Awake () {
        savedCooldown = cooldown;
        savedDuration = duration;
    }
	
    public void FrameOn() {
        //normal.SetActive(false);
        gun.SetActive(false);
        frame.SetActive(true);
        frameInUse = true;
    }

    public void FrameOff() {
        //normal.SetActive(true);
        gun.SetActive(true);
        frame.SetActive(false);
        duration = savedDuration;
        frameInUse = false;
        onCooldown = true;
    }

//    public void EnemyFrame() {
//        normal.SetActive(false);
//        frameEnemy.SetActive(true);
//        frameEnemyInUse = true;
//}

	// Update is called once per frame
	void Update () {
        if (!onCooldown && Input.GetButtonDown("Frame")) {
            //if (enemyFrame) {
            //    EnemyFrame();
            //}else {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy_Projectile");
            foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
            FrameOn();
            //}
        } else if (onCooldown) {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0) {
                cooldown = savedCooldown;
                onCooldown = false;
            }
        }
        if (frameInUse) {
            powerCharger += Time.deltaTime;
            powerCharge = powerCharger.ToString("N0");
            timer -= Time.deltaTime;
            duration -= Time.deltaTime;
            if (duration <= 0 || timer <= 0 && Input.GetButtonDown("Frame")) {
                FrameOff();
                timer = delay;
                return;
            }
        }
	}
}
