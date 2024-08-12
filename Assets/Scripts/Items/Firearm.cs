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
    protected bool _isReloading;
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

    public bool IsReloading
    {
        get { return _isReloading; }
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
        if (!_ready || _isReloading)
        {
            return ammo;
        }

        StartCoroutine(ReloadCoroutine());
        return 0;
    }

    private IEnumerator ReloadCoroutine()
    {
        _isReloading = true;
        _ammo = 0;
        yield return new WaitForSeconds(_reloadTime);
        _ammo = _capacity;
        _isReloading = false;
        StartCoroutine(Cooldown(0.2f)); // Assuming a delay between reload and being ready to shoot
    }

    public override void Use()
    {
        if (_ready && _ammo > 0)
        {
            _ammo--;
            // Fire the weapon logic here
            _ready = false;
            StartCoroutine(Cooldown(0.2f)); // Assuming a delay between shots
        }
    }
}
