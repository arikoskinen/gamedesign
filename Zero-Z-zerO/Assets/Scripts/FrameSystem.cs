using UnityEngine;
using System.Collections;

public class FrameSystem : MonoBehaviour {
    public GameObject normal;
    public GameObject frame;
    public float cooldown;
    private float savedCooldown;
    public float duration;
    private float savedDuration;
    private bool frameInUse = false;
    private bool onCooldown = false;

	// Use this for initialization
	void Awake () {
        savedCooldown = cooldown;
        savedDuration = duration;
    }
	
    void FrameOn() {
        normal.SetActive(false);
        frame.SetActive(true);
        frameInUse = true;
    }

    void FrameOff() {
        normal.SetActive(true);
        frame.SetActive(false);
        frameInUse = false;
        onCooldown = true;
    }

	// Update is called once per frame
	void Update () {
        if (!onCooldown && Input.GetButtonDown("Frame")) { 
            FrameOn();
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
                duration = savedDuration;
                FrameOff();
            }
        }
	}
}
