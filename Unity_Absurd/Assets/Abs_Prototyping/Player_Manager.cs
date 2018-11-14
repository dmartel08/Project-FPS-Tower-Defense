using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour{

    public bool constructing;
    public Game_Manager gameManager;

    public float playerReach = 5f;
    
    public LayerMask layerMaskFloor = 9;
    public LayerMask layerMaskConstructor = 10;
    public LayerMask layerMaskCore = 12;
    public LayerMask layerMaskPillars = 13;
    //public LayerMask layerMaskDefault = 0;
    public bool colliding = false;

    public bool canBuild = false;

    public void Awake()
    {
        gameManager = FindObjectOfType<Game_Manager>();
        
        ///YOU HAVE TO DO THIS STUPID FUCKING BULLSHIT
        layerMaskFloor = 1 << 9;
        layerMaskConstructor = 1 << 10;
        layerMaskCore = 1 << 12;
        layerMaskPillars = 1 << 13;
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

    public void Construction(bool constructing)
    {
        
        if (constructing ==  true)
        {
            RaycastHit hitLevel;
            RaycastHit hitObstacle;
            Ray rayPlayer = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0f));
            gameManager._coreConstructorMat.color = Color.red;
            canBuild = false;
            bool notHittingShit = true;

            ///A catch for the constructor to not make a core when one already exists or looking at a pillar.
            ///
            if (Physics.Raycast(rayPlayer, out hitObstacle, playerReach, layerMaskCore | layerMaskPillars))
            {
                Debug.Log("IM LOOKING AT CORE");
                Debug.DrawLine(Camera.main.transform.position, hitObstacle.point, Color.blue);
                notHittingShit = false;

            }


            if (Physics.Raycast(rayPlayer, out hitLevel, playerReach, layerMaskFloor))
            {
                Debug.DrawLine(Camera.main.transform.position, hitLevel.point, Color.blue);
                RaycastHit hitOther;
                

                ///Kill yourself
                /*
                Debug.DrawRay(gameManager._coreConstructor.transform.position + new Vector3(0f, .05f, 0f), Vector3.forward + Vector3.forward, Color.red);
                Debug.DrawRay(gameManager._coreConstructor.transform.position + new Vector3(0f, .05f, 0f), Vector3.left + Vector3.left, Color.yellow);
                Debug.DrawRay(gameManager._coreConstructor.transform.position + new Vector3(0f, .05f, 0f), Vector3.right + Vector3.right, Color.blue);
                Debug.DrawRay(gameManager._coreConstructor.transform.position + new Vector3(0f, .05f, 0f), Vector3.back + Vector3.back, Color.cyan);
                */

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
                    gameManager._coreConstructorMat.color = Color.green;
                    canBuild = true;
                }
                
            }
            //Constantly move the constructor so you can see where it can/can't be built.
           gameManager._coreConstructor.transform.position = hitLevel.point;
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

