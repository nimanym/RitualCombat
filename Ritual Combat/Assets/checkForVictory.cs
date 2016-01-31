using UnityEngine;
using System.Collections;

public class checkForVictory : MonoBehaviour {

    GameObject[] players;
    float timer;
    bool finished;

	// Use this for initialization
	void Start () {
        finished = false;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (finished && timer <= 0)
        {
            Application.LoadLevel("MainMenu");
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();

        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length <= 1)
        {
            string texto = "Player " + players[0].GetComponent<CharacterMovement>().player.ToString() + " Wins";
            style.fontSize = 40;
            GUI.Label(new Rect((Screen.width/2)-100, (Screen.height / 2)-20, 100, 20), texto, style);
            if (!finished) { 
                timer = 5.0f;
                finished = true;
            }
        }
    }
}
