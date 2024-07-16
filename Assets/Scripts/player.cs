using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Character character;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called based on a specific time inverval
    private void FixedUpdate()
    {
        if(character)
        {
            // Player motion is based on keystrokes
            float dx = Input.GetAxis("Horizontal");
            float dy = Input.GetAxis("Vertical");
            character.Move(dx, dy);
        }
    }

    // Set our character
    public void setCharacter(Character c)
    {
        if(character)
        {
            character.Terminate();
        }
        character = c;
    }
}
