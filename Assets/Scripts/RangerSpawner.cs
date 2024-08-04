using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class RangerSpawner : Spawner
{
    private GameObject rangerPrefab;
    private FirearmSpawner crossbowSpawner;

    public void Initialize()
    {
        rangerPrefab = Resources.Load<GameObject>("Prefabs/Ranger");
        crossbowSpawner = CreateInstance<FirearmSpawner>();
        crossbowSpawner.Initialize("Crossbow");
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject characterObject = Instantiate(rangerPrefab, location, Quaternion.identity);
        Character c = characterObject.GetComponent<Character>();
        // Obtain a pistol
        GameObject crossbowObject = crossbowSpawner.spawn(c.transform.position);
        // Set up the player
        c.PickUpItem(crossbowObject.GetComponent<IItem>());
        return characterObject;
    }
}
