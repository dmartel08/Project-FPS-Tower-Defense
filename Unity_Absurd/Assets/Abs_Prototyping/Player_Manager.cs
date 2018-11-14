using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour{

    public bool constructing;
    public Game_Manager gameManager;

    public float playerReach = 5f;
    public LayerMask layerMaskFloor = 9;
    public LayerMask layerMaskCore = 12;
    //public LayerMask layerMaskDefault = 0;
    public bool colliding = false;

    public bool canBuild = false;

    public void Awake()
    {
        gameManager = FindObjectOfType<Game_Manager>();

    }
    public void ConstructMode()
    {
        //Can't fucking instantiate because it will repeat continously.
        //GameObject _core = Instantiate(gameManager.coreConstructorPrefab, transform.forward* 1f, Quaternion.identity);
        if (constructing == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Turned *on* construction mode");
                constructing = true;
                gameManager._coreConstructor.SetActive(true);
            }
        }
        else if (constructing == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Turned *off* construction mode");
                constructing = false;
                canBuild = false;
                //gameManager.coreConstructorPrefab.transform.position = new Vector3(0, 0, 0);
                gameManager._coreConstructor.SetActive(false);
            }
        }

        Construction(constructing);
        Build();
    }

    public void Construction(bool can_construct)
    {
        
        if (can_construct ==  true)
        {
            RaycastHit hitLevel;

            Ray rayPlayer = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0f));
            

            if (Physics.Raycast(rayPlayer, out hitLevel, playerReach, layerMaskFloor))
            {
                //Can't instantiate because it'll just repeat all the fucking time.
                Debug.Log("Did hit floor");
                RaycastHit hitOther;
                
                ///Kill yourself
                Debug.DrawRay(gameManager._coreConstructor.transform.position + new Vector3(0f, .05f, 0f), Vector3.forward + Vector3.forward, Color.red);
                Debug.DrawRay(gameManager._coreConstructor.transform.position + new Vector3(0f, .05f, 0f), Vector3.left + Vector3.left, Color.yellow);
                Debug.DrawRay(gameManager._coreConstructor.transform.position + new Vector3(0f, .05f, 0f), Vector3.right + Vector3.right, Color.blue);
                Debug.DrawRay(gameManager._coreConstructor.transform.position + new Vector3(0f, .05f, 0f), Vector3.back + Vector3.back, Color.cyan);

                bool notHittingShit = true;

                ///Cardinal directions plus the inbetween so 8 points of contact.
                if (Physics.Raycast(hitLevel.point + new Vector3(0f, .05f, 0f), Vector3.forward, out hitOther, 2f) == true) 
                {
                   notHittingShit = false;
                }
                else if (Physics.Raycast(hitLevel.point + new Vector3(0f, .05f, 0f), Vector3.forward + Vector3.left, out hitOther, 2f) == true)
                {
                   notHittingShit = false;
                }
                else if (Physics.Raycast(hitLevel.point + new Vector3(0f, .05f, 0f), Vector3.left, out hitOther, 2f) == true)
                {
                    notHittingShit = false;
                }
                else if (Physics.Raycast(hitLevel.point + new Vector3(0f, .05f, 0f), Vector3.left + Vector3.back, out hitOther, 2f) == true)
                {
                    notHittingShit = false;
                }
                else if (Physics.Raycast(hitLevel.point + new Vector3(0f, .05f, 0f), Vector3.back, out hitOther, 2f) == true)
                {
                    notHittingShit = false;
                }
                else if (Physics.Raycast(hitLevel.point + new Vector3(0f, .05f, 0f), Vector3.back + Vector3.right, out hitOther, 2f) == true)
                {
                    notHittingShit = false;
                }
                else if (Physics.Raycast(hitLevel.point + new Vector3(0f, .05f, 0f), Vector3.right, out hitOther, 2f) == true)
                {
                   notHittingShit = false;
                }
                else if (Physics.Raycast(hitLevel.point + new Vector3(0f, .05f, 0f), Vector3.right + Vector3.forward, out hitOther, 2f) == true)
                {
                    notHittingShit = false;
                }

                if (notHittingShit)
                {
                    gameManager._coreConstructor.transform.position = hitLevel.point;
                    
                }
                ///Don't put in notHittingShit because if up against a wall, you're still hitting shit but the construct has space.
                canBuild = true;
                Debug.Log("I Can build right now");
            }
            
        }
    }

    public void Build()
    {

        if (canBuild)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(gameManager.corePrefab, gameManager._coreConstructor.transform.position, Quaternion.identity);
                canBuild = false;
                constructing = false;
                gameManager._coreConstructor.SetActive(false);
            }
        }
    }

    public void Update()
    {
        ConstructMode();

    }
}

