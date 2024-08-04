using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowSpawner : Spawner
{
    private GameObject crossbowPrefab;
    public void Initialize()
    {
        crossbowPrefab = Resources.Load<GameObject>("Prefabs/Crossbow");
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject pistolObject = Instantiate(crossbowPrefab, location, Quaternion.identity);
        return pistolObject;
    }
}
