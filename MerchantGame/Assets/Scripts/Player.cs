﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 50;

    public int deadThresh = 0;
    public int winThresh = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    public static Player Get()
    {
        Player player = GameObject.FindWithTag("Managers").GetComponent<Player>();

        return player;
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int i)
    {
        health += i;
        CheckHealth();
    }

    public bool RemoveHealth(int i)
    {
        health -= i;
        return CheckHealth();
    }

    public bool CheckHealth()
    {
        if(health <= deadThresh)
        {
            GameManager.Get().Die();
            return true;
        } else if(health >= winThresh)
        {
            GameManager.Get().Win();
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
