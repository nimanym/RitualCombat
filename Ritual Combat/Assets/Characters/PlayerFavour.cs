﻿using UnityEngine;
using System.Collections;

public class PlayerFavour : MonoBehaviour
{
    public float maxFavour = 100.0f;
    float favour;
    public bool isFull;
    int player;


    // Use this for initialization
    void Start()
    {
        favour = 0.0f;
        isFull = false;
        player = GetComponentInParent<CharacterMovement>().player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(favour);
        favour += 10*Time.deltaTime;
        if (favour >= 100.0f)
        {
            favour = 100.0f;
            isFull = true;
        }

        if (Input.GetAxis("Ulti" + player.ToString()) > 0) //BOTON B DEL MANDO
        {
            useUltimate();
        }
    }

    void OnGUI()
    {
        string texto = "Favour: " + (int)favour;
        switch (player) {
            case 1: GUI.Label(new Rect(10, 30, 100, 40), texto); break;
            case 2: GUI.Label(new Rect(110, 30, 190, 40), texto); break;
            case 3: GUI.Label(new Rect(200, 30, 290, 40), texto); break;
            case 4: GUI.Label(new Rect(300, 30, 390, 40), texto); break;
        }
    }

    public void addFavour(float fav)
    {
        favour += fav;
    }

    void useUltimate()
    {
        //Debug.Log(favour);
        if (isFull)
        {
            gameObject.SendMessage("Ultimate");
            favour = 0;
            isFull = false;
            //Debug.Log("Usas tu ulti: "+favour);

        }
    }

}
