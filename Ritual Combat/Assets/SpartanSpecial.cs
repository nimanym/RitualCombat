using UnityEngine;
using System.Collections;

public class SpartanSpecial : MonoBehaviour {

    public int damage = 50;
    public GameObject projectile;
    public float attackSpeed = 1.0f;
    public float favourOnHit = 10;
    public float projectileSpeed = 20.0f;
    bool attacking;
    public bool hasSpear = true;
    float cooldown;
    GameObject shot;
    GameObject spear;

    // Use this for initialization
    void Start()
    {
        cooldown = 1 / attackSpeed;
        spear = GameObject.FindGameObjectWithTag("Spear");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetAxis("Special" + GetComponentInParent<CharacterMovement>().player.ToString()) > 0)
        {
            attacking = true;
        }
        else {
            attacking = false;
        }

        if (attacking && cooldown <= 0 && hasSpear)
        {
            shot = Instantiate(projectile);
            shot.transform.position = transform.position;
            shot.transform.localScale = transform.localScale;
            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<CharacterMovement>().facing * projectileSpeed, projectileSpeed/5);
            shot.GetComponent<hurtPlayers>().damage = damage;
            shot.GetComponent<hurtPlayers>().giveFavour = favourOnHit;
            shot.GetComponent<hurtPlayers>().autoDestruct = false;
            shot.GetComponent<hurtPlayers>().knockback = true;
            shot.GetComponent<hurtPlayers>().setException(gameObject);
            shot.GetComponent<dropCollectableSpear>().player = gameObject.GetComponent<CharacterMovement>().player;
            cooldown = 1 / attackSpeed;
            
            hasSpear = false;
        }

        spear.SetActive(hasSpear);
    }
}
