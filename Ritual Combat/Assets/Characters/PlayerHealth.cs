using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 350.0f;
    public float health;
    public GameObject healthBar;
    public GameObject ragdoll;
    bool isAlive;
    bool isBlocking;
    int player;
    float damagedTimer = 0.0f;
    Vector3 healthBarSize;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        isAlive = true;
        player = GetComponentInParent<CharacterMovement>().player;
        healthBarSize = healthBar.transform.parent.GetComponent<RectTransform>().localScale;
    }       // Update is called once per frame	
    void FixedUpdate()
    {

        if (health <= 0)
        {
            health = 0.0f;
            isAlive = false;
            die();
        }

        //El personaje se vuelve rojo cuando recibe daño
        if (damagedTimer > 0.0f)
        {
            damagedTimer -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, 2*damagedTimer);
        }

        //Rotación de la barra de vida al rotar el personaje 180º
        if (gameObject.transform.rotation.eulerAngles.y > 0)
        {
            healthBar.transform.parent.GetComponent<RectTransform>().localScale = new Vector3(-healthBarSize.x, healthBarSize.y, healthBarSize.z);
        }
        else
        {
            healthBar.transform.parent.GetComponent<RectTransform>().localScale = healthBarSize;
        }
    }

    //Muestra la vida actual de los personajes en pantalla
    //void OnGUI()
    //{
    //    string texto = "Player " + player.ToString();
    //    string texto2 = "Health: " + (int)health;
    //    switch (player)
    //    {
    //        case 1: GUI.Label(new Rect(10, 10, 100, 20), texto); GUI.Label(new Rect(10, 25, 100, 35), texto2); break;
    //        case 2: GUI.Label(new Rect(160, 10, 250, 20), texto); GUI.Label(new Rect(160, 25, 250, 35), texto2); break;
    //        case 3: GUI.Label(new Rect(310, 10, 400, 20), texto); GUI.Label(new Rect(310, 25, 400, 35), texto2); break;
    //        case 4: GUI.Label(new Rect(460, 10, 550, 20), texto); GUI.Label(new Rect(460, 25, 550, 35), texto2); break;
    //    }
    //}

    public void setBlocking(bool blocking)
    {
        isBlocking = blocking;
    }

    public void receiveDamage(int dmg)
    {
        if (!isBlocking || dmg >= 40)
        {
            damagedTimer = 0.5f;
            if (isAlive)
            {
                health -= dmg;
            }
        }
        else
        {
            gameObject.GetComponent<PlayerFavour>().addFavour(20);
            setBlocking(false);
            gameObject.SendMessage("finishBlocking");
        }
        //Calcula la vida actual cada vez que recibe daño para actualizar la barra de vida
        float calcHealth = health / maxHealth;
        setHealthBar(calcHealth);
    }

    //Actualiza la barra de vida del personaje
    public void setHealthBar(float myHealth) {
        if (myHealth <= 0) myHealth = 0;
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        
    }

    public bool checkDead() {
        return !isAlive;
    }

    void die() {
        GameObject rag = Instantiate(ragdoll);
        rag.transform.position = transform.position;
        rag.transform.rotation = transform.rotation;
        rag.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        Destroy(gameObject);
    }


}