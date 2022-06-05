using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possess : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<Turret_Lydia>() != null)
        {
            collision.gameObject.GetComponentInChildren<Turret_Lydia>().mode = ShootMode.mouse;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<Turret_Lydia>() != null)
        {
            collision.gameObject.GetComponentInChildren<Turret_Lydia>().mode = ShootMode.up;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}

