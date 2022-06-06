using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrick_WaveSpawner : MonoBehaviour
{

    public enum SpwanState { SPAWNING, WAITING, COUNTING };


    [System.Serializable]
    public class Wave{
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;

    private int nextWave = 0;

    public float timeBetweenWave = 5f;
    public float waveCountDown;

    private float serchCountdown = 1f;

    public SpwanState state = SpwanState.COUNTING; 


    void Start(){
        waveCountDown = timeBetweenWave;

    }

    void update(){

        if(state == SpwanState.WAITING){

            if(!isEnemyAlaive()){
                waveCompleted();

            }
            else{
                return;
            }

        }



        if (waveCountDown <=0){
            if(state != SpwanState.SPAWNING){
                StartCoroutine( SpawnWave( waves[nextWave]));
            }
        }
        else{
            waveCountDown -= Time.deltaTime;
        }        
    }

    void waveCompleted(){
        Debug.Log("Wave completed");
        
        state = SpwanState.COUNTING;
        waveCountDown = timeBetweenWave;

        if(nextWave+1 > waves.Length -1 ){
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETED.... looping");

        }
        else{
            nextWave ++;
        }
    }

    bool isEnemyAlaive(){

        serchCountdown -= Time.deltaTime;
        if(serchCountdown <= 0f){
            serchCountdown = 1f;
            if(GameObject.FindWithTag("Enemy") == null){
                return false;
            }        
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave){
        state = SpwanState.SPAWNING;

        for(int i=0; i < _wave.count; i++){
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpwanState.WAITING;
        
        yield  break;
    }


    void SpawnEnemy(Transform _enemy){

        //Instantiate (_enemy, 0f, 0f);

        Debug.Log("Spawning Enemy");
    }
}
