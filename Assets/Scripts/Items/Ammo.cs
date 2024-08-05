using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Ammo : FloorItem
{
    private int _count;

    public void Awake()
    {
        _count = 0;
    }
    public int Count { get { return _count; } set { _count = value; } }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.gameObject.GetComponent<Character>();
        // Must be picked up by a character
        if (c)
        {
            // Must be a player
            if (c.gameObject.layer == Layers.PLAYER)
            {
                c.StockAmmo(_count);
                Destroy(gameObject);
            }
        }
    }
}
