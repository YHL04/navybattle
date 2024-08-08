using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoldierSpawner : Spawner
{
    private GameObject soldierPrefab;
    private FirearmSpawner pistolSpawner;

    public void Initialize()
    {
        soldierPrefab = Resources.Load<GameObject>("Prefabs/Soldier");
        pistolSpawner = CreateInstance<FirearmSpawner>();
        pistolSpawner.Initialize("Pistol");
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject characterObject = Instantiate(soldierPrefab, location, Quaternion.identity);
        Character c = characterObject.GetComponent<Character>();
        // Obtain a pistol
        GameObject pistolObject = pistolSpawner.spawn(c.transform.position);
        // Disable the collider (in inventory)
        pistolObject.GetComponent<Collider2D>().enabled = false;
        // Set up the player
        c.PickUpItem(pistolObject.GetComponent<IInventoryItem>());
        return characterObject;
    }
}
