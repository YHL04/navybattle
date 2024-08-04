using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmSpawner : Spawner
{
    private GameObject weaponPrefab;
    public void Initialize(string weaponType)
    {
        weaponPrefab = Resources.Load<GameObject>("Prefabs/" + weaponType);
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject pistolObject = Instantiate(weaponPrefab, location, Quaternion.identity);
        return pistolObject;
    }
}
