using UnityEngine;
using System.Collections;

public class PlayerShootingB : MonoBehaviour {
    public GameObject PlayerProjectile;             // player "bullet"
    public GameObject PlayerProjectileSeeker;
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

    public bool poweredUp;

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

            skodemiddle = (GameObject)Instantiate(PlayerProjectile, ProjectileMiddleSpawn.position, ProjectileLeftSpawn.rotation);

            if (poweredUp) {
                if (Input.GetButton("Slowdown")) {
                    skodemiddle = (GameObject)Instantiate(PlayerProjectile, ProjectileMiddleSpawn.position + new Vector3(-0.03f, 0, 0), ProjectileLeftSpawn.rotation);
                    skodemiddle = (GameObject)Instantiate(PlayerProjectile, ProjectileMiddleSpawn.position + new Vector3(0.03f, 0, 0), ProjectileLeftSpawn.rotation);
                    skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position + new Vector3(-0.03f, 0, 0), ProjectileLeftSpawn.rotation);
                    skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position + new Vector3(0.03f, 0, 0), ProjectileLeftSpawn.rotation);
                    skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position + new Vector3(-0.03f, 0, 0), ProjectileRightSpawn.rotation);
                    skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position + new Vector3(0.03f, 0, 0), ProjectileRightSpawn.rotation);

                    skodeleft = (GameObject)Instantiate(PlayerProjectileSeeker, ProjectileLeftSpawn.position + new Vector3(-0.05f, -0.15f, 0), Quaternion.Euler(0, 0, 90));
                    skoderight = (GameObject)Instantiate(PlayerProjectileSeeker, ProjectileRightSpawn.position + new Vector3(0.05f, -0.15f, 0), Quaternion.Euler(0, 0, -90f));
                } else {
                    skodemiddle = (GameObject)Instantiate(PlayerProjectile, ProjectileMiddleSpawn.position + new Vector3(-0.03f, 0, 0), Quaternion.Euler(0, 0, 7.5f));
                    skodemiddle = (GameObject)Instantiate(PlayerProjectile, ProjectileMiddleSpawn.position + new Vector3(0.03f, 0, 0), Quaternion.Euler(0, 0, -7.5f));
                    skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, Quaternion.Euler(0, 0, 25));
                    skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, Quaternion.Euler(0, 0, 15));
                    skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, Quaternion.Euler(0, 0, -25));
                    skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, Quaternion.Euler(0, 0, -15));
                }
            } else {
                if (Input.GetButton("Slowdown")) {
                    skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, ProjectileLeftSpawn.rotation);
                    skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, ProjectileRightSpawn.rotation);
                } else {
                    skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, Quaternion.Euler(0, 0, 25));
                    skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, Quaternion.Euler(0, 0, -25));
                }
            }
            //firingAnim.Play("AnimatedShipAnimFiring");
        }
    }
}
