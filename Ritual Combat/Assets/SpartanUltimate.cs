using UnityEngine;
using System.Collections;

public class SpartanUltimate : MonoBehaviour {

    public GameObject spear;
    public int numberOfSpears = 6;

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
        for (int i = 1; i <= numberOfSpears; i++)
        {
            GameObject spearRain = Instantiate(spear);
            spearRain.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(i*Screen.width/(numberOfSpears+1)+Random.Range(-(Screen.width / (numberOfSpears + 1)), Screen.width / (numberOfSpears+1)), Screen.height+50, 10));
            spearRain.GetComponent<hurtPlayers>().knockback = true;
            spearRain.GetComponent<hurtPlayers>().setException(gameObject);
            spearRain.GetComponent<dropCollectableSpear>().player = gameObject.GetComponent<CharacterMovement>().player;
        }

    }
}
