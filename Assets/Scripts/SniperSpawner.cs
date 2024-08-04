using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class SniperSpawner : Spawner
{
    private GameObject sniperPrefab;
    private FirearmSpawner sniperRifleSpawner;

    public void Initialize()
    {
        sniperPrefab = Resources.Load<GameObject>("Prefabs/Sniper");
        sniperRifleSpawner = CreateInstance<FirearmSpawner>();
        sniperRifleSpawner.Initialize("SniperRifle");
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject characterObject = Instantiate(sniperPrefab, location, Quaternion.identity);
        Character c = characterObject.GetComponent<Character>();
        // Obtain a pistol
        GameObject sniperRifleObject = sniperRifleSpawner.spawn(c.transform.position);
        // Set up the player
        c.PickUpItem(sniperRifleObject.GetComponent<IItem>());
        return characterObject;
    }
}
