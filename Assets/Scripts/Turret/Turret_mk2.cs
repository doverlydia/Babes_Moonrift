using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
 * Turret Control Script
 * Written by Mark Walker
 * 5/26/22
 */
public class Turret_mk2 : MonoBehaviour
{
    private Camera cam;
    [SerializeField, Range(1, 1000)] private float rotationSpeed = 1;
    [SerializeField] private SimpleProjectile bullet;
    [SerializeField] private Transform spawnPoint;

    void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        //Captures mouse position
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        //Captures direction relative to transform
        var direction = mousePosition - transform.position;
        transform.up = Vector3.MoveTowards(transform.up, direction, rotationSpeed * Time.deltaTime);

        //Instantiates bullet if left mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnPoint.position, Quaternion.identity).Init(transform.up);
        }
    }
}
