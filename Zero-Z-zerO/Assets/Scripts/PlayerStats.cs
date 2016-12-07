using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour, IDamageable {
    public float lives = 3;
    public float currentHP;
    public float maxHP;
    public float power;
    public bool destroyable;
    public GameObject dood;
    public enum PlayerState { normal, invis };
    public PlayerState currentState;
    SpriteRenderer sr;
    float timer = 0.2f;
    float delay = 0.2f;

    public float invisTime;
    private float defaultInvisTime;
    public bool invis;

    // Use this for initialization
    void Awake() {
        currentHP = maxHP;
        defaultInvisTime = invisTime;
        currentState = PlayerState.normal;
        sr = GetComponentInChildren<SpriteRenderer>();
    }
    public void ReceiveHit(float damage) {
        if (currentState == PlayerState.normal) {
            currentHP -= damage;
        }
        if (currentHP == 0 && destroyable) {
            lives -= 1;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy_Projectile");
            foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
            currentState = PlayerState.invis;
            InvisibleFrames();
            currentHP = maxHP;
        }
    }

    public void InvisibleFrames() {
    }
        void Update() {
        if (Input.GetButton("Exit")) {
            SceneManager.LoadScene("Scenes/Start_Menu");
        }
        if (lives == 0) {
            SceneManager.LoadScene("Scenes/Start_Menu");
        }
        if (currentState == PlayerState.normal) {
            sr.color = Color.white;
        }
        if (currentState == PlayerState.invis) {
            invisTime -= Time.deltaTime;
            if (invisTime <= 0) {
                currentState = PlayerState.normal;
                invisTime = defaultInvisTime;
            }
            if (sr.color == Color.black) {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    sr.color = Color.white;
                    timer = delay;
                    return;
                }
            }
            if (sr.color == Color.white) {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    sr.color = Color.black;
                    timer = delay;
                    return;
                }
            }
        }
    }
}
