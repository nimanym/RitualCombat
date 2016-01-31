using UnityEngine;
using System.Collections;

public class ColliderIfNotSpear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameObject.GetComponentInParent<SpartanSpecial>().hasSpear && gameObject.GetComponent<PolygonCollider2D>() == null)
        {
            PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D>();
            collider.isTrigger = true;
        }
        else if(gameObject.GetComponentInParent<SpartanSpecial>().hasSpear && gameObject.GetComponent<PolygonCollider2D>() != null)
        {
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
        }
    }
}
