using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : ControllableCharacter
{
    [SerializeField]
    private Camera cam;
    private PlayerInputActions playerControls;
    private ProgressBar healthBar;
    private ProgressBar ammoBar;

    private Vector2 motionVector;
    public Camera Camera { get { return cam; } set { cam = value; } }

    Text ammoTracker;
    private TrackAmmo trackAmmo;

    public override void Awake()
    {
        base.Awake();
        playerControls = new PlayerInputActions();
        GameObject prefab = Resources.Load<GameObject>("Prefabs/ProgressBar");
        // Health Bar
        GameObject b1 = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        healthBar = b1.GetComponent<ProgressBar>();
        indicators.Add(healthBar);

        // Ammo Bar
        /*
        ammoTracker = GameObject.Find("AmmoCanvas").GetComponent<Text>();

        b1 = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        ammoBar = b1.GetComponent<ProgressBar>();
        ammoBar.SetColor(Color.yellow);
        indicators.Add(ammoBar);
        */
    }

    void Start()
    {
        // Find the TrackAmmo component in the scene
        trackAmmo = FindObjectOfType<TrackAmmo>();

        if (trackAmmo == null)
        {
            Debug.LogError("TrackAmmo component not found in the scene.");
        }
        else
        {
            UpdateAmmoUI();
        }
    }

    public void OnEnable()
    {
        playerControls.Enable();
        // ENABLING CALLS
        playerControls.Player.Move.performed += Move;
        playerControls.Player.Move.canceled += Move;

        playerControls.Player.Look.performed += Look;
        playerControls.Player.Use.performed += UseItem;
        playerControls.Player.Inventory.performed += Inventory;
        playerControls.Player.Reload.performed += Reload;
        playerControls.Player.Drop.performed += Drop;
    }

    public void OnDisable()
    {
        playerControls.Disable();
    }

    // INPUT SYSTEM CALLS
    public void Move(InputAction.CallbackContext context)
    {
        if (character)
        {
            Vector2 dir = context.ReadValue<Vector2>();
            if (context.canceled)
            {
                motionVector = Vector2.zero;
            }
            else
            {
                motionVector = dir;
            }
        }
    }

    private void Look(InputAction.CallbackContext context)
    {
        if (character)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(context.ReadValue<Vector2>());
            Vector3 rotation = mousePos - character.transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            character.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }

    public void UseItem(InputAction.CallbackContext context)
    {
        if (character)
        {
            character.UseItem();
            UpdateAmmoUI();
        }
    }

    public void Inventory(InputAction.CallbackContext context)
    {
        if (character)
        {
            // Parse key number
            int key = 0;
            Int32.TryParse(context.control.name, out key);
            if (key < character.InventorySize)
            {
                character.Hotkey = key - 1;
                UpdateAmmoUI();
            }
        }
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (character)
        {
            character.Reload();
            trackAmmo?.StartReload(); // Start reloading process and update UI to 0/
        }
    }

    public void Drop(InputAction.CallbackContext context)
    {
        if (character)
        {
            character.DropItem();
            UpdateAmmoUI();
        }
    }

    private void UpdateAmmoUI()
    {
        if (trackAmmo != null && character != null)
        {
            var weapon = character.GetCurrentWeapon() as Firearm;
            trackAmmo.SetCurrentWeapon(weapon);
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
                healthBar.Destroy();
                if (ammoBar != null) ammoBar.Destroy();
                character = null;
                // DO NOT set player to inactive on death of a character!
                return;
            }
            // MOVE
            character.Move(motionVector.x, motionVector.y);
            // CARRY CURRENT ITEM
            character.HoldItem();
            // HEALTH
            healthBar.transform.position = character.transform.position + Vector3.down * 1.3f;
            healthBar.UpdateAmount(character.Health, character.MaxHealth);
        }
    }

    // Disconnect the current player (flag for destruction)
    public void Disconnect()
    {
        this.active = false;
    }
}
