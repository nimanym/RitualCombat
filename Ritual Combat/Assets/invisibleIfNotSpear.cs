using UnityEngine;
using System.Collections;

public class invisibleIfNotSpear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.SetActive(gameObject.GetComponentInParent<SpartanSpecial>().hasSpear);
	}
}
