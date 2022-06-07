using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable_Lydia : MonoBehaviour
{
    [SerializeField] float maxHp;
    internal bool Dead => currentHp <= 0;
    private float currentHp;
    public UnityEvent onHit;
    public UnityEvent onDeath;

    private void Start()
    {
        currentHp = maxHp;
    }
    public void TakeDamage(float howMuch)
    {
        //hit
        currentHp -= howMuch;
        onHit.Invoke();

        //death
        if (currentHp <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject,0.5f);
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
