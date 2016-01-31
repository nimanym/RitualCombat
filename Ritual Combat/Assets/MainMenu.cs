using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void startGame(string sceneName) {
        Application.LoadLevel(sceneName);
    }

    public void quitGame() {
        Application.Quit();
    }
}
