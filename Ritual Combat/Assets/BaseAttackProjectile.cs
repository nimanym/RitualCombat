using UnityEngine;
using System.Collections;

public class BaseAttackProjectile : MonoBehaviour {

    public int damage = 5;
    public GameObject projectile;
    public float attackSpeed = 1.0f;
    public int favourOnHit = 10;
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
            cooldown = cooldown = 1 / attackSpeed;
        }
        
    }
}
