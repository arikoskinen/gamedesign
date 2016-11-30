using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour, IDamageable {
    public float lives = 3;
    public float currentHP;
    public float maxHP;
    public float power;
    public bool destroyable;
    public GameObject dood;

    // Use this for initialization
    void Awake() {
        currentHP = maxHP;
    }
    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0 && destroyable) {
            lives -= 1;
        }
    }
        void Update() {
        if (lives == 0) {
            Destroy(dood);
        }
    }
}
