using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Enemy,
    Player
}

public class Damagable_Lydia : MonoBehaviour
{
    [SerializeField] float maxHp;
    internal bool Dead;
    private float currentHp;
    [SerializeField] EntityType entityType = EntityType.Enemy;

    private void Start()
    {
        currentHp = maxHp;
    }
    public void TakeDamage(float howMuch)
    {
        //hit
        currentHp -= howMuch;

        //death
        if (currentHp <= 0)
        {
            if (entityType == EntityType.Enemy)
            {
                GameEvents.EnemyDeath.Invoke();
            }

            Destroy(gameObject);
        }
    }
    public float GetCurrentHP()
    {
        return currentHp;
    }

    public void Heal()
    {
        currentHp = maxHp;
    }

    public float GetMaxHP()
    {
        return maxHp;
    }

    public void SetMaxHP(float _maxHP)
    {
        maxHp = _maxHP;
    }
}
