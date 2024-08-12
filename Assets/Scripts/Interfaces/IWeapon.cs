using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon : IInventoryItem
{
    float Damage { get; }
    float Delay { get; }
    float Range { get; }
}
