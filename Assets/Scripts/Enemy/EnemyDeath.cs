using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    public AudioSource EDeath;

    public void PlayEDeath()
    {
        EDeath.Play();
    }
    private void OnDestroy()
    {
        if (GetComponent<Damagable_Lydia>().Dead)
            GameEvents.instance.EnemyDeath.Invoke();
        PlayEDeath();
    }
}
