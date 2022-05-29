using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Enemy Health Update Script
 * Written by Mark Walker
 * 5/29/22
 */

public class EHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Damagable_Lydia damageable;

    public GameObject healthBarUI;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        damageable = GetComponent<Damagable_Lydia>();
        health = damageable.GetCurrentHP();
        maxHealth = damageable.GetMaxHP();
        slider.value = CalculateHealth();

        //health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        health = damageable.GetCurrentHP();
        maxHealth = damageable.GetMaxHP();
        slider.value = CalculateHealth();

        if(health < maxHealth)
            healthBarUI.SetActive(true);
        if (health <= 0)
            Destroy(gameObject);
        if (health > maxHealth)
            health = maxHealth;
    }

    public float CalculateHealth()
    {
        return (health/maxHealth);
    }
}
