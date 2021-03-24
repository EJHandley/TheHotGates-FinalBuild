using System.Collections;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    enum SpawnState { SPAWNING, WAITING, COUNTING };
    SpawnState state = SpawnState.COUNTING;

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
    private int nextWave = 0;

    public float enemyCheck = 1f;

    public void Update()
    {
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

        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;

        if (nextWave + 1 > waves.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            nextWave++;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("SPAWNING WAVE");
        state = SpawnState.SPAWNING;

        for (int z = 0; z < _wave.enemies.Length; z++)
        {
            for (int i = 0; i < _wave.enemies[z].count; i++)
            {
                SpawnEnemy(_wave.enemies[z].enemy);
                yield return new WaitForSeconds(1f / _wave.spawnRate);
            }
        }

        Debug.Log("FINISHED SPAWNING");
        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("SPAWNING ENEMY");
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
