using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        //Add the name of the scene to be used.
        //SceneManager.LoadScene("scene-name");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
