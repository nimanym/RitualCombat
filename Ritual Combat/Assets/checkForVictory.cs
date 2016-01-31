using UnityEngine;
using System.Collections;

public class checkForVictory : MonoBehaviour {

    GameObject[] players;

	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        //for (int i = 0; i < players.Length; i++)
        //{
        //    players[i].GetComponent<PlayerHealth>().checkDead();
        //}
	}
}
