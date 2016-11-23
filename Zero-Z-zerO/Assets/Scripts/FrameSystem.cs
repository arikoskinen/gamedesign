using UnityEngine;
using System.Collections;

public class FrameSystem : MonoBehaviour {
    public GameObject normal;
    public GameObject normalGun;
    public GameObject frame;
    public GameObject frameEnemy;
    public bool enemyFrame;
    public float cooldown;
    private float savedCooldown;
    public float duration;
    private float savedDuration;
    public bool frameInUse = false;
    public bool frameEnemyInUse = false;
    private bool onCooldown = false;

	// Use this for initialization
	void Awake () {
        savedCooldown = cooldown;
        savedDuration = duration;
    }
	
    public void FrameOn() {
        normalGun.SetActive(false);
        frame.SetActive(true);
        frameInUse = true;
    }

    public void FrameOff() {
        normalGun.SetActive(true);
        frame.SetActive(false);
        duration = savedDuration;
        frameInUse = false;
        onCooldown = true;
    }

    public void EnemyFrame() {
        normal.SetActive(false);
        frameEnemy.SetActive(true);
        frameEnemyInUse = true;
}

	// Update is called once per frame
	void Update () {
        if (!onCooldown && Input.GetButtonDown("Frame")) {
            if (enemyFrame) {
                EnemyFrame();
            }else {
                FrameOn();
            }
        } else if (onCooldown) {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0) {
                cooldown = savedCooldown;
                onCooldown = false;
            }
        }
        if (frameInUse) {
            duration -= Time.deltaTime;
            if (duration <= 0) {
                FrameOff();
            }
        }
	}
}
