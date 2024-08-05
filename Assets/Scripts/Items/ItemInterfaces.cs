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
public interface IDropItem : IItem
{
    public void OnTriggerEnter2D(Collider2D collision);
}
public interface IHoldableItem : IItem
{
    void Use();
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