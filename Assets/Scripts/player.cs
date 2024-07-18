using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Character character;
    [SerializeField]
    private Camera camera;
    private int hotkey;
    // Awake is called on the instantiation of the class
    void Awake()
    {
        this.hotkey = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (character)
        {
            // CARRY CURRENT ITEM
            character.HoldItem();
            // PLAYER MOTION
            float dx = Input.GetAxis("Horizontal");
            float dy = Input.GetAxis("Vertical");
            character.Move(dx, dy);

            // PLAYER SWITCHES HOTKEY
            for(int i = 0; i < character.InventorySize ; i++)
            {
                if(Input.GetKeyDown(KeyCode.Alpha1+i))
                {
                    character.Hotkey = i;
                }
            }

            // PLAYER ANGLE
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - character.transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            character.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            
            // PLAYER USES ITEM
            if(Input.GetKeyDown(KeyCode.E))
            {
                character.UseItem(hotkey);
            }
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
