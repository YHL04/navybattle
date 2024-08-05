using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class Item : MonoBehaviour, IItem
{
    public Component component { get { return this; } }

    public abstract ItemType Type { get; }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
public abstract class InventoryItem : Item, IInventoryItem
{
    public abstract void Use();

    private IEnumerator OnDropActivate()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }
    public void OnDrop()
    {
        // Cooldown on grabbing again, needs to be a separate function call
        StartCoroutine(OnDropActivate());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.gameObject.GetComponent<Character>();
        // Must be picked up by a character
        if (c)
        {
            // Must be a player
            if (c.gameObject.layer == Layers.PLAYER)
            {
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                c.PickUpItem(this);
            }
        }
    }
}
public abstract class Weapon : InventoryItem, IWeapon
{
    protected float _damage;
    protected float _delay;
    protected float _range;
    protected int _layer;
    public float Damage
    {
        get { return _damage; }
    }
    public float Delay
    {
        get { return _delay; }
    }
    public float Range {
        get { return _range; }
    }
    public int Layer
    {
        get { return _layer; }
        set { _layer = value; }
    }
}

public abstract class Firearm : Weapon, IFirearm
{
    protected float _bulletSpeed;
    protected float _bulletSpread;
    protected int _capacity;
    protected int _ammo;
    protected bool _ready;
    protected float _reloadTime;
    protected BulletSpawner bulletSpawner;
    public int Ammo
    {
        get { return _ammo; }
    }
    public int Capacity
    {
        get { return _capacity; } 
    }

    public float BulletSpeed
    {
        get { return _bulletSpeed; }
    }
    public float BulletSpread
    {
        get { return _bulletSpread; }
    }
    public float ReloadTime
    {
        get { return _reloadTime; }
    }
    // REDEFINE
    protected IEnumerator Cooldown(float time)
    {
        _ready = false;
        yield return new WaitForSeconds(time);
        _ready = true;
    }
    public override ItemType Type {
        get { return ItemType.FIREARM; }
    }
    // All guns reload the same way
    public int Reload(int ammo)
    {
        // If we aren't ready return same amount
        if(!_ready)
        {
            return ammo;
        }
        StartCoroutine(Cooldown(_reloadTime));
        if (this.Ammo + ammo <= this.Capacity)
        {
            this._ammo += ammo;
            // No ammo remaining 
            return 0;
        } else
        {
            int remaining = ammo + this.Ammo - this.Capacity;
            this._ammo = this.Capacity;
            return remaining;
        }
    }
}