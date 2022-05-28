using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage_Lydia : MonoBehaviour
{
    [SerializeField] float damage;

    public void ApplyDamageToDamagable(Damagable_Lydia damagable)
    {
        damagable.TakeDamage(damage);
    }
}
