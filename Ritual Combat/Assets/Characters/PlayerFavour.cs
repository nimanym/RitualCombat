using UnityEngine;
using System.Collections;

public class PlayerFavour : MonoBehaviour
{
    public float maxFavour = 100.0f;
    float favour;
    public bool isFull;
    public int player;


    // Use this for initialization
    void Start()
    {
        favour = 0.0f;
        isFull = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(favour);
        favour += 100*Time.deltaTime;
        if (favour >= 100.0f)
        {
            favour = 100.0f;
            isFull = true;
        }

        if (Input.GetAxis("Ulti" + GetComponentInParent<CharacterMovement>().player.ToString()) > 0) //BOTON B DEL MANDO
        {
            useUltimate();
        }
    }

    void OnGUI()
    {
        string texto = "Favour: " + favour;
        if (player == 1)
        {
            GUI.Label(new Rect(10, 40, 100, 50), texto);
        }
        else if (player == 2)
        {
            GUI.Label(new Rect(Screen.width - 100, 40, Screen.width - 10, 50), texto);
        }
    }

    public void addFavour(int fav)
    {
        favour += fav;
    }

    void addFavour()
    {
        if (Input.GetAxis("Fire2") > 0)
        {
            favour += 10;
        }
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
