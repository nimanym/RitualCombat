using UnityEngine;
using System.Collections;

public class hurtPlayers : MonoBehaviour {

    public int damage = 50;
    public GameObject exceptPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setException(GameObject player)
    {
        exceptPlayer = player;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject != exceptPlayer)
            {
                col.gameObject.GetComponent<PlayerHealth>().receiveDamage(damage);
                Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), col.collider);
            }
        }
    }
}
