using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SniperRifle : Firearm
{
    [SerializeField]
    private GameObject bulletPrefab;
    private void Awake()
    {
        // two(?) shot
        this._damage = 150f;
        this._delay = 1.5f;
        this._reloadTime = 1f;
        this._range = 200f;
        this._bulletSpeed = 80f;
        this._bulletSpread = 0.5f;
        this._capacity = 4;
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
            this._ammo--;
            StartCoroutine(Cooldown(_delay));
        }
    }
}
