using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class InventoryItem : Item, IInventoryItem
{
    public abstract void Use();

    private IEnumerator OnDropActivate()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }
    public void OnDrop()
    {
        // Cooldown on grabbing again, needs to be a separate function call
        StartCoroutine(OnDropActivate());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.gameObject.GetComponent<Character>();
        // Must be picked up by a character
        if (c)
        {
            // Must be a player
            if (c.gameObject.layer == Layers.PLAYER)
            {
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                c.PickUpItem(this);
            }
        }
    }
}