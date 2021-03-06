using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class AgentEnemy : MonoBehaviour
{
    Transform target;
    [SerializeField] GameObject corpsePrefab;
    [SerializeField] GameObject poofPrefab;
    [SerializeField] GameObject summonPortalPrefab;

    private void Awake()
    {
        Instantiate(summonPortalPrefab, transform.position, Quaternion.identity);
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        GetComponent<NavMeshAgent2D>().destination = target.position;
        GetComponent<Damagable_Lydia>().onHit.AddListener(()=>OnHit());
        GetComponent<Damagable_Lydia>().onDeath.AddListener(()=>OnDeath());
        
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) <= 1)
        {
            GameEvents.instance.EnemyArrivedToDestination.Invoke();
            GetComponent<ApplyDamage_Lydia>().ApplyDamageToDamagable(target.gameObject.GetComponent<Damagable_Lydia>());
            Instantiate(poofPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    void OnHit()
    {
        GetComponent<Animator>().SetTrigger("hit");
    }
    void OnDeath()
    {
        Instantiate(corpsePrefab, transform.position, Quaternion.identity);
    }
}