﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown("Escape"))
        {
            Application.Quit();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over");
    }
}