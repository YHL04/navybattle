using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public override ItemType Type
    {
        get { return ItemType.FIREARM; }
    }
    // All guns reload the same way
    public int Reload(int ammo)
    {
        // If we aren't ready return same amount
        if (!_ready)
        {
            return ammo;
        }
        StartCoroutine(Cooldown(_reloadTime));
        if (this.Ammo + ammo <= this.Capacity)
        {
            this._ammo += ammo;
            // No ammo remaining 
            return 0;
        }
        else
        {
            int remaining = ammo + this.Ammo - this.Capacity;
            this._ammo = this.Capacity;
            return remaining;
        }
    }
}