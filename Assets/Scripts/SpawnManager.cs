using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float interval = 5f;
    public GameObject enemy;
    public Transform[] spawns;
    public int spawnLimit;
    private float time;
    private int counter;

    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        while (spawnLimit > 0)
        {
            time += Time.deltaTime;

                while (time >= interval && counter <= 4)
                {
                    for (int i = 0; i < spawns.Length; i++)
                    {
                        Instantiate(enemy, spawns[i].position, spawns[i].rotation);
                    }
                    time -= interval;
                    counter++;
                }
            spawnLimit--;
        }
    }
}
