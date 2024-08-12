using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFirearm : IWeapon
{
    float BulletSpeed { get; }
    float BulletSpread { get; }
    int Ammo { get; }
    int Capacity { get; }
    float ReloadTime { get; }
    public int Reload(int ammo);
}