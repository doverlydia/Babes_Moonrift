using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWithLimitedRange_Alex : MonoBehaviour
{
    private Vector2 moveDir;
    public float moveSpeed = 5f;

    private void OnEnable()
    {
        Invoke("Destroy", 0.5f); // here you can set your own bullet lifetime_ Alex

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    public void MovementDirection(Vector2 dir)
    {
        moveDir = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
