using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Lydia : MonoBehaviour
{
    [SerializeField] private ObjectPool_Lydia pool;
    [SerializeField] private float CoolDownRanged;
    [SerializeField] Transform firePointTransform;
    public GameControll controll { get; private set; }
    public LookAt2D_Lydia lookAt { get; private set; }
    private float lastShot;

    public bool isActive = false;

    internal Vector2 shootVector => (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        lookAt = GetComponent<LookAt2D_Lydia>();
        controll = FindObjectOfType<GameControll>();
    }

    private void Start()
    {
        pool.Init();
    }

    private void Update()
    {
        if (isActive && Input.GetMouseButton(0))
        {
            Pew();
        }


    }

    void Pew()
    {
        if (Time.time - lastShot < CoolDownRanged)
        {
            return;
        }
        lastShot = Time.time;

        GameObject bullet = pool.GetPooledObjects();

        if (bullet != null)
        {
            bullet.transform.position = firePointTransform.position;
            Bullet_Lydia shot = bullet.GetComponent<Bullet_Lydia>();
            bullet.transform.parent = null;
            bullet.SetActive(true);
            shot.direction = shootVector;
        }
    }

}
