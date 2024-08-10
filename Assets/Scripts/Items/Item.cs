using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Item : MonoBehaviour, IItem
{
    public Component component { get { return this; } }

    public abstract ItemType Type { get; }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}