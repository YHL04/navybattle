using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : ScriptableObject
{
    public void spawnItem(GameObject prefab, Vector3 location)
    {
        GameObject g = Instantiate(prefab, location, Quaternion.identity);
    }
}
