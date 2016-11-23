using UnityEngine;
using System.Collections;

public class PlayerShootingEnemy : MonoBehaviour {
    public GameObject PlayerProjectile;             // player "bullet"
    public Transform ProjectileSpawn;
    public Transform ProjectileLeftSpawn;
    public Transform ProjectileRightSpawn;
    private GameObject skode;
    private GameObject skodeleft;
    private GameObject skoderight;
    public AudioClip shootSound;
    private AudioSource playerFireSnd;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public float firingRate;
    private float nextfiring;
    public float PrjDestroyDelay = 2.2f;
    public bool autofire;
    private Animator firingAnim;            // player firing anim

    public enum PowerLevel { P1, P2, P3, P4, P5 };
    public PowerLevel currentPower;

    // Use this for initialization
    void Awake() {
        currentPower = PowerLevel.P1;
        playerFireSnd = GetComponent<AudioSource>();

        // Sprite animations
        firingAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire") && Time.time > nextfiring || autofire && Time.time > nextfiring) {
            nextfiring = Time.time + firingRate;

            float vol = Random.Range(volLowRange, volHighRange);
            playerFireSnd.PlayOneShot(shootSound, vol);

            if (currentPower >= PowerLevel.P1) {
                skode = (GameObject)Instantiate(PlayerProjectile, ProjectileSpawn.position, ProjectileSpawn.rotation);
            }
            if (currentPower >= PowerLevel.P2) {
                
                skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, ProjectileSpawn.rotation);
                skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, ProjectileSpawn.rotation);
            }
            if (currentPower >= PowerLevel.P3) {
                skode = (GameObject)Instantiate(PlayerProjectile, ProjectileSpawn.position, Quaternion.Euler(0, 0, 25));
                skode = (GameObject)Instantiate(PlayerProjectile, ProjectileSpawn.position, Quaternion.Euler(0, 0, -25));
            }
            if (currentPower >= PowerLevel.P4) {
                skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, Quaternion.Euler(0, 0, 25));
                skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, Quaternion.Euler(0, 0, -25));
            }
            if (currentPower >= PowerLevel.P5) {
                skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, Quaternion.Euler(0, 0, -25));
                skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, Quaternion.Euler(0, 0, 25));
            }


        }
    }
}

