using UnityEngine;
using System.Collections;

public class canBeCollected : MonoBehaviour {

    public int player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<CharacterMovement>().player == player)
            {
                col.gameObject.GetComponent<SpartanSpecial>().hasSpear = true;
                Destroy(gameObject);
            }
        }
    }
}
