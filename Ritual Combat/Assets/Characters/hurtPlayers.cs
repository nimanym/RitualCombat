using UnityEngine;
using System.Collections;

public class hurtPlayers : MonoBehaviour {

    public int damage = 50;
    public GameObject exceptPlayer;
    public bool autoDestruct = false;
    public float giveFavour = 0.0f;
    public bool knockback = false;

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
                if (giveFavour>0)
                {
                    exceptPlayer.GetComponent<PlayerFavour>().addFavour(giveFavour);
                }
                col.gameObject.GetComponent<PlayerHealth>().receiveDamage(damage);

                if (knockback)
                {
                    col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((damage / 3.0f) *Mathf.Sign(col.gameObject.transform.position.x-transform.position.x), 0), ForceMode2D.Impulse);
                }

                if (autoDestruct)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), col.collider);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject != exceptPlayer)
            {
                if (giveFavour > 0)
                {
                    exceptPlayer.GetComponent<PlayerFavour>().addFavour(giveFavour);
                }
                col.gameObject.GetComponent<PlayerHealth>().receiveDamage(damage);

                if (knockback)
                {
                    col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((damage / 3.0f) * Mathf.Sign(col.gameObject.transform.position.x - transform.position.x), 0), ForceMode2D.Impulse);
                }

                if (autoDestruct)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), col);
                }
            }
        }
    }
}
