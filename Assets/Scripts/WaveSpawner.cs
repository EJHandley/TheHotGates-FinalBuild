using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

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

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public TMP_Text waveCountdownText;

    private float enemyCheck = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public GameManager gameManager;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No Spawn Points");
        }

        waveCountdown = timeBetweenWaves;
    }

    public void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

        waveCountdownText.text = Mathf.Round(waveCountdown).ToString();
    }

    public void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            this.enabled = false;
            gameManager.WinLevel();
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
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

        state = SpawnState.WAITING;

        yield break;
    }

    public void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("SPAWNING ENEMY");

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        
    }
}
