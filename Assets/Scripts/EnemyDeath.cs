using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        GameEvents.instance.EnemyDeath.Invoke();
    }
}
