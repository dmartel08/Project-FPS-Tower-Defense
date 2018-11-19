using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	private int health = 10;
    public bool canBeDamaged = true;

    public Player_Manager playerManager;
    public Weapon playerWeapon;
   // public Collider playerWeaponCol;

    private void Start()
    {
       
        playerManager = FindObjectOfType<Player_Manager>();
        playerWeapon = playerManager.playerWeapon.GetComponent<Weapon>();
    //    playerWeaponCol = playerWeapon.GetComponent<Collider>();
    }

    public void Stab()
    {

    }

    public void TakeDamage()
    {
        if (canBeDamaged)
        {
            Debug.Log("Oh fuck I'm gonna get hurt");

            health = health - playerWeapon.weaponDamage;
            Debug.Log(this.name + " health is now " + health);

            if (health <= 0)
            {
                GetComponent<NavMeshAgent>().enabled = false;
                Debug.Log("Oh shit I'm daed");
                canBeDamaged = false;
                Rigidbody rb = this.GetComponent<Rigidbody>();
                
                // (playerWeapon.power, playerWeapon.weaponStabPos)
                rb.isKinematic = false;
                rb.useGravity = false;
                //playerManager.transform.forward
                rb.AddForceAtPosition(/*playerWeapon.power */ playerWeapon.weaponHitbox.transform.forward * 40f, playerWeapon.weaponStabPos.normalized, ForceMode.Impulse);

            }
        }
        
          
    }
    
}
