using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public interface IItem : IComponent
{
    void Use(ICharacter c, int flag=0);
    void Destroy();
}

public interface IWeapon : IItem
{
    float Damage { get; }
    float Delay { get; }
    float Range { get; }
}

public interface IFirearm : IWeapon
{
    float BulletSpeed { get; }
    float BulletSpread { get; }
    int Ammo { get; }
    int Capacity { get; }
}