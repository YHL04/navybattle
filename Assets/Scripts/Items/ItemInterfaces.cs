using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

// This enum will allow us to cast up to a differennt interface
public enum ItemType
{
    ITEM,
    WEAPON,
    FIREARM,
    CONSUMABLE
}
public interface IItem : IComponent
{
    ItemType Type { get; }
    void Use();
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
    public int Reload(int ammo);
}