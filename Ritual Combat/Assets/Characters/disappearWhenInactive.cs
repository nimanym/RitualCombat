using UnityEngine;
using System.Collections;

public class disappearWhenInactive : MonoBehaviour {

    public float afterSeconds = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        afterSeconds -= Time.deltaTime;

        if (afterSeconds <= 0.0f)
        {
            Destroy(gameObject);
        }
        else if (afterSeconds <= 1.0f)
        {
            if (((int)(afterSeconds * 10)) % 2 == 0)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else GetComponent<SpriteRenderer>().enabled = true;
        }
        
	}
}
