using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [field: SerializeField] public int Money { get; private set; }

    private void Start()
    {
        GameEvents.instance.EnemyDeath.AddListener(() => AddMoney(1));
    }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public void SubtractMoney(int amount)
    {
        Money -= amount;
    }
}
