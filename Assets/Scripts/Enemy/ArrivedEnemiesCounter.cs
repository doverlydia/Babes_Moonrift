using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivedEnemiesCounter : MonoBehaviour
{
    [field: SerializeField]public int arrivedEnemies { get; private set; }
    private void Start()
    {
        GameEvents.instance.EnemyArrivedToDestination.AddListener(AddToCounter);
    }
    private void AddToCounter()
    {
        arrivedEnemies++;
    }
}
