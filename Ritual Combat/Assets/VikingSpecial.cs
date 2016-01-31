using UnityEngine;
using System.Collections;

public class VikingSpecial : MonoBehaviour {

    public GameObject shield;
    public float attackSpeed = 0.5f;
    public float raisedTime = 0.5f;
    float raisedCounter;
    public int favourOnHit = 20;
    public Vector3 weaponRestPosition = new Vector3(0.05f, 0);
    public Vector3 weaponRestRotation = new Vector3(0, 0, 18.0f);
    public Vector3 weaponSwingPosition = new Vector3(0.052f, 0);
    public Vector3 weaponSwingRotation = new Vector3(0, 0, 0.0f);
    Vector3 PositionDiff;
    Vector3 RotationDiff;
    bool attacking;
    bool swingIn;
    bool shieldRaised;
    bool swingOut;

    // Use this for initialization
    void Start()
    {
        PositionDiff = weaponSwingPosition - weaponRestPosition;
        RotationDiff = weaponSwingRotation - weaponRestRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Special" + GetComponentInParent<CharacterMovement>().player.ToString()) > 0)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        if (attacking && shield.transform.localPosition == weaponRestPosition && shield.transform.localRotation.eulerAngles == weaponRestRotation)
        {
            swingOut = false;
            shieldRaised = true;
            raisedCounter = raisedTime;
            swingIn = true;
        }
        else if (shieldRaised && shield.transform.localPosition == weaponSwingPosition && shield.transform.localRotation.eulerAngles == weaponSwingRotation)
        {
            if (raisedCounter <= 0.0f)
            {
                shieldRaised = false;
                gameObject.SendMessage("setBlocking", false);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                gameObject.SendMessage("setBlocking", true);
            }
            raisedCounter -= Time.deltaTime;
        }
        else if (swingIn && shield.transform.localPosition == weaponSwingPosition && shield.transform.localRotation.eulerAngles == weaponSwingRotation)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            swingIn = false;
            swingOut = true;
        }
        else if (!swingIn && !shieldRaised)
        {
            swingOut = true;
        }


        if (swingIn)
        {
            shield.transform.localPosition = Vector3.MoveTowards(shield.transform.localPosition, weaponSwingPosition, PositionDiff.magnitude * attackSpeed * Time.deltaTime);
            shield.transform.Rotate(Vector3.MoveTowards(shield.transform.localRotation.eulerAngles, weaponSwingRotation, RotationDiff.magnitude * attackSpeed * Time.deltaTime) - shield.transform.localRotation.eulerAngles);
        }
        else if (swingOut)
        {
            shield.transform.localPosition = Vector3.MoveTowards(shield.transform.localPosition, weaponRestPosition, PositionDiff.magnitude * attackSpeed * Time.deltaTime);
            shield.transform.Rotate(Vector3.MoveTowards(shield.transform.localRotation.eulerAngles, weaponRestRotation, RotationDiff.magnitude * attackSpeed * Time.deltaTime) - shield.transform.localRotation.eulerAngles);
        }
    }

    public void finishBlocking()
    {
        raisedCounter = 0;
        shieldRaised = false;
    }
}
