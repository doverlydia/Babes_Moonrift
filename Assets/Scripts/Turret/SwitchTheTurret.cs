using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchTheTurret : MonoBehaviour
{
    Turret_Lydia myTurret;
    private void Awake()
    {
        myTurret = GetComponentInChildren<Turret_Lydia>();
    }
    public void OnMouseDown()
    {
        Debug.Log("hello!");
        if (!myTurret.isActive)
        {
            myTurret.controll.ChangeTurret(myTurret);
        }
    }
}