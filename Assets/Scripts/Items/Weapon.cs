using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : InventoryItem, IWeapon
{
    protected float _damage;
    protected float _delay;
    protected float _range;
    protected int _layer;
    public float Damage
    {
        get { return _damage; }
    }
    public float Delay
    {
        get { return _delay; }
    }
    public float Range
    {
        get { return _range; }
    }
    public int Layer
    {
        get { return _layer; }
        set { _layer = value; }
    }
}