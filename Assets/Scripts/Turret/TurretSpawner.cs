using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    BoxCollider2D bounds;
    SpriteRenderer sr;
    public bool canSpawn => CanSpawn();
    [SerializeField] List<Collider2D> results = new List<Collider2D>();
    ContactFilter2D contactFilter = new ContactFilter2D();
    [SerializeField] LayerMask layerMask;
    private void Start()
    {
        bounds = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        contactFilter.layerMask = layerMask;
        contactFilter.useLayerMask = true;
    }
    public bool CanSpawn()
    {
        if (bounds.OverlapCollider(contactFilter, results) > 0)
        {
            return false;
        }
        return true;
    }

    private void Update()
    {
        Vector3 worldPoint = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(worldPoint);
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;

        if (CanSpawn())
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.red;
        }
    }
}
