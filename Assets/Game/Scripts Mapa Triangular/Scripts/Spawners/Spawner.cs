﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Transform[] spawnLocation;
    public GameObject[] prefab;
    public GameObject[] clone;
    public GameObject menuPausa;

    public bool spawn = false;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
        if (spawn && menuPausa.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            Spawn();
            spawn = false;
        }

    }
    void Spawn()
    {
        clone[0] = Instantiate(prefab[0], spawnLocation[0].transform.position, Quaternion.Euler(90, 0, 180)) as GameObject;
    }
    
}
