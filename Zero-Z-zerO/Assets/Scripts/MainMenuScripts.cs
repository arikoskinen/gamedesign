using UnityEngine;
using System.Collections;

public class MainMenuScripts : MonoBehaviour {
    private bool _isFirstMenu = true;
    private bool _isShipSelectMenu = false;
    private bool _isBombSelectMenu = false;
    private bool _isOptionsMenu = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        FirstMenu();
        ShipSelectMenu();
        BombSelectMenu();
        OptionsMenu();

        if (_isShipSelectMenu == true || _isBombSelectMenu == true || _isOptionsMenu == true) {
            if (GUI.Button(new Rect(10, Screen.height - 35, 150, 25), "Back")) {
                    _isShipSelectMenu = false;
                    _isBombSelectMenu = false;
                    _isOptionsMenu = false;
}
        }
    }

    void FirstMenu() {
        if (_isFirstMenu) {
            if (GUI.Button(new Rect(10, Screen.height / 2 - 100, 150, 25), "Start")) {
                _isFirstMenu = false;
                _isShipSelectMenu = true;
            }
            if (GUI.Button(new Rect(10, Screen.height / 2 - 65, 150, 25), "Options")) {
                _isFirstMenu = false;
                _isShipSelectMenu = true;
            }
            if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Quit")) {
                Application.Quit();
            }
        }
    }

    void ShipSelectMenu() {
        if (_isShipSelectMenu) {
            if (GUI.Button(new Rect(10, Screen.height / 2 - 100, 150, 25), "Ship1")) {
                _isFirstMenu = false;
                _isShipSelectMenu = true;
            }
            if (GUI.Button(new Rect(10, Screen.height / 2 - 65, 150, 25), "Ship2")) {
                _isFirstMenu = false;
                _isShipSelectMenu = true;
            }
            if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Back")) {
                _isShipSelectMenu = false;
                _isFirstMenu = true;
            }
        }
    }

    void BombSelectMenu() {
        if (_isShipSelectMenu) {
            if (GUI.Button(new Rect(10, Screen.height / 2 - 100, 150, 25), "Bomb1")) {
                _isFirstMenu = false;
                _isShipSelectMenu = true;
            }
            if (GUI.Button(new Rect(10, Screen.height / 2 - 65, 150, 25), "Bomb2")) {
                _isFirstMenu = false;
                _isShipSelectMenu = true;
            }
            if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Bomb3")) {
                _isShipSelectMenu = false;
                _isFirstMenu = true;
            }
        }
    }

    void OptionsMenu() {
        if (_isOptionsMenu) {
            if (GUI.Button(new Rect(10, Screen.height / 2 - 100, 150, 25), "???")) {

            }
            if (GUI.Button(new Rect(10, Screen.height / 2 - 65, 150, 25), "Profit")) {

            }
            if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Back")) {
                _isOptionsMenu = false;
                _isFirstMenu = true;
            }
        }
    }
}
