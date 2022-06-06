using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour
{
    Transform target;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        GetComponent<NavMeshAgent2D>().destination = target.position;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) <= 1)
        {
            GameEvents.instance.EnemyArrivedToDestination.Invoke();
            GetComponent<ApplyDamage_Lydia>().ApplyDamageToDamagable(target.gameObject.GetComponent<Damagable_Lydia>());
            Destroy(gameObject);

        }
    }
}