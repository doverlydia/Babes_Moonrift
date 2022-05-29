using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootMode
{
    up,
    enemy,
    mouse
}
public class Turret_Lydia : MonoBehaviour
{
    [SerializeField] private ObjectPool_Lydia pool;
    [SerializeField] private float CoolDownRanged;
    [SerializeField] Transform firePointTransform;
    public GameControll controll { get; private set; }
    public LookAt2D_Lydia lookAt { get; private set; }
    private float lastShot;
    [SerializeField] ShootMode mode;
    //private bool firstClick = false;
    //private bool _isActive;
    //public bool isActive {
    //    get { return _isActive; } set {
    //        _isActive = value;
    //        if (value == true)
    //        {
    //            firstClick = true; 
    //        }               
    //    } }

    internal Vector2 shootVector => GetShootVector();

    Vector2 GetShootVector()
    {
        switch (mode)
        {
            case ShootMode.mouse:
                return (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            case ShootMode.enemy:         
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemies.Length > 0)
                {
                    Transform enemy = enemies[Random.Range(0, enemies.Length - 1)].transform;
                    return (enemy.position - transform.position).normalized;
                }
                else
                {
                    return Vector2.up;
                }
            default:
                return Vector2.up;
        }
    }

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
        //if (isActive && firstClick == false && Input.GetMouseButton(0))
        //{
        Pew();
        //}
        //else if (isActive && firstClick == true)
        //{
        //    firstClick = false;
        //}
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
