using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

    public GameObject Player;
    public GameObject enemyPrefab;
    public GameObject corePrefab;

    //This needs to exist in scene because my code sucks ass. Can't instantiate an instance so need to 
    //pull from somewhere already existing in the scene.
    //Don't make this a prefab. (Yet...jk who am I kidding, I won't fucking finish this project)
    public GameObject coreConstructorPrefab;
    public GameObject _coreConstructor;

    public void Start()
    {
        _coreConstructor = Instantiate(coreConstructorPrefab);
        _coreConstructor.SetActive(false);
    }

}
