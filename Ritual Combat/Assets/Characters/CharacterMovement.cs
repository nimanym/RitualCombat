using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 5.0f;
    public float jumpForce = 15.0f;
    public int player;
    public int facing;
    bool canJump;
    bool downPlatform;
    List<Collider2D> dropDown;

	// Use this for initialization
	void Start () {
        facing = 1;
        canJump = false;
        downPlatform = false;
        dropDown = new List<Collider2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate() {

        //Debug.Log(Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.min).x);
        
        //Movimiento Lateral
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal" + player.ToString())*maxSpeed, 0.0f), ForceMode2D.Impulse);

        if (transform.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            facing = 1;
            transform.Rotate(new Vector3(0, 0, 0) - transform.eulerAngles);
        }
        else if (transform.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            facing = -1;
            transform.Rotate(new Vector3(0, 180, 0) - transform.eulerAngles);
        }

            if (transform.GetComponent<Rigidbody2D>().velocity.x > maxSpeed)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
        }

        if (transform.GetComponent<Rigidbody2D>().velocity.x < -maxSpeed)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
        }


        //Salto
        if (Input.GetAxis("Jump" + player.ToString()) > 0)
        {
            if (canJump)
            {
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
                canJump = false;
            }
        }

        if (Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.center).x < 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2 (Mathf.Abs(transform.GetComponent<Rigidbody2D>().velocity.x), transform.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Camera.main.WorldToScreenPoint(transform.GetComponent<BoxCollider2D>().bounds.center).x > Screen.width)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Abs(transform.GetComponent<Rigidbody2D>().velocity.x), transform.GetComponent<Rigidbody2D>().velocity.y);
        }

        //Bajar Plataformas
        if (Input.GetAxis("Vertical" + player.ToString()) < 0)
        {
            downPlatform = true;
        }
        else {
            downPlatform = false;
            for (int i = dropDown.Count-1; i >= 0 ; i--)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), dropDown[i], false);
                dropDown.Remove(dropDown[i]);
            }
        }

    }

    void OnCollisionStay2D (Collision2D col)
    {
        if (col.gameObject.tag == "Floor" && transform.GetComponent<Rigidbody2D>().velocity.y==0)
        {
            canJump = true;
        }

        if (col.gameObject.GetComponent<PlatformEffector2D>() && downPlatform)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), col.collider);
            if (!dropDown.Contains(col.collider))
            {
                dropDown.Add(col.collider);
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            canJump = false;
        }
    }
}
