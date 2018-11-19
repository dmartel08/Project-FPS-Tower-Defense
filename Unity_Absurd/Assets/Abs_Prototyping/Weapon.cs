using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {



    public int weaponDamage = 10;
    public GameObject weaponTip;
    public Weapon_Hitbox weaponHitbox;

    public Vector3 weaponStabPos;
    public float power;
    //public bool iStabbing;


    private void Start()
    {
        power = 10f;
    }

    public void StabStart()
    {
       // iStabbing = true;
    }

    public void StabEnd()
    {
        weaponStabPos = weaponTip.transform.position;
        if (weaponHitbox.currentEnemyTarget != null)
        {
            weaponHitbox.currentEnemyTarget.GetComponent<Enemy>().TakeDamage();
        }
        else
        {
            Debug.Log("You missed..");
        }

    }

}
