using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class PauseEscape : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the specified scene
            SceneManager.LoadScene(0);
        }
    }
}

