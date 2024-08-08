using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/**
 *  ICharacter represents variables and functions that all Character implementations need.
 */
public interface ICharacter : IComponent
{
    // Represents a scaler for the character's movement speed
    float MovementSpeed { get; }
    // Represents the current health of a character
    float Health { get; }
    // Represents the total health
    float MaxHealth { get; }
    // Represents the defense of a character (lowers the damage they take)
    float Defense { get; }
    // Characters need to hold ammo
    int Ammo { get; }
    // Chracters need to implement their own move logic
    void Move(float dx, float dy);
    // Characters need to take damage
    void TakeDamage(float damage);
    // Chracters need to be able to identify if they have died
    bool isAlive();
    // Apply buffs to the current character
    void Upgrade(float hp, float defense, float movementSpeed);
    // Heal the character some amount
    void Heal(float hp);
    // Reload the charactere's ammo
    void StockAmmo(int ammo);
    // Terminate the character gameobject
    void Terminate();

    // NOTE: Not every character needs an inventory or be able to use items!
}

public interface IInventory
{
    int InventorySize { get; }
    int Hotkey { get; set; }
    void UseItem();
    void PickUpItem(IInventoryItem item);
    void DropItem();
}

/**
 *  Character is an abstract class that represents a specific character a Player can choose.
 *  Character is responsible for unique motion implementations, display, health, etc.
 */
public abstract class Character : MonoBehaviour, ICharacter, IInventory
{
    // SerializeField allows us to edit private variables in Unity (e.g. it is listed for us to edit despite being private)
    protected float _movementSpeed;
    protected float _maxHealth;
    protected float _health;
    protected float _defense;
    protected int _hotkey;
    protected int _ammo;
    protected float _vision;
    protected IInventoryItem[] _inventory;

    // Implementations of interface functions and variables
    public Component component { get { return this; } }
    public float MovementSpeed
    {
        get { return _movementSpeed; }
    }
    public float Health
    {
        get { return _health; }
    }
    public float MaxHealth
    {
        get { return _maxHealth; }
    }
    public float Defense
    {
        get { return _defense; }
    }
    public int InventorySize
    {
        get { return _inventory.Length; }
    }
    public int Hotkey
    {
        get { return _hotkey; }
        set
        {
            if(value >= 0 && value < _inventory.Length)
            {
                if(_inventory[_hotkey] != null)
                {
                    _inventory[_hotkey].gameObject.SetActive(false);
                }
                _hotkey = value;
                if (_inventory[_hotkey] != null)
                {
                    _inventory[_hotkey].gameObject.SetActive(true);
                }
            }
        }
    }
    public int Ammo
    {
        get { return _ammo; }
    }
    // Vision is how far this character can see by default for targetting entities (e.g. for enemies)
    public float Vision
    {
        get { return _vision; }
    }

    // Character needs to have its layer set (player enemy)
    public void SetLayer(int layer)
    {
        this.gameObject.layer = layer;
        for(int i = 0; i < _inventory.Length; i++)
        {
            if (_inventory[i] != null)
            {
                _inventory[i].gameObject.layer = layer;
            }
        }
    }
    // Character needs to "Hold" item
    public void HoldItem()
    {
        if (_inventory[_hotkey] != null)
        {
            // TEMPORARY DIMENSIONAL SHIFTS
            _inventory[_hotkey].transform.position = this.transform.position + this.transform.rotation*Vector2.right;
            _inventory[_hotkey].transform.rotation = this.transform.rotation;
        }
    }
    // Every character has the same move logic
    public void Move(float dx, float dy)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(dx * MovementSpeed, dy * MovementSpeed);
    }
    // Every character will have the same attack logic, just with a different weapon
    public void UseItem()
    {
        if (_inventory[_hotkey] != null)
        {
            _inventory[_hotkey].Use();
        }
    }

    // Reload the current item if it supports reloading
    public void Reload()
    {
        if (_inventory[_hotkey] != null)
        {
            ItemType type = _inventory[_hotkey].Type;
            if(type == ItemType.FIREARM)
            {
                IFirearm firearm = (IFirearm) _inventory[_hotkey];
                this._ammo = firearm.Reload(_ammo);
            }
        }
    }
    public void PickUpItem(IInventoryItem item)
    {
        for(int i = 0; i < _inventory.Length; i++)
        {
            if (_inventory[i] == null)
            {
                _inventory[i] = item;
                _inventory[i].gameObject.layer = this.gameObject.layer;
                // DISABLE ITEM (s.t. it doesn't show if its not our hotbar)
                if(i != _hotkey)
                {
                    _inventory[i].gameObject.SetActive(false);
                    _inventory[i].enabled = false;
                }
                return;
            }
        }
    }
    public void DropItem()
    {
        if (_inventory[_hotkey] != null)
        {
            _inventory[_hotkey].OnDrop();
            _inventory[_hotkey] = null;
        }
    }
    // Every character will take damage by the same algorithm
    public void TakeDamage(float damage)
    {
        // This function can change... about every 2 defense will half the damage taken. Note we clamp with 0
        this._health = Mathf.Clamp(this.Health - damage / (0.5f * this.Defense + 1), 0, float.MaxValue);
    }
    // Check if the character is alive
    public bool isAlive()
    {
        return _health > 0;
    }
    // Upgrade the character's stats
    public void Upgrade(float hp, float defense, float movementSpeed)
    {
        this._maxHealth += hp;
        this._defense += defense;
        this._movementSpeed += movementSpeed;
    }
    // Heal the character
    public void Heal(float hp)
    {
        this._health = Mathf.Clamp(this.Health + hp, 0, this.MaxHealth);
    }
    // Stock ammo
    public void StockAmmo(int ammo)
    {
        this._ammo += ammo;
    }
    // Terminate the current character GameObject
    public void Terminate()
    {
        for(int i = 0; i < _inventory.Length; i++)
        {
            if (_inventory[i] != null)
            {
                _inventory[i].Destroy();
            }
        }
        Destroy(gameObject);
    }
}
