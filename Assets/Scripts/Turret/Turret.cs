using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //Having issues assigning main camera when turret is made into a prefab - Mark
    //[SerializeField] private Camera cam;
    private Camera cam;
    [SerializeField] private BulletMovement bulletPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float clampAngle = 90f;
    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private float totalCharge;
    [SerializeField] private float rechargeSpeed;

    [SerializeField] private float bulletsPS;

    //Setting camera to main here as opposed to in the inspector to mitigate information not
    //carrying over into the prefab - Mark
    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.up = Vector3.MoveTowards(transform.up, mousePos, rotationSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity).Init(transform.up);
        }
    }

}