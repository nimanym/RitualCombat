using UnityEngine;
using System.Collections;

public class bounceOnBorder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.center).x < 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(transform.GetComponent<Rigidbody2D>().velocity.x), transform.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.center).x > Screen.width)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Abs(transform.GetComponent<Rigidbody2D>().velocity.x), transform.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
