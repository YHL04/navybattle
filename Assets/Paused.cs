using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    // Start is called before the first frame update
    public void PauseMain()
    {
        SceneManager.LoadScene(0);
    }
}
