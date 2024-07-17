using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Firearm
{
    private BulletSpawner bulletSpawner;
    [SerializeField]
    private GameObject bulletPrefab;
    private void Awake()
    {
        this._damage = 5f;
        this._delay = 0.5f;
        this._range = 100f;
        this._bulletSpeed = 100f;
        this._capacity = 12;
        this._ammo = this._capacity;
        this.bulletSpawner = ScriptableObject.CreateInstance<BulletSpawner>();
    }
    public override void Use()
    {
        bulletSpawner.spawnBullet(bulletPrefab, this, this._layer);
    }
}
