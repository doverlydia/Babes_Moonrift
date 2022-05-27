using System.Collections.Generic;
using UnityEngine;

/*
 * Switching Turret Control Script
 * Original script made by Alex
 * 5/27/22
 */

public class SwitchTheTurret : MonoBehaviour
{
    public GameControll control;


    //Attempting to get it to work when pressing the 'E' key
    //Currently works to enable the first turret but cannot be used to enable
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            control.ChangeTurret(this.gameObject);
            GetComponent<Turret>().enabled = true;
        }
        
    }
    */

    void OnMouseDown()
    {
        control.ChangeTurret(this.gameObject);
        GetComponent<Turret>().enabled = true;
    }

}