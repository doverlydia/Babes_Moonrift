using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject shop;



    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1f);
    }

    public void exitShop()
    {
        StartCoroutine(waiter());
        shop.SetActive(false);
    }

    public void enterShop()
    {
        shop.SetActive(true);
    }

}
