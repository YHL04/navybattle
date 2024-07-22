using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllableCharacter : MonoBehaviour
{
    protected Character character;
    protected int hotkey;
    protected bool active;
    // Check if the current player is active (flag for removal)
    public bool Active { get { return active;  } }
    public bool ActiveCharacter { get { return character != null; } }
    void Awake()
    {
        this.hotkey = 0;
        this.active = true;
    }
    // How updating occurs depends on the implementation. Controller class
    public abstract void Update();
    public void setCharacter(Character c)
    {
        this.character = c;
        this.character.SetLayer(this.gameObject.layer);
    }
    // Terminating the entity, maybe a player quits or an enemy dies
    public void Terminate()
    {
        if(this.character != null)
        {
            this.character.Terminate();
        }
        Destroy(this.gameObject);
    }
    // Get the current location of the player's character (if playing)
    public Transform GetLocation()
    {
        if(character != null)
        {
            return character.transform;
        }
        return null;
    }
}
public class Player : ControllableCharacter
{
    [SerializeField]
    private Camera cam;

    // Update is called once per frame
    public override void Update()
    {
        if (character)
        {
            // Check if player is dead
            if(!character.isAlive())
            {
                character.Terminate();
                character = null;
                // DO NOT set player to inactive on death of a character!
                return;
            }
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
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - character.transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            character.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            
            // PLAYER USES ITEM
            if(Input.GetKeyDown(KeyCode.E))
            {
                character.UseItem();
            }
        }
    }
    // Disconnect the current player (flag for destruction)
    public void Disconnect()
    {
        this.active = false;
    }
}