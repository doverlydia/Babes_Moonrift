using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        if (GetComponent<Damagable_Lydia>().Dead)
            GameEvents.instance.EnemyDeath.Invoke();
    }
}
