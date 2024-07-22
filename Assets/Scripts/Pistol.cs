using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Pistol : Firearm
{
    [SerializeField]
    private GameObject bulletPrefab;
    private void Awake()
    {
        // TEMP HIGH DAMAGE: DEATH IN 5 SHOTS
        this._damage = 60f;
        this._delay = 0.5f;
        this._range = 100f;
        this._bulletSpeed = 50f;
        this._capacity = 12;
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
