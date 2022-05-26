using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float interval = 5f;
    [SerializeField] EnemyPlaceholder enemy;
    [SerializeField] Transform spawnPoint;
    float time;
    int counter = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        while (time >= interval && counter <= 10)
        {
            Instantiate(enemy, spawnPoint);
            time -= interval;
            counter++;
        }
    }



}

