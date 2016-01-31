using UnityEngine;
using System.Collections;

public class BaseAttack : MonoBehaviour {

    public int damage = 10;
    public GameObject weapon;
    public float attackSpeed = 2.0f;
    public int favourOnHit = 10;
    public Vector3 weaponRestPosition = new Vector3(0.05f, 0);
    public Vector3 weaponRestRotation = new Vector3(0, 0, 18.0f);
    public Vector3 weaponSwingPosition = new Vector3(0.052f, 0);
    public Vector3 weaponSwingRotation = new Vector3(0, 0, 0.0f);
    Vector3 PositionDiff;
    Vector3 RotationDiff;
    bool attacking;
    bool swingIn;
    bool swingOut;

	// Use this for initialization
	void Start () {
        PositionDiff = weaponSwingPosition - weaponRestPosition;
        RotationDiff = weaponSwingRotation - weaponRestRotation;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxis("BaseAttack" + GetComponentInParent<CharacterMovement>().player.ToString()) > 0)
        {
            attacking = true;
        }
        else {
            attacking = false;
        }

        if (attacking && weapon.transform.localPosition == weaponRestPosition && weapon.transform.localRotation.eulerAngles == weaponRestRotation)
        {
            swingOut = false;
            swingIn = true;
        }
        else if(swingIn && weapon.transform.localPosition == weaponSwingPosition && weapon.transform.localRotation.eulerAngles == weaponSwingRotation)
        {
            swingIn = false;
            swingOut = true;
        }
        else if (!swingIn)
        {
            swingOut = true;
        }


        if (swingIn)
        { 
            weapon.transform.localPosition = Vector3.MoveTowards(weapon.transform.localPosition, weaponSwingPosition, PositionDiff.magnitude * attackSpeed * Time.deltaTime);
            weapon.transform.Rotate(Vector3.MoveTowards(weapon.transform.localRotation.eulerAngles, weaponSwingRotation, RotationDiff.magnitude * attackSpeed * Time.deltaTime)- weapon.transform.localRotation.eulerAngles);
            weapon.GetComponentInChildren<BoxCollider2D>(true).enabled = true;
        }
        else if (swingOut){
            weapon.transform.localPosition = Vector3.MoveTowards(weapon.transform.localPosition, weaponRestPosition, PositionDiff.magnitude * attackSpeed * Time.deltaTime);
            weapon.transform.Rotate(Vector3.MoveTowards(weapon.transform.localRotation.eulerAngles, weaponRestRotation, RotationDiff.magnitude * attackSpeed * Time.deltaTime)- weapon.transform.localRotation.eulerAngles);
            weapon.GetComponentInChildren<BoxCollider2D>(true).enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject != gameObject)
            {
                GetComponentInParent<PlayerFavour>().addFavour(favourOnHit);
                col.gameObject.GetComponent<PlayerHealth>().receiveDamage(damage);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(damage* GetComponentInParent<CharacterMovement>().facing, 0), ForceMode2D.Impulse);
            }
        }
    }
}
