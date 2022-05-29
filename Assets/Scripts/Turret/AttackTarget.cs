using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public Transform Point;
    public GameObject ProjectilePreFab;

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy)
        AttackEnemy(GetComponent<Transform>());
    }

    private void AttackEnemy(Transform enemy)
    {
        Vector3 dir = enemy.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject NewProjectile = Instantiate(ProjectilePreFab, Point.position, Quaternion.identity);
        NewProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        NewProjectile.GetComponent<Rigidbody2D>().AddForce(dir * 400);
    }
}
