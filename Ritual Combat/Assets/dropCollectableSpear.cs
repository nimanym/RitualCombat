using UnityEngine;
using System.Collections;

public class dropCollectableSpear : MonoBehaviour {

    public GameObject collectableSpear;
    public int player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.5f)
        {
            Destroy(gameObject);
        }*/
    }

    void OnDestroy()
    {
        GameObject drop = Instantiate(collectableSpear);
        drop.transform.position = transform.position;
        drop.transform.rotation = transform.rotation;
        drop.transform.localScale = transform.localScale;
        //drop.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        drop.GetComponent<canBeCollected>().player = player;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" )
        {
            Destroy(gameObject);
        }
    }
}
