using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting}



    [System.Serializable]
    public class Wave
    {
        public string nameOfWave;
        public GameObject enemy;
        public int enemyCount;
        public float rate;
        
    }
    public Transform[] spawnPoints;
    private int currentSpawnPoint;
    public Wave wave;
    public Wave[] waves;
    private int nextWave;

    private EnemyController enemyController;

    public Transform core;
    public GameObject player;

    public float waveDelay;
    private float waveCountDown;

    public SpawnState state = SpawnState.Counting;


    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = waveDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == SpawnState.Waiting)
        {
            if(!EnemyIsAlive())
            {
                
                Debug.Log("Wave Completed!");
            }
            else
            {
                waveCountDown = waveDelay;
                state = SpawnState.Counting;
                return;
            }
        }



        if(waveCountDown <= 0)
        {
            if(state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }else
        {
            waveCountDown -= Time.deltaTime;
        }
            
    }

    public bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return true;
        }
        else
            return false;
    }


    IEnumerator SpawnWave(Wave _wave)
    {
        if (state != SpawnState.Waiting)
        {
            Debug.Log("Spawning wave:" + _wave.nameOfWave);
            state = SpawnState.Spawning;


            for (int i = 0; i < _wave.enemyCount; i++)
            {
                SpawnEnemy(_wave.enemy);
                yield return new WaitForSeconds(_wave.rate);

            }

        }
        state = SpawnState.Waiting;

        yield break;
    }
    
    void SpawnEnemy(GameObject _enemy)
    {
        
        currentSpawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(_enemy, spawnPoints[currentSpawnPoint].position, Quaternion.identity);
        enemyController = enemy.GetComponent<EnemyController>();
        enemyController.playerTarget = player;
        enemyController.coreTarget = core;
        enemyController.roundController = this;
        Debug.Log("Spawning enemy: " + _enemy);
    }



}
