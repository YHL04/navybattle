using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : ControllableCharacter
{
    [SerializeField]
    private Camera cam;
    private PlayerInputActions playerControls;

    public override void Awake()
    {
        base.Awake();
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        // ENABLING CALLS
        playerControls.Player.Move.performed += Move;
        playerControls.Player.Move.canceled += Move;

        playerControls.Player.Look.performed += Look;
        playerControls.Player.Use.performed += UseItem;
        playerControls.Player.Inventory.performed += Inventory;
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // INPUT SYSTEM CALLS
    private void Move(InputAction.CallbackContext context)
    {
        if(character)
        {
            Vector2 dir = context.ReadValue<Vector2>();
            if (context.canceled)
            {
                character.Move(0, 0);
            }
            else
            {
                character.Move(dir.x, dir.y);
            }
        }
        
    }
    private void Look(InputAction.CallbackContext context)
    {
        if(character)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(context.ReadValue<Vector2>());
            Vector3 rotation = mousePos - character.transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            character.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
    private void UseItem(InputAction.CallbackContext context)
    {
        if(character)
        {
            character.UseItem();
        }
    }
    private void Inventory(InputAction.CallbackContext context)
    {
        if(character)
        {
            // Parse key number
            int key = 0;
            Int32.TryParse(context.control.name, out key);
            if (key < character.InventorySize)
            {
                character.Hotkey = key - 1;
            }
        }
    }
    // Update is called once per frame
    public override void Update()
    {
        if (character)
        {
            // Check if player is dead
            if (!character.isAlive())
            {
                character.Terminate();
                character = null;
                // DO NOT set player to inactive on death of a character!
                return;
            }
            // CARRY CURRENT ITEM
            character.HoldItem();
            // PLAYER MOTION
            /*float dx = Input.GetAxis("Horizontal");
            float dy = Input.GetAxis("Vertical");
            character.Move(dx, dy);

            // PLAYER SWITCHES HOTKEY
            for (int i = 0; i < character.InventorySize; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                character.UseItem();
            }*/
        }
    }
    // Disconnect the current player (flag for destruction)
    public void Disconnect()
    {
        this.active = false;
    }
}
