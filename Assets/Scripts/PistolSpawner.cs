using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSpawner : Spawner
{
    private GameObject pistolPrefab;
    public void Initialize()
    {
        pistolPrefab = Resources.Load<GameObject>("Prefabs/Pistol");
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject pistolObject = Instantiate(pistolPrefab, location, Quaternion.identity);
        return pistolObject;
    }
}
