﻿using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public TMP_Text waveCountdownText;
    public TMP_Text waveStartText;

    public float enemyCheck = 1f;
    public float spawnerCheck = 1f;

    private GameObject[] spawnPoints;

    public GameManager gameManager;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        if (spawnPoints.Length == 0)
        {
            Debug.Log("No Spawn Points");
        }

        waveCountdown = timeBetweenWaves;
    }

    public void Update()
    {
        if (!SpawnerIsActive())
        {
            AllWavesCompleted();
            return;
        }

        waveCountdownText.text = "Next Wave In:" + " " + Mathf.Round(waveCountdown).ToString();
    }

    public void StartCountdown()
    {
        waveCountdown -= Time.deltaTime;
    }

    public void AllWavesCompleted()
    {
        gameManager.WinLevel();
    }

    bool SpawnerIsActive()
    {
        spawnerCheck -= Time.deltaTime;
        if (spawnerCheck <= 0f)
        {
            spawnerCheck = 1f;
            if(GameObject.FindGameObjectWithTag("SpawnPoint") == null)
                {
                    return false;
                }
        }
        return true;
    }
}
