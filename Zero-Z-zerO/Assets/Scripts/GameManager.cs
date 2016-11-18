using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static bool kakuseiMode;
    public static float kakuseiMovementFactor = 0.5f;
    public bool zeroModeUsable;
    public static bool zeroMode;
    public static float zeroMovementFactor = -0.5f;
    private bool pauseToggle;

    public Transform player;
    public float gameOverTimescale = 0.001f;

    private static GameManager _instance;
    public static GameManager instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<GameManager>();

                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    private bool noShip = true;
    private bool ship1 = false;
    private bool ship2 = false;

    private bool noBomb = true;
    private bool bomb1 = false;
    private bool bomb2 = false;
    private bool bomb3 = false;

    void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(this);
        } else {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    void Start()
    {
        // SceneManager.LoadScene("Scene01_ShooterStart");
        // SceneManager.LoadScene("Aris_station001");

        Input.simulateMouseWithTouches = false;
        player = GameObject.Find("PlayerShip NEO").transform;

    }

    public void Player() {
        if (ship1){
            player = GameObject.Find("PlayerShip1").transform;
        } else if (ship2) {
            player = GameObject.Find("PlayerShip2").transform;
        }
    }

    void Update()
    {
        if (player == null) {
            print("Game Over! Hit any key.");
            Time.timeScale = gameOverTimescale;
            // if (Input.anyKeyDown)

            if (Input.anyKeyDown || Input.touchCount > 0) {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Aris_station001");
            }
        }
        //    if (Input.GetKeyDown(KeyCode.K)) // Pause.
        //    { 
        //        ShipControl.gamepad = false;
        //}
        if (Input.GetKeyDown(KeyCode.P)) // Pause.
        {

            if (pauseToggle)
                Time.timeScale = 1;
            else
                Time.timeScale = 0.0000001f;

            pauseToggle = !pauseToggle;


        }

        if (Input.GetKey(KeyCode.Escape))
        {
            // Application.Quit();
            SceneManager.LoadScene("Aris_station001");
        }

        // kakuseimode

        if (Input.GetKeyDown(KeyCode.X))

        {
            if (kakuseiMode)
            {

                // enemies shoots more
                // projectiles moves slowly
                // collected diamonds decreasing by 10 in amount of time
                // enemy projectiles turns to gold (Z)
                Debug.Log("Kakusei On.");
            }
            else {


                kakuseiMode = !kakuseiMode; // there is short delay when going back to "normal mode".
                                            // destroyed enemies turns to diamonds
                Debug.Log("Kakusei Off.");

            }
            // else // when diamonds end, kakuseiOvermode
        }
        if (Input.GetKeyDown(KeyCode.Z) &&
            zeroModeUsable) {
            if (zeroMode) {

                // enemies shoots more
                // projectiles moves slowly
                // collected diamonds decreasing by 10 in amount of time
                // enemy projectiles turns to gold (Z)
                Debug.Log("Zero-Z-Zero Mode On.");
            } else {


                zeroMode = !zeroMode; // there is short delay when going back to "normal mode".
                                      // destroyed enemies turns to diamonds
                Debug.Log("Zero-Z-Zero Mode Off.");

            }
            // else // when diamonds end, kakuseiOvermode
        }
    }


}

