using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Add me!!

public class MenuSettings : MonoBehaviour
    
{
    public TMP_Dropdown graphicsDrop;
    // Start is called before the first frame update
    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDrop.value);
    }
   public void OnQuit()
    {
        Application.Quit();
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
