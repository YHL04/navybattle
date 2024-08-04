using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifleSpawner : Spawner
{
    private GameObject sniperRiflePrefab;
    public void Initialize()
    {
        sniperRiflePrefab = Resources.Load<GameObject>("Prefabs/SniperRifle");
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject pistolObject = Instantiate(sniperRiflePrefab, location, Quaternion.identity);
        return pistolObject;
    }
}
