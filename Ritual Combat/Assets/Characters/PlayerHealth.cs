using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 350;
    public int health;
    bool isAlive;
    int player;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        isAlive = true;
        player = GetComponentInParent<CharacterMovement>().player;
    }       // Update is called once per frame	
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            isAlive = false;
        }

    }

    //Muestra la vida actual de los personajes en pantalla
    void OnGUI()
    {
        string texto = "Player " + player.ToString();
        string texto2 = "Health: " + health;
        switch (player)
        {
            case 1: GUI.Label(new Rect(10, 10, 100, 20), texto); GUI.Label(new Rect(10, 25, 100, 35), texto2); break;
            case 2: GUI.Label(new Rect(160, 10, 250, 20), texto); GUI.Label(new Rect(160, 25, 250, 35), texto2); break;
            case 3: GUI.Label(new Rect(310, 10, 400, 20), texto); GUI.Label(new Rect(310, 25, 400, 35), texto2); break;
            case 4: GUI.Label(new Rect(460, 10, 550, 20), texto); GUI.Label(new Rect(460, 25, 550, 35), texto2); break;
        }
    }

    public void receiveDamage(int dmg)
    {
        if (isAlive)
        {
            health -= dmg;
        }
    }


}