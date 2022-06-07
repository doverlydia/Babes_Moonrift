using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int nextWave = 1;

    public enum SpawnState { Spawning, Waiting, Counting };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;

    [SerializeField] float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;

    //bool isGameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;


        //StartCoroutine(SpawnWave(waves[nextWave]));
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            //check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //Begin a new round
                WaveCompleted();
                //waveCountdown = graceTime;
            }
        }
        else
        {
            //waveCountdown -= Time.deltaTime;
            //Debug.Log("Enemy Still alive");
            //return;
        }  
        
        if (waveCountdown <= 0)
        {
            if (state == SpawnState.Counting)
            {
                //start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves complete! Looping...");
            //Can put a finished screen or transition here
        }
        else
        {
            nextWave++;
        }    
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            //Done every second as opposed to every frame
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }  
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.Spawning;
        waveCountdown = timeBetweenWaves;
        //spawn a bunch of things

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            //In order to wait a few seconds between spawning
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        //Debug.Log("I am now waiting");
        state = SpawnState.Waiting;
        //Need this break
        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
        
    }










    /*

    IEnumerator GracePeriod()
    {
        Debug.Log("spawned enemies logic");
        yield return new WaitForSeconds(graceTime);
        if (!isGameEnded)
            StartCoroutine(GracePeriod());
    }
    */
}