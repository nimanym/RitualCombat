using UnityEngine;
using System.Collections;

public class rotateDirection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, 0, Mathf.Rad2Deg*(Mathf.Atan(GetComponent<Rigidbody2D>().velocity.y / GetComponent<Rigidbody2D>().velocity.x))-transform.rotation.eulerAngles.z);
        if (GetComponent<Rigidbody2D>().velocity.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if(GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
