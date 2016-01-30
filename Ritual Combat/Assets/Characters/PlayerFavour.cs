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
        favour += Time.deltaTime;
        if (favour >= 100.0f)
        {
            favour = 100.0f;
            isFull = true;
        }

        if (Input.GetAxis("Fire1") > 0) //BOTON B DEL MANDO
        {
            useUltimate();
        }
    }

    void addFavour(int fav)
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
        Debug.Log(favour);
        if (isFull)
        {
            favour = 0;
            isFull = false;
            //Debug.Log("Usas tu ulti: "+favour);

        }
    }

}
