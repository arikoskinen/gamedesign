using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour, IDamageable {
    public GameObject dood;
    public float currentHP;
    public float maxHP;

    // Use this for initialization
    void Awake () {
        currentHP = maxHP;
	
	}
    public void ReceiveHit(float damage) {
        currentHP -= damage;
        if (currentHP == 0) {
        }
    }
        // Update is called once per frame
        void Update () {
	}
}
