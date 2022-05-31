using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameControll : MonoBehaviour
{
    public Turret_Lydia[] turrets;
    //Turret_Lydia currentTurret = null;

    void Awake()
    {
        turrets = FindObjectsOfType<Turret_Lydia>();
        //currentTurret = turrets[1];
        //ChangeTurret(turrets[0]);
        //foreach(Turret_Lydia turret in turrets)
        //{
        //    turret.isActive = false;
        //    turret.lookAt.enabled = false;
        //}
    }
   //public void ChangeTurret(Turret_Lydia turret)
   // {
   //     turret.isActive = true;
   //     turret.lookAt.enabled = true;
        
   //     if (currentTurret != null)
   //     {
   //         currentTurret.isActive = false;
   //         currentTurret.lookAt.enabled = false;
   //     }
      
        
   //     currentTurret = turret;

   //     Debug.Log("turret changed!");
   // }
}
