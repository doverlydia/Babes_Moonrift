using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*  
 * Starting Enemy Script
 * Written by Mark Walker
 * 5/26/22
 * Edits by Frank Kovacs, 6/5/22
 */
public class EnemyDestruct : MonoBehaviour
{
    //Insertion point for enemyDeath prefab
    public GameObject deathEffect;

    // Update is called once per frame
    public void Die()
    {
        Destroy(gameObject);
        //Will work best with Collider2D
        //After the game object (enemy) is destroyed, the deathEffect
        //Will play for the alloted time in the Destroy() function
        //Tune the time to what you think works best
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.75f);
        }
    }
}
