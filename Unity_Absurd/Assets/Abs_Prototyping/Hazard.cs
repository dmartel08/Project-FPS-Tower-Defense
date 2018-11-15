using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    Game_Manager gameManager;

    GameObject player;
    Player_Manager playerManager;
    Collider playerCol;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game_Manager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<Player_Manager>();
        playerCol = player.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCol)
        {
            Debug.Log("Something fell into me");
            player.transform.position = gameManager.playerSpawn.transform.position;
        }
    }
}
