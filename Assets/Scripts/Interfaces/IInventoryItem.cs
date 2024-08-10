using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem : IFloorItem, IDropItem
{
    void Use();
}