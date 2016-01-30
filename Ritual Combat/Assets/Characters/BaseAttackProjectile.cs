using UnityEngine;
using System.Collections;

public class BaseAttackProjectile : MonoBehaviour {

    public int damage = 5;
    public GameObject projectile;
    public float attackSpeed = 1.0f;
    public float favourOnHit = 10;
    public float projectileSpeed = 15.0f;
    bool attacking;
    float cooldown;
    GameObject shot;

    // Use this for initialization
    void Start()
    {
        cooldown = 1 / attackSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetAxis("BaseAttack" + GetComponentInParent<CharacterMovement>().player.ToString()) > 0)
        {
            attacking = true;
        }
        else {
            attacking = false;
        }
        
        if(attacking && cooldown <= 0)
        {
            shot=Instantiate(projectile);
            shot.transform.position = transform.position;
            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<CharacterMovement>().facing*projectileSpeed, 0);
            shot.GetComponent<hurtPlayers>().damage = damage;
            shot.GetComponent<hurtPlayers>().giveFavour = favourOnHit;
            shot.GetComponent<hurtPlayers>().autoDestruct = true;
            shot.GetComponent<hurtPlayers>().setException(gameObject);
            cooldown = 1 / attackSpeed;
        }
        
    }
}
