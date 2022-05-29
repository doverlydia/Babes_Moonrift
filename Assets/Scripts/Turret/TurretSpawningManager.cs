using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawningManager : MonoBehaviour
{
    public static TurretSpawningManager Instance;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject turretPrefab;
    [SerializeField] TurretSpawner turretSpawner;
    private bool CanAffordTurret(int price)
    {
        return playerStats.Money >= price;
    }

    private void SpawnTurretAtPos(GameObject turret, Vector3 pos)
    {
        Instantiate(turret, pos, Quaternion.identity);
    }

    public void TrySpawn(GameObject turret)
    {
        if (turretSpawner.canSpawn)
        {
            SpawnTurretAtPos(turret, turretSpawner.transform.position);
            turretSpawner.gameObject.SetActive(false);
        }
    }

    public void ActivateTurretSpawner()
    {
        if (CanAffordTurret(0))
            turretSpawner.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (turretSpawner.gameObject.activeInHierarchy && Input.GetMouseButtonDown(0))
        {
            TrySpawn(turretPrefab);
        }
    }
}
