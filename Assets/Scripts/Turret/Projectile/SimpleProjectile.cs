using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*  
 * Simple Projectile Script
 * Written by Mark Walker
 * 5/26/22
 */
public class SimpleProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    
    
    public void Init(Vector2 direction)
    {
        //Uses current direction and set speed to generate velocity
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Sends to enemy to despawn it
        if (col.gameObject.tag == "Enemy")
        {
            col.transform.GetComponent<EnemyDestruct>().Die();
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Bullet")
        {

        }
        //Destroys in collision with player or wall
        else
        {
            Destroy(gameObject);
        }
        
    }
}
