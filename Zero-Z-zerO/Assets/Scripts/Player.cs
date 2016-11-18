using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public string shipType;
    public bool destroyable = false;

    public float tspeed = 0.0096f;                  // Value for touch "speed".

    public float speed = 0.02f;                     // player ship movement speed
    public float xpos = 0f;
    public float ypos = -1.44f;
    public float zpos = 0f;
    public GameObject PlayerShip;
    public GameObject leftHelper;                   // kakuseimode left helper
    public GameObject rightHelper;                  // kakuseimode right helper
    public AudioClip PlayerDestroySound;
    public bool hit;
    public int playerCurrentHP;
    public int playerMaxHP;
    public float invisTime;
    private float defaultInvisTime;         
    public bool invis;

    // Player Ship Animations
    private Animator playerDestroy;         // player explosion
    // private Animator playerTurnLeft;
    private Animator playerTurnLeft;
    private Animator playerTurnRight;
    private Animator helperTurnRight;
    private Animator invisAnim;

    // Booleans
    public Transform upperLeft;
    public Transform lowerRight;

    public enum PlayerState { normal, invis};
    public PlayerState currentState;

    // Player Keyboard Control function
    void PlayerControl() {
        if (!hit) {
            //if (Input.GetButton("Fire") && !autofire && Time.time > nextfiring) {
            //    skodeleft = (GameObject)Instantiate(PlayerProjectile, ProjectileLeftSpawn.position, ProjectileLeftSpawn.rotation);
            //    skoderight = (GameObject)Instantiate(PlayerProjectile, ProjectileRightSpawn.position, ProjectileRightSpawn.rotation);

            //    nextfiring = Time.time + firingRate;

            //    firingAnim.Play("AnimatedShipAnimFiring");
            //}
            transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime);
            transform.Translate(Vector3.up * speed * Input.GetAxis("Vertical") * Time.deltaTime);

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
                // vikan framen näpin liike...
                // fixaus screenToWorldPoint;
                //var screenToWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).deltaPosition);

                Vector2 touchdeltaposition = Input.GetTouch(0).deltaPosition;

                // liiku x,y akselilla.
                transform.Translate(touchdeltaposition.x * tspeed, touchdeltaposition.y * tspeed, 0);
            }
        }
    }
    // Keyboatd control function ends here

    void Awake() {
        defaultInvisTime = invisTime;
        currentState = PlayerState.normal;
        // Player Sounds 
        playerDestroy = GetComponent<Animator>();
        playerTurnLeft = GetComponent<Animator>();
        playerTurnRight = GetComponent<Animator>();
        invisAnim = GetComponent<Animator>();

    }

    // Use this for initialization
    void Start() {
        xpos = PlayerShip.transform.position.x;
        ypos = PlayerShip.transform.position.y;
        zpos = PlayerShip.transform.position.z;
    }

    void OnPlayerHit() {
        playerCurrentHP -= 1;
        // Todo: player hitcounter
        
        playerDestroy.Play("PlayerShipDestroyAnim");
        if (playerCurrentHP <= 0)
        {
            Destroy(gameObject, 0.58f);
        } else
        {
            currentState = PlayerState.invis;
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (destroyable && col.gameObject.tag == "Enemy" || destroyable && col.gameObject.tag == "Enemy_Projectile") {
            if (currentState == PlayerState.normal)
            {
                OnPlayerHit();
            }


        }
    }
        // Update is called once per frame
        void Update() {
        PlayerControl();
        if (currentState == PlayerState.invis)
        {
            //   Animator InvisibleAnimation = GameObject.Find("PlayerSPrite").GetComponent<Animator>();
            //invisAnim.Play("InvisibleFrames");
            invisTime -= Time.deltaTime;
            if (invisTime <= 0)
            {
                currentState = PlayerState.normal;
                invisAnim.Play("PlayerShipSteady");
                invisTime = defaultInvisTime;

            }
        }

        var newPosition = PlayerShip.transform.position;

        float clampedX = Mathf.Clamp(newPosition.x, upperLeft.position.x, lowerRight.position.x);
        float clampedY = Mathf.Clamp(newPosition.y, lowerRight.position.y, upperLeft.position.y);

        PlayerShip.transform.position = new Vector3(clampedX, clampedY, 0f);
    }
}

