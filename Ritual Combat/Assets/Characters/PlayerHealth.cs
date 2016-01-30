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
        string texto = "Player" + player.ToString() + ": " + health;
        if (player == 1)
        {
            GUI.Label(new Rect(10, 10, 100, 20), texto);
        }
        else if (player == 2)
        {
            GUI.Label(new Rect(Screen.width - 100, 10, Screen.width - 10, 20), texto);
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