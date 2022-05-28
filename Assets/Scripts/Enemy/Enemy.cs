using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyEnemy;

    public void Die()
    {
        //Instantiate(destroyEnemy, transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }

}
