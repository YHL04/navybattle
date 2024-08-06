using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class JohnNavyGun : Firearm
{
    [SerializeField]
    private GameObject bulletPrefab;
    private void Awake()
    {
        // two(?) shot
        this._damage = 2000f;
        this._delay = 0.1f;
        this._range = 2000f;
        this._bulletSpeed = 10f;
        this._bulletSpread = 1f;
        this._capacity = 10000000;
        this._ammo = this._capacity;
        this._ready = true;
        this.bulletSpawner = ScriptableObject.CreateInstance<BulletSpawner>();
        this.bulletSpawner.Initialize(this);
    }
    public override void Use()
    {
        if (this._ammo > 0 && _ready)
        {
            bulletSpawner.spawn(transform.position);
            StartCoroutine(Cooldown(_delay));
            this._ammo--;
        }
    }
}
