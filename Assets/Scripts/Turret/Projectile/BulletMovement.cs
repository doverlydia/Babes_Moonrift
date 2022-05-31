using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 5f;

    public void Init(Vector2 direction)
    {
        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.GetComponent<Enemy>().Die();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
