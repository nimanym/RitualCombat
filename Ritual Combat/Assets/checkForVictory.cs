using UnityEngine;
using System.Collections;

public class checkForVictory : MonoBehaviour {

    GameObject[] players;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

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
        }
    }
}
