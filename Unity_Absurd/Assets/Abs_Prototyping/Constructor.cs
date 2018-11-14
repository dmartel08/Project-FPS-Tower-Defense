using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor : MonoBehaviour {

    public Game_Manager gameManager;
    public Player_Manager playerManager;

    public void Awake()
    {
        gameManager = FindObjectOfType<Game_Manager>();
        playerManager = FindObjectOfType<Player_Manager>();
    }

}
