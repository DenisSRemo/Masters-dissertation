﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_zombie : MonoBehaviour
{
    /// <summary>
    /// this deals with the zombie horde mechanic
    /// </summary>

    public GameObject[] zombies;
    
    private void Start()
    {
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i].SetActive(false);
        }
           
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            for (int i = 0; i < zombies.Length; i++)
            {
                zombies[i].SetActive(true);
            }
           // Destroy(gameObject);
        }
        
    }
}
