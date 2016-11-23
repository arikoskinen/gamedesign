using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour, IDamageable {
    public GameObject dood;
    public float currentHP;
    public float maxHP;
    public float power;
    public bool destroyable;

    // Use this for initialization
    void Awake() {
        currentHP = maxHP;
    }
    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0 && destroyable) {
            Destroy(dood);
        }
    }

    void Update() {

    }
}
