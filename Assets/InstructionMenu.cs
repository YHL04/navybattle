using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onInstructions()
    {
        SceneManager.LoadScene(7);
    }
    public void instructMain()
    {
        SceneManager.LoadScene(0);
    }
}
