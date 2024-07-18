using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class SoldierSpawner : Spawner
{
    private GameObject soldierPrefab;
    private PistolSpawner pistolSpawner;

    public void Initialize()
    {
        soldierPrefab = Resources.Load<GameObject>("Prefabs/Soldier");
        pistolSpawner = CreateInstance<PistolSpawner>();
        pistolSpawner.Initialize();
    }
    public override GameObject spawn(Vector3 location)
    {
        Debug.Log(soldierPrefab);
        GameObject characterObject = Instantiate(soldierPrefab, location, Quaternion.identity);
        Character c = characterObject.GetComponent<Character>();
        // Obtain a pistol
        GameObject pistolObject = pistolSpawner.spawn(c.transform.position);
        // Set up the player
        c.PickUpItem(pistolObject.GetComponent<IItem>());
        return characterObject;
    }
}
