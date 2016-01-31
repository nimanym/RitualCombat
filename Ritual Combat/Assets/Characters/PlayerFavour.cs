using UnityEngine;
using System.Collections;

public class PlayerFavour : MonoBehaviour
{
    public float maxFavour = 100.0f;
    float favour;
    public bool isFull;
    int player;
    public GameObject favourBar;
    Vector3 favourBarSize;


    // Use this for initialization
    void Start()
    {
        favour = 0.0f;
        isFull = false;
        player = GetComponentInParent<CharacterMovement>().player;
        favourBarSize = favourBar.transform.parent.GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (favour >= 100.0f)
        {
            favour = 100.0f;
            isFull = true;
        }

        //Debug.Log(favour);
        addFavour(10*Time.deltaTime); //Debug: La regeneración de favor está chetada

        

        if (Input.GetAxis("Ulti" + player.ToString()) > 0) //BOTON B DEL MANDO
        {
            useUltimate();
        }

        //Rotación de la barra de favor al rotar el personaje 180º
        if (gameObject.transform.rotation.eulerAngles.y > 0)
        {
            favourBar.transform.parent.GetComponent<RectTransform>().localScale = new Vector3(-favourBarSize.x, favourBarSize.y, favourBarSize.z);
        }
        else
        {
            favourBar.transform.parent.GetComponent<RectTransform>().localScale = favourBarSize;
        }
    }

    //Muestra el favor actual de los personajes en pantalla
    //void OnGUI()
    //{
    //    string texto = "Favour: " + (int)favour;
    //    switch (player) {
    //        case 1: GUI.Label(new Rect(10, 40, 100, 50), texto); break;
    //        case 2: GUI.Label(new Rect(160, 40, 250, 50), texto); break;
    //        case 3: GUI.Label(new Rect(310, 40, 400, 50), texto); break;
    //        case 4: GUI.Label(new Rect(460, 40, 550, 50), texto); break;
    //    }
    //}

    public void addFavour(float fav)
    {
        favour += fav;

        //Calcula el favor actual cada vez que recibe daño para actualizar la barra de favor
        float calcFavour = favour / maxFavour;
        setFavourBar(calcFavour);
    }

    //Usa la habilidad definitiva si la barra de favor está llena
    void useUltimate()
    {
        if (isFull)
        {
            gameObject.SendMessage("Ultimate");
            favour = 0;
            isFull = false;
        }
    }

    //Actualiza la barra de favor del personaje
    public void setFavourBar(float myFavour)
    {
        if (myFavour <= 0) myFavour = 0;
        if (myFavour >= 100) myFavour = 100;
        favourBar.transform.localScale = new Vector3(myFavour, favourBar.transform.localScale.y, favourBar.transform.localScale.z);

    }

}
