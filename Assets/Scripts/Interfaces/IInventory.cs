using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * IInventory represents inventory functionality operations
 */
public interface IInventory
{
    int InventorySize { get; }
    int Hotkey { get; set; }
    void UseItem();
    void PickUpItem(IInventoryItem item);
    void DropItem();
}