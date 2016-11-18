using UnityEngine;
using System.Collections;

public class HelperShipCode : MonoBehaviour
{
    public Transform LeftSpawn;
    public Transform RightSpawn;
    private GameObject leftSkode;
    private GameObject rightSkode;
    public GameObject helperProjectile;
    private float helpernextfiring;  // pause between fire
    public float DestrDelay = 2.2f;  // Helper projectile destroy delay
    public float nxtfiring = 2.0f;
    public float firingrate = 1.0f;
    public bool helperIsFiring;



    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nxtfiring && helperIsFiring==true)
        {

            nxtfiring = Time.time + firingrate;


            // float vol = Random.Range(volLowRange, volHighRange);
            // playerFireSnd.PlayOneShot(shootSound, vol);

            leftSkode = (GameObject)Instantiate(helperProjectile, LeftSpawn.position, LeftSpawn.rotation);
            Destroy(leftSkode, DestrDelay);

            rightSkode = (GameObject)Instantiate(helperProjectile, RightSpawn.position, RightSpawn.rotation);
            Destroy(rightSkode, DestrDelay);

        }
    }

}