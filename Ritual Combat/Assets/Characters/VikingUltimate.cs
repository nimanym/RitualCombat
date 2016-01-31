using UnityEngine;
using System.Collections;

public class VikingUltimate : MonoBehaviour {

    public GameObject hammer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Ultimate()
    {
        GameObject mjollnir = Instantiate(hammer);
        mjollnir.transform.position = new Vector3(transform.position.x+GetComponent<CharacterMovement>().facing*3, mjollnir.transform.position.y);
        mjollnir.transform.Rotate(new Vector3(0, 0, 270));
        /*if(GetComponent<CharacterMovement>().facing == -1)
        {
            mjollnir.transform.Rotate(new Vector3(0, 0, 180));
        }*/
        mjollnir.GetComponent<hurtPlayers>().knockback = true;
        mjollnir.GetComponent<hurtPlayers>().setException(gameObject);
    }
}
