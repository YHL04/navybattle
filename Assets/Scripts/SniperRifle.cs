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
        this._damage = 200f;
        this._delay = 1.0f;
        this._range = 200f;
        this._bulletSpeed = 100f;
        this._capacity = 6;
        this._ammo = this._capacity;
        this.bulletSpawner = ScriptableObject.CreateInstance<BulletSpawner>();
        this.bulletSpawner.Initialize(this);
    }
    public override void Use()
    {
        if (this._ammo > 0)
        {
            bulletSpawner.spawn(transform.position);
            this._ammo--;
        }
    }
}
