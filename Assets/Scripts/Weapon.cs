using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    protected float _damage;
    protected float _delay;
    protected float _range;
    protected int _layer;

    public Component component { get { return this; } }
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
    public abstract void Use();
}

public abstract class Firearm : Weapon, IFirearm
{
    protected float _bulletSpeed;
    protected int _capacity;
    protected int _ammo;

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
    public int Reload(int ammo)
    {
        if(this.Ammo + ammo <= this.Capacity)
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