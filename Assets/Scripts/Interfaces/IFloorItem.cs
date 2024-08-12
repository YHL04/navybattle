using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFloorItem : IItem
{
    public void OnTriggerEnter2D(Collider2D collision);
}
