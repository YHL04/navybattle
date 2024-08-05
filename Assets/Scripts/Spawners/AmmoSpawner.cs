using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : Spawner
{
    private int count;
    private GameObject ammoPrefab;

    public void Initialize(int count)
    {
        this.count = count;
        ammoPrefab = Resources.Load<GameObject>("Prefabs/Ammo");
    }
    public override GameObject spawn(Vector3 location)
    {
        GameObject ammoObject = Instantiate(ammoPrefab, location, Quaternion.identity);
        Ammo c = ammoObject.GetComponent<Ammo>();
        c.Count = count;
        return ammoObject;
    }
}
