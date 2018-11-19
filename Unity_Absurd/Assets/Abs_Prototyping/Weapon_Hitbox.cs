using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hitbox : MonoBehaviour {

    //public bool isTarget;
    public Weapon weapon;
    public Enemy currentEnemyTarget;

    private void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("something something ");
            currentEnemyTarget = col.gameObject.GetComponent<Enemy>();
           // GameObject testEnemy = col.gameObject.GetComponent<GameObject>();
            //Enemy _enemy = col.gameObject.GetComponent<Enemy>();
        }
    }
    private void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("something something ");
            currentEnemyTarget = col.gameObject.GetComponent<Enemy>();
            // GameObject testEnemy = col.gameObject.GetComponent<GameObject>();
            //Enemy _enemy = col.gameObject.GetComponent<Enemy>();
        }
    }
    /*
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            testEnemy = col.gameObject.GetComponent<GameObject>();
            //Enemy _enemy = col.gameObject.GetComponent<Enemy>();
        }
    }
    */
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Enemy _enemy = col.gameObject.GetComponent<Enemy>();
            currentEnemyTarget = null;
        }
    }
    
}
