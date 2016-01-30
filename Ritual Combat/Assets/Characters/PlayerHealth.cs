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
        string texto = "Player " + player.ToString() + ": " + health;
        switch (player)
        {
            case 1: GUI.Label(new Rect(10, 10, 100, 20), texto); break;
            case 2: GUI.Label(new Rect(110, 10, 190, 20), texto); break;
            case 3: GUI.Label(new Rect(200, 10, 290, 20), texto); break;
            case 4: GUI.Label(new Rect(300, 10, 390, 20), texto); break;
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