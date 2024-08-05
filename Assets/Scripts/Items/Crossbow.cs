using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Crossbow : Firearm
{
    [SerializeField]
    private GameObject bulletPrefab;
    private void Awake()
    {
        // TEMP HIGH DAMAGE: DEATH IN 5 SHOTS
        this._damage = 100f;
        this._delay = 1.0f;
        this._range = 150f;
        this._bulletSpeed = 40f;
        this._bulletSpread = 5f;
        this._capacity = 8;
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
            StartCoroutine(Cooldown());
            this._ammo--;
        }
    }
}
