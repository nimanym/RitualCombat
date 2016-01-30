using UnityEngine;
using System.Collections;

public class CultistUltimate : MonoBehaviour {

    public GameObject tentacle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ultimate()
    {
        GameObject cthulhu = Instantiate(tentacle);
        if (GetComponent<CharacterMovement>().facing == 1)
        {
            cthulhu.transform.position = new Vector3(-21, transform.position.y, 1);
        }
        else if (GetComponent<CharacterMovement>().facing == -1)
        {
            cthulhu.transform.Rotate(new Vector3(0, 180, 0));
            cthulhu.transform.position = new Vector3(21, transform.position.y, 1);
        }
        cthulhu.GetComponent<hurtPlayers>().setException(gameObject);
    }
}
