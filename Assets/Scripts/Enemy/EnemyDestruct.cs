using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*  
 * Starting Enemy Script
 * Written by Mark Walker
 * 5/26/22
 */
public class EnemyDestruct : MonoBehaviour
{
    // Update is called once per frame
    public void Die()
    {
        Destroy(gameObject);
    }
}
