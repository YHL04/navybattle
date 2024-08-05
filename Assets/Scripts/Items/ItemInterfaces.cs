using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Progress;

// This enum will allow us to cast up to a different interface of importance
public enum ItemType
{
    FIREARM,
    DROP
}
public interface IItem : IComponent
{
    ItemType Type { get; }
    void Destroy();
}
public interface IFloorItem : IItem
{
    public void OnTriggerEnter2D(Collider2D collision);
}

public interface IDropItem : IItem
{
    void OnDrop();
}

public interface IInventoryItem : IFloorItem, IDropItem
{
    void Use();
}

public interface IWeapon : IInventoryItem
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
    float ReloadTime { get; }
    public int Reload(int ammo);
}