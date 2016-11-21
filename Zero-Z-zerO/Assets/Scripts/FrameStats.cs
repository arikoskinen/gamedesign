using UnityEngine;
using System.Collections;

public class FrameStats : MonoBehaviour, IDamageable {
    public float currentHP;
    public float maxHP;
    public FrameSystem frameSystem;

    // Use this for initialization
    void Awake() {
        currentHP = maxHP;

    }
    public void ReceiveHit(float damage) {
        currentHP -= damage;
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            currentHP -= 1;
        }
        if (currentHP == 0) {
            frameSystem.FrameOff();
            currentHP = maxHP;
        }
    }
}
