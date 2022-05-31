using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Reticle movement script
 * Written by Mark Walker
 * 5/26/22
 */
public class Reticle : MonoBehaviour
{
    private Vector3 mouseCoordinates;
    public float MouseSensitivity = 0.1f;

    // Update is called once per frame
    void Update()
    {
        GameObject crosshair = GameObject.Find("Crosshair");
        mouseCoordinates = Input.mousePosition;
        mouseCoordinates = Camera.main.ScreenToWorldPoint(mouseCoordinates);
        crosshair.transform.position = Vector2.Lerp(transform.position, mouseCoordinates, MouseSensitivity);     
    }
}
