using UnityEngine;
using System.Collections;

public class PlayerFavour : MonoBehaviour
{
    public float maxFavour = 100.0f;
    float favour;
    public bool isFull;


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
        favour += 10*Time.deltaTime;
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
