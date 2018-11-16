using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_Manager : MonoBehaviour {

    /// <summary>
    /// Units
    /// </summary>
    public GameObject Player;
    public GameObject enemyPrefab;
    public List<GameObject> enemies = null;

    /// <summary>
    /// Buildings
    /// </summary>
    public GameObject corePrefab;
    public GameObject core = null;
    /// <summary>
    /// Spawns
    /// </summary>
    public GameObject playerSpawn;
    public List<GameObject> enemySpawns;

    /// <summary>
    /// Building constructors
    /// </summary>
    public GameObject coreConstructorPrefab;
    public GameObject _coreConstructor;
    public Material _coreConstructorMat;

    public void Start()
    {
        _coreConstructor = Instantiate(coreConstructorPrefab);
        Renderer rend = _coreConstructor.GetComponent<Renderer>();
        _coreConstructorMat = rend.material;

        ///So it's not in your face. Can't start inactive otherwise parameters don't get assigned.
        _coreConstructor.SetActive(false);
        
    }

    public void AttackPhase()
    {
        
        //Spawn units
        foreach (GameObject enemySpawn in enemySpawns)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemySpawn.transform.position, Quaternion.identity);
            enemies.Add(enemy);
        }

        //Sends units
        foreach (GameObject enemy in enemies)
        {
            if (core != null)
            {
                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                agent.destination = core.transform.position;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AttackPhase();
        }
    }
}
