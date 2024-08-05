using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FloorItem : Item, IFloorItem
{
    public override ItemType Type
    {
        get { return ItemType.DROP; }
    }
    public abstract void OnTriggerEnter2D(Collider2D collision);
}