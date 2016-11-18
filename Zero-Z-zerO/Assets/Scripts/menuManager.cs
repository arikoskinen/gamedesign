using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

public void StartGame() {
            SceneManager.LoadScene("Scene01_ShooterStart");
        }
    
    
    public void ExitGame() {
        Application.Quit();  // Make are you sure Yes or No if needed..
    }
}
