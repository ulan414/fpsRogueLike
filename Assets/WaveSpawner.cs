using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = -1;

    public float timeBetweenWaves = 3f;
    public float waveCountDown;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public Transform player;
    public float minRadius = 15f;
    public float maxRadius = 50f;

    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                //begin
                Debug.Log("Wave Completed");
            }
            else
            {
                return;
            }
        }
        if(waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                if (waves.Length > nextWave + 1) {
                    nextWave++;
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
                else
                {
                    Debug.Log("You win!!!");
                }
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if(searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("AI") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(_wave.rate);
        }
        state = SpawnState.WAITING;

        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        Vector2 randomOffset = Random.insideUnitCircle.normalized * Random.Range(minRadius, maxRadius);
        Vector3 spawnPosition = player.position + new Vector3(randomOffset.x, 0.1f, randomOffset.y);
        Instantiate(_enemy, spawnPosition, transform.rotation);
        Debug.Log("Spawning enemy: " + _enemy.name);
    }
}
