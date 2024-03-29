﻿using System.Collections;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING, HOLDING };
    public SpawnState state = SpawnState.HOLDING;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public float spawnRate;
        public WaveGroup[] enemies;

        [System.Serializable]
        public class WaveGroup
        {
            public Transform enemy;
            public int count;
        }
    }

    public WaveSpawner waveSpawner;

    public GameObject self;

    public Wave[] waves;
    [HideInInspector]
    public int nextWave = 0;

    public float enemyCheck = 1f;

    [HideInInspector]
    public bool waveStarted = false;

    public void Update()
    {
        if (GameManager.GameIsOver)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            waveSpawner.waveStartText.enabled = false;
            waveSpawner.waveCountdownText.enabled = true;
            waveStarted = true;
        }

        if (!waveStarted)
        {
            waveSpawner.waveStartText.enabled = true;
            waveSpawner.waveCountdownText.enabled = false;
            return;
        }

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveSpawner.waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveSpawner.StartCountdown();
        }
    }

    private void WaveCompleted()
    {
        waveSpawner.waveCountdown = waveSpawner.timeBetweenWaves;

        state = SpawnState.COUNTING;

        if (nextWave + 1 > waves.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            nextWave++;
            if(nextWave == 3 || nextWave == 6 || nextWave == 9)
            {
                waveStarted = false;
            }
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int z = 0; z < _wave.enemies.Length; z++)
        {
            for (int i = 0; i < _wave.enemies[z].count; i++)
            {
                SpawnEnemy(_wave.enemies[z].enemy);
                yield return new WaitForSeconds(1f / _wave.spawnRate);
            }
        }

        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, transform.position, transform.rotation);
    }

    public bool EnemyIsAlive()
    {
        enemyCheck -= Time.deltaTime;
        if (enemyCheck <= 0f)
        {
            enemyCheck = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
}
