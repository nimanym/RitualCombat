using UnityEngine;
using System.Collections;

public class CrossScreen : MonoBehaviour {

    public float speed=1.0f;
    bool goingBack;
    bool leftToRight;

    // Use this for initialization
    void Start () {
        if (transform.rotation.eulerAngles.y == 0)
        {
            leftToRight = true;
        }
        else leftToRight = false;

        goingBack = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (leftToRight)
        {
            if (goingBack)
            {
                transform.Translate(new Vector3(-speed, 0));
                if (Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.max).x < 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                transform.Translate(new Vector3(speed, 0));
                if(Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.max).x > Screen.width)
                {
                    goingBack = true;
                }
            }
        }
        else //RightToLeft
        {
            if (goingBack)
            {
                transform.Translate(new Vector3(-speed, 0));
                if (Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.min).x > Screen.width)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("entra");
                transform.Translate(new Vector3(speed, 0));
                if (Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.min).x < 0)
                {
                    goingBack = true;
                }
            }
        }



    }
}
