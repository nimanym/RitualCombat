using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 350;
    public int health;
    bool isAlive;
    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        isAlive = true;
    }       // Update is called once per frame	
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            isAlive = false;
        }
    }

    void receiveDamage()
    {
        if (isAlive)
        {
            health -= 30;
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