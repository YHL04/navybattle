using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class JohnNavyBattleSpawner : Spawner
{
    private GameObject johnNavyBattlePrefab;
    private FirearmSpawner johnNavyBattleGunSpawner;

    public void Initialize()
    {
        johnNavyBattlePrefab = Resources.Load<GameObject>("Prefabs/JohnNavyBattle");
        johnNavyBattleGunSpawner = CreateInstance<FirearmSpawner>();
        johnNavyBattleGunSpawner.Initialize("JohnNavyGun");
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject characterObject = Instantiate(johnNavyBattlePrefab, location, Quaternion.identity);
        Character c = characterObject.GetComponent<Character>();
        // Obtain a pistol
        GameObject crossbowObject = johnNavyBattleGunSpawner.spawn(c.transform.position);
        // Set up the player
        c.PickUpItem(crossbowObject.GetComponent<IInventoryItem>());
        return characterObject;
    }
}
