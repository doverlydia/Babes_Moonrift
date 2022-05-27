using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTheTurret : MonoBehaviour
{
    public GameControll control;

    void OnMouseDown()
    {
        control.ChangeTurret(this.gameObject);
        GetComponent<Turret>().enabled = true;
    }
}
