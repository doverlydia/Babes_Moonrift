using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawns;
    public int spawnLimit;
    private float time;
    public float buffer;

    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > buffer && spawnLimit > 0)
        {
            time = 0f;
            //for (int i = 0; i < spawnLimit; i++)
            //{
                Instantiate(enemy, spawns.position, spawns.rotation);
            spawnLimit--;
            //}
        }
    }
}
