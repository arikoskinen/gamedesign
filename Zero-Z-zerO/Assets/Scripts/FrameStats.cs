using UnityEngine;
using System.Collections;

public class FrameStats : MonoBehaviour, IDamageable {
    public float currentHP;
    public float maxHP;
    FrameSystem frameSystem;

    // Use this for initialization
    void Awake() {
        currentHP = maxHP;
        frameSystem = GetComponentInParent<FrameSystem>();
    }
    public void ReceiveHit(float damage) {
        currentHP -= damage;
    }
    // Update is called once per frame
    void Update() {
        if (currentHP == 0) {
            frameSystem.FrameOff();
            currentHP = maxHP;
        }
    }
}
