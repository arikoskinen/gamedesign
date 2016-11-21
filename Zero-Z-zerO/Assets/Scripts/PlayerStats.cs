using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour, IDamageable {
    public GameObject dood;
    public float currentHP;
    public float maxHP;

    // Use this for initialization
    void Awake() {
        currentHP = maxHP;

    }
    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0) {
            Destroy(dood);
        }
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            currentHP -= 1;
        }
        if (currentHP == 0) {
            Destroy(dood);
        }
    }
}
