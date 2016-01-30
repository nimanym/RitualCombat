using UnityEngine;
using System.Collections;

public class slowingOrb : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * 0.96f;

        if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
