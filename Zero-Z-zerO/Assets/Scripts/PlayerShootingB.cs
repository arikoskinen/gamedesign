using UnityEngine;
using System.Collections;

public class PlayerShootingB : MonoBehaviour {
    public GameObject PlayerProjectile;             // player "bullet"
    public Transform ProjectileLeftSpawn;
    public Transform ProjectileRightSpawn;
    private GameObject skodeleft;                   // player's left cannon bullet
    private GameObject skoderight;                  // player's right cannon bullet
    public Transform ProjectileMiddleSpawn;
    private GameObject skodemiddle;
    public AudioClip shootSound;
    private AudioSource playerFireSnd;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public float firingRate;
    private float nextfiring;
    public float PrjDestroyDelay = 2.2f;
    public bool autofire;
    private Animator firingAnim;            // player firing anim

    // Use this for initialization
    void Awake() {
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

            skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, ProjectileLeftSpawn.rotation);
            skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, ProjectileRightSpawn.rotation);
            skodemiddle = (GameObject)Instantiate(PlayerProjectile, ProjectileMiddleSpawn.position, ProjectileMiddleSpawn.rotation);

            firingAnim.Play("AnimatedShipAnimFiring");
        }
    }
}
