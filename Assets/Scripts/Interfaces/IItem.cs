using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem : IComponent
{
    ItemType Type { get; }
    void Destroy();
}
