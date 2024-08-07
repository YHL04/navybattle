using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerScreen : MonoBehaviour
{
    public void WinnerMain()
    {
        SceneManager.LoadScene(0);
        
    }

    public void WinnerQuit()
    {
        Application.Quit();
    }

}
