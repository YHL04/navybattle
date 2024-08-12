using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
    public void OnSettings()
    {
        SceneManager.LoadScene(2);
    }
}
